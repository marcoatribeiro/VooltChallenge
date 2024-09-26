using VooltChallenge.Api.Endpoints;
using VooltChallenge.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddDatabase("AdsDatabase");

builder.Services.AddEndpointsApiExplorer();

var backendUrl = builder.Configuration["BackendUrl"];

// Add a CORS policy for the client
builder.Services.AddCors(
    options => options.AddDefaultPolicy(
        policy => policy.WithOrigins(builder.Configuration["BackendUrl"] ?? "https://localhost:5276",
                builder.Configuration["FrontendUrl"] ?? "https://localhost:5176")
            .AllowAnyMethod()
            .AllowAnyHeader()));

builder.Services.AddOutputCache(x =>
{
    x.AddBasePolicy(c => c.Cache());
    x.AddPolicy(OutputCache.PolicyName, c => 
        c.Cache()
            .Expire(TimeSpan.FromMinutes(1))
            .Tag(OutputCache.AdsTag));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseOutputCache();

//app.UseMiddleware<ValidationMappingMiddleware>();
app.MapApiEndpoints();

//var dbInitializer = app.Services.GetRequiredService<DbInitializer>();
//await dbInitializer.InitializeAsync();


//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();

app.Run();
