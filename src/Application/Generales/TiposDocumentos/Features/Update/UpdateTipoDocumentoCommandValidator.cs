namespace Application.Generales.TiposDocumentos.Features.Update;

public class UpdateTipoDocumentoCommandValidator : AbstractValidator<UpdateTipoDocumentoCommand>
{
    public UpdateTipoDocumentoCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty()
            .WithMessage("El campo id es obligatorio")
            .NotNull()
            .WithMessage("El campo id es obligatorio");

        RuleFor(p => p.Nombre)
            .NotEmpty()
            .WithMessage("El campo nombre no puede ser vació")
            .NotNull()
            .WithMessage("El campo nombre no puede ser nulo")
            .MaximumLength(20)
            .WithMessage("El campo nombre no puede superar los 20 caracteres");

        RuleFor(p => p.Descripcion)
            .MaximumLength(1024)
            .WithMessage("El campo descripción no puede superar los 1024 caracteres");
    }
}
