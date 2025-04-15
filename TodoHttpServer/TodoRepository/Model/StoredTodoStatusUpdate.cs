 public class StoredTodoStatusUpdate
{
    public required int Id { get; set; }
    public required int TodoId { get; set; }
    public required string Status { get; set; }
    public required string EventTimeStamp { get; set; }
}