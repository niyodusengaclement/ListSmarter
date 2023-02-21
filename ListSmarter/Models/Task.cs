using ListSmarter.Enums;


namespace ListSmarter.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public TaskStatusEnum Status { get; set; }
        public int? AssigneeId { get; set; }
        public Person? Assignee { get; set; }
        public int? BucketId { get; set; }
        public Bucket? Bucket { get; set; }
    }
}
