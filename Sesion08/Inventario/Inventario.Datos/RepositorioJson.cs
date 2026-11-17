
using System.Text.Json;
using Inventario.Modelos;

namespace Inventario.Datos;

public class RepositorioJson : IRepositorioProductos
{
    private readonly string _ruta;

    private readonly JsonSerializerOptions _opciones =
        new JsonSerializerOptions
        {
            WriteIndented = true
        };

    public RepositorioJson(string ruta = "inventario.json")
    {
        _ruta = Path.GetFullPath(ruta);

        Console.WriteLine("=================================");
        Console.WriteLine("ARCHIVO DE INVENTARIO:");
        Console.WriteLine(_ruta);
        Console.WriteLine("=================================");
    }

    private List<Producto> LeerArchivo()
    {
        if (!File.Exists(_ruta))
        {
            return new List<Producto>();
        }

        try
        {
            string contenido = File.ReadAllText(_ruta);

            return JsonSerializer.Deserialize<List<Producto>>(
                contenido, _opciones
            ) ?? new List<Producto>();
        }
        catch (JsonException)
        {
            string rutaDanada = _ruta + ".danado";

            File.Copy(_ruta, rutaDanada, true);

            Console.WriteLine(
                $"JSON dañado. Copia guardada en: {rutaDanada}"
            );

            return new List<Producto>();
        }
    }

    private void GuardarArchivo(List<Producto> productos)
    {
        string? carpeta = Path.GetDirectoryName(_ruta);

        if (!string.IsNullOrEmpty(carpeta))
        {
            Directory.CreateDirectory(carpeta);
        }

        string json = JsonSerializer.Serialize(
            productos, _opciones
        );

        File.WriteAllText(_ruta, json);

        Console.WriteLine("Inventario guardado correctamente.");
    }

    public List<Producto> ObtenerTodos()
    {
        return LeerArchivo();
    }

    public Producto? BuscarPorCodigo(string codigo)
    {
        return LeerArchivo().FirstOrDefault(
            p => p.Codigo.Equals(
                codigo,
                StringComparison.OrdinalIgnoreCase
            )
        );
    }

    public void Agregar(Producto producto)
    {
        List<Producto> productos = LeerArchivo();

        productos.Add(producto);

        GuardarArchivo(productos);
    }

    public void Actualizar(Producto producto)
    {
        List<Producto> productos = LeerArchivo();

        int indice = productos.FindIndex(
            p => p.Codigo.Equals(
                producto.Codigo,
                StringComparison.OrdinalIgnoreCase
            )
        );

        if (indice == -1)
        {
            throw new ArgumentException(
                "El producto no existe."
            );
        }

        productos[indice] = producto;

        GuardarArchivo(productos);
    }
    public void Eliminar(string codigo)
    {
        List<Producto> productos = LeerArchivo();

        int indice = productos.FindIndex(
            p => p.Codigo.Equals(
                codigo,
                StringComparison.OrdinalIgnoreCase
            )
        );

        if (indice == -1)
        {
            throw new ArgumentException("Producto no encontrado.");
        }

        productos.RemoveAt(indice);

        GuardarArchivo(productos);
    }
}
