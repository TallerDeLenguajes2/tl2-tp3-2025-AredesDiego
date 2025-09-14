public class Cadeteria
{
    public string? Nombre { get; }
    public int Telefono { get; }
    public List<Cadete> ListadoCadetes { get; }
    public List<Pedido> ListadoPedidos { get; }

    public Cadeteria(string nombre, int telefono, List<Cadete> cadetes)
    {
        Nombre = nombre;
        Telefono = telefono;

        if (cadetes != null)
            ListadoCadetes = cadetes;
        else
            ListadoCadetes = new List<Cadete>();

        ListadoPedidos = new List<Pedido>();
    }


    public void DarDeAltaPedido()
    {
        Console.WriteLine("=== Alta de Pedido ===");

        Console.Write("Estado del pedido (true=entregado / false=pendiente): ");
        bool estado = bool.Parse(Console.ReadLine());

        Console.Write("Número de pedido: ");
        int nro = int.Parse(Console.ReadLine());

        Console.WriteLine("Datos del Cliente:");
        Console.Write("Nombre: ");
        string nombreCliente = Console.ReadLine();
        Console.Write("Dirección: ");
        string direccionCliente = Console.ReadLine();
        Console.Write("Teléfono: ");
        string telefonoCliente = Console.ReadLine();

        Console.Write("Observaciones: ");
        string obs = Console.ReadLine();

        var cliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente);

        var nuevoPedido = new Pedido(estado, cliente, nro, obs);

        ListadoPedidos.Add(nuevoPedido);

        Console.WriteLine($"Pedido {nro} dado de alta correctamente.\n");
    }
    public Cliente AsignarloACadete(int idPedido, Cliente cliente, List<Pedido> ListadoPedidos)
    {
        List<Pedido> pedidoEncontrado = new List<Pedido>();
        Cliente clienteReasignar = null;

        foreach (var pedido in ListadoPedidos)
        {
            if (pedido.Nro == idPedido)
            {
                pedidoEncontrado.Add(pedido);
                ListadoPedidos.Remove(pedido);
                break;
            }
        }

        return clienteReasignar;
    }

    public bool AsignarCadeteAPedido(int idCadete, int idPedido)
    {
        var pedido = ListadoPedidos.FirstOrDefault(p => p.Nro == idPedido);
        var cadete = ListadoCadetes.FirstOrDefault(c => c.Id == idCadete);

        if (pedido == null || cadete == null)
            return false;

        pedido.CadeteAsignado = cadete;
        return true;
    }

    public bool CambiarEstadoPedido(int idPedido, bool nuevoEstado)
    {
        foreach (var pedido in ListadoPedidos)
        {
            if (pedido.Nro == idPedido)
            {
                pedido.Estado = nuevoEstado;
                return true;
            }
        }

        foreach (var cadete in ListadoCadetes)
        {
            foreach (var pedido in ListadoPedidos)
            {
                if (pedido.Nro == idPedido)
                {
                    pedido.Estado = nuevoEstado;
                    return true;
                }
            }
        }

        return false;
    }

    public double JornalACobrar(int idCadete)
    {
        return ListadoPedidos
            .Where(p => p.CadeteAsignado?.Id == idCadete && p.Estado == true)
            .Count() * 500;
    }
    
}



