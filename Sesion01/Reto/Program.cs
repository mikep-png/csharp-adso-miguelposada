using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Pedir los datos al usuario
            Console.Write("¿Cómo te llamas? ");
            string entrada = Console.ReadLine() ?? "";
            string nombre = string.IsNullOrWhiteSpace(entrada) ? "Invitado" : entrada;

            Console.Write("¿Cuál es tu programa de formación? ");
            entrada = Console.ReadLine() ?? "";
            string programa = string.IsNullOrWhiteSpace(entrada) ? "No especificado" : entrada;

            Console.Write("¿Cuál es tu número de ficha? ");
            entrada = Console.ReadLine() ?? "";
            string ficha = string.IsNullOrWhiteSpace(entrada) ? "No especificada" : entrada;

            Console.Write("Escribe una frase que te represente: ");
            entrada = Console.ReadLine() ?? "";
            string frase = string.IsNullOrWhiteSpace(entrada) ? "Nunca dejar de aprender" : entrada;

            // 2. Mostrar el título de la tarjeta en color cian
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("|              MI TARJETA                  |");
            Console.ResetColor();

            // 3. Mostrar los datos utilizando interpolación de cadenas
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"| Nombre:    {nombre} |");
            Console.WriteLine($"| Programa:  {programa} |");
            Console.WriteLine($"| Ficha:     {ficha} |");
            Console.ResetColor();

            // 4. Mostrar la frase personal en otro color
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"| Frase: {frase}");
            Console.ResetColor();

            // 5. Despedida
            Console.WriteLine("\n¡Gracias por conocer mi tarjeta!");
        }
    }
}
