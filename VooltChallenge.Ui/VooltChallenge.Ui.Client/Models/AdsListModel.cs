namespace VooltChallenge.Ui.Client.Models;

public sealed class AdsListModel
{
    public List<AdModel> Items { get; init; } = [];
    public int TotalCount { get; private set; }

    public void AddItem(AdModel item)
    {
        Items.Add(item);
        TotalCount++;
    }
}
