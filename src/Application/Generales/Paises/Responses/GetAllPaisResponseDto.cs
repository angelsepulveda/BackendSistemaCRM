namespace Application.Generales.Paises.Responses;

public record GetAllPaisRespondeDto(
  Guid Id, string Nombre, string Nacionalidad, bool Activo, DateTime PublishedAt);