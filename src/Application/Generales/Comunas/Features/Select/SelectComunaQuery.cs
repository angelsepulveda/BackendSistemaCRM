using Application.Generales.Comunas.Responses;

namespace Application.Generales.Comunas.Features.Select;

public record SelectComunaQuery() : IRequest<BaseResponse<IReadOnlyList<SelectComunaResponseDto>>>;
