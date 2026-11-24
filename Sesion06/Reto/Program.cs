using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        List<Empleado> nomina = [
            new EmpleadoPlanta("Juan Pérez", "101", 3000000m, 6),
            new EmpleadoPlanta("Ana Gómez", "102", 2500000m, 3),
            new EmpleadoPorHoras("Carlos Ruiz", "103", 10000m, 170),
            new EmpleadoPorHoras("María Lopez", "104", 12000m, 150),
            new Contratista("Luis Torres", "105", 4000000m),
            new Contratista("Elena Patiño", "106", 3500000m)
        ];

        Console.WriteLine("--- DETALLE DE PAGOS ---");
        foreach (var emp in nomina)
        {
            Console.WriteLine($"{emp} -> Salario Neto: {emp.CalcularSalario():C0}");
        }

        decimal totalNomina = nomina.Sum(e => e.CalcularSalario());
        decimal mayorPago = nomina.Max(e => e.CalcularSalario());

        var totalesPorTipo = nomina
            .GroupBy(e => e.GetType().Name)
            .Select(g => new { Tipo = g.Key, Total = g.Sum(e => e.CalcularSalario()) });

        Console.WriteLine($"\nTotal de la Nómina: {totalNomina:C0}");
        Console.WriteLine($"Mayor Pago Realizado: {mayorPago:C0}");

        Console.WriteLine("\n--- TOTAL POR TIPO DE EMPLEADO ---");
        foreach (var t in totalesPorTipo)
        {
            Console.WriteLine($"- {t.Tipo}: {t.Total:C0}");
        }
    }
}

public abstract class Empleado
{
    public string Nombre { get; set; }
    public string Documento { get; set; }

    protected Empleado(string nombre, string documento)
    {
        Nombre = nombre;
        Documento = documento;
    }

    public abstract decimal CalcularSalario();

    public override string ToString()
    {
        return $"[{GetType().Name}] {Nombre} (Doc: {Documento})";
    }
}

public class EmpleadoPlanta : Empleado
{
    public decimal SalarioBase { get; set; }
    public int AntiguedadAnios { get; set; }

    public EmpleadoPlanta(string nombre, string documento, decimal salarioBase, int antiguedadAnios)
        : base(nombre, documento)
    {
        SalarioBase = salarioBase;
        AntiguedadAnios = antiguedadAnios;
    }

    public override decimal CalcularSalario()
    {
        return AntiguedadAnios >= 5 ? SalarioBase * 1.05m : SalarioBase;
    }
}

public class EmpleadoPorHoras : Empleado
{
    public decimal ValorHora { get; set; }
    public int HorasTrabajadas { get; set; }

    public EmpleadoPorHoras(string nombre, string documento, decimal valorHora, int horasTrabajadas)
        : base(nombre, documento)
    {
        ValorHora = valorHora;
        HorasTrabajadas = horasTrabajadas;
    }

    public override decimal CalcularSalario()
    {
        if (HorasTrabajadas <= 160)
        {
            return HorasTrabajadas * ValorHora;
        }

        int horasNormales = 160;
        int horasExtras = HorasTrabajadas - 160;
        return (horasNormales * ValorHora) + (horasExtras * ValorHora * 1.5m);
    }
}

public class Contratista : Empleado
{
    public decimal Honorarios { get; set; }

    public Contratista(string nombre, string documento, decimal honorarios)
        : base(nombre, documento)
    {
        Honorarios = honorarios;
    }

    public override decimal CalcularSalario()
    {
        return Honorarios * 0.90m;
    }
}
