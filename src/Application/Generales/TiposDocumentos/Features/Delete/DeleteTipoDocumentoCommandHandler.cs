using Application.Generales.TiposDocumentos.Specifications;
using Domain.Generales.TiposDocumentos;
using Domain.Generales.TiposDocumentos.Exceptions;

namespace Application.Generales.TiposDocumentos.Features.Delete;

internal sealed class DeleteTipoDocumentoCommandHandler
    : IRequestHandler<DeleteTipoDocumentoCommand, BaseResponse<bool>>
{
    private readonly IBaseReadRepository<TipoDocumento, Guid> _tipoDocumentoReadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTipoDocumentoCommandHandler(
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
        DeleteTipoDocumentoCommand request,
        CancellationToken cancellationToken
    )
    {
        var spec = new TipoDocumentoFindByIdSpecification(request.Id);

        var tipoDocumentoDeleted = await _tipoDocumentoReadRepository.GetByWithSpec(spec);

        if (tipoDocumentoDeleted == null)
        {
            throw new TipoDocumentoNotFoundException();
        }

        if (tipoDocumentoDeleted.Activo)
        {
            throw new TipoDocumentoEnableException();
        }

        _unitOfWork.WriteRepository<TipoDocumento, Guid>().DeleteEntity(tipoDocumentoDeleted);

        var result = await _unitOfWork.Complete();

        if (result <= 0)
        {
            return new BaseResponse<bool>
            {
                IsSuccess = false,
                Message = "El registro no se eliminó correctamente"
            };
        }

        return new BaseResponse<bool>
        {
            IsSuccess = true,
            Message = "El registro se eliminó correctamente"
        };
    }
}
