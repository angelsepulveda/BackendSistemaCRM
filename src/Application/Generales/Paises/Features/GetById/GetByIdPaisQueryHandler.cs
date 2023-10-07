using Application.Generales.Paises.Responses;
using Application.Generales.Paises.Specifications;
using Domain.Generales.Paises;
using Domain.Generales.Paises.Exceptions;

namespace Application.Generales.Paises.Features.GetById;

internal sealed class GetByIdPaisQueryHandler
    : IRequestHandler<GetByIdPaisQuery, BaseResponse<GetByIdPaisResponseDto>>
{
    private readonly IBaseReadRepository<Pais, Guid> _paisReadRepository;

    public GetByIdPaisQueryHandler(IBaseReadRepository<Pais, Guid> paisReadRepository)
    {
        _paisReadRepository = paisReadRepository;
    }

    public async Task<BaseResponse<GetByIdPaisResponseDto>> Handle(
        GetByIdPaisQuery request,
        CancellationToken cancellationToken
    )
    {
        var spec = new PaisFindByIdEnableSpecification(request.Id);

        var pais = await _paisReadRepository.GetByWithSpec(spec);

        if (pais == null)
        {
            throw new PaisNotFoundException();
        }

        return new BaseResponse<GetByIdPaisResponseDto>()
        {
            IsSuccess = true,
            Data = new GetByIdPaisResponseDto(pais.Id, pais.Nombre, pais.Nacionalidad),
            Message = "Consulta exitosa!!"
        };
    }
}
