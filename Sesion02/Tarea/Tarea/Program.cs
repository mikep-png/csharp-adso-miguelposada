using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tarea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int secreto = random.Next(1, 101);
            int intentos = 0;
            int numero = 0;
            bool adivino = false;

            do
            {
                Console.Write("Adivine el número (1 al 100): ");
                if (int.TryParse(Console.ReadLine().Trim(), out numero))
                {
                    intentos++;

                    if (numero == secreto)
                    {
                        Console.WriteLine("\n¡¡¡Adivinó el número, Felicitaciones!!!.");
                        Console.WriteLine($"Intentos totales: {intentos}");
                        adivino = true;
                        break;
                    }
                    else if (numero > secreto)
                    {
                        Console.WriteLine("El número ingresado es MAYOR al número secreto.");
                    }
                    else if (numero < secreto)
                    {
                        Console.WriteLine("El número ingresado es MENOR al número secreto.");
                    }

                    if (intentos < 7)
                    {
                        Console.WriteLine($"Le quedan: {7 - intentos} intentos.\n");
                    }
                }
            } while (intentos < 7);

            if (!adivino)
            {
                Console.WriteLine($"\nIntentos agotados. El número correcto era: {secreto}");
            }

        }
    }
}
