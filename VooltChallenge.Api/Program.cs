using VooltChallenge.Api.Endpoints;
using VooltChallenge.Api.Mapping;
using VooltChallenge.Application;
using VooltChallenge.Application.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddDatabase("AdsDatabase");

builder.Services.AddEndpointsApiExplorer();

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

app.UseMiddleware<ValidationMappingMiddleware>();
app.MapApiEndpoints();

// Seed the database
await using var scope = app.Services.CreateAsyncScope();
await DataSeeder.InitializeAsync(scope.ServiceProvider);

app.Run();
