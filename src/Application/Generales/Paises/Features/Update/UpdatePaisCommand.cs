namespace Application.Generales.Paises.Features.Update;

public record UpdatePaisCommand(Guid Id, string Nombre, string Nacionalidad) : IRequest<BaseResponse<bool>>;