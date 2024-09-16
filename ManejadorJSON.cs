using System;
using System.IO;
using System.Text.Json; // Asegúrate de usar System.Text.Json
using System.Collections.Generic;

namespace Modelos;
public class ManejadorJSON : AccesoADatos
{
    public List<Cadete> LeerCadetesJSON()
    {
        try
        {
            string jsonData = File.ReadAllText(rutaArchivoCadeteJSON);

            // Deserializa el archivo JSON a una lista de objetos Cadete
            var cadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonData);

            return cadetes;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al leer el archivo JSON: " + ex.Message);
            return null;
        }
    }
    public Cadeteria LeerCadeteriaJSON()
    {
        try
        {
            string jsonData = File.ReadAllText(rutaArchivoCadeteriaJSON);

            // Deserializa el archivo JSON a una lista de objetos Cadete
            var cadeteriaDes = JsonSerializer.Deserialize<Cadeteria>(jsonData);

            List<Cadete> cadetes = LeerCadetesJSON();

            Cadeteria cadeteria = new Cadeteria(cadeteriaDes.Nombre, cadeteriaDes.Telefono, cadetes);
            return cadeteria;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al leer el archivo JSON: " + ex.Message);
            return null;
        }
    }
}