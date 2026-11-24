using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        IMetodoPago efectivo = new PagoEfectivo();
        IMetodoPago tarjetaValida = new PagoTarjeta("1234567812345678");
        IMetodoPago tarjetaInvalida = new PagoTarjeta("12345");
        IMetodoPago billeteraValida = new PagoBilletera();

        Console.WriteLine("--- SIMULACIÓN DE COBROS ---");
        ProcesadorPagos.Cobrar(efectivo, 100000m);
        ProcesadorPagos.Cobrar(tarjetaValida, 500000m);
        ProcesadorPagos.Cobrar(tarjetaInvalida, 200000m);
        ProcesadorPagos.Cobrar(billeteraValida, 2500000m);
        ProcesadorPagos.Cobrar(billeteraValida, 1500000m);

        Console.WriteLine("\n--- SIMULACIÓN DE REEMBOLSOS ---");
        ProcesadorPagos.Devolver(efectivo, 50000m);
        ProcesadorPagos.Devolver(tarjetaValida, 100000m);
        ProcesadorPagos.Devolver(billeteraValida, 200000m);
    }
}

public interface IMetodoPago
{
    string Nombre { get; }
    decimal CalcularComision(decimal monto);
    bool Validar(decimal monto);
}

public interface IReembolsable
{
    bool Reembolsar(decimal monto);
}

public class PagoEfectivo : IMetodoPago
{
    public string Nombre => "Efectivo";
    public decimal CalcularComision(decimal monto) => 0m;
    public bool Validar(decimal monto) => monto > 0;
}

public class PagoTarjeta : IMetodoPago, IReembolsable
{
    public string Nombre => "Tarjeta de Crédito/Débito";
    public string NumeroTarjeta { get; set; }

    public PagoTarjeta(string numeroTarjeta)
    {
        NumeroTarjeta = numeroTarjeta;
    }

    public decimal CalcularComision(decimal monto) => monto * 0.03m;

    public bool Validar(decimal monto) =>
        monto > 0 && !string.IsNullOrWhiteSpace(NumeroTarjeta) && NumeroTarjeta.Length == 16;

    public bool Reembolsar(decimal monto)
    {
        Console.WriteLine($" Reembolso de {monto:C0} enviado a la franquicia de la tarjeta.");
        return true;
    }
}

public class PagoBilletera : IMetodoPago, IReembolsable
{
    public string Nombre => "Billetera Digital";
    public decimal CalcularComision(decimal monto) => monto * 0.01m;

    public bool Validar(decimal monto) => monto > 0 && monto <= 2000000m;

    public bool Reembolsar(decimal monto)
    {
        Console.WriteLine($" Reembolso de {monto:C0} acreditado inmediatamente en el saldo de la billetera.");
        return true;
    }
}

public static class ProcesadorPagos
{
    public static void Cobrar(IMetodoPago metodo, decimal monto)
    {
        Console.WriteLine($"\nIntentando cobrar {monto:C0} con {metodo.Nombre}...");

        if (!metodo.Validar(monto))
        {
            Console.WriteLine("❌ El pago fue rechazado. Validaciones de negocio no superadas.");
            return;
        }

        decimal comision = metodo.CalcularComision(monto);
        decimal total = monto + comision;

        Console.WriteLine($"✅ Pago aprobado.");
        Console.WriteLine($"   Monto base: {monto:C0}");
        Console.WriteLine($"   Comisión aplicable: {comision:C0}");
        Console.WriteLine($"   Cargado al usuario: {total:C0}");
    }

    public static void Devolver(IMetodoPago metodo, decimal monto)
    {
        Console.WriteLine($"\nProcesando devolución de {monto:C0} en {metodo.Nombre}...");

        if (metodo is IReembolsable reembolsable)
        {
            reembolsable.Reembolsar(monto);
            Console.WriteLine("✅ Reembolso completado con éxito.");
        }
        else
        {
            Console.WriteLine($"❌ Error: El método {metodo.Nombre} no admite reembolsos.");
        }
    }
}
