using Application.Generales.Regiones.Specifications;
using Domain.Generales.Regiones;
using Domain.Generales.Regiones.Exceptions;

namespace Application.Generales.Regiones.Features.Deactivate;

public sealed class DeactivateRegionCommandHandler :
       IRequestHandler<DeactivateRegionCommand, BaseResponse<bool>>
{
  private readonly IBaseReadRepository<Region, Guid> _regionReadRepository;
  private readonly IUnitOfWork _unitOfWork;

  public DeactivateRegionCommandHandler(
    IBaseReadRepository<Region, Guid> regionReadRepository,
    IUnitOfWork unitOfWork)
  {
    _regionReadRepository = regionReadRepository ?? throw new ArgumentNullException(nameof(regionReadRepository));
    _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
  }

  public async Task<BaseResponse<bool>> Handle(
    DeactivateRegionCommand request, CancellationToken cancellationToken)
  {
    var spec = new RegionFindByIdEnableSpecification(request.Id);

    var regionUpdated = await _regionReadRepository.GetByWithSpec(spec);

    if (regionUpdated == null)
    {
      throw new RegionNotFoundException();
    }

    regionUpdated.ChangeActivo(false);

    _unitOfWork.WriteRepository<Region, Guid>().UpdateEntity(regionUpdated);

    var result = await _unitOfWork.Complete();

    if (result <= 0)
    {
      return new BaseResponse<bool>
      {
        IsSuccess = false,
        Message = "El registro no se desactivó correctamente"
      };
    }

    return new BaseResponse<bool>
    {
      IsSuccess = true,
      Message = "El registro se desactivó correctamente"
    };
  }
}