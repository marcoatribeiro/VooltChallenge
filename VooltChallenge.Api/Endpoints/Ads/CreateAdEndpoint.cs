using Microsoft.AspNetCore.OutputCaching;
using VooltChallenge.Api.Mapping;
using VooltChallenge.Application.Services;
using VooltChallenge.Contracts.Requests;
using VooltChallenge.Contracts.Responses;
using VooltChallenge.Shared;

namespace VooltChallenge.Api.Endpoints.Ads;

internal static class CreateAdEndpoint
{
    public const string Name = "CreateOrUpdateAd";

    public static IEndpointRouteBuilder MapCreateOrUpdateAd(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiEndpoints.Ads.Create, async (
                CreateOrUpdateAdRequest request, IAdService adService,
                IOutputCacheStore outputCacheStore, CancellationToken token) =>
            {
                var ad = request.MapToAd();
                await adService.CreateOrUpdateAsync(ad, token);
                await outputCacheStore.EvictByTagAsync(OutputCache.AdsTag, token);
                return TypedResults.Ok();
            })
            .WithName(Name)
            .Produces<AdResponse>(StatusCodes.Status200OK)
            .Produces<ValidationFailureResponse>(StatusCodes.Status400BadRequest);
        return app;
    }
}
