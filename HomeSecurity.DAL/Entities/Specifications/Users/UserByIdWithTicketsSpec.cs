using Ardalis.Specification;

namespace HomeSecurity.DAL.Entities.Specifications.Users;

public class UserByIdWithTicketsSpec : Specification<User>
{
    public UserByIdWithTicketsSpec(string userId)
    {
        Query
            .Where(u => u.Id == userId);
    }
}