using Application.Generales.Comunas.Responses;

namespace Application.Generales.Comunas.Features.GetById;

public record GetByIdComunaQuery(Guid Id) : IRequest<BaseResponse<GetByIdComunaResponseDto>>;
