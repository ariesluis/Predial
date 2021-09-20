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
    public partial class FrmSaveMatPred : Form
    {
        public FrmSaveMatPred()
        {
            InitializeComponent();
            loadMaterialAcabado();
            this.cboMat.SelectedIndex = 0;
        }

        private void loadMaterialAcabado()
        {
            try
            {
                MaterialPredDB mpdb = new MaterialPredDB();
                mpdb.Mc.Lst = mpdb.listMatCons("factor_material_estruc");
                mpdb.Fac.Lst = mpdb.listFactorAcab();
                cboAcabado.DisplayMember = "desc";
                cboAcabado.ValueMember = "id";
                cboAcabado.DataSource = mpdb.Fac.Lst;
                cboMat.DisplayMember = "desc";
                cboMat.ValueMember = "id";
                cboMat.DataSource = mpdb.Mc.Lst;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error al cargar "+ex.Message, "Error");
            }
        }

        private void insert()
        {
            try
            {
                FactorDB fdb = new FactorDB();
                string sql = "Insert into factor_mat_pred(`ac_id`, `ma_id`,`mp_cons`, `mp_valor`) Values ("
                    + int.Parse(cboAcabado.SelectedValue.ToString())
                    + "," + int.Parse(cboMat.SelectedValue.ToString())
                    + ",'" + txtCons.Text
                    + "'," + (double)spnValor.Value
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
