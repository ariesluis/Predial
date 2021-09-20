using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model.dato_predial
{
    class Desc_Construc
    {
        private int id, nrob, nrops;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Nrob
        {
            get { return nrob; }
            set { nrob = value; }
        }

        public int Nrops
        {
            get { return nrops; }
            set { nrops = value; }
        }
        private string cond_fis, val_cul, anio, elect, sanit, espec, nro_banio;

        public string Nro_banio
        {
            get { return nro_banio; }
            set { nro_banio = value; }
        }

        public string Elect
        {
            get { return elect; }
            set { elect = value; }
        }

        public string Sanit
        {
            get { return sanit; }
            set { sanit = value; }
        }

        public string Espec
        {
            get { return espec; }
            set { espec = value; }
        }

        public string Cond_fis
        {
            get { return cond_fis; }
            set { cond_fis = value; }
        }

        public string Val_cul
        {
            get { return val_cul; }
            set { val_cul = value; }
        }

        public string Anio
        {
            get { return anio; }
            set { anio = value; }
        }
        private double area;

        public double Area
        {
            get { return area; }
            set { area = value; }
        }

        private double precioBase;

        public double PrecioBase
        {
            get { return precioBase; }
            set { precioBase = value; }
        }

        private Ficha ficha;

        internal Ficha Ficha
        {
            get { return ficha; }
            set { ficha = value; }
        }
    }
}
