using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VooltChallenge.Application.Models;
using VooltChallenge.Shared;

namespace VooltChallenge.Application.Database;

public sealed class DataSeeder
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        await using var context = new AdContext(serviceProvider.GetRequiredService<DbContextOptions<AdContext>>());

        if (await context.Database.EnsureCreatedAsync())
        {
            await SeedAdsAsync(context);
        }
    }

    private static async Task SeedAdsAsync(AdContext context)
    {
        var faker = new Faker();
        var ads = new List<Ad>();

        for (int i = 1; i <= 15; i++)
        {
            ads.Add(new Ad
            {
                Id = i,
                Description = faker.Lorem.Sentence(5),
                CreationDate = faker.Date.Past(1),
                Status = faker.PickRandom<AdStatus>(),
                Balance = faker.Finance.Amount(0, 2000),
                ExternalId = faker.Random.AlphaNumeric(10),
                TotalLeads = faker.Random.Int(0, 200)
            });
        }

        await context.Ads.AddRangeAsync(ads);
        await context.SaveChangesAsync();
    }
}
