using VooltChallenge.Application.Models;

namespace VooltChallenge.Application.Services;

public interface IAdService
{
    Task<bool> CreateOrUpdateAsync(Ad ad, CancellationToken token = default);
    
    Task<IEnumerable<Ad>> GetAllAsync(CancellationToken token = default);
    
    Task<int> GetTotalCountAsync(CancellationToken token = default);
}
