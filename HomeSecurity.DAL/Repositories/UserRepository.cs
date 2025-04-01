using Ardalis.Specification.EntityFrameworkCore;
using HomeSecurity.DAL.Entities;
using HomeSecurity.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HomeSecurity.DAL.Repositories;

public class UserRepository(DbContext context)
    : RepositoryBase<User>(context), IUserRepository
{
}