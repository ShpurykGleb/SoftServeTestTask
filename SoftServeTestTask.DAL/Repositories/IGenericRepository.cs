using System.Linq.Expressions;

namespace SoftServeTestTask.DAL.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(object id);
        Task<T> GetByIdAsync(object id, params Expression<Func<T, object>>[] includeProperties);
        Task<bool> AddAsync(T obj);
        Task<bool> UpdateAsync(T obj);
        Task<bool> DeleteAsync(object id);
        Task<bool> SaveAsync();
    }
}
