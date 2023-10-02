using Domain.Generales.Regiones;

namespace Application.Generales.Regiones.Features.Create;

public sealed class CreateRegionCommandHandler :
        IRequestHandler<CreateRegionCommand, BaseResponse<bool>>
{
  private readonly IBaseReadRepository<Region, Guid> _regionReadRepository;
  private readonly IUnitOfWork _unitOfWork;

  public CreateRegionCommandHandler(
    IBaseReadRepository<Region, Guid> regionReadRepository,
     IUnitOfWork unitOfWork)
  {
    _regionReadRepository = regionReadRepository ?? throw new ArgumentNullException(nameof(regionReadRepository));
    _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
  }

  public async Task<BaseResponse<bool>> Handle(
    CreateRegionCommand request,
    CancellationToken cancellationToken)
  {

    var region = new Region(Guid.NewGuid(), request.Nombre, request.PaisId, true);

    _unitOfWork.WriteRepository<Region, Guid>().AddEntity(region);


    var result = await _unitOfWork.Complete();

    if (result <= 0)
    {
      return new BaseResponse<bool>()
      {
        IsSuccess = false,
        Message = "El registro no se creó correctamente"
      };

    }

    return new BaseResponse<bool>()
    {
      IsSuccess = true,
      Message = "El registro se creó correctamente"
    };

  }
}