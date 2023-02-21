namespace ListSmarter.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<Task>? Tasks { get; set; }
    }
}
