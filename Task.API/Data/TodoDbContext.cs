using Microsoft.EntityFrameworkCore;
using Task.API.Models;

namespace Task.API.Data
{
    public class TodoDbContext : DbContext 
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) :base(options) 
        { 

        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
