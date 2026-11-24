
using System;
using System.Collections.Generic;
using System.Linq;

// ============================================================
// SESION 6: HERENCIA, INTERFACES Y POLIMORFISMO
// EJEMPLO PRINCIPAL: VEHICULOS DE UN PEAJE
// ============================================================


// ============================================================
// PARTE 1: CLASE ABSTRACTA VEHICULO
// ============================================================

// Una clase abstracta sirve como modelo para otras clases.
// No podemos crear directamente objetos de tipo Vehiculo.

public abstract class Vehiculo
{
    public string Placa { get; }
    public int Ruedas { get; }

    // Constructor protegido: las clases hijas lo utilizan.
    protected Vehiculo(string placa, int ruedas)
    {
        Placa = placa.ToUpper();
        Ruedas = ruedas;
    }

    // Metodo abstracto: las clases hijas deben implementarlo.
    public abstract decimal CalcularPeaje();

    // Metodo virtual: las clases hijas pueden sobrescribirlo.
    public virtual string Describir()
    {
        return $"{GetType().Name,-15} {Placa} - {Ruedas} ruedas - Peaje: {CalcularPeaje():C0}";
    }

    // Sobrescritura del metodo ToString().
    public override string ToString()
    {
        return Describir();
    }
}


// ============================================================
// PARTE 2: HERENCIA - CLASE CARRO
// ============================================================

public class Carro : Vehiculo
{
    public int Puestos { get; }

    public Carro(string placa, int puestos)
        : base(placa, 4)
    {
        Puestos = puestos;
    }

    public override decimal CalcularPeaje()
    {
        return 12000m;
    }
}


// ============================================================
// PARTE 3: HERENCIA - CLASE MOTO
// ============================================================

public class Moto : Vehiculo
{
    public Moto(string placa)
        : base(placa, 2)
    {
    }

    public override decimal CalcularPeaje()
    {
        return 6000m;
    }

    // Sobrescribimos Describir() y reutilizamos el metodo padre.
    public override string Describir()
    {
        return base.Describir() + " - Usa casco";
    }
}


// ============================================================
// PARTE 4: INTERFAZ IRECARGABLE
// ============================================================

// Una interfaz establece un contrato.
// Las clases que la implementen deben tener estas propiedades
// y metodos.

public interface IRecargable
{
    int Bateria { get; }

    void Recargar();
}


// ============================================================
// PARTE 5: HERENCIA E INTERFAZ - CARRO ELECTRICO
// ============================================================

// CarroElectrico hereda de Carro e implementa IRecargable.

public class CarroElectrico : Carro, IRecargable
{
    public int Bateria { get; private set; } = 40;

    public CarroElectrico(string placa, int puestos)
        : base(placa, puestos)
    {
    }

    // Un carro electrico paga la mitad del peaje.
    public override decimal CalcularPeaje()
    {
        return base.CalcularPeaje() * 0.5m;
    }

    public void Recargar()
    {
        Bateria = 100;
    }
}


// ============================================================
// PARTE 6: IMPLEMENTACION DE INTERFAZ - PATINETA
// ============================================================

// La patineta no hereda de Vehiculo.
// Solamente implementa la capacidad de recargarse.

public class Patineta : IRecargable
{
    public int Bateria { get; private set; } = 15;

    public void Recargar()
    {
        Bateria = 100;
    }
}


// ============================================================
// PARTE 7: METODO POLIMORFICO PARA RECARGAR
// ============================================================

// Recibe cualquier objeto que implemente IRecargable.
// No importa si es un carro electrico o una patineta.

public static class GestorRecargas
{
    public static void CargarTodos(List<IRecargable> lista)
    {
        foreach (IRecargable aparato in lista)
        {
            aparato.Recargar();

            Console.WriteLine(
                $"{aparato.GetType().Name}: {aparato.Bateria}% de bateria"
            );
        }
    }
}


// ============================================================
// EJERCICIO 1: FIGURAS GEOMETRICAS
// ============================================================

// Clase abstracta Figura.
// Todas las figuras deben calcular su area y perimetro.

public abstract class Figura
{
    public abstract double Area();

    public abstract double Perimetro();

    // Muestra el nombre de la figura, su area y perimetro.
    public override string ToString()
    {
        return $"{GetType().Name} - Area: {Area():F2} - Perimetro: {Perimetro():F2}";
    }
}


// ------------------------------------------------------------
// CLASE CUADRADO
// ------------------------------------------------------------

public class Cuadrado : Figura
{
    public double Lado { get; }

