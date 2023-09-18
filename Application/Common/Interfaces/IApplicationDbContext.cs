using Microsoft.EntityFrameworkCore;
using SUKiiServer.Domain.Entities;

namespace SUKiiServer.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoItem> TodoItems { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellation);
    }
}
