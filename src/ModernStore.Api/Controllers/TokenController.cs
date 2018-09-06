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
        
        [HttpPost]
        [AllowAnonymous]
        [Route("v1/authenticate")]
        public async Task<IActionResult> AuthenticateUser([FromForm]AuthenticateUserCommand login)
        {
            IActionResult response = Unauthorized();
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

                return Ok(new
                {
                    token = tokenString,
                    user = new
                    {
                        id = Guid.NewGuid(),
                        name = "bruno",
                        email = "brunokno@gmail.com",
                        username = "bruno",
                        bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus nec iaculis mauris.",
                        image = "https://picsum.photos/128/128/",
                        birthdate = DateTime.Now
                    }
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = new[] { "Usuário não encontrado." }
            });

        }

        private string BuildToken(dynamic user)
        {
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

    }
}