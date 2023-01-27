using NetCoreAssignment.Domain.Entities;

namespace NetCoreAssignment.Domain.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
    }
}
