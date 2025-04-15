
namespace TodoHttpServer.QueryEndpoints.Model
{
    public class TodoUpdateHistoryItem
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Status { get; set; }
        public required string EventTimeStamp { get; set; }
    }
}
