using DAL.Db.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Linq.Expressions;

namespace DAL.Db
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public LibraryContext libraryContext;
        public DbSet<TEntity> dbSet;

        public Repository(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
            dbSet = libraryContext.Set<TEntity>();
        }

        public async void Delete(Guid id)
        {
            TEntity entityToDelete = await dbSet.FindAsync(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (libraryContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByID(Guid? id)
        {
            return await dbSet.FindAsync(id);
        }

        public async void Insert(TEntity entity)
        {
           await dbSet.AddAsync(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            libraryContext.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
