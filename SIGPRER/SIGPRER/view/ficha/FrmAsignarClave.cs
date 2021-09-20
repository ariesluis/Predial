using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIGPRER.Util;
using SIGPRER.controller.predios;
using SIGPRER.controller;

namespace SIGPRER.view.ficha
{
    public partial class FrmAsignarClave : Form
    {
        public FrmAsignarClave()
        {
            InitializeComponent();
        }

        PredioDB pdb = new PredioDB();
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtValor.Text != "")
            {
                pdb.Fi = pdb.obtenerFicha("Select * from fichas where fi_cod_catastral='" + txtValor.Text + "'");
                if (pdb.Fi.Cod_catastro == null)
                {
                    Util.Util.escribirXml(txtValor.Text, "clave", "catastro", "claveCatastro.xml");
                    MessageBox.Show("Clave lista para asignarse");
                    Application.Exit();
                }
                else
                    MessageBox.Show("Clave catastral ya registrada, ingrese otra", "Advertencia");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
