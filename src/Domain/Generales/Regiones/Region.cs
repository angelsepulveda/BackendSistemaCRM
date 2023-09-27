namespace Domain.Generales.Regiones;

public class Region : BaseEntity<Guid>
{
		public string Nombre { get; private set; }  = string.Empty;
		public bool Activo { get; private set; }

		public Region()
		{

		}

		public Region(Guid id, string nombre, bool activo)
		{
				Nombre = nombre;
				Activo = activo;
		}

		public void ChangeActivo(bool value)
		{
				if(Activo != value)
						Activo = value;
		}
}