    public Cuadrado(double lado)
    {
        Lado = lado;
    }

    public override double Area()
    {
        return Lado * Lado;
    }

    public override double Perimetro()
    {
        return 4 * Lado;
    }
}


// ------------------------------------------------------------
// CLASE RECTANGULO
// ------------------------------------------------------------

public class Rectangulo : Figura
{
    public double Base { get; }
    public double Altura { get; }

    public Rectangulo(double baseFigura, double altura)
    {
        Base = baseFigura;
        Altura = altura;
    }

    public override double Area()
    {
        return Base * Altura;
    }

    public override double Perimetro()
    {
        return 2 * (Base + Altura);
    }
}


// ------------------------------------------------------------
// CLASE CIRCULO
// ------------------------------------------------------------

public class Circulo : Figura
{
    public double Radio { get; }

    public Circulo(double radio)
    {
        Radio = radio;
    }

    public override double Area()
    {
        return Math.PI * Radio * Radio;
    }

    public override double Perimetro()
    {
        return 2 * Math.PI * Radio;
    }
}


// ============================================================
// EJERCICIO 2: ANIMALES CON SONIDO
// ============================================================

// Clase padre Animal.
// El metodo virtual permite que cada animal tenga su sonido.

public class Animal
{
    public string Nombre { get; }

    public Animal(string nombre)
    {
        Nombre = nombre;
    }

    public virtual string HacerSonido()
    {
        return "...";
    }
}


// ------------------------------------------------------------
// CLASE PERRO
// ------------------------------------------------------------

public class Perro : Animal
{
    public Perro(string nombre)
        : base(nombre)
    {
    }

    public override string HacerSonido()
    {
        return "Guau";
    }
}


// ------------------------------------------------------------
// CLASE GATO
// ------------------------------------------------------------

public class Gato : Animal
{
    public Gato(string nombre)
        : base(nombre)
    {
    }

    public override string HacerSonido()
    {
        return "Miau";
    }
}


// ------------------------------------------------------------
// CLASE VACA
// ------------------------------------------------------------

public class Vaca : Animal
{
    public Vaca(string nombre)
        : base(nombre)
    {
    }

    public override string HacerSonido()
    {
        return "Muuu";
    }
}


// ============================================================
// EJERCICIO 3: INTERFAZ IDESCARGABLE
// ============================================================

// Las clases que implementen esta interfaz deben tener
// un tamaño y un metodo para descargar.

public interface IDescargable
{
    double TamanoMB { get; }

    void Descargar();
}


// ------------------------------------------------------------
// CLASE CANCION
// ------------------------------------------------------------

public class Cancion : IDescargable
{
    public string Titulo { get; }
    public double TamanoMB { get; }

    public Cancion(string titulo, double tamanoMB)
    {
        Titulo = titulo;
        TamanoMB = tamanoMB;
    }

    public void Descargar()
    {
        Console.WriteLine($"Descargando cancion: {Titulo}");
    }
}


// ------------------------------------------------------------
// CLASE PELICULA
// ------------------------------------------------------------

public class Pelicula : IDescargable
{
    public string Titulo { get; }
    public double TamanoMB { get; }

    public Pelicula(string titulo, double tamanoMB)
    {
        Titulo = titulo;
        TamanoMB = tamanoMB;
    }

    public void Descargar()
    {
        Console.WriteLine($"Descargando pelicula: {Titulo}");
    }
}


// ============================================================
// METODO LINQ: CALCULAR TAMAÑO TOTAL DE DESCARGAS
// ============================================================

public static class GestorDescargas
{
    public static double TamanoTotal(List<IDescargable> lista)
    {
        return lista.Sum(d => d.TamanoMB);
    }
}


