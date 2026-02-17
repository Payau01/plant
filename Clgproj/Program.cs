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



builder.Services.AddDbContext<InvoiceDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("InvoiceDb")));

builder.Services.AddDbContext<FertilizerDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("FertilizerDb")));

builder.Services.AddDbContext<CultivationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("CultivationDb")));

builder.Services.AddDbContext<AnalysisDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AnalysisDb")));

// Add services to the container.


builder.Services.AddScoped<IPlantAnalysisService, PlantAnalysisService>();
builder.Services.AddScoped<IWateringService, WateringService>();
builder.Services.AddScoped<IwaterOptimizationService, WaterOptimizationService>();
builder.Services.AddScoped<IPlantGrowthService, PlantGrowthService>();
builder.Services.AddScoped<IPlantHistoryService, PlantHistoryService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IFertilizerService, FertilizerService>();
builder.Services.AddScoped<IFertilizerUsageRepository, FertilizerUsageRepository>();
builder.Services.AddScoped<IPlantGrowthRepository, PlantGrowthRepository>();


builder.Services.AddScoped<IEventBus, EventBus>();


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
    async (int plantId, IwaterOptimizationService service) =>
    {
        var liters = await service.CalculateRequiredWaterAsync(plantId);
        return Results.Ok(new
        {
            PlantId = plantId,
            RequiredWaterInLiters = liters
        });
    });

app.MapPost("/api/fertilizer/usage",
    async (FertilizerUsage usage, IFertilizerService service) =>
    {
        await service.RecordUsageAsync(usage);
        return Results.Ok("Fertilizer usage recorded successfully.");
    });

app.MapGet("/api/fertilizer/usage/{plantId}",
    async (int plantId, IFertilizerService service) =>
    {
        var history = await service.GetUsageHistoryAsync(plantId);
        return Results.Ok(history);
    });


app.MapPost("/api/invoices/bulk-sale",
    (BulkInvoiceRequest request, IInvoiceService service) =>
    {
        var invoice = service.GenerateBulkSaleInvoiceAsync(
            request.FarmerName,
            request.BuyerName,
            request.Items);

        return Results.Ok(invoice);
    });
//


app.Run();
//


