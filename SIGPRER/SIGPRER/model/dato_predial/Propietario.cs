using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model
{
    class Propietario
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string ci_nat, nom_nat, fnat, ci_con, nom_con, fcon, ruc_jur, nom_jur, am_jur, fjur, dni_rl, nom_rl, direccion, telefono, email;

        public string Ci_nat
        {
            get { return ci_nat; }
            set { ci_nat = value; }
        }

        public string Nom_nat
        {
            get { return nom_nat; }
            set { nom_nat = value; }
        }

        public string Fnat
        {
            get { return fnat; }
            set { fnat = value; }
        }

        public string Ci_con
        {
            get { return ci_con; }
            set { ci_con = value; }
        }

        public string Nom_con
        {
            get { return nom_con; }
            set { nom_con = value; }
        }

        public string Fcon
        {
            get { return fcon; }
            set { fcon = value; }
        }

        public string Ruc_jur
        {
            get { return ruc_jur; }
            set { ruc_jur = value; }
        }

        public string Nom_jur
        {
            get { return nom_jur; }
            set { nom_jur = value; }
        }

        public string Am_jur
        {
            get { return am_jur; }
            set { am_jur = value; }
        }

        public string Fjur
        {
            get { return fjur; }
            set { fjur = value; }
        }

        public string Dni_rl
        {
            get { return dni_rl; }
            set { dni_rl = value; }
        }

        public string Nom_rl
        {
            get { return nom_rl; }
            set { nom_rl = value; }
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

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
