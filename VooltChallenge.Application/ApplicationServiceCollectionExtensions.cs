using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VooltChallenge.Application.Database;
using VooltChallenge.Application.Repositories;
using VooltChallenge.Application.Services;

namespace VooltChallenge.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAdRepository, AdRepository>();
        services.AddScoped<IAdService, AdService>();
        // services.AddValidatorsFromAssemblyContaining<IApplicationMarker>(ServiceLifetime.Singleton);
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services,
        string databaseName)
    {
        services.AddDbContext<AdContext>(opt => opt.UseInMemoryDatabase(databaseName));
        //services.AddSingleton<DbInitializer>();
        return services;
    }
}
