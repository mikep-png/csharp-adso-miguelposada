
using System;
using System.Drawing;
using System.Windows.Forms;
using Inventario.Modelos;

namespace Inventario.Escritorio
{
    public class FormProducto : Form
    {
        private TextBox txtCodigo;
        private TextBox txtNombre;
        private NumericUpDown nudPrecio;
        private NumericUpDown nudStock;

        public Producto ProductoCreado { get; private set; }

        public FormProducto()
        {
            Text = "Agregar producto";
            Size = new Size(400, 350);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            CrearInterfaz();
        }

        private void CrearInterfaz()
        {
            CrearEtiqueta("Código:", 30, 30);
            txtCodigo = CrearTexto(130, 27);

            CrearEtiqueta("Nombre:", 30, 80);
            txtNombre = CrearTexto(130, 77);

            CrearEtiqueta("Precio:", 30, 130);

            nudPrecio = new NumericUpDown
            {
                Location = new Point(130, 127),
                Width = 200,
                DecimalPlaces = 2,
                Maximum = 1000000000,
                Minimum = 0,
                ThousandsSeparator = true
            };

            Controls.Add(nudPrecio);

            CrearEtiqueta("Stock:", 30, 180);

            nudStock = new NumericUpDown
            {
                Location = new Point(130, 177),
                Width = 200,
                Minimum = 0,
                Maximum = 1000000
            };

            Controls.Add(nudStock);

            var btnGuardar = new Button
            {
                Text = "Guardar",
                Location = new Point(130, 235),
                Size = new Size(95, 35),
                DialogResult = DialogResult.None
            };

            btnGuardar.Click += (s, e) => GuardarProducto();

            Controls.Add(btnGuardar);

            var btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(235, 235),
                Size = new Size(95, 35),
                DialogResult = DialogResult.Cancel
            };

            Controls.Add(btnCancelar);

            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;
        }

        private void CrearEtiqueta(string texto, int x, int y)
        {
            Controls.Add(new Label
            {
                Text = texto,
                Location = new Point(x, y),
                AutoSize = true
            });
        }

        private TextBox CrearTexto(int x, int y)
        {
            var caja = new TextBox
            {
                Location = new Point(x, y),
                Width = 200
            };

            Controls.Add(caja);
            return caja;
        }


        private void GuardarProducto()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "El código y el nombre son obligatorios.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (nudPrecio.Value <= 0)
            {
                MessageBox.Show("El precio debe ser mayor que cero.");
                return;
            }

            try
            {
                ProductoCreado = new Producto(
                    txtCodigo.Text.Trim(),
                    txtNombre.Text.Trim(),
                    nudPrecio.Value,
                    (int)nudStock.Value
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al crear producto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
