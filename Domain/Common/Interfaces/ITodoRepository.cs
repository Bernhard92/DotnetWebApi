using SUKiiServer.Domain.Entities;

namespace SUKiiServer.Domain.Common.Interfaces
{
    public interface ITodoRepository
    {
        void Store(TodoItem todoItem);
        Task<TodoItem> GetById(Guid id);
        Task<IList<TodoItem>> GetAll();
        void Delete(TodoItem todo);
        void Add(TodoItem todoItem);
        Task Save();
    }
}
