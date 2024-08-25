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
    public int Nro { get; set; }
    public string Obs { get; set; }
    private Cliente cliente;
    public Estados EstadoDelPedido { get; set; }

    public Pedido(int _Nro, string _Obs, string _Nombre, string _Direccion, string _Telefono, string _DatosReferenciaDireccion)
    {
        Nro = _Nro;
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
        Console.WriteLine($"\t\tObservaciones: {Obs}");
        MostrarEstado();
        cliente.MostrarDatosCliente();
        Console.WriteLine("\t**************************************");
    }
}