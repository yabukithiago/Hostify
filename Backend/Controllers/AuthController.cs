using Hostify.Data;
using Hostify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
		private readonly AppDbContext _context;

		public AuthController(IConfiguration configuration, AppDbContext context)
		{
			_configuration = configuration;
			_context = context;
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] UserLoginModel login)
		{
			var user = await _context.Utilizador
				.FirstOrDefaultAsync(u => u.UsernameUtilizador == login.Username && u.PasswordUtilizador == login.Password);

			if (user == null)
			{
				return Unauthorized(); 
			}

			var secretKey = _configuration["Jwt:SecretKey"];
			if (string.IsNullOrEmpty(secretKey))
			{
				return StatusCode(500, "Secret key not configured.");
			}

			var key = Encoding.ASCII.GetBytes(secretKey);

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
	}
}
