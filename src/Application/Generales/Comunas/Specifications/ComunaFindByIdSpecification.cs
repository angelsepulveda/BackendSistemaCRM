using Domain.Generales.Comunas;

namespace Application.Generales.Comunas.Specifications;

public class ComunaFindByIdSpecification : BaseSpecification<Comuna>
{
    public ComunaFindByIdSpecification(Guid id)
        : base(x => x.Id == id) { }
}
