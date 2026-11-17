using System.Media;

namespace Practica1
{
    public partial class Form1 : Form
    {
        private Image imagenOriginal;
        private float angulo = 0;
        private SoundPlayer reproductor;

        public Form1()
        {
            InitializeComponent();

            // Configurar velocidad del giro (30 milisegundos) y conectar su evento
            timer1.Interval = 30;
            timer1.Tick += timer1_Tick;

            // Cargar la imagen y redimensionarla a 500x500 para que gire rápido sin trabarse
            using (Image temp = Image.FromFile(@"C:\Users\Sena\Downloads\csharp-adso-miguelposada\gorda.png"))
            {
                imagenOriginal = new Bitmap(temp, new Size(500, 500));
            }

            pictureBox1.Image = imagenOriginal;
            pictureBox1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int num1 = Convert.ToInt32(numero1.Text);
                int num2 = Convert.ToInt32(numero2.Text);

                if (num2 == 0)
                {
                    throw new ArgumentException("El divisor no puede ser cero.");
                }

                txtResultado.Text = Convert.ToString(num1 / num2);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error de argumento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa solo números válidos.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = Convert.ToString(Convert.ToInt32(numero1.Text) + Convert.ToInt32(numero2.Text));
        }

        private void btnRestar_Click_1(object sender, EventArgs e)
        {
            txtResultado.Text = Convert.ToString(Convert.ToInt32(numero1.Text) - Convert.ToInt32(numero2.Text));
        }

        private void btnMultiplicar_Click_1(object sender, EventArgs e)
        {
            txtResultado.Text = Convert.ToString(Convert.ToInt32(numero1.Text) * Convert.ToInt32(numero2.Text));
        }

        private void SonidoGracioso_Click(object sender, EventArgs e)
        {
            string entrada = PedirTexto("¿Cuál es tu peso en kg?", "Control de peso");

            if (string.IsNullOrWhiteSpace(entrada)) return;

            if (double.TryParse(entrada, out double peso))
            {
                if (peso > 80)
                {
                    // Hacer que ocupe TODO el formulario y pase por encima de los demás controles
                    pictureBox1.Dock = DockStyle.Fill;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.BringToFront();
                    pictureBox1.Visible = true;

                    timer1.Start();

                    reproductor = new SoundPlayer(@"C:\Users\Sena\Downloads\csharp-adso-miguelposada\agua.wav");
                    reproductor.PlayLooping();
                }
                else
                {
                    MessageBox.Show("Su peso es saludable.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento que hace girar la imagen continuamente
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (imagenOriginal == null) return;

            angulo += 10;
            if (angulo >= 360) angulo = 0;

            Bitmap imagenRotada = new Bitmap(imagenOriginal.Width, imagenOriginal.Height);
            using (Graphics g = Graphics.FromImage(imagenRotada))
            {
                g.TranslateTransform(imagenOriginal.Width / 2f, imagenOriginal.Height / 2f);
                g.RotateTransform(angulo);
                g.TranslateTransform(-imagenOriginal.Width / 2f, -imagenOriginal.Height / 2f);
                g.DrawImage(imagenOriginal, new Point(0, 0));
            }

            if (pictureBox1.Image != null && pictureBox1.Image != imagenOriginal)
            {
                pictureBox1.Image.Dispose();
            }
            pictureBox1.Image = imagenRotada;
        }

        private string PedirTexto(string mensaje, string titulo)
        {
            Form ventana = new Form()
            {
                Width = 320,
                Height = 160,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = titulo,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label etiqueta = new Label() { Left = 20, Top = 15, Width = 260, Text = mensaje };
            TextBox cajaTexto = new TextBox() { Left = 20, Top = 45, Width = 260 };
            Button botonAceptar = new Button() { Text = "Aceptar", Left = 180, Width = 100, Top = 80, DialogResult = DialogResult.OK };

            ventana.Controls.Add(etiqueta);
            ventana.Controls.Add(cajaTexto);
            ventana.Controls.Add(botonAceptar);
            ventana.AcceptButton = botonAceptar;

            return ventana.ShowDialog() == DialogResult.OK ? cajaTexto.Text : "";
        }
    }
}
