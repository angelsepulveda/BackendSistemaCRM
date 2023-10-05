namespace Application.Generales.Comunas.Responses;

public record GetAllComunaResponseDto(
  Guid Id,
  string Nombre,
   Guid RegionId,
   bool Activo,
   DateTime PublishedAt);