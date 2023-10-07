namespace Domain.Generales.Regiones.Exceptions;

public class RegionEnableException : DomainException
{
  public RegionEnableException()
      : base("La región está activo.") { }
}