using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Avaluos
{
    class conexion
    {
        string coneccion = "Database=db_factoraplicacion; Data Source=192.168.1.9; User Id=root; Password=root";
        
        public MySqlConnection getConexion()
        {
            MySqlConnection obj = new MySqlConnection(coneccion);
            return obj;
        }
    }
}
