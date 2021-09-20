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
    public partial class FrmSaveValores : Form
    {
        private int pos;
        public FrmSaveValores()
        {
            InitializeComponent();
            this.cboValorAdd.SelectedIndex = 0;
        }

        private void cboValorAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            pos = cboValorAdd.SelectedIndex;
            if (cboValorAdd.SelectedIndex == 0) { lblUnidadMedida.Show(); cboUnidMedida.Show(); }
            else{ lblUnidadMedida.Hide(); cboUnidMedida.Hide(); }
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

        private void insert()
        {
            try
            {
                FactorDB fdb = new FactorDB();
                string sql = "";
                if (pos == 0)
                {
                    sql = "Insert into factor_valor_material (`vm_cod`, `vm_desc`, `vm_unid`, `vm_precio`) Values ("
                        + (int)spnCod.Value
                        + ",'" + txtDesc.Text
                        + "','" + cboUnidMedida.SelectedItem.ToString()
                        + "'," + (double)spnPrecio.Value
                        + ")";
                }
                if (pos == 1)
                {
                    sql = "Insert into factor_valor_mo (`vmo_cod`, `vmo_desc`, `vmo_jornal`) Values ("
                        + (int)spnCod.Value
                        + ",'" + txtDesc.Text
                        + "'," + (double)spnPrecio.Value
                        + ")";
                }
                if (pos == 2)
                {
                    sql = "Insert into factor_valor_maquinaria (`vme_cod`, `vme_desc`, `vme_cost_hor`) Values ("
                        + (int)spnCod.Value
                        + ",'" + txtDesc.Text
                        + "'," + (double)spnPrecio.Value
                        + ")";
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
