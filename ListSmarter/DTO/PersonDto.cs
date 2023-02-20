namespace ListSmarter.DTO
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Task[]? Tasks { get; set; }

    }
}
