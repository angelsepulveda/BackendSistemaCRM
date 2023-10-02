using Application.Generales.Regiones.Responses;

namespace Application.Generales.Regiones.Features.Select;

public record SelectRegionQuery() : IRequest<BaseResponse<IReadOnlyList<SelectRegionResponseDto>>>;