using AutoMapper;
using HomeSecurity.BLL.DTOs.Sensors;
using HomeSecurity.DAL.Entities;

namespace HomeSecurity.BLL.Helpers;

public class SensorProfile : Profile
{
    public SensorProfile()
    {
        CreateMap<Sensor, SensorDto>()
            .ForMember(dest => dest.LocationName, 
                opt => opt.MapFrom(src => src.Location.Name))
            .ReverseMap();
    }
}