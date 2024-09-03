using Hostify.Data;
using Hostify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hostify.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class QuartoController : ControllerBase
	{
		private readonly AppDbContext _context;
		public QuartoController(AppDbContext _context)
		{
			this._context = _context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Quarto>>> GetQuarto()
		{
			return await _context.Quartos.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult<Quarto>> PostQuarto(Quarto quarto)
		{
			_context.Quartos.Add(quarto);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetQuarto), new { id = quarto.IdQuarto }, quarto);
		}

		[HttpDelete]	
		public async Task<ActionResult<Quarto>> DeleteQuarto(int id)
		{
			var quarto = await _context.Quartos.FindAsync(id);
			if (quarto == null)
			{
				return NotFound();
			}

			_context.Quartos.Remove(quarto);
			await _context.SaveChangesAsync();

			return quarto;
		}
	}
}
