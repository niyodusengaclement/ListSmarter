using ListSmarter;
using ListSmarter.Controllers;
using ListSmarter.DTO;
using Microsoft.Extensions.DependencyInjection;
using ListSmarter.Services.PersonService;
using ListSmarter.Services.BucketService;
using ListSmarter.Repositories.BucketRepository;
using ListSmarter.Repositories.PersonRepository;
using FluentValidation;
using ListSmarter.Validators;

static IServiceProvider CreateServiceProvider()
{
    var services = new ServiceCollection();

    // Person initialization
    services.AddSingleton<IPersonRepository<PersonDto>, PersonRepository>();
    services.AddSingleton<IPersonService<PersonDto>, PersonService>();
    services.AddSingleton<IValidator<PersonDto>, PersonValidator>();

    // Person initialization
    services.AddSingleton<IBucketRepository<BucketDto>, BucketRepository>();
    services.AddSingleton<IBucketService<BucketDto>, BucketService>();
    services.AddSingleton<IValidator<BucketDto>, BucketValidator>();

    services.AddAutoMapper(typeof(AutoMapperProfile));
    return services.BuildServiceProvider();
}

var serviceProvider = CreateServiceProvider();
var personService = serviceProvider.GetService<IPersonService<PersonDto>>();
var bucketService = serviceProvider.GetService<IBucketService<BucketDto>>();
var personController = new PersonController(personService ?? throw new Exception("No Person Service was found"));
var bucketController = new BucketController(bucketService ?? throw new Exception("No Bucket Service was found"));

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
Console.WriteLine("6. Assign Task to a user");

Console.WriteLine();
Console.WriteLine("11. List of all buckets");
Console.WriteLine("12. Add bucket");
Console.WriteLine("13. Get bucket by ID");
Console.WriteLine("14. Update bucket");
Console.WriteLine("15. Delete a bucket");
Console.WriteLine("16. Get bucket tasks");

Console.WriteLine("0. Exit / Quit");
Console.WriteLine();

OptionSelector(personController, bucketController);
static void OptionSelector(PersonController personController, BucketController? bucketController)
{

    Console.WriteLine();
    Console.WriteLine("Select a number and click enter. Enter 0 to Exit");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 0:
            break;
        case 1:
            Console.WriteLine();
            Console.WriteLine("List of all users: \n");
            List<PersonDto> persons = personController.GetAll();

            foreach (PersonDto person in persons)
            {
                Console.WriteLine($"ID: {person.Id}");
                Console.WriteLine($"FirstName: {person.FirstName}");
                Console.WriteLine($"LastName: {person.LastName}");
                Console.WriteLine();
            }
            OptionSelector(personController, bucketController);
            break;

        case 2:

            Console.WriteLine("Add user section. Please fill the following info");
            Console.WriteLine();

            Console.Write("Enter firstname: ");
            string Firstname = Console.ReadLine();

            Console.Write("Enter lastname: ");
            string Lastname = Console.ReadLine();

            int LastUserIdx = personController.GetAll().Count();
            personController.Add(new PersonDto() { Id = LastUserIdx, FirstName = Firstname, LastName = Lastname });

            OptionSelector(personController, bucketController);
            break;
        case 3:
            Console.WriteLine();
            Console.WriteLine("Get User by ID: \n");

            Console.Write("Enter User ID: ");
            int UserId = Convert.ToInt32(Console.ReadLine());

            PersonDto user = personController.GetById(UserId);

            Console.WriteLine($"ID: {user.Id}");
            Console.WriteLine($"FirstName: {user.FirstName}");
            Console.WriteLine($"LastName: {user.LastName}");

            OptionSelector(personController, bucketController);
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

            personController.Update(PersonId, new PersonDto() { Id = PersonId, FirstName = FirstnameUpdates, LastName = LastnameUpdates });

            OptionSelector(personController, bucketController);
            break;
        case 5:
            Console.WriteLine();
            Console.WriteLine("Delete user \n");

            Console.Write("Enter User ID: ");
            int LateUserId = Convert.ToInt32(Console.ReadLine());

            string Msg = personController.Delete(LateUserId);

            Console.WriteLine(Msg);

            OptionSelector(personController, bucketController);
            break;
        case 6:
            Console.WriteLine();
            Console.WriteLine("Assign Task to a user: \n");

            Console.Write("Enter User ID: ");

            OptionSelector(personController, bucketController);
            break;

            // Bucket cases
        case 11:
            Console.WriteLine();
            Console.WriteLine("List of all buckets \n");
            List<BucketDto> buckets = bucketController.GetAll();

            foreach (BucketDto theBucket in buckets)
            {
                Console.WriteLine($"ID: {theBucket.Id}");
                Console.WriteLine($"FirstName: {theBucket.Title}");
                Console.WriteLine();
            }
            OptionSelector(personController, bucketController);
            break;

        case 12:

            Console.WriteLine("Add bucket section. Please fill the following info");
            Console.WriteLine();

            Console.Write("Enter Title: ");
            string BucketTitle = Console.ReadLine();


            int LastBucketIdx = bucketController.GetAll().Count();
            bucketController.Add(new BucketDto() { Id = LastBucketIdx, Title = BucketTitle });

            OptionSelector(personController, bucketController);
            break;
        case 13:
            Console.WriteLine();
            Console.WriteLine("Get Bucket by ID: \n");

            Console.Write("Enter User ID: ");
            int BucketId = Convert.ToInt32(Console.ReadLine());

            BucketDto bucket = bucketController.GetById(BucketId);

            Console.WriteLine($"ID: {bucket.Id}");
            Console.WriteLine($"Title: {bucket.Title}");

            OptionSelector(personController, bucketController);
            break;
        case 14:
            Console.WriteLine();

            Console.WriteLine("Update bucket section. Please fill the following info");
            Console.WriteLine();

            Console.Write("Enter bucket ID: ");
            int ExistingBucketId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter title: ");
            string TitleUpdates = Console.ReadLine();


            bucketController.Update(ExistingBucketId, new BucketDto() { Id = ExistingBucketId, Title = TitleUpdates });

            OptionSelector(personController, bucketController);
            break;
        case 15:
            Console.WriteLine();
            Console.WriteLine("Delete bucket \n");

            Console.Write("Enter Bucket ID: ");
            int LateBacketrId = Convert.ToInt32(Console.ReadLine());

            string DeleteMsg = bucketController.Delete(LateBacketrId);

            Console.WriteLine(DeleteMsg);

            OptionSelector(personController, bucketController);
            break;
        case 16:
            Console.WriteLine();
            Console.WriteLine("Get Bucket tasks: \n");

            Console.Write("Enter Bucket ID: ");

            Console.WriteLine("List of bucket tasks \n");
            List<BucketDto> theBuckets = bucketController.GetAll();

            foreach (BucketDto b in theBuckets)
            {
                Console.WriteLine($"ID: {b.Id}");
                Console.WriteLine($"FirstName: {b.Title}");
                Console.WriteLine();
            }
            OptionSelector(personController, bucketController);
            break;
        default:
            Console.WriteLine("Enter correct option please. Or Enter 0 to exit");
            OptionSelector(personController, bucketController);
            break;
    }
}