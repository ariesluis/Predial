using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model.factores
{
    class Valor_Impuesto
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private double band_imp, sbu, serv_admi, bomberos;

        public double Band_imp
        {
            get { return band_imp; }
            set { band_imp = value; }
        }

        public double Sbu
        {
            get { return sbu; }
            set { sbu = value; }
        }

        public double Serv_admi
        {
            get { return serv_admi; }
            set { serv_admi = value; }
        }

        public double Bomberos
        {
            get { return bomberos; }
            set { bomberos = value; }
        }
    }
}
