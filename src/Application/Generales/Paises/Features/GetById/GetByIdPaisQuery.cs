using Application.Generales.Paises.Responses;

namespace Application.Generales.Paises.Features.GetById;

public record GetByIdPaisQuery(Guid Id) : IRequest<BaseReponse<GetByIdPaisResponseDto>>;