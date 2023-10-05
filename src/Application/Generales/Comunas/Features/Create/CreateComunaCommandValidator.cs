namespace Application.Generales.Comunas.Features.Create;

public class CreateComunaCommandValidator : AbstractValidator<CreateComunaCommand>
{
    public CreateComunaCommandValidator()
    {
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
