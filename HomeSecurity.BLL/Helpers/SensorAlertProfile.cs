using AutoMapper;
using HomeSecurity.BLL.DTOs.SensorAlerts;
using HomeSecurity.DAL.Entities;

namespace HomeSecurity.BLL.Helpers;

public class SensorAlertProfile : Profile
{
    public SensorAlertProfile()
    {
        CreateMap<SensorAlert, SensorAlertDto>()
            .ForMember(dest => dest.SensorName,
                opt => opt.MapFrom(src => src.Sensor.Name))

            .ForMember(dest => dest.SensorType, 
                opt => opt.MapFrom(src => src.Sensor.SensorType.ToString()))

            .ForMember(dest => dest.LocationName, 
                opt => opt.MapFrom(src => src.Sensor.Location.Name));
    }
}