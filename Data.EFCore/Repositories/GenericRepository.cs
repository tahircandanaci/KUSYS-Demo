using Data.EFCore.Context;
using Domain.Base;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.EFCore.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, IDisposable
    {
        protected readonly KUSYSContext Context;
        protected readonly DbSet<T> DbSet;

        public GenericRepository(KUSYSContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        #region Public Methods

        public Task<T> GetById(int id)
        {
            return DbSet.FirstAsync(f => f.Id == id);
        }

        public Task<T?> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return DbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> Insert(T entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public Task Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            DbSet.Remove(GetById(id).Result);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public Task<int> CountAll()
        {
            return DbSet.CountAsync();
        }

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
        {
            return DbSet.CountAsync(predicate);
        }

        #endregion

        private bool _disposed = false;

        ~GenericRepository() =>
           Dispose();

        public void Dispose()
        {
            if (!_disposed)
            {
                Context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}