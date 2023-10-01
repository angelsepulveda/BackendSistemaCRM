using Application.Generales.Paises.Responses;

namespace Application.Generales.Paises.Features.Select;

public record SelectPaisQuery : IRequest<BaseReponse<IReadOnlyList<SelectPaisRespondeDto>>>;