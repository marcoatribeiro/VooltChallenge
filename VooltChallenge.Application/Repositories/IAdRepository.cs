using VooltChallenge.Application.Models;

namespace VooltChallenge.Application.Repositories;

public interface IAdRepository
{
    Task<bool> CreateAsync(Ad ad, CancellationToken token = default);
        
    Task<bool> ExistsByIdAsync(int id, CancellationToken token = default);
    
    Task<IEnumerable<Ad>> GetAllAsync(CancellationToken token = default);
    
    Task<int> GetTotalCountAsync(CancellationToken token = default);

    Task<bool> UpdateAsync(Ad ad, CancellationToken token = default);
}
