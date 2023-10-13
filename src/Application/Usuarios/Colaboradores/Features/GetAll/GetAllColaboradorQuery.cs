using Application.Usuarios.Colaboradores.Responses;

namespace Application.Usuarios.Colaboradores.Features.GetAll;

public record GetAllColaboradorQuery()
    : IRequest<BaseResponse<IReadOnlyList<GetAllColaboradorResponseDto>>>;
