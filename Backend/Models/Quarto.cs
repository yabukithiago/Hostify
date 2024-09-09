using System;
using System.ComponentModel.DataAnnotations;

namespace Hostify.Models
{
	public class Quarto
	{
		[Key]
		public int IdQuarto { get; set; }

		[Required]
		public int IdHotel { get; set; }

		[Required]
		public string QuartoTipo { get; set; }

		public string QuartoDescricao { get; set; }

		[Required]
		public string QuartoLocalizacao { get; set; }
		[Required]
		public int QuartoCapacidade { get; set; }

		[Required]
		public decimal QuartoDiaria { get; set; }
	}
}
