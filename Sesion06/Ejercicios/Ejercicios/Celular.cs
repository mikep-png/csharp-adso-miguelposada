using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicios
{
    public class Celular
    {
        public string Marca { get; set; }
        public int Bateria { get; private set; }

        public Celular(string marca)
        {
            Marca = marca;
            Bateria = 0;
        }

        public void Cargar(int porcentaje)
        {
            if (porcentaje < 0)
            {
                Console.WriteLine("El porcentaje debe ser mayor que cero.");
                return;
            }
            Bateria = Math.Min(100, Bateria + porcentaje);

            Console.WriteLine($"Celular cargado. Batería actual: {Bateria}%");
        }

        public bool Usar(int minutos)
        {
            if (minutos <= 0)
            {
                Console.WriteLine("Los mínutos deben ser mayor que cero.");
                return false;
            }

            if (Bateria < minutos)
            {
                Console.WriteLine("Batería insuficiente. No se puede utilizar el celular");
                return false;
            }

            Bateria -= minutos;

            Console.WriteLine($"Celular utilizado durante {minutos} minutos.");
            Console.WriteLine($"Batería restante {Bateria}%");

            return true;
        }

    }
}
