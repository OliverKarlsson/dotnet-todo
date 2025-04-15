using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TodoHttpServer.QueryEndpoints.Model;

public class TodoStatus
{
    public static readonly string Active = "Active";
    public static readonly string Completed = "Completed";
}

public class TodoRepository
{
    private readonly IDbConnection _dbConnection; 

    public TodoRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<TodoItemModel>> GetAllTodosAsync()
    {
        var query = MakeTodosSelectWithMatchingStatusQuery();

        return await _dbConnection.QueryAsync<TodoItemModel>(query);
    }

    public async Task CreateTodoWithActiveStatusAsync(string name, string currentDate)
    {
        using var transaction = _dbConnection.BeginTransaction();
        try
        {
            var queryTodo = "INSERT INTO Todos (Name, CreationDate) VALUES (@Name, @CreationDate);";
            await _dbConnection.ExecuteAsync(queryTodo, new
            {
                Name = name,
                CreationDate = currentDate
            }, transaction);

            var eventTimeStamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            var queryStatus = @"INSERT INTO Todos_Status_Updates (TodoId, Status, EventTimeStamp)
                VALUES (last_insert_rowid(), @Status, @EventTimeStamp)";
            await _dbConnection.ExecuteAsync(queryStatus, new
            { 
                Status = TodoStatus.Active,
                EventTimeStamp = eventTimeStamp
            }, transaction);

            transaction.Commit();
           
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<IEnumerable<TodoItemModel>> GetAllActiveTodosAsync()
    {
        var query = MakeTodosSelectWithMatchingStatusQuery(TodoStatus.Active);

        return await _dbConnection.QueryAsync<TodoItemModel>(query);
    }

    public async Task<IEnumerable<TodoItemModel>> GetAllCompletedTodosAsync()
    {
        var query = MakeTodosSelectWithMatchingStatusQuery(TodoStatus.Completed);

        return await _dbConnection.QueryAsync<TodoItemModel>(query);
    }

    public async Task CreateTodoStatusUpdateAsync(int todoId, string status)
    {
        var eventTimeStamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

        var query = "INSERT INTO Todos_Status_Updates (TodoId, Status, EventTimeStamp) VALUES (@TodoId, @Status, @EventTimeStamp)";
         await _dbConnection.ExecuteAsync(query, new
        {
            TodoId = todoId,
            Status = status,
            EventTimeStamp = eventTimeStamp
        });
    }

    private string MakeTodosSelectWithMatchingStatusQuery(string? status = "")
    {
        var optionalAndString = "";
        if (status == TodoStatus.Active)
        {
            optionalAndString = "AND B.Status = 'Active'";
        }
        else if (status == TodoStatus.Completed)
        {
            optionalAndString = "AND B.Status = 'Completed'";
        }
        var res = $@"SELECT
                A.*,
                B.Status as Status
            FROM Todos A
            INNER JOIN Todos_Status_Updates B
                ON A.Id = B.TodoId
                {optionalAndString}
            WHERE B.Id = (
                SELECT MAX(C.Id)
                FROM Todos_Status_Updates C
                WHERE A.Id = C.TodoId
                ORDER BY C.EventTimeStamp DESC
                LIMIT 1
            )";

        return res;
    }
}
