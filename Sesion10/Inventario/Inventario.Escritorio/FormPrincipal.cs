
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Inventario.Modelos;
using Inventario.Servicios;

namespace Inventario.Escritorio
{
    public class FormPrincipal : Form
    {
        private readonly ServicioInventario _servicio;

        private DataGridView dgvProductos;
        private TextBox txtBuscar;
        private NumericUpDown nudCantidad;
        private Label lblTotal;
        private Label lblEstado;

        public FormPrincipal(ServicioInventario servicio)
        {
            _servicio = servicio;

            ConfigurarVentana();
            CrearInterfaz();
            CargarProductos();
        }

        private void ConfigurarVentana()
        {
            Text = "Sistema de Inventario";
            Size = new Size(1050, 650);
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(850, 550);
            BackColor = Color.FromArgb(245, 247, 250);
            Font = new Font("Segoe UI", 10);
        }

        private void CrearInterfaz()
        {
            var titulo = new Label
            {
                Text = "GESTIÓN DE INVENTARIO",
                Font = new Font("Segoe UI", 19, FontStyle.Bold),
                Location = new Point(25, 20),
                AutoSize = true
            };

            Controls.Add(titulo);

            txtBuscar = new TextBox
            {
                Location = new Point(25, 85),
                Width = 350,
                PlaceholderText = "Buscar por nombre o código..."
            };

            txtBuscar.TextChanged += (s, e) => CargarProductos();
            Controls.Add(txtBuscar);

            var btnAgregar = CrearBoton("Agregar producto", 400, 83);
            btnAgregar.Click += (s, e) => AgregarProducto();
            Controls.Add(btnAgregar);

            var btnEliminar = CrearBoton("Eliminar", 555, 83);
            btnEliminar.Click += (s, e) => EliminarProducto();
            Controls.Add(btnEliminar);

            var btnReportes = CrearBoton("Reportes", 710, 83);
            btnReportes.Click += (s, e) => AbrirReportes();
            Controls.Add(btnReportes);

            dgvProductos = new DataGridView
            {
                Location = new Point(25, 135),
                Size = new Size(970, 330),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom |
                         AnchorStyles.Left | AnchorStyles.Right,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                BackgroundColor = Color.White
            };

            dgvProductos.Columns.Add("Codigo", "Código");
            dgvProductos.Columns.Add("Nombre", "Nombre");
            dgvProductos.Columns.Add("Precio", "Precio");
            dgvProductos.Columns.Add("Stock", "Stock");

            dgvProductos.CellDoubleClick += DgvProductos_CellDoubleClick;

            Controls.Add(dgvProductos);

            var lblCantidad = new Label
            {
                Text = "Cantidad:",
                Location = new Point(25, 490),
                AutoSize = true
            };

            Controls.Add(lblCantidad);

            nudCantidad = new NumericUpDown
            {
                Location = new Point(110, 486),
                Width = 80,
                Minimum = 1,
                Maximum = 100000
            };

            Controls.Add(nudCantidad);

            var btnVender = CrearBoton("Vender", 220, 480);
            btnVender.Click += (s, e) => VenderProducto();
            Controls.Add(btnVender);

            var btnStock = CrearBoton("Agregar stock", 350, 480);
            btnStock.Click += (s, e) => AgregarStock();
            Controls.Add(btnStock);

            lblTotal = new Label
            {
                Text = "Valor total: $0",
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                Location = new Point(25, 540),
                AutoSize = true
            };

            Controls.Add(lblTotal);

            lblEstado = new Label
            {
                Text = "Productos: 0",
                Dock = DockStyle.Bottom,
                Height = 25,
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.FromArgb(225, 230, 238)
            };

            Controls.Add(lblEstado);

            var reloj = new System.Windows.Forms.Timer
            {
                Interval = 1000
            };

            reloj.Tick += (s, e) =>
            {
                lblEstado.Text =
                    $"Productos: {dgvProductos.Rows.Count} | Hora: {DateTime.Now:HH:mm:ss}";
            };

            reloj.Start();
        }

