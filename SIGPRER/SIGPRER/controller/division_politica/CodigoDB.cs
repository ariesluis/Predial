using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGPRER.Connection;
using SIGPRER.model.codigo_provincial;
using MySql.Data.MySqlClient;
using System.Data;

namespace SIGPRER.controller
{
    class CodigoDB
    {
        private Conexion co = new Conexion();
        private Codigo cod = null;
        public Codigo Cod
        {
            get { if (cod == null) { cod = new Codigo(); } return cod; }
            set { cod = value; }
        }

        public List<Codigo> readDBlist(string sql, int div_poli)
        {
            List<Codigo> lst = new List<Codigo>();
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexionProvincia();
            try
            {
                cmd = new MySqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                if (div_poli == 0)
                {
                    while (dr.Read())
                    {
                        Codigo code = new Codigo();
                        code.Cod = dr[0].ToString();
                        code.Cod_comp = "";
                        code.Nombre = dr[1].ToString();
                        lst.Add(code);
                    }
                }
                else
                {
                    while (dr.Read())
                    {
                        Codigo code = new Codigo();
                        code.Cod = dr[0].ToString();
                        code.Cod_comp = dr[1].ToString();
                        code.Nombre = dr[2].ToString();
                        lst.Add(code);
                    }
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                lst = null;
                throw ex;
            }
            catch (Exception ex)
            {
                lst = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return lst;
        }
    }
}
