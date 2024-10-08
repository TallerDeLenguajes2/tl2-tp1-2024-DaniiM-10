using Modelos;
namespace Modelos;

public enum Estados {
    Pendiente,
    EnCamino,
    Entregado,
    Cancelado
}
public class Pedido
{
    public long Nro { get; set; }
    public string PedidoC { get; set; }
    public float Precio { get; set; }
    public string Obs { get; set; }
    private Cliente cliente;
    public Estados EstadoDelPedido { get; set; }

    public Pedido(long _Nro, string _PedidoC, float _Precio, string _Obs, 
    string _Nombre, string _Direccion, string _Telefono, string _DatosReferenciaDireccion)
    {
        Nro = _Nro;
        PedidoC = _PedidoC;
        Precio = _Precio;
        Obs = _Obs;
        cliente = new Cliente(_Nombre, _Direccion, _Telefono, _DatosReferenciaDireccion);
        EstadoDelPedido = Estados.Pendiente;
    }
    private void MostrarEstado()
    {
        switch (EstadoDelPedido)
        {
            case Estados.Pendiente:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case Estados.EnCamino:
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case Estados.Entregado:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case Estados.Cancelado:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
        }
        Console.WriteLine($"Estado del pedido: {EstadoDelPedido}");
        Console.ResetColor();
    }
    public void MostrarPedido()
    {
        Console.WriteLine("\t********** Datos del Pedido **********");
        Console.WriteLine($"\t\tNro de pedido: {Nro}");
        Console.WriteLine($"\t\tPedido C: {PedidoC}");
        Console.WriteLine($"\t\tPedido C: {Precio}");
        Console.WriteLine($"\t\tObservaciones: {Obs}");
        MostrarEstado();
        cliente.MostrarDatosCliente();
        Console.WriteLine("\t**************************************");
    }
    public void EliminarCliente() // Eliminar cliente
    {
        cliente = null;

    }
}