
using Application.Generales.Paises.Specifications;
using Domain.Generales.Paises;
using Domain.Generales.Paises.Exceptions;

namespace Application.Generales.Paises.Features.Update;

public sealed class UpdatePaisCommandHandler : IRequestHandler<UpdatePaisCommand, BaseResponse<bool>>
{
  private readonly IBaseReadRepository<Pais, Guid> _paisReadRepository;
  private readonly IUnitOfWork _unitOfWork;

  public UpdatePaisCommandHandler(
    IBaseReadRepository<Pais, Guid> paisReadRepository,
    IUnitOfWork unitOfWork)
  {
    _paisReadRepository = paisReadRepository;
    _unitOfWork = unitOfWork;
  }

  public async Task<BaseResponse<bool>> Handle(
    UpdatePaisCommand request,
    CancellationToken cancellationToken)
  {

    var spec = new PaisFindByIdEnableSpecification(request.Id);

    var paisUpdated = await _paisReadRepository.GetByWithSpec(spec);

    if (paisUpdated == null)
    {
      throw new PaisNotFoundException();
    }

    if (paisUpdated.Nombre != request.Nombre)
    {
      var specNombre = new PaisFindByIdNameSpecification(request.Nombre);

      var paisExists = await _paisReadRepository.GetByWithSpec(specNombre);

      if (paisExists != null && paisExists.Activo)
      {
        throw new PaisAlreadyExistsException();
      }
    }

    paisUpdated.Update(request.Nombre, request.Nacionalidad);

    _unitOfWork.WriteRepository<Pais, Guid>().UpdateEntity(paisUpdated);

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