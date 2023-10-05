using Application.Generales.TiposDocumentos.Responses;

namespace Application.Generales.TiposDocumentos.Features.GetAll;

public record GetAllTipoDocumentoQuery()
    : IRequest<BaseResponse<IReadOnlyList<GetAllTipoDocumentoResponseDto>>>;
