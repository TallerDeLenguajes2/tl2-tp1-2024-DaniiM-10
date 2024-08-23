# Taller de lenguajes II - TP1 - Ibáñez Lucas Daniel (Danii :P)

### Preguntas:

1. ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?  
    La relación entre las clases **Pedido** y **Cliente** es un ejemplo de composicion, ya que si se elimina un pedido, el cliente tambien se debe eliminar.  
    La relación entre **Cadete** y **Pedido** es un tipo de asociación por agregación, porque al no tener pedidos no quiere decir que no pueda tener cadetes.  
    Por ultimo, la relación entre **Cadeteria** y **Cadete** es por composicion, lo que implica que los cadetes dependen de la cadeteria.
2. ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?  
    **- Alguno de los metodos que podria agregar en Cadeteria:**  
        - `AltaCadete()`: Para ingresar un nuevo cadete en la cadeteria, podria incluir una creacion de un objeto Cadete de la lista de cadetes.  
        - `BajaCadete()`: Para eliminar un cadete de la lista.  
        - `ReasignarCadete()`: Para reasignar un pedido de un cadete a otro.  
        - `ModificarCadete()`: Para modificar la informacion de un cadete, en el caso de que este lo necesite.  
    **- Alguno de los metodos que podria agregar en Cadete:**  
        - `AltaPedido()`: Para ingresar un nuevo pedido en la lista de pedidos del cadete.  
        - `ListarPedidos()`: Para mostrar los pedidos del cadete.  
        - `CambiarEstadoPedido()`: Para cambiar el estado del pedido, de "Pendiente", "En camino" o "Entregado".  
        - `EliminarPedido()`: Para eliminar un pedido de la lista de pedidos que tenga el cadete.  
3. Teniendo en cuenta los principios de abstracción y ocultamiento, ¿qué atributos, propiedades y métodos deberían ser públicos y cuáles privados?
4. ¿Cómo diseñaría los constructores de cada una de las clases?
5. ¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?