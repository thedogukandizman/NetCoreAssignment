using NetCoreAssignment.DataAccess.Contexts;
using NetCoreAssignment.Domain.Repositories;
using NetCoreAssignment.Domain.Entities;
using NetCoreAssignment.Domain.Shared.Types;
using Microsoft.EntityFrameworkCore;
using NetCoreAssignment.DataAccess.Extensions;

namespace NetCoreAssignment.DataAccess.Repositories
{
    public class TodoRepository : Repository<Todo>,ITodoRepository
    {
        public TodoRepository(BaseDbContext context):base(context)
        {

        }

        public IQueryable<Todo> GetListWithUser(StatusType? status, bool tracking = true)
        {
            var query = Table.AsQueryable().WhereIf(status.HasValue,x=>x.Status==(int)status).Include(x => x.User);

            if (!tracking)
                return query.AsNoTracking();

            return query;
        }
    }
}
