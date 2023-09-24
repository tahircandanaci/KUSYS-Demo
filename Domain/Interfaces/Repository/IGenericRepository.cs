using Domain.Base;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);
        Task<T?> FirstOrDefault(Expression<Func<T, bool>> predicate);

        Task<T> Insert(T entity);
        Task Update(T entity);
        Task Delete(int id);

        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);

        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<T, bool>> predicate);
    }
}
