using Domain.Usuarios.Colaboradores;

namespace Application.Usuarios.Colaboradores.Specifications;

public class ColaboradorFindByIdSpecification : BaseSpecification<Colaborador>
{
    public ColaboradorFindByIdSpecification(Guid id)
        : base(x => x.Id == id)
    {
        AddInclude(p => p.Comuna);
    }
}
