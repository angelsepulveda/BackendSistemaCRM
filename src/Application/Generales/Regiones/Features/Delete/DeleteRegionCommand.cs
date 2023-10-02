namespace Application.Generales.Regiones.Features.Delete;

public record DeleteRegionCommand(Guid Id) : IRequest<BaseResponse<bool>>;