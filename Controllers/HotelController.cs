using Hostify.Data;
using Hostify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hostify.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class HotelController : ControllerBase
	{
		private readonly AppDbContext _context;
		public HotelController(AppDbContext _context)
		{
			this._context = _context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Hotel>>> GetHotel()
		{
			return await _context.Hotel.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
		{
			_context.Hotel.Add(hotel);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetHotel), new { id = hotel.IdHotel }, hotel);
		}

		[HttpDelete]
		public async Task<ActionResult<Hotel>> DeleteHotel(int id)
		{
			var hotel = await _context.Hotel.FindAsync(id);
			if (hotel == null)
			{
				return NotFound();
			}

			_context.Hotel.Remove(hotel);
			await _context.SaveChangesAsync();

			return hotel;
		}
	}
}
