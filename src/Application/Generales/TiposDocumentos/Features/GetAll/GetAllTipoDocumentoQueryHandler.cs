using Application.Generales.TiposDocumentos.Responses;
using Domain.Generales.TiposDocumentos;

namespace Application.Generales.TiposDocumentos.Features.GetAll;

internal sealed class GetAllTipoDocumentoQueryHandler
    : IRequestHandler<
        GetAllTipoDocumentoQuery,
        BaseResponse<IReadOnlyList<GetAllTipoDocumentoResponseDto>>
    >
{
    private readonly IBaseReadRepository<TipoDocumento, Guid> _tipoDocumentoReadRepository;

    public GetAllTipoDocumentoQueryHandler(
        IBaseReadRepository<TipoDocumento, Guid> tipoDocumentoReadRepository
    )
    {
        _tipoDocumentoReadRepository =
            tipoDocumentoReadRepository
            ?? throw new ArgumentNullException(nameof(tipoDocumentoReadRepository));
    }

    public async Task<BaseResponse<IReadOnlyList<GetAllTipoDocumentoResponseDto>>> Handle(
        GetAllTipoDocumentoQuery request,
        CancellationToken cancellationToken
    )
    {
        var tiposDocumentos = await _tipoDocumentoReadRepository.GetAllAsync();

        return new BaseResponse<IReadOnlyList<GetAllTipoDocumentoResponseDto>>()
        {
            IsSuccess = true,
            Data = tiposDocumentos
                .Select(
                    p =>
                        new GetAllTipoDocumentoResponseDto(
                            p.Id,
                            p.Nombre,
                            p.Descripcion,
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
