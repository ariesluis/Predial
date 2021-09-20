namespace Avaluos.view
{
    partial class FrmSaveMatPred
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboMat = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboAcabado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.spnValor = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCons = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnValor)).BeginInit();
            this.SuspendLayout();
            // 
            // cboMat
            // 
            this.cboMat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboMat.FormattingEnabled = true;
            this.cboMat.Items.AddRange(new object[] {
            "Estructura",
            "Pared",
            "Cubierta"});
            this.cboMat.Location = new System.Drawing.Point(155, 76);
            this.cboMat.Name = "cboMat";
            this.cboMat.Size = new System.Drawing.Size(122, 23);
            this.cboMat.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "Material:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboAcabado);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboMat);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.spnValor);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCons);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnRegistrar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(26, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 243);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Materiales Predominantes Construcción";
            // 
            // cboAcabado
            // 
            this.cboAcabado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboAcabado.FormattingEnabled = true;
            this.cboAcabado.Items.AddRange(new object[] {
            "Estructura",
            "Pared",
            "Cubierta"});
            this.cboAcabado.Location = new System.Drawing.Point(155, 120);
            this.cboAcabado.Name = "cboAcabado";
            this.cboAcabado.Size = new System.Drawing.Size(122, 23);
            this.cboAcabado.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(77, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = "Acabado:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(287, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "USD/M2";
            // 
            // spnValor
            // 
            this.spnValor.DecimalPlaces = 2;
            this.spnValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.spnValor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spnValor.Location = new System.Drawing.Point(155, 164);
            this.spnValor.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.spnValor.Name = "spnValor";
            this.spnValor.Size = new System.Drawing.Size(122, 21);
            this.spnValor.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(97, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Valor:";
            // 
            // txtCons
            // 
            this.txtCons.Location = new System.Drawing.Point(155, 34);
            this.txtCons.Name = "txtCons";
            this.txtCons.Size = new System.Drawing.Size(122, 21);
            this.txtCons.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(54, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "Construcción:";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnRegistrar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRegistrar.Location = new System.Drawing.Point(134, 203);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(100, 24);
            this.btnRegistrar.TabIndex = 6;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // FrmSaveMatPred
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 287);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSaveMatPred";
            this.Text = "Materiales Predominantes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnValor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCons;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown spnValor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboAcabado;
        private System.Windows.Forms.Label label2;
    }
}