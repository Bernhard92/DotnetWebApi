using Microsoft.EntityFrameworkCore;
using SUKiiServer.Application.Common.Interfaces;
using SUKiiServer.Domain.Entities;

namespace SUKiiServer.Infrastructure.DataAccess
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}