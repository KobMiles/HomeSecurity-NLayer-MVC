using Ardalis.Specification;

namespace HomeSecurity.DAL.Interfaces.Repositories;

public interface IReadRepository<TEntity> : IReadRepositoryBase<TEntity>
    where TEntity : class
{
}