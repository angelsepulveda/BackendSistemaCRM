namespace Domain.Usuarios.Colaboradores.Exceptions;

public class ColaboradorAlreadyExistsException : DomainException
{
    public ColaboradorAlreadyExistsException()
        : base("El colaborador ya está registrado.") { }
}
