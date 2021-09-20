namespace Avaluos.view
{
    partial class FrmRegMatEstruc
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
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRegMa = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEstruc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegEs = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMaterial);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnRegMa);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(51, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 113);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro Materiales Estructura";
            // 
            // txtMaterial
            // 
            this.txtMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtMaterial.Location = new System.Drawing.Point(108, 31);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(112, 21);
            this.txtMaterial.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(15, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "Material:";
            // 
            // btnRegMa
            // 
            this.btnRegMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnRegMa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRegMa.Location = new System.Drawing.Point(108, 74);
            this.btnRegMa.Name = "btnRegMa";
            this.btnRegMa.Size = new System.Drawing.Size(100, 24);
            this.btnRegMa.TabIndex = 6;
            this.btnRegMa.Text = "Registrar";
            this.btnRegMa.UseVisualStyleBackColor = true;
            this.btnRegMa.Click += new System.EventHandler(this.btnRegMa_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEstruc);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnRegEs);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(51, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 113);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registro Construcciones (Mejoras)";
            // 
            // txtEstruc
            // 
            this.txtEstruc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtEstruc.Location = new System.Drawing.Point(108, 31);
            this.txtEstruc.Name = "txtEstruc";
            this.txtEstruc.Size = new System.Drawing.Size(112, 21);
            this.txtEstruc.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(15, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Estructura:";
            // 
            // btnRegEs
            // 
            this.btnRegEs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnRegEs.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRegEs.Location = new System.Drawing.Point(108, 74);
            this.btnRegEs.Name = "btnRegEs";
            this.btnRegEs.Size = new System.Drawing.Size(100, 24);
            this.btnRegEs.TabIndex = 6;
            this.btnRegEs.Text = "Registrar";
            this.btnRegEs.UseVisualStyleBackColor = true;
            this.btnRegEs.Click += new System.EventHandler(this.btnRegEs_Click);
            // 
            // FrmRegMatEstruc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 287);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmRegMatEstruc";
            this.Text = "Registro Estructura y Materiales";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRegMa;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtEstruc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegEs;


    }
}