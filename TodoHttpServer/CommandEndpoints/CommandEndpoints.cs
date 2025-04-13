using Microsoft.AspNetCore.Builder;
using TodoHttpServer.CommandEndpoints.Model;

namespace TodoHttpServer.CommandEndpoints
{
    public static class CommandEndpoints
    {
        public static void MapCommandEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/commands/example", () => "This is a command endpoint");

            app.MapPost("/todos/create", async (CreateTodo todoItem) =>
            {
                return Results.Created($"/todos/6", todoItem);
            });

            app.MapPost("/todos/{TodoId}/complete", async (int TodoId) =>
            {
                return Results.Ok($"Todo with ID {TodoId} marked as complete.");
            });

            app.MapPost("/todos/{TodoId}/undo-complete", async (int TodoId) =>
            {
                return Results.Ok($"Completion undone for Todo with ID {TodoId}.");
            });
        }
    }
}