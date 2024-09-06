using Hostify.Data;
using Hostify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hostify.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ReservaController : ControllerBase
	{
		private readonly AppDbContext _context;

		public ReservaController(AppDbContext _context)
		{
			this._context = _context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Reserva>>> GetReserva()
		{
			return await _context.Reserva.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Reserva>> GetReserva(int id)
		{
			var reserva = await _context.Reserva.FindAsync(id);
			if (reserva == null)
			{
				return NotFound();
			}

			return reserva;
		}

		[HttpPost]
		public async Task<ActionResult<Reserva>> PostReserva(Reserva reserva)
		{
			_context.Reserva.Add(reserva);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetReserva), new { id = reserva.IdReserva }, reserva);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutReserva(int id, Reserva reserva)
		{
			if (id != reserva.IdReserva)
			{
				return BadRequest();
			}

			_context.Entry(reserva).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!_context.Reserva.Any(e => e.IdReserva == id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Reserva>> DeleteReserva(int id)
		{
			var reserva = await _context.Reserva.FindAsync(id);
			if (reserva == null)
			{
				return NotFound();
			}

			_context.Reserva.Remove(reserva);
			await _context.SaveChangesAsync();

			return reserva;
		}
	}
}
