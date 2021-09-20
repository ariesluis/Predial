using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIGPRER.controller.user;

namespace SIGPRER.view.factor
{
    public partial class FrmAutorizacion : Form
    {
        public FrmAutorizacion()
        {
            InitializeComponent();
        }

        UserDB us = new UserDB();

        private bool autentificacion()
        {
            string usuario = txtUsuario.Text;
            string pass = txtPass.Text;
            us.User = us.traeUsuario(usuario, pass);
            if (us.User != null)
            {
                if (us.User.Nom_usu != null && us.User.Password != null)
                {
                    if (us.User.Persona.Estado == "a" && us.User.Persona.Rol == "a")
                        return true;
                    else
                        return false;
                }
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

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (autentificacion())
            {
                MessageBox.Show("Inicio de sesión aceptado", "En línea", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmModifFact frm = new FrmModifFact(us);
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No tiene acceso a este módulo, consulte con el administrador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
