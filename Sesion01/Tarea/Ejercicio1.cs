using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea
{
    internal class Ejercicio1
    {
        public static void Ejecutar()
        {
            Console.Write("Ingrese los segundos: ");

            if (int.TryParse(Console.ReadLine(), out int total) && total >= 0)
            {
                int horas = total / 3600;
                int minutos = (total % 3600) / 60;
                int segundos = total % 60;

                Console.WriteLine($"{horas} h {minutos} min {segundos} s");
            }
            else
            {
                Console.WriteLine("Ingrese un número entero válido.");
            }
        }
    }
}
