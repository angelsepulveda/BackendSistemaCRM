using Domain.Generales.Paises;

namespace Infrastructure.Generales.Paises.Databases;

public class PaisConfiguration : IEntityTypeConfiguration<Pais>
{
    public void Configure(EntityTypeBuilder<Pais> builder)
    {
        builder.ToTable("tb_gral_paises");

        builder.HasKey(c => c.Id);

        builder.Property(p => p.Nombre).HasColumnName("nombre").HasMaxLength(100).IsRequired();
        builder
            .Property(p => p.Nacionalidad)
            .HasColumnName("nacionalidad")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Activo).HasColumnName("activo").IsRequired();

        builder.Property(p => p.CreatedAt).HasColumnName("created_at");

        builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");

        builder.Property(p => p.CreatedBy).HasColumnName("created_by");

        builder.Property(p => p.UpdatedBy).HasColumnName("updated_by");
    }
}
