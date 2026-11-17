using System;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("--- 1. GENERADOR DE USUARIOS ---");

string nombre = "";
while (string.IsNullOrWhiteSpace(nombre) || nombre.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length < 2)
{
    Console.Write("Ingrese el nombre completo (Debe incluir nombre y apellido): ");
    nombre = Console.ReadLine();
}

string doc = "";
while (string.IsNullOrWhiteSpace(doc) || doc.Length < 2)
{
    Console.Write("Ingrese el documento de identidad (Mínimo 2 dígitos): ");
    doc = Console.ReadLine();
}

string usuario = GenerarUsuario(nombre, doc);
Console.WriteLine($"Usuario generado: {usuario}");

Console.WriteLine("\n--- 2. ANALIZADOR DE FRASES ---");

string fraseInput = "";
while (string.IsNullOrWhiteSpace(fraseInput))
{
    Console.Write("Ingrese una frase: ");
    fraseInput = Console.ReadLine();
}

AnalizarFrase(fraseInput);

    static string GenerarUsuario(string nombreCompleto, string documento)
{
    if (string.IsNullOrWhiteSpace(nombreCompleto) || string.IsNullOrWhiteSpace(documento))
        return string.Empty;

    string textoLimpio = QuitarTildes(nombreCompleto).ToLower();
    string[] partes = textoLimpio.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

    if (partes.Length < 2) return string.Empty;

    string inicialNombre = partes[0].Substring(0, 1);
    string primerApellido = partes[1];

    string ultimosDigitos = documento.Substring(documento.Length - 2);

    return $"{inicialNombre}{primerApellido}{ultimosDigitos}";
}

static void AnalizarFrase(string frase)
{
    if (string.IsNullOrWhiteSpace(frase))
    {
        Console.WriteLine("La frase está vacía.");
        return;
    }

    string[] palabras = frase.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    int totalPalabras = palabras.Length;

    Array.Reverse(palabras);

    StringBuilder constructorFrase = new StringBuilder();
    for (int i = 0; i < palabras.Length; i++)
    {
        constructorFrase.Append(palabras[i]);
        if (i < palabras.Length - 1)
        {
            constructorFrase.Append(" ");
        }
    }

    Console.WriteLine($"\nFrase original: \"{frase}\"");
    Console.WriteLine($"Cantidad de palabras: {totalPalabras}");
    Console.WriteLine($"Frase invertida: \"{constructorFrase.ToString()}\"");
}
static string QuitarTildes(string texto)
{
    return texto.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u")
                .Replace("Á", "A").Replace("É", "E").Replace("Í", "I").Replace("Ó", "O").Replace("Ú", "U")
                .Replace("ü", "u").Replace("Ü", "U");
}
