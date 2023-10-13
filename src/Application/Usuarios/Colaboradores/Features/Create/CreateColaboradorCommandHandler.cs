using Application.Usuarios.Colaboradores.Specifications;
using Domain.Common.Services;
using Domain.Usuarios.Colaboradores;
using Domain.Usuarios.Colaboradores.Exceptions;

namespace Application.Usuarios.Colaboradores.Features.Create;

internal sealed class CreateColaboradorCommandHandler
    : IRequestHandler<CreateColaboradorCommand, BaseResponse<bool>>
{
    private readonly IBaseReadRepository<Colaborador, Guid> _colaboradorReadRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHashPassword _hashPassword;

    public CreateColaboradorCommandHandler(
        IBaseReadRepository<Colaborador, Guid> colaboradorReadRepository,
        IUnitOfWork unitOfWork
    )
    {
        _colaboradorReadRepository =
            colaboradorReadRepository
            ?? throw new ArgumentNullException(nameof(colaboradorReadRepository));

        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<BaseResponse<bool>> Handle(
        CreateColaboradorCommand request,
        CancellationToken cancellationToken
    )
    {
        var spec = new ColaboradorFindByEmailAndNumDocumentoSpecification(
            request.EmailPersonal,
            request.TipoDocumentoId,
            request.NumDocumento,
            request.EmailAcceso
        );

        var colaboradorExists = await _colaboradorReadRepository.GetByWithSpec(spec);

        if (colaboradorExists != null)
            throw new ColaboradorAlreadyExistsException();
    }
}
