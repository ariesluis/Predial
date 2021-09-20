using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaluos.model.user
{
    class User
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string ci;

        public string Ci
        {
            get { return ci; }
            set { ci = value; }
        }
        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string cargo;

        public string Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
