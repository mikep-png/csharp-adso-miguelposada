List<int> numeros = [12, 45, 7, 88, 23, 56, 3, 91, 40];

var pares = numeros.Where(n => n % 2 == 0).ToList();
var top3 = numeros.OrderByDescending(n => n).Take(3).ToList();

Console.WriteLine($"Pares: {string.Join(", ", pares)}");
Console.WriteLine($"Top 3: {string.Join(", ", top3)}");
Console.WriteLine($"Suma: {numeros.Sum()} · Promedio: {numeros.Average():N1}");
Console.WriteLine($"¿Alguno mayor a 90? {numeros.Any(n => n > 90)}");

List<Producto> productos =
[
    new("Cuaderno", "Papelería", 6500m, 40),
    new("Mouse", "Tecnología", 45000m, 3),
    new("USB 64 GB", "Tecnología", 38000m, 15)
];

var baratos = productos.Where(p => p.Precio < 10000m);
var masCaro = productos.MaxBy(p => p.Precio);
decimal valorInventario = productos.Sum(p => p.Precio * p.Stock);

record Producto(string Nombre, string Categoria, decimal Precio, int Stock);   // SIEMPRE al final

var porCategoria = productos
    .GroupBy(p => p.Categoria)
    .Select(g => new { Categoria = g.Key, Unidades = g.Sum(p => p.Stock) });

foreach (var c in porCategoria)
{
    Console.WriteLine($"{c.Categoria,-12} {c.Unidades} unidades");
}
