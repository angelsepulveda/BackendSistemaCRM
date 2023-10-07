using Application.Generales.TiposDocumentos.Specifications;
using Domain.Generales.TiposDocumentos;
using Domain.Generales.TiposDocumentos.Exceptions;

namespace Application.Generales.TiposDocumentos.Features.Update;

internal sealed class UpdateTipoDocumentoCommandHandler
    : IRequestHandler<UpdateTipoDocumentoCommand, BaseResponse<bool>>
{
    private readonly IBaseReadRepository<TipoDocumento, Guid> _tipoDocumentoReadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTipoDocumentoCommandHandler(
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
        UpdateTipoDocumentoCommand request,
        CancellationToken cancellationToken
    )
    {
        var spec = new TipoDocumentoFindByIdEnableSpecification(request.Id);

        var tipoDocumentoUpdated = await _tipoDocumentoReadRepository.GetByWithSpec(spec);

        if (tipoDocumentoUpdated == null)
        {
            throw new TipoDocumentoNotFoundException();
        }

        if (tipoDocumentoUpdated.Nombre != request.Nombre)
        {
            var specNombre = new TipoDocumentoFindByIdNameSpecification(request.Nombre);

            var paisExists = await _tipoDocumentoReadRepository.GetByWithSpec(specNombre);

            if (paisExists != null && paisExists.Activo)
            {
                throw new TipoDocumentoAlreadyExistsException();
            }
        }

        tipoDocumentoUpdated.Update(request.Nombre, request.Descripcion);

        _unitOfWork.WriteRepository<TipoDocumento, Guid>().UpdateEntity(tipoDocumentoUpdated);

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
