namespace Domain.Generales.Paises.Exceptions;

public class PaisEnableException : DomainException
{
  public PaisEnableException()
      : base("El país está activo.") { }
}