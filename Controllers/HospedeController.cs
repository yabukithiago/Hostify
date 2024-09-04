using Hostify.Data;
using Hostify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hostify.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class HospedeController : ControllerBase
	{
		private readonly AppDbContext _context;
		public HospedeController(AppDbContext _context)
		{
			this._context = _context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Hospede>>> GetHospede()
		{
			return await _context.Hospede.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult<Hospede>> PostHospede(Hospede hospede)
		{
			_context.Hospede.Add(hospede);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetHospede), new { id = hospede.IdUtilizador }, hospede);
		}

		[HttpDelete]
		public async Task<ActionResult<Hospede>> DeleteHospede(int id)
		{
			var hospede = await _context.Hospede.FindAsync(id);
			if (hospede == null)
			{
				return NotFound();
			}

			_context.Hospede.Remove(hospede);
			await _context.SaveChangesAsync();

			return hospede;
		}
	}
}
