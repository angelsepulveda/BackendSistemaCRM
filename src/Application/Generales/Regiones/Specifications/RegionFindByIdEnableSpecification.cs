using Domain.Generales.Regiones;

namespace Application.Generales.Regiones.Specifications;

public class RegionFindByIdEnableSpecification : BaseSpecification<Region>
{
  public RegionFindByIdEnableSpecification(Guid id)
      : base(x => x.Id == id && x.Activo == true)
  { }
}