using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model.dato_predial
{
    class Relieve
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string desc;

        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }
        private double porcent;

        public double Porcent
        {
            get { return porcent; }
            set { porcent = value; }
        }

        private Ficha ficha;

        internal Ficha Ficha
        {
            get { return ficha; }
            set { ficha = value; }
        }
    }
}
