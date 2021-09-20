using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Avaluos.controller;
using Avaluos.Util;

namespace Avaluos.view
{
    public partial class FrmSaveMejora : Form
    {
        public FrmSaveMejora()
        {
            InitializeComponent();
            loadMaterialCons();
        }

        private void loadMaterialCons()
        {
            try
            {
                MaterialPredDB mpdb = new MaterialPredDB();
                mpdb.Mc.Lst = mpdb.listMatCons("factor_material_estruc");
                MaterialPredDB mpdb1 = new MaterialPredDB();
                mpdb1.Mc.Lst = mpdb1.listMatCons("factor_construccion");

                cboEstruc.DisplayMember = "desc";
                cboEstruc.ValueMember = "id";
                cboEstruc.DataSource = mpdb1.Mc.Lst;
                cboMat.DisplayMember = "desc";
                cboMat.ValueMember = "id";
                cboMat.DataSource = mpdb.Mc.Lst;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error al cargar " + ex.Message, "Error");
            }
        }

        private void insert()
        {
            try
            {
                FactorDB fdb = new FactorDB();
                string sql = "Insert into factor_valor_mejora (`co_id`, `ma_id`, `vm_valor`) Values ("
                    + int.Parse(cboEstruc.SelectedValue.ToString())
                    + "," + int.Parse(cboMat.SelectedValue.ToString())
                    + "," + (double)spnPrecio.Value
                    + ")";
                int rta = fdb.insertFactor(sql);
                if (rta == 0) { MessageBox.Show("No registrado", "Error", MessageBoxButtons.OK); }
                else { MessageBox.Show("Registrado", "Listo", MessageBoxButtons.OK); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar los datos " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Controller.nullBlank(this))
            {
                insert();
                Controller.ClearControl(this);
            }
            else { MessageBox.Show("Hay valores en blanco", "Advertencia", MessageBoxButtons.OK); }
        }
    }
}
