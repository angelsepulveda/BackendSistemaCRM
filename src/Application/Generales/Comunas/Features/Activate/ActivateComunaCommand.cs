namespace Application.Generales.Comunas.Features.Activate;

public record ActivateComunaCommand(Guid Id) : IRequest<BaseResponse<bool>>;