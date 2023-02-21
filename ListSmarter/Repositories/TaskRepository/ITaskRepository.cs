using ListSmarter.Enums;
using ListSmarter.DTO;

namespace ListSmarter.Repositories.TaskRepository
{
    public interface ITaskRepository : IRepository<TaskDto>
    {
        void ChangeTaskStatus(int taskId, TaskStatusEnum status);
        void AssignTaskToUser(int taskId, int userId);
        void AssignTaskToBucket(int taskId, int bucketId);
        List<TaskDto> GetTasksByBucketId(int bucketId);
    }
}
