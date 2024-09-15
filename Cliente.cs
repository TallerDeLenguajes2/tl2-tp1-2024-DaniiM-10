namespace Modelos;
public class Cliente
{
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string DatosReferenciaDireccion { get; set; }

    public Cliente(){}
    public Cliente(string _Nombre, string _Direccion, string _Telefono, string _DatosReferenciaDireccion) 
    {
        Nombre = _Nombre;
        Direccion = _Direccion;
        Telefono = _Telefono;
        DatosReferenciaDireccion = _DatosReferenciaDireccion;
    }
    public void MostrarDatosCliente()
    {
        Console.WriteLine("\t\t- CLIENTE:");
        Console.WriteLine($"\t\tNombre: {Nombre}");
        Console.WriteLine($"\t\tDireccion: {Direccion}");
        Console.WriteLine($"\t\tTelefono: {Telefono}");
        if(!string.IsNullOrEmpty(DatosReferenciaDireccion)) Console.WriteLine($"\t\tReferencias: {DatosReferenciaDireccion}");
    }
}