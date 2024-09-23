using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Hostify.Models
{
	public abstract class Utilizador
	{
		[Key]
		public int IdUtilizador { get; set; }

		[Required]
		public string UsernameUtilizador { get; set; }

		[Required]
		[JsonIgnore]
		public string PasswordUtilizador { get; set; }

		[Required]
		public string NameUtilizador { get; set; }

		[Required]
		public string TypeUtilizador { get; set; }
		[Required]
		public string EmailUtilizador { get; set; }
		[Required]
		public string PhoneUtilizador { get; set; }
	}
}
