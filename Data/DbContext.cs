using Microsoft.EntityFrameworkCore;
using TaskTracker.Api.Data;
using TrackerTask.Model;

namespace TaskTracker.Api.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Tasks => Set<Item>();
    }
}