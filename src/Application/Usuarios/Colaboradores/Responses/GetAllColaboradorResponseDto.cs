namespace Application.Usuarios.Colaboradores.Responses;

public record GetAllColaboradorResponseDto(
    Guid Id,
    string NombreCompleto,
    string Email,
    string Estado,
    string TipoDocumento,
    string NumDocumento,
    string Direccion,
    DateTime PublishedAt
);
