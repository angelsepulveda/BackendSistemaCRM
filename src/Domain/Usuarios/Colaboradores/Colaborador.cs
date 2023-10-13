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
        string genero,
        string estadoCivil,
        string emailPersonal,
        string telefono,
        string emailAcceso,
        string password,
        string estado,
        string rol,
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
        Genero = SetGeneroFromString(genero);
        EstadoCivil = SetEstadoCivilFromString(estadoCivil);
        EmailPersonal = emailPersonal;
        Telefono = telefono;
        EmailAcceso = emailAcceso;
        Password = password;
        Estado = SetEstadoFromString(estado);
        ComunaId = comunaId;
        Direccion = direccion;
        Rol = SetRolFromString(rol);
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

    public void ChangeColaboradorEstado(string value)
    {
        var estadoEnum = SetEstadoFromString(value);
        if (Estado != estadoEnum)
            Estado = estadoEnum;
    }

    public void Update(
        string nombres,
        string apellidos,
        Guid tipoDocumentoId,
        string numDocumento,
        DateTime fechaNacimiento,
        string genero,
        string estadoCivil,
        string emailPersonal,
        string telefono,
        string emailAcceso,
        string password,
        string rol,
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

        var generoEnum = SetGeneroFromString(genero);
        if (Genero != generoEnum)
            Genero = generoEnum;

        var estadoCivilEnum = SetEstadoCivilFromString(estadoCivil);
        if (EstadoCivil != estadoCivilEnum)
            EstadoCivil = estadoCivilEnum;

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

        var rolEnum = SetRolFromString(rol);
        if (Rol != rolEnum)
            Rol = rolEnum;
    }

    private ColaboradorEstadoCivil SetEstadoCivilFromString(string estadoCivilStr)
    {
        if (!Enum.TryParse(estadoCivilStr, out ColaboradorEstadoCivil estadoCivil))
        {
            throw new ArgumentException("Valor de estado civil no válido", nameof(estadoCivilStr));
        }

        return estadoCivil;
    }

    private ColaboradorEstado SetEstadoFromString(string estadoStr)
    {
        if (!Enum.TryParse(estadoStr, out ColaboradorEstado estado))
        {
            throw new ColaboradorEstadoCivilInvalidException();
        }

        return estado;
    }

    private ColaboradorGenero SetGeneroFromString(string generoStr)
    {
        if (!Enum.TryParse(generoStr, out ColaboradorGenero genero))
        {
            throw new ColaboradorGeneroInvalidException();
        }

        return genero;
    }

    private ColaboradorRol SetRolFromString(string rolStr)
    {
        if (!Enum.TryParse(rolStr, out ColaboradorRol rol))
        {
            throw new ColaboradorRolInvalidException();
        }

        return rol;
    }
}
