namespace VooltChallenge.Contracts.Requests;

public sealed class CreateOrUpdateAdRequest
{
    public required int Id { get; init; }
    public required string Description { get; init; }
    public string? Status { get; set; }
    public decimal? Balance { get; set; }
    public string? ExternalId { get; set; }
    public int TotalLeads { get; init; }
}
