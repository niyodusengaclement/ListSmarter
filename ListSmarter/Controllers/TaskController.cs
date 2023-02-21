using ListSmarter.DTO;
using ListSmarter.Enums;
using ListSmarter.Services.TaskService;

namespace ListSmarter.Controllers
{
    public class TaskController
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService) => _taskService = taskService;

        public List<TaskDto> Add(TaskDto user)
        {
            return _taskService.Add(user).ToList();
        }
        public List<TaskDto> GetAll()
        {
            return _taskService.GetAll().ToList();
        }

        public TaskDto GetById(int id)
        {
            return _taskService.GetById(id);
        }

        public string Update(int id, TaskDto task)
        {
            return _taskService.Update(id, task);
        }

        public string Delete(int id)
        {
            return _taskService.Delete(id);
        }

        public void ChangeTaskStatus(int taskId, TaskStatusEnum status)
        {
            _taskService.ChangeTaskStatus(taskId, status);
        }
        public void AssignTaskToUser(int taskId, int userId)
        {
            _taskService.AssignTaskToUser(taskId, userId);
        }
        public void AssignTaskToBucket(int taskId, int bucketId)
        {
            _taskService.AssignTaskToBucket(taskId, bucketId);
        }
        public List<TaskDto> GetTasksByBucketId(int bucketId)
        {
            return _taskService.GetTasksByBucketId(bucketId);
        }
    }
}
