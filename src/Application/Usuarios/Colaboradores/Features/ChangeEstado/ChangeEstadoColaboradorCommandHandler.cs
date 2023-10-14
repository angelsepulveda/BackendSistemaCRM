using Application.Usuarios.Colaboradores.Specifications;
using Domain.Usuarios.Colaboradores;

namespace Application.Usuarios.Colaboradores.Features.ChangeEstado;

internal sealed class ChangeEstadoColaboradorCommandHandler :
     IRequestHandler<ChangeEstadoColaboradorCommand, BaseResponse<bool>>
{
  private readonly IBaseReadRepository<Colaborador, Guid> _colaboradorReadRepository;
  private readonly IUnitOfWork _unitOfWork;

  public ChangeEstadoColaboradorCommandHandler(
         IBaseReadRepository<Colaborador, Guid> colaboradorReadRepository,
         IUnitOfWork unitOfWork
     )
  {
    _colaboradorReadRepository =
        colaboradorReadRepository
        ?? throw new ArgumentNullException(nameof(colaboradorReadRepository));

    _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
  }


  public async Task<BaseResponse<bool>> Handle(
    ChangeEstadoColaboradorCommand request,
     CancellationToken cancellationToken)
  {
    var specById = new ColaboradorFindByIdSpecification(request.Id);

    var colaboradorUpdated = await _colaboradorReadRepository.GetByWithSpec(specById);

    if (colaboradorUpdated == null) throw new ColaboradorNotFoundException();

    colaboradorUpdated.ChangeColaboradorEstado(request.Estado);

    _unitOfWork.WriteRepository<Colaborador, Guid>().UpdateEntity(colaboradorUpdated);

    var result = await _unitOfWork.Complete();

    if (result <= 0)
    {
      return new BaseResponse<bool>
      {
        IsSuccess = false,
        Message = "No se pudo cambiar el estado del registro correctamente"
      };
    }

    return new BaseResponse<bool>
    {
      IsSuccess = true,
      Message = "El cambio del estado del registro se realizo correctamente"
    };
  }
}