using System;
using System.Windows.Forms;

namespace Practica2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Selecciona "Mañana" por defecto para evitar que ambos RadioButton queden vacíos
            rdbManana.Checked = true;
        }

        private void btnInscribir_Click(object sender, EventArgs e)
        {
            // Limpia alertas previas
            errorProvider1.Clear();
            bool valido = true;

            // Validar nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "Escribe el nombre.");
                valido = false;
            }

            // Validar programa seleccionado
            if (cmbPrograma.SelectedItem is null)
            {
                errorProvider1.SetError(cmbPrograma, "Elige un programa.");
                valido = false;
            }

            // Validar aceptación de términos
            if (!chkTerminos.Checked)
            {
                errorProvider1.SetError(chkTerminos, "Debes aceptar los términos.");
                valido = false;
            }

            // Si hay algún error, detiene la ejecución
            if (!valido) return;

            // Captura la jornada y agrega el registro a la lista
            string jornada = rdbManana.Checked ? "Mañana" : "Tarde";
            lstInscritos.Items.Add($"{txtNombre.Text.Trim()} · {nudEdad.Value} años · {cmbPrograma.SelectedItem} · {jornada}");

            // Limpia los campos para un nuevo registro
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            nudEdad.Value = 14;
            cmbPrograma.SelectedIndex = -1;
            rdbManana.Checked = true;
            chkTerminos.Checked = false;
            txtNombre.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Puedes eliminar este evento desde el diseñador si no lo estás usando
        }
    }
}

