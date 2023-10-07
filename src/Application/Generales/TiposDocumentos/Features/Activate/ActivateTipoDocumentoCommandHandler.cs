using Application.Generales.TiposDocumentos.Specifications;
using Domain.Generales.TiposDocumentos;
using Domain.Generales.TiposDocumentos.Exceptions;

namespace Application.Generales.TiposDocumentos.Features.Activate;

internal sealed class ActivateTipoDocumentoCommandHandler
    : IRequestHandler<ActivateTipoDocumentoCommand, BaseResponse<bool>>
{
    private readonly IBaseReadRepository<TipoDocumento, Guid> _tipoDocumentoReadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ActivateTipoDocumentoCommandHandler(
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
        ActivateTipoDocumentoCommand request,
        CancellationToken cancellationToken
    )
    {
        var spec = new TipoDocumentoFindByIdSpecification(request.Id);

        var tipoDocumentoUpdated = await _tipoDocumentoReadRepository.GetByWithSpec(spec);

        if (tipoDocumentoUpdated == null)
        {
            throw new TipoDocumentoNotFoundException();
        }

        if (tipoDocumentoUpdated.Activo)
        {
            throw new TipoDocumentoEnableException();
        }

        tipoDocumentoUpdated.ChangeActivo(true);

        _unitOfWork.WriteRepository<TipoDocumento, Guid>().UpdateEntity(tipoDocumentoUpdated);

        var result = await _unitOfWork.Complete();

        if (result <= 0)
        {
            return new BaseResponse<bool>
            {
                IsSuccess = false,
                Message = "El registro no se activó correctamente"
            };
        }

        return new BaseResponse<bool>
        {
            IsSuccess = true,
            Message = "El registro se activó correctamente"
        };
    }
}
