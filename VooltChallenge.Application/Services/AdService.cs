using FluentValidation;
using VooltChallenge.Application.Models;
using VooltChallenge.Application.Repositories;

namespace VooltChallenge.Application.Services;

public sealed class AdService : IAdService
{
    private readonly IAdRepository _adRepository;
    private readonly IValidator<Ad> _adValidator;

    public AdService(IAdRepository adRepository, IValidator<Ad> adValidator)
    {
        _adRepository = adRepository;
        _adValidator = adValidator;
    }

    public async Task<bool> CreateOrUpdateAsync(Ad ad, CancellationToken token = default)
    {
        await _adValidator.ValidateAndThrowAsync(ad, cancellationToken: token);
        var adExists = await _adRepository.ExistsByIdAsync(ad.Id, token);
        if (!adExists)
        {
            return await _adRepository.CreateAsync(ad, token);
        }

        return await _adRepository.UpdateAsync(ad, token);
    }

    public Task<IEnumerable<Ad>> GetAllAsync(CancellationToken token = default)
    {
        return _adRepository.GetAllAsync(token);
    }

    public Task<int> GetTotalCountAsync(CancellationToken token = default)
    {
        return _adRepository.GetTotalCountAsync(token);
    }
}
