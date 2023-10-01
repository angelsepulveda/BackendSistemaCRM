namespace Application.Generales.Paises.Features.Create;

public class CreatePaisCommandValidator : AbstractValidator<CreatePaisCommand>
{
  public CreatePaisCommandValidator()
  {

    RuleFor(p => p.Nombre)
            .NotEmpty().WithMessage("El campo nombre no puede ser vació")
            .NotNull().WithMessage("El campo nombre no puede ser nulo")
            .MaximumLength(100).WithMessage("El campo nombre no puede superar los 100 caracteres");

    RuleFor(p => p.Nacionalidad)
            .NotEmpty().WithMessage("El campo nacionalidad no puede ser vació")
            .NotNull().WithMessage("El campo nacionalidad no puede ser nulo")
            .MaximumLength(100).WithMessage("El campo nacionalidad no puede superar los 100 caracteres");
  }
}