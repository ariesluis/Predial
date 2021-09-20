using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.model
{
    class Responsable
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string obs, tcat, fcat, tjur, fjur, prop, fprop, test, ftest, semp, femp, cgtc, fgtc;

        public string Obs
        {
            get { return obs; }
            set { obs = value; }
        }

        public string Tcat
        {
            get { return tcat; }
            set { tcat = value; }
        }

        public string Fcat
        {
            get { return fcat; }
            set { fcat = value; }
        }

        public string Tjur
        {
            get { return tjur; }
            set { tjur = value; }
        }

        public string Fjur
        {
            get { return fjur; }
            set { fjur = value; }
        }

        public string Prop
        {
            get { return prop; }
            set { prop = value; }
        }

        public string Fprop
        {
            get { return fprop; }
            set { fprop = value; }
        }

        public string Test
        {
            get { return test; }
            set { test = value; }
        }

        public string Ftest
        {
            get { return ftest; }
            set { ftest = value; }
        }

        public string Semp
        {
            get { return semp; }
            set { semp = value; }
        }

        public string Femp
        {
            get { return femp; }
            set { femp = value; }
        }

        public string Cgtc
        {
            get { return cgtc; }
            set { cgtc = value; }
        }

        public string Fgtc
        {
            get { return fgtc; }
            set { fgtc = value; }
        }

        private Ficha ficha;

        internal Ficha Ficha
        {
            get { return ficha; }
            set { ficha = value; }
        }
    }
}
