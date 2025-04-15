using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using TodoHttpServer.CommandEndpoints.Model;

namespace TodoHttpServer.CommandEndpoints
{
    public static class CommandEndpoints
    {
        public static void MapCommandEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/todos/create", async (CreateTodo todoItem, [FromServices] TodoRepository repository) =>
            {
                var currentDate = DateTime.UtcNow.ToString("yyyy-MM-dd");

                await repository.CreateTodoWithActiveStatusAsync(todoItem.Name, currentDate);
                return Results.Created($"/todos", todoItem);
            });

            app.MapPost("/todos/{TodoId}/complete", async (int TodoId, [FromServices] TodoRepository repository) =>
            {
                await repository.CreateTodoStatusUpdateAsync(TodoId, TodoStatus.Completed);
                return Results.Ok($"Todo with ID {TodoId} marked as complete.");
            });

            app.MapPost("/todos/{TodoId}/undo-complete", async (int TodoId, [FromServices] TodoRepository repository) =>
            {
                await repository.CreateTodoStatusUpdateAsync(TodoId, TodoStatus.Active);
                return Results.Ok($"Completion undone for Todo with ID {TodoId}.");
            });
        }
    }
}