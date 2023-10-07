namespace Application.Generales.TiposDocumentos.Features.Update;

public record UpdateTipoDocumentoCommand(Guid Id, string Nombre, string Descripcion)
    : IRequest<BaseResponse<bool>>;
