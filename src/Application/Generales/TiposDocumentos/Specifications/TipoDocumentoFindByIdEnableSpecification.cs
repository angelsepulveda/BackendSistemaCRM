using Domain.Generales.TiposDocumentos;

namespace Application.Generales.TiposDocumentos.Specifications;

public class TipoDocumentoFindByIdEnableSpecification : BaseSpecification<TipoDocumento>
{
    public TipoDocumentoFindByIdEnableSpecification(Guid id)
        : base(x => x.Id == id && x.Activo == true) { }
}
