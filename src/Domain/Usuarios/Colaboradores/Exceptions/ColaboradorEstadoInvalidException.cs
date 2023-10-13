namespace Domain.Usuarios.Colaboradores;

public class ColaboradorEstadoInvalidException : DomainException
{
    public ColaboradorEstadoInvalidException()
        : base("La estado no es válido.") { }
}
