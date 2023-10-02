using Domain.Generales.Regiones;

namespace Application.Generales.Regiones.Specifications;

public class RegionWithRelationsSpecification : BaseSpecification<Region>
{
  public RegionWithRelationsSpecification() : base(x => x.Activo == true)
  {
    AddInclude(x => x.Pais);
  }
}