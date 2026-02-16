using Clgproj.Data;
using Clgproj.EventHandlers;
using Clgproj.Events;
using Clgproj.Infrastructure;
using Clgproj.Model;
using Clgproj.Repository.Implementations;
using Clgproj.Repository.Interfaces;
using Clgproj.Services.Implemantations;
using Clgproj.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File(
        "Logs/app-.log",
        rollingInterval: RollingInterval.Day)
    .CreateLogger();

// 
var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();


builder.Services.AddDbContext<WateringDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("WateringDb")));

builder.Services.AddDbContext<InvoiceDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("InvoiceDb")));

builder.Services.AddDbContext<FertilizerDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("FertilizerDb")));

builder.Services.AddDbContext<CultivationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("CultivationDb")));

builder.Services.AddDbContext<WateringDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AnalysisDb")));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IPlantAnalysisService, PlantAnalysisService>();
builder.Services.AddScoped<IWateringService, WateringService>();
builder.Services.AddScoped<IWaterOptimizationService, WaterOptimizationService>();
builder.Services.AddScoped<IPlantGrowthRepository, PlantGrowthRepository>();
builder.Services.AddScoped<IPlantGrowthService, PlantGrowthService>();
builder.Services.AddScoped<IPlantHistoryService, PlantHistoryService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IFertilizerRepository, FertilizerRepository>();
builder.Services.AddScoped<IFertilizerRecommandationService, FertilizerRecommendationService>();
builder.Services.AddScoped<IEventBus, EventBus>();
builder.Services.AddScoped<ICropYieldRepository, CropYieldRepository>();
builder.Services.AddScoped<ICropYieldService, CropYieldService>();

builder.Services.AddDbContext<GovernmentSchemeDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("GovernmentSchemeDb")));

builder.Services.AddScoped<IGovernmentSchemeRepository, GovernmentSchemeRepository>();
builder.Services.AddScoped<IGovernmentSchemeService, GovernmentSchemeService>();

builder.Services.AddDbContext<FarmerSchemeDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("FarmerSchemeDb")));

builder.Services.AddScoped<IFarmerSchemeApplicationRepository,
    FarmerSchemeApplicationRepository>();

builder.Services.AddScoped<IFarmerSchemeApplicationService,
    FarmerSchemeApplicationService>();

builder.Services.AddScoped<IEventBus, EventBus>();

builder.Services.AddScoped<
    IEventHandler<FarmerSchemeAppliedEvent>,
    FarmerSchemeAppliedEventHandler>();

builder.Services.AddScoped<
    IEventHandler<FarmerSchemeApprovedEvent>,
    FarmerSchemeApprovedEventHandler>();

builder.Services.AddScoped<
    IEventHandler<FarmerSchemeRejectedEvent>,
    FarmerSchemeRejectedEventHandler>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseRouting();

app.UseHttpsRedirection();


app.MapPost("/api/plant/analyze",
    async (IFormFile image, IPlantAnalysisService service) =>
    {
        var result = await service.AnalyzePlantAsync(image);
        return Results.Ok(result);
    });

app.MapGet("/api/plants/{id}/history",
    async (int id, IPlantHistoryService service) =>
    {
        return Results.Ok(await service.GetPlantWithHistoryAsync(id));
    });

app.MapPost("/api/plants/{plantId}/watering/schedule",
    async (int plantId, IWateringService service) =>
    {
        return Results.Ok(await service.GenerateScheduleAsync(plantId));
    });

app.MapPost("/api/plants/{plantId}/watering/execute",
    async (int plantId, IWateringService service) =>
    {
        var success = await service.ExecuteWateringIfDueAsync(
            plantId, service.GetWaterFrequency());
        return success ? Results.Ok("Watered") : Results.Ok("Not due");
    });

app.MapGet("/api/plants/{plantId}/water/optimize",
    async (int plantId, IWaterOptimizationService service) =>
    {
        var liters = await service.CalculateRequiredWaterAsync(plantId);
        return Results.Ok(new
        {
            PlantId = plantId,
            RequiredWaterInLiters = liters
        });
    });

app.MapPost("/api/fertilizer/usage",
    async (FertilizerUsage usage, IFertilizerRecommandationService service) =>
    {
        await service.RecordUsageAsync(usage);
        return Results.Ok("Fertilizer usage recorded successfully.");
    });

app.MapGet("/api/fertilizer/usage/{plantId}",
    async (int plantId, IFertilizerRecommandationService service) =>
    {
        var history = await service.GetUsageHistoryAsync(plantId);
        return Results.Ok(history);
    });

app.MapGet("/api/fertilizer/recommend",
    async (string plantType, string growthStage,
           IFertilizerRecommandationService service) =>
    {
        var fertilizer = await service.RecommendAsync(plantType, growthStage);
        return fertilizer is null
            ? Results.NotFound("No suitable fertilizer found")
            : Results.Ok(fertilizer);
    });

app.MapPost("/api/plants/{plantId}/yield/predict",
    async (int plantId, ICropYieldService service) =>
    {
        var result = await service.GeneratePridictionAsync(plantId);
        return Results.Ok(result);
    });

app.MapGet("/api/plants/{plantId}/yield/history",
    async (int plantId, ICropYieldService service) =>
    {
        var history = await service.GetPridictionHistoryAsync(plantId);
        return Results.Ok(history);
    });

app.MapPost("/api/schemes",
    async (GovernmentScheme scheme,
           IGovernmentSchemeService service) =>
    {
        var created = await service.CreateAsync(scheme);
        return Results.Ok(created);
    });

app.MapGet("/api/schemes/active",
    async (IGovernmentSchemeService service) =>
    {
        return Results.Ok(await service.GetActiveSchemesAsync());
    });

app.MapGet("/api/schemes/recommend",
    async (string crop, string season,
           IGovernmentSchemeService service) =>
    {
        return Results.Ok(await service.RecommendAsync(crop, season));
    });

app.MapPost("/api/farmer-schemes/apply",
    async (int schemeId, int farmerId,
           IFarmerSchemeApplicationService service) =>
    {
        var result = await service.ApplyAsync(schemeId, farmerId);
        return Results.Ok(result);
    });

app.MapGet("/api/farmer-schemes/{farmerId}",
    async (int farmerId,
           IFarmerSchemeApplicationService service) =>
    {
        return Results.Ok(
            await service.GetFarmerApplicationsAsync(farmerId));
    });

app.MapPost("/api/farmer-schemes/{applicationId}/approve",
    async (int applicationId,
           IFarmerSchemeApplicationService service) =>
    {
        await service.ApproveAsync(applicationId);
        return Results.Ok("Application approved");
    });

app.MapPost("/api/farmer-schemes/{applicationId}/reject",
    async (int applicationId,
           IFarmerSchemeApplicationService service) =>
    {
        await service.RejectAsync(applicationId);
        return Results.Ok("Application rejected");
    });


app.MapGet("/api/schemes/{id}",
    async (int id,
           IGovernmentSchemeService service) =>
    {
        var scheme = await service.GetByIdAsync(id);
        return scheme is null
            ? Results.NotFound()
            : Results.Ok(scheme);
    });



app.MapPost("/api/invoices/bulk-sale",
    (BulkInvoiceRequest request, IInvoiceService service) =>
    {
        var invoice = service.GenerateBulkSaleInvoice(
            request.FarmerName,
            request.BuyerName,
            request.Items);

        return Results.Ok(invoice);
    });


app.Run();
