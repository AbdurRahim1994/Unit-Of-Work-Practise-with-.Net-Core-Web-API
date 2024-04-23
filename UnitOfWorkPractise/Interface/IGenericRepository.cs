namespace UnitOfWorkPractise.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        T Add(T entity);
        T Update(T entity, int id);
        bool Delete(int id);
        List<T> GetAll();
        T GetById(int id);
    }
}
