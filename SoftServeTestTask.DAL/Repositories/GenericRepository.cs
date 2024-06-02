using Microsoft.EntityFrameworkCore;
using SoftServeTestTask.DAL.Database;
using System.Linq.Expressions;

namespace SoftServeTestTask.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EducationalContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(EducationalContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _table;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<T> GetByIdAsync(object id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _table;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            var entity = await query.FirstOrDefaultAsync(e => EF.Property<object>(e, "Id").Equals(id));

            return entity;
        }


        public async Task<bool> AddAsync(T obj)
        {
            try
            {
                await _table.AddAsync(obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(T obj)
        {
            try
            {
                _table.Attach(obj);
                _context.Entry(obj).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(object id)
        {
            try
            {
                T existing = await _table.FindAsync(id);
                if (existing != null)
                {
                    _table.Remove(existing);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }   

        public async Task<bool> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
