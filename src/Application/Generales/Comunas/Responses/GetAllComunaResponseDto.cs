namespace Application.Generales.Comunas.Responses;

public record GetAllComunaResponseDto(
    Guid Id,
    string Nombre,
    string Region,
    bool Activo,
    DateTime PublishedAt
);
