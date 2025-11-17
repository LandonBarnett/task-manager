using System.ComponentModel.DataAnnotations;

namespace TaskManager.Api.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;


        public string? Description { get; set; }


        public string Status { get; set; } = "Todo";


        public string Priority { get; set; } = "Medium";


        public DateTime? DueDate { get; set; }

        public DateTime CreatedAt { get; set; }


        public DateTime? UpdatedAt { get; set; }

    }
}
