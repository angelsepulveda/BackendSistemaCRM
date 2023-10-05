namespace Application.Generales.Comunas.Features.Create;

public record CreateComunaCommand(string Nombre, Guid RegionId) : IRequest<BaseResponse<bool>>;
