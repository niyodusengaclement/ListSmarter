namespace ListSmarter.DTO
{
    public class BucketDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public List<Task>? Tasks { get; set; }
    }
}
