using Microsoft.IdentityModel.Tokens;
using NZWalkTutorial.Models.Domains;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NZWalkTutorial.Repositories
{
    public class tokenhandler : Itokenhandler
    {
        private readonly IConfiguration configuration;

        public tokenhandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Task<string> Createtokenasync(User user)
        {
   
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, user.FirstName));
            claims.Add(new Claim(ClaimTypes.Surname, user.LastName));

            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            user.Roles.ForEach((role) =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
                );
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var creadentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
             expires: DateTime.Now.AddMinutes(15),
             signingCredentials: creadentials

                );

          return Task.FromResult(  new JwtSecurityTokenHandler().WriteToken(token));


        }
    }
}
