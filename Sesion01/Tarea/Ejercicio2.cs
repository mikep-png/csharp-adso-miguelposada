using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea
{
    internal class Ejercicio2
    {
        public static void Ejecutar()
        {
            Console.Write("Ingrese los grados Celsius: ");

            if (double.TryParse(Console.ReadLine(), out double celsius))
            {
                double fahrenheit = celsius * 9 / 5 + 32;
                Console.WriteLine($"{fahrenheit:F1} °F");
            }
            else
            {
                Console.WriteLine("Temperatura no válida.");
            }
        }
    }
}
