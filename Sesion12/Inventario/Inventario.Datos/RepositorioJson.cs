
using System.Text.Json;
using Inventario.Modelos;

namespace Inventario.Datos;

public class RepositorioJson : IRepositorioProductos
{
    private readonly string _archivo = "productos.json";

    public List<Producto> ObtenerTodos()
    {
        if (!File.Exists(_archivo))
        {
            return new List<Producto>();
        }

        string json = File.ReadAllText(_archivo);

        return JsonSerializer.Deserialize<List<Producto>>(json)
               ?? new List<Producto>();
    }

    public Producto? BuscarPorCodigo(string codigo)
    {
        return ObtenerTodos().FirstOrDefault(
            p => p.Codigo.Equals(
                codigo, StringComparison.OrdinalIgnoreCase));
    }

    public void Agregar(Producto producto)
    {
        List<Producto> productos = ObtenerTodos();

        productos.Add(producto);

        Guardar(productos);
    }

    public void Actualizar(Producto producto)
    {
        List<Producto> productos = ObtenerTodos();

        int indice = productos.FindIndex(
            p => p.Codigo.Equals(
                producto.Codigo, StringComparison.OrdinalIgnoreCase));

        if (indice == -1)
        {
            throw new ArgumentException("El producto no existe.");
        }

        productos[indice] = producto;

        Guardar(productos);
    }

    public void Eliminar(string codigo)
    {
        List<Producto> productos = ObtenerTodos();

        Producto? producto = productos.FirstOrDefault(
            p => p.Codigo.Equals(
                codigo, StringComparison.OrdinalIgnoreCase));

        if (producto == null)
        {
            throw new ArgumentException("Producto no encontrado.");
        }

        productos.Remove(producto);

        Guardar(productos);
    }

    public List<Categoria> ObtenerCategorias()
    {
        return new List<Categoria>
        {
            new Categoria
            {
                Id = 1,
                Nombre = "General"
            }
        };
    }

    private void Guardar(List<Producto> productos)
    {
        string json = JsonSerializer.Serialize(
            productos,
            new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText(_archivo, json);
    }
}
