using Hostify.Data;
using Hostify.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hostify.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class HotelController : UtilizadorControllerBase<Hotel>
	{
		public HotelController(AppDbContext context) : base(context)
		{
		}
	}
}
