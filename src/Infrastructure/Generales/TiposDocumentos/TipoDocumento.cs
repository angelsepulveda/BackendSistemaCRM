using Domain.Generales.TiposDocumentos;

namespace Infrastructure.Generales.TiposDocumentos;

public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumento>
{
    public void Configure(EntityTypeBuilder<TipoDocumento> builder)
    {
        builder.ToTable("tb_gral_tipos_documentos");

        builder.HasKey(c => c.Id);

        builder.Property(p => p.Nombre).HasColumnName("nombre").HasMaxLength(20).IsRequired();

        builder.Property(p => p.Descripcion).HasColumnName("descripcion").HasMaxLength(1024);

        builder.Property(p => p.Activo).HasColumnName("activo").IsRequired();

        builder.Property(p => p.CreatedAt).HasColumnName("created_at");

        builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");

        builder.Property(p => p.CreatedBy).HasColumnName("created_by");

        builder.Property(p => p.UpdatedBy).HasColumnName("updated_by");
    }
}
