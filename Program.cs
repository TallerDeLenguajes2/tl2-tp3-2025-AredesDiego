using System;
using System.Collections.Generic;

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

Cadeteria cadeteria1 = new Cadeteria("Merlina", 1245125, Lcadete);

List<Cadeteria> cadeterias = new List<Cadeteria>();
cadeterias.Add(cadeteria1);

Informe informe = new Informe();
informe.mostrarInformeCadeteria(cadeterias);

Console.ReadKey();

