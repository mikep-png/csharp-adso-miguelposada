using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== TAREA SESIÓN 01 =====");
            Console.WriteLine("1. Segundos a reloj");
            Console.WriteLine("2. Celsius a Fahrenheit");
            Console.WriteLine("3. Promedio de tres notas");
            Console.Write("Seleccione un ejercicio: ");

            string opcion = Console.ReadLine() ?? "";

            switch (opcion)
            {
                case "1":
                    Ejercicio1.Ejecutar();
                    break;

                case "2":
                    Ejercicio2.Ejecutar();
                    break;

                case "3":
                    Ejercicio3.Ejecutar();
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }
    }
}
