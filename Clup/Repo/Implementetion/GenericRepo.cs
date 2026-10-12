using Clup.AppDbContext;
using Clup.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace Clup.Repo.Implementetion
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly ClupDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepo(ClupDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
       public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void DeleteAsync(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
                

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
