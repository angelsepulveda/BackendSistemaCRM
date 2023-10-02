using Domain.Generales.Regiones;

namespace Application.Generales.Regiones.Specifications;

public class RegionesEnableSpecification : BaseSpecification<Region>
{
  public RegionesEnableSpecification() : base(x => x.Activo == true)
  {

  }
}