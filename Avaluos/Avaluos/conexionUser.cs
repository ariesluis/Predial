using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaluos
{
    class conexionUser
    {
        string coneccion = "Database=db_user_log; Data Source=192.168.1.9; User Id=root; Password=root";

        public MySqlConnection getConexion()
        {
            MySqlConnection obj = new MySqlConnection(coneccion);
            return obj;
        }
    }
}
