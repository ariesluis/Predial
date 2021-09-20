using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model
{
    class Carac_Fisica
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string forma, riesgo, erosion, clas_suelo, cob_natural, ecosis_rele, valor_cult;
        private double area, costo_base;

        public double Area
        {
            get { return area; }
            set { area = value; }
        }

        public double Costo_base
        {
            get { return costo_base; }
            set { costo_base = value; }
        }

        public string Forma
        {
            get { return forma; }
            set { forma = value; }
        }

        public string Riesgo
        {
            get { return riesgo; }
            set { riesgo = value; }
        }

        public string Erosion
        {
            get { return erosion; }
            set { erosion = value; }
        }

        public string Clas_suelo
        {
            get { return clas_suelo; }
            set { clas_suelo = value; }
        }

        public string Cob_natural
        {
            get { return cob_natural; }
            set { cob_natural = value; }
        }

        public string Ecosis_rele
        {
            get { return ecosis_rele; }
            set { ecosis_rele = value; }
        }

        public string Valor_cult
        {
            get { return valor_cult; }
            set { valor_cult = value; }
        }

        private Ficha ficha;

        internal Ficha Ficha
        {
            get { return ficha; }
            set { ficha = value; }
        }
    }
}
