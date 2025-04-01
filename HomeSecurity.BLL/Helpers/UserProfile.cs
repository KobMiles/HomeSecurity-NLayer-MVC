using AutoMapper;
using HomeSecurity.BLL.DTOs.Users;
using HomeSecurity.DAL.Entities;

namespace HomeSecurity.BLL.Helpers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>()
            .ReverseMap();

        CreateMap<UserRegisterDto, User>()
            .ForMember(dest => dest.UserName,
                opt => opt.MapFrom(src => src.Email));
    }
}