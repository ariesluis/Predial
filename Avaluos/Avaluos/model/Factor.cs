using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaluos.model
{
    class Factor
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string desc;

        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }
        private double coef;

        public double Coef
        {
            get { return coef; }
            set { coef = value; }
        }

        private List<Factor> lst;

        internal List<Factor> Lst
        {
            get { return lst; }
            set { lst = value; }
        }
    }
}
