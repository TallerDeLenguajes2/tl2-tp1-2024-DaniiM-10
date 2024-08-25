namespace Modelos;
public class ManejadorCSV
{
    public List<Cadete> LeerCadetesCSV(string rutaArchivoCadete)
    {
        var lineas = File.ReadAllLines(rutaArchivoCadete);

        // Convierto cada línea del CSV en un objeto Cadete usando LINQ
        List<Cadete> cadetes = lineas.Select(linea =>
        {
            var datos = linea.Split(',');
            long id = long.Parse(datos[0]);

            return new Cadete(id, datos[1], datos[2], datos[3]);
        }).ToList();

        return cadetes;
    }
    public Cadeteria LeerCadeteriaCSV(string rutaArchivoCadeteria)
    {
        var linea = File.ReadAllText(rutaArchivoCadeteria);
        var datos = linea.Split(',');

        string rutaArchivoCadete = "";

        Cadeteria cadeteria = new Cadeteria(datos[0], datos[1], LeerCadetesCSV(rutaArchivoCadete));

        return cadeteria;
    }
    public bool EscribirLineaCSV(string rutaArchivo, string[] fila)
    {
        bool salida = false;
        using (StreamWriter escritor = new StreamWriter(rutaArchivo, true)) // "true" para agregar línea en lugar de sobrescribir
        {
            escritor.WriteLine(String.Join(',', fila));
            salida = true;
        }
        return salida;
    }
    public bool BorrarLineaCSV(string rutaArchivo, long id)
    {
        var lineas = File.ReadAllLines(rutaArchivo).ToList();
        var lineasActualizadas = new List<string>();

        bool salida = false;

        foreach (var linea in lineas)
        {
            var datos = linea.Split(',');

            if (datos.Length > 0 && long.TryParse(datos[0], out long idLinea))
            {
                if (idLinea != id)
                {
                    lineasActualizadas.Add(linea);
                } else {
                    salida = false;
                }
            }
        }
        File.WriteAllLines(rutaArchivo, lineasActualizadas);

        return salida;
    }
    public bool ModificarLineaCSV(string rutaArchivo, long id, string[] nuevaFila)
    {
        var lineas = File.ReadAllLines(rutaArchivo).ToList();
        bool lineaModificada = false;

        for (int i = 0; i < lineas.Count; i++)
        {
            var datos = lineas[i].Split(',');

            if (datos.Length > 0 && long.TryParse(datos[0], out long idLinea) && idLinea == id)
            {
                lineas[i] = string.Join(",", nuevaFila);
                lineaModificada = true;
                break;
            }
        }

        if (lineaModificada)
        {
            File.WriteAllLines(rutaArchivo, lineas);
        }

        return lineaModificada;
    }
}
