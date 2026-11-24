
namespace Inventario.Modelos;

public class Producto
{
    public string Codigo { get; private set; }
    public string Nombre { get; private set; }
    public decimal Precio { get; private set; }
    public int Stock { get; private set; }

    // Identificador de la categoría a la que pertenece.
    public int? CategoriaId { get; private set; }

    // Relación con el modelo Categoria.
    public Categoria? Categoria { get; private set; }

    public Producto(string codigo, string nombre, decimal precio, int stock)
    {
        Codigo = codigo;
        Nombre = nombre;
        Precio = precio;
        Stock = stock;
    }

    // Permite asignar o cambiar la categoría.
    public void CambiarCategoria(int? categoriaId)
    {
        CategoriaId = categoriaId;
    }

    public void ActualizarDatos(string nombre, decimal precio)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException("El nombre es obligatorio.");
        }

        if (precio < 0)
        {
            throw new ArgumentException("El precio no puede ser negativo.");
        }

        Nombre = nombre;
        Precio = precio;
    }

    public void Vender(int cantidad)
    {
        if (cantidad <= 0)
        {
            throw new ArgumentException(
                "La cantidad debe ser mayor que cero.");
        }

        if (cantidad > Stock)
        {
            throw new StockInsuficienteException(Nombre, Stock);
        }

        Stock -= cantidad;
    }

    public void AgregarStock(int cantidad)
    {
        if (cantidad <= 0)
        {
            throw new ArgumentException(
                "La cantidad debe ser mayor que cero.");
        }

        Stock += cantidad;
    }

    public override string ToString()
    {
        return $"Código: {Codigo} | Nombre: {Nombre} | " +
               $"Precio: {Precio:C} | Stock: {Stock}";
    }
}
