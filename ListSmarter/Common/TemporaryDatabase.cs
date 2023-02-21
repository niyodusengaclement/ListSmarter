using TaskModel = ListSmarter.Models.Task;
using ListSmarter.Models;
using ListSmarter.Enums;

namespace ListSmarter.Common
{
    public static class TemporaryDatabase
    {
        public static List<Person> People = new();
        public static List<Bucket> Buckets = new();
        public static List<TaskModel> Tasks = new();

        static TemporaryDatabase()
        {
            SeedData();
        }
        public static void SeedData()
        {
            for (int i = 0; i < 5; i++)
            {
                Person person = new()
                {
                    Id = i,
                    FirstName = $"Johnson{i + 1}",
                    LastName = $"Doe{i + 1}",
                };
                People.Add(person);


                TaskModel task = new()
                {
                    Id = i,
                    Title = $"Ticket #{i + 1}",
                    Description = $"This is Ticket number {i + 1}",
                    Status = TaskStatusEnum.Open,
                };
                Tasks.Add(task);


                Bucket bucket = new()
                {
                    Id = i,
                    Title = $"Baketti{i + 1}",
                };
                Buckets.Add(bucket);
            }
        }
    }
}
