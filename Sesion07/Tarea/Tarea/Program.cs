using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

class Program
{
    private const string ArchivoJson = "notas.json";
    private const string ArchivoLog = "errores.log";

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Dictionary<string, List<double>> sistemaNotas = CargarNotas();
        bool salir = false;

        while (!salir)
        {
            try
            {
                Console.WriteLine("\n--- CONTROL DE NOTAS ---");
                Console.WriteLine("1. Registrar/Agregar notas de estudiante");
                Console.WriteLine("2. Ver todas las notas y promedios");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Nombre del estudiante: ");
                        string nombre = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(nombre))
                            throw new ArgumentException("El nombre del estudiante no puede estar vacío.");

                        Console.Write("Ingrese la nota (0.0 a 5.0): ");
                        if (!double.TryParse(Console.ReadLine(), out double nota) || nota < 0 || nota > 5)
                            throw new FormatException("La nota debe ser un número válido entre 0.0 y 5.0.");

                        if (!sistemaNotas.ContainsKey(nombre))
                        {
                            sistemaNotas[nombre] = new List<double>();
                        }

                        sistemaNotas[nombre].Add(nota);
                        GuardarNotas(sistemaNotas);
                        Console.WriteLine($"✅ Nota {nota} agregada correctamente a {nombre}.");
                        break;

                    case "2":
                        Console.WriteLine("\n--- REPORTE DE NOTAS ---");
                        if (sistemaNotas.Count == 0)
                        {
                            Console.WriteLine("No hay notas registradas.");
                            break;
                        }

                        foreach (var estudiante in sistemaNotas)
                        {
                            string notasTexto = string.Join(", ", estudiante.Value);
                            double promedio = estudiante.Value.Average();
                            Console.WriteLine($"- {estudiante.Key}: [{notasTexto}] | Promedio: {promedio:F2}");
                        }
                        break;

                    case "3":
                        salir = true;
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("❌ Opción inválida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n⚠️ Error de entrada: {ex.Message}");
                RegistrarErrorEnLog(ex.Message);
            }
        }
    }

    static Dictionary<string, List<double>> CargarNotas()
    {
        if (!File.Exists(ArchivoJson))
            return new Dictionary<string, List<double>>();

        try
        {
            string json = File.ReadAllText(ArchivoJson);
            return JsonSerializer.Deserialize<Dictionary<string, List<double>>>(json) ?? new Dictionary<string, List<double>>();
        }
        catch (Exception ex)
        {
            RegistrarErrorEnLog($"Error cargando JSON: {ex.Message}");
            Console.WriteLine("⚠️ El archivo de notas estaba corrupto. Iniciando sistema vacío.");
            return new Dictionary<string, List<double>>();
        }
    }

    static void GuardarNotas(Dictionary<string, List<double>> notas)
    {
        try
        {
            string json = JsonSerializer.Serialize(notas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ArchivoJson, json);
        }
        catch (Exception ex)
        {
            RegistrarErrorEnLog($"Error guardando JSON: {ex.Message}");
            Console.WriteLine($"❌ Error al guardar datos: {ex.Message}");
        }
    }

    static void RegistrarErrorEnLog(string mensajeError)
    {
        try
        {
            string lineaLog = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR: {mensajeError}{Environment.NewLine}";
            File.AppendAllText(ArchivoLog, lineaLog);
        }
        catch
        {
            // Si el log falla, se ignora para no romper la ejecución del hilo principal
        }
    }
}
