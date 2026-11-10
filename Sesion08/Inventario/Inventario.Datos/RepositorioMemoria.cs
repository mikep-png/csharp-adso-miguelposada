
using Inventario.Modelos;

namespace Inventario.Datos;

public class RepositorioMemoria : IRepositorioProductos
{
    private readonly List<Producto> _productos = new();

    public List<Producto> ObtenerTodos()
    {
        return _productos.ToList();
    }

    public Producto? BuscarPorCodigo(string codigo)
    {
        return _productos.FirstOrDefault(
            p => p.Codigo.Equals(
                codigo, StringComparison.OrdinalIgnoreCase));
    }

    public void Agregar(Producto producto)
    {
        _productos.Add(producto);
    }

    public void Actualizar(Producto producto)
    {
        int indice = _productos.FindIndex(
            p => p.Codigo.Equals(
                producto.Codigo, StringComparison.OrdinalIgnoreCase));

        if (indice == -1)
        {
            throw new ArgumentException(
                "El producto no existe.");
        }

        _productos[indice] = producto;
    }
    public void Eliminar(string codigo)
    {
        Producto? producto = BuscarPorCodigo(codigo);

        if (producto == null)
        {
            throw new ArgumentException("Producto no encontrado.");
        }

        _productos.Remove(producto);
    }
}
