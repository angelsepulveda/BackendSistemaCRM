namespace Application.Generales.Regiones.Responses;

public record GetAllRegionResponseDto(Guid Id, string Nombre, string Pais, DateTime PublishedAt);