using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VooltChallenge.Application.Models;

namespace VooltChallenge.Application.Database;

public sealed class AdContext : DbContext
{
    public AdContext(DbContextOptions<AdContext> options)
        : base(options) { }

    public DbSet<Ad> Ads { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Ad>(builder =>
        {
            builder.Property(x => x.Status)
                .HasConversion<EnumToStringConverter<AdStatus>>();
        });
    }
}
