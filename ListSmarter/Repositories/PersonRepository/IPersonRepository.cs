namespace ListSmarter.Repositories.PersonRepository
{
    public interface IPersonRepository<T> : IRepository<T>
    {
        void AssignUserTask(int userId, int taskId);
    }
}
