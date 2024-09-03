using Microsoft.EntityFrameworkCore;
using Hostify.Models;

namespace Hostify.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		public DbSet<Quarto> Quartos { get; set; }
	}
}
