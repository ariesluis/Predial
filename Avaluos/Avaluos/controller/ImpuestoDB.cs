using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Avaluos.model;
using System.Data;

namespace Avaluos.controller
{
    class ImpuestoDB
    {
        conexion co = new conexion();

        private TarifaImpuesto ti = null;
        public TarifaImpuesto Tarifa
        {
            get { if (ti == null) { ti = new TarifaImpuesto(); } return ti; }
            set { ti = value; }
        }

        public int saveOrUpdateTarifa(string sql)
        {
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            int resp;
            try
            {
                cmd = new MySqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                resp = cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                resp = 0;
                throw ex;
            }
            catch (Exception ex)
            {
                resp = 0;
                throw ex;
            }
            cn.Close();
            cmd = null;
            cn = null;
            return resp;
        }
        public TarifaImpuesto consultTarifa()
        {
            TarifaImpuesto t = new TarifaImpuesto();
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            try
            {
                string comandoSql = "Select * from factor_calculo_impuesto";
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    t.Id = int.Parse(dr[0].ToString());
                    t.Banda = double.Parse(dr[1].ToString());
                    t.Sbu = double.Parse(dr[2].ToString());
                    t.Serv_admi = double.Parse(dr[3].ToString());
                    t.Bomberos = double.Parse(dr[4].ToString());
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cn.Close();
            cmd = null;
            return t;
        }
    }
}
