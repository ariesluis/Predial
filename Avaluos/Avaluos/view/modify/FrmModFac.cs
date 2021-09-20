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
using Avaluos.controller;

namespace Avaluos.view.modify
{
    public partial class FrmModFac : Form
    {

        private string opcs;
        private int fila;
        
        public FrmModFac()
        {
            InitializeComponent();
            spnValor.Hide();
            lblValor.Hide();
        }

        private void cboOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int opcn = cboOpcion.SelectedIndex;
            opcs = cboOpcion.SelectedItem.ToString();
            formatTable(opcs);
            if (opcn == 0) opcs = "acabado"; if (opcn == 1) opcs = "acera"; if (opcn == 2) opcs = "agua_proviene";
            if (opcn == 3) opcs = "agua_recibe"; if (opcn == 4) opcs = "alcantarillado"; if (opcn == 5) opcs = "alumbrado"; if (opcn == 6) opcs = "clas_agrologica";
            if (opcn == 7) opcs = "clas_suelo"; if (opcn == 8) opcs = "cob_nat_pred"; if (opcn == 9) opcs = "columna";
            if (opcn == 10) opcs = "cond_fisica"; if (opcn == 11) opcs = "cond_ocup"; if (opcn == 12) opcs = "contrapiso";
            if (opcn == 13) opcs = "cubierta"; if (opcn == 14) opcs = "disp_riego"; if (opcn == 15) opcs = "dominio";
            if (opcn == 16) opcs = "ecos_rele"; if (opcn == 17) opcs = "electricidad"; if (opcn == 18) opcs = "entrepiso";
            if (opcn == 19) opcs = "erosion"; if (opcn == 20) opcs = "est_conservacion"; if (opcn == 21) opcs = "est_via";
            if (opcn == 22) opcs = "forma"; if (opcn == 23) opcs = "forma_adqui"; if (opcn == 24) opcs = "inst_esp";
            if (opcn == 25) opcs = "loc_manz"; if (opcn == 26) opcs = "met_riego"; if (opcn == 27) opcs = "num_banio";
            if (opcn == 28) opcs = "obra_mejora"; if (opcn == 29) opcs = "pared"; if (opcn == 30) opcs = "pendiente";
            if (opcn == 31) opcs = "piso"; if (opcn == 32) opcs = "poblac_cercana"; if (opcn == 33) opcs = "puerta";
            if (opcn == 34) opcs = "recolec_basura"; if (opcn == 35) opcs = "revest_cubierta"; if (opcn == 36) opcs = "revest_pared";
            if (opcn == 37) opcs = "riesgo"; if (opcn == 38) opcs = "rodadura"; if (opcn == 39) opcs = "tenenc_vivienda";
            if (opcn == 40) opcs = "tipo_via"; if (opcn == 41) opcs = "titularidad"; if (opcn == 42) opcs = "transporte_publico";
            if (opcn == 43) opcs = "tumbado"; if (opcn == 44) opcs = "unidad_vivienda"; if (opcn == 45) opcs = "uso_constructivo";
            if (opcn == 46) opcs = "uso_predio"; if (opcn == 47) opcs = "valor_cult"; if (opcn == 48) opcs = "ventana";
            if (opcn == 49) opcs = "viga";
            loadDataList(opcs);
            gpbList.Enabled = true;
        }

        private void formatTable(string opc)
        {
            dgvDatos.Columns.Clear();
            if (string.Equals(opc, "pendiente", StringComparison.OrdinalIgnoreCase))
            {
                dgvDatos.Columns.Add("Column0", "ID");
                dgvDatos.Columns.Add("Column1", "Clasificación");
                dgvDatos.Columns.Add("Column2", "Porción");
                dgvDatos.Columns.Add("Column3", "Descripción");
                dgvDatos.Columns.Add("Column4", "Coeficiente");
            }
            else
            {
                if (opc == "Clasificación Agrológica")
                {
                    dgvDatos.Columns.Add("Column0", "ID");
                    dgvDatos.Columns.Add("Column1", "Descripción");
                    dgvDatos.Columns.Add("Column2", "Coeficiente");
                    dgvDatos.Columns.Add("Column3", "Valor");
                }
                else
                {
                    dgvDatos.Columns.Add("Column0", "ID");
                    dgvDatos.Columns.Add("Column1", "Descripción");
                    dgvDatos.Columns.Add("Column2", "Coeficiente");
                }
            }
        }

