public class Cadete
{
    public int Id { get; }
    public string? nombre;
    private string? direccion;
    private int telefono;

    public Cadete(int id, string nombre, string direccion, int telefono)
    {
        Id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
    }

    public double JornalACobrar(List<Pedido> todosLosPedidos)
    {
        return CantidadPedidosEntregados(todosLosPedidos) * 500;
    }

    private int CantidadPedidosEntregados(List<Pedido> todosLosPedidos)
    {
        int contador = 0;

        foreach (var pedidoActual in todosLosPedidos)
        {
            // Verifica si el pedido está asignado a ESTE cadete y está entregado
            if (pedidoActual.CadeteAsignado == this && pedidoActual.Estado)
            {
                contador++;
            }
        }

        return contador;
    }

}
