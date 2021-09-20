using Avaluos.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Avaluos.Util;

namespace Avaluos.view
{
    public partial class FrmRegMatEstruc : Form
    {
        public FrmRegMatEstruc()
        {
            InitializeComponent();
        }

        private void btnRegMa_Click(object sender, EventArgs e)
        {
            if (txtMaterial.Text.Trim()!="")
            {
                insert(0);
                Controller.ClearControl(this);
            }
            else { MessageBox.Show("Hay valores en blanco", "Advertencia", MessageBoxButtons.OK); }
        }

        private void btnRegEs_Click(object sender, EventArgs e)
        {
            if (txtEstruc.Text.Trim() != "")
            {
                insert(1);
                Controller.ClearControl(this);
            }
            else { MessageBox.Show("Hay valores en blanco", "Advertencia", MessageBoxButtons.OK); }
        }

        private void insert(int param)
        {
            try
            {
                FactorDB fdb = new FactorDB();
                string sql = "";
                if (param == 0)
                {
                    sql = "Insert into factor_material_estruc (`ma_desc`) Values ('"
                    + txtMaterial.Text
                    + "')";
                }
                else 
                {
                    sql = "Insert into factor_construccion (`co_desc`) Values ('"
                    + txtEstruc.Text
                    + "')";
                }
                
                int rta = fdb.insertFactor(sql);
                if (rta == 0) { MessageBox.Show("No registrado", "Error", MessageBoxButtons.OK); }
                else { MessageBox.Show("Registrado", "Listo", MessageBoxButtons.OK); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar los datos " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
    }
}
