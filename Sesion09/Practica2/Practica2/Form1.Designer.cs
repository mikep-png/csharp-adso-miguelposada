namespace Practica2
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
            txtNombre = new TextBox();
            nudEdad = new NumericUpDown();
            cmbPrograma = new ComboBox();
            rdbManana = new RadioButton();
            rdbTarde = new RadioButton();
            chkTerminos = new CheckBox();
            btnInscribir = new Button();
            lstInscritos = new ListBox();
            errorProvider1 = new ErrorProvider(components);
            lblNombre = new Label();
            lblEdad = new Label();
            lblPrograma = new Label();
            ((System.ComponentModel.ISupportInitialize)nudEdad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(40, 32);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(106, 15);
            lblNombre.TabIndex = 8;
            lblNombre.Text = "Nombre completo:";
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNombre.Location = new Point(160, 29);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(300, 23);
            txtNombre.TabIndex = 0;
            // 
            // lblEdad
            // 
            lblEdad.AutoSize = true;
            lblEdad.Location = new Point(40, 72);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(36, 15);
            lblEdad.TabIndex = 9;
            lblEdad.Text = "Edad:";
            // 
            // nudEdad
            // 
            nudEdad.Location = new Point(160, 70);
            nudEdad.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            nudEdad.Minimum = new decimal(new int[] { 14, 0, 0, 0 });
            nudEdad.Name = "nudEdad";
            nudEdad.Size = new Size(80, 23);
            nudEdad.TabIndex = 1;
            nudEdad.Value = new decimal(new int[] { 14, 0, 0, 0 });
            // 
            // lblPrograma
            // 
            lblPrograma.AutoSize = true;
            lblPrograma.Location = new Point(40, 112);
            lblPrograma.Name = "lblPrograma";
            lblPrograma.Size = new Size(62, 15);
            lblPrograma.TabIndex = 10;
            lblPrograma.Text = "Programa:";
            // 
            // cmbPrograma
            // 
            cmbPrograma.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPrograma.FormattingEnabled = true;
            cmbPrograma.Items.AddRange(new object[] { "ADSO", "Multimedia", "Contabilidad" });
            cmbPrograma.Location = new Point(160, 109);
            cmbPrograma.Name = "cmbPrograma";
            cmbPrograma.Size = new Size(180, 23);
            cmbPrograma.TabIndex = 2;
            // 
            // rdbManana
            // 
            rdbManana.AutoSize = true;
            rdbManana.Checked = true;
            rdbManana.Location = new Point(160, 150);
            rdbManana.Name = "rdbManana";
            rdbManana.Size = new Size(68, 19);
            rdbManana.TabIndex = 3;
            rdbManana.TabStop = true;
            rdbManana.Text = "Mañana";
            rdbManana.UseVisualStyleBackColor = true;
            // 
            // rdbTarde
            // 
            rdbTarde.AutoSize = true;
            rdbTarde.Location = new Point(245, 150);
            rdbTarde.Name = "rdbTarde";
            rdbTarde.Size = new Size(54, 19);
            rdbTarde.TabIndex = 4;
            rdbTarde.Text = "Tarde";
            rdbTarde.UseVisualStyleBackColor = true;
            // 
            // chkTerminos
            // 
            chkTerminos.AutoSize = true;
            chkTerminos.Location = new Point(160, 185);
            chkTerminos.Name = "chkTerminos";
            chkTerminos.Size = new Size(134, 19);
            chkTerminos.TabIndex = 5;
            chkTerminos.Text = "Acepto los términos";
            chkTerminos.UseVisualStyleBackColor = true;
            // 
            // btnInscribir
            // 
            btnInscribir.Location = new Point(160, 220);
            btnInscribir.Name = "btnInscribir";
            btnInscribir.Size = new Size(110, 28);
            btnInscribir.TabIndex = 6;
            btnInscribir.Text = "Inscribir";
            btnInscribir.UseVisualStyleBackColor = true;
            btnInscribir.Click += btnInscribir_Click;
            // 
            // lstInscritos
            // 
            lstInscritos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstInscritos.FormattingEnabled = true;
            lstInscritos.ItemHeight = 15;
            lstInscritos.Location = new Point(40, 265);
            lstInscritos.Name = "lstInscritos";
            lstInscritos.Size = new Size(420, 140);
            lstInscritos.TabIndex = 7;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            AcceptButton = btnInscribir;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 430);
            Controls.Add(lblPrograma);
            Controls.Add(lblEdad);
            Controls.Add(lblNombre);
            Controls.Add(lstInscritos);
            Controls.Add(btnInscribir);
            Controls.Add(chkTerminos);
            Controls.Add(rdbTarde);
            Controls.Add(rdbManana);
            Controls.Add(cmbPrograma);
            Controls.Add(nudEdad);
            Controls.Add(txtNombre);
            Name = "Form1";
            Text = "Inscripciones";
            ((System.ComponentModel.ISupportInitialize)nudEdad).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private NumericUpDown nudEdad;
        private ComboBox cmbPrograma;
        private RadioButton rdbManana;
        private RadioButton rdbTarde;
        private CheckBox chkTerminos;
        private Button btnInscribir;
        private ListBox lstInscritos;
        private ErrorProvider errorProvider1;
        private Label lblNombre;
        private Label lblEdad;
        private Label lblPrograma;
    }
}
