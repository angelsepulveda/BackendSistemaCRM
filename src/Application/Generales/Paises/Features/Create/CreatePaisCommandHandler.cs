using Domain.Common.Bases;
using Domain.Common.UnitOfWork;
using Domain.Generales.Paises;

namespace Application.Generales.Paises.Features.Create;

public sealed class CreatePaisCommandHandler : IRequestHandler<CreatePaisCommand, BaseReponse<bool>>
{
    private readonly IBaseReadRepository<Pais, Guid> _paisReadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePaisCommandHandler(
        IBaseReadRepository<Pais, Guid> paisReadRepository,
        IUnitOfWork unitOfWork
    )
    {
        _paisReadRepository = paisReadRepository;
        _unitOfWork = unitOfWork;
    }

    public Task<BaseReponse<bool>> Handle(
        CreatePaisCommand request,
        CancellationToken cancellationToken
    )
    {
        throw new NotImplementedException();
    }
}