// ============================================================
// PROGRAMA PRINCIPAL
// ============================================================

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // ====================================================
        // DEMOSTRACION PRINCIPAL: VEHICULOS Y PEAJES
        // ====================================================

        Console.WriteLine("\n======================================");
        Console.WriteLine("       VEHICULOS Y PEAJES");
        Console.WriteLine("======================================");

        // Polimorfismo: una lista del tipo padre Vehiculo
        // puede almacenar diferentes clases hijas.

        List<Vehiculo> fila = new List<Vehiculo>
        {
            new Carro("abc123", 5),
            new Moto("xyz98a"),
            new CarroElectrico("ele001", 4)
        };

        // Cada objeto utiliza su propia version de Describir().
        foreach (Vehiculo vehiculo in fila)
        {
            Console.WriteLine(vehiculo.Describir());
        }

        // LINQ: sumar los peajes de todos los vehiculos.
        decimal totalPeajes = fila.Sum(v => v.CalcularPeaje());

        Console.WriteLine($"\nTotal recaudado: {totalPeajes:C0}");


        // ====================================================
        // DEMOSTRACION: COMPROBAR SI UN VEHICULO ES RECARGABLE
        // ====================================================

        Console.WriteLine("\n======================================");
        Console.WriteLine("       VEHICULOS RECARGABLES");
        Console.WriteLine("======================================");

        foreach (Vehiculo vehiculo in fila)
        {
            // is comprueba si implementa la interfaz.
            if (vehiculo is IRecargable recargable)
            {
                Console.WriteLine(
                    $"{vehiculo.Placa} tiene {recargable.Bateria}% de bateria"
                );
            }
        }

        // OfType filtra los objetos que implementan IRecargable.
        List<IRecargable> recargables = fila
            .OfType<IRecargable>()
            .ToList();

        Console.WriteLine(
            $"\nCantidad de vehiculos recargables: {recargables.Count}"
        );


        // ====================================================
        // DEMOSTRACION: RECARGAR VEHICULOS Y PATINETAS
        // ====================================================

        Console.WriteLine("\n======================================");
        Console.WriteLine("       SISTEMA DE RECARGA");
        Console.WriteLine("======================================");

        List<IRecargable> enchufados = new List<IRecargable>
        {
            new CarroElectrico("ele002", 2),
            new Patineta()
        };

        GestorRecargas.CargarTodos(enchufados);


        // ====================================================
        // EJERCICIO 1: FIGURAS GEOMETRICAS
        // ====================================================

        Console.WriteLine("\n======================================");
        Console.WriteLine("       EJERCICIO 1: FIGURAS");
        Console.WriteLine("======================================");

        // Crear una lista con cinco figuras diferentes.
        List<Figura> figuras = new List<Figura>
        {
            new Cuadrado(4),
            new Rectangulo(5, 3),
            new Circulo(2),
            new Cuadrado(6),
            new Rectangulo(8, 2)
        };

        // Mostrar todas las figuras.
        foreach (Figura figura in figuras)
        {
            Console.WriteLine(figura);
        }

        // MaxBy encuentra la figura con mayor area.
        Figura mayorArea = figuras.MaxBy(f => f.Area())!;

        Console.WriteLine("\nFigura con mayor area:");
        Console.WriteLine(mayorArea);


        // ====================================================
        // EJERCICIO 2: ANIMALES CON SONIDO
        // ====================================================

        Console.WriteLine("\n======================================");
        Console.WriteLine("       EJERCICIO 2: ANIMALES");
        Console.WriteLine("======================================");

        // Una lista del tipo Animal almacena perros,
        // gatos y vacas gracias al polimorfismo.

        List<Animal> animales = new List<Animal>
        {
            new Perro("Max"),
            new Gato("Michi"),
            new Vaca("Lola"),
            new Perro("Rocky"),
            new Gato("Luna")
        };

        foreach (Animal animal in animales)
        {
            Console.WriteLine(
                $"{animal.Nombre} dice: {animal.HacerSonido()}"
            );
        }


        // ====================================================
        // EJERCICIO 3: ELEMENTOS DESCARGABLES
        // ====================================================

        Console.WriteLine("\n======================================");
        Console.WriteLine("       EJERCICIO 3: DESCARGAS");
        Console.WriteLine("======================================");

        // La lista permite guardar canciones y peliculas
        // porque ambas implementan IDescargable.

        List<IDescargable> archivos = new List<IDescargable>
        {
            new Cancion("Blinding Lights", 8.5),
            new Pelicula("Interestelar", 2500),
            new Cancion("Starboy", 7.2),
            new Pelicula("Avatar", 3000)
        };

        // Descargar cada elemento.
        foreach (IDescargable archivo in archivos)
        {
            archivo.Descargar();

            Console.WriteLine(
                $"Tamano: {archivo.TamanoMB} MB\n"
            );
        }

        // Calcular el tamaño total utilizando LINQ.
        double totalDescargas = GestorDescargas.TamanoTotal(archivos);

        Console.WriteLine("--------------------------------------");
        Console.WriteLine($"Tamano total: {totalDescargas} MB");


        // ====================================================
        // FINAL DEL PROGRAMA
        // ====================================================

        Console.WriteLine("\n======================================");
        Console.WriteLine("       FIN DEL PROGRAMA");
        Console.WriteLine("======================================");
    }
}
