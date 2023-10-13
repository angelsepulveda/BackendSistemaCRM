namespace Application.Usuarios.Colaboradores.Responses;

public record GetByIdColaboradorResponseDto(
    Guid Id,
    string Nombres,
    string Apellidos,
    Guid TipoDocumentoId,
    string NumDocumento,
    DateTime FechaNacimiento,
    string Genero,
    string EstadoCivil,
    string EmailPersonal,
    string Telefono,
    string EmailAcceso,
    string Estado,
    string Rol,
    Guid PaisId,
    Guid RegionId,
    Guid ComunaId,
    string Direccion
);
