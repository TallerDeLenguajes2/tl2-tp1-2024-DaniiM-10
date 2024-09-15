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
    /*public void AltaCadete(string[] cadete)
    {
        ManejadorCSV manejador = new ManejadorCSV();
        bool verif = manejador.EscribirLineaCSV(cadete);

        if(verif)
        {
            Console.WriteLine($"Se agrego el nuevo cadete '{cadete[0]}': '{cadete[1]}'.");
            Cadetes.Add(new Cadete(_Nombre:cadete[0], _Direccion:cadete[1], _Telefono:cadete[2]));
        } else {
            Console.WriteLine("No se pudo agregar un nuevo cadete.");
        }
    }*/
    /*public void BajaCadete(long id) 
    {
        ManejadorCSV manejador = new ManejadorCSV();
        bool verif = manejador.BorrarLineaCSV(id);

        if(verif)
        {
            Console.WriteLine($"Se borró el cadete '{id}'.");
            Cadetes.Remove(Cadetes.Find(cadete => cadete.Id == id));
        } else {
            Console.WriteLine("No se pudo borrar el cadete.");
        }
    }*/
    /*public void ModificarCadete(long id, string[] datos)
    {
        ManejadorCSV manejador = new ManejadorCSV();
        bool verif = manejador.ModificarLineaCSV(id, datos);

        if(verif)
        {
            Console.WriteLine($"Se actualizó el cadete '{id}'.");
            Cadetes.Remove(Cadetes.Find(cadete => cadete.Id == id));
            Cadetes.Add(new Cadete(_Nombre:datos[0], _Direccion:datos[1], _Telefono:datos[2]));
        } else {
            Console.WriteLine("No se pudo modificar el cadete.");
        }
    }*/

    public int JornalACobrar(long id)
    {
        int cantPedidosEntregados = Pedidos.Count(p => p.cadete.Id == id && p.EstadoDelPedido == Estados.Entregado);
        return 500 * cantPedidosEntregados;
    }
    public bool AsignarCadeteAPedido (long id, Pedido pedido)
    {
        Cadete cadete = Cadetes.Find(c => c.Id == id);

        if (cadete != null && pedido != null)
        {
            pedido.cadete = null;
            pedido.cadete = cadete;
            Console.WriteLine("=============================================================");
            Console.WriteLine($"\t- Se asignó el pedido {pedido.Nro} al cadete {cadete.Id}");
            Console.WriteLine("=============================================================");
            Console.ReadKey();
            return false;
        } else {
            Console.WriteLine("=============================================================");
            Console.WriteLine($"No se encontró el cadete. Intente ingresar de nuevo o cambielo.");
            Console.WriteLine("=============================================================");
            return true;
        }
    }
}