using Domain.Generales.TiposDocumentos;

namespace Application.Generales.TiposDocumentos.Specifications;

public class TipoDocumentoFindByIdSpecification : BaseSpecification<TipoDocumento>
{
    public TipoDocumentoFindByIdSpecification(Guid id)
        : base(x => x.Id == id) { }
}
