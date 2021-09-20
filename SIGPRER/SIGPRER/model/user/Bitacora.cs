using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model.user
{
    public class Bitacora
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int id_usu;

        public int Id_usu
        {
            get { return id_usu; }
            set { id_usu = value; }
        }
        private string accion;

        public string Accion
        {
            get { return accion; }
            set { accion = value; }
        }
        private string fecha;

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
    }
}
