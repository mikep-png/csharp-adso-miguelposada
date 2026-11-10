
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
    Console.WriteLine("6. Salir");
    Console.Write("Seleccione una opción: ");

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
                continuar = false;
                Console.WriteLine("Programa finalizado.");
                break;

            default:
                Console.WriteLine("Opción no válida.");
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
