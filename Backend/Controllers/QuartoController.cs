using Hostify.Data;
using Hostify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Hostify.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class QuartoController : ControllerBase
	{
		private readonly AppDbContext _context;
		private readonly string _imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

		public QuartoController(AppDbContext _context)
		{
			this._context = _context;
		}

		//Lista todos os quartos
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Quarto>>> GetQuarto()
		{
			return await _context.Quarto.ToListAsync();
		}

		//Lista um quarto especifico
		[HttpGet("{id}")]
		public async Task<ActionResult<Quarto>> GetQuarto(int id)
		{
			var quarto = await _context.Quarto.FindAsync(id);
			if (quarto == null)
			{
				return NotFound();
			}

			return quarto;
		}

		//Cria um quarto
		[HttpPost]
		public async Task<ActionResult<Hotel>> PostQuarto(Quarto quarto)
		{
			_context.Quarto.Add(quarto);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetQuarto), new { id = quarto.IdQuarto }, quarto);
		}

		//Atualiza um quarto
		[HttpPut("{id}")]
		public async Task<IActionResult> PutQuarto(int id, Quarto quarto)
		{
			if (id != quarto.IdQuarto)
			{
				return BadRequest();
			}

			_context.Entry(quarto).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!_context.Quarto.Any(e => e.IdQuarto == id))
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

		//Deleta um quarto
		[HttpDelete("{id}")]
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

		// Endpoint para fazer upload da imagem
		[HttpPost("{id}/upload-image")]
		public async Task<IActionResult> UploadImage(int id, IFormFile file)
		{
			if (file == null || file.Length == 0)
			{
				return BadRequest("No file uploaded.");
			}

			var quarto = await _context.Quarto.FindAsync(id);
			if (quarto == null)
			{
				return NotFound();
			}
			
			if (!Directory.Exists(_imageFolderPath))
			{
				Directory.CreateDirectory(_imageFolderPath);
			}

			var filePath = Path.Combine(_imageFolderPath, file.FileName);
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			quarto.QuartoImagem = $"/images/{file.FileName}";
			_context.Quarto.Update(quarto);
			await _context.SaveChangesAsync();

			return Ok(new { quarto.QuartoImagem });
		}
	}
}
