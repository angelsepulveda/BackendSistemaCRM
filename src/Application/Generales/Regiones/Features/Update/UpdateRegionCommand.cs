namespace Application.Generales.Regiones.Features.Update;

public record UpdateRegionCommand(Guid Id, string Nombre, Guid PaisId)
               : IRequest<BaseResponse<bool>>;