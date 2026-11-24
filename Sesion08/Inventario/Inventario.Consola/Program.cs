
using Inventario.Datos;
using Inventario.Modelos;
using Inventario.Servicios;

// Repositorio que almacena los datos en JSON.
IRepositorioProductos repositorio = new RepositorioJson();

// Para probar el nivel extra, cambia la línea anterior por:
// IRepositorioProductos repositorio = new RepositorioMemoria();

ServicioInventario servicio = new ServicioInventario(repositorio);

bool continuar = true;

while (continuar)
{
    Console.WriteLine("\n===== SISTEMA DE INVENTARIO =====");
    Console.WriteLine("1. Registrar producto");
    Console.WriteLine("2. Agregar stock");
    Console.WriteLine("3. Vender producto");
    Console.WriteLine("4. Ver inventario");
    Console.WriteLine("5. Productos con stock bajo");
    Console.WriteLine("6. Buscar producto por texto");
    Console.WriteLine("7. Eliminar producto");
    Console.WriteLine("8. Salir");

    string opcion = Console.ReadLine() ?? "";

    try
    {
        switch (opcion)
        {
            case "1":
                RegistrarProducto();
                break;

            case "2":
                AgregarStock();
                break;

            case "3":
                VenderProducto();
                break;

            case "4":
                MostrarInventario();
                break;

            case "5":
                MostrarStockBajo();
                break;

            case "6":
                BuscarProducto();
                break;

            case "7":
                EliminarProducto();
                break;

            case "8":
                continuar = false;
                Console.WriteLine("Programa finalizado.");
                break;
        }
    }
    catch (StockInsuficienteException ex)
    {
        Console.WriteLine($"Error de inventario: {ex.Message}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error inesperado: {ex.Message}");
    }
}

void RegistrarProducto()
{
    Console.WriteLine("\n=== REGISTRAR PRODUCTO ===");

    Console.Write("Código: ");
    string codigo = Console.ReadLine() ?? "";

    Console.Write("Nombre: ");
    string nombre = Console.ReadLine() ?? "";

    Console.Write("Precio: ");

    if (!decimal.TryParse(Console.ReadLine(), out decimal precio))
    {
        Console.WriteLine("Precio inválido.");
        return;
    }

    Console.Write("Stock inicial: ");

    if (!int.TryParse(Console.ReadLine(), out int stock))
    {
        Console.WriteLine("Stock inválido.");
        return;
    }

    Producto producto = new Producto(codigo, nombre, precio, stock);

    servicio.Agregar(producto);

    Console.WriteLine("Producto registrado correctamente.");
}

void AgregarStock()
{
    Console.WriteLine("\n=== AGREGAR STOCK ===");

    Console.Write("Código: ");
    string codigo = Console.ReadLine() ?? "";

    Console.Write("Cantidad: ");

    if (!int.TryParse(Console.ReadLine(), out int cantidad))
    {
        Console.WriteLine("Cantidad inválida.");
        return;
    }

    servicio.AgregarStock(codigo, cantidad);

    Console.WriteLine("Stock actualizado correctamente.");
}

void VenderProducto()
{
    Console.WriteLine("\n=== VENDER PRODUCTO ===");

    Console.Write("Código: ");
    string codigo = Console.ReadLine() ?? "";

    Console.Write("Cantidad: ");

    if (!int.TryParse(Console.ReadLine(), out int cantidad))
    {
        Console.WriteLine("Cantidad inválida.");
        return;
    }

    servicio.Vender(codigo, cantidad);

    Console.WriteLine("Venta realizada correctamente.");
}

void MostrarInventario()
{
    Console.WriteLine("\n=== INVENTARIO COMPLETO ===");

    List<Producto> productos = servicio.Listar();

    if (productos.Count == 0)
    {
        Console.WriteLine("No hay productos registrados.");
        return;
    }

    foreach (Producto producto in productos)
    {
        Console.WriteLine(producto);
    }
}

void MostrarStockBajo()
{
    Console.WriteLine("\n=== PRODUCTOS CON STOCK BAJO ===");

    List<Producto> productos = servicio.StockBajo();

    if (productos.Count == 0)
    {
        Console.WriteLine("No hay productos con stock bajo.");
        return;
    }

    foreach (Producto producto in productos)
    {
        Console.WriteLine(producto);
    }
}

void BuscarProducto()
{
    Console.WriteLine("\n=== BUSCAR PRODUCTO ===");

    Console.Write("Escribe el nombre o código: ");
    string texto = Console.ReadLine() ?? "";

    List<Producto> productos = servicio.BuscarPorTexto(texto);

    if (productos.Count == 0)
    {
        Console.WriteLine("No se encontraron productos.");
        return;
    }

    Console.WriteLine("\n=== RESULTADOS DE BÚSQUEDA ===");

    foreach (Producto producto in productos)
    {
        Console.WriteLine(producto);
    }
}

void EliminarProducto()
{
    Console.WriteLine("\n=== ELIMINAR PRODUCTO ===");

    Console.Write("Código del producto: ");
    string codigo = Console.ReadLine() ?? "";

    Producto? producto = servicio.Listar()
        .FirstOrDefault(p =>
            p.Codigo.Equals(
                codigo,
                StringComparison.OrdinalIgnoreCase
            )
        );

    if (producto == null)
    {
        Console.WriteLine("Producto no encontrado.");
        return;
    }

    Console.WriteLine("\nProducto seleccionado:");
    Console.WriteLine(producto);

    Console.Write("¿Seguro que deseas eliminarlo? (s/n): ");
    string confirmacion = Console.ReadLine() ?? "";

    if (confirmacion.Equals("s", StringComparison.OrdinalIgnoreCase))
    {
        servicio.Eliminar(codigo);
        Console.WriteLine("Producto eliminado correctamente.");
    }
    else
    {
        Console.WriteLine("Eliminación cancelada.");
    }
}