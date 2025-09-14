using System.Text.Json;

public class AccesoADatosJSON<T> : IAccesoADatos<T>
{
    public List<T> Cargar(string archivo)
    {
        if (!File.Exists(archivo))
        {
            Console.WriteLine($"Archivo no encontrado: {archivo}");
            return new List<T>();
        }

        string json = File.ReadAllText(archivo);
        return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
    }
}
