using Microsoft.AspNetCore.Builder;
using TodoHttpServer.QueryEndpoints.Model;

namespace TodoHttpServer.QueryEndpoints
{
    public static class QueryEndpoints
    {
        public static void MapQueryEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/todos", async () =>
            {
                var todos = new TodoItemModel[]
                {
                    new TodoItemModel { Id = 1, Name = "Buy groceries", CreationDate = "2025-01-01", Completed = true },
                    new TodoItemModel { Id = 2, Name = "Clean desk", CreationDate = "2025-01-02", Completed = true },
                    new TodoItemModel { Id = 3, Name = "Water plants", CreationDate = "2025-01-03", Completed = false },
                    new TodoItemModel { Id = 4, Name = "Finish report", CreationDate = "2025-01-04", Completed = false },
                    new TodoItemModel { Id = 5, Name = "Plan vacation", CreationDate = "2025-01-05", Completed = false }
                };
                return Results.Ok(todos);
            });

            app.MapGet("/todos/active", async () =>
            {
                var todos = new TodoItemModel[]
                {
                    new TodoItemModel { Id = 3, Name = "Water plants", CreationDate = "2025-01-03", Completed = false },
                    new TodoItemModel { Id = 4, Name = "Finish report", CreationDate = "2025-01-04", Completed = false },
                    new TodoItemModel { Id = 5, Name = "Plan vacation", CreationDate = "2025-01-05", Completed = false }
                };
                return Results.Ok(todos);
            });

            app.MapGet("/todos/completed", async () =>
            {
                var todos = new TodoItemModel[]
                {
                    new TodoItemModel { Id = 1, Name = "Buy groceries", CreationDate = "2025-01-01", Completed = true },
                    new TodoItemModel { Id = 2, Name = "Clean desk", CreationDate = "2025-01-02", Completed = true },
                };
                return Results.Ok(todos);
            });

        }
    }

  
}