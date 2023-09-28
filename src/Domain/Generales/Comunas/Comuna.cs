using Domain.Generales.Regiones;

namespace Domain.Generales.Comunas;

public class Comuna : BaseEntity<Guid>
{
  public Comuna(string nombre, int regionId, bool activo)
  {
    Nombre = nombre;
    RegionId = regionId;
    Activo = activo;
  }


  public Comuna()
  {

  }
  public string Nombre { get; private set; } = string.Empty;
  public int RegionId { get; private set; }
  public bool Activo { get; private set; }

  public virtual Region Region { get; set; }

  public void ChangeActivo(bool value)
  {
    if (Activo != value)
      Activo = value;
  }
}