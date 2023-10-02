using Domain.Generales.Regiones;

namespace Application.Generales.Regiones.Specifications;

public class RegionFindByIdSpecification : BaseSpecification<Region>
{
  public RegionFindByIdSpecification(Guid id) : base(x => x.Id == id)
  {

  }
}