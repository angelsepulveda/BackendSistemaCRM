using Application.Generales.Comunas.Specifications;
using Domain.Generales.Comunas;
using Domain.Generales.Comunas.Exceptions;

namespace Application.Generales.Comunas.Features.Activate;

public sealed class ActivateComunaCommandHandler
    : IRequestHandler<ActivateComunaCommand, BaseResponse<bool>>
{
    private readonly IBaseReadRepository<Comuna, Guid> _comunaReadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ActivateComunaCommandHandler(
        IBaseReadRepository<Comuna, Guid> comunaReadRepository,
        IUnitOfWork unitOfWork
    )
    {
        _comunaReadRepository =
            comunaReadRepository ?? throw new ArgumentNullException(nameof(comunaReadRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<BaseResponse<bool>> Handle(
        ActivateComunaCommand request,
        CancellationToken cancellationToken
    )
    {
        var spec = new ComunaFindByIdSpecification(request.Id);

        var comunaUpdated = await _comunaReadRepository.GetByWithSpec(spec);

        if (comunaUpdated == null)
        {
            throw new ComunaNotFoundException();
        }

        if (comunaUpdated.Activo)
        {
            throw new ComunaEnableException();
        }

        comunaUpdated.ChangeActivo(true);

        _unitOfWork.WriteRepository<Comuna, Guid>().UpdateEntity(comunaUpdated);

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
