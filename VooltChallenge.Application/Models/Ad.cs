namespace VooltChallenge.Application.Models;

public sealed class Ad
{
    public required int Id { get; init; }
    public required string Description { get; init; }
    public required DateTime CreationDate { get; init; }
    public required AdStatus Status { get; init; }
    public decimal? Balance { get; set; }
    public string? ExternalId { get; set; }
    public int TotalLeads { get; init; }
}
