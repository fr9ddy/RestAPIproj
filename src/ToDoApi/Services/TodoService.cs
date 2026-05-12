using System.Data.Common;

public class TodoService
{
    private readonly AppDbContext _db;
    public TodoService(AppDbContext db)
    {
        _db = db;
    }

    public TodoItem AddTask(string title, int id)
    {
        var item = new TodoItem { Title = title, Id = id, IsComplete = false };
        _db.TodoItems.Add(item);
        _db.SaveChanges();
        return item;
    }
    public bool CompleteTask(int id)
    {
        var task = _db.TodoItems.FirstOrDefault(t => t.Id == id);
        if(task == null)
        {
            throw new KeyNotFoundException();
        }
        task.IsComplete = true;
        _db.SaveChanges();
        return task.IsComplete;
    }
    public int DeleteTask(int id)
    {
        var task = _db.TodoItems.FirstOrDefault(t => t.Id == id);

        if(task == null)
        {
            throw new KeyNotFoundException();
        }
       _db.Remove(task);
       return id;
    }
    public List<TodoItem> GetTasks()
    {
        return _db.TodoItems.ToList();
    }
    public TodoItem? GetTaskById(int id)
    {
        var task = _db.TodoItems.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            throw new KeyNotFoundException();
        }
        return task;
    }
    
    public TodoList GetListById(int id)
    {
        var list = _db.TodoLists.FirstOrDefault(l => l.Id == id);
        if (list == null)
        {
            throw new KeyNotFoundException();
        }
        return list;
    }
}