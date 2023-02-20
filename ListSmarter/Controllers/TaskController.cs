using ListSmarter.DTO;
using ListSmarter.Enums;
using ListSmarter.Services.TaskService;

namespace ListSmarter.Controllers
{
    public class TaskController
    {
        private readonly ITaskService<TaskDto> _taskService;
        public TaskController(ITaskService<TaskDto> taskService) => _taskService = taskService;

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

        public string Update(int id, TaskDto user)
        {
            return _taskService.Update(id, user);
        }

        public string Delete(int id)
        {
            return _taskService.Delete(id);
        }

        public void ChangeTaskStatus(int taskId, TaskEnum status)
        {
            return _taskService.ChangeTaskStatus(taskId, status);
        }
    }
}
