namespace VooltChallenge.Api.Endpoints.Ads;

internal static class AdEndpointExtensions
{
    internal static IEndpointRouteBuilder MapAdEndpoints(this IEndpointRouteBuilder app)
    {
        //app.MapGetAd();
        app.MapCreateOrUpdateAd();
        app.MapGetAllAds();
        //app.MapUpdateAd();
        //app.MapDeleteAd();
        
        return app;
    }
}
