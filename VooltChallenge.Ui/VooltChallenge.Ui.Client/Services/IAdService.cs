using VooltChallenge.Shared;
using VooltChallenge.Ui.Client.Models;

namespace VooltChallenge.Ui.Client.Services;

public interface IAdService
{
    Task<(bool Success, ValidationFailureResponse? FailureResponse)> CreateOrUpdateAsync(AdModel ad, CancellationToken token = default);
    
    Task<AdsListModel> GetAllAsync(CancellationToken token = default);
}
