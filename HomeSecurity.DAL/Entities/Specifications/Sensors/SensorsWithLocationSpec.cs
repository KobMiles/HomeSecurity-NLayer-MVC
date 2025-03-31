using Ardalis.Specification;

namespace HomeSecurity.DAL.Entities.Specifications.Sensors;

public class SensorsWithLocationSpec : Specification<Sensor>
{
    public SensorsWithLocationSpec()
    {
        Query
            .Include(s => s.Location);
    }
}