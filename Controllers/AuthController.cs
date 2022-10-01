using Microsoft.AspNetCore.Mvc;
using NZWalkTutorial.Repositories;

namespace NZWalkTutorial.Controllers
{
    [ApiController]
    [Route("Auth")]
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly Itokenhandler tokenhandler;

        public AuthController(IUserRepository userRepository ,Itokenhandler tokenhandler)
        {
            this.userRepository = userRepository;
            this.tokenhandler = tokenhandler;
        }
        [HttpPost]
        [Route("login")]
        public async Task <IActionResult> LoginAsync(DTO.LoginReq loginreq)
        {
            //Validate inccoming req
            //check user if auth

            // check user and pass
            var user = await userRepository.AuthenticateAsync(
                loginreq.Username, loginreq.Password);

            if (user!=null)
            {
            var token=   await  tokenhandler.Createtokenasync(user);
                return Ok(token);
            }
            else return BadRequest("Username and pass inccorect");
        }
    }
}
