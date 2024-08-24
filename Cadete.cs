using System;
using Modelos;
namespace Modelos;

public class Cadete
{
    public long Id { get; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public List<Pedido> Pedidos { get; set; }

    public Cadete(string _Nombre, string _Direccion, string _Telefono)
    {
        Id = DateTime.Now.Ticks;
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
}
