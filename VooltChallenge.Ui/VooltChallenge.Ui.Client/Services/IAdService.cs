using VooltChallenge.Ui.Client.Models;

namespace VooltChallenge.Ui.Client.Services;

public interface IAdService
{
    Task<bool> CreateOrUpdateAsync(AdModel ad, CancellationToken token = default);
    
    Task<AdsListModel> GetAllAsync(CancellationToken token = default);
}
