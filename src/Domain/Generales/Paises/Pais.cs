namespace Domain.Generales.Paises;

public class Pais : BaseEntity<Guid>
{
    public Pais(string nombre, string nacionalidad, bool activo)
    {
        Nombre = nombre;
        Nacionalidad = nacionalidad;
        Activo = activo;
    }

    public Pais() { }

    public string Nombre { get; private set; } = string.Empty;
    public string Nacionalidad { get; private set; } = string.Empty;
    public bool Activo { get; private set; }

    public void ChangeActivo(bool value)
    {
        if (Activo != value)
            Activo = value;
    }

    public void Update(string nombre, string nacionalidad)
    {
        if (Nombre != nombre)
            Nombre = nombre;

        if (Nacionalidad != nacionalidad)
            Nacionalidad = nacionalidad;
    }
}
