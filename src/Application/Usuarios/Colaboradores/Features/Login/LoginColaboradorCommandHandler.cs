using Application.Usuarios.Colaboradores.Responses;
using Application.Usuarios.Colaboradores.Specifications;
using Domain.Usuarios.Colaboradores;
using Domain.Usuarios.Colaboradores.Exceptions;
using Domain.Usuarios.Colaboradores.Services;

namespace Application.Usuarios.Colaboradores.Features.Login;

internal sealed class LoginColaboradorCommandHandler :
   IRequestHandler<LoginColaboradorCommand, BaseResponse<LoginColaboradorResponseDto>>
{

  private readonly IBaseReadRepository<Colaborador, Guid> _colaboradorReadRepository;
  private readonly ITokenService _tokenService;

  public LoginColaboradorCommandHandler(
         IBaseReadRepository<Colaborador, Guid> colaboradorReadRepository,
         ITokenService tokenService
     )
  {
    _colaboradorReadRepository =
        colaboradorReadRepository
        ?? throw new ArgumentNullException(nameof(colaboradorReadRepository));

    _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
  }


  public async Task<BaseResponse<LoginColaboradorResponseDto>>
         Handle(LoginColaboradorCommand request, CancellationToken cancellationToken)
  {
    var spec = new ColaboradorFindByEmailSpecification(request.Email);

    var colaborador = await _colaboradorReadRepository.GetByWithSpec(spec);

    if (colaborador == null) throw new ColaboradorLoginException();

    var passwordValid = _tokenService.ComparePassword(colaborador.Password, request.Password);

    if (!passwordValid) throw new ColaboradorLoginException();

    return new BaseResponse<LoginColaboradorResponseDto>()
    {
      IsSuccess = true,
      Data = new LoginColaboradorResponseDto(
                 _tokenService.GenerateToken(colaborador),
                 new DataColaboradorResponseDto(
                  colaborador.Id,
                  $"{colaborador.Nombres} {colaborador.Apellidos}")
             ),
      Message = "Consulta Exitosa!!"
    };
  }
}