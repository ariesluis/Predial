using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGPRER.Connection;
using SIGPRER.model.factores;
using MySql.Data.MySqlClient;
using System.Data;

namespace SIGPRER.controller.factores
{
    class FactorDB
    {
        private Conexion co = new Conexion();
        private Factor fac = null;
        private Factor_Valor facv = null;
        private Valor_Impuesto vi = null;
        private Valor_Mejora vm = null;

        internal Valor_Mejora Vm
        {
            get { if (vm == null) { vm = new Valor_Mejora(); } return vm; }
            set { vm = value; }
        }
        internal Valor_Impuesto Vi
        {
            get { if (vi == null) { vi = new Valor_Impuesto(); } return vi; }
            set { vi = value; }
        }

        public Factor Fac
        {
            get { if (fac == null) { fac = new Factor(); } return fac; }
            set { fac = value; }
        }
        public Factor_Valor Facv
        {
            get { if (facv == null) { facv = new Factor_Valor(); } return facv; }
            set { facv = value; }
        }

        public Factor traerFactor(string nombre)
        {
            Factor f = null;
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexionFactor();
            try
            {
                string sql="Select * from factor where fa_desc ='" + nombre + "'";
                cmd = new MySqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    f = new Factor();
                    f.Id = int.Parse(dr[0].ToString());
                    f.Desc = dr[1].ToString();
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                f = null;
                throw ex;
            }
            catch (Exception ex)
            {
                f = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return f;
        }
        public List<Factor> listFactor()
        {
            List<Factor> lst = new List<Factor>();
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexionFactor();
            try
            {
                cmd = new MySqlCommand("Select * from factor", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Factor fv = new Factor();
                    fv.Id = int.Parse(dr[0].ToString());
                    fv.Desc = dr[1].ToString();
                    lst.Add(fv);
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

        public List<Factor_Valor> listSegunFactor(int id)
        {
            List<Factor_Valor> lst = new List<Factor_Valor>();
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexionFactor();
            try
            {
                cmd = new MySqlCommand("Select * from factor_valor where fa_id =" + id, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Factor_Valor fv = new Factor_Valor();
                    fv.Fa_id = int.Parse(dr[0].ToString());
                    fv.Desc = dr[1].ToString();
                    fv.Valor = double.Parse(dr[2].ToString());
                    lst.Add(fv);
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
        public List<Factor_Valor> listFactorRelieve(int id)
        {
            List<Factor_Valor> lst = new List<Factor_Valor>();
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexionFactor();
            try
            {
                cmd = new MySqlCommand("Select * from factor_valor_relieve where fa_id =" + id, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Factor_Valor fv = new Factor_Valor();
                    fv.Fa_id = int.Parse(dr[0].ToString());
                    fv.Desc = dr[1].ToString();
                    fv.Valor = double.Parse(dr[2].ToString());
                    fv.Adicional = dr[3].ToString();
                    lst.Add(fv);
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

        public Factor_Valor valorFactor(int fa_id, string desc)
        {
            Factor_Valor f = null;
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexionFactor();
            try
            {
                string sql = "Select * from factor_valor where fa_id =" + fa_id + " and fv_desc='" + desc + "'";
                cmd = new MySqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    f = new Factor_Valor();
                    f.Fa_id = int.Parse(dr[0].ToString());
                    f.Desc = dr[1].ToString();
                    f.Valor = double.Parse(dr[2].ToString());
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                f = null;
                throw ex;
            }
            catch (Exception ex)
            {
                f = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return f;
        }

        public Factor_Valor valorRelieve(string desc)
        {
            Factor_Valor f = null;
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexionFactor();
            try
            {
                string sql = "Select * from factor_valor_relieve where fv_desc='" + desc + "'";
                cmd = new MySqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    f = new Factor_Valor();
                    f.Fa_id = int.Parse(dr[0].ToString());
                    f.Desc = dr[1].ToString();
                    f.Valor = double.Parse(dr[2].ToString());
                    f.Adicional = dr[3].ToString();
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                f = null;
                throw ex;
            }
            catch (Exception ex)
            {
                f = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return f;
        }

        public Valor_Impuesto valoresBase(int id)
        {
            Valor_Impuesto f = null;
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexionFactor();
            try
            {
                string sql = "Select * from valor_impuestos where fa_id=" + id + "";
                cmd = new MySqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    f = new Valor_Impuesto();
                    f.Id = int.Parse(dr[0].ToString());
                    f.Band_imp = double.Parse(dr[1].ToString());
                    f.Sbu = double.Parse(dr[2].ToString());
                    f.Serv_admi = double.Parse(dr[3].ToString());
                    f.Bomberos = double.Parse(dr[4].ToString());
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                f = null;
                throw ex;
            }
            catch (Exception ex)
            {
                f = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return f;
        }

        public int guardarActualizar(string sql)
        {
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexionFactor();
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

        public List<Valor_Mejora> listValorMejora(int id)
        {
            List<Valor_Mejora> lst = new List<Valor_Mejora>();
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexionFactor();
            try
            {
                cmd = new MySqlCommand("Select * from valor_mejoras where fa_id =" + id, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Valor_Mejora fv = new Valor_Mejora();
                    fv.Id = int.Parse(dr[0].ToString());
                    fv.Mejora = dr[1].ToString();
                    fv.Material = dr[2].ToString();
                    fv.Precio = double.Parse(dr[3].ToString());
                    lst.Add(fv);
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

        public Valor_Mejora traerValorMejora(string obra, string material)
        {
            Valor_Mejora f = null;
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexionFactor();
            try
            {
                string sql = "Select * from valor_mejoras where mejora='" + obra + "' and material='" + material + "'";
                cmd = new MySqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    f = new Valor_Mejora();
                    f.Id = int.Parse(dr[0].ToString());
                    f.Mejora = dr[1].ToString();
                    f.Material = dr[2].ToString();
                    f.Precio = double.Parse(dr[3].ToString());
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                f = null;
                throw ex;
            }
            catch (Exception ex)
            {
                f = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return f;
        }

        public Valor_Mejora traerValorTipologia(string materiales)
        {
            Valor_Mejora f = null;
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexionFactor();
            try
            {
                string sql = "Select * from valor_mejoras where material='" + materiales + "'";
                cmd = new MySqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    f = new Valor_Mejora();
                    f.Id = int.Parse(dr[0].ToString());
                    f.Mejora = dr[1].ToString();
                    f.Material = dr[2].ToString();
                    f.Precio = double.Parse(dr[3].ToString());
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                f = null;
                throw ex;
            }
            catch (Exception ex)
            {
                f = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return f;
        }
    }
}
