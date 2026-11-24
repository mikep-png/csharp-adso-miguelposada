
namespace Inventario.Modelos;

public class Categoria
{
    public int Id { get; set; }

    public string Nombre { get; set; } = "";

    // Una categoría puede tener muchos productos.
    public List<Producto> Productos { get; set; } = [];

    // Permite mostrar el nombre en los ComboBox y las grillas.
    public override string ToString()
    {
        return Nombre;
    }
}
