using Application.Generales.Paises.Specifications;
using Domain.Generales.Paises;
using Domain.Generales.Paises.Exceptions;

namespace Application.Generales.Paises.Features.Activate;

public sealed class ActivatePaisCommandHandler : IRequestHandler<ActivatePaisCommand, BaseReponse<bool>>
{
  private readonly IBaseReadRepository<Pais, Guid> _paisReadRepository;
  private readonly IUnitOfWork _unitOfWork;

  public ActivatePaisCommandHandler(
    IBaseReadRepository<Pais, Guid> paisReadRepository,
     IUnitOfWork unitOfWork)
  {
    _paisReadRepository = paisReadRepository;
    _unitOfWork = unitOfWork;
  }

  public async Task<BaseReponse<bool>> Handle(
    ActivatePaisCommand request,
    CancellationToken cancellationToken)
  {
    var spec = new PaisFindByIdSpecification(request.Id);

    var paisUpdated = await _paisReadRepository.GetByWithSpec(spec);

    if (paisUpdated == null)
    {
      throw new PaisNotFoundException();
    }

    if (paisUpdated.Activo)
    {
      throw new PaisEnableException();
    }

    paisUpdated.ChangeActivo(true);

    _unitOfWork.WriteRepository<Pais, Guid>().UpdateEntity(paisUpdated);

    var result = await _unitOfWork.Complete();

    if (result <= 0)
    {
      return new BaseReponse<bool>
      {
        IsSuccess = false,
        Message = "El registro no se activó correctamente"
      };
    }

    return new BaseReponse<bool>
    {
      IsSuccess = true,
      Message = "El registro se activó correctamente"
    };
  }
}