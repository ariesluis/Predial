using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaluos.model
{
    class ValorMateriales:Valor
    {
        private string unid;

        public string Unid
        {
            get { return unid; }
            set { unid = value; }
        }

        private List<ValorMateriales> lst;

        public List<ValorMateriales> Lst1
        {
            get { return lst; }
            set { lst = value; }
        }
    }
}
