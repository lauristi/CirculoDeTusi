namespace CirculoDeTusi
{
    partial class frmEfeitoTusi
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
            chkExibirLinhas = new CheckBox();
            TotalCirculos = new NumericUpDown();
            label1 = new Label();
            chkExibirCirculo = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)TotalCirculos).BeginInit();
            SuspendLayout();
            // 
            // chkExibirLinhas
            // 
            chkExibirLinhas.AutoSize = true;
            chkExibirLinhas.ForeColor = Color.White;
            chkExibirLinhas.Location = new Point(172, 12);
            chkExibirLinhas.Name = "chkExibirLinhas";
            chkExibirLinhas.Size = new Size(146, 19);
            chkExibirLinhas.TabIndex = 1;
            chkExibirLinhas.Text = "Mostrar llinhas de guia";
            chkExibirLinhas.UseMnemonic = false;
            chkExibirLinhas.UseVisualStyleBackColor = true;
            // 
            // TotalCirculos
            // 
            TotalCirculos.BorderStyle = BorderStyle.FixedSingle;
            TotalCirculos.Location = new Point(321, 8);
            TotalCirculos.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            TotalCirculos.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            TotalCirculos.Name = "TotalCirculos";
            TotalCirculos.Size = new Size(120, 23);
            TotalCirculos.TabIndex = 2;
            TotalCirculos.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ActiveCaption;
            label1.Location = new Point(780, 9);
            label1.Name = "label1";
            label1.Size = new Size(92, 21);
            label1.TabIndex = 3;
            label1.Text = "Par de Tusi";
            // 
            // chkExibirCirculo
            // 
            chkExibirCirculo.AutoSize = true;
            chkExibirCirculo.ForeColor = Color.White;
            chkExibirCirculo.Location = new Point(22, 11);
            chkExibirCirculo.Name = "chkExibirCirculo";
            chkExibirCirculo.Size = new Size(132, 19);
            chkExibirCirculo.TabIndex = 4;
            chkExibirCirculo.Text = "Mostrar círculo guia";
            chkExibirCirculo.UseVisualStyleBackColor = true;
            // 
            // frmEfeitoTusi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(884, 861);
            Controls.Add(chkExibirCirculo);
            Controls.Add(label1);
            Controls.Add(TotalCirculos);
            Controls.Add(chkExibirLinhas);
            Name = "frmEfeitoTusi";
            Text = "Efeito Tusi";
            Load += frmEfeitoTusi_Load;
            ((System.ComponentModel.ISupportInitialize)TotalCirculos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CheckBox chkExibirLinhas;
        private NumericUpDown TotalCirculos;
        private Label label1;
        private CheckBox chkExibirCirculo;
    }
}
