using Application.Generales.Comunas.Responses;
using Application.Generales.Comunas.Specifications;
using Domain.Generales.Comunas;
using Domain.Generales.Comunas.Exceptions;

namespace Application.Generales.Comunas.Features.GetById;

public sealed class GetByIdComunaQueryHandler
    : IRequestHandler<GetByIdComunaQuery, BaseResponse<GetByIdComunaResponseDto>>
{
    private readonly IBaseReadRepository<Comuna, Guid> _comunaReadRepository;

    public GetByIdComunaQueryHandler(IBaseReadRepository<Comuna, Guid> comunaReadRepository)
    {
        _comunaReadRepository =
            comunaReadRepository ?? throw new ArgumentNullException(nameof(comunaReadRepository));
    }

    public async Task<BaseResponse<GetByIdComunaResponseDto>> Handle(
        GetByIdComunaQuery request,
        CancellationToken cancellationToken
    )
    {
        var spec = new ComunaFindByIdEnableSpecification(request.Id);

        var comuna = await _comunaReadRepository.GetByWithSpec(spec);

        if (comuna == null)
        {
            throw new ComunaNotFoundException();
        }

        return new BaseResponse<GetByIdComunaResponseDto>()
        {
            IsSuccess = true,
            Data = new GetByIdComunaResponseDto(comuna.Id, comuna.Nombre, comuna.RegionId),
            Message = "Consulta exitosa!!"
        };
    }
}
