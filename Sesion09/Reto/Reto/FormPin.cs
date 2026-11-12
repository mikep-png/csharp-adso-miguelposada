using System;
using System.Windows.Forms;

namespace Reto
{
    public partial class FormPin : Form
    {
        private const string PinCorrecto = "1234";
        private int _intentosRestantes = 3;

        public FormPin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtPin.Text == PinCorrecto)
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            _intentosRestantes--;
            lblIntentos.Text = $"Intentos restantes: {_intentosRestantes}";
            txtPin.Clear();
            txtPin.Focus();

            if (_intentosRestantes <= 0)
            {
                MessageBox.Show(
                    "Has agotado los 3 intentos permitidos. El sistema se cerrará.",
                    "Acceso bloqueado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
            else
            {
                MessageBox.Show(
                    "PIN incorrecto. Intenta nuevamente.",
                    "Error de autenticación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
