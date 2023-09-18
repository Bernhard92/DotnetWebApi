using SUKiiServer.Application.DTOs;

namespace SUKiiServer.Application.Common.Interfaces.Services
{
    public interface ITodoService
    {
        Task<List<TodoItemDto>> GetAllTodos();
        Task<TodoItemDto> GetTodo(Guid id);
        Task<TodoItemDto> ChangeTodo(Guid id, TodoItemDto todo);
        Task<TodoItemDto> AddNewTodo(string name);
        Task RemoveTodo(Guid id);
    }
}
