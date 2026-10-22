//Crear una lista
List<string> compras = ["Arroz", "Leche", "Leche"];
compras.Add("Café"); //Permite agregar a una lista
compras.Remove("Leche"); //Permite eliminar a una lista
Console.WriteLine($"Tienes {compras.Count} productos");
compras.Sort(); //Ordena la lista

Console.WriteLine(string.Join(", ", compras));

Dictionary<string, string> agenda = new(StringComparer.OrdinalIgnoreCase);
agenda["Ana"] = "3001234567";
agenda["Luis"] = "3109876543";

if (agenda.TryGetValue("ana", out string? telefono))
{
    Console.WriteLine($"Ana: {telefono}");
}

foreach (var (nombre, tel) in agenda)
{
    Console.WriteLine($"{nombre}: {tel}");
}

//Diccionario con listas adentro
Dictionary<string, List<double>> notas = new(StringComparer.OrdinalIgnoreCase);
notas["Ana"] = [];          // al registrar, crea la lista vacía
notas["Ana"].Add(4.5);
notas["Ana"].Add(3.8);

foreach (var (nombre, nota) in notas)
{
    Console.WriteLine($"{nombre}: {string.Join(" - ", nota)}");
}

//static decimal LeerDecimal(string mensaje)
//{
//    Console.Write(mensaje);
//    decimal valor;
//    while (!decimal.TryParse(Console.ReadLine(), out valor))
//    {
//        Console.Write("Valor no válido. Intenta de nuevo\nDigite un número decimal: ");
//    }
//    return valor;

//}

//static int LeerEntero(string mensaje)
//{
//    Console.Write(mensaje);
//    int valor;
//    while (!int.TryParse(Console.ReadLine(), out valor))
//    {
//        Console.Write("Valor no válido. Intenta de nuevo\nDigite un número entero: ");
//    }
//    return valor;
//}