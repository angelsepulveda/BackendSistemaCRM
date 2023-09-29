namespace Domain.Generales.TiposDocumentos;

public class TipoDocumento : BaseEntity<int>
{
    public TipoDocumento(string nombre, string descripcion, bool activo)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        Activo = activo;
    }

    public TipoDocumento() { }

    public string Nombre { get; private set; } = string.Empty;
    public string Descripcion { get; private set; } = string.Empty;
    public bool Activo { get; private set; }

    public void ChangeActivo(bool value)
    {
        if (value != Activo)
            Activo = value;
    }

    public void Update(string nombre, string descripcion)
    {
        if (Nombre != nombre)
            Nombre = nombre;

        if (Descripcion != descripcion)
            Descripcion = descripcion;
    }
}
