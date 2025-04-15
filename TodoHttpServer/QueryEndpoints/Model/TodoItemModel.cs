
namespace TodoHttpServer.QueryEndpoints.Model
{
    public class TodoItemModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string CreationDate { get; set; }
        public required string Status { get; set; }
    }
}