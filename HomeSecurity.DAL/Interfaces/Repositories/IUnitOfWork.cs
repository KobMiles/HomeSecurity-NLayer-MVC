using System.Net.Sockets;
using System;
using HomeSecurity.DAL.Entities;

namespace HomeSecurity.DAL.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    IRepository<Sensor> Sensors { get; }
    IRepository<Location> Locations { get; }
    IRepository<SensorAlert> SensorAlerts { get; }
    IUserRepository Users { get; }

    int Save();
    Task<int> SaveAsync();
}