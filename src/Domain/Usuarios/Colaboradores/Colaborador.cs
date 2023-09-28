using Domain.Generales.Comunas;

namespace Domain.Usuarios.Colaboradores;

public class Colaborador : BaseEntity<Guid>
{
  public string Nombres { get; private set; } = string.Empty;
  public string Apellidos { get; private set; } = string.Empty;
  public DateTime FechaNacimiento { get; private set; }
  public ColaboradorGenero Genero { get; private set; }
  public ColaboradorEstadoCivil EstadoCivil { get; private set; }
  public string EmailPersonal { get; private set; } = string.Empty;
  public string PhoneNumber { get; set; } = string.Empty;
  public string EmailAcceso { get; private set; } = string.Empty;
  public string Password { get; private set; } = string.Empty;
  public ColaboradorEstado Estado { get; private set; }
  public Guid ComunaId { get; private set; }
  public string Direccion { get; private set; } = string.Empty;

  public virtual Comuna Comuna { get; set; }

}