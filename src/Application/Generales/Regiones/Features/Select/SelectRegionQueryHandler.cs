using System;
using Application.Generales.Regiones.Responses;
using Application.Generales.Regiones.Specifications;
using Domain.Generales.Regiones;

namespace Application.Generales.Regiones.Features.Select;

public sealed class SelectRegionQueryHandler :
  IRequestHandler<SelectRegionQuery, BaseResponse<IReadOnlyList<SelectRegionResponseDto>>>
{
  private readonly IBaseReadRepository<Region, Guid> _regionReadRepository;

  public SelectRegionQueryHandler(IBaseReadRepository<Region, Guid> regionReadRepository)
  {
    _regionReadRepository = regionReadRepository
        ?? throw new ArgumentNullException(nameof(regionReadRepository));
  }

  public async Task<BaseResponse<IReadOnlyList<SelectRegionResponseDto>>> Handle(
  SelectRegionQuery request, CancellationToken cancellationToken)
  {
    var spec = new RegionesEnableSpecification();

    var regiones = await _regionReadRepository.GetAllWithSpec(spec);

    return new BaseResponse<IReadOnlyList<SelectRegionResponseDto>>()
    {
      IsSuccess = true,
      Data = regiones.Select(p => new SelectRegionResponseDto
              (
                p.Id,
                p.Nombre,
                p.PaisId
              )).ToList().AsReadOnly(),
      Message = "Consulta Exitosa!!"
    };
  }
}