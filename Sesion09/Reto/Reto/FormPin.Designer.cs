namespace Reto
{
    partial class FormPin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblInstruccion = new Label();
            txtPin = new TextBox();
            btnIngresar = new Button();
            lblIntentos = new Label();
            SuspendLayout();
            // 
            // lblInstruccion
            // 
            lblInstruccion.AutoSize = true;
            lblInstruccion.Location = new Point(35, 25);
            lblInstruccion.Name = "lblInstruccion";
            lblInstruccion.Size = new Size(165, 15);
            lblInstruccion.TabIndex = 2;
            lblInstruccion.Text = "Ingresa tu PIN de 4 dígitos:";
            // 
            // txtPin
            // 
            txtPin.Location = new Point(35, 50);
            txtPin.MaxLength = 4;
            txtPin.Name = "txtPin";
            txtPin.PasswordChar = '●';
            txtPin.Size = new Size(200, 23);
            txtPin.TabIndex = 0;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(35, 85);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(200, 28);
            btnIngresar.TabIndex = 1;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // lblIntentos
            // 
            lblIntentos.AutoSize = true;
            lblIntentos.ForeColor = Color.Firebrick;
            lblIntentos.Location = new Point(35, 125);
            lblIntentos.Name = "lblIntentos";
            lblIntentos.Size = new Size(125, 15);
            lblIntentos.TabIndex = 3;
            lblIntentos.Text = "Intentos restantes: 3";
            // 
            // FormPin
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(270, 165);
            Controls.Add(lblIntentos);
            Controls.Add(btnIngresar);
            Controls.Add(txtPin);
            Controls.Add(lblInstruccion);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Validación de Seguridad";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInstruccion;
        private TextBox txtPin;
        private Button btnIngresar;
        private Label lblIntentos;
    }
}
