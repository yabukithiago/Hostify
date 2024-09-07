using Hostify.Data;
using Hostify.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hostify.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class HospedeController : UtilizadorControllerBase<Hospede>
	{
		public HospedeController(AppDbContext context) : base(context)
		{
		}
	}
}
