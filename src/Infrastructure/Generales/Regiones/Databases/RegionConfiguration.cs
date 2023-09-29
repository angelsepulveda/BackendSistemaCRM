using Domain.Generales.Regiones;

namespace Infrastructure.Generales.Regiones.Databases;

public class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.ToTable("tb_gral_regiones");

        builder.HasKey(c => c.Id);

        builder.Property(p => p.Nombre).HasColumnName("nombre").HasMaxLength(100).IsRequired();

        builder.Property(c => c.PaisId).HasColumnName("pais_id").IsRequired();

        builder.Property(p => p.Activo).HasColumnName("activo").IsRequired();

        builder.Property(p => p.CreatedAt).HasColumnName("created_at");

        builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");

        builder.Property(p => p.CreatedBy).HasColumnName("created_by");

        builder.Property(p => p.UpdatedBy).HasColumnName("updated_by");

        //relaciones
        builder.HasOne(u => u.Pais).WithOne().HasForeignKey<Region>("PaisId");
    }
}
