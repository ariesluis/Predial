using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model.user
{
    public class Usuario
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nom_usu;

        public string Nom_usu
        {
            get { return nom_usu; }
            set { nom_usu = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string estado = "d";

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private Persona persona;

        internal Persona Persona
        {
            get { return persona; }
            set { persona = value; }
        }
    }
}
