using Application.Common.Specifications;
using Domain.Generales.Paises;

namespace Application.Generales.Paises.Specifications;

public class PaisFindByIdNameSpecification : BaseSpecification<Pais>
{
  public PaisFindByIdNameSpecification(string nombre) : base(x => x.Nombre == nombre)
  {

  }
}