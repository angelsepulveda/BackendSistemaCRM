namespace Application.Generales.Comunas.Features.Update;

public record UpdateComunaCommand(
  Guid Id, string Nombre, Guid RegionId) : IRequest<BaseResponse<bool>>;