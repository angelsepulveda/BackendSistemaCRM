namespace Application.Generales.Comunas.Features.Deactivate;

public record DeactivateComunaCommand(Guid Id) : IRequest<BaseResponse<bool>>;
