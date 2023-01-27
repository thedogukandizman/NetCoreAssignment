using NetCoreAssignment.Domain.Entities;
using NetCoreAssignment.Domain.Shared.Types;

namespace NetCoreAssignment.Domain.Repositories
{
    public interface ITodoRepository : IRepository<Todo>
    {
        IQueryable<Todo> GetListWithUser(StatusType? status, bool tracking = true);
    }
}
