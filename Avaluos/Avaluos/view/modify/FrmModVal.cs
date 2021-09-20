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
    public partial class FrmModVal : Form
    {
        public FrmModVal()
        {
            InitializeComponent();
        }

        private int fila;
        private int opc;

        private void cboOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int opcn = cboOpcion.SelectedIndex;
            formatTable(opcn);
            loadDataList(opcn);
            gpbList.Enabled = true;
        }

        private void formatTable(int i)
        {
            dgvDatos.Columns.Clear();
            if (i==0)
            {
                dgvDatos.Columns.Add("Column0", "ID");
                dgvDatos.Columns.Add("Column1", "Descripción");
                dgvDatos.Columns.Add("Column2", "Unidad");
                dgvDatos.Columns.Add("Column3", "Valor");
            }
            else
            {
                dgvDatos.Columns.Add("Column0", "ID");
                dgvDatos.Columns.Add("Column3", "Descripción");
                dgvDatos.Columns.Add("Column3", "Valor");
            }
        }

        private void loadDataList(int tabla)
        {
            opc = tabla;
            try
            {
                if (tabla == 0)
                {
                    FactorDB fdb = new FactorDB();
                    fdb.ValMaterial.Lst1 = fdb.listValorMaterial();
                    int i = 0;
                    foreach (var item in fdb.ValMaterial.Lst1)
                    {
                        dgvDatos.Rows.Add(1);
                        dgvDatos.Rows[i].Cells[0].Value = item.Id;
                        dgvDatos.Rows[i].Cells[1].Value = item.Desc;
                        dgvDatos.Rows[i].Cells[2].Value = item.Unid;
                        dgvDatos.Rows[i].Cells[3].Value = item.Valor1;
                        i++;
                    }
                }
                else
                {
                    FactorDB fdb = new FactorDB();
                    fdb.Valor.Lst = fdb.listValorMO();
                    int i = 0;
                    foreach (var item in fdb.Valor.Lst)
                    {
                        dgvDatos.Rows.Add(1);
                        dgvDatos.Rows[i].Cells[0].Value = item.Id;
                        dgvDatos.Rows[i].Cells[1].Value = item.Desc;
                        dgvDatos.Rows[i].Cells[2].Value = item.Valor1;
                        i++;
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = dgvDatos.CurrentRow.Index; //obtiene el indice de la fila seleccionada
            btnSelect.Enabled = true;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            gpbDatos.Enabled = true;
            if (opc == 0)
            {
                txtId.Text = dgvDatos.Rows[fila].Cells[0].Value.ToString();
                txtDesc.Text = dgvDatos.Rows[fila].Cells[1].Value.ToString();
                spnCoef.Value = decimal.Parse(dgvDatos.Rows[fila].Cells[3].Value.ToString());
            }
            else
            {
                txtId.Text = dgvDatos.Rows[fila].Cells[0].Value.ToString();
                txtDesc.Text = dgvDatos.Rows[fila].Cells[1].Value.ToString();
                spnCoef.Value = decimal.Parse(dgvDatos.Rows[fila].Cells[2].Value.ToString());
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            modificar();
            Controller.ClearControl(this);
            gpbList.Enabled = false;
            gpbDatos.Enabled = false;
            btnSelect.Enabled = false;
        }

        private void modificar()
        {
            try
            {
                FactorDB fdb = new FactorDB();
                string comandoSql = "";
                if (opc == 0)
                {
                    comandoSql = "Update valor_material set vm_precio=" + (double)spnCoef.Value
                        + " WHERE vm_id=" + int.Parse(txtId.Text);
                }
                else
                {
                    comandoSql = "Update valor_mo set vmo_jornal=" + (double)spnCoef.Value
                        + " WHERE vmo_id=" + int.Parse(txtId.Text);
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
    }
}
