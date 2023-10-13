namespace Domain.Usuarios.Colaboradores;

public class ColaboradorGeneroInvalidException : DomainException
{
    public ColaboradorGeneroInvalidException()
        : base("El género es inválido.") { }
}
