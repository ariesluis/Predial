using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Avaluos.view;
using Avaluos.view.modify;
using Avaluos.view.saves;

namespace Avaluos
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }

        private void showForm(Form frm)
        {
            frm.MdiParent = this;
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmModFac frm = new FrmModFac();
            frm.Show();
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmModVal frm = new FrmModVal();
            frm.Show();
        }

        private void editarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmValorImp frm = new FrmValorImp();
            frm.MdiParent = this;
            frm.Show();
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
