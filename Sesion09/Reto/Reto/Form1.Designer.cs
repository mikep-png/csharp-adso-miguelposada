namespace Reto
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
            lblTitular = new Label();
            lblSaldo = new Label();
            lblMonto = new Label();
            nudMonto = new NumericUpDown();
            btnDepositar = new Button();
            btnRetirar = new Button();
            lstMovimientos = new ListBox();
            ((System.ComponentModel.ISupportInitialize)nudMonto).BeginInit();
            SuspendLayout();
            // 
            // lblTitular
            // 
            lblTitular.AutoSize = true;
            lblTitular.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitular.Location = new Point(30, 25);
            lblTitular.Name = "lblTitular";
            lblTitular.Size = new Size(120, 19);
            lblTitular.TabIndex = 5;
            lblTitular.Text = "Titular: ---";
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSaldo.ForeColor = Color.DarkGreen;
            lblSaldo.Location = new Point(30, 55);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(110, 21);
            lblSaldo.TabIndex = 6;
            lblSaldo.Text = "Saldo: $0";
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(30, 105);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(46, 15);
            lblMonto.TabIndex = 7;
            lblMonto.Text = "Monto:";
            // 
            // nudMonto
            // 
            nudMonto.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            nudMonto.Location = new Point(85, 102);
            nudMonto.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudMonto.Minimum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudMonto.Name = "nudMonto";
            nudMonto.Size = new Size(150, 23);
            nudMonto.TabIndex = 0;
            nudMonto.ThousandsSeparator = true;
            nudMonto.Value = new decimal(new int[] { 10000, 0, 0, 0 });
            // 
            // btnDepositar
            // 
            btnDepositar.Location = new Point(255, 100);
            btnDepositar.Name = "btnDepositar";
            btnDepositar.Size = new Size(95, 28);
            btnDepositar.TabIndex = 1;
            btnDepositar.Text = "Depositar";
            btnDepositar.UseVisualStyleBackColor = true;
            btnDepositar.Click += btnDepositar_Click;
            // 
            // btnRetirar
            // 
            btnRetirar.Location = new Point(360, 100);
            btnRetirar.Name = "btnRetirar";
            btnRetirar.Size = new Size(95, 28);
            btnRetirar.TabIndex = 2;
            btnRetirar.Text = "Retirar";
            btnRetirar.UseVisualStyleBackColor = true;
            btnRetirar.Click += btnRetirar_Click;
            // 
            // lstMovimientos
            // 
            lstMovimientos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstMovimientos.FormattingEnabled = true;
            lstMovimientos.ItemHeight = 15;
            lstMovimientos.Location = new Point(30, 150);
            lstMovimientos.Name = "lstMovimientos";
            lstMovimientos.Size = new Size(425, 184);
            lstMovimientos.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(485, 360);
            Controls.Add(lstMovimientos);
            Controls.Add(btnRetirar);
            Controls.Add(btnDepositar);
            Controls.Add(nudMonto);
            Controls.Add(lblMonto);
            Controls.Add(lblSaldo);
            Controls.Add(lblTitular);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cajero Automático";
            ((System.ComponentModel.ISupportInitialize)nudMonto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitular;
        private Label lblSaldo;
        private Label lblMonto;
        private NumericUpDown nudMonto;
        private Button btnDepositar;
        private Button btnRetirar;
        private ListBox lstMovimientos;
    }
}
