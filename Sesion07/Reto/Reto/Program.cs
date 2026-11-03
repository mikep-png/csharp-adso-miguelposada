using System.Text;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        RepositorioInventario repo = new RepositorioInventario();
        List<Producto> inventario = repo.Cargar();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n--- MENÚ DE TIENDA PERSISTENTE ---");
            Console.WriteLine("1. Registrar producto");
            Console.WriteLine("2. Agregar stock");
            Console.WriteLine("3. Vender producto");
            Console.WriteLine("4. Ver inventario completo");
            Console.WriteLine("5. Ver productos con menos de 5 unidades");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    try
                    {
                        Console.Write("Código: ");
                        string cod = Console.ReadLine();
                        Console.Write("Nombre: ");
                        string nom = Console.ReadLine();
                        Console.Write("Precio: ");
                        decimal pre = decimal.Parse(Console.ReadLine());
                        Console.Write("Stock inicial: ");
                        int stk = int.Parse(Console.ReadLine());

                        if (inventario.Any(p => p.Codigo.Equals(cod, StringComparison.OrdinalIgnoreCase)))
                        {
                            Console.WriteLine("❌ Ya existe un producto con ese código.");
                            break;
                        }

                        Producto nuevo = new Producto(cod, nom, pre, stk);
                        inventario.Add(nuevo);
                        repo.Guardar(inventario);
                        Console.WriteLine("✅ Producto registrado exitosamente.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"❌ Error: {ex.Message}");
                    }
                    break;

                case "2":
                    try
                    {
                        Console.Write("Ingrese el código del producto: ");
                        string codBuscar = Console.ReadLine();
                        Producto prod = inventario.FirstOrDefault(p => p.Codigo.Equals(codBuscar, StringComparison.OrdinalIgnoreCase));

                        if (prod == null)
                        {
                            Console.WriteLine("❌ Producto no encontrado.");
                            break;
                        }

                        Console.Write("Cantidad de stock a agregar: ");
                        int cantAgregar = int.Parse(Console.ReadLine());
                        prod.AgregarStock(cantAgregar);
                        repo.Guardar(inventario);
                        Console.WriteLine($"✅ Stock actualizado. Nuevo stock: {prod.Stock}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"❌ Error: {ex.Message}");
                    }
                    break;

                case "3":
                    try
                    {
                        Console.Write("Ingrese el código del producto a vender: ");
                        string codVenta = Console.ReadLine();
                        Producto prodVenta = inventario.FirstOrDefault(p => p.Codigo.Equals(codVenta, StringComparison.OrdinalIgnoreCase));

                        if (prodVenta == null)
                        {
                            Console.WriteLine("❌ Producto no encontrado.");
                            break;
                        }

                        Console.Write("Cantidad a vender: ");
                        int cantVenta = int.Parse(Console.ReadLine());

                        prodVenta.Vender(cantVenta);
                        repo.Guardar(inventario);
                        Console.WriteLine($"✅ Venta realizada. Unidades restantes: {prodVenta.Stock}");
                    }
                    catch (StockInsuficienteException ex)
                    {
                        Console.WriteLine($"⚠️ {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"❌ Error: {ex.Message}");
                    }
                    break;

                case "4":
                    Console.WriteLine("\n--- INVENTARIO COMPLETO ---");
                    if (!inventario.Any())
                    {
                        Console.WriteLine("El inventario está vacío.");
                        break;
                    }
                    foreach (var p in inventario)
                    {
                        Console.WriteLine($"Código: {p.Codigo} | Nombre: {p.Nombre} | Precio: {p.Precio:C0} | Stock: {p.Stock}");
                    }
                    break;

                case "5":
                    Console.WriteLine("\n--- ALERTA: BAJO STOCK (< 5 UNIDADES) ---");
                    var bajoStock = inventario.Where(p => p.Stock < 5).ToList();
                    if (!bajoStock.Any())
                    {
                        Console.WriteLine("No hay productos con menos de 5 unidades.");
                        break;
                    }
                    foreach (var p in bajoStock)
                    {
                        Console.WriteLine($"⚠️ Código: {p.Codigo} | Nombre: {p.Nombre} | Stock: {p.Stock}");
                    }
                    break;

                case "6":
                    salir = true;
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("❌ Opción inválida.");
                    break;
            }
        }
    }
}

public class Producto
{
    private string _codigo;
    private string _nombre;
    private decimal _precio;
    private int _stock;

    public string Codigo
    {
        get => _codigo;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El código es obligatorio.");
            _codigo = value.Trim().ToUpper();
        }
    }

    public string Nombre
    {
        get => _nombre;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre no puede estar vacío.");
            _nombre = value.Trim();
        }
    }

    public decimal Precio
    {
        get => _precio;
        set
        {
            if (value <= 0)
                throw new ArgumentException("El precio debe ser mayor que 0.");
            _precio = value;
        }
    }

    public int Stock
    {
        get => _stock;
        private set
        {
            if (value < 0)
                throw new ArgumentException("El stock no puede ser negativo.");
            _stock = value;
        }
    }

    public Producto(string codigo, string nombre, decimal precio, int stock)
    {
        Codigo = codigo;
        Nombre = nombre;
        Precio = precio;
        Stock = stock;
    }

    public void AgregarStock(int cantidad)
    {
        if (cantidad <= 0)
            throw new ArgumentException("La cantidad a agregar debe ser mayor que 0.");
        Stock += cantidad;
    }

    public void Vender(int cantidad)
    {
        if (cantidad <= 0)
            throw new ArgumentException("La cantidad a vender debe ser mayor que 0.");
        if (cantidad > Stock)
            throw new StockInsuficienteException($"Stock insuficiente para {Nombre}. Solicitado: {cantidad}, Disponible: {Stock}");
        Stock -= cantidad;
    }
}

public class RepositorioInventario
{
    private const string Archivo = "inventario.json";
    private const string ArchivoCorrupto = "inventario_danado.json";

    public List<Producto> Cargar()
    {
        if (!File.Exists(Archivo))
        {
            return new List<Producto>();
        }

        try
        {
            string json = File.ReadAllText(Archivo);
            return JsonSerializer.Deserialize<List<Producto>>(json) ?? new List<Producto>();
        }
        catch (JsonException)
        {
            Console.WriteLine($"\n⚠️ ALERTA: El archivo '{Archivo}' estaba dañado.");
            try
            {
                if (File.Exists(Archivo))
                {
                    File.Copy(Archivo, ArchivoCorrupto, true);
                    File.Delete(Archivo);
                    Console.WriteLine($"💾 Se guardó una copia de respaldo en '{ArchivoCorrupto}'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"No se pudo crear la copia de respaldo: {ex.Message}");
            }
            Console.WriteLine("El inventario iniciará vacío.\n");
            return new List<Producto>();
        }
    }

    public void Guardar(List<Producto> inventario)
    {
        try
        {
            string json = JsonSerializer.Serialize(
                inventario,
                new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(Archivo, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error crítico al guardar el archivo: {ex.Message}");
        }
    }
}

public class StockInsuficienteException : Exception
{
    public StockInsuficienteException(string mensaje) : base(mensaje) { }
}