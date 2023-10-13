namespace Application.Usuarios.Colaboradores.Features.Create;

public record CreateColaboradorCommand(
    string Nombres,
    string Apellidos,
    Guid TipoDocumentoId,
    string NumDocumento,
    DateTime FechaNacimiento,
    string Genero,
    string EstadoCivil,
    string EmailPersonal,
    string Password,
    string ConfirmPassword,
    string Telefono,
    string EmailAcceso,
    string Estado,
    string Rol,
    Guid ComunaId,
    string Direccion
) : IRequest<BaseResponse<bool>>;
