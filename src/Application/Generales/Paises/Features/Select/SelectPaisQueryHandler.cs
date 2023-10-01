using Application.Generales.Paises.Responses;
using Application.Generales.Paises.Specifications;
using Domain.Generales.Paises;

namespace Application.Generales.Paises.Features.Select;

public sealed class SelectPaisQueryHandler :
   IRequestHandler<SelectPaisQuery, BaseReponse<IReadOnlyList<SelectPaisRespondeDto>>>
{

  private readonly IBaseReadRepository<Pais, Guid> _paisReadRepository;

  public SelectPaisQueryHandler(IBaseReadRepository<Pais, Guid> paisReadRepository)
  {
    _paisReadRepository = paisReadRepository;
  }

  public async Task<BaseReponse<IReadOnlyList<SelectPaisRespondeDto>>> Handle(
    SelectPaisQuery request, CancellationToken cancellationToken)
  {
    var spec = new PaisesEnableSpecification();

    var paises = await _paisReadRepository.GetAllWithSpec(spec);

    return new BaseReponse<IReadOnlyList<SelectPaisRespondeDto>>()
    {
      IsSuccess = true,
      Data = paises.Select(p => new SelectPaisRespondeDto
              (
                p.Id,
                p.Nombre
              )).ToList().AsReadOnly(),
      Message = "Consulta Exitosa!!"
    };
  }
}