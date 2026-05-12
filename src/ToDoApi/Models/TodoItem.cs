public class TodoItem
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool IsComplete { get; set; }
    public int ListId { get; set; }
    public TodoList? List { get; set; }
}