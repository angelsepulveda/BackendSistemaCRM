using Domain.Generales.Comunas;
using Domain.Generales.Paises;
using Domain.Generales.Regiones;
using Domain.Generales.TiposDocumentos;
using Domain.Usuarios.Colaboradores;

namespace Infrastructure.Common.Database.Contexts;

public class CRMDbContext : DbContext
{
    DbSet<Pais> Paises { get; set; }
    DbSet<Region> Regiones { get; set; }
    DbSet<Comuna> Comunas { get; set; }
    DbSet<TipoDocumento> TipoDocumentos { get; set; }
    DbSet<Colaborador> Colaboradores { get; set; }

    public CRMDbContext(DbContextOptions<CRMDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CRMDbContext).Assembly);
    }
}
