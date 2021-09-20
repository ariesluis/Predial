using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model
{
    class Uso_Suelo
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string uso;

        public string Uso
        {
            get { return uso; }
            set { uso = value; }
        }
        private double ext, porc;

        public double Ext
        {
            get { return ext; }
            set { ext = value; }
        }

        public double Porc
        {
            get { return porc; }
            set { porc = value; }
        }

        private Ficha ficha;

        internal Ficha Ficha
        {
            get { return ficha; }
            set { ficha = value; }
        }
    }
}
