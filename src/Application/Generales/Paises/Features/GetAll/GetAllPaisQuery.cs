using Application.Generales.Paises.Responses;

namespace Application.Generales.Paises.Features.GetAll;

public record GetAllPaisQuery() : IRequest<BaseReponse<IReadOnlyList<GetAllPaisRespondeDto>>>;