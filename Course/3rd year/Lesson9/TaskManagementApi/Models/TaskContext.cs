using Microsoft.EntityFrameworkCore;

namespace TaskManagementApi.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options): base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}