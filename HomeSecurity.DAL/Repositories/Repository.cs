using Ardalis.Specification.EntityFrameworkCore;
using HomeSecurity.DAL.Interfaces;
using HomeSecurity.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HomeSecurity.DAL.Repositories;

public class Repository<TEntity>(DbContext context)
    : RepositoryBase<TEntity>(context), IRepository<TEntity>
    where TEntity : class, IEntity
{

}