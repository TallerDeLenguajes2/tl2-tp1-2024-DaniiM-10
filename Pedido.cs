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
}