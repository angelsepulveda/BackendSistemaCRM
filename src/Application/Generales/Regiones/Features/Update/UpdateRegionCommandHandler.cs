using Application.Generales.Regiones.Specifications;
using Domain.Generales.Regiones;
using Domain.Generales.Regiones.Exceptions;

namespace Application.Generales.Regiones.Features.Update;

public sealed class UpdateRegionCommandHandler
   : IRequestHandler<UpdateRegionCommand, BaseResponse<bool>>
{
  private readonly IBaseReadRepository<Region, Guid> _regionReadRepository;
  private readonly IUnitOfWork _unitOfWork;

  public UpdateRegionCommandHandler(
    IBaseReadRepository<Region, Guid> regionReadRepository,
    IUnitOfWork unitOfWork)
  {
    _regionReadRepository = regionReadRepository ?? throw new ArgumentNullException(nameof(regionReadRepository));
    _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
  }

  public async Task<BaseResponse<bool>> Handle(
    UpdateRegionCommand request, CancellationToken cancellationToken)
  {
    var spec = new RegionFindByIdEnableSpecification(request.Id);

    var regionUpdated = await _regionReadRepository.GetByWithSpec(spec);

    if (regionUpdated == null)
    {
      throw new RegionNotFoundException();
    }

    regionUpdated.Update(request.Nombre, request.PaisId);

    _unitOfWork.WriteRepository<Region, Guid>().UpdateEntity(regionUpdated);

    var result = await _unitOfWork.Complete();

    if (result <= 0)
    {
      return new BaseResponse<bool>
      {
        IsSuccess = false,
        Message = "El registro no se actualizó correctamente"
      };
    }

    return new BaseResponse<bool>
    {
      IsSuccess = true,
      Message = "El registro se actualizó correctamente"
    };
  }
}