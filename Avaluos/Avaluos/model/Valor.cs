using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaluos.model
{
    class Valor
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

        private double valor;
        public double Valor1
        {
            get { return valor; }
            set { valor = value; }
        }

        private List<Valor> lst;

        public List<Valor> Lst
        {
            get { return lst; }
            set { lst = value; }
        }
    }
}
