using System;
using System.Collections.Generic;
using System.Linq;

public class Informe
{
    public void mostrarInformeCadeteria(List<Cadeteria>? ListadoCadeterias)
    {
        if (ListadoCadeterias == null || !ListadoCadeterias.Any())
        {
            Console.WriteLine("No hay cadeterías para mostrar.");
            return;
        }

        foreach (var cadeteria in ListadoCadeterias)
        {
            Console.WriteLine("\n---Nombre de Cadeteria: " + cadeteria.Nombre);
            Console.WriteLine("---Telefono de Cadeteria: " + cadeteria.Telefono);

            var totalPedidos = cadeteria.ListadoPedidos.Count;
            Console.WriteLine("Total de pedidos en esta cadetería: " + totalPedidos);

            var jornalTotal = cadeteria.ListadoCadetes.Sum(c => c.JornalACobrar(cadeteria.ListadoPedidos));
            Console.WriteLine("Jornal total a pagar: " + jornalTotal);

            var promedioPedidos = cadeteria.ListadoCadetes.Any()
                ? cadeteria.ListadoPedidos.Count / (double)cadeteria.ListadoCadetes.Count
                : 0;
            Console.WriteLine("Promedio de pedidos por cadete: " + promedioPedidos);

            var topCadete = cadeteria.ListadoCadetes
                .Select(c => new
                {
                    Cadete = c,
                    CantidadPedidos = cadeteria.ListadoPedidos.Count(p => p.CadeteAsignado == c)
                })
                .OrderByDescending(x => x.CantidadPedidos)
                .FirstOrDefault();

            if (topCadete != null)
            {
                Console.WriteLine($"Cadete con más pedidos: {topCadete.Cadete.nombre} ({topCadete.CantidadPedidos} pedidos)");
            }

            foreach (var cadete in cadeteria.ListadoCadetes)
            {
                var cantPedidos = cadeteria.ListadoPedidos.Count(p => p.CadeteAsignado == cadete);
                var jornal = cadete.JornalACobrar(cadeteria.ListadoPedidos);

                Console.WriteLine($"\nCadete: {cadete.nombre}");
                Console.WriteLine($"Jornal a cobrar: {jornal}");
                Console.WriteLine($"Cantidad de pedidos: {cantPedidos}");
            }
        }
    }
}
