using Ardalis.Specification;

namespace HomeSecurity.DAL.Entities.Specifications.SensorAlerts;

public class SensorAlertsWithSensorSpec : Specification<SensorAlert>
{
    public SensorAlertsWithSensorSpec()
    {
        Query
            .Include(sa => sa.Sensor)
            .ThenInclude(s => s.Location);
    }
}