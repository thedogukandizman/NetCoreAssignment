using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using NetCoreAssignment.DataAccess.Contexts;
using NetCoreAssignment.Domain.Repositories;
using NetCoreAssignment.Domain.Entities;

namespace NetCoreAssignment.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        readonly private BaseDbContext _context;
        public Repository(BaseDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();
        public async Task<bool> CreateAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == id);
            return Remove(model);
        }
        public bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }


        public IQueryable<T> GetList(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public IQueryable<T> GetList(System.Linq.Expressions.Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.FirstOrDefaultAsync(data => data.Id == id);
        }

        private bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<int> SaveAsync()
         => await _context.SaveChangesAsync();
    }
}
