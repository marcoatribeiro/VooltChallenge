using VooltChallenge.Application.Models;
using VooltChallenge.Contracts.Requests;
using VooltChallenge.Contracts.Responses;

namespace VooltChallenge.Api.Mapping;

internal static class ContractMapping
{
    public static Ad MapToAd(this CreateOrUpdateAdRequest request) => new()
    {
        Id = request.Id,
        Description = request.Description,
        CreationDate = DateTime.UtcNow,
        Status = string.IsNullOrEmpty(request.Status) ? AdStatus.Active : Enum.Parse<AdStatus>(request.Status),
        Balance = request.Balance,
        ExternalId = request.ExternalId,
        TotalLeads = request.TotalLeads
    };

    public static AdResponse MapToResponse(this Ad ad) => new()
    {
        Id = ad.Id,
        Description = ad.Description,
        CreationDate = ad.CreationDate,
        Status = ad.Status.ToString(),
        Balance = ad.Balance,
        ExternalId = ad.ExternalId,
        TotalLeads = ad.TotalLeads
    };

    public static AdsResponse MapToResponse(this IEnumerable<Ad> ads, int totalCount) => new()
    {
        Items = ads.Select(MapToResponse).ToList(),
        TotalCount = totalCount
    };
}
