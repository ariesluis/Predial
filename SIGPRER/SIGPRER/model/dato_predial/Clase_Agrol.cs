using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model
{
    class Clase_Agrol
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string clase;

        public string Clase
        {
            get { return clase; }
            set { clase = value; }
        }
        private double area, porcion;

        public double Area
        {
            get { return area; }
            set { area = value; }
        }

        public double Porcion
        {
            get { return porcion; }
            set { porcion = value; }
        }

        private Ficha ficha;

        internal Ficha Ficha
        {
            get { return ficha; }
            set { ficha = value; }
        }

        private List<Clase_Agrol> lst;

        internal List<Clase_Agrol> Lst
        {
            get { return lst; }
            set { lst = value; }
        }
    }
}
