namespace Domain.Generales.TiposDocumentos.Exceptions;

public class TipoDocumentoNotFoundException : DomainException
{
    public TipoDocumentoNotFoundException()
        : base("El tipo de documento no existe.") { }
}
