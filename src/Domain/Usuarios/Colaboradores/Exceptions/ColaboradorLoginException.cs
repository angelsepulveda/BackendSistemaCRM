namespace Domain.Usuarios.Colaboradores.Exceptions;

public class ColaboradorLoginException : DomainException
{
  public ColaboradorLoginException()
         : base("Las credenciales no son validas.") { }
}