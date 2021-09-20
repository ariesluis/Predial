using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model.factores
{
    class Valor_Mejora
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string mejora;

        public string Mejora
        {
            get { return mejora; }
            set { mejora = value; }
        }
        private string material;

        public string Material
        {
            get { return material; }
            set { material = value; }
        }
        private double precio;

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        private Factor factor;

        internal Factor Factor
        {
            get { return factor; }
            set { factor = value; }
        }
        private List<Valor_Mejora> lst;

        internal List<Valor_Mejora> Lst
        {
            get { return lst; }
            set { lst = value; }
        }
    }
}
