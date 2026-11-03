using System;
using System.Collections.Generic;
using System.Linq;

Dictionary<string, List<double>> aprendices = new Dictionary<string, List<double>>();
int opcion;
do
{
    Console.WriteLine("=== Sistema de Gestión de Aprendices ===");
    Console.WriteLine("1. Registrar Aprendiz");
    Console.WriteLine("2. Agregar Nota a Aprendiz");
    Console.WriteLine("3. Listar Aprendices (Promedio y Juicio)");
    Console.WriteLine("4. Ranking de Aprendices (Mayor a Menor)");
    Console.WriteLine("5. Ver Mejor Aprendiz y Cantidad de Aprobados");
    Console.WriteLine("6. Eliminar Aprendiz");
    Console.WriteLine("7. Salir del Programa");
    Console.WriteLine("Porfavor seleccione una opción: ");

    if (!int.TryParse(Console.ReadLine(), out opcion))
    {
        opcion = 0;
    }

    switch (opcion)
    {
        case 1: RegistrarAprendiz(); break;
        case 2: AgregarNota(); break;
        case 3: ListarAprendices(); break;
        case 4: RankingAprendices(); break;
        case 5: MostrarEstadisticas(); break;
        case 6: EliminarAprendiz(); break;
        case 7: Console.WriteLine("Saliendo del programa..."); ; break;
        default:
            Console.WriteLine("Opción no válida. Presione una opción válida.");
            Console.ReadKey();
            break;
    }
} while (opcion != 7);

void RegistrarAprendiz()
{
    Console.WriteLine("Ingrese el nombre del aprendiz: ");
    string nombre = Console.ReadLine().Trim();

    if (string.IsNullOrEmpty(nombre))
    {
        Console.WriteLine("El nombre no puede estar vacio.");
    }
    else if (aprendices.ContainsKey(nombre))
    {
        Console.WriteLine("El aprendiz ya se encuentra registrado.");
    }
    else
    {
        aprendices.Add(nombre, new List<double>());
        Console.WriteLine($"¡Aprendiz '{nombre}' registrado con éxito!");
    }
    PresioneTecla();
}

void AgregarNota()
{
    Console.Write("Ingrese el nombre del aprendiz: ");
    string nombre = Console.ReadLine().Trim();

    if (!aprendices.ContainsKey(nombre))
    {
        Console.WriteLine("El aprendiz no existe.");
    }
    else
    {
        Console.Write("Ingrese la nota (0.0 a 5.0): ");
        if (double.TryParse(Console.ReadLine(), out double nota) && nota >= 0 && nota <= 5)
        {
            aprendices[nombre].Add(nota);
            Console.WriteLine($"Nota {nota} agregada correctamente a {nombre}.");
        }
        else
        {
            Console.WriteLine("Error: La nota debe ser un número entre 0 y 5.");
        }
    }
    PresioneTecla();
}

void ListarAprendices()
{
    Console.Clear();
    Console.WriteLine("=== LISTADO DE APRENDICES ===");
    if (aprendices.Count == 0)
    {
        Console.WriteLine("No hay aprendices registrados.");
    }
    else
    {
        foreach (var item in aprendices)
        {
            string notasStr = item.Value.Count > 0 ? string.Join(", ", item.Value) : "Sin notas";
            double promedio = item.Value.Count > 0 ? item.Value.Average() : 0.0;
            // Juicio: A (Aprobado) si promedio >= 3.5, D (Deficiente) si es menor
            string juicio = promedio >= 3.5 ? "A" : "D";

            Console.WriteLine($"- Nombre: {item.Key} | Notas: [{notasStr}] | Promedio: {promedio:F2} | Juicio: {juicio}");
        }
    }
    PresioneTecla();
}
void RankingAprendices()
{
    Console.Clear();
    Console.WriteLine("=== RANKING DE APRENDICES (POR PROMEDIO) ===");

    if (aprendices.Count == 0)
    {
        Console.WriteLine("No hay datos suficientes para generar el ranking.");
    }
    else
    {
        var ranking = aprendices
            .Select(a => new
            {
                Nombre = a.Key,
                Promedio = a.Value.Count > 0 ? a.Value.Average() : 0.0
            })
            .OrderByDescending(a => a.Promedio)
            .ToList();

        int puesto = 1;
        foreach (var item in ranking)
        {
            Console.WriteLine($"{puesto}. {item.Nombre} - Promedio: {item.Promedio:F2}");
            puesto++;
        }
    }
}

void MostrarEstadisticas()
{
    Console.WriteLine("=== ESTADÍSTICAS GENERALES ===");
    if (aprendices.Count == 0)
    {
        Console.WriteLine("No hay aprendices registrados.");
        PresioneTecla();
        return;
    }

    var datosCalculados = aprendices.Select(a => new
    {
        Nombre = a.Key,
        Promedio = a.Value.Count > 0 ? a.Value.Average() : 0.0
    }).ToList();

    var mejorAprendiz = datosCalculados.OrderByDescending(a => a.Promedio).FirstOrDefault();

    int cantidadAprobados = datosCalculados.Count(a => a.Promedio >= 3.5);

    Console.WriteLine($"Mejor Aprendiz: {mejorAprendiz.Nombre} (Promedio: {mejorAprendiz.Promedio:F2})");
    Console.WriteLine($"Cantidad de Aprobados (Promedio >= 3.5): {cantidadAprobados} de {aprendices.Count}");

    PresioneTecla();
}

void EliminarAprendiz()
{
    Console.Write("Ingrese el nombre del aprendiz a eliminar: ");
    string nombre = Console.ReadLine().Trim();

    if (aprendices.Remove(nombre))
    {
        Console.WriteLine($"El aprendiz '{nombre}' ha sido eliminado correctamente.");
    }
    else
    {
        Console.WriteLine("El aprendiz especificado no existe.");
    }
    PresioneTecla();
}

void PresioneTecla()
{
    Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
    Console.ReadKey();
}
