using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model.user
{
    public class Persona
    {
        private string ci, nombres, direccion, telefono, rol = "s", estado = "a";

        public string Rol
        {
            get { return rol; }
            set { rol = value; }
        }

        public string Ci
        {
            get { return ci; }
            set { ci = value; }
        }

        public string Nombres
        {
            get { return nombres; }
            set { nombres = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
