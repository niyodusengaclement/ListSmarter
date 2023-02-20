using FluentValidation;
using ListSmarter.DTO;
using ListSmarter.Enums;
using ListSmarter.Repositories.TaskRepository;
namespace ListSmarter.Services.TaskService
{
    public class TaskService : IGenericService<TaskDto>, ITaskService<TaskDto>
    {
        private readonly ITaskRepository<TaskDto> _taskRepository;
        private readonly IValidator<TaskDto> _taskValidator;
        public TaskService(ITaskRepository<TaskDto> taskRepository, IValidator<TaskDto> taskValidator)
        {
            _taskRepository = taskRepository;
            _taskValidator = taskValidator ?? throw new ArgumentException(); ;

            for (int i = 0; i < 7; i++)
            {
                TaskDto task = new TaskDto()
                {
                    Id = i,
                    Title = $"Ticket{i + 1}",
                };
                Add(task);
            }
        }

        public IList<TaskDto> Add(TaskDto user)
        {
            var validationResult = _taskValidator.Validate(user);

            if (validationResult.IsValid)
            {
                _taskRepository.Add(user);
            }
            return _taskRepository.GetAll();
        }
        public IList<TaskDto> GetAll()
        {
            return _taskRepository.GetAll();
        }

        public TaskDto GetById(int id)
        {
            return _taskRepository.GetById(id);
        }

        public string Update(int id, TaskDto user)
        {
            var validationResult = _taskValidator.Validate(user);

            if (validationResult.IsValid)
            {
                _taskRepository.Update(id, user);
            }
            return "Bad input. Task validation failed";
        }

        public string Delete(int id)
        {
            _taskRepository.Delete(id);
            return "Task has been deleted successfully";
        }

        public void ChangeTaskStatus(int taskId, TaskEnum status)
        {
            _taskRepository.ChgangeTaskStatus(taskId, status);
        }
    }
}
