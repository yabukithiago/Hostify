using Hostify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hostify.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IConfiguration _configuration;

		public AuthController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		[HttpPost("login")]
		public IActionResult Login([FromBody] UserLoginModel login)
		{
			if (login.Username == "admin" && login.Password == "password")
			{
				var secretKey = _configuration["Jwt:SecretKey"];
				if (string.IsNullOrEmpty(secretKey))
				{
					return StatusCode(500, "Secret key not configured.");
				}

				var key = Encoding.ASCII.GetBytes(secretKey); // Chave secreta definida no appsettings.json

				var tokenHandler = new JwtSecurityTokenHandler();
				var tokenDescriptor = new SecurityTokenDescriptor
				{
					Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, login.Username) }),
					Expires = DateTime.UtcNow.AddHours(1),
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
				};

				var token = tokenHandler.CreateToken(tokenDescriptor);
				var tokenString = tokenHandler.WriteToken(token);

				return Ok(new { Token = tokenString });
			}

			return Unauthorized();
		}
	}
}
