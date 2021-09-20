using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model
{
    class Servicio_Via
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string tipo_via, mat_via, alumb, estado_via, pobla_cerca, transport, acera, basura;

        public string Mat_via
        {
            get { return mat_via; }
            set { mat_via = value; }
        }

        public string Tipo_via
        {
            get { return tipo_via; }
            set { tipo_via = value; }
        }

        public string Alumb
        {
            get { return alumb; }
            set { alumb = value; }
        }

        public string Estado_via
        {
            get { return estado_via; }
            set { estado_via = value; }
        }

        public string Pobla_cerca
        {
            get { return pobla_cerca; }
            set { pobla_cerca = value; }
        }

        public string Transport
        {
            get { return transport; }
            set { transport = value; }
        }

        public string Acera
        {
            get { return acera; }
            set { acera = value; }
        }

        public string Basura
        {
            get { return basura; }
            set { basura = value; }
        }

        private Ficha ficha;

        internal Ficha Ficha
        {
            get { return ficha; }
            set { ficha = value; }
        }
    }
}
