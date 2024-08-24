using Modelos;
namespace Modelos;

public class Cadeteria
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public List<Cadete> Cadetes { get; set; }

    public Cadeteria(string _Nombre, string _Telefono)
    {
        Nombre = _Nombre;
        Telefono = _Telefono;
        Cadetes = new List<Cadete>();
    }
}