using Microsoft.AspNetCore.Mvc;
using SUKiiServer.Application.Common.Interfaces.Services;
using SUKiiServer.Application.DTOs;

namespace SUKiiServer.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoItemsController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetTodoItems()
        {
            return await _todoService.GetAllTodos();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDto>> GetTodoItem(Guid id)
        {
            var todoItem = await _todoService.GetTodo(id);
            return todoItem;
        }

        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(Guid id, TodoItemDto todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            await _todoService.ChangeTodo(id, todoItem);
            return NoContent();
        }

        // POST: api/TodoItems
        [HttpPost]
        public async Task<ActionResult<TodoItemDto>> PostTodoItem(string name)
        {
            var todoItem = await _todoService.AddNewTodo(name);
            return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(Guid id)
        {
            await _todoService.RemoveTodo(id);
            return NoContent();
        }
    }
}
