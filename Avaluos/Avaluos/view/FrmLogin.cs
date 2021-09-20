using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Avaluos.controller.user;

namespace Avaluos.view
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (autentificacion())
            {
                FrmPrincipal frm = new FrmPrincipal();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Contraeña o usuario incorrectos", "Advertencia", MessageBoxButtons.OK);
            }

        }

        private bool autentificacion()
        {
            string usuario = txtUsuario.Text;
            string pass = txtPass.Text;
            UserDB us = new UserDB();
            us.Cuenta = us.traeCuenta(usuario, pass);
            if (us.Cuenta != null)
            {
                if (us.Cuenta.Username != null && us.Cuenta.Password != null)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
