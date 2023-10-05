using Domain.Generales.Comunas;

namespace Application.Generales.Comunas.Specifications;

public class ComunasWithRelationsSpecification : BaseSpecification<Comuna>
{
    public ComunasWithRelationsSpecification()
        : base(x => x.Activo == true)
    {
        AddInclude(p => p.Region);
    }
}
