using Application.Generales.Regiones.Specifications;
using Domain.Generales.Regiones;
using Domain.Generales.Regiones.Exceptions;

namespace Application.Generales.Regiones.Features.Activate;

public sealed class ActivateRegionCommandHandler : IRequestHandler<ActivateRegionCommand, BaseResponse<bool>>
{
  private readonly IBaseReadRepository<Region, Guid> _regionReadRepository;
  private readonly IUnitOfWork _unitOfWork;

  public ActivateRegionCommandHandler(
    IBaseReadRepository<Region, Guid> regionReadRepository,
    IUnitOfWork unitOfWork)
  {
    _regionReadRepository = regionReadRepository ?? throw new ArgumentNullException(nameof(regionReadRepository));
    _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
  }

  public async Task<BaseResponse<bool>> Handle(
    ActivateRegionCommand request,
    CancellationToken cancellationToken)
  {
    var spec = new RegionFindByIdSpecification(request.Id);

    var regionUpdated = await _regionReadRepository.GetByWithSpec(spec);

    if (regionUpdated == null)
    {
      throw new RegionNotFoundException();
    }

    if (regionUpdated.Activo)
    {
      throw new RegionEnableException();
    }

    regionUpdated.ChangeActivo(true);

    _unitOfWork.WriteRepository<Region, Guid>().UpdateEntity(regionUpdated);

    var result = await _unitOfWork.Complete();

    if (result <= 0)
    {
      return new BaseResponse<bool>
      {
        IsSuccess = false,
        Message = "El registro no se activó correctamente"
      };
    }

    return new BaseResponse<bool>
    {
      IsSuccess = true,
      Message = "El registro se activó correctamente"
    };
  }
}