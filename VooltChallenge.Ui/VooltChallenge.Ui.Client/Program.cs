using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using VooltChallenge.Ui.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddFluentUIComponents();

builder.Services.AddHttpClient("WebApi", client => client.BaseAddress = new Uri(builder.Configuration["BackendUrl"] ?? "https://localhost:5276"));
builder.Services.AddScoped<IAdService, AdService>();

await builder.Build().RunAsync();
