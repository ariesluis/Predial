namespace Avaluos.view
{
    partial class FrmSaveValores
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.spnCod = new System.Windows.Forms.NumericUpDown();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboUnidMedida = new System.Windows.Forms.ComboBox();
            this.lblUnidadMedida = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.spnPrecio = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboValorAdd = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnCod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPrecio)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.spnCod);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cboUnidMedida);
            this.groupBox1.Controls.Add(this.lblUnidadMedida);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnRegistrar);
            this.groupBox1.Controls.Add(this.spnPrecio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(72, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 213);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Valor Materiales";
            // 
            // spnCod
            // 
            this.spnCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.spnCod.Location = new System.Drawing.Point(124, 33);
            this.spnCod.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.spnCod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnCod.Name = "spnCod";
            this.spnCod.Size = new System.Drawing.Size(112, 21);
            this.spnCod.TabIndex = 14;
            this.spnCod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtDesc
            // 
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtDesc.Location = new System.Drawing.Point(124, 109);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(112, 21);
            this.txtDesc.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(30, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "Descripción:";
            // 
            // cboUnidMedida
            // 
            this.cboUnidMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboUnidMedida.FormattingEnabled = true;
            this.cboUnidMedida.Items.AddRange(new object[] {
            "m3",
            "Kg",
            "m2",
            "m",
            "u"});
            this.cboUnidMedida.Location = new System.Drawing.Point(124, 147);
            this.cboUnidMedida.Name = "cboUnidMedida";
            this.cboUnidMedida.Size = new System.Drawing.Size(112, 23);
            this.cboUnidMedida.TabIndex = 11;
            // 
            // lblUnidadMedida
            // 
            this.lblUnidadMedida.AutoSize = true;
            this.lblUnidadMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblUnidadMedida.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUnidadMedida.Location = new System.Drawing.Point(30, 147);
            this.lblUnidadMedida.Name = "lblUnidadMedida";
            this.lblUnidadMedida.Size = new System.Drawing.Size(88, 15);
            this.lblUnidadMedida.TabIndex = 10;
            this.lblUnidadMedida.Text = "Unida Medida:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(30, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Código:";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnRegistrar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRegistrar.Location = new System.Drawing.Point(89, 178);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(100, 24);
            this.btnRegistrar.TabIndex = 6;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // spnPrecio
            // 
            this.spnPrecio.DecimalPlaces = 2;
            this.spnPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.spnPrecio.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spnPrecio.Location = new System.Drawing.Point(124, 71);
            this.spnPrecio.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.spnPrecio.Name = "spnPrecio";
            this.spnPrecio.Size = new System.Drawing.Size(112, 21);
            this.spnPrecio.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(30, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Precio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Valores de Agregación:";
            // 
            // cboValorAdd
            // 
            this.cboValorAdd.FormattingEnabled = true;
            this.cboValorAdd.Items.AddRange(new object[] {
            "Materiales Generales",
            "Mano de Obra",
            "Equipo y Maquinaria"});
            this.cboValorAdd.Location = new System.Drawing.Point(218, 13);
            this.cboValorAdd.Name = "cboValorAdd";
            this.cboValorAdd.Size = new System.Drawing.Size(122, 21);
            this.cboValorAdd.TabIndex = 15;
            this.cboValorAdd.SelectedIndexChanged += new System.EventHandler(this.cboValorAdd_SelectedIndexChanged);
            // 
            // FrmSaveValores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 287);
            this.Controls.Add(this.cboValorAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSaveValores";
            this.Text = "Valor Agregación Materiales";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnCod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPrecio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboUnidMedida;
        private System.Windows.Forms.Label lblUnidadMedida;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.NumericUpDown spnPrecio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.NumericUpDown spnCod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboValorAdd;
    }
}