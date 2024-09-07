using Microsoft.EntityFrameworkCore;
using Hostify.Models;

namespace Hostify.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		public DbSet<Utilizador> Utilizador { get; set; }
		public DbSet<Hospede> Hospede { get; set; }
		public DbSet<Hotel> Hotel { get; set; }
		public DbSet<Quarto> Quarto { get; set; }
		public DbSet<Reserva> Reserva { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Utilizador>()
				.HasDiscriminator<string>("TypeUtilizador")
				.HasValue<Hotel>("Hotel")
				.HasValue<Hospede>("Hospede");

			base.OnModelCreating(modelBuilder);
		}
	}
}
