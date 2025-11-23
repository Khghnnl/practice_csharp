using _20251118_ToDoApp_1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace _20251118_ToDoApp_1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Todo テーブルに相当する DbSet
        public DbSet<Todo> Todos => Set<Todo>();
    }
}
