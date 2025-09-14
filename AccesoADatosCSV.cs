public class AccesoADatosCSV<T> : IAccesoADatos<T>
{
    public List<T> Cargar(string archivo)
    {
        if (!File.Exists(archivo))
        {
            Console.WriteLine($"Archivo no encontrado: {archivo}");
            return new List<T>();
        }

        var lineas = File.ReadAllLines(archivo);

        var lista = new List<T>();

        for (int i = 1; i < lineas.Length; i++) // salteamos encabezado
        {
            var separate = lineas[i].Split(',');

            if (typeof(T) == typeof(Pedido))
            {
                int nro = int.Parse(separate[0]);
                string obs = separate[1];
                bool estado = bool.Parse(separate[2]);

                Cliente cliente = new Cliente
                {
                    nombre = separate[3],
                    direccion = separate[4],
                    telefono = int.Parse(separate[5]),
                    DatosDeReferenciaDireccion = separate[6]
                };

                var pedido = new Pedido(estado, cliente, nro, obs, null);
                lista.Add((T)(object)pedido);
            }
            else if (typeof(T) == typeof(Cadete))
            {
                int id = int.Parse(separate[0]);
                string nombre = separate[1];
                string direccion = separate[2];
                int telefono = int.Parse(separate[3]);

                var cadete = new Cadete(id, nombre, direccion, telefono);
                lista.Add((T)(object)cadete);
            }
        }

        return lista;
    }
}
