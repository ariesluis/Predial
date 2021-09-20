using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaluos.model
{
    class TarifaImpuesto
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private double banda;

        public double Banda
        {
            get { return banda; }
            set { banda = value; }
        }
        private double sbu;

        public double Sbu
        {
            get { return sbu; }
            set { sbu = value; }
        }

        private double serv_admi;

        public double Serv_admi
        {
            get { return serv_admi; }
            set { serv_admi = value; }
        }
        private double bomberos;

        public double Bomberos
        {
            get { return bomberos; }
            set { bomberos = value; }
        }
    }
}
