
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace Reto;

public partial class Form1 : Form
{
    private DataGridView dgvContactos;
    private TextBox txtBuscar;
    private TextBox txtNombre;
    private TextBox txtTelefono;
    private TextBox txtCorreo;

    private Label lblTotal;
    private Button btnAgregar;
    private Button btnEliminar;
    private Button btnGuardar;

    private ErrorProvider errorProvider1;

    // Guarda el Id del contacto que se está editando.
    private int? contactoEditandoId = null;

    public Form1()
    {
        InitializeComponent();

        CrearInterfaz();

        using (var db = new AgendaContext())
        {
            db.Database.EnsureCreated();
        }

        CargarContactos();
    }

    private void CrearInterfaz()
    {
        Text = "Agenda de contactos";
        StartPosition = FormStartPosition.CenterScreen;
        Size = new Size(950, 650);
        MinimumSize = new Size(800, 550);

        errorProvider1 = new ErrorProvider();
        errorProvider1.ContainerControl = this;

        // Título
        Label lblTitulo = new Label
        {
            Text = "AGENDA DE CONTACTOS",
            Font = new Font("Arial", 18, FontStyle.Bold),
            Location = new Point(20, 15),
            Size = new Size(450, 35)
        };

        // Búsqueda
        Label lblBuscar = new Label
        {
            Text = "Buscar contacto:",
            Location = new Point(20, 65),
            Size = new Size(120, 25)
        };

        txtBuscar = new TextBox
        {
            Name = "txtBuscar",
            Location = new Point(145, 62),
            Size = new Size(300, 25)
        };

        txtBuscar.TextChanged += txtBuscar_TextChanged;

        // Campos del contacto
        Label lblNombre = new Label
        {
            Text = "Nombre:",
            Location = new Point(20, 110),
            Size = new Size(100, 25)
        };

        txtNombre = new TextBox
        {
            Name = "txtNombre",
            Location = new Point(120, 107),
            Size = new Size(220, 25)
        };

        Label lblTelefono = new Label
        {
            Text = "Teléfono:",
            Location = new Point(365, 110),
            Size = new Size(100, 25)
        };

        txtTelefono = new TextBox
        {
            Name = "txtTelefono",
            Location = new Point(455, 107),
            Size = new Size(180, 25)
        };

        Label lblCorreo = new Label
        {
            Text = "Correo:",
            Location = new Point(655, 110),
            Size = new Size(70, 25)
        };

        txtCorreo = new TextBox
        {
            Name = "txtCorreo",
            Location = new Point(720, 107),
            Size = new Size(190, 25)
        };

        // Botón agregar
        btnAgregar = new Button
        {
            Text = "Agregar",
            Location = new Point(20, 155),
            Size = new Size(120, 35)
        };

        btnAgregar.Click += btnAgregar_Click;

        // Botón guardar cambios
        btnGuardar = new Button
        {
            Text = "Guardar cambios",
            Location = new Point(155, 155),
            Size = new Size(145, 35),
            Enabled = false
        };

        btnGuardar.Click += btnGuardar_Click;

        // Botón eliminar
        btnEliminar = new Button
        {
            Text = "Eliminar seleccionado",
            Location = new Point(315, 155),
            Size = new Size(180, 35)
        };

        btnEliminar.Click += btnEliminar_Click;

        // Total de contactos
        lblTotal = new Label
        {
            Name = "lblTotal",
            Text = "0 contactos",
            Location = new Point(20, 205),
            Size = new Size(250, 25),
            Font = new Font("Arial", 10, FontStyle.Bold)
        };

        // Tabla
        dgvContactos = new DataGridView
        {
            Name = "dgvContactos",
            Location = new Point(20, 235),
            Size = new Size(890, 350),
            Anchor = AnchorStyles.Top |
                     AnchorStyles.Bottom |
                     AnchorStyles.Left |
                     AnchorStyles.Right,
            ReadOnly = true,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            MultiSelect = false,
            RowHeadersVisible = false
        };

        dgvContactos.CellDoubleClick += dgvContactos_CellDoubleClick;

        // Agregar controles a la ventana
        Controls.Add(lblTitulo);
        Controls.Add(lblBuscar);
        Controls.Add(txtBuscar);

        Controls.Add(lblNombre);
        Controls.Add(txtNombre);

        Controls.Add(lblTelefono);
        Controls.Add(txtTelefono);

        Controls.Add(lblCorreo);
        Controls.Add(txtCorreo);

        Controls.Add(btnAgregar);
        Controls.Add(btnGuardar);
        Controls.Add(btnEliminar);

        Controls.Add(lblTotal);
        Controls.Add(dgvContactos);
    }

