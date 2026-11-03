using System.Data;
using System.Text;
Console.OutputEncoding = Encoding.UTF8;

string contra;
bool esFuerte = false;

while (!esFuerte)
{
    Console.WriteLine("\nEscriba la contraseña: ");
    contra = Console.ReadLine();

    esFuerte = EvaluarContra(contra);

    if (!esFuerte)
    {
        Console.WriteLine("La contraseña no es lo suficientemente fuerte.");
    }
}
Console.WriteLine("\n¡Contraseña aceptada con éxito!");

static bool EvaluarContra(string texto)
{
    if (texto == null) return false;

    int mayusculas = 0, minusculas = 0, numeros = 0, espacios = 0, especiales = 0;

    foreach (char c in texto)
    {
        if (char.IsDigit(c))
        {
            numeros++;
        }
        else if (char.IsUpper(c))
        {
            mayusculas++;
        }

        else if (char.IsLower(c))
        {
            minusculas++;
        }
        else if (char.IsWhiteSpace(c))
        {
            espacios++;
        }
        else if (char.IsPunctuation(c) || char.IsSymbol(c))
        {
            especiales++;
        }
    }

    bool longitud = texto.Length >= 8;
    bool mayuscula = mayusculas > 0;
    bool minuscula = minusculas > 0;
    bool numero = numeros > 0;
    bool especial = especiales > 0;
    bool sinespacios = espacios == 0;

    string valorlongitud = longitud ? "✔️" : "✖️";
    string valormayuscula = mayuscula ? "✔️" : "✖️";
    string valorminuscula = minuscula ? "✔️" : "✖️";
    string valornumero = numero ? "✔️" : "✖️";
    string valorespecial = especial ? "✔️" : "✖️";
    string valorsinespacios = sinespacios ? "✔️" : "✖️";

    int sumavalores = 0;

    if (longitud) sumavalores++;
    if (mayuscula) sumavalores++;
    if (minuscula) sumavalores++;
    if (numero) sumavalores++;
    if (especial) sumavalores++;
    if (sinespacios) sumavalores++;

    Console.WriteLine($"\nResultados de la evaluación:");
    Console.WriteLine($"{valorlongitud} Mínimo 8 caracteres.");
    Console.WriteLine($"{valorminuscula} Al menos una minúscula.");
    Console.WriteLine($"{valormayuscula} Al menos una mayúscula.");
    Console.WriteLine($"{valornumero} Contiene un número.");
    Console.WriteLine($"{valorespecial} Contiene un caracter especial.");
    Console.WriteLine($"{valorsinespacios} No tiene espacios.");

    string nivel;
    if (sumavalores == 6) nivel = "Fuerte";
    else if (sumavalores >= 4) nivel = "Media";
    else nivel = "Débil";

    Console.WriteLine($"\nNivel de seguridad: {nivel} ({sumavalores}/6 reglas cumplidas)");

    return nivel == "Fuerte";
}