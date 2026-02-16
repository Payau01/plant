using clgproj.UI;
using clgproj.UI.Services.Api;
using Clgproj.Ui.Services.Api;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<PlantApiService>();
builder.Services.AddScoped<WateringApiService>();
builder.Services.AddScoped<FertilizerApiService>();
builder.Services.AddScoped<InvoiceApiService>();
builder.Services.AddScoped<AnalysisApiService>();


await builder.Build().RunAsync();

// ?? BACKEND CONNECTION (CHANGE PORT IF NEEDED)
builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri("https://localhost:5001/")
    });

