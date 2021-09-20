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

namespace Avaluos.view.saves
{
    public partial class FrmValorImp : Form
    {
        public FrmValorImp()
        {
            InitializeComponent();
            cargarDatos();
        }

        private ImpuestoDB impDB = new ImpuestoDB();

        private void cargarDatos()
        {
            try
            {
                impDB.Tarifa = impDB.consultTarifa();
                nudBanda.Value = (decimal) impDB.Tarifa.Banda;
                nudSbu.Value = (decimal)impDB.Tarifa.Sbu;
                nudServAdmi.Value = (decimal)impDB.Tarifa.Serv_admi;
                nudBombero.Value = (decimal)impDB.Tarifa.Bomberos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void actualizar()
        {
            try
            {
                impDB.Tarifa.Banda = (double)nudBanda.Value;
                impDB.Tarifa.Sbu = (double)nudSbu.Value;
                impDB.Tarifa.Serv_admi = (double)nudServAdmi.Value;
                impDB.Tarifa.Bomberos = (double)nudBombero.Value;
                string comandoSql = "Update factor_calculo_impuesto set ban_impo=" + impDB.Tarifa.Banda
                        + ", sbu=" + impDB.Tarifa.Sbu
                        + ", serv_admin=" + impDB.Tarifa.Serv_admi
                        + ", bombero=" + impDB.Tarifa.Bomberos
                        + " WHERE id=" + impDB.Tarifa.Id;
                impDB.saveOrUpdateTarifa(comandoSql);
                MessageBox.Show("Valores Actualizados", "Listo", MessageBoxButtons.OK);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al actualizar", "Error", MessageBoxButtons.OK);
                throw e;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            actualizar();
            cargarDatos();
        }
    }
}
