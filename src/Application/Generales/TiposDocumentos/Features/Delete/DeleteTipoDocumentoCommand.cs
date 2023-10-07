namespace Application.Generales.TiposDocumentos.Features.Delete;

public record DeleteTipoDocumentoCommand(Guid Id) : IRequest<BaseResponse<bool>>;
