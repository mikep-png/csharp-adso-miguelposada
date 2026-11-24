
namespace Inventario.Modelos;

public class ResumenCategoria
{
    public int? CategoriaId { get; set; }

    public string NombreCategoria { get; set; } = string.Empty;

    public int CantidadProductos { get; set; }

    public decimal ValorTotal { get; set; }
}
