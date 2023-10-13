using Application.Usuarios.Colaboradores.Responses;

namespace Application.Usuarios.Colaboradores.Features.GetById;

public record GetByIdColaboradorQuery(Guid Id)
    : IRequest<BaseResponse<GetByIdColaboradorResponseDto>>;
