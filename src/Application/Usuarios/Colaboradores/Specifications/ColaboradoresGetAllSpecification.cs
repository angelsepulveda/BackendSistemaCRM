using Domain.Usuarios.Colaboradores;

namespace Application.Usuarios.Colaboradores.Specifications;

public class ColaboradoresGetAllSpecification : BaseSpecification<Colaborador>
{
    public ColaboradoresGetAllSpecification()
        : base()
    {
        AddInclude(p => p.Comuna.Region.Pais);
        AddInclude(p => p.TipoDocumento);
    }
}
