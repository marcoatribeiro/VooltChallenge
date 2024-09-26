namespace VooltChallenge.Api.Endpoints.Ads;

internal static class AdEndpointExtensions
{
    internal static IEndpointRouteBuilder MapAdEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapCreateOrUpdateAd();
        app.MapGetAllAds();
        
        return app;
    }
}
