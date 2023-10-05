using Domain.Generales.Comunas;

namespace Application.Generales.Comunas.Specifications;

public class ComunaFindByIdEnableSpecification : BaseSpecification<Comuna>
{
  public ComunaFindByIdEnableSpecification(Guid id)
      : base(x => x.Id == id && x.Activo == true)
  {

  }
}