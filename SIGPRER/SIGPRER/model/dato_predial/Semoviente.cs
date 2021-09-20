using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model
{
    class Semoviente
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string especie, raza, edad, sangre, num, vigencia = "a";

        public string Especie
        {
            get { return especie; }
            set { especie = value; }
        }

        public string Raza
        {
            get { return raza; }
            set { raza = value; }
        }

        public string Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public string Sangre
        {
            get { return sangre; }
            set { sangre = value; }
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
