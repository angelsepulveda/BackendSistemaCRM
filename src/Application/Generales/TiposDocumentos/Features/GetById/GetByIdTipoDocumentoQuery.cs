using Application.Generales.TiposDocumentos.Responses;

namespace Application.Generales.TiposDocumentos.Features.GetById;

public record GetByIdTipoDocumentoQuery(Guid Id)
    : IRequest<BaseResponse<GetByIdTipoDocumentoResponseDto>>;
