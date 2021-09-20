using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model
{
    class Mat_Edificio
    {
        private int id, nro_bloque;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Nro_bloque
        {
            get { return nro_bloque; }
            set { nro_bloque = value; }
        }
        private string tipo, material, vigencia;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        public string Vigencia
        {
            get { return vigencia; }
            set { vigencia = value; }
        }

        private Ficha ficha;

        internal Ficha Ficha
        {
            get { return ficha; }
            set { ficha = value; }
        }

        private List<Mat_Edificio> lst = new List<Mat_Edificio>();

        internal List<Mat_Edificio> Lst
        {
            get { return lst; }
            set { lst = value; }
        }

    }
}
