public class TodoList
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<TodoItem> Items { get; set; } = new();
    public bool IsDeleted { get; set; }
}