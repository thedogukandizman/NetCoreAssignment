using NetCoreAssignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace NetCoreAssignment.Domain.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }

        IQueryable<T> GetList(bool tracking = true);
        IQueryable<T> GetList(Expression<Func<T, bool>> method, bool tracking = true);

        Task<bool> CreateAsync(T model);

        Task<bool> DeleteAsync(int id);

        Task<T> GetByIdAsync(int id);

        bool Update(T model);

        Task<int> SaveAsync();
    }
}
