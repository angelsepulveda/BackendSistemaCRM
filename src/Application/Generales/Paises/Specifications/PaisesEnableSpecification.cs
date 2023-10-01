using Application.Common.Specifications;
using Domain.Generales.Paises;

namespace Application.Generales.Paises.Specifications;

public class PaisesEnableSpecification : BaseSpecification<Pais>
{
  public PaisesEnableSpecification() : base(x => x.Activo == true)
  {

  }
}