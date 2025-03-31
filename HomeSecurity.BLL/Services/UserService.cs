using AutoMapper;
using HomeSecurity.BLL.DTOs.Users;
using HomeSecurity.BLL.Interfaces.Services;
using HomeSecurity.DAL.Entities.Specifications.Users;
using HomeSecurity.DAL.Interfaces.Repositories;

namespace HomeSecurity.BLL.Services;

public class UserService(IUnitOfWork unitOfWork, IMapper mapper) : IUserService
{
    public async Task<UserDto> GetUserDetailsAsync(string userId)
    {
        var spec = new UserByIdWithTicketsSpec(userId);
        var user = await unitOfWork.Users.FirstOrDefaultAsync(spec)
                   ?? throw new KeyNotFoundException($"User with id: {userId} not found.");

        var userDetailsDto = mapper.Map<UserDto>(user);

        return userDetailsDto;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users = await unitOfWork.Users.ListAsync();
        return mapper.Map<IEnumerable<UserDto>>(users);
    }
}