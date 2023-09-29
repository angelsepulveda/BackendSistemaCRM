namespace Domain.Usuarios.Colaboradores;

public class Colaborador : BaseEntity<Guid>
{
    public Colaborador(
        Guid id,
        string nombres,
        string apellidos,
        Guid tipoDocumentoId,
        string numDocumento,
        DateTime fechaNacimiento,
        ColaboradorGenero genero,
        ColaboradorEstadoCivil estadoCivil,
        string emailPersonal,
        string telefono,
        string emailAcceso,
        string password,
        ColaboradorEstado estado,
        ColaboradorRol rol,
        Guid comunaId,
        string direccion
    )
    {
        Id = id;
        Nombres = nombres;
        Apellidos = apellidos;
        TipoDocumentoId = tipoDocumentoId;
        NumDocumento = numDocumento;
        FechaNacimiento = fechaNacimiento;
        Genero = genero;
        EstadoCivil = estadoCivil;
        EmailPersonal = emailPersonal;
        Telefono = telefono;
        EmailAcceso = emailAcceso;
        Password = password;
        Estado = estado;
        ComunaId = comunaId;
        Direccion = direccion;
        Rol = rol;
    }

    public Colaborador() { }

    public string Nombres { get; private set; } = string.Empty;
    public string Apellidos { get; private set; } = string.Empty;
    public Guid TipoDocumentoId { get; private set; }
    public string NumDocumento { get; private set; } = string.Empty;
    public DateTime FechaNacimiento { get; private set; }
    public ColaboradorGenero Genero { get; private set; }
    public ColaboradorEstadoCivil EstadoCivil { get; private set; }
    public string EmailPersonal { get; private set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string EmailAcceso { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public ColaboradorEstado Estado { get; private set; }
    public ColaboradorRol Rol { get; private set; }
    public Guid ComunaId { get; private set; }
    public string Direccion { get; private set; } = string.Empty;

    public virtual Comuna Comuna { get; set; }
    public virtual TipoDocumento TipoDocumento { get; set; }

    public void ChangeColaboradorEstado(ColaboradorEstado value)
    {
        if (Estado != value)
            Estado = value;
    }

    public void Update(
        string nombres,
        string apellidos,
        Guid tipoDocumentoId,
        string numDocumento,
        DateTime fechaNacimiento,
        ColaboradorGenero genero,
        ColaboradorEstadoCivil estadoCivil,
        string emailPersonal,
        string telefono,
        string emailAcceso,
        string password,
        ColaboradorRol rol,
        Guid comunaId,
        string direccion
    )
    {
        if (Nombres != nombres)
            Nombres = nombres;

        if (Apellidos != apellidos)
            Apellidos = apellidos;

        if (TipoDocumentoId != tipoDocumentoId)
            TipoDocumentoId = tipoDocumentoId;

        if (NumDocumento != numDocumento)
            NumDocumento = numDocumento;

        if (FechaNacimiento != fechaNacimiento)
            FechaNacimiento = fechaNacimiento;

        if (Genero != genero)
            Genero = genero;

        if (EstadoCivil != estadoCivil)
            EstadoCivil = estadoCivil;

        if (EmailPersonal != emailPersonal)
            EmailPersonal = emailPersonal;

        if (Telefono != telefono)
            Telefono = telefono;

        if (EmailAcceso != emailAcceso)
            EmailAcceso = emailAcceso;

        if (Password != password)
            Password = password;

        if (ComunaId != comunaId)
            ComunaId = comunaId;

        if (Direccion != direccion)
            Direccion = direccion;

        if (Rol != rol)
            Rol = rol;
    }
}
