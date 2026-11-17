using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea
{
    internal class Ejercicio3
    {
        public static void Ejecutar()
        {
            Console.Write("Ingrese la primera nota: ");
            bool valida1 = double.TryParse(Console.ReadLine(), out double nota1);

            Console.Write("Ingrese la segunda nota: ");
            bool valida2 = double.TryParse(Console.ReadLine(), out double nota2);

            Console.Write("Ingrese la tercera nota: ");
            bool valida3 = double.TryParse(Console.ReadLine(), out double nota3);

            if (valida1 && valida2 && valida3)
            {
                double promedio = (nota1 + nota2 + nota3) / 3;
                Console.WriteLine($"Promedio: {promedio:F1}");
            }
            else
            {
                Console.WriteLine("Debe ingresar tres notas válidas.");
            }
        }
    }
}
