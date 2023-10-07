namespace Application.Generales.TiposDocumentos.Features.Create;

public record CreateTipoDocumentoCommand(string Nombre, string Descripcion)
    : IRequest<BaseResponse<bool>>;
