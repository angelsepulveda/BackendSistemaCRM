namespace Domain.Usuarios.Colaboradores;

public class ColaboradorNotFoundException : DomainException
{
    public ColaboradorNotFoundException()
        : base("El colaborador no existe.") { }
}
