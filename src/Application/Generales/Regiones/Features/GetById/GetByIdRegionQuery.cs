using Application.Generales.Regiones.Responses;

namespace Application.Generales.Regiones.Features.GetById;

public record GetByIdRegionQuery(Guid Id) : IRequest<BaseResponse<GetByIdRegionResponseDto>>;