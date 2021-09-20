using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model
{
    class Lin_Ref
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string desc, info;

        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }

        public string Info
        {
            get { return info; }
            set { info = value; }
        }
        private Ficha ficha;

        internal Ficha Ficha
        {
            get { return ficha; }
            set { ficha = value; }
        }
        private List<Lin_Ref> lst;

        internal List<Lin_Ref> Lst
        {
            get { return lst; }
            set { lst = value; }
        }
    }
}
