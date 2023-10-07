namespace Application.Generales.TiposDocumentos.Features.Activate;

public record ActivateTipoDocumentoCommand(Guid Id) : IRequest<BaseResponse<bool>>;
