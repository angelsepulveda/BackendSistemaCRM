using Domain.Usuarios.Colaboradores;

namespace Application.Usuarios.Colaboradores.Specifications;

public class ColaboradorFindByEmailSpecification : BaseSpecification<Colaborador>
{
  public ColaboradorFindByEmailSpecification(string email) : base(x => x.EmailAcceso == email) { }
}