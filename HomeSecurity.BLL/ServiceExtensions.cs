using FluentValidation.AspNetCore;
using FluentValidation;
using HomeSecurity.BLL.Interfaces.Services;
using HomeSecurity.BLL.Services;
using HomeSecurity.BLL.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace HomeSecurity.BLL;
public static class ServiceExtensions
{
    public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
    {
        services.AddScoped<ISensorService, SensorService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAlarmService, AlarmService>();

        return services;
    }

    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }   
    public static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<UserRegisterDtoValidator>();

        return services;
    }
}