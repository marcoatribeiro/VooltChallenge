using Microsoft.EntityFrameworkCore;
using VooltChallenge.Application.Database;
using VooltChallenge.Application.Models;

namespace VooltChallenge.Application.Repositories;

internal sealed class AdRepository : IAdRepository
{
    private readonly AdContext _context;

    public AdRepository(AdContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(Ad ad, CancellationToken token = default)
    {
        _context.Ads.Add(ad);
        var result = await _context.SaveChangesAsync(token);
        return result > 0;
    }

    public Task<bool> ExistsByIdAsync(int id, CancellationToken token = default)
    {
        return _context.Ads.AnyAsync(x => x.Id == id, token);
    }

    public Task<IEnumerable<Ad>> GetAllAsync(CancellationToken token = default)
    {
        return Task.FromResult(_context.Ads.AsEnumerable());
    }

    public Task<int> GetTotalCountAsync(CancellationToken token = default)
    {
        return _context.Ads.CountAsync(token);
    }

    public async Task<bool> UpdateAsync(Ad ad, CancellationToken token = default)
    {
        _context.Ads.Update(ad);
        var result = await _context.SaveChangesAsync(token);
        return result > 0;
    }
}
