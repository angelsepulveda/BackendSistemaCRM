namespace Application.Generales.TiposDocumentos.Responses;

public record GetAllTipoDocumentoResponseDto(
    Guid Id,
    string Nombre,
    string Descripcion,
    bool Activo,
    DateTime PublishedAt
);
