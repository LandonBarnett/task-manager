namespace TaskManager.Api.Dtos
{
    public class CreateTaskDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string Priority { get; set; }

        //public TaskPriority Priority { get; set; } = TaskPriority.Medium;
    }
}
