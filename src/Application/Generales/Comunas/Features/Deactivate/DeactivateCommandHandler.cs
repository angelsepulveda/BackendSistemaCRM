using Application.Generales.Comunas.Specifications;
using Domain.Generales.Comunas;
using Domain.Generales.Comunas.Exceptions;

namespace Application.Generales.Comunas.Features.Deactivate;

public sealed class DeactivateComunaCommandHandler
    : IRequestHandler<DeactivateComunaCommand, BaseResponse<bool>>
{
    private readonly IBaseReadRepository<Comuna, Guid> _comunaReadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeactivateComunaCommandHandler(
        IBaseReadRepository<Comuna, Guid> comunaReadRepository,
        IUnitOfWork unitOfWork
    )
    {
        _comunaReadRepository =
            comunaReadRepository ?? throw new ArgumentNullException(nameof(comunaReadRepository));

        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<BaseResponse<bool>> Handle(
        DeactivateComunaCommand request,
        CancellationToken cancellationToken
    )
    {
        var spec = new ComunaFindByIdEnableSpecification(request.Id);

        var comunaUpdated = await _comunaReadRepository.GetByWithSpec(spec);

        if (comunaUpdated == null)
        {
            throw new ComunaNotFoundException();
        }

        comunaUpdated.ChangeActivo(false);

        _unitOfWork.WriteRepository<Comuna, Guid>().UpdateEntity(comunaUpdated);

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
