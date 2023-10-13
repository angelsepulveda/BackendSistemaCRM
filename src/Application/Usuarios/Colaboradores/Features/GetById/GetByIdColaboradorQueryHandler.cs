using Application.Usuarios.Colaboradores.Responses;
using Application.Usuarios.Colaboradores.Specifications;
using Domain.Usuarios.Colaboradores;

namespace Application.Usuarios.Colaboradores.Features.GetById;

internal sealed class GetByIdColaboradorQueryHandler
    : IRequestHandler<GetByIdColaboradorQuery, BaseResponse<GetByIdColaboradorResponseDto>>
{
    private readonly IBaseReadRepository<Colaborador, Guid> _colaboradorReadRepository;

    public GetByIdColaboradorQueryHandler(
        IBaseReadRepository<Colaborador, Guid> colaboradorReadRepository
    )
    {
        _colaboradorReadRepository =
            colaboradorReadRepository
            ?? throw new ArgumentNullException(nameof(colaboradorReadRepository));
    }

    public async Task<BaseResponse<GetByIdColaboradorResponseDto>> Handle(
        GetByIdColaboradorQuery request,
        CancellationToken cancellationToken
    )
    {
        var spec = new ColaboradorFindByIdSpecification(request.Id);

        var colaborador = await _colaboradorReadRepository.GetByWithSpec(spec);

        if (colaborador == null)
            throw new ColaboradorNotFoundException();

        return new BaseResponse<GetByIdColaboradorResponseDto>()
        {
            IsSuccess = true,
            Data = new GetByIdColaboradorResponseDto(
                colaborador.Id,
                colaborador.Nombres,
                colaborador.Apellidos,
                colaborador.TipoDocumentoId,
                colaborador.NumDocumento,
                colaborador.FechaNacimiento,
                colaborador.Genero.ToString(),
                colaborador.EstadoCivil.ToString(),
                colaborador.EmailPersonal,
                colaborador.Telefono,
                colaborador.EmailAcceso,
                colaborador.Estado.ToString(),
                colaborador.Rol.ToString(),
                colaborador.Comuna.Region.PaisId,
                colaborador.Comuna.Region.Id,
                colaborador.ComunaId,
                colaborador.Direccion
            ),
            Message = "Consulta Exitosa!!"
        };
    }
}
