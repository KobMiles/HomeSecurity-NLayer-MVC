using HomeSecurity.DAL.Data;
using HomeSecurity.DAL.Interfaces.Repositories;
using HomeSecurity.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HomeSecurity.DAL;

public static class ServiceExtensions
{
    public static void AddDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<HomeSecurityDbContext>(x =>
            x.UseSqlServer(connectionString));
    }

    public static void AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}