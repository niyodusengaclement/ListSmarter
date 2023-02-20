using ListSmarter.Enums;

namespace ListSmarter.Repositories.TaskRepository
{
    public interface ITaskRepository<T> : IRepository<T>
    {
        void ChgangeTaskStatus(int taskId, TaskEnum status);
    }
}
