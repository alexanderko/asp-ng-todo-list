using Microsoft.EntityFrameworkCore;

namespace TodoSpa.Models {
    public class TodoContext : DbContext {
        public TodoContext (DbContextOptions<TodoContext> options) : base (options) { }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<TodoList>()
                .HasMany(l => l.Tasks)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<TodoList>()
                .HasData(
                    new TodoList { Id = 1, Title = "Get Junior Developer Position"}
                );

            modelBuilder
                .Entity<Task>()
                .HasData(
                    new Task { Id = 1, TodoListId = 1, Title = "Register on Meetup", IsDone = true },
                    new Task { Id = 2, TodoListId = 1, Title = "Get amazed by ASP.NET Core" },
                    new Task { Id = 3, TodoListId = 1, Title = "Apply to InterLink inCamp" }
                );
        }
    }
}
