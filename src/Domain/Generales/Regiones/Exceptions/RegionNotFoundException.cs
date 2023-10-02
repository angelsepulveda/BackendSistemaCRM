namespace Domain.Generales.Regiones.Exceptions;

public class RegionNotFoundException : DomainException
{
  public RegionNotFoundException() : base("La región no existe.") { }
}