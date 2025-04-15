using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using TodoHttpServer.QueryEndpoints.Model;

namespace TodoHttpServer.QueryEndpoints
{
    public static class QueryEndpoints
    {
        public static void MapQueryEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/todos", async ([FromServices] TodoRepository repository) =>
            {
                var todos = await repository.GetAllTodosAsync();
                
                return Results.Ok(todos);
            });

            app.MapGet("/todos/active", async ([FromServices] TodoRepository repository) =>
            {
                var todos = await repository.GetAllActiveTodosAsync();
                 
                return Results.Ok(todos);
            });

            app.MapGet("/todos/completed", async ([FromServices] TodoRepository repository) =>
            {
                var todos = await repository.GetAllCompletedTodosAsync();
                
                return Results.Ok(todos);
            });
        }
    }

  
}