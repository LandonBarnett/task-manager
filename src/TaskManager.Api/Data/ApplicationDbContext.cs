using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TaskManager.Api.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add my own tables here 
        public DbSet<TaskManager.Api.Models.TaskItem> TaskItems { get; set; } = null!;

    }
}