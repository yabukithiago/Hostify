using System;
using System.ComponentModel.DataAnnotations;

namespace Hostify.Models
{
	public class Reserva
	{
		[Key]
		public int IdReserva { get; set; }
		[Required]
		public Hotel Hotel { get; set; }
		[Required]
		public Hospede Hospede { get; set; }
		[Required]
		public Quarto Quarto { get; set; }
		public string TypeReserva { get; set; }
		public string DescriptionReserva { get; set; }
		public DateTime InicioReserva { get; set; }
		public DateTime FimReserva { get; set; }
	}
}
