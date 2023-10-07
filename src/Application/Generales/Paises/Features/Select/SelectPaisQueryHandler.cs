using Application.Generales.Paises.Responses;
using Application.Generales.Paises.Specifications;
using Domain.Generales.Paises;

namespace Application.Generales.Paises.Features.Select;

internal sealed class SelectPaisQueryHandler
    : IRequestHandler<SelectPaisQuery, BaseResponse<IReadOnlyList<SelectPaisRespondeDto>>>
{
    private readonly IBaseReadRepository<Pais, Guid> _paisReadRepository;

    public SelectPaisQueryHandler(IBaseReadRepository<Pais, Guid> paisReadRepository)
    {
        _paisReadRepository = paisReadRepository;
    }

    public async Task<BaseResponse<IReadOnlyList<SelectPaisRespondeDto>>> Handle(
        SelectPaisQuery request,
        CancellationToken cancellationToken
    )
    {
        var spec = new PaisesEnableSpecification();

        var paises = await _paisReadRepository.GetAllWithSpec(spec);

        return new BaseResponse<IReadOnlyList<SelectPaisRespondeDto>>()
        {
            IsSuccess = true,
            Data = paises
                .Select(p => new SelectPaisRespondeDto(p.Id, p.Nombre))
                .ToList()
                .AsReadOnly(),
            Message = "Consulta Exitosa!!"
        };
    }
}
