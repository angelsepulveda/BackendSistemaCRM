namespace Application.Generales.TiposDocumentos.Features.Deactivate;

public record DeactivateTipoDocumentoCommand(Guid Id) : IRequest<BaseResponse<bool>>;
