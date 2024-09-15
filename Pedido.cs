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
    public Cadete cadete { get; set; }
    public Pedido(){}
    public Pedido(long _Nro, string _PedidoC, float _Precio, string _Obs, 
    string _Nombre, string _Direccion, string _Telefono, string _DatosReferenciaDireccion)
    {
        Nro = _Nro;
        PedidoC = _PedidoC;
        Precio = _Precio;
        Obs = _Obs;
        EstadoDelPedido = Estados.Pendiente;
        cliente = new Cliente(_Nombre, _Direccion, _Telefono, _DatosReferenciaDireccion);
        cadete = new Cadete();
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
    public void EliminarCliente()
    {
        cliente = null;
    }

    public static implicit operator List<object>(Pedido v)
    {
        throw new NotImplementedException();
    }
}