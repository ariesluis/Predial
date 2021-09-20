using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avaluos.model.user;
using MySql.Data.MySqlClient;
using System.Data;

namespace Avaluos.controller.user
{
    class UserDB
    {
        conexionUser co = new conexionUser();
        private User user = null;

        internal User User
        {
            get { if (user == null) { user = new User(); } return user; }
            set { user = value; }
        }
        private Activity actividad = null;

        internal Activity Actividad
        {
            get { if (actividad == null) { actividad = new Activity(); } return actividad; }
            set { actividad = value; }
        }
        private Account cuenta = null;

        internal Account Cuenta
        {
            get { if (cuenta == null) { cuenta = new Account(); } return cuenta; }
            set { cuenta = value; }
        }

        public User traeUsuario(int id)
        {
            UserDB us = null;
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            try
            {
                string comandoSql = "Select * from users where id='" + id + "'";
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    us = new UserDB();
                    us.User.Id = int.Parse(dr[0].ToString());
                    us.User.Ci= dr[1].ToString();
                    us.User.Apellido = dr[2].ToString();
                    us.User.Nombre = dr[3].ToString();
                    us.User.Cargo = dr[4].ToString();
                    us.User.Estado = dr[5].ToString();
                }
                dr.Close();

            }
            catch (MySqlException ex)
            {
                us.User = null;
                throw ex;
            }
            catch (Exception ex)
            {
                us.User = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return us.User;
        }

        public Account traeCuenta(string username, string pass)
        {
            UserDB cu = null;
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            try
            {
                string comandoSql = "Select * from accounts where username='" + username + "' and password=MD5('" + pass + "')";
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cu = new UserDB();
                    cu.Cuenta.Id = int.Parse(dr[0].ToString());
                    cu.Cuenta.Username = dr[1].ToString();
                    cu.Cuenta.Password = dr[2].ToString();
                    cu.Cuenta.User = traeUsuario(int.Parse(dr[3].ToString()));
                }
                dr.Close();

            }
            catch (MySqlException ex)
            {
                cu.Cuenta = null;
                throw ex;
            }
            catch (Exception ex)
            {
                cu.Cuenta = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            if (cu != null)
                return cu.Cuenta;
            else
                return null;
        }
    }
}
