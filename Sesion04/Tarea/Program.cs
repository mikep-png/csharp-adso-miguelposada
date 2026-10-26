using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

List<Venta> ventas =
[
    new("Portátil", "Medellín", 2, 2_800_000m),
    new("Mouse", "Bogotá", 10, 45_000m),
    new("Teclado", "Cali", 5, 120_000m),
    new("Monitor", "Medellín", 3, 750_000m),
    new("Mouse", "Medellín", 8, 45_000m),
    new("Portátil", "Bogotá", 1, 2_800_000m),
    new("Diadema", "Cali", 6, 180_000m),
    new("Monitor", "Bogotá", 2, 750_000m),
    new("Teclado", "Medellín", 4, 120_000m),
    new("Diadema", "Bogotá", 3, 180_000m),
    new("Portátil", "Cali", 2, 2_800_000m),
    new("Mouse", "Cali", 12, 45_000m)
];

decimal totalVendido = ventas.Sum(v => v.Cantidad * v.PrecioUnitario);
decimal promedioPorVenta = ventas.Average(v => v.Cantidad * v.PrecioUnitario);

var ventasPorCiudad = ventas
    .GroupBy(v => v.Ciudad)
    .Select(g => new { Ciudad = g.Key, Total = g.Sum(v => v.Cantidad * v.PrecioUnitario) })
    .OrderByDescending(c => c.Total);

var top3ProductosIngresos = ventas
    .GroupBy(v => v.Producto)
    .Select(g => new { Producto = g.Key, Ingresos = g.Sum(v => v.Cantidad * v.PrecioUnitario) })
    .OrderByDescending(p => p.Ingresos)
    .Take(3);

var productoMasVendidoUnidades = ventas
    .GroupBy(v => v.Producto)
    .Select(g => new { Producto = g.Key, Unidades = g.Sum(v => v.Cantidad) })
    .OrderByDescending(p => p.Unidades)
    .FirstOrDefault();

Console.WriteLine($"Total Vendido: {totalVendido:C0}");
Console.WriteLine($"Promedio por Venta: {promedioPorVenta:C0}\n");

Console.WriteLine("--- Ventas por Ciudad (Mayor a Menor) ---");
foreach (var c in ventasPorCiudad)
{
    Console.WriteLine($"- {c.Ciudad}: {c.Total:C0}");
}

Console.WriteLine("\n--- Top 3 Productos por Ingresos ---");
foreach (var p in top3ProductosIngresos)
{
    Console.WriteLine($"- {p.Producto}: {p.Ingresos:C0}");
}

Console.WriteLine("\n--- Producto más Vendido en Unidades ---");
if (productoMasVendidoUnidades != null)
{
    Console.WriteLine($"- {productoMasVendidoUnidades.Producto} ({productoMasVendidoUnidades.Unidades} unidades)");
}

record Venta(string Producto, string Ciudad, int Cantidad, decimal PrecioUnitario);
