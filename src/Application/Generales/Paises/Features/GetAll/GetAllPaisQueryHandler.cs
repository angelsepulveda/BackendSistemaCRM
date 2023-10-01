using Application.Generales.Paises.Responses;
using Application.Generales.Paises.Specifications;
using Domain.Generales.Paises;

namespace Application.Generales.Paises.Features.GetAll;

public sealed class GetAllPaisQueryHandler :
          IRequestHandler<GetAllPaisQuery, BaseReponse<IReadOnlyList<GetAllPaisRespondeDto>>>
{
  private readonly IBaseReadRepository<Pais, Guid> _paisReadRepository;

  public GetAllPaisQueryHandler(IBaseReadRepository<Pais, Guid> paisReadRepository)
  {
    _paisReadRepository = paisReadRepository;
  }

  public async Task<BaseReponse<IReadOnlyList<GetAllPaisRespondeDto>>> Handle(
      GetAllPaisQuery request, CancellationToken cancellationToken)
  {
    var spec = new PaisesEnableSpecification();

    var paises = await _paisReadRepository.GetAllWithSpec(spec);

    return new BaseReponse<IReadOnlyList<GetAllPaisRespondeDto>>()
    {
      IsSuccess = true,
      Data = paises.Select(p => new GetAllPaisRespondeDto
              (
                p.Id,
                p.Nombre,
                p.Nacionalidad,
                p.Activo,
                p.CreatedAt ?? DateTime.Now
              )).ToList().AsReadOnly(),
      Message = "Consulta Exitosa!!"
    };
  }
}