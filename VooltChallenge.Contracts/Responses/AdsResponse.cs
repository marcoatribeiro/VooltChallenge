namespace VooltChallenge.Contracts.Responses;

public sealed class AdsResponse
{
    public required IEnumerable<AdResponse> Items { get; init; } = [];
    public int TotalCount { get; init; }
}
