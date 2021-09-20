using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model.dato_predial
{
    class Avaluo
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private double avt, avc, avtotal, imp, imb, sea, imt;

        public double Avt
        {
            get { return avt; }
            set { avt = value; }
        }

        public double Avtotal
        {
            get { return avtotal; }
            set { avtotal = value; }
        }

        public double Avc
        {
            get { return avc; }
            set { avc = value; }
        }

        public double Imp
        {
            get { return imp; }
            set { imp = value; }
        }

        public double Imb
        {
            get { return imb; }
            set { imb = value; }
        }

        public double Sea
        {
            get { return sea; }
            set { sea = value; }
        }

        public double Imt
        {
            get { return imt; }
            set { imt = value; }
        }
    }
}
