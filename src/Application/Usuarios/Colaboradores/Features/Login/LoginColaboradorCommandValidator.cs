namespace Application.Usuarios.Colaboradores.Features.Login;

public class LoginColaboradorCommandValidator : AbstractValidator<LoginColaboradorCommand>
{
  public LoginColaboradorCommandValidator()
  {
    RuleFor(p => p.Email)
           .NotEmpty()
           .WithMessage("El campo email acceso es obligatorio")
           .NotNull()
           .EmailAddress()
           .WithMessage("El campo email acceso no es un email válido");

    RuleFor(p => p.Password)
        .NotEmpty()
        .WithMessage("El campo contraseña es obligatorio")
        .NotNull()
        .WithMessage("El campo contraseña es obligatorio")
        .MinimumLength(6)
        .WithMessage("El campo contraseña debe tener al menos 6 caracteres");

  }
}