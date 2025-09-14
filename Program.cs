string rutaArchivoPedido = "pedido.csv";
string rutaArchivoCadete = "cadetes.csv";

Console.WriteLine("Seleccione el tipo de datos a cargar (1 = CSV, 2 = JSON):");
string opcion = Console.ReadLine();

IAccesoADatos<Pedido> accesoPedidos;
IAccesoADatos<Cadete> accesoCadetes;

if (opcion == "1")
{
    accesoPedidos = new AccesoADatosCSV<Pedido>();
    accesoCadetes = new AccesoADatosCSV<Cadete>();
}
else
{
    accesoPedidos = new AccesoADatosJSON<Pedido>();
    accesoCadetes = new AccesoADatosJSON<Cadete>();

    rutaArchivoPedido = rutaArchivoPedido.Replace(".csv", ".json");
    rutaArchivoCadete = rutaArchivoCadete.Replace(".csv", ".json");
}

List<Pedido> Lpedido = accesoPedidos.Cargar(rutaArchivoPedido);
List<Cadete> Lcadete = accesoCadetes.Cargar(rutaArchivoCadete);

Random random = new Random();
foreach (var pedido in Lpedido)
{
    if (Lcadete != null && Lcadete.Count > 0)
    {
        int indexAleatorio = random.Next(Lcadete.Count);
        pedido.CadeteAsignado = Lcadete[indexAleatorio];
        
        pedido.Estado = random.Next(2) == 1;
    }
}

Cadeteria cadeteria1 = new Cadeteria("Merlina", 1245125, Lcadete);

if (Lpedido != null)
{
    foreach (var pedido in Lpedido)
    {
        cadeteria1.ListadoPedidos.Add(pedido);
    }
}

Informe informe = new Informe();
string reporte = informe.GenerarInformeCadeteria(new List<Cadeteria> { cadeteria1 });

Console.WriteLine(reporte);

