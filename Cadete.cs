using System;
using Modelos;
namespace Modelos;

public class Cadete
{
    public long Id { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }

    public Cadete(){}
    
    public Cadete(string _Nombre, string _Direccion, string _Telefono, long? _Id = null)
    {
        Id = _Id ?? DateTime.Now.Ticks; // Usa el ID proporcionado o genera uno nuevo
        Nombre = _Nombre;
        Direccion = _Direccion ?? throw new ArgumentNullException(nameof(_Direccion));
        Telefono = _Telefono;
    }
}
