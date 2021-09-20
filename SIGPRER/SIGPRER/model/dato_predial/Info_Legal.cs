using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model
{
    class Info_Legal
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string form_tenen, sup_desc, sup_unidad, dprf, dpfc, dp_auto, dp_fi, dp_lugar, dom, tip_tenen, desc_tenen, prop_ant;

        public string Form_tenen
        {
            get { return form_tenen; }
            set { form_tenen = value; }
        }

        public string Sup_desc
        {
            get { return sup_desc; }
            set { sup_desc = value; }
        }

        public string Sup_unidad
        {
            get { return sup_unidad; }
            set { sup_unidad = value; }
        }

        public string Dprf
        {
            get { return dprf; }
            set { dprf = value; }
        }

        public string Dpfc
        {
            get { return dpfc; }
            set { dpfc = value; }
        }

        public string Dp_auto
        {
            get { return dp_auto; }
            set { dp_auto = value; }
        }

        public string Dp_fi
        {
            get { return dp_fi; }
            set { dp_fi = value; }
        }

        public string Dp_lugar
        {
            get { return dp_lugar; }
            set { dp_lugar = value; }
        }

        public string Prop_ant
        {
            get { return prop_ant; }
            set { prop_ant = value; }
        }
        private double sup_area;

        public double Sup_area
        {
            get { return sup_area; }
            set { sup_area = value; }
        }

        public string Dom
        {
            get { return dom; }
            set { dom = value; }
        }

        public string Desc_tenen
        {
            get { return desc_tenen; }
            set { desc_tenen = value; }
        }

        public string Tip_tenen
        {
            get { return tip_tenen; }
            set { tip_tenen = value; }
        }

        private Ficha ficha;

        internal Ficha Ficha
        {
            get { return ficha; }
            set { ficha = value; }
        }
    }
}
