using Microsoft.AspNetCore.Identity;

namespace HomeSecurity.DAL.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}