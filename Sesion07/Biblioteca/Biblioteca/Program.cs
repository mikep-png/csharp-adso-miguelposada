using Biblioteca;

var libro1 = new Libro("La Odisea", "Homero", 320);
var libro2 = new Libro("La Vorágine", "Jose Eustasio Rivera", 320);

Console.WriteLine(libro1.Titulo);
libro1.Prestar();
Console.WriteLine(libro1.Disponible ? "Disponible" : "No disponible");

Console.WriteLine(libro1);

var raro = new Libro("", "Nadie", -50);
//libro1.Disponible = true // ¡lo "devolvió" sin pasar por Devolver!

//List<Libro> biblioteca =
//    [
//        new Libro("La Odisea", "Homero", 320),
//        new Libro("La Vorágine", "Jose Eustasio Rivera", 220),
//        new Libro("María", "Jorge Isaacs", 288),
//        new Libro("Divina comedia", "Dante Alighieri", 230)
//    ];

//var disponibles = biblioteca.Where(l => l.Disponible).ToList();

//var masLargo = biblioteca.MaxBy(l => l.Paginas);
//var masCorto = biblioteca.MinBy(l => l.Paginas);

//Console.WriteLine($"El más largo es: {masLargo?.Titulo}");
//Console.WriteLine($"El más corto es: {masCorto?.Titulo}");