using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaluos.model
{
    class Valor_14
    {
        private int id, ac_id, ma_id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Ac_id
        {
            get { return ac_id; }
            set { ac_id = value; }
        }

        public int Ma_id
        {
            get { return ma_id; }
            set { ma_id = value; }
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
    }
}
