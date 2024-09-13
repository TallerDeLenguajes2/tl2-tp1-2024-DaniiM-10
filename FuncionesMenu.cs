using System.Reflection.Metadata.Ecma335;
using System;
using Modelos;
namespace Menu;

public class FuncionesMenu
{
    public Pedido AltaPedido()
    {
        Console.Clear();
        Console.WriteLine("********** Crear Pedido **********");

        Console.WriteLine("\t- Agregue los datos del cliente:");
        Console.Write("\t\t- Nombre:");string nombre = Console.ReadLine();
        Console.Write("\t\t- Direccion:");string direccion = Console.ReadLine();
        Console.Write("\t\t- Telefono:");string telefono = Console.ReadLine();
        Console.Write("\t\t- Datos de referencia:");string datosRef = Console.ReadLine();

        Console.WriteLine("\t- Agregue los datos del pedido:");
        Console.Write("\t\t- Pedido:");string pedido = Console.ReadLine();
        Console.Write("\t\t- Precio:");float precio = float.Parse(Console.ReadLine());
        Console.Write("\t\t- Observaciones:");string obs = Console.ReadLine();

        long nroPedido = DateTime.Now.Ticks;
        Pedido pedidoCreado = new Pedido(nroPedido, pedido, precio, obs, nombre, direccion, telefono, datosRef);

        Console.WriteLine("=============================================================");
        Console.WriteLine($"\t- Pedido creado con exito. Nro de pedido: {nroPedido}");
        Console.WriteLine("=============================================================");

        Console.ReadKey();

        return pedidoCreado;
    }
    public void AsignarPedidoCadete(Pedido pedido, Cadeteria cadeteria) 
    {
        do
        {
            Console.Clear();
            Console.WriteLine("********** Asignar Pedido **********");
            Console.Write("\t- Ingrese el id del cadete:");long id = long.Parse(Console.ReadLine());
            
            var cadete = cadeteria.Cadetes.Find(cadete => cadete.Id == id);
            if (cadete != null)
            {
                cadete.Pedidos.Add(pedido);
                Console.WriteLine("=============================================================");
                Console.WriteLine($"\t- Se asignó el pedido {pedido.Nro} al cadete {cadete.Id}");
                Console.WriteLine("=============================================================");
                Console.ReadKey();
                return;
            } else {
                Console.WriteLine("=============================================================");
                Console.WriteLine($"No se encontró el cadete. Intente ingresar de nuevo o cambielo.");
                Console.WriteLine("=============================================================");
            }
        } while (true);
    }
    public void CambiarEstadoPedido(Cadeteria cadeteria) // Cambiar el estado de los pedidos
    {
        Console.WriteLine("********** Cambiar Estado Pedido **********");

        Console.WriteLine("\t- Todos los pedidos:");
        foreach (var cadete in cadeteria.Cadetes)
        {
            Console.WriteLine($"\t\t- Pedidos del cadete {cadete.Nombre}:");
            cadete.ListarPedidos();
        }
        Console.WriteLine("******************************************");
        bool pedidoEncontrado = false;
        do
        {
            Console.WriteLine("\t- Ingrese el Nro de pedido:");long nro = long.Parse(Console.ReadLine());
            Console.WriteLine("\t- Ingrese el estado del pedido (Entregado, EnCamino, Cancelado)"); string opcion = Console.ReadLine();
            
            var pedidos = cadeteria.Cadetes.SelectMany(cadete => cadete.Pedidos).ToList(); // Combina todos los pedidos en una sola lista
            
            var pedido = pedidos.Find(pedido => pedido.Nro == nro);

            if (pedido != null)
            {
                opcion = char.ToUpper(opcion[0]) + opcion.Substring(1);
                
                switch (opcion)
                {
                    case "Entregado":
                        pedido.EstadoDelPedido = Estados.Entregado;    
                        break;
                    case "EnCamino":
                    case "Encamino":
                        pedido.EstadoDelPedido = Estados.EnCamino;
                        break;
                    case "Cancelado":
                        pedido.EstadoDelPedido = Estados.Cancelado;
                        break;
                    default:
                        pedido.EstadoDelPedido = Estados.Pendiente;
                        break;
                }
                pedidoEncontrado = true;
                Console.WriteLine("=============================================================");
                Console.WriteLine($"Se cambio el estado del pedido {nro} a {opcion}.");
                Console.WriteLine("=============================================================");
            } else {
                Console.WriteLine("=============================================================");
                Console.WriteLine("No se encontró el pedido. Intente de nuevo.");
                Console.WriteLine("=============================================================");
            }
            Console.ReadKey();
        } while (!pedidoEncontrado);
    }
    public void ReasignarPedidoCadete(Cadeteria cadeteria)
    {
        do
        {
            Console.WriteLine("********** Reasignar el pedido **********");
            Console.Write("\t- Ingrese el nro de pedido:");long nroPedido = long.Parse(Console.ReadLine());

            foreach (var cadete in cadeteria.Cadetes)
            {
                foreach (var pedido in cadete.Pedidos)
                {
                    if (pedido.Nro == nroPedido)
                    {
                        Pedido pedidoEncontrado = pedido;
                        cadete.Pedidos.Remove(pedidoEncontrado);
                        AsignarPedidoCadete(pedidoEncontrado, cadeteria);
                        Console.ReadKey();
                        return;
                    }
                }
            }
            Console.WriteLine("=============================================================");
            Console.WriteLine("No se encontró el pedido. Intente de nuevo.");
            Console.WriteLine("=============================================================");
        } while (true);
    }
    public void Informe(Cadeteria cadeteria)
    {
        double montoGanadoTotal = 0;
        Console.WriteLine("********** Informe **********");
        foreach (var cadete in cadeteria.Cadetes)
        {
            Console.WriteLine($"\t********** Cadete {cadete.Nombre} **********");
            int cantEnvios = 0;
            double montoGanadoCadaCadete = 0;
            foreach (var pedido in cadete.Pedidos)
            {
                if (pedido.EstadoDelPedido == Estados.Entregado)
                {
                    cantEnvios++;
                    montoGanadoCadaCadete += pedido.Precio;
                }
            }
            //mostrar las variables
            Console.WriteLine($"\t\t- Nro de pedidos entregados: {cantEnvios}");
            Console.WriteLine($"\t\t- Monto ganado: ${montoGanadoCadaCadete}");
            montoGanadoTotal += montoGanadoCadaCadete;
        }
        Console.WriteLine($"\t**************************************");
        Console.WriteLine($"\t- Monto ganado total: ${montoGanadoTotal}");
        Console.ReadKey();
    }
}