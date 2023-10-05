using Application.Generales.TiposDocumentos.Responses;

namespace Application.Generales.TiposDocumentos.Features.Select;

public record SelectTipoDocumentoQuery()
    : IRequest<BaseResponse<IReadOnlyList<SelectTipoDocumentoResponseDto>>>;
