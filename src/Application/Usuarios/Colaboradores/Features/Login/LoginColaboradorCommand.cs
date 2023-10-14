using Application.Usuarios.Colaboradores.Responses;

namespace Application.Usuarios.Colaboradores.Features.Login;

public record LoginColaboradorCommand(string Email, string Password)
  : IRequest<BaseResponse<LoginColaboradorResponseDto>>;