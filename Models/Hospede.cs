﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Hostify.Models
{
    public class Hospede : Utilizador
	{ 
        [Key]
		public int IdHospede { get; set; }
        [Required]
		public string UsernameUtilizador { get; set; }
		[Required]
		public string PasswordUtilizador { get; set; }
		[Required]
		public string NameUtilizador { get; set; }
		[Required]
		public string TypeUtilizador { get; set; }
	}
}