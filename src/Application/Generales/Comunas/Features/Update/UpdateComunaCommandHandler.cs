using Application.Generales.Comunas.Specifications;
using Domain.Generales.Comunas;
using Domain.Generales.Comunas.Exceptions;

namespace Application.Generales.Comunas.Features.Update;

public sealed class UpdateComunaCommandHandler :
    IRequestHandler<UpdateComunaCommand, BaseResponse<bool>>
{

  private readonly IBaseReadRepository<Comuna, Guid> _comunaReadRepository;
  private readonly IUnitOfWork _unitOfWork;

  public UpdateComunaCommandHandler(
    IBaseReadRepository<Comuna, Guid> comunaReadRepository,
    IUnitOfWork unitOfWork)
  {
    _comunaReadRepository = comunaReadRepository ?? throw new ArgumentNullException(nameof(comunaReadRepository));
    _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
  }

  public async Task<BaseResponse<bool>> Handle(
    UpdateComunaCommand request,
    CancellationToken cancellationToken)
  {
    var spec = new ComunaFindByIdEnableSpecification(request.Id);

    var comunaUpdated = await _comunaReadRepository.GetByWithSpec(spec);

    if (comunaUpdated == null)
    {
      throw new ComunaNotFoundException();
    }

    comunaUpdated.Update(request.Nombre, request.RegionId);

    _unitOfWork.WriteRepository<Comuna, Guid>().UpdateEntity(comunaUpdated);

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
