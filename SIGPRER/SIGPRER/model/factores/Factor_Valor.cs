using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model.factores
{
    class Factor_Valor
    {
        private int fa_id;

        public int Fa_id
        {
            get { return fa_id; }
            set { fa_id = value; }
        }

        private string desc;

        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }
        private double valor;

        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        private List<Factor_Valor> lst;

        internal List<Factor_Valor> Lst
        {
            get { return lst; }
            set { lst = value; }
        }

        private string adicional;

        public string Adicional
        {
            get { return adicional; }
            set { adicional = value; }
        }
    }
}
