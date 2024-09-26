using VooltChallenge.Shared;

namespace VooltChallenge.Ui.Client.Models;

public sealed class AdModel
{
    public AdModel() { }

    public AdModel(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public AdStatus Status { get; set; }
    public decimal? Balance { get; set; }
    public string? ExternalId { get; set; }
    public int TotalLeads { get; set; }
}
