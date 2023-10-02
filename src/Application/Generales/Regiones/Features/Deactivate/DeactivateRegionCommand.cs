namespace Application.Generales.Regiones.Features.Deactivate;

public record DeactivateRegionCommand(Guid Id) : IRequest<BaseResponse<bool>>;