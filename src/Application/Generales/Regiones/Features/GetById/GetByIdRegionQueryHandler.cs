using Application.Generales.Regiones.Responses;
using Application.Generales.Regiones.Specifications;
using Domain.Generales.Regiones;
using Domain.Generales.Regiones.Exceptions;

namespace Application.Generales.Regiones.Features.GetById;

public sealed class GetByIdRegionQueryHandler :
     IRequestHandler<GetByIdRegionQuery, BaseResponse<GetByIdRegionResponseDto>>
{
  private readonly IBaseReadRepository<Region, Guid> _regionReadRepository;

  public GetByIdRegionQueryHandler(IBaseReadRepository<Region, Guid> regionReadRepository)
  {
    _regionReadRepository = regionReadRepository
        ?? throw new ArgumentNullException(nameof(regionReadRepository));
  }

  public async Task<BaseResponse<GetByIdRegionResponseDto>> Handle(
    GetByIdRegionQuery request,
    CancellationToken cancellationToken)
  {
    var spec = new RegionFindByIdEnableSpecification(request.Id);

    var region = await _regionReadRepository.GetByWithSpec(spec);

    if (region == null)
    {
      throw new RegionNotFoundException();
    }

    return new BaseResponse<GetByIdRegionResponseDto>()
    {
      IsSuccess = true,
      Data = new GetByIdRegionResponseDto(region.Id, region.Nombre, region.PaisId),
      Message = "Consulta exitosa!!"
    };
  }
}