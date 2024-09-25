using VooltChallenge.Api.Mapping;
using VooltChallenge.Application.Services;
using VooltChallenge.Contracts.Requests;
using VooltChallenge.Contracts.Responses;

namespace VooltChallenge.Api.Endpoints.Ads;

internal static class GetAllAdsEndpoint
{
    public const string Name = "GetAllAds";

    public static IEndpointRouteBuilder MapGetAllAds(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiEndpoints.Ads.GetAll, async (
                [AsParameters] GetAllAdsRequest request, IAdService adService, 
                CancellationToken token) =>
            {
                var ads = await adService.GetAllAsync(token);
                var adsTotalCount = await adService.GetTotalCountAsync(token);
                var adsResponse = ads.MapToResponse(adsTotalCount);
                return TypedResults.Ok(adsResponse);
            })
            .WithName(Name)
            .Produces<AdsResponse>(StatusCodes.Status200OK)
            .CacheOutput(OutputCache.PolicyName);
        return app;
    }
}
