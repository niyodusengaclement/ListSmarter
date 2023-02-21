

using ListSmarter.Models;
using ListSmarter.Enums;

namespace ListSmarter.DTO
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public TaskStatusEnum Status { get; set; }
        public Person? Assignee { get; set; }
        public Bucket? Bucket { get; set; }
    }
}
