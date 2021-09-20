using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGPRER.controller.user;
using SIGPRER.Connection;
using SIGPRER.model.user;
using MySql.Data.MySqlClient;
using System.Data;

namespace SIGPRER.controller.user
{
    public class UserDB
    {
        Conexion co = new Conexion();
        private Usuario user = null;

        internal Usuario User
        {
            get { if (user == null) { user = new Usuario(); } return user; }
            set { user = value; }
        }
        private Bitacora actividad = null;

        internal Bitacora Actividad
        {
            get { if (actividad == null) { actividad = new Bitacora(); } return actividad; }
            set { actividad = value; }
        }
        private Persona persona = null;

        internal Persona Persona
        {
            get { if (persona == null) { persona = new Persona(); } return persona; }
            set { persona = value; }
        }

        public Persona traePersona(string ci)
        {
            Persona persona = null;
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexionUser();
            try
            {
                string comandoSql = "Select * from persona where ci='" + ci + "'";
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    persona = new Persona();
                    persona.Ci = dr[0].ToString();
                    persona.Nombres = dr[1].ToString();
                    persona.Direccion = dr[2].ToString();
                    persona.Telefono = dr[3].ToString();
                    persona.Rol = dr[4].ToString();
                    persona.Estado = dr[5].ToString();
                }
                dr.Close();

            }
            catch (MySqlException ex)
            {
                persona = null;
                throw ex;
            }
            catch (Exception ex)
            {
                persona = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return persona;
        }

        public Usuario traeUsuario(string username, string pass)
        {
            Usuario usu = null;
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexionUser();
            try
            {
                string comandoSql = "Select * from usuario where user='" + username + "' and password=MD5('" + pass + "')";
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usu = new Usuario();
                    usu.Id = int.Parse(dr[0].ToString());
                    usu.Nom_usu = dr[1].ToString();
                    usu.Password = dr[2].ToString();
                    usu.Estado = dr[3].ToString();
                    usu.Persona = traePersona(usu.Nom_usu);
                }
                dr.Close();

            }
            catch (MySqlException ex)
            {
                usu = null;
                throw ex;
            }
            catch (Exception ex)
            {
                usu = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return usu;
        }
        public int guardarActualizar(string sql)
        {
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexionUser();
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
    }
}
