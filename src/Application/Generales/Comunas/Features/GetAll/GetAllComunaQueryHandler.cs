using Application.Generales.Comunas.Responses;
using Application.Generales.Comunas.Specifications;
using Domain.Generales.Comunas;

namespace Application.Generales.Comunas.Features.GetAll;

public sealed class GetAllComunaQueryHandler
    : IRequestHandler<GetAllComunaQuery, BaseResponse<IReadOnlyList<GetAllComunaResponseDto>>>
{
    private readonly IBaseReadRepository<Comuna, Guid> _comunaReadRepository;

    public GetAllComunaQueryHandler(IBaseReadRepository<Comuna, Guid> comunaReadRepository)
    {
        _comunaReadRepository =
            comunaReadRepository ?? throw new ArgumentNullException(nameof(comunaReadRepository));
    }

    public async Task<BaseResponse<IReadOnlyList<GetAllComunaResponseDto>>> Handle(
        GetAllComunaQuery request,
        CancellationToken cancellationToken
    )
    {
        var spec = new ComunasWithRelationsSpecification();

        var comunas = await _comunaReadRepository.GetAllWithSpec(spec);

        return new BaseResponse<IReadOnlyList<GetAllComunaResponseDto>>()
        {
            IsSuccess = true,
            Data = comunas
                .Select(
                    p =>
                        new GetAllComunaResponseDto(
                            p.Id,
                            p.Nombre,
                            p.Region.Nombre,
                            p.Activo,
                            p.CreatedAt ?? DateTime.Now
                        )
                )
                .ToList()
                .AsReadOnly(),
            Message = "Consulta Exitosa!!"
        };
    }
}
