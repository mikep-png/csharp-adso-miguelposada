using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

List<Producto> inventario = [
    new("P01", "Portátil ASUS", 3500000m, 5),
    new("M01", "Mouse Logi", 90000m, 15),
    new("T01", "Teclado Redragon", 180000m, 10)
];

List<LineaVenta> carrito = [];
bool salir = false;

while (!salir)
{
    Console.WriteLine("\n--- MENÚ DE GESTIÓN ---");
    Console.WriteLine("1. Registrar producto");
    Console.WriteLine("2. Agregar stock");
    Console.WriteLine("3. Vender al carrito");
    Console.WriteLine("4. Ver carrito y total");
    Console.WriteLine("5. Ver inventario");
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

                Producto nuevo = new Producto(cod, nom, pre, stk);
                inventario.Add(nuevo);
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
                string codBuscar = Console.ReadLine().ToUpper();
                Producto prod = inventario.FirstOrDefault(p => p.Codigo == codBuscar);

                if (prod == null)
                {
                    Console.WriteLine("❌ Producto no encontrado.");
                    break;
                }

                Console.Write("Cantidad de stock a agregar: ");
                int cantAgregar = int.Parse(Console.ReadLine());
                prod.AgregarStock(cantAgregar);
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
                string codVenta = Console.ReadLine().ToUpper();
                Producto prodVenta = inventario.FirstOrDefault(p => p.Codigo == codVenta);

                if (prodVenta == null)
                {
                    Console.WriteLine("❌ Producto no encontrado.");
                    break;
                }

                Console.Write("Cantidad a vender: ");
                int cantVenta = int.Parse(Console.ReadLine());

                prodVenta.Vender(cantVenta);
                decimal subtotal = cantVenta * prodVenta.Precio;

                carrito.Add(new LineaVenta(prodVenta.Codigo, prodVenta.Nombre, cantVenta, subtotal));
                Console.WriteLine("✅ Agregado al carrito correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
            break;

        case "4":
            Console.WriteLine("\n--- ELEMENTOS EN EL CARRITO ---");
            if (!carrito.Any())
            {
                Console.WriteLine("El carrito está vacío.");
                break;
            }

            foreach (var item in carrito)
            {
                Console.WriteLine($"- {item.Nombre} ({item.Codigo}) x{item.Cantidad} - Subtotal: {item.Subtotal:C0}");
            }

            decimal totalCarrito = carrito.Sum(l => l.Subtotal);
            Console.WriteLine($"TOTAL A PAGAR: {totalCarrito:C0}");

            Console.Write("\n¿Desea remover un producto rechazado del carrito? (S/N): ");
            if (Console.ReadLine().ToUpper() == "S")
            {
                Console.Write("Ingrese el código del producto a remover: ");
                string codRechazado = Console.ReadLine().ToUpper();

                LineaVenta lineaRemover = carrito.FirstOrDefault(l => l.Codigo == codRechazado);

                if (lineaRemover == null)
                {
                    Console.WriteLine("❌ Ese producto no está en el carrito.");
                    break;
                }

                Producto prodInventario = inventario.FirstOrDefault(p => p.Codigo == codRechazado);
                if (prodInventario != null)
                {
                    prodInventario.AgregarStock(lineaRemover.Cantidad);
                }

                carrito.Remove(lineaRemover);
                Console.WriteLine($"✅ Producto {lineaRemover.Nombre} removido y devuelto al inventario.");
            }
            break;

        case "5":
            Console.WriteLine("\n--- INVENTARIO ACTUAL ---");
            foreach (var p in inventario)
            {
                Console.WriteLine($"Código: {p.Codigo} | Nombre: {p.Nombre} | Precio: {p.Precio:C0} | Stock: {p.Stock}");
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
            throw new InvalidOperationException($"Stock insuficiente. Solo quedan {Stock} unidades.");
        Stock -= cantidad;
    }
}

public record LineaVenta(string Codigo, string Nombre, int Cantidad, decimal Subtotal);


