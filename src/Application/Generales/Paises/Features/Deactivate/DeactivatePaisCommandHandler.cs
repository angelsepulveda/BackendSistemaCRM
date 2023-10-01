using Application.Generales.Paises.Specifications;
using Domain.Generales.Paises;
using Domain.Generales.Paises.Exceptions;

namespace Application.Generales.Paises.Features.Deactivate;

public sealed class DeactivatePaisCommandHandler : IRequestHandler<DeactivatePaisCommand, BaseReponse<bool>>
{
  private readonly IBaseReadRepository<Pais, Guid> _paisReadRepository;
  private readonly IUnitOfWork _unitOfWork;

  public DeactivatePaisCommandHandler(
    IBaseReadRepository<Pais, Guid> paisReadRepository,
    IUnitOfWork unitOfWork)
  {
    _paisReadRepository = paisReadRepository;
    _unitOfWork = unitOfWork;
  }

  public async Task<BaseReponse<bool>> Handle(
    DeactivatePaisCommand request,
    CancellationToken cancellationToken)
  {
    var spec = new PaisFindByIdEnableSpecification(request.Id);

    var paisUpdated = await _paisReadRepository.GetByWithSpec(spec);

    if (paisUpdated == null)
    {
      throw new PaisNotFoundException();
    }

    paisUpdated.ChangeActivo(false);

    _unitOfWork.WriteRepository<Pais, Guid>().UpdateEntity(paisUpdated);

    var result = await _unitOfWork.Complete();

    if (result <= 0)
    {
      return new BaseReponse<bool>
      {
        IsSuccess = false,
        Message = "El registro no se desactivó correctamente"
      };
    }

    return new BaseReponse<bool>
    {
      IsSuccess = true,
      Message = "El registro se desactivó correctamente"
    };
  }
}
