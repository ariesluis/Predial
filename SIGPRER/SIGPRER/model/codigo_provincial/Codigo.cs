using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model.codigo_provincial
{
    class Codigo
    {
        private string cod;

        public string Cod
        {
            get { return cod; }
            set { cod = value; }
        }
        private string cod_comp;

        public string Cod_comp
        {
            get { return cod_comp; }
            set { cod_comp = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private List<Codigo> lst;

        internal List<Codigo> Lst
        {
            get { return lst; }
            set { lst = value; }
        }

        private Codigo code;

        internal Codigo Code
        {
            get { return code; }
            set { code = value; }
        }
    }
}
