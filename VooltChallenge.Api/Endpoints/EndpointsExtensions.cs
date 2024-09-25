using VooltChallenge.Api.Endpoints.Ads;

namespace VooltChallenge.Api.Endpoints;

internal static class EndpointsExtensions
{
    internal static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapAdEndpoints();
        return app;
    }
}
