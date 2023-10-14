using Application.Usuarios.Colaboradores.Specifications;
using Domain.Usuarios.Colaboradores;
using Domain.Usuarios.Colaboradores.Exceptions;
using Domain.Usuarios.Colaboradores.Services;

namespace Application.Usuarios.Colaboradores.Features.Update;

internal sealed class UpdateColaboradorCommandHandler :
   IRequestHandler<UpdateColaboradorCommand, BaseResponse<bool>>
{
  private readonly IBaseReadRepository<Colaborador, Guid> _colaboradorReadRepository;
  private readonly IUnitOfWork _unitOfWork;
  private readonly ITokenService _tokenService;

  public UpdateColaboradorCommandHandler(
         IBaseReadRepository<Colaborador, Guid> colaboradorReadRepository,
         IUnitOfWork unitOfWork,
         ITokenService tokenService
     )
  {
    _colaboradorReadRepository =
        colaboradorReadRepository
        ?? throw new ArgumentNullException(nameof(colaboradorReadRepository));

    _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
  }

  public async Task<BaseResponse<bool>> Handle(
    UpdateColaboradorCommand request,
    CancellationToken cancellationToken)
  {
    var spec = new ColaboradorFindByEmailAndNumDocumentoSpecification(
         request.EmailPersonal,
         request.TipoDocumentoId,
         request.NumDocumento,
         request.EmailAcceso
     );

    var colaboradorExists = await _colaboradorReadRepository.GetByWithSpec(spec);

    if (colaboradorExists != null)
    {
      if (colaboradorExists.Id != request.Id) throw new ColaboradorAlreadyExistsException();
    }

    var specById = new ColaboradorFindByIdSpecification(request.Id);

    var colaboradorUpdated = await _colaboradorReadRepository.GetByWithSpec(specById);

    if (colaboradorUpdated == null) throw new ColaboradorNotFoundException();

    var passwordEncrypt = _tokenService.EncryptPassword(request.Password);

    colaboradorUpdated.Update(
        request.Nombres,
        request.Apellidos,
        request.TipoDocumentoId,
        request.NumDocumento,
        request.FechaNacimiento,
        request.Genero,
        request.EstadoCivil,
        request.EmailPersonal,
        request.Telefono,
        request.EmailAcceso,
        passwordEncrypt,
        request.Rol,
        request.ComunaId,
        request.Direccion
    );

    _unitOfWork.WriteRepository<Colaborador, Guid>().UpdateEntity(colaboradorUpdated);

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
