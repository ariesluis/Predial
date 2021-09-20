namespace Avaluos.view.modify
{
    partial class FrmModFac
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
            this.cboOpcion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbList = new System.Windows.Forms.GroupBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.gpbDatos = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.spnCoef = new System.Windows.Forms.NumericUpDown();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.spnValor = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.gpbList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.gpbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnCoef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnValor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboOpcion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            // 
            // cboOpcion
            // 
            this.cboOpcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOpcion.FormattingEnabled = true;
            this.cboOpcion.Items.AddRange(new object[] {
            "Acabado",
            "Acera",
            "Agua Proviene",
            "Agua Recibe",
            "Alcantarillado",
            "Alumbrado",
            "Clasificación Agrológica",
            "Clasificación Suelo",
            "Cobertura Natural",
            "Columna",
            "Condición Física",
            "Condición Ocupación",
            "Contrapiso",
            "Cubierta",
            "Disponibilidad Riego",
            "Dominio",
            "Ecosistema Relevante",
            "Energía Eléctrica Proviene",
            "Entrepiso",
            "Erosión",
            "Estado Conservación",
            "Estado Vía",
            "Forma del Predio",
            "Forma Adquisición",
            "Instalaciones Especiales",
            "Localización Manzana",
            "Método Riego",
            "Numero Baños",
            "Obra o Mejora",
            "Pared",
            "Pendiente",
            "Piso",
            "Poblaciones Cercanas",
            "Puerta",
            "Recolección Basura",
            "Revestido Cubierta",
            "Revestido Pared",
            "Riesgo",
            "Rodadura (Material Vía)",
            "Tenencia Vivienda",
            "Tipo Vía",
            "Titularidad",
            "Transporte Público",
            "Tumbado",
            "Unidad o Vivienda",
            "Uso Constructivo",
            "Uso del Predio",
            "Valor Cultural",
            "Ventana",
            "Viga"});
            this.cboOpcion.Location = new System.Drawing.Point(201, 24);
            this.cboOpcion.Name = "cboOpcion";
            this.cboOpcion.Size = new System.Drawing.Size(229, 21);
            this.cboOpcion.TabIndex = 1;
            this.cboOpcion.SelectedIndexChanged += new System.EventHandler(this.cboOpcion_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione la opción:";
            // 
            // gpbList
            // 
            this.gpbList.Controls.Add(this.btnSelect);
            this.gpbList.Controls.Add(this.dgvDatos);
            this.gpbList.Enabled = false;
            this.gpbList.Location = new System.Drawing.Point(12, 86);
            this.gpbList.Name = "gpbList";
            this.gpbList.Size = new System.Drawing.Size(447, 172);
            this.gpbList.TabIndex = 1;
            this.gpbList.TabStop = false;
            this.gpbList.Text = "Listado Datos";
            // 
            // btnSelect
            // 
            this.btnSelect.Enabled = false;
            this.btnSelect.Location = new System.Drawing.Point(186, 133);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Seleccionar";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(6, 19);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.Size = new System.Drawing.Size(425, 108);
            this.dgvDatos.TabIndex = 0;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            // 
            // gpbDatos
            // 
            this.gpbDatos.Controls.Add(this.lblValor);
            this.gpbDatos.Controls.Add(this.spnValor);
            this.gpbDatos.Controls.Add(this.btnSalir);
            this.gpbDatos.Controls.Add(this.btnModificar);
            this.gpbDatos.Controls.Add(this.label5);
            this.gpbDatos.Controls.Add(this.spnCoef);
            this.gpbDatos.Controls.Add(this.txtDesc);
            this.gpbDatos.Controls.Add(this.txtId);
            this.gpbDatos.Controls.Add(this.label4);
            this.gpbDatos.Controls.Add(this.label2);
            this.gpbDatos.Enabled = false;
            this.gpbDatos.Location = new System.Drawing.Point(13, 264);
            this.gpbDatos.Name = "gpbDatos";
            this.gpbDatos.Size = new System.Drawing.Size(446, 149);
            this.gpbDatos.TabIndex = 2;
            this.gpbDatos.TabStop = false;
            this.gpbDatos.Text = "Datos:";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(333, 70);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(88, 23);
            this.btnSalir.TabIndex = 25;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(333, 35);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(88, 23);
            this.btnModificar.TabIndex = 24;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(130, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Coeficiente:";
            // 
            // spnCoef
            // 
            this.spnCoef.DecimalPlaces = 2;
            this.spnCoef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.spnCoef.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spnCoef.Location = new System.Drawing.Point(199, 31);
            this.spnCoef.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spnCoef.Name = "spnCoef";
            this.spnCoef.Size = new System.Drawing.Size(60, 21);
            this.spnCoef.TabIndex = 6;
            // 
            // txtDesc
            // 
            this.txtDesc.Enabled = false;
            this.txtDesc.Location = new System.Drawing.Point(91, 67);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(138, 20);
            this.txtDesc.TabIndex = 5;
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(50, 32);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(60, 20);
            this.txtId.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Descripción:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "ID:";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(9, 108);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(34, 13);
            this.lblValor.TabIndex = 27;
            this.lblValor.Text = "Valor:";
            // 
            // spnValor
            // 
            this.spnValor.DecimalPlaces = 2;
            this.spnValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.spnValor.Location = new System.Drawing.Point(91, 104);
            this.spnValor.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.spnValor.Name = "spnValor";
            this.spnValor.Size = new System.Drawing.Size(60, 21);
            this.spnValor.TabIndex = 26;
            // 
            // FrmModFac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 425);
            this.Controls.Add(this.gpbDatos);
            this.Controls.Add(this.gpbList);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FrmModFac";
            this.Text = "Modificación Datos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpbList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.gpbDatos.ResumeLayout(false);
            this.gpbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnCoef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnValor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboOpcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpbList;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.GroupBox gpbDatos;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown spnCoef;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.NumericUpDown spnValor;
    }
}