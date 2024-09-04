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
			return await _context.Quarto.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult<Quarto>> PostQuarto(Quarto quarto)
		{
			_context.Quarto.Add(quarto);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetQuarto), new { id = quarto.IdQuarto }, quarto);
		}

		[HttpDelete]	
		public async Task<ActionResult<Quarto>> DeleteQuarto(int id)
		{
			var quarto = await _context.Quarto.FindAsync(id);
			if (quarto == null)
			{
				return NotFound();
			}

			_context.Quarto.Remove(quarto);
			await _context.SaveChangesAsync();

			return quarto;
		}
	}
}
