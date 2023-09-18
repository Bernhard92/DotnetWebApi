using Microsoft.EntityFrameworkCore;
using SUKiiServer.Application.Common.Interfaces;
using SUKiiServer.Domain.Common.Interfaces;
using SUKiiServer.Domain.Entities;

namespace SUKiiServer.Infrastructure.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly IApplicationDbContext _dbContext;

    public TodoRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public void Store(TodoItem todoItem)
    {
        throw new NotImplementedException();
    }

    public async Task<TodoItem> GetById(Guid id)
    {
        var todo = await _dbContext.TodoItems.FindAsync(id);
        if (todo == null)
        {
            throw new Exception($"Todo ({id}) not found");
        }
        return todo;
    }

    public async Task<IList<TodoItem>> GetAll()
    {
        var todoItems = await _dbContext.TodoItems.ToListAsync();
        return todoItems;
    }

    public void Add(TodoItem todoItem)
    {
        _dbContext.TodoItems.Add(todoItem);
    }   

    public void Delete(TodoItem todo)
    {
        _dbContext.TodoItems.Remove(todo);
    }

    public async Task Save()
    {
        await _dbContext.SaveChangesAsync(CancellationToken.None);
    }

}