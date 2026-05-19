using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApi.Controllers;

[ApiController]
[Route("todo")]
public class TodoController : ControllerBase
{

    //HTTP LIST REQUESTS
    private readonly TodoService _service;
    public TodoController(TodoService service)
    {
        _service = service;
    }

    [HttpPost("lists")]
    public ActionResult<TodoList> CreateList([FromBody] CreateListDto dto)
    {
        var created = _service.CreateList(dto.Name);
        return CreatedAtAction(nameof(GetListById), new { listId = created.Id}, created);
    }

    [HttpGet("lists")]
    public ActionResult<List<TodoList>> GetLists()
    {
        var item = _service.GetLists();
        return Ok(item); // Returns 200
    }

    [HttpGet("lists/{listId}")]
    public ActionResult<TodoList> GetListById(int listId)
    {
        return Ok(_service.GetListById(listId)); //Returns 200
    }
    
    [HttpDelete("lists/{listId}")]
    public IActionResult DeleteList(int listId)
    {
        _service.DeleteList(listId);
        return NoContent(); // Returns 204 (no content)
    }

    //HTTP TASK REQUESTS
    [HttpPost("lists/{listId}/tasks")]
    public ActionResult<TodoItem> AddTask(int listId, [FromBody] CreateTaskDto dto)
    {
        try
        {
            var created = _service.AddTask(listId, dto.Name);
            return Ok(created);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPatch("lists/{listId}/tasks/{taskId}/complete")]
    public IActionResult CompleteTask(int listId, int taskId)
    {
        _service.CompleteTask(taskId);
        return NoContent();
    }

    [HttpDelete("lists/{listId}/tasks/{taskId}")]
    public IActionResult DeleteTask(int listId, int taskId)
    {
        _service.DeleteTask(taskId);
        return NoContent();
    }

    [HttpGet("lists/{listId}/tasks")]
    public ActionResult<TodoItem> GetTasksByListId(int listId)
    {
        return Ok(_service.GetTasksByListId(listId));
    }

    [HttpGet("lists/{listId}/tasks/{taskId}")]
    public ActionResult<TodoItem> GetTaskById(int listId, int taskId)
    {
        return Ok(_service.GetTaskById(listId, taskId));
    }
}