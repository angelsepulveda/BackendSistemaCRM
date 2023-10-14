namespace Application.Usuarios.Colaboradores.Features.ChangeEstado;

public class ChangeEstadoColaboradorCommandValidator : AbstractValidator<ChangeEstadoColaboradorCommand>
{
  public ChangeEstadoColaboradorCommandValidator()
  {
    RuleFor(p => p.Id)
       .NotNull().WithMessage("El campo de id no puede ser nulo")
       .NotEmpty().WithMessage("El campo de id es obligatorio");

    RuleFor(p => p.Estado)
      .NotEmpty()
      .WithMessage("El campo estado no puede ser vació")
      .NotNull()
      .WithMessage("El campo estado no puede ser nulo");
  }
}