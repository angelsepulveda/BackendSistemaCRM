using Application.Usuarios.Colaboradores.Responses;
using Application.Usuarios.Colaboradores.Specifications;
using Domain.Usuarios.Colaboradores;

namespace Application.Usuarios.Colaboradores.Features.GetAll;

internal sealed class GetAllColaboradorQueryHandler
    : IRequestHandler<
        GetAllColaboradorQuery,
        BaseResponse<IReadOnlyList<GetAllColaboradorResponseDto>>
    >
{
    private readonly IBaseReadRepository<Colaborador, Guid> _colaboradorReadRepository;

    public GetAllColaboradorQueryHandler(
        IBaseReadRepository<Colaborador, Guid> colaboradorReadRepository
    )
    {
        _colaboradorReadRepository =
            colaboradorReadRepository
            ?? throw new ArgumentNullException(nameof(colaboradorReadRepository));
    }

    public async Task<BaseResponse<IReadOnlyList<GetAllColaboradorResponseDto>>> Handle(
        GetAllColaboradorQuery request,
        CancellationToken cancellationToken
    )
    {
        var spec = new ColaboradoresGetAllSpecification();

        var colaboradores = await _colaboradorReadRepository.GetAllWithSpec(spec);

        return new BaseResponse<IReadOnlyList<GetAllColaboradorResponseDto>>()
        {
            IsSuccess = true,
            Data = colaboradores
                .Select(
                    p =>
                        new GetAllColaboradorResponseDto(
                            p.Id,
                            $"{p.Nombres} {p.Apellidos}",
                            p.EmailAcceso,
                            p.Estado.ToString(),
                            p.TipoDocumento.Nombre,
                            p.NumDocumento,
                            $"{p.Direccion} {p.Comuna.Nombre} {p.Comuna.Region.Nombre} {p.Comuna.Region.Pais.Nombre}",
                            p.CreatedAt ?? DateTime.Now
                        )
                )
                .ToList()
                .AsReadOnly(),
            Message = "Consulta Exitosa!!"
        };
    }
}
