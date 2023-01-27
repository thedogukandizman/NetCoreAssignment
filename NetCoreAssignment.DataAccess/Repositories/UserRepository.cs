using NetCoreAssignment.DataAccess.Contexts;
using NetCoreAssignment.Domain.Repositories;
using NetCoreAssignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace NetCoreAssignment.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {

        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await Table.FirstOrDefaultAsync(data => data.Email == email);
        }
    }
}