        private void loadDataList(string tabla)
        {
            try
            {
                if (tabla == "pendiente")
                {
                    FactorDB fdb = new FactorDB();
                    fdb.Fac5.Lst1 = fdb.listFactorPendiente();
                    int i = 0;
                    foreach (var item in fdb.Fac5.Lst1)
                    {
                        dgvDatos.Rows.Add(1);
                        dgvDatos.Rows[i].Cells[0].Value = item.Id;
                        dgvDatos.Rows[i].Cells[1].Value = item.Clas;
                        dgvDatos.Rows[i].Cells[2].Value = item.Porcion;
                        dgvDatos.Rows[i].Cells[3].Value = item.Desc;
                        dgvDatos.Rows[i].Cells[4].Value = item.Coef;
                        i++;
                    }
                }
                else
                {
                    if (tabla == "clas_agrologica")
                    {
                        FactorDB fdb = new FactorDB();
                        fdb.Faca.Lst1 = fdb.listFactorAgrologico();
                        int i = 0;
                        foreach (var item in fdb.Faca.Lst1)
                        {
                            dgvDatos.Rows.Add(1);
                            dgvDatos.Rows[i].Cells[0].Value = item.Id;
                            dgvDatos.Rows[i].Cells[1].Value = item.Desc;
                            dgvDatos.Rows[i].Cells[2].Value = item.Coef;
                            dgvDatos.Rows[i].Cells[3].Value = item.Valor;
                            i++;
                        }
                    }
                    else
                    {
                        FactorDB fdb = new FactorDB();
                        fdb.Fac.Lst = fdb.listFactor(tabla);
                        int i = 0;
                        foreach (var item in fdb.Fac.Lst)
                        {
                            dgvDatos.Rows.Add(1);
                            dgvDatos.Rows[i].Cells[0].Value = item.Id;
                            dgvDatos.Rows[i].Cells[1].Value = item.Desc;
                            dgvDatos.Rows[i].Cells[2].Value = item.Coef;
                            i++;
                        }
                    }
                }

            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = dgvDatos.CurrentRow.Index; //obtiene el indice de la fila seleccionada
            btnSelect.Enabled = true;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            spnValor.Hide();
            lblValor.Hide();
            gpbDatos.Enabled = true;
            if (opcs == "pendiente")
            {
                txtId.Text = dgvDatos.Rows[fila].Cells[0].Value.ToString();
                txtDesc.Text = dgvDatos.Rows[fila].Cells[3].Value.ToString();
                spnCoef.Value = decimal.Parse(dgvDatos.Rows[fila].Cells[4].Value.ToString());
            }
            else
            {
                if (opcs == "clas_agrologica")
                {
                    spnValor.Show();
                    lblValor.Show();
                    txtId.Text = dgvDatos.Rows[fila].Cells[0].Value.ToString();
                    txtDesc.Text = dgvDatos.Rows[fila].Cells[1].Value.ToString();
                    spnCoef.Value = decimal.Parse(dgvDatos.Rows[fila].Cells[2].Value.ToString());
                    spnValor.Value = decimal.Parse(dgvDatos.Rows[fila].Cells[3].Value.ToString());
                }
                else
                {
                    txtId.Text = dgvDatos.Rows[fila].Cells[0].Value.ToString();
                    txtDesc.Text = dgvDatos.Rows[fila].Cells[1].Value.ToString();
                    spnCoef.Value = decimal.Parse(dgvDatos.Rows[fila].Cells[2].Value.ToString());
                }
            }
        }

        private void modificar()
        {
            try
            {
                FactorDB fdb = new FactorDB();
                string comandoSql="";
                if (opcs == "clas_agrologica")
                {
                    comandoSql = "Update factor_" + opcs + " set coef=" + (double)spnCoef.Value
                        + ", valor=" + (double)spnValor.Value
                        + " WHERE id=" + int.Parse(txtId.Text);
                    
                }
                else
                {
                    comandoSql = "Update factor_" + opcs + " set coef=" + (double)spnCoef.Value
                        + " WHERE id=" + int.Parse(txtId.Text);
                }
                int rta = fdb.updateFactor(comandoSql);
                if (rta == 0)
                    MessageBox.Show("Valor no actualizado", "Error", MessageBoxButtons.OK);
                else
                    MessageBox.Show("Valor actualizado", "Listo", MessageBoxButtons.OK);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            modificar();
            Controller.ClearControl(this);
            gpbList.Enabled = false;
            gpbDatos.Enabled = false;
            btnSelect.Enabled = false;
            spnValor.Hide();
            lblValor.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = dgvDatos.CurrentRow.Index; //obtiene el indice de la fila seleccionada
            btnSelect.Enabled = true;
        }
    }
}
