
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
            throw new ArgumentException("El código es obligatorio.");

        if (string.IsNullOrWhiteSpace(producto.Nombre))
            throw new ArgumentException("El nombre es obligatorio.");

        if (producto.Precio < 0)
            throw new ArgumentException("El precio no puede ser negativo.");

        if (producto.Stock < 0)
            throw new ArgumentException("El stock no puede ser negativo.");

        if (_repositorio.BuscarPorCodigo(producto.Codigo) != null)
            throw new ArgumentException("El código ya está registrado.");

        _repositorio.Agregar(producto);
    }

    public void Actualizar(Producto productoActualizado)
    {
        if (productoActualizado == null)
            throw new ArgumentNullException(nameof(productoActualizado));

        Producto? producto = _repositorio.BuscarPorCodigo(
            productoActualizado.Codigo
        );

        if (producto == null)
            throw new ArgumentException("Producto no encontrado.");

        producto.ActualizarDatos(
            productoActualizado.Nombre,
            productoActualizado.Precio
        );

        // Actualizar también la categoría.
        producto.CambiarCategoria(productoActualizado.CategoriaId);

        _repositorio.Actualizar(producto);
    }

    public void AgregarStock(string codigo, int cantidad)
    {
        Producto? producto = _repositorio.BuscarPorCodigo(codigo);

        if (producto == null)
            throw new ArgumentException("Producto no encontrado.");

        producto.AgregarStock(cantidad);
        _repositorio.Actualizar(producto);
    }

    public void Vender(string codigo, int cantidad)
    {
        Producto? producto = _repositorio.BuscarPorCodigo(codigo);

        if (producto == null)
            throw new ArgumentException("Producto no encontrado.");

        producto.Vender(cantidad);
        _repositorio.Actualizar(producto);
    }

    public List<Producto> StockBajo()
    {
        return _repositorio.ObtenerTodos()
            .Where(p => p.Stock < 5)
            .ToList();
    }

    public List<Producto> ProductosMasValiosos()
    {
        return _repositorio.ObtenerTodos()
            .OrderByDescending(p => p.Precio * p.Stock)
            .ToList();
    }

    public List<Producto> BuscarPorTexto(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
            throw new ArgumentException("Debes escribir un texto para buscar.");

        return _repositorio.ObtenerTodos()
            .Where(p =>
                p.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                p.Codigo.Contains(texto, StringComparison.OrdinalIgnoreCase)
            )
            .ToList();
    }

    public void Eliminar(string codigo)
    {
        if (string.IsNullOrWhiteSpace(codigo))
            throw new ArgumentException("Debes escribir el código del producto.");

        _repositorio.Eliminar(codigo);
    }

    public List<Categoria> ObtenerCategorias()
    {
        return _repositorio.ObtenerCategorias();
    }

    public List<Producto> FiltrarPorCategoria(int categoriaId)
    {
        return _repositorio.ObtenerTodos()
            .Where(p => p.CategoriaId == categoriaId)
            .ToList();
    }

    public List<ResumenCategoria> ObtenerResumenPorCategoria()
    {
        return _repositorio.ObtenerTodos()
            .GroupBy(p => new
            {
                p.CategoriaId,
                NombreCategoria = p.Categoria != null
                    ? p.Categoria.Nombre
                    : "Sin categoría"
            })
            .Select(grupo => new ResumenCategoria
            {
                CategoriaId = grupo.Key.CategoriaId,
                NombreCategoria = grupo.Key.NombreCategoria,
                CantidadProductos = grupo.Count(),
                ValorTotal = grupo.Sum(p => p.Precio * p.Stock)
            })
            .ToList();
    }
}
