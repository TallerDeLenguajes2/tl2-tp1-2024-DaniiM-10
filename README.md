# TL II - TP1 - Ibáñez Lucas Daniel (Danii :P)

## 1. ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;La relación entre las clases **Pedido** y **Cliente** es un ejemplo de composicion, ya que si se elimina un pedido, el cliente tambien se debe eliminar.  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;La relación entre **Cadete** y **Pedido** es un tipo de asociación por agregación, porque al no tener pedidos no quiere decir que no pueda tener cadetes.  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Por ultimo, la relación entre **Cadeteria** y **Cadete** es por composicion, lo que implica que los cadetes dependen de la cadeteria.

## 2. ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?
- **Alguno de los metodos que podria agregar en Cadeteria:**  
    - `AltaCadete()`: Para ingresar un nuevo cadete.  
    - `BajaCadete()`: Para eliminar un cadete.  
    - `ModificarCadete()`: Para modificar la informacion de un cadete, en el caso de que este lo necesite.  
- **Alguno de los metodos que podria agregar en Cadete:**  
    - `ListarPedidos()`: Para mostrar los pedidos del cadete.  
    - `EliminarHistorialPedidos()`: Para eliminar todos los pedidos al final de la jornada.  

## 3. Teniendo en cuenta los principios de abstracción y ocultamiento, ¿qué atributos, propiedades y métodos deberían ser públicos y cuáles privados?
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Por lo general los atributos son privados, para que solo sean accesibles desde dentro de la clase o sus derivadas. Podriamos utilizar los getters y setters para mostrar o modificar algun valor de un atributo.  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Los metodos publicos podrian ser aquellos que nos permiten interactuar con el objeto y ejecutar algunas funcionalidades importantes, y hacer privados a los metodos que solo sean relevantes para la implementación interna, o que realicen alguna tarea auxiliar.  

## 4. ¿Cómo diseñaría los constructores de cada una de las clases?
- **Constructor de Cadeteria:**
```csharp
public Cadeteria(string _Nombre, string _Telefono)
{
    Nombre = _Nombre;
    Telefono = _Telefono;
    Cadetes = new List<Cadete>();
}
```
- **Constructor de Cadete:**
```csharp
public Cadete(string _Nombre, string _Direccion, string _Telefono)
{
    Id = DateTime.Now.Ticks;
    Nombre = _Nombre;
    Direccion = _Direccion;
    Telefono = _Telefono;
    Pedidos = new List<Pedido>();
}
```
- **Constructor de Pedido:**
```csharp
public Pedido(int _Nro, string _Obs, string _Nombre, string _Direccion, string _Telefono, string _DatosReferenciaDireccion)
{
    Nro = _Nro;
    Obs = _Obs;
    cliente = new Cliente(_Nombre, _Direccion, _Telefono, _DatosReferenciaDireccion);
    EstadoDelPedido = Estados.Pendiente;
}
```
- **Constructor de Cliente:**
```csharp
public Cliente(string _Nombre, string _Direccion, string _Telefono, string _DatosReferenciaDireccion) 
{
    Nombre = _Nombre;
    Direccion = _Direccion;
    Telefono = _Telefono;
    DatosReferenciaDireccion = _DatosReferenciaDireccion;
}
```  
## 5. ¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?