using Domain.Generales.Regiones;

namespace Domain.Generales.Comunas;

public class Comuna : BaseEntity<Guid>
{
    public Comuna(Guid id, string nombre, Guid regionId, bool activo)
    {
        Id = id;
        Nombre = nombre;
        RegionId = regionId;
        Activo = activo;
    }

    public Comuna() { }

    public string Nombre { get; private set; } = string.Empty;
    public Guid RegionId { get; private set; }
    public bool Activo { get; private set; }

    public virtual Region Region { get; set; }

    public void ChangeActivo(bool value)
    {
        if (Activo != value)
            Activo = value;
    }

    public void Update(string nombre, Guid regionId)
    {
        if (Nombre != nombre)
            Nombre = nombre;

        if (RegionId != regionId)
            RegionId = regionId;
    }
}
