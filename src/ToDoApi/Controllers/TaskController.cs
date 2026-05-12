using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApi.Controllers;

[ApiController]
[Route("api/todo")]
public class TodoController : ControllerBase
{
    private readonly TodoService _service;
    public TodoController(TodoService service)
    {
        _service = service;
    }

    [HttpPost]
    public ActionResult<TodoItem> AddTask([FromBody] CreateTaskDto dto)
    {
        var created = _service.AddTask(dto.Title, dto.ListId);
        return CreatedAtAction(nameof(GetTaskById), new { id = created.Id }, created);
    }

    [HttpGet("{id}")]
    public ActionResult<TodoItem> GetTaskById(int id)
    {
        var item = _service.GetTaskById(id);
        return Ok(item);
    }
    
    [HttpGet]
    public ActionResult<List<TodoItem>> GetTasks()
    {
        return Ok(_service.GetTasks());
    }

    [HttpPut("{id}/complete")]
    public IActionResult CompleteTask(int id)
    {
        return Ok(_service.CompleteTask(id));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        return Ok(_service.DeleteTask(id));
    }

    [HttpGet("list/{listId}")]
    public ActionResult GetListById(int listId)
    {
        var list = _service.GetListById(listId);
        return Ok(list);
    }
}