using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaluos.model.user
{
    class Activity
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string actividad;

        public string Actividad
        {
            get { return actividad; }
            set { actividad = value; }
        }
        private string fecha;

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private User user;

        internal User User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
