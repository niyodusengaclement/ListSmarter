namespace ListSmarter.Repositories
{
    public interface IRepository<T>
    {
        T GetById(int id);
        IList<T> Add(T item);
        void Update(int id, T data);
        void Delete(int id);
        IList<T> GetAll();
    }
}
