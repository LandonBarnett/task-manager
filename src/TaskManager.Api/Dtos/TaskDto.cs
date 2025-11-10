namespace TaskManager.Api.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Status { get; set; } = "Todo";
        public string Priority { get; set; } = "Medium";
        public DateTime? DueDate { get; set; }
    }
}
