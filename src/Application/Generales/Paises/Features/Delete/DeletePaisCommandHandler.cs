using Application.Generales.Paises.Specifications;
using Domain.Generales.Paises;
using Domain.Generales.Paises.Exceptions;

namespace Application.Generales.Paises.Features.Delete;

internal sealed class DeletePaisCommandHandler
    : IRequestHandler<DeletePaisCommand, BaseResponse<bool>>
{
    private readonly IBaseReadRepository<Pais, Guid> _paisReadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePaisCommandHandler(
        IBaseReadRepository<Pais, Guid> paisReadRepository,
        IUnitOfWork unitOfWork
    )
    {
        _paisReadRepository = paisReadRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<bool>> Handle(
        DeletePaisCommand request,
        CancellationToken cancellationToken
    )
    {
        var spec = new PaisFindByIdSpecification(request.Id);

        var paisDeleted = await _paisReadRepository.GetByWithSpec(spec);

        if (paisDeleted == null)
        {
            throw new PaisNotFoundException();
        }

        if (paisDeleted.Activo)
        {
            throw new PaisEnableException();
        }

        _unitOfWork.WriteRepository<Pais, Guid>().DeleteEntity(paisDeleted);

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
