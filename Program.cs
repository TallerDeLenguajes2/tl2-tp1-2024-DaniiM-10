using System;
using Modelos;
using Menu;
public class Program
{
    public static void Main(string[] args)
    {
        Cadeteria cadeteria = null;
        Console.WriteLine("Como desea cargar la cateria y los cadetes?\n1- JSON\n2- CSV\n- Ingrese una opcion: ");int opc = int.Parse(Console.ReadLine());
        if (opc == 2)
        {
            ManejadorCSV manejadorCSV = new ManejadorCSV();
            cadeteria = manejadorCSV.LeerCadeteriaCSV();
        } else {
            ManejadorJSON manejadorCSV = new ManejadorJSON();
            cadeteria = manejadorCSV.LeerCadeteriaJSON();
        }

        InterfazMenu menu = new InterfazMenu();
        menu.Interfaz(cadeteria);
    }
}