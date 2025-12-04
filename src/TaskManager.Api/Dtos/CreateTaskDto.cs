using System.ComponentModel.DataAnnotations;
using TaskManager.Api.Models;

namespace TaskManager.Api.Dtos
{
    public class CreateTaskDto
    {
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Title { get; set; } = null!;

        [StringLength(2000)]
        public string? Description { get; set; }

        [StringLength(2000)]
        public string? Owner { get; set; }

        public DateTime? DueDate { get; set; }

        [EnumDataType(typeof(TaskPriority))]
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;

        //[EnumDataType(typeof(TaskManager.Api.Models.TaskStatus))]
        //public TaskManager.Api.Models.TaskStatus Status { get; set; } = TaskManager.Api.Models.TaskStatus.Todo;

        //public Boolean IsDeleted { get; set; } = false;

        /*
         *   public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string OwnerId { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
         * 
         * 
         * */

    }
}
