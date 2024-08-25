using Modelos;
namespace Modelos;

public class Cadeteria
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public List<Cadete> Cadetes { get; set; }

    public Cadeteria(string _Nombre, string _Telefono, List<Cadete> _cadetes)
    {
        Nombre = _Nombre;
        Telefono = _Telefono;
        Cadetes = _cadetes;
    }
    public void AltaCadete() // Agg cadete al csv
    {
        
    }
    public void BajaCadete() // Del cadete al csv
    {

    }
    public void ModificarCadete() // Mod cadete al csv
    {

    }
}