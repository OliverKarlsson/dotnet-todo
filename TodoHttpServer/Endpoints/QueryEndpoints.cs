using Microsoft.AspNetCore.Builder;

namespace TodoHttpServer.Endpoints
{
    public static class QueryEndpoints
    {
        public static void MapQueryEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/queries/example", () => "This is a query endpoint");
        }
    }
}