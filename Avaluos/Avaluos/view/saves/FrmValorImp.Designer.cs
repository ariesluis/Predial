namespace Avaluos.view.saves
{
    partial class FrmValorImp
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
            this.nudServAdmi = new System.Windows.Forms.NumericUpDown();
            this.nudBombero = new System.Windows.Forms.NumericUpDown();
            this.nudBanda = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.lblUnidadMedida = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.nudSbu = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudServAdmi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBombero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBanda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSbu)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudServAdmi);
            this.groupBox1.Controls.Add(this.nudBombero);
            this.groupBox1.Controls.Add(this.nudBanda);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblUnidadMedida);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnRegistrar);
            this.groupBox1.Controls.Add(this.nudSbu);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(51, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 220);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos:";
            // 
            // nudServAdmi
            // 
            this.nudServAdmi.DecimalPlaces = 2;
            this.nudServAdmi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.nudServAdmi.Location = new System.Drawing.Point(182, 107);
            this.nudServAdmi.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudServAdmi.Name = "nudServAdmi";
            this.nudServAdmi.Size = new System.Drawing.Size(112, 21);
            this.nudServAdmi.TabIndex = 16;
            // 
            // nudBombero
            // 
            this.nudBombero.DecimalPlaces = 2;
            this.nudBombero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.nudBombero.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudBombero.Location = new System.Drawing.Point(182, 145);
            this.nudBombero.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudBombero.Name = "nudBombero";
            this.nudBombero.Size = new System.Drawing.Size(112, 21);
            this.nudBombero.TabIndex = 15;
            // 
            // nudBanda
            // 
            this.nudBanda.DecimalPlaces = 2;
            this.nudBanda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.nudBanda.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudBanda.Location = new System.Drawing.Point(182, 31);
            this.nudBanda.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudBanda.Name = "nudBanda";
            this.nudBanda.Size = new System.Drawing.Size(112, 21);
            this.nudBanda.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(11, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(162, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "Tasa Servicio Administrativo:";
            // 
            // lblUnidadMedida
            // 
            this.lblUnidadMedida.AutoSize = true;
            this.lblUnidadMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblUnidadMedida.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUnidadMedida.Location = new System.Drawing.Point(11, 147);
            this.lblUnidadMedida.Name = "lblUnidadMedida";
            this.lblUnidadMedida.Size = new System.Drawing.Size(127, 15);
            this.lblUnidadMedida.TabIndex = 10;
            this.lblUnidadMedida.Text = "Cuerpo de Bomberos:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(11, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Banda Impositiva:";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnRegistrar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRegistrar.Location = new System.Drawing.Point(111, 183);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(100, 24);
            this.btnRegistrar.TabIndex = 6;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // nudSbu
            // 
            this.nudSbu.DecimalPlaces = 2;
            this.nudSbu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.nudSbu.Location = new System.Drawing.Point(182, 71);
            this.nudSbu.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudSbu.Name = "nudSbu";
            this.nudSbu.Size = new System.Drawing.Size(112, 21);
            this.nudSbu.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(11, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Salario Básico Unificado:";
            // 
            // FrmValorImp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 287);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(434, 329);
            this.Name = "FrmValorImp";
            this.Text = "Valor del Impuesto Predial Rural";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudServAdmi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBombero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBanda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSbu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblUnidadMedida;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.NumericUpDown nudSbu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudBanda;
        private System.Windows.Forms.NumericUpDown nudServAdmi;
        private System.Windows.Forms.NumericUpDown nudBombero;
    }
}