using Ardalis.Specification;

namespace HomeSecurity.DAL.Interfaces.Repositories;

public interface IRepository<TEntity>
    : IRepositoryBase<TEntity>, IReadRepository<TEntity>
    where TEntity : class, IEntity
{
}