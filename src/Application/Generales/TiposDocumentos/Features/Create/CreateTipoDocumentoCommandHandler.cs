using Application.Generales.TiposDocumentos.Specifications;
using Domain.Generales.TiposDocumentos;
using Domain.Generales.TiposDocumentos.Exceptions;

namespace Application.Generales.TiposDocumentos.Features.Create;

public class CreateTipoDocumentoCommandHandler
    : IRequestHandler<CreateTipoDocumentoCommand, BaseResponse<bool>>
{
    private readonly IBaseReadRepository<TipoDocumento, Guid> _tipoDocumentoReadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTipoDocumentoCommandHandler(
        IBaseReadRepository<TipoDocumento, Guid> tipoDocumentoReadRepository,
        IUnitOfWork unitOfWork
    )
    {
        _tipoDocumentoReadRepository =
            tipoDocumentoReadRepository
            ?? throw new ArgumentNullException(nameof(tipoDocumentoReadRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<BaseResponse<bool>> Handle(
        CreateTipoDocumentoCommand request,
        CancellationToken cancellationToken
    )
    {
        var spec = new TipoDocumentoFindByIdNameSpecification(request.Nombre);
        var tipoDocumentoExists = await _tipoDocumentoReadRepository.GetByWithSpec(spec);

        if (tipoDocumentoExists != null)
        {
            if (tipoDocumentoExists.Activo)
            {
                throw new TipoDocumentoAlreadyExistsException();
            }

            // Activamos el registro
            tipoDocumentoExists.ChangeActivo(true);

            _unitOfWork.WriteRepository<TipoDocumento, Guid>().UpdateEntity(tipoDocumentoExists);
        }
        else
        {
            var tipoDocumento = new TipoDocumento(
                Guid.NewGuid(),
                request.Nombre,
                request.Descripcion,
                true
            );
            _unitOfWork.WriteRepository<TipoDocumento, Guid>().AddEntity(tipoDocumento);
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
