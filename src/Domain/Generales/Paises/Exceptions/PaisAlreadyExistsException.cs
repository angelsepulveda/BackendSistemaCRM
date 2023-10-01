namespace Domain.Generales.Paises.Exceptions;

public class PaisAlreadyExistsException : DomainException
{
  public PaisAlreadyExistsException()
      : base("El país ya está registrado.") { }
}