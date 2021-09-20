using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaluos.model
{
    class FactorPendiente:Factor
    {
        private string clas;

        public string Clas
        {
            get { return clas; }
            set { clas = value; }
        }
        private string porcion;

        public string Porcion
        {
            get { return porcion; }
            set { porcion = value; }
        }

        private List<FactorPendiente> lst;

        internal List<FactorPendiente> Lst1
        {
            get { return lst; }
            set { lst = value; }
        }
    }
}
