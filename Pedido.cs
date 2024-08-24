using Modelos;
namespace Modelos;

public enum Estados {
    Pendiente,
    EnCamino,
    Entregado
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
}
