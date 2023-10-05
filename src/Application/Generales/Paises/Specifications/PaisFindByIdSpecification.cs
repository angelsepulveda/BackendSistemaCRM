using Domain.Generales.Paises;

namespace Application.Generales.Paises.Specifications;

public class PaisFindByIdSpecification : BaseSpecification<Pais>
{
    public PaisFindByIdSpecification(Guid id)
        : base(x => x.Id == id) { }
}
