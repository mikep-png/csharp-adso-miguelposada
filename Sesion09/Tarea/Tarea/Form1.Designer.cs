using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Tarea
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            lblValor = new System.Windows.Forms.Label();
            txtValor = new System.Windows.Forms.TextBox();
            lblOrigen = new System.Windows.Forms.Label();
            cmbOrigen = new System.Windows.Forms.ComboBox();
            lblDestino = new System.Windows.Forms.Label();
            cmbDestino = new System.Windows.Forms.ComboBox();
            btnConvertir = new System.Windows.Forms.Button();
            lblResultado = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Location = new System.Drawing.Point(35, 30);
            lblValor.Name = "lblValor";
            lblValor.Size = new System.Drawing.Size(37, 15);
            lblValor.TabIndex = 5;
            lblValor.Text = "Valor:";
            // 
            // txtValor
            // 
            txtValor.Location = new System.Drawing.Point(110, 27);
            txtValor.Name = "txtValor";
            txtValor.Size = new System.Drawing.Size(180, 23);
            txtValor.TabIndex = 0;
            // 
            // lblOrigen
            // 
            lblOrigen.AutoSize = true;
            lblOrigen.Location = new System.Drawing.Point(35, 70);
            lblOrigen.Name = "lblOrigen";
            lblOrigen.Size = new System.Drawing.Size(25, 15);
            lblOrigen.TabIndex = 6;
            lblOrigen.Text = "De:";
            // 
            // cmbOrigen
            // 
            cmbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbOrigen.FormattingEnabled = true;
            cmbOrigen.Items.AddRange(new object[] { "°C", "°F", "K" });
            cmbOrigen.Location = new System.Drawing.Point(110, 67);
            cmbOrigen.Name = "cmbOrigen";
            cmbOrigen.Size = new System.Drawing.Size(180, 23);
            cmbOrigen.TabIndex = 1;
            // 
            // lblDestino
            // 
            lblDestino.AutoSize = true;
            lblDestino.Location = new System.Drawing.Point(35, 110);
            lblDestino.Name = "lblDestino";
            lblDestino.Size = new System.Drawing.Size(18, 15);
            lblDestino.TabIndex = 7;
            lblDestino.Text = "A:";
            // 
            // cmbDestino
            // 
            cmbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbDestino.FormattingEnabled = true;
            cmbDestino.Items.AddRange(new object[] { "°C", "°F", "K" });
            cmbDestino.Location = new System.Drawing.Point(110, 107);
            cmbDestino.Name = "cmbDestino";
            cmbDestino.Size = new System.Drawing.Size(180, 23);
            cmbDestino.TabIndex = 2;
            // 
            // btnConvertir
            // 
            btnConvertir.Location = new System.Drawing.Point(110, 150);
            btnConvertir.Name = "btnConvertir";
            btnConvertir.Size = new System.Drawing.Size(180, 30);
            btnConvertir.TabIndex = 3;
            btnConvertir.Text = "Convertir";
            btnConvertir.UseVisualStyleBackColor = true;
            btnConvertir.Click += btnConvertir_Click;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblResultado.ForeColor = System.Drawing.Color.MidnightBlue;
            lblResultado.Location = new System.Drawing.Point(35, 200);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new System.Drawing.Size(105, 20);
            lblResultado.TabIndex = 4;
            lblResultado.Text = "Resultado: ---";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            AcceptButton = btnConvertir;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(340, 250);
            Controls.Add(lblResultado);
            Controls.Add(btnConvertir);
            Controls.Add(cmbDestino);
            Controls.Add(lblDestino);
            Controls.Add(cmbOrigen);
            Controls.Add(lblOrigen);
            Controls.Add(txtValor);
            Controls.Add(lblValor);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Conversor de Temperatura";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.ComboBox cmbOrigen;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.ComboBox cmbDestino;
        private System.Windows.Forms.Button btnConvertir;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
