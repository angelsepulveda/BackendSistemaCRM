namespace Application.Generales.Regiones.Responses;

public record GetAllRegionResponseDto(
    Guid Id,
   string Nombre,
    string Pais,
    bool Activo,
     DateTime PublishedAt);