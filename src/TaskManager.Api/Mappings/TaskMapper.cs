//TODO - Add Automapper

using TaskManager.Api.Dtos;
using TaskManager.Api.Models;

namespace TaskManager.Api.Mappings
{
    public static class TaskMapper
    {
        /// <summary>
        /// Converts a <see cref="TaskItem"/> instance to its corresponding <see cref="TaskDto"/> representation.
        /// </summary>
        /// <param name="task">The <see cref="TaskItem"/> to convert. Cannot be null.</param>
        /// <returns>A <see cref="TaskDto"/> containing the mapped properties from the specified <paramref name="task"/>.</returns>
        public static TaskDto ToDto(TaskItem task)
        {
            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status.ToString(),
                Priority = task.Priority.ToString(),
                DueDate = task.DueDate
            };
        }

        /// <summary>
        /// Creates a new TaskItem entity from the specified CreateTaskDto instance.
        /// </summary>
        /// <param name="dto">The data transfer object containing the details of the task to be created. Cannot be null.</param>
        /// <returns>A TaskItem entity populated with the values from the specified CreateTaskDto.</returns>
        public static TaskItem ToEntity(CreateTaskDto dto)
        {
           return new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                DueDate = dto.DueDate,
                Priority = dto.Priority  //make sure this mapping works correctly
           };
    }
    }
}
