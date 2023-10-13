using Domain.Usuarios.Colaboradores;

namespace Infrastructure.Usuarios.Colaboradores.Databases;

public class ColaboradorConfiguration : IEntityTypeConfiguration<Colaborador>
{
    public void Configure(EntityTypeBuilder<Colaborador> builder)
    {
        builder.ToTable("tb_usuarios_colaboradores");

        builder.HasKey(c => c.Id);

        builder.Property(p => p.Nombres).HasColumnName("nombres").HasMaxLength(150).IsRequired();

        builder
            .Property(p => p.Apellidos)
            .HasColumnName("apellidos")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(c => c.TipoDocumentoId).HasColumnName("tipo_documento_id").IsRequired();

        builder
            .Property(p => p.NumDocumento)
            .HasColumnName("num_documento")
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(u => u.Rol)
            .HasConversion(
                v => v.ToString(),
                v => (ColaboradorRol)Enum.Parse(typeof(ColaboradorRol), v)
            )
            .HasColumnName("rol")
            .IsRequired();

        builder
            .Property(u => u.Genero)
            .HasConversion(
                v => v.ToString(),
                v => (ColaboradorGenero)Enum.Parse(typeof(ColaboradorGenero), v)
            )
            .HasColumnName("genero")
            .IsRequired();

        builder
            .Property(u => u.EstadoCivil)
            .HasConversion(
                v => v.ToString(),
                v => (ColaboradorEstadoCivil)Enum.Parse(typeof(ColaboradorEstadoCivil), v)
            )
            .HasColumnName("estado_civil")
            .IsRequired();

        builder
            .Property(c => c.EmailPersonal)
            .HasColumnName("email_personal")
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(c => c.FechaNacimiento).HasColumnName("fecha_nacimiento").IsRequired();

        builder
            .Property(c => c.EmailAcceso)
            .HasColumnName("email_acceso")
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(p => p.Password).HasColumnName("password").HasMaxLength(1024).IsRequired();

        builder.Property(p => p.Telefono).HasColumnName("telefono").HasMaxLength(30).IsRequired();

        builder.Property(c => c.ComunaId).HasColumnName("comuna_id").IsRequired();

        builder
            .Property(p => p.Direccion)
            .HasColumnName("direccion")
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(p => p.Estado).HasColumnName("estado");

        builder.Property(p => p.CreatedAt).HasColumnName("created_at");

        builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");

        builder.Property(p => p.CreatedBy).HasColumnName("created_by");

        builder.Property(p => p.UpdatedBy).HasColumnName("updated_by");

        //relaciones
        builder
            .HasOne(u => u.TipoDocumento)
            .WithOne()
            .HasForeignKey<Colaborador>("TIpoDocumentoId");

        builder.HasOne(u => u.Comuna).WithOne().HasForeignKey<Colaborador>("ComunaId");
    }
}
