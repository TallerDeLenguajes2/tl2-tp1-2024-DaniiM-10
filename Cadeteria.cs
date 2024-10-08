namespace Modelos;

public class Cadeteria
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public List<Cadete> Cadetes { get; set; }

    public Cadeteria(string _Nombre, string _Telefono, List<Cadete> _Cadetes)
    {
        Nombre = _Nombre;
        Telefono = _Telefono;
        Cadetes = _Cadetes;
    }
    public void AltaCadete(string rutaArchivoCadete, string[] cadete)
    {        
        ManejadorCSV manejador = new ManejadorCSV();
        bool verif = manejador.EscribirLineaCSV(rutaArchivoCadete, cadete);

        if(verif)
        {
            Console.WriteLine($"Se agrego el nuevo cadete '{cadete[0]}': '{cadete[1]}'.");
            Cadetes.Add(new Cadete(_Nombre:cadete[0], _Direccion:cadete[1], _Telefono:cadete[2]));
        } else {
            Console.WriteLine("No se pudo agregar un nuevo cadete.");
        }
    }
    public void BajaCadete(string rutaArchivoCadete, long id) 
    {
        ManejadorCSV manejador = new ManejadorCSV();
        bool verif = manejador.BorrarLineaCSV(rutaArchivoCadete, id);

        if(verif)
        {
            Console.WriteLine($"Se borró el cadete '{id}'.");
            Cadetes.Remove(Cadetes.Find(cadete => cadete.Id == id));
        } else {
            Console.WriteLine("No se pudo borrar el cadete.");
        }
    }
    public void ModificarCadete(string rutaArchivoCadete, long id, string[] datos)
    {
        ManejadorCSV manejador = new ManejadorCSV();
        bool verif = manejador.ModificarLineaCSV(rutaArchivoCadete, id, datos);

        if(verif)
        {
            Console.WriteLine($"Se actualizó el cadete '{id}'.");
            Cadetes.Remove(Cadetes.Find(cadete => cadete.Id == id));
            Cadetes.Add(new Cadete(_Nombre:datos[0], _Direccion:datos[1], _Telefono:datos[2]));
        } else {
            Console.WriteLine("No se pudo modificar el cadete.");
        }
    }
}