using Application.Generales.Regiones.Specifications;
using Domain.Generales.Regiones;
using Domain.Generales.Regiones.Exceptions;

namespace Application.Generales.Regiones.Features.Delete;

public sealed class DeleteRegionCommandHandler :
    IRequestHandler<DeleteRegionCommand, BaseResponse<bool>>
{
  private readonly IBaseReadRepository<Region, Guid> _regionReadRepository;
  private readonly IUnitOfWork _unitOfWork;

  public DeleteRegionCommandHandler(
    IBaseReadRepository<Region, Guid> regionReadRepository,
    IUnitOfWork unitOfWork)
  {
    _regionReadRepository = regionReadRepository ?? throw new ArgumentNullException(nameof(regionReadRepository));
    _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
  }

  public async Task<BaseResponse<bool>> Handle(
    DeleteRegionCommand request,
    CancellationToken cancellationToken)
  {
    var spec = new RegionFindByIdSpecification(request.Id);

    var regionDeleted = await _regionReadRepository.GetByWithSpec(spec);

    if (regionDeleted == null)
    {
      throw new RegionNotFoundException();
    }

    if (regionDeleted.Activo)
    {
      throw new RegionEnableException();
    }

    _unitOfWork.WriteRepository<Region, Guid>().DeleteEntity(regionDeleted);

    var result = await _unitOfWork.Complete();

    if (result <= 0)
    {
      return new BaseResponse<bool>
      {
        IsSuccess = false,
        Message = "El registro no se eliminó correctamente"
      };
    }

    return new BaseResponse<bool>
    {
      IsSuccess = true,
      Message = "El registro se eliminó correctamente"
    };
  }
}