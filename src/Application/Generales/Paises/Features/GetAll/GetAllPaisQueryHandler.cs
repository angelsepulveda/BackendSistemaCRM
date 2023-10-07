using Application.Generales.Paises.Responses;
using Application.Generales.Paises.Specifications;
using Domain.Generales.Paises;

namespace Application.Generales.Paises.Features.GetAll;

internal sealed class GetAllPaisQueryHandler
    : IRequestHandler<GetAllPaisQuery, BaseResponse<IReadOnlyList<GetAllPaisRespondeDto>>>
{
    private readonly IBaseReadRepository<Pais, Guid> _paisReadRepository;

    public GetAllPaisQueryHandler(IBaseReadRepository<Pais, Guid> paisReadRepository)
    {
        _paisReadRepository = paisReadRepository;
    }

    public async Task<BaseResponse<IReadOnlyList<GetAllPaisRespondeDto>>> Handle(
        GetAllPaisQuery request,
        CancellationToken cancellationToken
    )
    {
        var spec = new PaisesEnableSpecification();

        var paises = await _paisReadRepository.GetAllWithSpec(spec);

        return new BaseResponse<IReadOnlyList<GetAllPaisRespondeDto>>()
        {
            IsSuccess = true,
            Data = paises
                .Select(
                    p =>
                        new GetAllPaisRespondeDto(
                            p.Id,
                            p.Nombre,
                            p.Nacionalidad,
                            p.Activo,
                            p.CreatedAt ?? DateTime.Now
                        )
                )
                .ToList()
                .AsReadOnly(),
            Message = "Consulta Exitosa!!"
        };
    }
}
