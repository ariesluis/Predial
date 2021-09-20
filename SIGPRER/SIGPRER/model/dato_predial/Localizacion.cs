using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model.dato_predial
{
    class Localizacion
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nomPred, codSect, nomSect, codVia, nomVia, manzana;

        public string NomPred
        {
            get { return nomPred; }
            set { nomPred = value; }
        }

        public string CodSect
        {
            get { return codSect; }
            set { codSect = value; }
        }

        public string NomSect
        {
            get { return nomSect; }
            set { nomSect = value; }
        }

        public string CodVia
        {
            get { return codVia; }
            set { codVia = value; }
        }

        public string NomVia
        {
            get { return nomVia; }
            set { nomVia = value; }
        }

        public string Manzana
        {
            get { return manzana; }
            set { manzana = value; }
        }
        private double cx, cy;

        public double Cx
        {
            get { return cx; }
            set { cx = value; }
        }

        public double Cy
        {
            get { return cy; }
            set { cy = value; }
        }

        private Ficha ficha;

        internal Ficha Ficha
        {
            get { return ficha; }
            set { ficha = value; }
        }
    }
}
