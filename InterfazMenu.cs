using System;
using Modelos;
namespace Menu;

public class InterfazMenu
{
    private Pedido pedido { get; set; }
    public void Interfaz(Cadeteria cadeteria) 
    {
        if (pedido != null)
        {
            Console.WriteLine("Tiene un pedido en linea.");
        }
        do
        {
            Console.WriteLine("Bienvenido al menú:");
            Console.WriteLine("1. Dar de alta pedidos.");
            Console.WriteLine("2. Asignarlo a cadetes.");
            Console.WriteLine("3. Cambiarlos de estado.");
            Console.WriteLine("4. Reasignar el pedido a otro cadete.");
            Console.WriteLine("5. Mostrar informa de jornada.");
            Console.WriteLine("6. Salir.");

            Console.Write("Elige una opción (1-6): ");
            int opcion = int.Parse(Console.ReadLine());

            FuncionesMenu funcionesMenu = new FuncionesMenu();

            switch (opcion)
            {
                case 1:
                    pedido = funcionesMenu.AltaPedido();
                    break;
                case 2:
                    funcionesMenu.AsignarPedidoCadete(pedido, cadeteria);
                    break;
                case 3:
                    funcionesMenu.CambiarEstadoPedido(cadeteria);
                    break;
                case 4:
                    funcionesMenu.ReasignarPedidoCadete(cadeteria);
                    break;
                case 5:
                    funcionesMenu.Informe(cadeteria);
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    Interfaz(cadeteria);
                    break;
            }
        } while (true);
    }
}
