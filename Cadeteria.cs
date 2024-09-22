namespace Modelos;

public class Cadeteria
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public List<Cadete> Cadetes { get; set; }
    public List<Pedido> Pedidos { get; set; }

    public Cadeteria(){}

    public Cadeteria(string _Nombre, string _Telefono, List<Cadete> _Cadetes)
    {
        Nombre = _Nombre;
        Telefono = _Telefono;
        Cadetes = _Cadetes;
        Pedidos = new List<Pedido>();
    }
    public int JornalACobrar(long id)
    {
        int cantPedidosEntregados = Pedidos.Count(p => p.cadete.Id == id && p.EstadoDelPedido == Estados.Entregado);
        return 500 * cantPedidosEntregados;
    }
    public bool AsignarCadeteAPedido (long nroPedido, int idCadete)
    {
        Cadete cadete = Cadetes.Find(c => c.Id == idCadete);
        Pedido pedido = Pedidos.Find(p => p.Nro == nroPedido);

        if (cadete != null && pedido != null)
        {
            pedido.cadete = null;
            pedido.cadete = cadete;
            return true; // Se asignó un pedido a un cadete
        } else {
            return false; // No se asignó un pedido a un cadete
        }
    }
}