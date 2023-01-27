using NetCoreAssignment.Domain.Entities;
using NetCoreAssignment.Service.Contracts.Dtos.Users;

namespace NetCoreAssignment.Service.Contracts.Services
{
    public interface IUserService
    {
        Task<LoginResponseDto> AuthenticateAsync(LoginDto model);
        Task<User> GetByIdAsync(int id);
        Task RegisterAsync(RegisterDto model);
        Task ChangePasswordAsync(ChangePasswordDto model);
    }
}
