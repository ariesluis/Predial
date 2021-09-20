using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avaluos.model;
using MySql.Data.MySqlClient;
using System.Data;

namespace Avaluos.controller
{
    class MaterialPredDB
    {
        conexion co = new conexion();
        Factor fac = null;

        public Factor Fac
        {
            get { if (fac == null) { fac = new Factor(); } return fac; }
            set { fac = value; }
        }
        Otros_15_16 mc = null;

        public Otros_15_16 Mc
        {
            get { if (mc == null) { mc = new Otros_15_16(); } return mc; }
            set { mc = value; }
        }

        public List<Factor> listFactorAcab()
        {
            MaterialPredDB mpdb = null;
            List<Factor> lst = new List<Factor>();
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            try
            {
                string comandoSql = "Select * from factor_acabado";
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    mpdb = new MaterialPredDB();
                    mpdb.Fac.Id = int.Parse(dr[0].ToString());
                    mpdb.Fac.Desc = dr[1].ToString();
                    mpdb.Fac.Coef = double.Parse(dr[2].ToString());
                    lst.Add(mpdb.Fac);
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

        public List<Otros_15_16> listMatCons(string tabla)
        {
            MaterialPredDB mcdb = null;
            List<Otros_15_16> lst = new List<Otros_15_16>();
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            try
            {
                string comandoSql = "Select * from " + tabla;
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    mcdb = new MaterialPredDB();
                    mcdb.Mc.Id = int.Parse(dr[0].ToString());
                    mcdb.Mc.Desc = dr[1].ToString();
                    lst.Add(mcdb.Mc);
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
