namespace ListSmarter.Services
{
    public interface IGenericService<T>
    {
        T GetById(int id);
        IList<T> Add(T item);
        string Update(int id, T item);
       string Delete(int id);
        IList<T> GetAll();

    }
}
