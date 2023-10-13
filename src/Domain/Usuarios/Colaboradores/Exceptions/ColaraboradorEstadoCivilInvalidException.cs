namespace Domain.Usuarios.Colaboradores;

public class ColaboradorEstadoCivilInvalidException : DomainException
{
    public ColaboradorEstadoCivilInvalidException()
        : base("La estado civil no es válido.") { }
}
