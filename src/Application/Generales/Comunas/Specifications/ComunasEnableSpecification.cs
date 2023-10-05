using Domain.Generales.Comunas;

namespace Application.Generales.Comunas.Specifications;

public class ComunasEnableSpecification : BaseSpecification<Comuna>
{
    public ComunasEnableSpecification()
        : base(x => x.Activo == true) { }
}
