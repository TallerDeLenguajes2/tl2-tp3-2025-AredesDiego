using System.Diagnostics.Contracts;
public class Cliente
{
    public Cliente() {} 
    public Cliente(string? nombreCliente, string? direccionCliente, string? telefonoCliente)
    {
        NombreCliente = nombreCliente;
        DireccionCliente = direccionCliente;
        TelefonoCliente = telefonoCliente;
    }

    public string? nombre { get; set; }
    public string? direccion { get; set; }
    public int telefono { get; set; }
    public string? DatosDeReferenciaDireccion { get; set; }
    public string? NombreCliente { get; }
    public string? DireccionCliente { get; }
    public string? TelefonoCliente { get; }
}

