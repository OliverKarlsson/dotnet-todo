using TodoHttpServer.CommandEndpoints;
using TodoHttpServer.QueryEndpoints;
using Microsoft.Data.Sqlite;
using System.Data;
using Dapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDbConnection>(sp =>
{
    var connection = new SqliteConnection("Data Source=todo.db");
    connection.Open();
    return connection;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddOpenApi();

//builder.Services.AddSingleton<IDbConnection>(sp => new SqlConnection("YourConnectionStringHere"));
builder.Services.AddScoped<TodoRepository>();

var app = builder.Build();

void InitializeDatabase(IDbConnection connection)
{
    var createTodosQuery = @"
        CREATE TABLE IF NOT EXISTS Todos (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Name TEXT NOT NULL,
            CreationDate TEXT NOT NULL
        )";
    connection.Execute(createTodosQuery);

    var createTodosStatusQuery = @"
        CREATE TABLE IF NOT EXISTS Todos_Status_Updates (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            TodoId INTEGER NOT NULL,
            Status TEXT NOT NULL, -- e.g., 'Completed', 'Uncompleted'
            EventTimeStamp TEXT NOT NULL,
            FOREIGN KEY (TodoId) REFERENCES Todos(Id)
        )";
    connection.Execute(createTodosStatusQuery);
}

using (var scope = app.Services.CreateScope())
{
    var dbConnection = scope.ServiceProvider.GetRequiredService<IDbConnection>();
    InitializeDatabase(dbConnection);
}

app.UseCors("AllowFrontend");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapQueryEndpoints();
app.MapCommandEndpoints();

app.Run();
 
