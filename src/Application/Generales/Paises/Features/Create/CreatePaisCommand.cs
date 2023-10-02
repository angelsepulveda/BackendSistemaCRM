namespace Application.Generales.Paises.Features.Create;

public record CreatePaisCommand(string Nombre, string Nacionalidad) : IRequest<BaseResponse<bool>>;
