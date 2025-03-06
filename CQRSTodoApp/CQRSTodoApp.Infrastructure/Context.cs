using CQRSTodoApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSTodoApp.Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<TodoTask> TodoTasks { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
    }
}
