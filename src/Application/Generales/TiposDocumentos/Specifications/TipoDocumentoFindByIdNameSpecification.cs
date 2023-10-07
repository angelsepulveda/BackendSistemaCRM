using Domain.Generales.TiposDocumentos;

namespace Application.Generales.TiposDocumentos.Specifications;

public class TipoDocumentoFindByIdNameSpecification : BaseSpecification<TipoDocumento>
{
    public TipoDocumentoFindByIdNameSpecification(string nombre)
        : base(x => x.Nombre == nombre) { }
}
