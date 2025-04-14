using Dapper;
using System.Data;

public class TodoRepository
{
    private readonly IDbConnection _dbConnection;

    public TodoRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<StoredTodo>> GetAllTodosAsync()
    {
        var query = "SELECT * FROM Todos";
        return await _dbConnection.QueryAsync<StoredTodo>(query);
    }

    public async Task<int> CreateTodoAsync(string name, string currentDate)
    {
        var query = "INSERT INTO Todos (Name, CreationDate) VALUES (@Name, @CreationDate)";
        return await _dbConnection.ExecuteAsync(query, new
        {
            Name = name,
            CreationDate = currentDate,
        });
    }
}
