using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPRER.Connection
{
    class Conexion
    {
        //string servidor = "Data Source=192.168.110.2; User Id=sigprer; Password=sigprer1010";
        string servidor = "Data Source=localhost; User Id=root; Password=";

        string coneccionProvincia = "Database=db_codprov; ";
        string coneccionFactor = "Database=dbp_factorapp; ";
        string coneccionPredio = "Database=dbp_datos_predio; ";
        string coneccionUser = "Database=dbp_usuario; ";

        public MySqlConnection getConexionUser()
        {
            coneccionUser += servidor;
            MySqlConnection obj = new MySqlConnection(coneccionUser);
            return obj;
        }

        public MySqlConnection getConexionProvincia()
        {
            coneccionProvincia += servidor;
            MySqlConnection obj = new MySqlConnection(coneccionProvincia);
            return obj;
        }

        public MySqlConnection getConexionFactor()
        {
            coneccionFactor += servidor;
            MySqlConnection obj = new MySqlConnection(coneccionFactor);
            return obj;
        }
        public MySqlConnection getConexionPredio()
        {
            coneccionPredio += servidor;
            MySqlConnection obj = new MySqlConnection(coneccionPredio);
            return obj;
        }
    }
}
