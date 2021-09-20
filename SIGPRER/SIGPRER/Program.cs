using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIGPRER.view.ficha;
using SIGPRER.view.factor;
using SIGPRER.view.user;
using System.Xml;
using SIGPRER.Util;
using SIGPRER.model.user;

namespace SIGPRER
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>

        [STAThread]
        static void Main()
        {
            XmlTextReader reader = new XmlTextReader("C:\\sigprer\\param.xml");
            string view = "";
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Text: //Display the text in each element.
                        view = reader.Value.Trim();
                        break;
                }
            }
            reader.Close();
            Usuario u = Util.Util.leerUsuarioXml();
            if (u.Id != 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                if (view != "")
                {
                    if (view == "o01")//insercion de datos del predio
                        Application.Run(new FrmInsert());
                    else
                    {
                        if (view == "o11")//avaluo del predio
                            Application.Run(new FrmAvaluo());
                        else
                        {
                            if (view == "o100")//modificacion de factores
                                Application.Run(new FrmAutorizacion());
                            else
                            {
                                if (view == "o00")//login
                                    Application.Run(new FrmLogin());
                                else
                                {
                                    if (view == "o10")//consulta datos predio
                                        Application.Run(new FrmConsultar());
                                    else
                                    {
                                        if (view == "o1000")
                                            Application.Run(new FrmBusqueda());
                                        else
                                        {
                                            if (view == "o1001")
                                                Application.Run(new FrmAsignarClave());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FrmLogin());
                }
            }
            else
            {
                if (view != "o00")
                {
                    MessageBox.Show("Iniciar sesion primero", "Requerido");
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FrmLogin());
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FrmLogin());
                }
            }
        }
    }
}
