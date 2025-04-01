using HomeSecurity.DAL.Interfaces.Repositories;
using HomeSecurity.DAL.Data;
using HomeSecurity.DAL.Entities;

namespace HomeSecurity.DAL.Repositories;

public class UnitOfWork(HomeSecurityDbContext context) : IUnitOfWork
{

    private IRepository<Sensor>? _sensors;
    private IRepository<Location>? _locations;
    private IRepository<SensorAlert>? _sensorAlerts;
    private IRepository<AlarmStatus>? _alarmStatuses;
    private IUserRepository? _users;

    public IRepository<Sensor> Sensors
        => _sensors ??= new Repository<Sensor>(context);

    public IRepository<Location> Locations
        => _locations ??= new Repository<Location>(context);

    public IRepository<SensorAlert> SensorAlerts
        => _sensorAlerts ??= new Repository<SensorAlert>(context);

    public IRepository<AlarmStatus> AlarmStatuses
        => _alarmStatuses ??= new Repository<AlarmStatus>(context);

    public IUserRepository Users
        => _users ??= new UserRepository(context);

    public int Save() => context.SaveChanges();
    public async Task<int> SaveAsync() => await context.SaveChangesAsync();

    public void Dispose()
    {
        context.Dispose();
        GC.SuppressFinalize(this);
    }
}