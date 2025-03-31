using HomeSecurity.BLL.Interfaces.Services;
using HomeSecurity.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HomeSecurity.BLL;
public static class ServiceExtensions
{
    public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
    {
        services.AddScoped<ISensorService, SensorService>();
        return services;
    }

    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}