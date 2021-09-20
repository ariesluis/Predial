using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaluos.model
{
    class Otros_15_16
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
        private List<Otros_15_16> lst;

        public List<Otros_15_16> Lst
        {
            get { return lst; }
            set { lst = value; }
        }
    }
}
