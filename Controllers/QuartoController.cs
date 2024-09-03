using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class QuartoController : ControllerBase
	{
		private readonly AppDbContext _context;
		public QuartoController(AppDbContext _context)
		{
			this._context = _context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Quarto>>> GetAcomodacoes()
		{
			return await _context.Acomodacoes.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult<Quarto>> PostAcomodacao(Quarto acomodacao)
		{
			_context.Acomodacoes.Add(acomodacao);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetAcomodacoes), new { id = acomodacao.Id }, acomodacao);
		}

		[HttpDelete]	
		public async Task<ActionResult<Quarto>> DeleteAcomodacao(int id)
		{
			var acomodacao = await _context.Acomodacoes.FindAsync(id);
			if (acomodacao == null)
			{
				return NotFound();
			}

			_context.Acomodacoes.Remove(acomodacao);
			await _context.SaveChangesAsync();

			return acomodacao;
		}
	}
}
