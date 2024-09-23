using Hostify.Data;
using System;
using System.Linq;

namespace Hostify
{
	public class QuartoService
	{
		private readonly AppDbContext _context;
		public QuartoService(AppDbContext context)
		{
			_context = context;
		}

		public bool BloquearQuarto(int idQuarto, DateTime inicioReserva, DateTime fimReserva)
		{
			var quarto = _context.Quarto.FirstOrDefault(q => q.IdQuarto == idQuarto);
			if (quarto != null && quarto.QuartoDisponivel)
			{
				if (!_context.Reserva.Any(r => r.Quarto.IdQuarto == idQuarto &&
						(inicioReserva < r.FimReserva && fimReserva > r.InicioReserva)))
				{
					quarto.QuartoDisponivel = false;
					_context.SaveChanges();
					return true;
				}
			}
			return false;
		}

		public void LiberarQuarto(int idQuarto)
		{
			var quarto = _context.Quarto.FirstOrDefault(q => q.IdQuarto == idQuarto);
			if (quarto != null)
			{
				quarto.QuartoDisponivel = true;
				_context.SaveChanges();
			}
		}
	}
}
