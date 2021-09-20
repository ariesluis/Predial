using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIGPRER.controller.predios;
using SIGPRER.controller;
using System.Xml;

namespace SIGPRER.view.ficha
{
    public partial class FrmBusqueda : Form
    {
        public FrmBusqueda()
        {
            InitializeComponent();
        }

        PredioDB pdb = new PredioDB();

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtValor.Text != "")
            {
                if (cmbParam.SelectedIndex != 0)
                {
                    pdb.Pro = pdb.obtenerProp("select * from propietarios where "
                                            + "pr_nom_nat='" + txtValor.Text
                                            + "' or pr_ruc_ju='" + txtValor.Text
                                            + "' or pr_dni_rl='" + txtValor.Text
                                            + "'");
                    pdb.Fi.Lst = pdb.obtenerFichas("select * from fichas where pr_id=" + pdb.Pro.Id);
                }
                else
                    pdb.Fi.Lst = pdb.obtenerFichas("Select * from fichas where fi_cod_catastral='" + txtValor.Text + "'");
                XmlTextWriter writer = new XmlTextWriter("c:\\sigprer\\search.xml", System.Text.Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                writer.WriteStartElement("busqueda");
                for (int i = 0; i < pdb.Fi.Lst.Count; i++)
                {
                    createNode(pdb.Fi.Lst[i].Cod_catastro, writer);
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
                MessageBox.Show("Parámetro registrado");
                Application.Exit();
            }
        }
        private void createNode(string clave, XmlTextWriter writer)
        {
            writer.WriteStartElement("catastro");
            writer.WriteString(clave);
            writer.WriteEndElement();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
