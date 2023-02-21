using FluentValidation;
using ListSmarter.DTO;
using ListSmarter.Enums;
using ListSmarter.Repositories.PersonRepository;
using ListSmarter.Repositories.TaskRepository;
using ListSmarter.Repositories.BucketRepository;

namespace ListSmarter.Services.TaskService
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IBucketRepository _bucketRepository;
        private readonly IValidator<TaskDto> _taskValidator;
        private readonly int MAX_TASKS = 10;
        public TaskService(ITaskRepository taskRepository, IPersonRepository personRepository, IBucketRepository bucketRepository, IValidator<TaskDto> taskValidator)
        {
            _taskRepository = taskRepository;
            _personRepository = personRepository;
            _bucketRepository = bucketRepository;
            _taskValidator = taskValidator ?? throw new ArgumentException();
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

        public void ChangeTaskStatus(int taskId, TaskStatusEnum status)
        {
            _taskRepository.ChangeTaskStatus(taskId, status);
        }

        public void AssignTaskToUser(int taskId, int userId)
        {
            PersonDto person = _personRepository.GetById(userId);
            _taskRepository.AssignTaskToUser(taskId, userId);
        }
        
        public void AssignTaskToBucket(int taskId, int bucketId)
        {
            BucketDto bucket = _bucketRepository.GetById(bucketId);
            TaskDto task = _taskRepository.GetById(taskId);

            if (task != null && bucket != null)
            {
                if (bucket?.Tasks?.Count < MAX_TASKS)
                {
                    _taskRepository.AssignTaskToBucket(taskId, bucketId);
                }
            }
        }
        public List<TaskDto> GetTasksByBucketId(int bucketId)
        {
            return _taskRepository.GetTasksByBucketId(bucketId);
        }
    }
}
