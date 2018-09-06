using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Repositories;
using ModernStore.Shared.Commands;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Controllers
{
    //[Route("api/[controller]")]
    public class TokenController : Controller
    {
        private IConfiguration _config;
        private readonly ICustomerRepository _customerRepository;
        private readonly UserCommandHandler _handler;

        public TokenController(
            IConfiguration config, 
            ICustomerRepository customerRepository,
            UserCommandHandler handler)
        {
            _config = config;
            _customerRepository = customerRepository;
            _handler = handler;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult CreateToken([FromBody]AuthenticateUserCommand login)
        {
            IActionResult response = Unauthorized();
            //var user = Authenticate(login);

            //if (user != null)
            //{
            //    var tokenString = BuildToken(user);
            //    response = Ok(new
            //    {
            //        token = tokenString,
            //        user = "bruno"
            //    });
            //}
            //else
            //{
            //    return BadRequest(new
            //    {
            //        success = false,
            //        errors = new[] { "Usuário não encontrado." }
            //    });
            //}

            return response;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("v1/authenticate")]
        public async Task<IActionResult> AuthenticateUser([FromForm]AuthenticateUserCommand login)
        {
            IActionResult response = Unauthorized();
            //var user = Authenticate(login);
            var result = _handler.Handle(login);

            if(_handler.Notifications.Count>0)
                return Unauthorized(
                //new
                //{
                //    success = false,
                //    errors = new[] { "Login/Senha não conferem." }
                //}
                );

            if (result != null)
            {
                var tokenString = BuildToken(result);

                Ok(new
                {
                    token = tokenString,
                    user = new
                    {
                        id = 1,
                        name = "bruno",
                        email = "brunokno@gmail.com",
                        username = "bruno",
                        bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus nec iaculis mauris.",
                        birthdate = DateTime.Now
                    }
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = new[] { "Usuário não encontrado." }
            });


            //if (user != null)
            //{
            //    var tokenString = BuildToken(user);
            //    response = Ok(new
            //    {
            //        token = tokenString,
            //        user = new
            //        {
            //            id = 1,
            //            name = "bruno",
            //            email = "brunokno@gmail.com",
            //            username = "bruno",
            //            bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus nec iaculis mauris.",
            //            birthdate = DateTime.Now
            //        }
            //    });
            //}

            //return response;
        }

        private string BuildToken(dynamic user)
        {
            // var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            // var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            //   _config["Jwt:Issuer"],
            //   expires: DateTime.Now.AddMinutes(30),
            //   signingCredentials: creds);

            // return new JwtSecurityTokenHandler().WriteToken(token);


            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, user.Name),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Birthdate, user.Birthdate.ToString("yyyy-MM-dd")),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //private ICommandResult Authenticate(AuthenticateUserCommand authenticateUserCommand)
        //{
            //UserModel user = null;         

            //var customer = _customerRepository.GetByUsername(login.Username);
            //
            //if (customer. login.Username == "brunokno@gmail.com" && login.Password == "123456")
            //{
            //    user = new UserModel { Name = "Mario Rossi", Email = "mario.rossi@domain.com" };
            //}
            //return user;
        //}

        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public User User { get; set; }
        }

        public class User
        {
            public string Username { get; private set; }
            public string Password { get; private set; }
            public bool Active { get; private set; }
            public string Bio { get; set; }
            public DateTime Birthdate { get; set; }
        }

        private class UserModel
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public DateTime Birthdate { get; set; }
        }
    }
}