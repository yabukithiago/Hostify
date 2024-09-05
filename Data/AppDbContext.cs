using Microsoft.EntityFrameworkCore;
using Hostify.Models;

namespace Hostify.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		public DbSet<Quarto> Quarto { get; set; }
		public DbSet<Hospede> Hospede { get; set; }
		public DbSet<Hotel> Hotel { get; set; }
		public DbSet<Reserva> Reserva { get; set; }
	}
}
