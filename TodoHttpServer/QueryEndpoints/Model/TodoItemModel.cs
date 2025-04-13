
namespace TodoHttpServer.QueryEndpoints.Model
{
    public class TodoItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }
        public bool Completed { get; set; }
    }
}