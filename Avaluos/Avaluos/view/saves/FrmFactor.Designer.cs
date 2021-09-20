namespace Avaluos.view.saves
{
    partial class FrmFactor
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
            this.gpx = new System.Windows.Forms.GroupBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.spnCoef = new System.Windows.Forms.NumericUpDown();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboFactor = new System.Windows.Forms.ComboBox();
            this.gbxPendiente = new System.Windows.Forms.GroupBox();
            this.cboDesc = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboPorc = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboClas = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.gpx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnCoef)).BeginInit();
            this.gbxPendiente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // gpx
            // 
            this.gpx.Controls.Add(this.btnRegistrar);
            this.gpx.Controls.Add(this.spnCoef);
            this.gpx.Controls.Add(this.txtDesc);
            this.gpx.Controls.Add(this.label2);
            this.gpx.Controls.Add(this.label3);
            this.gpx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gpx.Location = new System.Drawing.Point(69, 82);
            this.gpx.Name = "gpx";
            this.gpx.Size = new System.Drawing.Size(268, 193);
            this.gpx.TabIndex = 14;
            this.gpx.TabStop = false;
            this.gpx.Text = "Factor Estado";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnRegistrar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRegistrar.Location = new System.Drawing.Point(86, 136);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(100, 24);
            this.btnRegistrar.TabIndex = 6;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // spnCoef
            // 
            this.spnCoef.DecimalPlaces = 3;
            this.spnCoef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.spnCoef.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spnCoef.Location = new System.Drawing.Point(96, 74);
            this.spnCoef.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spnCoef.Name = "spnCoef";
            this.spnCoef.Size = new System.Drawing.Size(120, 21);
            this.spnCoef.TabIndex = 5;
            // 
            // txtDesc
            // 
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtDesc.Location = new System.Drawing.Point(96, 26);
            this.txtDesc.MaxLength = 20;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(120, 21);
            this.txtDesc.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(9, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Coeficiente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripción:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(152, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Seleccione Factor:";
            // 
            // cboFactor
            // 
            this.cboFactor.FormattingEnabled = true;
            this.cboFactor.Items.AddRange(new object[] {
            "Clasificación del Suelo",
            "Régimen de Propiedad",
            "Uso de Predio",
            "Localización en la Manzana",
            "Cobertura Natural Predominante",
            "Ecosistema Relevante",
            "Tipo de Vía de Acceso",
            "Material Vía",
            "Otras Vías de Acceso",
            "Aceras",
            "Disponibilidad de Riego",
            "Método Riego",
            "Instalaciones Especiales",
            "Nivel",
            "Condición Fisica",
            "Valor Cultural",
            "Estado de Conservación",
            "Uso Constructivo",
            "Mampostería Soportante",
            "Columnas",
            "Vigas",
            "Contrapiso",
            "Entrepiso",
            "Pared",
            "Cubierta",
            "Revestimiento Pared",
            "Revestimiento Cubierta",
            "Tumbado",
            "Ventanas",
            "Vidrios",
            "Puertas",
            "Pisos",
            "Tipo de Obra o Mejora",
            "Clasificación Unidad o Vivienda",
            "Tipo Vivienda",
            "Condición de Ocupación",
            "Tenencia de la Vivienda",
            "Agua Proviene",
            "Agua Recibe",
            "Alcantarillado",
            "Energía Eléctrica",
            "Eliminación de Basura",
            "Dominio",
            "Forma Adquisición",
            "Pendiente",
            "Acabados",
            "Titularidad"});
            this.cboFactor.Location = new System.Drawing.Point(116, 35);
            this.cboFactor.Name = "cboFactor";
            this.cboFactor.Size = new System.Drawing.Size(181, 21);
            this.cboFactor.TabIndex = 15;
            this.cboFactor.SelectedIndexChanged += new System.EventHandler(this.cboFactor_SelectedIndexChanged);
            // 
            // gbxPendiente
            // 
            this.gbxPendiente.Controls.Add(this.cboDesc);
            this.gbxPendiente.Controls.Add(this.label9);
            this.gbxPendiente.Controls.Add(this.cboPorc);
            this.gbxPendiente.Controls.Add(this.label8);
            this.gbxPendiente.Controls.Add(this.cboClas);
            this.gbxPendiente.Controls.Add(this.label7);
            this.gbxPendiente.Controls.Add(this.button1);
            this.gbxPendiente.Controls.Add(this.numericUpDown1);
            this.gbxPendiente.Controls.Add(this.label4);
            this.gbxPendiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gbxPendiente.Location = new System.Drawing.Point(24, 75);
            this.gbxPendiente.Name = "gbxPendiente";
            this.gbxPendiente.Size = new System.Drawing.Size(363, 200);
            this.gbxPendiente.TabIndex = 16;
            this.gbxPendiente.TabStop = false;
            this.gbxPendiente.Text = "Factor Pendiente";
            // 
            // cboDesc
            // 
            this.cboDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboDesc.FormattingEnabled = true;
            this.cboDesc.Items.AddRange(new object[] {
            "Plana",
            "Suave",
            "Media",
            "Fuerte",
            "Muy Fuerte",
            "Escarpada",
            "Escarpada",
            "Abrupta"});
            this.cboDesc.Location = new System.Drawing.Point(114, 126);
            this.cboDesc.Name = "cboDesc";
            this.cboDesc.Size = new System.Drawing.Size(110, 23);
            this.cboDesc.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(27, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "Descripción:";
            // 
            // cboPorc
            // 
            this.cboPorc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboPorc.FormattingEnabled = true;
            this.cboPorc.Items.AddRange(new object[] {
            "0-5",
            "5-10",
            "10-20",
            "20-35",
            "35-45",
            "45-70",
            ">70"});
            this.cboPorc.Location = new System.Drawing.Point(114, 80);
            this.cboPorc.Name = "cboPorc";
            this.cboPorc.Size = new System.Drawing.Size(112, 23);
            this.cboPorc.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(27, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "Porción:";
            // 
            // cboClas
            // 
            this.cboClas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboClas.FormattingEnabled = true;
            this.cboClas.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cboClas.Location = new System.Drawing.Point(114, 34);
            this.cboClas.Name = "cboClas";
            this.cboClas.Size = new System.Drawing.Size(112, 23);
            this.cboClas.TabIndex = 9;
            this.cboClas.SelectedIndexChanged += new System.EventHandler(this.cboClas_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(27, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Clasificación:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(248, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 24);
            this.button1.TabIndex = 6;
            this.button1.Text = "Registrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(114, 172);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(112, 21);
            this.numericUpDown1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(27, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Coeficiente:";
            // 
            // FrmFactor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 287);
            this.Controls.Add(this.gbxPendiente);
            this.Controls.Add(this.cboFactor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gpx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FrmFactor";
            this.Text = "FrmFactor";
            this.gpx.ResumeLayout(false);
            this.gpx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnCoef)).EndInit();
            this.gbxPendiente.ResumeLayout(false);
            this.gbxPendiente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpx;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.NumericUpDown spnCoef;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFactor;
        private System.Windows.Forms.GroupBox gbxPendiente;
        private System.Windows.Forms.ComboBox cboDesc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboPorc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboClas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
    }
}