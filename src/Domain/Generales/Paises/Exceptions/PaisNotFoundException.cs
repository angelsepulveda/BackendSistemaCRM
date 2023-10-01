namespace Domain.Generales.Paises.Exceptions;

public class PaisNotFoundException : DomainException
{
  public PaisNotFoundException() : base("El país no existe.") { }
}