        private Button CrearBoton(string texto, int x, int y)
        {
            return new Button
            {
                Text = texto,
                Location = new Point(x, y),
                Size = new Size(145, 35),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(35, 99, 180),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
        }

        private void CargarProductos()
        {
            var productos = _servicio.Listar();

            if (!string.IsNullOrWhiteSpace(txtBuscar?.Text))
            {
                productos = _servicio.BuscarPorTexto(txtBuscar.Text);
            }

            dgvProductos.Rows.Clear();

            foreach (var producto in productos)
            {
                int fila = dgvProductos.Rows.Add(
                    producto.Codigo,
                    producto.Nombre,
                    producto.Precio.ToString("C2"),
                    producto.Stock
                );

                if (producto.Stock < 5)
                {
                    dgvProductos.Rows[fila].DefaultCellStyle.BackColor =
                        Color.MistyRose;

                    dgvProductos.Rows[fila].DefaultCellStyle.ForeColor =
                        Color.DarkRed;
                }
            }

            decimal total = _servicio.Listar()
                .Sum(p => p.Precio * p.Stock);

            lblTotal.Text = $"Valor total del inventario: {total:C2}";

            if (lblEstado != null)
                lblEstado.Text =
                    $"Productos: {productos.Count} | Hora: {DateTime.Now:HH:mm:ss}";
        }

        private Producto Seleccionado()
        {
            if (dgvProductos.CurrentRow == null)
                return null;

            string codigo = dgvProductos.CurrentRow
                .Cells["Codigo"].Value?.ToString();

            return _servicio.Listar()
                .FirstOrDefault(p => p.Codigo == codigo);
        }


        private void DgvProductos_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string codigo = dgvProductos.Rows[e.RowIndex]
                .Cells["Codigo"].Value?.ToString();

            Producto producto = _servicio.Listar()
                .FirstOrDefault(p => p.Codigo == codigo);

            if (producto == null)
                return;

            using (var formulario = new FormProducto())
            {
                formulario.CargarProducto(producto);

                if (formulario.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Actualizar los datos mediante el servicio.
                        _servicio.Actualizar(formulario.ProductoCreado);

                        // Volver a consultar el inventario.
                        CargarProductos();

                        MessageBox.Show(
                            "Producto actualizado correctamente.\n\n" +
                            $"Nuevo nombre: {formulario.ProductoCreado.Nombre}\n" +
                            $"Nuevo precio: {formulario.ProductoCreado.Precio:C2}",
                            "Actualización exitosa",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            ex.Message,
                            "Error al actualizar",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }


        private void AgregarProducto()
        {
            using var formulario = new FormProducto();

            if (formulario.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _servicio.Agregar(formulario.ProductoCreado);
                    CargarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void AbrirReportes()
        {
            using var formulario = new FormReportes(_servicio);
            formulario.ShowDialog();
        }

        private void VenderProducto()
        {
            if (Seleccionado() is not Producto producto)
            {
                MessageBox.Show("Selecciona un producto.");
                return;
            }

            try
            {
                _servicio.Vender(
                    producto.Codigo,
                    (int)nudCantidad.Value
                );

                CargarProductos();
            }
            catch (StockInsuficienteException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Stock insuficiente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void AgregarStock()
        {
            if (Seleccionado() is not Producto producto)
            {
                MessageBox.Show("Selecciona un producto.");
                return;
            }

            try
            {
                _servicio.AgregarStock(
                    producto.Codigo,
                    (int)nudCantidad.Value
                );

                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void EliminarProducto()
        {
            if (Seleccionado() is not Producto producto)
            {
                MessageBox.Show("Selecciona un producto.");
                return;
            }

            var respuesta = MessageBox.Show(
                $"¿Seguro que deseas eliminar {producto.Nombre}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (respuesta == DialogResult.Yes)
            {
                _servicio.Eliminar(producto.Codigo);
                CargarProductos();
            }
        }
    }
}
