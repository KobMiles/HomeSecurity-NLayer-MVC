using HomeSecurity.BLL.DTOs.Users;

namespace HomeSecurity_NLayer_MVC.ViewModels;

public class ProfileViewModel
{
    public UserDto CurrentUser { get; set; } = null!;
    public IEnumerable<UserDto> AllUsers { get; set; } = new List<UserDto>();
}