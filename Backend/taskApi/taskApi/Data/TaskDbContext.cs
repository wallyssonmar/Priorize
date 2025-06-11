using Microsoft.EntityFrameworkCore;
using taskApi.Models;

namespace taskApi.Data
{
    public class TaskDbContext: DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext>options): base(options) { }
        
        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>()
                .HasKey(u => u.Id);
        }
    }
}
