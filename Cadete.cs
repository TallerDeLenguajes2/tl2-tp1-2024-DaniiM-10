using System;
using Modelos;
namespace Modelos;

public class Cadete
{
    public long Id { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public List<Pedido> Pedidos { get; set; }

    public Cadete(long _Id, string _Nombre, string _Direccion, string _Telefono)
    {
        //Id = DateTime.Now.Ticks;
        Id = _Id;
        Nombre = _Nombre;
        Direccion = _Direccion;
        Telefono = _Telefono;
        Pedidos = new List<Pedido>();
    }
    public int PedidosEntregados()
    {
        return Pedidos.Count(pedido => pedido.EstadoDelPedido == Estados.Entregado); // Expresion LINQ
    }
    public int JornalACobrar()
    {
        return 500 * PedidosEntregados();
    }
    public void ListarPedidos()
    {
        Console.WriteLine("*************** Listado de pedidos ***************");
        foreach (var pedido in Pedidos) pedido.MostrarPedido();
        Console.WriteLine("**************************************************");
    }
    public void EliminarHistorialPedidos()
    {
        if (Pedidos != null)
        {
            Pedidos.Clear();
            Console.WriteLine("El historial de pedidos fue vaciado.");
        } else {
            Console.WriteLine("No hay pedidos.");
        }
    }
}
