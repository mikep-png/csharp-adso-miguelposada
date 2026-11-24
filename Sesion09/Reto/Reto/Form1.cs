using System;
using System.Windows.Forms;

namespace Reto
{
    public partial class Form1 : Form
    {
        private readonly CuentaBancaria _cuenta = new("Tu Nombre", "001-123", 500000m);

        public Form1()
        {
            InitializeComponent();
            lblTitular.Text = $"Titular: {_cuenta.Titular} (Cuenta: {_cuenta.Numero})";
            ActualizarSaldo();
        }

        private void ActualizarSaldo()
        {
            lblSaldo.Text = $"Saldo: {_cuenta.Saldo:C0}";
        }

        private void RegistrarMovimiento(string tipo, decimal monto)
        {
            string hora = DateTime.Now.ToString("HH:mm:ss");
            lstMovimientos.Items.Insert(0, $"[{hora}] {tipo}: {monto:C0}");
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            decimal monto = nudMonto.Value;

            if (_cuenta.Depositar(monto))
            {
                ActualizarSaldo();
                RegistrarMovimiento("Depósito", monto);
            }
            else
            {
                MessageBox.Show(
                    "No se pudo realizar el depósito.\nEl monto debe ser mayor a $0 y múltiplo de $10.000.",
                    "Operación rechazada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            decimal monto = nudMonto.Value;

            if (_cuenta.Retirar(monto))
            {
                ActualizarSaldo();
                RegistrarMovimiento("Retiro", monto);
            }
            else
            {
                MessageBox.Show(
                    "No se pudo realizar el retiro.\nVerifica que tengas saldo suficiente y que el monto sea múltiplo de $10.000.",
                    "Operación rechazada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
