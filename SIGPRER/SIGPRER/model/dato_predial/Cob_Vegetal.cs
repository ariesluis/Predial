using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model.dato_predial
{
    class Cob_Vegetal
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string desc, edad, est, indicador="i";

        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }

        public string Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public string Est
        {
            get { return est; }
            set { est = value; }
        }

        public string Indicador
        {
            get { return indicador; }
            set { indicador = value; }
        }
        private double porc;

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
