using Domain.Generales.Paises;

namespace Application.Generales.Paises.Specifications;

public class PaisFindByIdEnableSpecification : BaseSpecification<Pais>
{
    public PaisFindByIdEnableSpecification(Guid id)
        : base(x => x.Id == id && x.Activo == true) { }
}
