using Domain.Generales.TiposDocumentos;

namespace Application.Generales.TiposDocumentos.Specifications;

public class TiposDocumentosEnableSpecification : BaseSpecification<TipoDocumento>
{
    public TiposDocumentosEnableSpecification()
        : base(x => x.Activo == true) { }
}
