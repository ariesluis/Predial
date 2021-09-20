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
    class FactorDB
    {
        conexion co = new conexion();

        private Factor fac = null;
        public Factor Fac
        {
            get { if (fac == null) { fac = new Factor(); } return fac; }
            set { fac = value; }
        }

        private FactorAgrologica faca = null;
        public FactorAgrologica Faca
        {
            get { if (faca == null) { faca = new FactorAgrologica(); } return faca; }
            set { faca = value; }
        }

        private FactorPendiente fac5 = null;
        public FactorPendiente Fac5
        {
            get { if (fac5 == null) { fac5 = new FactorPendiente(); } return fac5; }
            set { fac5 = value; }
        }

        private Valor valor = null;
        public Valor Valor
        {
            get { if (valor == null) { valor = new Valor(); } return valor; }
            set { valor = value; }
        }
        
        private ValorMateriales valMaterial = null;
        public ValorMateriales ValMaterial
        {
            get { if (valMaterial == null) { valMaterial = new ValorMateriales(); } return valMaterial; }
            set { valMaterial = value; }
        }
        
        //factor, valores referencia, construcciones y materiales de estructura
        public int insertFactor(string sql)
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

        public int updateFactor(string sql)
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
            return resp;
        }

        //factor list factores
        public List<Factor> listFactor(string tabla)
        {
            FactorDB fdb = null;
            List<Factor> lst = new List<Factor>();
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            try
            {
                string comandoSql = "Select * from factor_" + tabla;
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fdb = new FactorDB();
                    fdb.Fac.Id = int.Parse(dr[0].ToString());
                    fdb.Fac.Desc = dr[1].ToString();
                    fdb.Fac.Coef = double.Parse(dr[2].ToString());
                    lst.Add(fdb.Fac);
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

        //factor list pendiente
        public List<FactorPendiente> listFactorPendiente()
        {
            FactorDB fdb = null;
            List<FactorPendiente> lst = new List<FactorPendiente>();
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            try
            {
                string comandoSql = "Select * from factor_pendiente";
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fdb = new FactorDB();
                    fdb.Fac5.Id = int.Parse(dr[0].ToString());
                    fdb.Fac5.Clas = dr[1].ToString();
                    fdb.Fac5.Porcion = dr[2].ToString();
                    fdb.Fac5.Desc = dr[3].ToString();
                    fdb.Fac5.Coef = double.Parse(dr[4].ToString());
                    lst.Add(fdb.Fac5);
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

        //factor list agrologica
        public List<FactorAgrologica> listFactorAgrologico()
        {
            FactorDB fdb = null;
            List<FactorAgrologica> lst = new List<FactorAgrologica>();
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            try
            {
                string comandoSql = "Select * from factor_clas_agrologica";
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fdb = new FactorDB();
                    fdb.Faca.Id = int.Parse(dr[0].ToString());
                    fdb.Faca.Desc= dr[1].ToString();
                    fdb.Faca.Coef = double.Parse(dr[2].ToString());
                    fdb.Faca.Valor = double.Parse(dr[3].ToString());
                    lst.Add(fdb.Faca);
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

        //lista valor mano de obra
        public List<Valor> listValorMO()
        {
            FactorDB fdb = null;
            List<Valor> lst = new List<Valor>();
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            try
            {
                string comandoSql = "Select * from valor_mo";
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fdb = new FactorDB();
                    fdb.Valor.Id = int.Parse(dr[0].ToString());
                    fdb.Valor.Desc = dr[1].ToString();
                    fdb.Valor.Valor1 = double.Parse(dr[2].ToString());
                    lst.Add(fdb.Valor);
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

        //lista valor materiales generales
        public List<ValorMateriales> listValorMaterial()
        {
            FactorDB fdb = null;
            List<ValorMateriales> lst = new List<ValorMateriales>();
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            try
            {
                string comandoSql = "Select * from valor_material";
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fdb = new FactorDB();
                    fdb.ValMaterial.Id = int.Parse(dr[0].ToString());
                    fdb.ValMaterial.Desc = dr[1].ToString();
                    fdb.ValMaterial.Unid = dr[2].ToString();
                    fdb.ValMaterial.Valor1 = double.Parse(dr[3].ToString());
                    lst.Add(fdb.ValMaterial);
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
