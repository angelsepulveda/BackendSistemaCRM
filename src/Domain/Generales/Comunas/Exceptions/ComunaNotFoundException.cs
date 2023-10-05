namespace Domain.Generales.Comunas.Exceptions;

public class ComunaNotFoundException : DomainException
{
  public ComunaNotFoundException() : base("La comuna no existe.") { }
}