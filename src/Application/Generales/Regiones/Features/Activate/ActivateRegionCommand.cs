namespace Application.Generales.Regiones.Features.Activate;

public record ActivateRegionCommand(Guid Id) : IRequest<BaseResponse<bool>>;