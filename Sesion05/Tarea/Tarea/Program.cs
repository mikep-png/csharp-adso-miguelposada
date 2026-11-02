using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        CuentaBancaria cuenta1 = new CuentaBancaria("Juan Pérez", "123456", 500000m);
        CuentaBancaria cuenta2 = new CuentaBancaria("Maria Lopez", "789012", 100000m);

        Console.WriteLine($"Cuenta 1 - Titular: {cuenta1.Titular} | Saldo: {cuenta1.Saldo:C0}");
        Console.WriteLine($"Cuenta 2 - Titular: {cuenta2.Titular} | Saldo: {cuenta2.Saldo:C0}");

        Console.WriteLine("\n--- Simulando Transferencia ---");
        if (cuenta1.Transferir(cuenta2, 200000m))
        {
            Console.WriteLine("✅ Transferencia exitosa de $200,000 de Cuenta 1 a Cuenta 2.");
        }
        else
        {
            Console.WriteLine("❌ Transferencia rechazada.");
        }

        Console.WriteLine($"\nSaldo final Cuenta 1: {cuenta1.Saldo:C0}");
        Console.WriteLine($"Saldo final Cuenta 2: {cuenta2.Saldo:C0}");
    }
}

public class CuentaBancaria
{
    public string Titular { get; private set; }
    public string Numero { get; private set; }
    public decimal Saldo { get; private set; }

    public CuentaBancaria(string titular, string numero, decimal saldoInicial = 0)
    {
        Titular = titular;
        Numero = numero;
        Saldo = saldoInicial < 0 ? 0 : saldoInicial;
    }

    public bool Depositar(decimal monto)
    {
        if (monto <= 0) return false;

        Saldo += monto;
        return true;
    }

    public bool Retirar(decimal monto)
    {
        if (monto <= 0 || monto > Saldo) return false;

        Saldo -= monto;
        return true;
    }

    public bool Transferir(CuentaBancaria destino, decimal monto)
    {
        if (destino == null || monto <= 0 || monto > Saldo) return false;

        Saldo -= monto;
        destino.Depositar(monto);
        return true;
    }
}
