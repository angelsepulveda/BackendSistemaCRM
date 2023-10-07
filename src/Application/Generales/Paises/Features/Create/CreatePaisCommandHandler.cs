using Application.Generales.Paises.Specifications;
using Domain.Generales.Paises;
using Domain.Generales.Paises.Exceptions;

namespace Application.Generales.Paises.Features.Create;

internal sealed class CreatePaisCommandHandler
    : IRequestHandler<CreatePaisCommand, BaseResponse<bool>>
{
    private readonly IBaseReadRepository<Pais, Guid> _paisReadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePaisCommandHandler(
        IBaseReadRepository<Pais, Guid> paisReadRepository,
        IUnitOfWork unitOfWork
    )
    {
        _paisReadRepository = paisReadRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<bool>> Handle(
        CreatePaisCommand request,
        CancellationToken cancellationToken
    )
    {
        var spec = new PaisFindByIdNameSpecification(request.Nombre);
        var paisExists = await _paisReadRepository.GetByWithSpec(spec);

        if (paisExists != null)
        {
            if (paisExists.Activo)
            {
                throw new PaisAlreadyExistsException();
            }

            // Activamos el registro
            paisExists.ChangeActivo(true);
            _unitOfWork.WriteRepository<Pais, Guid>().UpdateEntity(paisExists);
        }
        else
        {
            var pais = new Pais(Guid.NewGuid(), request.Nombre, request.Nacionalidad, true);
            _unitOfWork.WriteRepository<Pais, Guid>().AddEntity(pais);
        }

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
