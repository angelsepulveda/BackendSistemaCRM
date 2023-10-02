namespace Application.Generales.Regiones.Features.Update;

public class UpdateRegionCommandValidator : AbstractValidator<UpdateRegionCommand>
{
  public UpdateRegionCommandValidator()
  {
    RuleFor(p => p.Id)
       .NotNull().WithMessage("El campo de id no puede ser nulo")
       .NotEmpty().WithMessage("El campo de id es obligatorio");

    RuleFor(p => p.Nombre)
     .NotEmpty().WithMessage("El campo nombre no puede ser vació")
     .NotNull().WithMessage("El campo nombre no puede ser nulo")
     .MaximumLength(100).WithMessage("El campo nombre no puede superar los 100 caracteres");

    RuleFor(p => p.PaisId)
          .NotNull().WithMessage("El campo de paisId no puede ser nulo")
          .NotEmpty().WithMessage("El campo de paisId es obligatorio");
  }
}