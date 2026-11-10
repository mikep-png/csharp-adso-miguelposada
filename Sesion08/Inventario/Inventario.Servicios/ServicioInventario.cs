
using Inventario.Datos;
using Inventario.Modelos;

namespace Inventario.Servicios;

public class ServicioInventario
{
    private readonly IRepositorioProductos _repositorio;

    public ServicioInventario(IRepositorioProductos repositorio)
    {
        _repositorio = repositorio;
    }

    public List<Producto> Listar()
    {
        return _repositorio.ObtenerTodos();
    }

    public void Agregar(Producto producto)
    {
        if (string.IsNullOrWhiteSpace(producto.Codigo))
        {
            throw new ArgumentException("El código es obligatorio.");
        }

        if (string.IsNullOrWhiteSpace(producto.Nombre))
        {
            throw new ArgumentException("El nombre es obligatorio.");
        }

        if (producto.Precio < 0)
        {
            throw new ArgumentException("El precio no puede ser negativo.");
        }

        if (producto.Stock < 0)
        {
            throw new ArgumentException("El stock no puede ser negativo.");
        }

        if (_repositorio.BuscarPorCodigo(producto.Codigo) != null)
        {
            throw new ArgumentException("El código ya está registrado.");
        }

        _repositorio.Agregar(producto);
    }

    public void AgregarStock(string codigo, int cantidad)
    {
        Producto? producto = _repositorio.BuscarPorCodigo(codigo);

        if (producto == null)
        {
            throw new ArgumentException("Producto no encontrado.");
        }

        producto.AgregarStock(cantidad);

        _repositorio.Actualizar(producto);
    }

    public void Vender(string codigo, int cantidad)
    {
        Producto? producto = _repositorio.BuscarPorCodigo(codigo);

        if (producto == null)
        {
            throw new ArgumentException("Producto no encontrado.");
        }

        producto.Vender(cantidad);

        _repositorio.Actualizar(producto);
    }

    public List<Producto> StockBajo()
    {
        return _repositorio.ObtenerTodos()
            .Where(p => p.Stock < 5)
            .ToList();
    }
}
