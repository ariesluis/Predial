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

namespace SIGPRER.view.user
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
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
                    if (us.User.Persona.Estado == "a")
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

        private void guardarXml()
        {
            try
            {
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(us.User.GetType());
                System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\sigprer\\user.xml");
                writer.Serialize(file, us.User);
                file.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (autentificacion())
            {
                MessageBox.Show("Inicio de sesión aceptado", "En línea", MessageBoxButtons.OK, MessageBoxIcon.Information);
                us.guardarActualizar("Update usuario set estado='c' where id=" + us.User.Id);
                us.User.Estado = "c";
                guardarXml();
                Util.Util.parametroXml("");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Contraeña o usuario incorrectos", "Advertencia", MessageBoxButtons.OK);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
