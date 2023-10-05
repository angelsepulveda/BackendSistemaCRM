namespace Application.Generales.Comunas.Responses;

public record GetByIdComunaResponseDto(Guid Id, string Nombre, Guid RegionId);