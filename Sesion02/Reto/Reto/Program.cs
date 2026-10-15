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
            int contador = 0;
            int pin = 0;
            int opcion = 0;
            double saldo = 500000;

            do
            {
                Console.Write("Escriba el pin: ");
                if (int.TryParse(Console.ReadLine().Trim(), out pin))
                {
                    contador++;

                    if (pin == 1234)
                    {
                        Console.WriteLine("Acceso concedido.");
                        do
                        {
                            do
                            {
                                Console.WriteLine("\nBienvenido al Cajero, Elija la opción deseada: \n1. Consultar saldo\n2. Depositar\n3. Retirar\n4. Salir");
                                Console.Write("Opción: ");
                                int.TryParse(Console.ReadLine().Trim(), out opcion);
                            } while (opcion < 1 || opcion > 4);

                            switch (opcion)
                            {
                                case 1:
                                    Console.WriteLine($"\nSaldo Actual: ${saldo:N2}");
                                    break;
                                case 2:
                                    Console.Write("\nIngrese la cantidad a depositar: $");
                                    if (double.TryParse(Console.ReadLine().Trim(), out double deposito))
                                    {
                                        if (deposito > 0)
                                        {
                                            saldo += deposito; 
                                            Console.WriteLine($"Depósito exitoso. Ha ingresado: ${deposito:N2} Pesos.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error: No se pueden depositar cantidades negativas o iguales a cero.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error: Entrada inválida. Por favor ingrese únicamente números.");
                                    }
                                    break;
                                case 3:
                                    Console.Write("\nIngrese la cantidad a retirar: $");
                                    double.TryParse(Console.ReadLine(), out double retiro);

                                    if (retiro % 10000 != 0)
                                    {
                                        Console.WriteLine("Error: El cajero solo entrega billetes en múltiplos de $10,000.");
                                    }
                                    else if (retiro > 0 && retiro <= saldo)
                                    {
                                        saldo -= retiro;
                                        Console.WriteLine($"Retiro exitoso. Ha retirado: ${retiro:N2}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Monto inválido o fondos insuficientes.");
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine("\nSaliendo del cajero... ¡Hasta luego!");
                                    break;
                            }

                        } while (opcion != 4); 

                        break; 
                    }
                    else
                    {
                        
                        if (contador >= 3)
                        {
                            Console.WriteLine("Tarjeta Bloqueada. Superó el límite de intentos.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"PIN incorrecto. Intentos restantes: {3 - contador}");
                        }
                    }
                }
            } while (true);

        }
    }
}
