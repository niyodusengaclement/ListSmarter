using ListSmarter;
using ListSmarter.ConsoleUI;
using ListSmarter.Controllers;
using ListSmarter.DTO;
using Microsoft.Extensions.DependencyInjection;
using ListSmarter.Services.PersonService;
using ListSmarter.Services.BucketService;
using ListSmarter.Services.TaskService;
using ListSmarter.Repositories.BucketRepository;
using ListSmarter.Repositories.PersonRepository;
using ListSmarter.Repositories.TaskRepository;
using FluentValidation;
using ListSmarter.Validators;

static IServiceProvider CreateServiceProvider()
{
    var services = new ServiceCollection();

    // Person initialization
    services.AddSingleton<IPersonRepository, PersonRepository>();
    services.AddSingleton<IPersonService, PersonService>();
    services.AddSingleton<IValidator<PersonDto>, PersonValidator>();

    // Bucket initialization
    services.AddSingleton<IBucketRepository, BucketRepository>();
    services.AddSingleton<IBucketService, BucketService>();
    services.AddSingleton<IValidator<BucketDto>, BucketValidator>();

    // Task initialization
    services.AddSingleton<ITaskRepository, TaskRepository>();
    services.AddSingleton<ITaskService, TaskService>();
    services.AddSingleton<IValidator<TaskDto>, TaskValidator>();

    services.AddAutoMapper(typeof(AutoMapperProfile));
    return services.BuildServiceProvider();
}

var serviceProvider = CreateServiceProvider();
var personService = serviceProvider.GetService<IPersonService>();
var bucketService = serviceProvider.GetService<IBucketService>();
var taskService = serviceProvider.GetService<ITaskService>();
var personController = new PersonController(personService ?? throw new Exception("No Person Service was found"));
var bucketController = new BucketController(bucketService ?? throw new Exception("No Bucket Service was found"));
var taskController = new TaskController(taskService ?? throw new Exception("No Task Service was found"));

Menu menu = new(personController, bucketController, taskController);

menu.OptionSelector();