using CQRSTodoApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSTodoApp.Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<ToDoTask> ToDoTasks { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
    }
}
