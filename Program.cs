using System;
using Modelos;
using Menu;
public class Program
{
    public static void Main(string[] args)
    {
        
        ManejadorCSV manejadorCSV = new ManejadorCSV();

        Cadeteria cadeteria = manejadorCSV.LeerCadeteriaCSV(csvCadeteria);

        InterfazMenu menu = new InterfazMenu();
        menu.Interfaz(cadeteria);
    }
}
