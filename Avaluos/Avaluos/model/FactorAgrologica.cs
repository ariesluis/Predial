using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaluos.model
{
    class FactorAgrologica: Factor
    {
        private double valor;

        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        private List<FactorAgrologica> lst;

        internal List<FactorAgrologica> Lst1
        {
            get { return lst; }
            set { lst = value; }
        }
    }
}
