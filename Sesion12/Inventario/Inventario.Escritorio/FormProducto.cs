
using System;
using System.Drawing;
using System.Windows.Forms;
using Inventario.Modelos;
using Inventario.Servicios;

namespace Inventario.Escritorio
{
    public class FormProducto : Form
    {
        private readonly ServicioInventario _servicio;

        private TextBox txtCodigo;
        private TextBox txtNombre;
        private NumericUpDown nudPrecio;
        private NumericUpDown nudStock;
        private ComboBox cmbCategoria;

        public Producto ProductoCreado { get; private set; }

        private bool _esEdicion = false;

        public FormProducto(ServicioInventario servicio)
        {
            _servicio = servicio;

            Text = "Agregar producto";
            Size = new Size(400, 430);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            CrearInterfaz();
            CargarCategorias();
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

            CrearEtiqueta("Categoría:", 30, 230);

            cmbCategoria = new ComboBox
            {
                Location = new Point(130, 227),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            Controls.Add(cmbCategoria);

            var btnGuardar = new Button
            {
                Text = "Guardar",
                Location = new Point(130, 300),
                Size = new Size(95, 35),
                DialogResult = DialogResult.None
            };

            btnGuardar.Click += (s, e) => GuardarProducto();
            Controls.Add(btnGuardar);

            var btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(235, 300),
                Size = new Size(95, 35),
                DialogResult = DialogResult.Cancel
            };

            Controls.Add(btnCancelar);

            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;
        }

        private void CargarCategorias()
        {
            var categorias = _servicio.ObtenerCategorias();

            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "Id";
            cmbCategoria.SelectedIndex = -1;
        }

        public void CargarProducto(Producto producto)
        {
            _esEdicion = true;

            Text = "Editar producto";

            txtCodigo.Text = producto.Codigo;
            txtCodigo.Enabled = false;

            txtNombre.Text = producto.Nombre;
            nudPrecio.Value = producto.Precio;
            nudStock.Value = producto.Stock;

            if (producto.CategoriaId.HasValue)
            {
                cmbCategoria.SelectedValue = producto.CategoriaId.Value;
            }
            else
            {
                cmbCategoria.SelectedIndex = -1;
            }
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
                MessageBox.Show("El código y el nombre son obligatorios.");
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

                int? categoriaId = cmbCategoria.SelectedValue is int id
                    ? id
                    : null;

                ProductoCreado.CambiarCategoria(categoriaId);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al guardar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
