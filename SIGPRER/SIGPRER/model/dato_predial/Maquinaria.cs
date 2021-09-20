using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model
{
    class Maquinaria
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string den, marca, anio, estado, num, vigencia = "a";

        public string Den
        {
            get { return den; }
            set { den = value; }
        }

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public string Anio
        {
            get { return anio; }
            set { anio = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string Num
        {
            get { return num; }
            set { num = value; }
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
    }
}
