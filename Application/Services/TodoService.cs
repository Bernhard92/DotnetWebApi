using SUKiiServer.Application.Common.Interfaces.Services;
using SUKiiServer.Application.DTOs;
using SUKiiServer.Domain.Common.Interfaces;
using SUKiiServer.Domain.Entities;

namespace SUKiiServer.Application.Services
{

    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }


        public async Task<List<TodoItemDto>> GetAllTodos()
        {
            var todos = await _todoRepository.GetAll();
            var dto = todos.Select(MapToDto);
            return dto.ToList();
        }

        public async Task<TodoItemDto> GetTodo(Guid id)
        {
            var todo = await _todoRepository.GetById(id);
            return MapToDto(todo);
        }

        public async Task<TodoItemDto> ChangeTodo(Guid id, TodoItemDto newTodo)
        {
            var todo = await _todoRepository.GetById(id);

            if (newTodo.IsComplete)
            {
                todo.CompleteTodo();
            }
            else
            {
                todo.ResetTodo();
            }

            if (string.IsNullOrEmpty(newTodo.Name))
            {
                throw new Exception("No Name given");
            }

            todo.ChangeName(newTodo.Name);

            await _todoRepository.Save();
            return newTodo;
        }

        public async Task<TodoItemDto> AddNewTodo(string name)
        {
            var todo = TodoItem.Create(name);
            _todoRepository.Add(todo);
            await _todoRepository.Save();
            return MapToDto(todo);
        }

        public async Task RemoveTodo(Guid id)
        {
            var todoItem = await _todoRepository.GetById(id);
            _todoRepository.Delete(todoItem);
            await _todoRepository.Save();
        }

        private TodoItemDto MapToDto(TodoItem todo)
        {
            return new TodoItemDto
            {
                Id = todo.Id,
                IsComplete = todo.IsComplete,
                Name = todo.Name
            };
        }
    }
}
