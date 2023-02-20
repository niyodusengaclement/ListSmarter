using ListSmarter.Enums;

namespace ListSmarter.Services.TaskService
{
    public interface ITaskService<T> : IGenericService<T> where T : class
    {
        void ChangeTaskStatus(int taskId, TaskEnum status);

    }
}
