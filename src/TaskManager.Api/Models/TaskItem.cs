namespace TaskManager.Api.Models
{

    public enum TaskStatus { Todo = 0, InProgress = 1, Done = 2 }
    public enum TaskPriority { Low = 0, Medium = 1, High = 2 }
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;  //https://stackoverflow.com/questions/54724304/what-does-null-statement-mean
        public string? Description { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.Todo;
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DueDate { get; set; }
        public string OwnerId { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
