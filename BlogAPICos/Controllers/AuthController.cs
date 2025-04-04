using Microsoft.AspNetCore.Identity.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BlogAPICos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Validación falsa por ejemplo
            if (request.Correo == "admin@blog.com" && request.Password == "123")
            {
                var claims = new[] {
                new Claim(ClaimTypes.Name, request.Correo)
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ClaveSuperSecreta123!"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return Unauthorized();
        }
    }

    public class LoginRequest
    {
        public string Correo { get; set; }
        public string Password { get; set; }
    }
}
