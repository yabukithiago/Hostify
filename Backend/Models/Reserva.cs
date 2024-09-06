using System;
using System.ComponentModel.DataAnnotations;

namespace Hostify.Models
	{
		public class Reserva
		{
			[Key]
			public int IdReserva { get; set; }
			[Required]
			public int IdHotel { get; set; }
            [Required]
			public int IdHospede { get; set; }
			[Required]
			public int QuartoNumero { get; set; }
			[Required]
			public string TypeReserva { get; set; }
			public string DescriptionReserva { get; set; }
			public decimal PerNight { get; set; }
            public decimal TotalCost { get; set; }
		}
	}
