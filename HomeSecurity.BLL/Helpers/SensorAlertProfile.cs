using AutoMapper;
using HomeSecurity.BLL.DTOs.SensorAlerts;
using HomeSecurity.DAL.Entities;

namespace HomeSecurity.BLL.Helpers;

public class SensorAlertProfile : Profile
{
    public SensorAlertProfile()
    {
        CreateMap<SensorAlertCreateDto, SensorAlert>()
            .ReverseMap();

        CreateMap<SensorAlert, SensorAlertDto>()
            .ReverseMap();
    }
}