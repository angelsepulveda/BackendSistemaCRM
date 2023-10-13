using Application.Usuarios.Colaboradores.Specifications;
using Domain.Usuarios.Colaboradores;
using Domain.Usuarios.Colaboradores.Exceptions;
using Domain.Usuarios.Colaboradores.Services;

namespace Application.Usuarios.Colaboradores.Features.Create;

internal sealed class CreateColaboradorCommandHandler
    : IRequestHandler<CreateColaboradorCommand, BaseResponse<bool>>
{
    private readonly IBaseReadRepository<Colaborador, Guid> _colaboradorReadRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;

    public CreateColaboradorCommandHandler(
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
        CreateColaboradorCommand request,
        CancellationToken cancellationToken
    )
    {
        var spec = new ColaboradorFindByEmailAndNumDocumentoSpecification(
            request.EmailPersonal,
            request.TipoDocumentoId,
            request.NumDocumento,
            request.EmailAcceso
        );

        var colaboradorExists = await _colaboradorReadRepository.GetByWithSpec(spec);

        if (colaboradorExists != null)
            throw new ColaboradorAlreadyExistsException();

        string passwordEncrypt = _tokenService.EncryptPassword(request.Password);

        var colaborador = new Colaborador(
            Guid.NewGuid(),
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
            request.Estado,
            request.Rol,
            request.ComunaId,
            request.Direccion
        );

        _unitOfWork.WriteRepository<Colaborador, Guid>().AddEntity(colaborador);

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
