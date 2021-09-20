using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model
{
    class Mejoras_Predio
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string desc, tip_mat, u_med, estado, vigencia = "a";

        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }

        public string Tip_mat
        {
            get { return tip_mat; }
            set { tip_mat = value; }
        }

        private double area;
        public double Area
        {
            get { return area; }
            set { area = value; }
        }

        public string U_med
        {
            get { return u_med; }
            set { u_med = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
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
