namespace Application.Usuarios.Colaboradores.Features.Create;

public class CreateColaboradorCommandValidator : AbstractValidator<CreateColaboradorCommand>
{
    public CreateColaboradorCommandValidator()
    {
        RuleFor(p => p.Nombres)
            .NotEmpty()
            .WithMessage("El campo nombres no puede ser vació")
            .NotNull()
            .WithMessage("El campo nombres no puede ser nulo")
            .MaximumLength(150)
            .WithMessage("El campo nombres no puede superar los 150 caracteres");

        RuleFor(p => p.Apellidos)
            .NotEmpty()
            .WithMessage("El campo apellidos no puede ser vació")
            .NotNull()
            .WithMessage("El campo apellidos no puede ser nulo")
            .MaximumLength(150)
            .WithMessage("El campo apellidos no puede superar los 150 caracteres");

        RuleFor(p => p.TipoDocumentoId)
            .NotEmpty()
            .WithMessage("El campo tipo de documento no puede ser vació")
            .NotNull()
            .WithMessage("El campo tipo de documento no puede ser nulo");

        RuleFor(p => p.NumDocumento)
            .NotEmpty()
            .WithMessage("El campo numero de documento no puede ser vació")
            .NotNull()
            .WithMessage("El campo numero de documento no puede ser nulo")
            .MaximumLength(50)
            .WithMessage("El campo numero de documento no puede superar los 50 caracteres");

        RuleFor(p => p.Estado)
            .NotEmpty()
            .WithMessage("El campo estado no puede ser vació")
            .NotNull()
            .WithMessage("El campo estado no puede ser nulo");

        RuleFor(p => p.EstadoCivil)
            .NotEmpty()
            .WithMessage("El campo estado civil no puede ser vació")
            .NotNull()
            .WithMessage("El campo estado civil no puede ser nulo");

        RuleFor(p => p.Genero)
            .NotEmpty()
            .WithMessage("El campo género no puede ser vació")
            .NotNull()
            .WithMessage("El campo género no puede ser nulo");

        RuleFor(p => p.FechaNacimiento)
            .NotEmpty()
            .WithMessage("El campo fecha de nacimiento es obligatorio")
            .NotNull()
            .WithMessage("El campo fecha de nacimiento no puede ser nulo");

        RuleFor(p => p.EmailPersonal)
            .NotEmpty()
            .WithMessage("El campo email personal es obligatorio")
            .NotNull()
            .EmailAddress()
            .WithMessage("El campo email personal no es un email válido");

        RuleFor(p => p.EmailAcceso)
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

        RuleFor(p => p.ConfirmPassword)
            .NotEmpty()
            .WithMessage("El campo confirmación de contraseña es obligatorio")
            .NotNull()
            .WithMessage("El campo confirmación de contraseña es obligatorio")
            .Equal(p => p.Password)
            .WithMessage("El campo confirmación de contraseña no coincide con el campo contraseña");

        RuleFor(p => p.ComunaId)
            .NotEmpty()
            .WithMessage("El campo comuna no puede ser vació")
            .NotNull()
            .WithMessage("El campo comuna no puede ser nulo");

        RuleFor(p => p.Direccion)
            .NotEmpty()
            .WithMessage("El campo dirección no puede ser vació")
            .NotNull()
            .WithMessage("El campo dirección no puede ser nulo")
            .Length(256)
            .WithMessage("El campo dirección no puede superar los 256 caracteres");

        RuleFor(p => p.Telefono)
            .NotEmpty()
            .WithMessage("El campo teléfono no puede ser vació")
            .NotNull()
            .WithMessage("El campo teléfono no puede ser nulo")
            .Length(256)
            .WithMessage("El campo teléfono no puede superar los 256 caracteres");
    }
}
