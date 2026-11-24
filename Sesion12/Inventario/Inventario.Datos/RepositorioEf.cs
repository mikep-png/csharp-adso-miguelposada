
using Inventario.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Datos;

public class RepositorioEf : IRepositorioProductos
{
    private readonly InventarioContext _db = new();

    public RepositorioEf()
    {
        // Crear la base de datos si todavía no existe.
        _db.Database.EnsureCreated();

        // Registrar categorías iniciales.
        if (!_db.Categorias.Any())
        {
            _db.Categorias.AddRange(
                new Categoria { Nombre = "Papelería" },
                new Categoria { Nombre = "Tecnología" },
                new Categoria { Nombre = "Aseo" }
            );

            _db.SaveChanges();
        }
    }

    public List<Producto> ObtenerTodos()
    {
        return _db.Productos
            .Include(p => p.Categoria)
            .ToList();
    }

    public Producto? BuscarPorCodigo(string codigo)
    {
        string clave = codigo.Trim().ToUpper();

        return _db.Productos
            .Include(p => p.Categoria)
            .FirstOrDefault(p => p.Codigo == clave);
    }

    public void Agregar(Producto producto)
    {
        _db.Productos.Add(producto);
        _db.SaveChanges();
    }

    public void Actualizar(Producto producto)
    {
        _db.Productos.Update(producto);
        _db.SaveChanges();
    }

    public void Eliminar(string codigo)
    {
        Producto? producto = BuscarPorCodigo(codigo);

        if (producto is null)
        {
            return;
        }

        _db.Productos.Remove(producto);
        _db.SaveChanges();
    }

    public List<Categoria> ObtenerCategorias()
    {
        return _db.Categorias
            .OrderBy(c => c.Nombre)
            .ToList();
    }
}
