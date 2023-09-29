using Domain.Generales.Comunas;

namespace Infrastructure.Generales.Comunas.Databases;

public class ComunaConfiguration : IEntityTypeConfiguration<Comuna>
{
    public void Configure(EntityTypeBuilder<Comuna> builder)
    {
        builder.ToTable("tb_gral_comunas");

        builder.HasKey(c => c.Id);
        builder.Property(p => p.Nombre).HasColumnName("nombre").HasMaxLength(100).IsRequired();

        builder.Property(c => c.RegionId).HasColumnName("region_id").IsRequired();

        builder.Property(p => p.Activo).HasColumnName("activo").IsRequired();

        builder.Property(p => p.CreatedAt).HasColumnName("created_at");

        builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");

        builder.Property(p => p.CreatedBy).HasColumnName("created_by");

        builder.Property(p => p.UpdatedBy).HasColumnName("updated_by");

        //relaciones
        builder.HasOne(u => u.Region).WithOne().HasForeignKey<Comuna>("RegionId");
    }
}