    // Cargar los contactos y aplicar el filtro de búsqueda.
    private void CargarContactos(string filtro = "")
    {
        using var db = new AgendaContext();

        var contactos = db.Contactos
            .Where(c => EF.Functions.Like(c.Nombre, $"%{filtro}%"))
            .OrderBy(c => c.Nombre)
            .ToList();

        dgvContactos.DataSource = contactos;

        lblTotal.Text = $"{contactos.Count} contactos";
    }

    // Buscar mientras el usuario escribe.
    private void txtBuscar_TextChanged(object sender, EventArgs e)
    {
        CargarContactos(txtBuscar.Text.Trim());
    }

    // Validar los campos del formulario.
    private bool ValidarCampos()
    {
        errorProvider1.Clear();

        bool valido = true;

        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            errorProvider1.SetError(
                txtNombre,
                "El nombre es obligatorio.");

            valido = false;
        }

        if (string.IsNullOrWhiteSpace(txtCorreo.Text) ||
            !txtCorreo.Text.Contains("@"))
        {
            errorProvider1.SetError(
                txtCorreo,
                "Escribe un correo válido que contenga @.");

            valido = false;
        }

        return valido;
    }

    // Agregar un contacto.
    private void btnAgregar_Click(object sender, EventArgs e)
    {
        if (!ValidarCampos())
            return;

        using var db = new AgendaContext();

        Contacto nuevoContacto = new Contacto
        {
            Nombre = txtNombre.Text.Trim(),
            Telefono = txtTelefono.Text.Trim(),
            Correo = txtCorreo.Text.Trim()
        };

        db.Contactos.Add(nuevoContacto);
        db.SaveChanges();

        LimpiarCampos();
        CargarContactos(txtBuscar.Text.Trim());

        MessageBox.Show(
            "Contacto agregado correctamente.",
            "Agenda",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    // Eliminar el contacto seleccionado.
    private void btnEliminar_Click(object sender, EventArgs e)
    {
        if (dgvContactos.CurrentRow?.DataBoundItem
            is not Contacto contacto)
        {
            MessageBox.Show("Selecciona un contacto para eliminar.");
            return;
        }

        DialogResult respuesta = MessageBox.Show(
            $"¿Deseas eliminar a {contacto.Nombre}?",
            "Confirmar eliminación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (respuesta != DialogResult.Yes)
            return;

        using var db = new AgendaContext();

        var contactoBD = db.Contactos.Find(contacto.Id);

        if (contactoBD != null)
        {
            db.Contactos.Remove(contactoBD);
            db.SaveChanges();
        }

        LimpiarCampos();
        CargarContactos(txtBuscar.Text.Trim());

        MessageBox.Show("Contacto eliminado correctamente.");
    }

    // Cargar los datos al hacer doble clic en una fila.
    private void dgvContactos_CellDoubleClick(
        object sender,
        DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        if (dgvContactos.Rows[e.RowIndex].DataBoundItem
            is not Contacto contacto)
            return;

        contactoEditandoId = contacto.Id;

        txtNombre.Text = contacto.Nombre;
        txtTelefono.Text = contacto.Telefono;
        txtCorreo.Text = contacto.Correo;

        btnGuardar.Enabled = true;
        btnAgregar.Enabled = false;
    }

    // Guardar los cambios del contacto seleccionado.
    private void btnGuardar_Click(object sender, EventArgs e)
    {
        if (contactoEditandoId == null)
            return;

        if (!ValidarCampos())
            return;

        using var db = new AgendaContext();

        var contacto = db.Contactos.Find(contactoEditandoId.Value);

        if (contacto == null)
        {
            MessageBox.Show("No se encontró el contacto.");
            LimpiarCampos();
            CargarContactos(txtBuscar.Text.Trim());
            return;
        }

        contacto.Nombre = txtNombre.Text.Trim();
        contacto.Telefono = txtTelefono.Text.Trim();
        contacto.Correo = txtCorreo.Text.Trim();

        db.SaveChanges();

        LimpiarCampos();
        CargarContactos(txtBuscar.Text.Trim());

        MessageBox.Show("Contacto actualizado correctamente.");
    }

    // Limpiar los campos y restablecer los botones.
    private void LimpiarCampos()
    {
        txtNombre.Clear();
        txtTelefono.Clear();
        txtCorreo.Clear();

        errorProvider1.Clear();

        contactoEditandoId = null;

        btnAgregar.Enabled = true;
        btnGuardar.Enabled = false;
    }
}
