using ListSmarter.Controllers;
using ListSmarter.DTO;
using ListSmarter.Enums;
using System.Text.RegularExpressions;

namespace ListSmarter.ConsoleUI
{
    public class Menu
    {
        PersonController _personController;
        BucketController _bucketController;
        TaskController _taskController;
        public Menu(PersonController personController, BucketController bucketController, TaskController taskController)
        {
            _personController = personController;
            _bucketController = bucketController;
            _taskController = taskController;


            Console.Write("Enter your Name: ");
            string? name = Console.ReadLine();

            Console.WriteLine($"Hello {name}, How can we help you? [Type a number from menu below]");


            // Select option to perform
            Console.WriteLine();
            Console.WriteLine("Menu");
            Console.WriteLine("===========================================");
            Console.WriteLine();
            Console.WriteLine("1. List of all users");
            Console.WriteLine("2. Add user");
            Console.WriteLine("3. Get User by ID");
            Console.WriteLine("4. Update user");
            Console.WriteLine("5. Delete a user");

            Console.WriteLine();
            Console.WriteLine("11. List of all buckets");
            Console.WriteLine("12. Add bucket");
            Console.WriteLine("13. Get bucket by ID");
            Console.WriteLine("14. Update a bucket");
            Console.WriteLine("15. Delete a bucket");

            Console.WriteLine();
            Console.WriteLine("21. Get all tasks");
            Console.WriteLine("22. Assign Task to a user");
            Console.WriteLine("23. Assign Task to a bucket");
            Console.WriteLine("24. Get tasks of a bucket");
            Console.WriteLine("25. Update a task");
            Console.WriteLine("26. Change task status");
            Console.WriteLine("27. Delete a task");

            Console.WriteLine("0. Exit / Quit");
            Console.WriteLine();
        }
        public void OptionSelector()
        {
            Console.WriteLine();
            Console.WriteLine("Select a number and click enter. Enter 0 to Exit");
            string? ChoiceString = Console.ReadLine();
            string pattern = @"^[0-9]\d{0,1}$";
            if (string.IsNullOrEmpty(ChoiceString))
            {
                Console.WriteLine("Please enter valid choice");
                OptionSelector();
            }
            bool IsMatch = Regex.IsMatch(ChoiceString, pattern);
            if (!IsMatch)
            {
                Console.WriteLine("Please enter valid choice");
                OptionSelector();
            }
            int choice = Convert.ToInt32(ChoiceString);

            switch (choice)
            {
                case 0:
                    Console.WriteLine();
                    Console.WriteLine("Thank you for visiting ListSmarter. Good Bye <3 !");
                    break;
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("List of all users: \n");
                    List<PersonDto> persons = _personController.GetAll();

                    foreach (PersonDto person in persons)
                    {
                        Console.WriteLine($"{person.Id}. {person.FirstName} {person.LastName}");
                        Console.WriteLine($"Total tasks: {person?.Tasks?.Count}");
                        if (person?.Tasks?.Count > 0)
                        {
                            foreach (TaskDto task in person.Tasks)
                            {
                                Console.WriteLine($"|{task.Id}|{task.Title}|{task.Description}");
                            }
                        }
                        Console.WriteLine();
                    }
                    OptionSelector();
                    break;

                case 2:

                    Console.WriteLine("Add user section. Please fill the following info");
                    Console.WriteLine();

                    Console.Write("Enter firstname: ");
                    string Firstname = Console.ReadLine();

                    Console.Write("Enter lastname: ");
                    string Lastname = Console.ReadLine();

                    int LastUserIdx = _personController.GetAll().Count();
                    _personController.Add(new PersonDto() { Id = LastUserIdx, FirstName = Firstname, LastName = Lastname });

                    OptionSelector();
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("Get User by ID: \n");

                    Console.Write("Enter User ID: ");
                    int UserId = Convert.ToInt32(Console.ReadLine());

                    PersonDto user = _personController.GetById(UserId);
                    Console.WriteLine($"{user.Id}. {user.FirstName} {user.LastName}");
                    OptionSelector();
                    break;
                case 4:
                    Console.WriteLine();

                    Console.WriteLine("Update user section. Please fill the following info");
                    Console.WriteLine();

                    Console.Write("Enter User ID: ");
                    int PersonId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter firstname: ");
                    string FirstnameUpdates = Console.ReadLine();

                    Console.Write("Enter lastname: ");
                    string LastnameUpdates = Console.ReadLine();

                    _personController.Update(PersonId, new PersonDto() { Id = PersonId, FirstName = FirstnameUpdates, LastName = LastnameUpdates });

                    OptionSelector();
                    break;
                case 5:
                    Console.WriteLine();
                    Console.WriteLine("Delete user \n");

                    Console.Write("Enter User ID: ");
                    int LateUserId = Convert.ToInt32(Console.ReadLine());

                    string Msg = _personController.Delete(LateUserId);

                    Console.WriteLine(Msg);

                    OptionSelector();
                    break;

                // Bucket cases
                case 11:
                    Console.WriteLine();
                    Console.WriteLine("List of all buckets \n");
                    List<BucketDto> buckets = _bucketController.GetAll();

                    foreach (BucketDto theBucket in buckets)
                    {
                        Console.WriteLine($"{theBucket.Id}. {theBucket.Title}");
                        Console.WriteLine();
                    }
                    OptionSelector();
                    break;

                case 12:

                    Console.WriteLine("Add bucket section. Please fill the following info");
                    Console.WriteLine();

                    Console.Write("Enter Title: ");
                    string BucketTitle = Console.ReadLine();


                    int LastBucketIdx = _bucketController.GetAll().Count();
                    _bucketController.Add(new BucketDto() { Id = LastBucketIdx, Title = BucketTitle });

                    OptionSelector();
                    break;
                case 13:
                    Console.WriteLine();
                    Console.WriteLine("Get Bucket by ID: \n");

                    Console.Write("Enter User ID: ");
                    int BucketId = Convert.ToInt32(Console.ReadLine());

                    BucketDto bucket = _bucketController.GetById(BucketId);

                    Console.WriteLine($"ID: {bucket.Id}");
                    Console.WriteLine($"Title: {bucket.Title}");

                    OptionSelector();
                    break;
                case 14:
                    Console.WriteLine();

                    Console.WriteLine("Update bucket section. Please fill the following info");
                    Console.WriteLine();

                    Console.Write("Enter bucket ID: ");
                    int ExistingBucketId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter title: ");
                    string TitleUpdates = Console.ReadLine();


                    _bucketController.Update(ExistingBucketId, new BucketDto() { Id = ExistingBucketId, Title = TitleUpdates });

                    OptionSelector();
                    break;
                case 15:
                    Console.WriteLine();
                    Console.WriteLine("Delete bucket \n");

                    Console.Write("Enter Bucket ID: ");
                    int LateBacketrId = Convert.ToInt32(Console.ReadLine());

                    string DeleteMsg = _bucketController.Delete(LateBacketrId);

                    Console.WriteLine(DeleteMsg);

                    OptionSelector();
                    break;
                case 16:
                    Console.WriteLine();
                    Console.WriteLine("Get Bucket tasks: \n");

                    Console.Write("Enter Bucket ID: ");

                    Console.WriteLine("List of bucket tasks \n");
                    List<BucketDto> theBuckets = _bucketController.GetAll();

                    foreach (BucketDto b in theBuckets)
                    {
                        Console.WriteLine($"{b.Id}. {b.Title}");
                        Console.WriteLine();
                    }
                    OptionSelector();
                    break;
                // Tasks
                case 21:
                    Console.WriteLine();
                    Console.WriteLine("List of Tasks: \n");
                    List<TaskDto> tasks = _taskController.GetAll();


                    foreach (TaskDto task in tasks)
                    {
                        Console.WriteLine($"|{task.Id}|{task.Title}|{task.Description}| status: {task.Status}");
                        Console.WriteLine($"Assigne: {task.Assignee?.FirstName} {task.Assignee?.LastName}");
                        Console.WriteLine($"Bucket: {task?.Bucket?.Title}");
                    }

                    OptionSelector();
                    break;
                case 22:
                    Console.WriteLine();
                    Console.WriteLine("Assign Task to a user: \n");

                    Console.Write("Enter User ID: ");
                    int assigneeId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Task ID: ");
                    int taskId = Convert.ToInt32(Console.ReadLine());

                    _taskController.AssignTaskToUser(taskId, assigneeId);

                    OptionSelector();
                    break;
                case 23:
                    Console.WriteLine();
                    Console.WriteLine("Assign Task to a bucket: \n");

                    Console.Write("Enter Bucket ID: ");
                    int bucketId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Task ID: ");
                    int bucketTaskId = Convert.ToInt32(Console.ReadLine());

                    _taskController.AssignTaskToBucket(bucketId, bucketTaskId);

                    OptionSelector();
                    break;
                case 24:
                    Console.WriteLine();
                    Console.WriteLine("Tasks by Bucket ID \n");
                    Console.Write("Enter Bucket ID: ");
                    int ThebucketId = Convert.ToInt32(Console.ReadLine());

                    List<TaskDto> bucketTasks = _taskController.GetTasksByBucketId(ThebucketId);


                    foreach (TaskDto task in bucketTasks)
                    {
                        Console.WriteLine($"|{task.Id}|{task.Title}|{task.Description}| status: {task.Status}");
                        Console.WriteLine($"Assigne: {task.Assignee?.FirstName} {task.Assignee?.LastName}");
                    }

                    OptionSelector();
                    break;
                case 25:
                    Console.WriteLine();
                    Console.WriteLine("Update Task section. Please fill the following info");
                    Console.WriteLine();

                    Console.Write("Enter Task ID: ");
                    int TaskId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Title: ");
                    string Title = Console.ReadLine();

                    Console.Write("Enter Description: ");
                    string Description = Console.ReadLine();

                    _taskController.Update(TaskId, new TaskDto() { Id = TaskId, Title = Title, Description = Description });

                    OptionSelector();
                    break;
                case 26:
                    Console.WriteLine();
                    Console.WriteLine("Update Task Status section. Please fill the following info");
                    Console.WriteLine();

                    Console.Write("Enter Task ID: ");
                    int ThisTaskId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Status (Valid Status are Open, InProgress and Closed): ");
                    string NewStatus = Console.ReadLine();

                    if (!string.IsNullOrEmpty(NewStatus) && Enum.IsDefined(typeof(TaskStatusEnum), NewStatus))
                    {
                        TaskStatusEnum TaskStatus = Enum.Parse<TaskStatusEnum>(NewStatus);
                        _taskController.ChangeTaskStatus(ThisTaskId, TaskStatus);

                        OptionSelector();
                    }
                    else
                    {
                        Console.WriteLine("Enter Valid Status please. Valid Status are Open, InProgress and Closed - Case sensitive");
                        OptionSelector();
                    }
                    break;
                case 27:
                    Console.WriteLine();
                    Console.WriteLine("Delete user \n");

                    Console.Write("Enter User ID: ");
                    int LateTaskId = Convert.ToInt32(Console.ReadLine());

                    string TaskDeleteMsg = _taskController.Delete(LateTaskId);

                    Console.WriteLine(TaskDeleteMsg);

                    OptionSelector();
                    break;

                default:
                    Console.WriteLine("Enter correct option please. Or Enter 0 to exit");
                    OptionSelector();
                    break;

            }
        }
    }
}