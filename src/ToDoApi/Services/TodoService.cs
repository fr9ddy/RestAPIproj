public class TodoService
{
    private readonly AppDbContext _db;
    public TodoService(AppDbContext db)
    {
        _db = db;
    }

    public TodoItem AddTask(int listId, string title)
    {
        var list = _db.TodoLists.FirstOrDefault(l => l.Id == listId);
        if(list == null)
        {
            throw new KeyNotFoundException();
        }
        var item = new TodoItem { Title = title, ListId = listId, IsComplete = false };
        _db.TodoItems.Add(item);
        _db.SaveChanges();
        return item;
    }
    public TodoList CreateList(string name)
    {
        var list = new TodoList { Name = name };
        _db.TodoLists.Add(list);
        _db.SaveChanges();
        return list;
    }
    
    public void CompleteTask(int id)
    {
        var task = _db.TodoItems.FirstOrDefault(t => t.Id == id);
        if(task == null)
        {
            throw new KeyNotFoundException();
        }
        task.IsComplete = true;
        _db.SaveChanges();
    }
    public void DeleteTask(int id)
    {
        var task = _db.TodoItems.FirstOrDefault(t => t.Id == id);

        if(task == null)
        {
            throw new KeyNotFoundException();
        }
       _db.Remove(task);
       _db.SaveChanges();
    }
    public void DeleteList(int id)
    {
        var list = _db.TodoLists.FirstOrDefault(l => l.Id == id);

        if(list == null)
        {
            throw new KeyNotFoundException();
        }
        _db.Remove(list);
        _db.SaveChanges();
    }
    public List<TodoList> GetLists()
    {
        return _db.TodoLists.ToList();
    }

    public List<TodoItem> GetTasksByListId(int listId)
    {
        return _db.TodoItems.Where(t => t.ListId == listId).ToList();
    }
    public TodoItem GetTaskById(int listId, int taskId)
    {
        var task = _db.TodoItems.FirstOrDefault(t => t.Id == taskId && t.ListId == listId);
        if (task == null) throw new KeyNotFoundException();
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