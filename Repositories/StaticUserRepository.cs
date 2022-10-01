using NZWalkTutorial.Models.Domains;

namespace NZWalkTutorial.Repositories
{
    public class StaticUserRepository : IUserRepository
    {
        // manual user entry instead of db for fast test
        private List<User> Users = new List<User>()
    {
            new User()
        {
                FirstName = "Read Only " , LastName="User" , Email="readonly@user.com", Id=Guid.NewGuid(), Username="readonly@user.com",Password="Readonly@user",Roles= new List<string> {"reader"}

        },
     new User()
        {
                FirstName = "Read Write " , LastName="User" , Email="readwrite@user.com", Id=Guid.NewGuid(), Username="readwrite@user.com",Password="Readwrite@user",Roles= new List<string> {"reader","writer"}

        }

        };

        public async Task<User> AuthenticateAsync(string username, string password)
        {
      var user =  Users.Find(x=>x.Username.Equals(username , StringComparison.InvariantCultureIgnoreCase) && x.Password.Equals(password));
            return user;
           
        }
    }


 
    }
