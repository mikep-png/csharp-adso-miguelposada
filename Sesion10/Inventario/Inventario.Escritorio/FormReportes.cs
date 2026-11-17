
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Inventario.Modelos;
using Inventario.Servicios;

namespace Inventario.Escritorio
{
    public class FormReportes : Form
    {
        private readonly ServicioInventario _servicio;

        private DataGridView dgvValiosos;
        private DataGridView dgvStockBajo;

        public FormReportes(ServicioInventario servicio)
        {
            _servicio = servicio;

            ConfigurarVentana();
            CrearInterfaz();
            CargarReportes();
        }

        private void ConfigurarVentana()
        {
            Text = "Reportes del inventario";
            Size = new Size(1050, 620);
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new Size(850, 500);
            BackColor = Color.FromArgb(245, 247, 250);
            Font = new Font("Segoe UI", 10);
        }

        private void CrearInterfaz()
        {
            var titulo = new Label
            {
                Text = "REPORTES DEL INVENTARIO",
                Font = new Font("Segoe UI", 19, FontStyle.Bold),
                Location = new Point(25, 20),
                AutoSize = true
            };

            Controls.Add(titulo);

            var lblValiosos = new Label
            {
                Text = "PRODUCTOS MÁS VALIOSOS",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(25, 85),
                AutoSize = true
            };

            Controls.Add(lblValiosos);

            dgvValiosos = CrearTabla(25, 120, 480, 350);

            dgvValiosos.Columns.Add("Codigo", "Código");
            dgvValiosos.Columns.Add("Nombre", "Nombre");
            dgvValiosos.Columns.Add("Precio", "Precio");
            dgvValiosos.Columns.Add("Stock", "Stock");
            dgvValiosos.Columns.Add("Valor", "Valor total");

            Controls.Add(dgvValiosos);

            var lblStockBajo = new Label
            {
                Text = "PRODUCTOS CON STOCK BAJO",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(530, 85),
                AutoSize = true
            };

            Controls.Add(lblStockBajo);

            dgvStockBajo = CrearTabla(530, 120, 480, 350);

            dgvStockBajo.Columns.Add("Codigo", "Código");
            dgvStockBajo.Columns.Add("Nombre", "Nombre");
            dgvStockBajo.Columns.Add("Precio", "Precio");
            dgvStockBajo.Columns.Add("Stock", "Stock");

            Controls.Add(dgvStockBajo);

            var btnActualizar = new Button
            {
                Text = "Actualizar reportes",
                Location = new Point(25, 490),
                Size = new Size(180, 40),
                BackColor = Color.FromArgb(35, 99, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };

            btnActualizar.Click += (s, e) => CargarReportes();

            Controls.Add(btnActualizar);

            var btnCerrar = new Button
            {
                Text = "Cerrar",
                Location = new Point(220, 490),
                Size = new Size(120, 40),
                BackColor = Color.FromArgb(90, 100, 115),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };

            btnCerrar.Click += (s, e) => Close();

            Controls.Add(btnCerrar);
        }

        private DataGridView CrearTabla(int x, int y, int ancho, int alto)
        {
            return new DataGridView
            {
                Location = new Point(x, y),
                Size = new Size(ancho, alto),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom |
                         AnchorStyles.Left | AnchorStyles.Right
            };
        }

        private void CargarReportes()
        {
            dgvValiosos.Rows.Clear();

            var productosValiosos = _servicio.ProductosMasValiosos();

            foreach (Producto producto in productosValiosos)
            {
                dgvValiosos.Rows.Add(
                    producto.Codigo,
                    producto.Nombre,
                    producto.Precio.ToString("C2"),
                    producto.Stock,
                    (producto.Precio * producto.Stock).ToString("C2")
                );
            }

            dgvStockBajo.Rows.Clear();

            var productosBajoStock = _servicio.StockBajo();

            foreach (Producto producto in productosBajoStock)
            {
                int fila = dgvStockBajo.Rows.Add(
                    producto.Codigo,
                    producto.Nombre,
                    producto.Precio.ToString("C2"),
                    producto.Stock
                );

                dgvStockBajo.Rows[fila].DefaultCellStyle.BackColor =
                    Color.MistyRose;

                dgvStockBajo.Rows[fila].DefaultCellStyle.ForeColor =
                    Color.DarkRed;
            }
        }
    }
}
