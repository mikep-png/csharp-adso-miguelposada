using System;
using System.Windows.Forms;

namespace Tarea
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool valido = true;

            if (!double.TryParse(txtValor.Text, out double valor))
            {
                errorProvider1.SetError(txtValor, "Ingresa un valor numérico válido.");
                valido = false;
            }

            if (cmbOrigen.SelectedItem is null)
            {
                errorProvider1.SetError(cmbOrigen, "Elige la unidad de origen.");
                valido = false;
            }

            if (cmbDestino.SelectedItem is null)
            {
                errorProvider1.SetError(cmbDestino, "Elige la unidad de destino.");
                valido = false;
            }

            if (!valido) return;

            string origen = cmbOrigen.SelectedItem.ToString()!;
            string destino = cmbDestino.SelectedItem.ToString()!;

            double resultado = ConversorTemperatura.Convertir(valor, origen, destino);

            lblResultado.Text = $"Resultado: {resultado:F2} {destino}";
        }
    }
}
