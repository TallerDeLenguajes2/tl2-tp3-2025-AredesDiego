public class Pedido
{
    public bool Estado;
    public Cliente? Cliente;
    public int Nro;
    public string? Obs;
    public Cadete? CadeteAsignado { get; set; }

    public Pedido(bool estado, Cliente cliente, int nro, string obs, Cadete? cadeteAsignado = null)
    {
        Estado = estado;
        Cliente = cliente;
        Nro = nro;
        Obs = obs;
        CadeteAsignado = cadeteAsignado;
    }

    private void VerDireccionCliente(Cliente cliente)
    {
        Console.WriteLine("Direccion:" + cliente.direccion);
    }
    private void VerDatosCliente(Cliente cliente)
    {
        Console.WriteLine("Nombre:" + cliente.nombre);
        Console.WriteLine("Telefono:" + cliente.telefono);
        Console.WriteLine("Datos De Referencia de Direccion:" + cliente.DatosDeReferenciaDireccion);
    }

}