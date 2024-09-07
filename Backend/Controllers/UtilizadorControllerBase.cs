using Hostify.Data;
using Hostify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public abstract class UtilizadorControllerBase<T> : ControllerBase where T : Utilizador
{
	protected readonly AppDbContext _context;

	protected UtilizadorControllerBase(AppDbContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<T>>> GetUtilizadores()
	{
		return await _context.Set<T>().ToListAsync();
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Utilizador>> GetUtilizador(int id)
	{
		var utilizador = await _context.Utilizador.FindAsync(id);
		if (utilizador == null)
		{
			return NotFound();
		}

		if (utilizador is Hotel hotel)
		{
			return Ok(hotel);
		}
		else if (utilizador is Hospede hospede)
		{
			return Ok(hospede);
		}

		return BadRequest("Tipo de utilizador desconhecido.");
	}


	[HttpPost]
	public async Task<ActionResult<T>> PostUtilizador(T utilizador)
	{
		if (utilizador is Hotel)
		{
			_context.Entry(utilizador).Property("TypeUtilizador").CurrentValue = "Hotel";
		}
		else if (utilizador is Hospede)
		{
			_context.Entry(utilizador).Property("TypeUtilizador").CurrentValue = "Hospede";
		}

		_context.Set<T>().Add(utilizador);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetUtilizador), new { id = utilizador.IdUtilizador }, utilizador);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> PutUtilizador(int id, T utilizador)
	{
		if (id != utilizador.IdUtilizador)
		{
			return BadRequest();
		}

		_context.Entry(utilizador).State = EntityState.Modified;

		try
		{
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException)
		{
			if (!_context.Set<T>().Any(e => e.IdUtilizador == id))
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
	public async Task<ActionResult<T>> DeleteUtilizador(int id)
	{
		var utilizador = await _context.Set<T>().FindAsync(id);
		if (utilizador == null)
		{
			return NotFound();
		}

		_context.Set<T>().Remove(utilizador);
		await _context.SaveChangesAsync();

		return utilizador;
	}
}