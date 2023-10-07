using Application.Generales.TiposDocumentos.Responses;
using Application.Generales.TiposDocumentos.Specifications;
using Domain.Generales.TiposDocumentos;
using Domain.Generales.TiposDocumentos.Exceptions;

namespace Application.Generales.TiposDocumentos.Features.GetById;

internal sealed class GetByIdTipoDocumentoQueryHandler
    : IRequestHandler<GetByIdTipoDocumentoQuery, BaseResponse<GetByIdTipoDocumentoResponseDto>>
{
    private readonly IBaseReadRepository<TipoDocumento, Guid> _tipoDocumentoReadRepository;

    public GetByIdTipoDocumentoQueryHandler(
        IBaseReadRepository<TipoDocumento, Guid> tipoDocumentoReadRepository
    )
    {
        _tipoDocumentoReadRepository = tipoDocumentoReadRepository;
    }

    public async Task<BaseResponse<GetByIdTipoDocumentoResponseDto>> Handle(
        GetByIdTipoDocumentoQuery request,
        CancellationToken cancellationToken
    )
    {
        var spec = new TipoDocumentoFindByIdEnableSpecification(request.Id);

        var tipoDocumento = await _tipoDocumentoReadRepository.GetByWithSpec(spec);

        if (tipoDocumento == null)
        {
            throw new TipoDocumentoNotFoundException();
        }

        return new BaseResponse<GetByIdTipoDocumentoResponseDto>()
        {
            IsSuccess = true,
            Data = new GetByIdTipoDocumentoResponseDto(
                tipoDocumento.Id,
                tipoDocumento.Nombre,
                tipoDocumento.Descripcion
            ),
            Message = "Consulta exitosa!!"
        };
    }
}
