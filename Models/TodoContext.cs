using Microsoft.EntityFrameworkCore;

namespace TodoSpa.Models {
    public class TodoContext : DbContext {
        public TodoContext (DbContextOptions<TodoContext> options) : base (options) { }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Task>()
                .HasData(
                    new Task { Id = 1, Title = "Register on Meetup", IsDone = true },
                    new Task { Id = 2, Title = "Get amazed by ASP.NET Core" },
                    new Task { Id = 3, Title = "Apply to InterLink inCamp" }
                );
        }
    }
}
