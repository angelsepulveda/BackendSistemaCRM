namespace Application.Generales.Regiones.Responses;

public record GetByIdRegionResponseDto(Guid Id, string Nombre, Guid PaisId);