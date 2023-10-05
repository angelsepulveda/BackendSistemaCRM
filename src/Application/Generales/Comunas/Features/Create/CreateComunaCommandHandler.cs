using Domain.Generales.Comunas;

namespace Application.Generales.Comunas.Features.Create;

public sealed class CreateComunaCommandHandler
    : IRequestHandler<CreateComunaCommand, BaseResponse<bool>>
{
    private readonly IBaseReadRepository<Comuna, Guid> _comunaReadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateComunaCommandHandler(
        IBaseReadRepository<Comuna, Guid> comunaReadRepository,
        IUnitOfWork unitOfWork
    )
    {
        _comunaReadRepository =
            comunaReadRepository ?? throw new ArgumentNullException(nameof(comunaReadRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<BaseResponse<bool>> Handle(
        CreateComunaCommand request,
        CancellationToken cancellationToken
    )
    {
        var comuna = new Comuna(Guid.NewGuid(), request.Nombre, request.RegionId, true);

        _unitOfWork.WriteRepository<Comuna, Guid>().AddEntity(comuna);

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
