using Microsoft.AspNetCore.Builder;

namespace TodoHttpServer.Endpoints
{
    public static class CommandEndpoints
    {
        public static void MapCommandEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/commands/example", () => "This is a command endpoint");
        }
    }
}