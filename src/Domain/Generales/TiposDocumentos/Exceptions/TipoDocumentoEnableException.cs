namespace Domain.Generales.TiposDocumentos.Exceptions;

public class TipoDocumentoEnableException : DomainException
{
    public TipoDocumentoEnableException()
        : base("El tipo de documento está activo.") { }
}
