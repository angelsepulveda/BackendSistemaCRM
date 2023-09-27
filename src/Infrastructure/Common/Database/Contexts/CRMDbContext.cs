using Domain.Generales.Regiones;

namespace Infrastructure.Common.Database.Contexts;

public class CRMDbContext : DbContext
{
	DbSet<Region> Regiones { get; set; }

	public CRMDbContext(DbContextOptions<CRMDbContext> options) : base(options)
	{

	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(CRMDbContext).Assembly);
	}

}