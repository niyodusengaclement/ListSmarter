namespace ListSmarter.Services.PersonService
{
    public interface IPersonService<T> : IGenericService<T> where T : class
    {
        void AssignUserTask(int userId, int taskId);

    }
}
