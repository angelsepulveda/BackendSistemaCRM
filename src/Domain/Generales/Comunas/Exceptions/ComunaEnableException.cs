namespace Domain.Generales.Comunas.Exceptions;

public class ComunaEnableException : DomainException
{
   public ComunaEnableException()
      : base("La comuna está activa.") { }
}