namespace DAL.Db.Interfaces
{
    public interface IService<T>
    {
        List<T> Get();
        T? GetById(Guid id);
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(Guid id);
    }
}