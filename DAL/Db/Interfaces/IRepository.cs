using System.Linq.Expressions;

namespace DAL.Db.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    public Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null!);
    public Task<TEntity> GetByID(Guid? id);
    public void Insert(TEntity entity);
    public void Delete(Guid id);
    public void Delete(TEntity entityToDelete);
    public void Update(TEntity entityToUpdate);
}