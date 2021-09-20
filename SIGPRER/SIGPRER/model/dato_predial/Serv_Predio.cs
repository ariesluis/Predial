using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model
{
    class Serv_Predio
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string agua, alcant, elect, riego, num_med_agua, num_med_elect, num_tel, met_riego;

        public string Agua
        {
            get { return agua; }
            set { agua = value; }
        }

        public string Alcant
        {
            get { return alcant; }
            set { alcant = value; }
        }

        public string Elect
        {
            get { return elect; }
            set { elect = value; }
        }

        public string Riego
        {
            get { return riego; }
            set { riego = value; }
        }

        public string Num_med_agua
        {
            get { return num_med_agua; }
            set { num_med_agua = value; }
        }

        public string Num_med_elect
        {
            get { return num_med_elect; }
            set { num_med_elect = value; }
        }

        public string Num_tel
        {
            get { return num_tel; }
            set { num_tel = value; }
        }

        public string Met_riego
        {
            get { return met_riego; }
            set { met_riego = value; }
        }
        private int num_agua = 0, num_elect = 0, num_lin_tel = 0;

        public int Num_agua
        {
            get { return num_agua; }
            set { num_agua = value; }
        }

        public int Num_elect
        {
            get { return num_elect; }
            set { num_elect = value; }
        }

        public int Num_lin_tel
        {
            get { return num_lin_tel; }
            set { num_lin_tel = value; }
        }

        private Ficha ficha;

        internal Ficha Ficha
        {
            get { return ficha; }
            set { ficha = value; }
        }
    }
}
