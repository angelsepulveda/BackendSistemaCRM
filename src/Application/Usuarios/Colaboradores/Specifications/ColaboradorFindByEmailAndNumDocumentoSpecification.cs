using Domain.Usuarios.Colaboradores;

namespace Application.Usuarios.Colaboradores.Specifications;

public class ColaboradorFindByEmailAndNumDocumentoSpecification : BaseSpecification<Colaborador>
{
    public ColaboradorFindByEmailAndNumDocumentoSpecification(
        string emailPersonal,
        Guid tipoDocumentoId,
        string numDocumento,
        string emailAcceso
    )
        : base(
            x =>
                x.EmailPersonal == emailPersonal == true
                || x.EmailAcceso == emailAcceso == true
                || (
                    x.TipoDocumentoId == tipoDocumentoId == true
                    && x.NumDocumento == numDocumento == true
                )
        ) { }
}
