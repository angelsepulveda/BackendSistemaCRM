namespace Application.Generales.Comunas.Features.Update;

public class UpdateComunaCommandValidator : AbstractValidator<UpdateComunaCommand>
{
    public UpdateComunaCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotNull()
            .WithMessage("El campo de id no puede ser nulo")
            .NotEmpty()
            .WithMessage("El campo de id es obligatorio");

        RuleFor(p => p.Nombre)
            .NotEmpty()
            .WithMessage("El campo nombre no puede ser vació")
            .NotNull()
            .WithMessage("El campo nombre no puede ser nulo")
            .MaximumLength(100)
            .WithMessage("El campo nombre no puede superar los 100 caracteres");

        RuleFor(p => p.RegionId)
            .NotNull()
            .WithMessage("El campo de regionId no puede ser nulo")
            .NotEmpty()
            .WithMessage("El campo de regionId es obligatorio");
    }
}
