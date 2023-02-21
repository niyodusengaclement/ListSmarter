using ListSmarter.DTO;
using ListSmarter.Enums;

namespace ListSmarter.Services.TaskService
{
    public interface ITaskService : IGenericService<TaskDto>
    {
        void ChangeTaskStatus(int taskId, TaskStatusEnum status);

        void AssignTaskToUser(int taskId, int userId);
        void AssignTaskToBucket(int taskId, int bucketId);
        List<TaskDto> GetTasksByBucketId(int bucketId);
    }
}
