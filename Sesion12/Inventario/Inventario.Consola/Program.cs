
using Inventario.Datos;
using Inventario.Modelos;
using Inventario.Servicios;

// Repositorio conectado a SQLite mediante Entity Framework.
IRepositorioProductos repositorio = new RepositorioEf();

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
    Console.WriteLine("9. Filtrar productos por categoría");
    Console.WriteLine("10. Resumen por categoría");

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

            case "9":
                FiltrarPorCategoria();
                break;

            case "10":
                MostrarResumenPorCategoria();
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

// REGISTRAR PRODUCTO
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

    // Mostrar categorías disponibles.
    List<Categoria> categorias = servicio.ObtenerCategorias();

    Console.WriteLine("\n=== CATEGORÍAS DISPONIBLES ===");

    foreach (Categoria categoria in categorias)
    {
        Console.WriteLine($"{categoria.Id}. {categoria.Nombre}");
    }

    Console.Write("Selecciona el ID de la categoría (Enter para ninguna): ");
    string entradaCategoria = Console.ReadLine() ?? "";

    Producto producto = new Producto(codigo, nombre, precio, stock);

    if (!string.IsNullOrWhiteSpace(entradaCategoria))
    {
        if (!int.TryParse(entradaCategoria, out int categoriaId))
        {
            Console.WriteLine("ID de categoría inválido.");
            return;
        }

        if (!categorias.Any(c => c.Id == categoriaId))
        {
            Console.WriteLine("La categoría seleccionada no existe.");
            return;
        }

        producto.CambiarCategoria(categoriaId);
    }

    servicio.Agregar(producto);

    Console.WriteLine("Producto registrado correctamente.");
}

// AGREGAR STOCK
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

// VENDER PRODUCTO
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

// MOSTRAR INVENTARIO
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
        MostrarDetalleProducto(producto);
    }
}

// MOSTRAR PRODUCTOS CON STOCK BAJO
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
        MostrarDetalleProducto(producto);
    }
}

// BUSCAR PRODUCTOS
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
        MostrarDetalleProducto(producto);
    }
}

// ELIMINAR PRODUCTO
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
    MostrarDetalleProducto(producto);

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

// FILTRAR POR CATEGORÍA
void FiltrarPorCategoria()
{
    Console.WriteLine("\n=== FILTRAR POR CATEGORÍA ===");

    List<Categoria> categorias = servicio.ObtenerCategorias();

    foreach (Categoria categoria in categorias)
    {
        Console.WriteLine($"{categoria.Id}. {categoria.Nombre}");
    }

    Console.Write("\nEscribe el ID de la categoría: ");

    if (!int.TryParse(Console.ReadLine(), out int categoriaId))
    {
        Console.WriteLine("ID inválido.");
        return;
    }

    if (!categorias.Any(c => c.Id == categoriaId))
    {
        Console.WriteLine("La categoría no existe.");
        return;
    }

    List<Producto> productos =
        servicio.FiltrarPorCategoria(categoriaId);

    if (productos.Count == 0)
    {
        Console.WriteLine("No hay productos en esta categoría.");
        return;
    }

    Console.WriteLine("\n=== PRODUCTOS ENCONTRADOS ===");

    foreach (Producto producto in productos)
    {
        MostrarDetalleProducto(producto);
    }
}

// RESUMEN POR CATEGORÍA
void MostrarResumenPorCategoria()
{
    Console.WriteLine("\n=== RESUMEN DEL INVENTARIO POR CATEGORÍA ===");

    List<ResumenCategoria> resumen =
        servicio.ObtenerResumenPorCategoria();

    if (resumen.Count == 0)
    {
        Console.WriteLine("No hay productos para generar el resumen.");
        return;
    }

    foreach (ResumenCategoria item in resumen)
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"Categoría: {item.NombreCategoria}");
        Console.WriteLine($"ID: {item.CategoriaId?.ToString() ?? "Sin asignar"}");
        Console.WriteLine($"Cantidad de productos: {item.CantidadProductos}");
        Console.WriteLine($"Valor total del inventario: {item.ValorTotal:C2}");
    }

    Console.WriteLine("--------------------------------");
}

// MOSTRAR DETALLE DE UN PRODUCTO
void MostrarDetalleProducto(Producto producto)
{
    Console.WriteLine(producto);
    Console.WriteLine(
        $"Categoría: {producto.Categoria?.Nombre ?? "Sin categoría"}");
    Console.WriteLine("--------------------------------");
}
