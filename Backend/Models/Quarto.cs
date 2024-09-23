using System;
using System.ComponentModel.DataAnnotations;

namespace Hostify.Models
{
	public class Quarto
	{
		[Key]
		public int IdQuarto { get; set; }

		[Required]
		public Hotel Hotel { get; set; }

		[Required]
		public string QuartoTipo { get; set; }
		[Required]
		public string QuartoDescricao { get; set; }
		[Required]
		public int QuartoCapacidade { get; set; }
		[Required]
		public decimal QuartoDiaria { get; set; }

		[Required]
		public string QuartoLocalizacao { get; set; }
		public string QuartoImagem { get; set; }
		public bool QuartoDisponivel { get; set; }
	}
}
