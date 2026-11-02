using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Usuario: ");
            string usuario = Console.ReadLine().ToLower().Trim();
            Console.Write("Clave: ");
            string clave = Console.ReadLine().ToLower().Trim();

            if (usuario == "admin" && clave == "1234")
            {
                Console.WriteLine("Bienvenido.");
                Console.WriteLine("Qué desea ver?: \n1.Calculadora con Switches\n2.Notas");
                int opc = Convert.ToInt32(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Console.WriteLine("Calculadora con Switch.");
                        Console.Write("Variable A: ");
                        string entrada = Console.ReadLine().Trim();
                        int a = Convert.ToInt32(entrada);
                        Console.Write("Variable B: ");
                        string entradaB = Console.ReadLine().Trim();
                        float b = Convert.ToInt32(entradaB);
                        Console.WriteLine("Qué operación desea ejecutar?: \n1.Sumar\n2.Restar\n3.Multiplicar\n4.Dividir\n5.Notas");
                        string op = Console.ReadLine().ToLower().Trim();
                        switch (op)
                        {
                            case "sumar":
                                Console.WriteLine($"Suma: {a + b}");
                                break;
                            case "restar":
                                Console.WriteLine($"Resta: {a - b}");
                                break;
                            case "multiplicar":
                                Console.WriteLine($"Multiplicación: {a * b}");
                                break;
                            case "dividir":
                                if (b == 0)
                                    Console.WriteLine("No se puede dividir entre 0.");
                                else
                                    Console.WriteLine($"División: {a / b}");
                                break;
                            default:
                                Console.WriteLine("Operación no válida");
                                break;
                        }
                        break;
                    case 2:
                        double nota = Convert.ToDouble(Console.ReadLine());
                        if (nota < 0 || nota > 5)
                            Console.WriteLine("La nota debe ser entre 0.0 y 5.0");
                        else
                        {
                            if (nota <= 3.0)
                                Console.WriteLine("Nota: Deficiente");
                            else if (nota < 4)
                                Console.WriteLine("Nota: Aceptable");
                            else if (nota < 4.6)
                                Console.WriteLine("Nota: Sobresaliente");
                            else
                                Console.WriteLine("Nota: Excelente");
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("Usuario o clave incorrectos.");
            }
        }
    }
}
