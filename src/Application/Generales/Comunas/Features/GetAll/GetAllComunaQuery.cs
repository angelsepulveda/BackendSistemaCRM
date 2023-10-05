using Application.Generales.Comunas.Responses;

namespace Application.Generales.Comunas.Features.GetAll;

public record GetAllComunaQuery : IRequest<BaseResponse<IReadOnlyList<GetAllComunaResponseDto>>>;
