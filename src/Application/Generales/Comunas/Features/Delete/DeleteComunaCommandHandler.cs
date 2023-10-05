using Application.Generales.Comunas.Specifications;
using Domain.Generales.Comunas;
using Domain.Generales.Comunas.Exceptions;

namespace Application.Generales.Comunas.Features.Delete;

public sealed class DeleteComunaCommandHandler
    : IRequestHandler<DeleteComunaCommand, BaseResponse<bool>>
{
    private readonly IBaseReadRepository<Comuna, Guid> _comunaReadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteComunaCommandHandler(
        IBaseReadRepository<Comuna, Guid> comunaReadRepository,
        IUnitOfWork unitOfWork
    )
    {
        _comunaReadRepository =
            comunaReadRepository ?? throw new ArgumentNullException(nameof(comunaReadRepository));

        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<BaseResponse<bool>> Handle(
        DeleteComunaCommand request,
        CancellationToken cancellationToken
    )
    {
        var spec = new ComunaFindByIdSpecification(request.Id);

        var comunaDeleted = await _comunaReadRepository.GetByWithSpec(spec);

        if (comunaDeleted == null)
        {
            throw new ComunaNotFoundException();
        }

        if (comunaDeleted.Activo)
        {
            throw new ComunaEnableException();
        }

        _unitOfWork.WriteRepository<Comuna, Guid>().DeleteEntity(comunaDeleted);

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
