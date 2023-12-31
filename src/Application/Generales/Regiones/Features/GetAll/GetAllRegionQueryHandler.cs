using Application.Generales.Regiones.Responses;
using Domain.Generales.Regiones;

namespace Application.Generales.Regiones.Features.GetAll;

public sealed class GetAllRegionQueryHandler
    : IRequestHandler<GetAllRegionQuery, BaseResponse<IReadOnlyList<GetAllRegionResponseDto>>>
{
    private readonly IBaseReadRepository<Region, Guid> _regionReadRepository;

    public GetAllRegionQueryHandler(IBaseReadRepository<Region, Guid> regionReadRepository)
    {
        _regionReadRepository = regionReadRepository;
    }

    public async Task<BaseResponse<IReadOnlyList<GetAllRegionResponseDto>>> Handle(
        GetAllRegionQuery request,
        CancellationToken cancellationToken
    )
    {
        var regiones = await _regionReadRepository.GetAllAsync();

        return new BaseResponse<IReadOnlyList<GetAllRegionResponseDto>>()
        {
            IsSuccess = true,
            Data = regiones
                .Select(
                    p =>
                        new GetAllRegionResponseDto(
                            p.Id,
                            p.Nombre,
                            p.Pais.Nombre,
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
