using Application.Generales.Regiones.Responses;

namespace Application.Generales.Regiones.Features.GetAll;

public record GetAllRegionQuery : IRequest<BaseResponse<IReadOnlyList<GetAllRegionResponseDto>>>;