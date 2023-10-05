using Application.Generales.Comunas.Responses;
using Application.Generales.Comunas.Specifications;
using Domain.Generales.Comunas;

namespace Application.Generales.Comunas.Features.Select;

public sealed class SelectComunaQueryHandler
    : IRequestHandler<SelectComunaQuery, BaseResponse<IReadOnlyList<SelectComunaResponseDto>>>
{
    private readonly IBaseReadRepository<Comuna, Guid> _comunaReadRepository;

    public SelectComunaQueryHandler(IBaseReadRepository<Comuna, Guid> comunaReadRepository)
    {
        _comunaReadRepository =
            comunaReadRepository ?? throw new ArgumentNullException(nameof(comunaReadRepository));
    }

    public async Task<BaseResponse<IReadOnlyList<SelectComunaResponseDto>>> Handle(
        SelectComunaQuery request,
        CancellationToken cancellationToken
    )
    {
        var spec = new ComunasEnableSpecification();

        var comunas = await _comunaReadRepository.GetAllWithSpec(spec);

        return new BaseResponse<IReadOnlyList<SelectComunaResponseDto>>()
        {
            IsSuccess = true,
            Data = comunas
                .Select(p => new SelectComunaResponseDto(p.Id, p.Nombre, p.RegionId))
                .ToList()
                .AsReadOnly(),
            Message = "Consulta Exitosa!!"
        };
    }
}
