using Microsoft.IdentityModel.Tokens;
using NZWalkTutorial.Models.Domains;

namespace NZWalkTutorial.Repositories
{
    public interface IUserRepository
    {
       Task<User> AuthenticateAsync(string username, string password); 
    }
}
