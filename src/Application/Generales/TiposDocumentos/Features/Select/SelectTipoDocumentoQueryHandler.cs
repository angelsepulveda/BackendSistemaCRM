using Application.Generales.TiposDocumentos.Responses;
using Application.Generales.TiposDocumentos.Specifications;
using Domain.Generales.TiposDocumentos;

namespace Application.Generales.TiposDocumentos.Features.Select;

internal sealed class SelectTipoDocumentoQueryHandler
    : IRequestHandler<
        SelectTipoDocumentoQuery,
        BaseResponse<IReadOnlyList<SelectTipoDocumentoResponseDto>>
    >
{
    private readonly IBaseReadRepository<TipoDocumento, Guid> _tipoDocumentoReadRepository;

    public SelectTipoDocumentoQueryHandler(
        IBaseReadRepository<TipoDocumento, Guid> tipoDocumentoReadRepository
    )
    {
        _tipoDocumentoReadRepository =
            tipoDocumentoReadRepository
            ?? throw new ArgumentNullException(nameof(tipoDocumentoReadRepository));
    }

    public async Task<BaseResponse<IReadOnlyList<SelectTipoDocumentoResponseDto>>> Handle(
        SelectTipoDocumentoQuery request,
        CancellationToken cancellationToken
    )
    {
        var spec = new TiposDocumentosEnableSpecification();

        var tiposDocumentos = await _tipoDocumentoReadRepository.GetAllWithSpec(spec);

        return new BaseResponse<IReadOnlyList<SelectTipoDocumentoResponseDto>>()
        {
            IsSuccess = true,
            Data = tiposDocumentos
                .Select(p => new SelectTipoDocumentoResponseDto(p.Id, p.Nombre))
                .ToList()
                .AsReadOnly(),
            Message = "Consulta Exitosa!!"
        };
    }
}
