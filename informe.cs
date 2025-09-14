public class Informe
{
    public string GenerarInformeCadeteria(List<Cadeteria> ListadoCadeterias)
    {
        if (ListadoCadeterias == null || !ListadoCadeterias.Any())
        {
            return "No hay cadeterías para mostrar.";
        }

        string informeCompleto = "";

        foreach (var cadeteria in ListadoCadeterias)
        {
            informeCompleto += $"\n---Nombre de Cadeteria: {cadeteria.Nombre}\n";
            informeCompleto += $"---Telefono de Cadeteria: {cadeteria.Telefono}\n";

            var totalPedidos = cadeteria.ListadoPedidos.Count;
            informeCompleto += $"Total de pedidos en esta cadetería: {totalPedidos}\n";

            double jornalTotal = 0;
            foreach (var cadete in cadeteria.ListadoCadetes)
            {
                int pedidosEntregados = cadeteria.ListadoPedidos
                    .Count(p => p.CadeteAsignado?.Id == cadete.Id && p.Estado);
                jornalTotal += cadete.CalcularJornal(pedidosEntregados);
            }
            informeCompleto += $"Jornal total a pagar: {jornalTotal}\n";

            var promedioPedidos = cadeteria.ListadoCadetes.Any()
                ? cadeteria.ListadoPedidos.Count / (double)cadeteria.ListadoCadetes.Count
                : 0;
            informeCompleto += $"Promedio de pedidos por cadete: {promedioPedidos:F2}\n";

            var topCadete = cadeteria.ListadoCadetes
                .Select(c => new
                {
                    Cadete = c,
                    CantidadPedidos = cadeteria.ListadoPedidos.Count(p => p.CadeteAsignado?.Id == c.Id)
                })
                .OrderByDescending(x => x.CantidadPedidos)
                .FirstOrDefault();

            if (topCadete != null && topCadete.CantidadPedidos > 0)
            {
                informeCompleto += $"Cadete con más pedidos: {topCadete.Cadete.Nombre} ({topCadete.CantidadPedidos} pedidos)\n";
            }

            foreach (var cadete in cadeteria.ListadoCadetes)
            {
                var cantPedidosAsignados = cadeteria.ListadoPedidos.Count(p => p.CadeteAsignado?.Id == cadete.Id);
                
                int pedidosEntregados = cadeteria.ListadoPedidos
                    .Count(p => p.CadeteAsignado?.Id == cadete.Id && p.Estado);
                
                var jornal = cadete.CalcularJornal(pedidosEntregados);

                if (cantPedidosAsignados > 0)
                {
                    informeCompleto += $"\nCadete: {cadete.Nombre}\n";
                    informeCompleto += $"Jornal a cobrar: {jornal}\n";
                    informeCompleto += $"Cantidad de pedidos asignados: {cantPedidosAsignados}\n";
                    informeCompleto += $"Pedidos entregados: {pedidosEntregados}\n";
                }
            }
        }

        return informeCompleto;
    }
}