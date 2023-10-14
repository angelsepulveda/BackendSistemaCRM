namespace Application.Usuarios.Colaboradores.Features.ChangeEstado;

public record ChangeEstadoColaboradorCommand(Guid Id, string Estado) : IRequest<BaseResponse<bool>>;