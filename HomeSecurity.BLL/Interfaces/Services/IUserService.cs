using HomeSecurity.BLL.DTOs.Users;

namespace HomeSecurity.BLL.Interfaces.Services;

public interface IUserService
{
    Task<UserDto> GetUserDetailsAsync(string userId);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
}