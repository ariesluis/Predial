using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIGPRER.model.user;
using System.Xml;

namespace SIGPRER.Util
{
    public class Util
    {
        public class User
        {
            public int id;
            public string estado;
        }
        public bool verificarCedula(string ced)
        {
            int isNumeric; var total = 0; const int tamanoLongitudCedula = 10; int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            const int numeroProvincias = 24; const int tercerDigito = 6;
            if (int.TryParse(ced, out isNumeric) && ced.Length == tamanoLongitudCedula)
            {
                var provincia = Convert.ToInt32(string.Concat(ced[0], ced[1], string.Empty));
                var digitoTres = Convert.ToInt32(ced[2] + string.Empty);
                if ((provincia > 0 && provincia <= numeroProvincias) && digitoTres < tercerDigito)
                {
                    var digitoVerificadorRecibido = Convert.ToInt32(ced[9] + string.Empty);
                    for (var k = 0; k < coeficientes.Length; k++)
                    {
                        var valor = Convert.ToInt32(coeficientes[k] + string.Empty) * Convert.ToInt32(ced[k] + string.Empty);
                        total = valor >= 10 ? total + (valor - 9) : total + valor;
                    }
                    var digitoVerificadorObtenido = total >= 10 ? (total % 10) != 0 ? 10 - (total % 10) : (total % 10) : total;
                    return digitoVerificadorObtenido == digitoVerificadorRecibido;
                }
                return false;
            }
            return false;
        }

        public static bool nullBlank(Control control)
        {
            bool b = true;

            var textbox = control as TextBox;
            if (textbox != null)
            {
                if (textbox.Text.Trim() == "")
                    b = false;
            }
            else
                b = false;
            foreach (Control childControl in control.Controls)
            {
                nullBlank(childControl);
            }
            return b;
        }

        public static void parametroXml(string parametro)
        {
            XmlTextWriter writer = new XmlTextWriter("c:\\sigprer\\param.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("r10101");
            writer.WriteStartElement("v0011");
            writer.WriteString(parametro);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        public static Usuario leerUsuarioXml()
        {
            try
            {
                Usuario introToVCS = new Usuario();
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(introToVCS.GetType());
                // Read the XML file.
                System.IO.StreamReader file = new System.IO.StreamReader("C:\\sigprer\\user.xml");
                // Deserialize the content of the file into a Book object.
                introToVCS = (Usuario)reader.Deserialize(file);
                return introToVCS;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string leerParamXml(string nombreXml)
        {
            XmlTextReader reader = new XmlTextReader("C:\\sigprer\\" + nombreXml);
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
            return view;
        }
        public static void escribirXml(string valor, string raiz, string nodo, string nombreXml)
        {
            XmlTextWriter writer = new XmlTextWriter("c:\\sigprer\\" + nombreXml, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement(raiz);
            writer.WriteStartElement(nodo);
            writer.WriteString(valor);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }
    }
}
