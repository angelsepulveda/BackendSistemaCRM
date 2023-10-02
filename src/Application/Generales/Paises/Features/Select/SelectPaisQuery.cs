using Application.Generales.Paises.Responses;

namespace Application.Generales.Paises.Features.Select;

public record SelectPaisQuery : IRequest<BaseResponse<IReadOnlyList<SelectPaisRespondeDto>>>;