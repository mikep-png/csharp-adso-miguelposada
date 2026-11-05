using Biblioteca;

List<Libro> biblioteca =
[
    new Libro("Cien años de soledad", "Gabriel García Márquez", 471),
    new Libro("La vorágine", "José Eustasio Rivera", 320),
    new Libro("María", "Jorge Isaacs", 288)
];
List<Prestamo> historial = [];

Console.Write("Ingrese el título del libro: ");
string titulo = Console.ReadLine() ?? "";
Console.Write("Ingrese el nombre del autor: ");
string autor = Console.ReadLine() ?? "";
Console.Write("Ingrese la cantidad de páginas: ");
int paginas = Convert.ToInt32(Console.ReadLine() ?? "");


try
{
    biblioteca.Add(new Libro(titulo, autor, paginas));
    Console.WriteLine($"Libro {titulo} agregado correctamente");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"✘ {ex.Message}");
}

Libro maria = biblioteca[0];
if (maria.Prestar())
    historial.Add(new Prestamo(maria.Titulo, "Cien años de solidad", DateTime.Now));

Console.WriteLine(maria.Prestar() ? "Prestado" : "✘ Ya estaba prestado");

foreach (Libro libro in biblioteca) Console.WriteLine(libro);
Console.WriteLine($"Libros largos: {biblioteca.Count(l => l.EsLargo)}");
foreach (Prestamo p in historial) Console.WriteLine(p);