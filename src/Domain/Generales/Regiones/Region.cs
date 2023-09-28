using Domain.Generales.Paises;

namespace Domain.Generales.Regiones;

public class Region : BaseEntity<Guid>
{
	public string Nombre { get; private set; } = string.Empty;
	public Guid PaisId { get; private set; }
	public bool Activo { get; private set; }

	public virtual Pais Pais { get; set; }

	public Region()
	{

	}

	public Region(Guid id, string nombre, Guid paisId, bool activo)
	{
		Nombre = nombre;
		PaisId = paisId;
		Activo = activo;
	}

	public void ChangeActivo(bool value)
	{
		if (Activo != value)
			Activo = value;
	}
}