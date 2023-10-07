namespace Domain.Generales.TiposDocumentos.Exceptions;

public class TipoDocumentoAlreadyExistsException : DomainException
{
    public TipoDocumentoAlreadyExistsException()
        : base("El tipo documento ya está registrado.") { }
}
