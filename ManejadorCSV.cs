namespace Modelos;
public class ManejadorCSV : AccesoADatos
{
    public List<Cadete> LeerCadetesCSV()
    {
        var lineas = File.ReadAllLines(rutaArchivoCadeteCSV);

        // Convierto cada línea del CSV en un objeto Cadete usando LINQ
        List<Cadete> cadetes = new List<Cadete>();

        // recorro cada linea de lineas
        foreach (var linea in lineas)
        {
            string[] datos = linea.Split(',');
            cadetes.Add(new Cadete(datos[1], datos[2], datos[3], long.Parse(datos[0])));
        }

        return cadetes;
    }
    public Cadeteria LeerCadeteriaCSV()
    {
        var linea = File.ReadAllText(rutaArchivoCadeteriaCSV);
        var datos = linea.Split(',');

        List<Cadete> cadetes = LeerCadetesCSV();

        Cadeteria cadeteria = new Cadeteria(datos[0], datos[1], cadetes);

        return cadeteria;
    }
}
