namespace VooltChallenge.Contracts.Responses;

public sealed class AdResponse
{
    public required int Id { get; init; }
    public required string Description { get; init; }
    public required DateTime CreationDate { get; init; }
    public required string Status { get; init; }
    public decimal? Balance { get; set; }
    public string? ExternalId { get; set; }
    public required int TotalLeads { get; set; }
}
