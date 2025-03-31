using Ardalis.Specification;
using HomeSecurity.DAL.Entities;

namespace HomeSecurity.DAL.Interfaces.Repositories;

public interface IUserRepository
    : IRepositoryBase<User>, IReadRepository<User>
{
}