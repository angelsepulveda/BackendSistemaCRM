namespace Application.Generales.Regiones.Features.Create;

public record CreateRegionCommand(string Nombre, Guid PaisId) : IRequest<BaseResponse<bool>>;