using Application.Generales.TiposDocumentos.Specifications;
using Domain.Generales.TiposDocumentos;
using Domain.Generales.TiposDocumentos.Exceptions;

namespace Application.Generales.TiposDocumentos.Features.Deactivate;

internal sealed class DeactivateTipoDocumentoCommandHandler
    : IRequestHandler<DeactivateTipoDocumentoCommand, BaseResponse<bool>>
{
    private readonly IBaseReadRepository<TipoDocumento, Guid> _tipoDocumentoReadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeactivateTipoDocumentoCommandHandler(
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
        DeactivateTipoDocumentoCommand request,
        CancellationToken cancellationToken
    )
    {
        var spec = new TipoDocumentoFindByIdEnableSpecification(request.Id);

        var tipoDocumentoUpdated = await _tipoDocumentoReadRepository.GetByWithSpec(spec);

        if (tipoDocumentoUpdated == null)
        {
            throw new TipoDocumentoNotFoundException();
        }

        tipoDocumentoUpdated.ChangeActivo(false);

        _unitOfWork.WriteRepository<TipoDocumento, Guid>().UpdateEntity(tipoDocumentoUpdated);

        var result = await _unitOfWork.Complete();

        if (result <= 0)
        {
            return new BaseResponse<bool>
            {
                IsSuccess = false,
                Message = "El registro no se desactivó correctamente"
            };
        }

        return new BaseResponse<bool>
        {
            IsSuccess = true,
            Message = "El registro se desactivó correctamente"
        };
    }
}
