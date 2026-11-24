namespace Practica1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblSaludo = new Label();
            lblnumero1 = new Label();
            lblnumero2 = new Label();
            lblnumero3 = new Label();
            numero1 = new TextBox();
            numero2 = new TextBox();
            txtResultado = new TextBox();
            btnSumar = new Button();
            btnRestar = new Button();
            btnMultiplicar = new Button();
            btnDividir = new Button();
            pictureBox1 = new PictureBox();
            SonidoGracioso = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblSaludo
            // 
            lblSaludo.AutoSize = true;
            lblSaludo.Location = new Point(66, 189);
            lblSaludo.Name = "lblSaludo";
            lblSaludo.Size = new Size(0, 15);
            lblSaludo.TabIndex = 3;
            // 
            // lblnumero1
            // 
            lblnumero1.AutoSize = true;
            lblnumero1.Location = new Point(66, 105);
            lblnumero1.Name = "lblnumero1";
            lblnumero1.Size = new Size(60, 15);
            lblnumero1.TabIndex = 4;
            lblnumero1.Text = "Número 1";
            // 
            // lblnumero2
            // 
            lblnumero2.AutoSize = true;
            lblnumero2.Location = new Point(66, 149);
            lblnumero2.Name = "lblnumero2";
            lblnumero2.Size = new Size(60, 15);
            lblnumero2.TabIndex = 5;
            lblnumero2.Text = "Número 2";
            // 
            // lblnumero3
            // 
            lblnumero3.AutoSize = true;
            lblnumero3.Location = new Point(66, 208);
            lblnumero3.Name = "lblnumero3";
            lblnumero3.Size = new Size(59, 15);
            lblnumero3.TabIndex = 6;
            lblnumero3.Text = "Resultado";
            // 
            // numero1
            // 
            numero1.Location = new Point(124, 102);
            numero1.Name = "numero1";
            numero1.Size = new Size(100, 23);
            numero1.TabIndex = 7;
            // 
            // numero2
            // 
            numero2.Location = new Point(124, 149);
            numero2.Name = "numero2";
            numero2.Size = new Size(100, 23);
            numero2.TabIndex = 8;
            // 
            // txtResultado
            // 
            txtResultado.Location = new Point(124, 208);
            txtResultado.Name = "txtResultado";
            txtResultado.Size = new Size(100, 23);
            txtResultado.TabIndex = 9;
            // 
            // btnSumar
            // 
            btnSumar.Location = new Point(230, 74);
            btnSumar.Name = "btnSumar";
            btnSumar.Size = new Size(110, 54);
            btnSumar.TabIndex = 11;
            btnSumar.Text = "+";
            btnSumar.UseVisualStyleBackColor = true;
            btnSumar.Click += btnSumar_Click;
            // 
            // btnRestar
            // 
            btnRestar.Location = new Point(341, 74);
            btnRestar.Name = "btnRestar";
            btnRestar.Size = new Size(108, 61);
            btnRestar.TabIndex = 12;
            btnRestar.Text = "-";
            btnRestar.UseVisualStyleBackColor = true;
            btnRestar.Click += btnRestar_Click_1;
            // 
            // btnMultiplicar
            // 
            btnMultiplicar.Location = new Point(230, 145);
            btnMultiplicar.Name = "btnMultiplicar";
            btnMultiplicar.Size = new Size(105, 78);
            btnMultiplicar.TabIndex = 13;
            btnMultiplicar.Text = "*";
            btnMultiplicar.UseVisualStyleBackColor = true;
            btnMultiplicar.Click += btnMultiplicar_Click_1;
            // 
            // btnDividir
            // 
            btnDividir.Location = new Point(341, 141);
            btnDividir.Name = "btnDividir";
            btnDividir.Size = new Size(108, 82);
            btnDividir.TabIndex = 14;
            btnDividir.Text = "/";
            btnDividir.UseVisualStyleBackColor = true;
            btnDividir.Click += button4_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(519, -54);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(377, 552);
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // SonidoGracioso
            // 
            SonidoGracioso.Location = new Point(145, 304);
            SonidoGracioso.Name = "SonidoGracioso";
            SonidoGracioso.Size = new Size(75, 23);
            SonidoGracioso.TabIndex = 16;
            SonidoGracioso.Text = "Sonido";
            SonidoGracioso.UseVisualStyleBackColor = true;
            SonidoGracioso.Click += SonidoGracioso_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuHighlight;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(SonidoGracioso);
            Controls.Add(pictureBox1);
            Controls.Add(btnDividir);
            Controls.Add(btnMultiplicar);
            Controls.Add(btnRestar);
            Controls.Add(btnSumar);
            Controls.Add(txtResultado);
            Controls.Add(numero2);
            Controls.Add(numero1);
            Controls.Add(lblnumero3);
            Controls.Add(lblnumero2);
            Controls.Add(lblnumero1);
            Controls.Add(lblSaludo);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblSaludo;
        private Label lblnumero1;
        private Label lblnumero2;
        private Label lblnumero3;
        private TextBox numero1;
        private TextBox numero2;
        private TextBox txtResultado;
        private Button btnSumar;
        private Button btnRestar;
        private Button btnMultiplicar;
        private Button btnDividir;
        private PictureBox pictureBox1;
        private Button SonidoGracioso;
        private FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Timer timer1;
    }
}
