using Avaluos.controller;
using Avaluos.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avaluos.view.saves
{
    public partial class FrmFactor : Form
    {
        private string tabla;
        public FrmFactor()
        {
            InitializeComponent();
            gbxPendiente.Hide();
        }

        private void insert(string sql)
        {
            try
            {
                FactorDB fdb = new FactorDB();
                int rta = fdb.insertFactor(sql);
                if (rta == 0) { MessageBox.Show("No registrado", "Error", MessageBoxButtons.OK); }
                else { MessageBox.Show("Registrado", "Listo", MessageBoxButtons.OK); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar los datos " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private string sentenciaSql()
        {
            return "Insert into factor_"+ tabla +"(`desc`, `coef`) Values ('" + txtDesc.Text + "'," + (double)spnCoef.Value + ")";
        }

        private string sentenciaSqlPendiente()
        { 
            return "Insert into factor_pendiente (`clas`, `porc`, `desc`, `coef`) Values ("
                    + int.Parse(cboClas.SelectedItem.ToString())
                    + ",'" + cboPorc.SelectedItem.ToString()
                    + "','" + cboDesc.SelectedItem.ToString()
                    + "'," + (double)spnCoef.Value
                    + ")";
        }

        private void cboFactor_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbxPendiente.Hide();
            int select = cboFactor.SelectedIndex;
            tabla="";
            if (select == 0) tabla = "clas_suelo";
            if (select == 1) tabla = "reg_prop";
            if (select == 2) tabla = "uso_predio";
            if (select == 3) tabla = "loc_manz";
            if (select == 4) tabla = ("cob_nat_pred");
            if (select == 5) tabla = ("ecos_rele");
            if (select == 6) tabla = ("tipo_via");
            if (select == 7) tabla = ("rodadura");
            if (select == 8) tabla = ("otra_via");
            if (select == 9) tabla = ("acera");
            if (select == 10) tabla = ("disp_riego");
            if (select == 11) tabla = ("met_riego");
            if (select == 12) tabla = ("inst_esp");
            if (select == 13) tabla = ("nivel");
            if (select == 14) tabla = ("cond_fisica");

            if (select == 15) tabla = ("valor_cult");
            if (select == 16) tabla = ("est_conservacion");
            if (select == 17) tabla = ("uso_constructivo");
            if (select == 18) tabla = ("mampost_soport");
            if (select == 19) tabla = ("columna");
            if (select == 20) tabla = ("viga");
            if (select == 21) tabla = ("contrapiso");
            if (select == 22) tabla = ("entrepiso");
            if (select == 23) tabla = ("pared");
            if (select == 24) tabla = ("cubierta");
            if (select == 25) tabla = ("revest_pared");
            if (select == 26) tabla = ("revest_cubierta");
            if (select == 27) tabla = ("tumbado");
            if (select == 28) tabla = ("ventana");
            if (select == 29) tabla = ("vidrio");

            if (select == 30) tabla = ("puerta");
            if (select == 31) tabla = ("piso");
            if (select == 32) tabla = ("obra_mejora");
            if (select == 33) tabla = ("unidad_vivienda");
            if (select == 34) tabla = ("tipo_vivienda");
            if (select == 35) tabla = ("cond_ocup");
            if (select == 36) tabla = ("tenenc_vivienda");
            if (select == 37) tabla = ("agua_proviene");
            if (select == 38) tabla = ("agua_recibe");
            if (select == 39) tabla = ("alcantarillado");
            if (select == 40) tabla = ("electricidad");
            if (select == 41) tabla = ("recolec_basura");
            if (select == 42) tabla = ("dominio");
            if (select == 43) tabla = ("forma_adqui");

            if (select == 44) { tabla = ("pendiente"); gbxPendiente.Show(); }
            if (select == 45) tabla = ("acabado");
            if (select == 46) tabla = ("titularidad");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtDesc.Text.Trim()!="")
            {
                insert(sentenciaSql());
                Controller.ClearControl(this);
                gbxPendiente.Hide();
            }
            else { MessageBox.Show("Hay valores en blanco", "Advertencia", MessageBoxButtons.OK); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboClas.SelectedIndex>=0)
            {
                insert(sentenciaSqlPendiente());
                Controller.ClearControl(this);
                gbxPendiente.Hide();
            }
            else { MessageBox.Show("Hay valores en blanco", "Advertencia", MessageBoxButtons.OK); }
        }

        private void cboClas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selec = 0;
            selec = cboClas.SelectedIndex;
            cboDesc.SelectedIndex = selec;
            cboPorc.SelectedIndex = selec;
        }
    }
}
