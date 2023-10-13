namespace Domain.Usuarios.Colaboradores;

public class ColaboradorRolInvalidException : DomainException
{
    public ColaboradorRolInvalidException()
        : base("El rol es inválido") { }
}
