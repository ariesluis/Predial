using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGPRER.model.dato_predial;
using SIGPRER.model;
using SIGPRER.Connection;
using MySql.Data.MySqlClient;
using System.Data;

namespace SIGPRER.controller.predios
{
    class PredioDB
    {
        private Conexion co = new Conexion();

        private Propietario pro = null;
        public Propietario Pro
        {
            get { if (pro == null) { pro = new Propietario(); } return pro; }
            set { pro = value; }
        }
        private Carac_Fisica cf = null;
        internal Carac_Fisica Cf
        {
            get { if (cf == null) { cf = new Carac_Fisica(); } return cf; }
            set { cf = value; }
        }
        private Clase_Agrol ca = null;
        internal Clase_Agrol Ca
        {
            get { if (ca == null) { ca = new Clase_Agrol(); } return ca; }
            set { ca = value; }
        }
        private Cob_Vegetal cv = null;
        internal Cob_Vegetal Cv
        {
            get { if (cv == null) { cv = new Cob_Vegetal(); } return cv; }
            set { cv = value; }
        }
        private Desc_Construc dc = null;
        internal Desc_Construc Dc
        {
            get { if (dc == null) { dc = new Desc_Construc(); } return dc; }
            set { dc = value; }
        }
        private Ficha fi = null;
        internal Ficha Fi
        {
            get { if (fi == null) { fi = new Ficha(); } return fi; }
            set { fi = value; }
        }
        private Info_Legal inf = null;
        internal Info_Legal Inf
        {
            get { if (inf == null) { inf = new Info_Legal(); } return inf; }
            set { inf = value; }
        }
        private Lin_Ref lin = null;
        internal Lin_Ref Lin
        {
            get { if (lin == null) { lin = new Lin_Ref(); } return lin; }
            set { lin = value; }
        }
        private Localizacion lo = null;
        internal Localizacion Lo
        {
            get { if (lo == null) { lo = new Localizacion(); } return lo; }
            set { lo = value; }
        }
        private Maquinaria maq = null;
        internal Maquinaria Maq
        {
            get { if (maq == null) { maq = new Maquinaria(); } return maq; }
            set { maq = value; }
        }
        private Mat_Edificio me = null;
        internal Mat_Edificio Me
        {
            get { if (me == null) { me = new Mat_Edificio(); } return me; }
            set { me = value; }
        }
        private Mejoras_Predio mp = null;
        internal Mejoras_Predio Mp
        {
            get { if (mp == null) { mp = new Mejoras_Predio(); } return mp; }
            set { mp = value; }
        }
        private Relieve re = null;
        internal Relieve Re
        {
            get { if (re == null) { re = new Relieve(); } return re; }
            set { re = value; }
        }
        private Responsable res = null;
        internal Responsable Res
        {
            get { if (res == null) { res = new Responsable(); } return res; }
            set { res = value; }
        }
        private Semoviente se = null;
        internal Semoviente Se
        {
            get { if (se == null) { se = new Semoviente(); } return se; }
            set { se = value; }
        }
        private Serv_Predio sp = null;
        internal Serv_Predio Sp
        {
            get { if (sp == null) { sp = new Serv_Predio(); } return sp; }
            set { sp = value; }
        }
        private Servicio_Via sv = null;
        internal Servicio_Via Sv
        {
            get { if (sv == null) { sv = new Servicio_Via(); } return sv; }
            set { sv = value; }
        }
        private Uso_Suelo us = null;
        internal Uso_Suelo Us
        {
            get { if (us == null) { us = new Uso_Suelo(); } return us; }
            set { us = value; }
        }

        private Avaluo avaluo;

        internal Avaluo Avaluo
        {
            get { if (avaluo == null) { avaluo = new Avaluo(); } return avaluo; }
            set { avaluo = value; }
        }

        public int ultimoProp()
        {
            int id_p = 0;
            try
            {
                MySqlDataReader dr = leerDB("SELECT MAX(pr_id) FROM propietarios");
                while (dr.Read())
                {
                    id_p = int.Parse(dr[0].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                id_p = 0;
                throw ex;
            }
            return id_p;
        }
        public int ultimaFich()
        {
            int id_p = 0;
            try
            {
                MySqlDataReader dr = leerDB("SELECT MAX(fi_id) FROM fichas");
                while (dr.Read())
                {
                    id_p = int.Parse(dr[0].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                id_p = 0;
                throw ex;
            }
            return id_p;
        }
        public int guardarActualizar(string sql)
        {
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexionPredio();
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
        public Propietario obtenerProp(string sql)
        {
            Propietario p = null;
            try
            {
                MySqlDataReader dr = leerDB(sql);
                while (dr.Read())
                {
                    p = new Propietario();
                    p.Id = int.Parse(dr[0].ToString());
                    p.Ci_nat = dr[1].ToString();
                    p.Nom_nat = dr[2].ToString();
                    p.Fnat = dr[3].ToString();
                    p.Ci_con = dr[4].ToString();
                    p.Nom_con = dr[5].ToString();
                    p.Fcon = dr[6].ToString();
                    p.Ruc_jur = dr[7].ToString();
                    p.Nom_jur = dr[8].ToString();
                    p.Am_jur = dr[9].ToString();
                    p.Fjur = dr[10].ToString();
                    p.Dni_rl = dr[11].ToString();
                    p.Nom_rl = dr[12].ToString();
                    p.Direccion = dr[13].ToString();
                    p.Telefono = dr[14].ToString();
                    p.Email = dr[15].ToString();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                p = null;
                throw ex;
            }
            return p;
        }
        public Ficha obtenerFicha(string sql)
        { 
            Ficha f = null;
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexionPredio();
            try
            {
                cmd = new MySqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    f = new Ficha();
                    f.Id = int.Parse(dr[0].ToString());
                    f.Prov = dr[1].ToString();
                    f.Cant = dr[2].ToString();
                    f.Parr = dr[3].ToString();
                    f.Zona = dr[4].ToString();
                    f.Sect = dr[5].ToString();
                    f.Poli = dr[6].ToString();
                    f.Cod_catastro = dr[7].ToString();
                    f.Propietario = obtenerProp("Select * from propietarios where pr_id =" + int.Parse(dr[8].ToString()));
                    f.Cf = obtenerCaracFis("Select * from carac_fisicas where fi_id=" + f.Id);
                    f.LstCa = obtenerClasAgro("Select * from clases_agrol where fi_id=" + f.Id);
                    f.LstCv = obtenerCobVeg("Select * from cobert_vegetal where fi_id=" + f.Id);
                    f.LstDc = obtenerDesCons("Select * from desc_construcciones where fi_id=" + f.Id);
                    f.Il = obtenerInfLeg("Select * from info_legal where fi_id=" + f.Id);
                    f.Lin = obtenerLinRef("Select * from linderos where fi_id=" + f.Id);
                    f.Local = obtenerLoc("Select * from localizacion where fi_id=" + f.Id);
                    f.LstMaq = obtenerMaq("Select * from maq_equipos where fi_id=" + f.Id);
                    f.LstMe = obtenerMe("Select * from mat_edificio where fi_id=" + f.Id);
                    f.LstMp = obtenerMp("Select * from mejoras_predio where fi_id=" + f.Id);
                    f.MetLin = obtenerLinRef("Select * from met_linderacion where fi_id=" + f.Id);
                    f.RefCar = obtenerLinRef("Select * from ref_cartog where fi_id=" + f.Id);
                    f.LstRel = obtenerRel("Select * from relieve where fi_id=" + f.Id);
                    f.Resp = obtenerResp("Select * from responsables where fi_id=" + f.Id);
                    f.LstSem = obtenerSem("Select * from semovientes where fi_id=" + f.Id);
                    f.Sp = obtenerSp("Select * from servicios_predio where fi_id=" + f.Id);
                    f.Sv = obtenerSv("Select * from servicios_via where fi_id=" + f.Id);
                    f.LstUs = obtenerUs("Select * from uso_suelos where fi_id=" + f.Id);
                }
                dr.Close();
                cmd = null;
            }
            catch (Exception ex)
            {
                f = null;
                throw ex;
            }
            return f;
        }

        public List<Ficha> obtenerFichas(string sql)
        {
            List<Ficha> lst = new List<Ficha>();
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexionPredio();
            try
            {
                cmd = new MySqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Ficha f = new Ficha();
                    f.Id = int.Parse(dr[0].ToString());
                    f.Prov = dr[1].ToString();
                    f.Cant = dr[2].ToString();
                    f.Parr = dr[3].ToString();
                    f.Zona = dr[4].ToString();
                    f.Sect = dr[5].ToString();
                    f.Poli = dr[6].ToString();
                    f.Cod_catastro = dr[7].ToString();
                    f.Propietario = obtenerProp("Select * from propietarios where pr_id =" + int.Parse(dr[8].ToString()));
                    //f.Cf = obtenerCaracFis("Select * from carac_fisicas where fi_id=" + f.Id);
                    //f.LstCa = obtenerClasAgro("Select * from clases_agrol where fi_id=" + f.Id);
                    //f.LstCv = obtenerCobVeg("Select * from cobert_vegetal where fi_id=" + f.Id);
                    //f.LstDc = obtenerDesCons("Select * from desc_construcciones where fi_id=" + f.Id);
                    f.Il = obtenerInfLeg("Select * from info_legal where fi_id=" + f.Id);
                    //f.Lin = obtenerLinRef("Select * from linderos where fi_id=" + f.Id);
                    f.Local = obtenerLoc("Select * from localizacion where fi_id=" + f.Id);
                    //f.LstMaq = obtenerMaq("Select * from maq_equipos where fi_id=" + f.Id);
                    //f.LstMe = obtenerMe("Select * from mat_edificio where fi_id=" + f.Id);
                    //f.LstMp = obtenerMp("Select * from mejoras_predio where fi_id=" + f.Id);
                    //f.MetLin = obtenerLinRef("Select * from met_linderacion where fi_id=" + f.Id);
                    //f.RefCar = obtenerLinRef("Select * from ref_cartog where fi_id=" + f.Id);
                    //f.LstRel = obtenerRel("Select * from relieve where fi_id=" + f.Id);
                    //f.Resp = obtenerResp("Select * from responsables where fi_id=" + f.Id);
                    //f.LstSem = obtenerSem("Select * from semovientes where fi_id=" + f.Id);
                    //f.Sp = obtenerSp("Select * from servicios_predio where fi_id=" + f.Id);
                    //f.Sv = obtenerSv("Select * from servicios_via where fi_id=" + f.Id);
                    //f.LstUs = obtenerUs("Select * from uso_suelos where fi_id=" + f.Id);
                    lst.Add(f);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                lst = null;
                throw ex;
            }
            return lst;
        }

        private Carac_Fisica obtenerCaracFis(string sql)
        {
            Carac_Fisica cf = null;
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexionPredio();
            try
            {
                cmd = new MySqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cf = new Carac_Fisica();
                    cf.Id = int.Parse(dr[0].ToString());
                    cf.Forma = dr[1].ToString();
                    cf.Riesgo = dr[2].ToString();
                    cf.Erosion = dr[3].ToString();
                    cf.Clas_suelo = dr[4].ToString();
                    cf.Cob_natural = dr[5].ToString();
                    cf.Ecosis_rele = dr[6].ToString();
                    cf.Valor_cult = dr[7].ToString();
                    cf.Area = double.Parse(dr[8].ToString());
                    cf.Costo_base = double.Parse(dr[9].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                cf = null;
                throw ex;
            }
            return cf;
        }
        private List<Clase_Agrol> obtenerClasAgro(string sql)
        {
            List<Clase_Agrol> lst = new List<Clase_Agrol>();
            try
            {
                MySqlDataReader dr = leerDB(sql);
                while (dr.Read())
                {
                    Clase_Agrol ca = new Clase_Agrol();
                    ca.Id = int.Parse(dr[0].ToString());
                    ca.Clase = dr[1].ToString();
                    ca.Area = double.Parse(dr[2].ToString());
                    ca.Porcion = double.Parse(dr[3].ToString());
                    lst.Add(ca);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                lst = null;
                throw ex;
            }
            return lst;
        }
        private List<Cob_Vegetal> obtenerCobVeg(string sql)
        {
            List<Cob_Vegetal> lst = new List<Cob_Vegetal>();
            try
            {
                MySqlDataReader dr = leerDB(sql);
                while (dr.Read())
                {
                    Cob_Vegetal ca = new Cob_Vegetal();
                    ca.Id = int.Parse(dr[0].ToString());
                    ca.Desc = dr[1].ToString();
                    ca.Porc = double.Parse(dr[2].ToString());
                    ca.Edad = dr[3].ToString();
                    ca.Est = dr[4].ToString();
                    ca.Indicador = dr[5].ToString();
                    lst.Add(ca);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                lst = null;
                throw ex;
            }
            return lst;
        }
        private List<Desc_Construc> obtenerDesCons(string sql)
        {
            List<Desc_Construc> lst = new List<Desc_Construc>();
            try
            {
                MySqlDataReader dr = leerDB(sql);
                while (dr.Read())
                {
                    Desc_Construc ca = new Desc_Construc();
                    ca.Id = int.Parse(dr[0].ToString());
                    ca.Nrob = int.Parse(dr[1].ToString());
                    ca.Nrops = int.Parse(dr[2].ToString());
                    ca.Cond_fis = dr[3].ToString();
                    ca.Val_cul = dr[4].ToString();
                    ca.Anio = dr[5].ToString();
                    ca.Area = double.Parse(dr[6].ToString());
                    ca.Elect = dr[7].ToString();
                    ca.Sanit = dr[8].ToString();
                    ca.Espec = dr[9].ToString();
                    ca.Nro_banio = dr[10].ToString();
                    ca.PrecioBase = double.Parse(dr[11].ToString());
                    lst.Add(ca);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                lst = null;
                throw ex;
            }
            return lst;
        }
        private Info_Legal obtenerInfLeg(string sql)
        {
            Info_Legal cf = null;
            try
            {
                MySqlDataReader dr = leerDB(sql);
                while (dr.Read())
                {
                    cf = new Info_Legal();
                    cf.Id = int.Parse(dr[0].ToString());
                    cf.Form_tenen = dr[1].ToString();
                    cf.Sup_desc = dr[2].ToString();
                    cf.Sup_area = double.Parse(dr[3].ToString());
                    cf.Sup_unidad = dr[4].ToString();
                    cf.Dprf = dr[5].ToString();
                    cf.Dpfc = dr[6].ToString();
                    cf.Dp_auto = dr[7].ToString();
                    cf.Dp_fi = dr[8].ToString();
                    cf.Dp_lugar = dr[9].ToString();
                    cf.Dom = dr[10].ToString();
                    cf.Tip_tenen = dr[11].ToString();
                    cf.Desc_tenen = dr[12].ToString();
                    cf.Prop_ant = dr[13].ToString();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                cf = null;
                throw ex;
            }
            return cf;
        }
        private List<Lin_Ref> obtenerLinRef(string sql)
        {
            List<Lin_Ref> lst = new List<Lin_Ref>();
            try
            {
                MySqlDataReader dr = leerDB(sql);
                while (dr.Read())
                {
                    Lin_Ref cf = new Lin_Ref();
                    cf.Id = int.Parse(dr[0].ToString());
                    cf.Desc = dr[1].ToString();
                    cf.Info = dr[2].ToString();
                    lst.Add(cf);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                lst = null;
                throw ex;
            }
            return lst;
        }
        private Localizacion obtenerLoc(string sql)
        {
            Localizacion cf = null;
            try
            {
                MySqlDataReader dr = leerDB(sql);
                while (dr.Read())
                {
                    cf = new Localizacion();
                    cf.Id = int.Parse(dr[0].ToString());
                    cf.NomPred = dr[1].ToString();
                    cf.CodSect = dr[2].ToString();
                    cf.NomSect = dr[3].ToString();
                    cf.CodVia = dr[4].ToString();
                    cf.NomVia = dr[5].ToString();
                    cf.Cx = double.Parse(dr[6].ToString());
                    cf.Cy = double.Parse(dr[7].ToString());
                    cf.Manzana = dr[8].ToString();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                cf = null;
                throw ex;
            }
            return cf;
        }
        private List<Maquinaria> obtenerMaq(string sql)
        {
            List<Maquinaria> lst = new List<Maquinaria>();
            try
            {
                MySqlDataReader dr = leerDB(sql);
                while (dr.Read())
                {
                    Maquinaria cf = new Maquinaria();
                    cf.Id = int.Parse(dr[0].ToString());
                    cf.Den = dr[1].ToString();
                    cf.Marca = dr[2].ToString();
                    cf.Anio = dr[3].ToString();
                    cf.Estado = dr[4].ToString();
                    cf.Num = dr[5].ToString();
                    cf.Vigencia = dr[6].ToString();
                    lst.Add(cf);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                lst = null;
                throw ex;
            }
            return lst;
        }
        private List<Mat_Edificio> obtenerMe(string sql)
        {
            List<Mat_Edificio> lst = new List<Mat_Edificio>();
            try
            {
                MySqlDataReader dr = leerDB(sql);
                while (dr.Read())
                {
                    Mat_Edificio  cf = new Mat_Edificio();
                    cf.Id = int.Parse(dr[0].ToString());
                    cf.Nro_bloque = int.Parse(dr[1].ToString());
                    cf.Tipo = dr[2].ToString();
                    cf.Material = dr[3].ToString();
                    lst.Add(cf);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                lst = null;
                throw ex;
            }
            return lst;
        }
        private List<Mejoras_Predio> obtenerMp(string sql)
        {
            List<Mejoras_Predio> lst = new List<Mejoras_Predio>();
            try
            {
                MySqlDataReader dr = leerDB(sql);
                while (dr.Read())
                {
                    Mejoras_Predio cf = new Mejoras_Predio();
                    cf.Id = int.Parse(dr[0].ToString());
                    cf.Desc = dr[1].ToString();
                    cf.Tip_mat = dr[2].ToString();
                    cf.U_med = dr[3].ToString();
                    cf.Area = double.Parse(dr[4].ToString());
                    cf.Estado = dr[5].ToString();
                    cf.Vigencia = dr[6].ToString();
                    lst.Add(cf);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                lst = null;
                throw ex;
            }
            return lst;
        }
        private List<Relieve> obtenerRel(string sql)
        {
            List<Relieve> lst = new List<Relieve>();
            try
            {
                MySqlDataReader dr = leerDB(sql);
                while (dr.Read())
                {
                    Relieve cf = new Relieve();
                    cf.Id = int.Parse(dr[0].ToString());
                    cf.Desc = dr[1].ToString();
                    cf.Porcent = double.Parse(dr[2].ToString());
                    lst.Add(cf);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                lst = null;
                throw ex;
            }
            return lst;
        }
        private Responsable obtenerResp(string sql)
        {
            Responsable cf = null;
            try
            {
                MySqlDataReader dr = leerDB(sql);
                while (dr.Read())
                {
                    cf = new Responsable();
                    cf.Id = int.Parse(dr[0].ToString());
                    cf.Obs = dr[1].ToString();
                    cf.Tcat = dr[2].ToString();
                    cf.Fcat = dr[3].ToString();
                    cf.Tjur = dr[4].ToString();
                    cf.Fjur = dr[5].ToString();
                    cf.Prop = dr[6].ToString();
                    cf.Fprop = dr[7].ToString();
                    cf.Test = dr[8].ToString();
                    cf.Ftest = dr[9].ToString();
                    cf.Semp = dr[10].ToString();
                    cf.Femp = dr[11].ToString();
                    cf.Cgtc = dr[12].ToString();
                    cf.Fgtc = dr[13].ToString();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                cf = null;
                throw ex;
            }
            return cf;
        }
        private List<Semoviente> obtenerSem(string sql)
        {
            List<Semoviente> lst = new List<Semoviente>();
            try
            {
                MySqlDataReader dr = leerDB(sql);
                while (dr.Read())
                {
                    Semoviente cf = new Semoviente();
                    cf.Id = int.Parse(dr[0].ToString());
                    cf.Especie = dr[1].ToString();
                    cf.Raza = dr[2].ToString();
                    cf.Edad = dr[3].ToString();
                    cf.Sangre = dr[4].ToString();
                    cf.Num = dr[5].ToString();
                    cf.Vigencia = dr[6].ToString();
                    lst.Add(cf);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                lst = null;
                throw ex;
            }
            return lst;
        }
        private Serv_Predio obtenerSp(string sql)
        {
            Serv_Predio cf = null;
            try
            {
                MySqlDataReader dr = leerDB(sql);
                while (dr.Read())
                {
                    cf = new Serv_Predio();
                    cf.Id = int.Parse(dr[0].ToString());
                    cf.Agua = dr[1].ToString();
                    cf.Num_med_agua = dr[2].ToString();
                    cf.Num_agua = int.Parse(dr[3].ToString());
                    cf.Elect = dr[4].ToString();
                    cf.Num_med_elect = dr[5].ToString();
                    cf.Num_elect = int.Parse(dr[6].ToString());
                    cf.Num_tel = dr[7].ToString();
                    cf.Num_lin_tel = int.Parse(dr[8].ToString());
                    cf.Alcant = dr[9].ToString();
                    cf.Riego = dr[10].ToString();
                    cf.Met_riego = dr[11].ToString();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                cf = null;
                throw ex;
            }
            return cf;
        }
        private Servicio_Via obtenerSv(string sql)
        {
            Servicio_Via cf = null;
            try
            {
                MySqlDataReader dr = leerDB(sql);
                while (dr.Read())
                {
                    cf = new Servicio_Via();
                    cf.Id = int.Parse(dr[0].ToString());
                    cf.Tipo_via = dr[1].ToString();
                    cf.Mat_via = dr[2].ToString();
                    cf.Alumb = dr[3].ToString();
                    cf.Estado_via = dr[4].ToString();
                    cf.Pobla_cerca = dr[5].ToString();
                    cf.Transport = dr[6].ToString();
                    cf.Acera = dr[7].ToString();
                    cf.Basura = dr[8].ToString();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                cf = null;
                throw ex;
            }
            return cf;
        }
        private List<Uso_Suelo> obtenerUs(string sql)
        {
            List<Uso_Suelo> lst = new List<Uso_Suelo>();
            try
            {
                MySqlDataReader dr = leerDB(sql);
                while (dr.Read())
                {
                    Uso_Suelo cf = new Uso_Suelo();
                    cf.Id = int.Parse(dr[0].ToString());
                    cf.Uso = dr[1].ToString();
                    cf.Ext = double.Parse(dr[2].ToString());
                    cf.Porc = double.Parse(dr[3].ToString());
                    lst.Add(cf);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                lst = null;
                throw ex;
            }
            return lst;
        }

        public bool obtenerAvaluo(int id)
        {
            bool v = false;
            try
            {
                MySqlDataReader dr = leerDB("Select * from avaluo where fi_id=" + id);
                while (dr.Read())
                {
                    v = true;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                cf = null;
                throw ex;
            }
            return v;
        }


        private Avaluo obtenerAva(int id)
        {
            Avaluo avaluo = null;
            try
            {
                MySqlDataReader dr = leerDB("Select * from avaluo where fi_id=" + id);
                while (dr.Read())
                {
                    avaluo = new Avaluo();
                    avaluo.Id = int.Parse(dr[0].ToString());
                    avaluo.Avt = double.Parse(dr[1].ToString());
                    avaluo.Avc = double.Parse(dr[2].ToString());
                    avaluo.Avtotal = double.Parse(dr[3].ToString());
                    avaluo.Imp = double.Parse(dr[4].ToString());
                    avaluo.Imb = double.Parse(dr[5].ToString());
                    avaluo.Sea = double.Parse(dr[6].ToString());
                    avaluo.Imt = double.Parse(dr[7].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                cf = null;
                throw ex;
            }
            return avaluo;
        }

        private MySqlDataReader leerDB(string sql)
        { 
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexionPredio();
            try
            {
                cmd = new MySqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                cmd = null;
                return dr;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        //metodos para armar la cadena sql
        public string cadena(Propietario p)
        {
            return "Insert into propietarios "
                    +"(`pr_ci_nat`,`pr_nom_nat`,`pr_fnac_nat`,`pr_ci_con`,`pr_nom_con`,`pr_fnac_con`,`pr_ruc_ju`,`pr_nom_ju`,`pr_acminis_ju`,`pr_fnac_ju`,`pr_dni_rl`,`pr_nom_rl`,`pr_dir`,`pr_tel`,`pr_email`) "
                    +"Values ("
                    +"'"+ p.Ci_nat
                    + "','" + p.Nom_nat
                    + "','" + p.Fnat
                    + "','" + p.Ci_con
                    + "','" + p.Nom_con
                    + "','" + p.Fcon
                    + "','" + p.Ruc_jur
                    + "','" + p.Nom_jur
                    + "','" + p.Am_jur
                    + "','" + p.Fjur
                    + "','" + p.Dni_rl
                    + "','" + p.Nom_rl
                    + "','" + p.Direccion
                    + "','" + p.Telefono
                    + "','" + p.Email
                    + "')";
        }
        public string cadena(Ficha f)
        {
            return "Insert into fichas "
                    +"(`fi_cod_prov`,`fi_cod_can`,`fi_cod_par`,`fi_cod_zon`,`fi_cod_sec`,`fi_cod_pol`,`fi_cod_catastral`,`pr_id`) "
                    + "Values ("
                    + "'" + f.Prov
                    + "','" + f.Cant
                    + "','" + f.Parr
                    + "','" + f.Zona
                    + "','" + f.Sect
                    + "','" + f.Poli
                    + "','" + f.Cod_catastro
                    + "'," + f.Propietario.Id
                    + ")";
        }
        public string cadena(Carac_Fisica f)
        {
            return "Insert into carac_fisicas "
                    + "(`cf_forma`,`cf_riesgo`,`cf_erosion`,`cf_clas_suelo`,`cf_cob_nat`,`cf_ecos_rele`,`cf_valor_cult`,`cf_area_tot`,`cf_costo_base`,`fi_id`)"
                    + " Values ("
                    + "'" + f.Forma
                    + "','" + f.Riesgo
                    + "','" + f.Erosion
                    + "','" + f.Clas_suelo
                    + "','" + f.Cob_natural
                    + "','" + f.Ecosis_rele
                    + "','" + f.Valor_cult
                    + "'," + f.Area
                    + "," + f.Costo_base
                    + "," + f.Ficha.Id
                    + ")";
        }
        public string cadena(Clase_Agrol f)
        {
            return "Insert into clases_agrol "
                    + "(`ca_clase`,`ca_area`,`ca_porc`,`fi_id`)"
                    + " Values ("
                    + "'" + f.Clase
                    + "'," + f.Area
                    + "," + f.Porcion
                    + "," + f.Ficha.Id
                    + ")";
        }
        public string cadena(Cob_Vegetal f)
        {
            return "Insert into cobert_vegetal "
                    + "(`cv_desc`,`cv_porc`,`cv_edad`,`cv_est`,`cv_ind`,`fi_id`)"
                    + " Values ("
                    + "'" + f.Desc
                    + "'," + f.Porc
                    + ",'" + f.Edad
                    + "','" + f.Est
                    + "','" + f.Indicador
                    + "'," + f.Ficha.Id
                    + ")";
        }
        public string cadena(Desc_Construc f)
        {
            return "Insert into desc_construcciones "
                    + "(`dc_nro_b`,`dc_nro_pisos`,`dc_cond_f`,`dc_val_c`,`dc_anio`,`dc_area`,`dc_elec`,`dc_sanit`,`dc_especial`,`dc_nro_banio`, `dc_costo_base`,`fi_id`)"
                    + " Values ("
                    + f.Nrob
                    + "," + f.Nrops
                    + ",'" + f.Cond_fis
                    + "','" + f.Val_cul
                    + "','" + f.Anio
                    + "'," + f.Area
                    + ",'" + f.Elect
                    + "','" + f.Sanit
                    + "','" + f.Espec
                    + "','" + f.Nro_banio
                    + "'," + f.PrecioBase
                    + "," + f.Ficha.Id
                    + ")";
        }
        public string cadena(Info_Legal f)
        {
            return "Insert into info_legal "
                    + "(`il_form_tenen`,`il_sup_desc`,`il_sup_area`,`il_sup_unid`,`il_dp_fec`,`il_dp_fecc`,`il_dp_aut`,`il_dp_feci`,`il_dp_lugar`,`il_dominio`,`il_tip_tenen`,`il_desc_tenen`,`il_prop_ant`,`fi_id`)"
                    + " Values ("
                    + "'"+f.Form_tenen
                    + "','" + f.Sup_desc
                    + "'," + f.Sup_area
                    + ",'" + f.Sup_unidad
                    + "','" + f.Dprf
                    + "','" + f.Dpfc
                    + "','" + f.Dp_auto
                    + "','" + f.Dp_fi
                    + "','" + f.Dp_lugar
                    + "','" + f.Dom
                    + "','" + f.Tip_tenen
                    + "','" + f.Desc_tenen
                    + "','" + f.Prop_ant
                    + "'," + f.Ficha.Id
                    + ")";
        }
        public string cadena(Lin_Ref f, int t)
        {
            if (t == 1)
            {
                return "Insert into linderos "
                        + "(`li_punt_card`,`li_nom_prop`,`fi_id`)"
                        + " Values ("
                        + "'" + f.Desc
                        + "','" + f.Info
                        + "'," + f.Ficha.Id
                        + ")";
            }
            else 
            {
                if (t == 2)
                {
                    return "Insert into met_linderacion "
                        + "(`li_desc`,`li_obs`,`fi_id`)"
                        + " Values ("
                        + "'" + f.Desc
                        + "','" + f.Info
                        + "'," + f.Ficha.Id
                        + ")";
                }
                else
                {
                    return "Insert into ref_cartog "
                        + "(`rc_descripcion`,`rc_cod`,`fi_id`)"
                        + " Values ("
                        + "'" + f.Desc
                        + "','" + f.Info
                        + "'," + f.Ficha.Id
                        + ")";
                }
            }
        }
        public string cadena(Localizacion f)
        {
            return "Insert into localizacion "
                    + "(`lo_nombre_predio`,`lo_cod_sect`,`lo_nom_sect`,`lo_cod_via`,`lo_nom_via`,`lo_coor_x`,`lo_coor_y`,`lo_loc_manz`,`fi_id`)"
                    + " Values ("
                    + "'" + f.NomPred
                    + "','" + f.CodSect
                    + "','" + f.NomSect
                    + "','" + f.CodVia
                    + "','" + f.NomVia
                    + "'," + f.Cx
                    + "," + f.Cy
                    + ",'" + f.Manzana
                    + "'," + f.Ficha.Id
                    + ")";
        }
        public string cadena(Maquinaria f)
        {
            return "Insert into maq_equipos "
                    + "(`mq_den`,`mq_marca`,`mq_anio`,`mq_estado`,`mq_numero`,`mq_vigente`,`fi_id`)"
                    + " Values ("
                    + "'" + f.Den
                    + "','" + f.Marca
                    + "','" + f.Anio
                    + "','" + f.Estado
                    + "','" + f.Num
                    + "','" + f.Vigencia
                    + "'," + f.Ficha.Id
                    + ")";
        }
        public string cadena(Mat_Edificio f)
        {
            return "Insert into mat_edificio "
                    + "(`me_nro_b`,`me_tipo`,`me_mat`,`fi_id`)"
                    + " Values ("
                    + f.Nro_bloque
                    + ",'" + f.Tipo
                    + "','" + f.Material
                    + "'," + f.Ficha.Id
                    + ")";
        }
        public string cadena(Mejoras_Predio f)
        {
            return "Insert into mejoras_predio "
                    + "(`mp_desc`,`mp_mat`,`mp_unid`,`mp_cant`,`mp_estado`,`mp_vigencia`,`fi_id`)"
                    + " Values ("
                    + "'" + f.Desc
                    + "','" + f.Tip_mat
                    + "','" + f.U_med
                    + "'," + f.Area
                    + ",'" + f.Estado
                    + "','" + f.Vigencia
                    + "'," + f.Ficha.Id
                    + ")";
        }
        public string cadena(Relieve f)
        {
            return "Insert into relieve "
                    + "(`re_desc`,`re_porc`,`fi_id`)"
                    + " Values ("
                    + "'" + f.Desc
                    + "'," + f.Porcent
                    + "," + f.Ficha.Id
                    + ")";
        }
        public string cadena(Responsable f)
        {
            return "Insert into responsables "
                    + "(`re_obser`,`re_tcat`,`re_fec_cat`,`re_tjur`,`re_fec_jur`,`re_prop`,`re_fecha_prop`,`re_test`,`re_fecha_test`,`re_semp`,`re_fec_emp`,`re_cgtc`,`re_fec_gtc`,`fi_id`)"
                    + " Values ("
                    + "'" + f.Obs
                    + "','" + f.Tcat
                    + "','" + f.Fcat
                    + "','" + f.Tjur
                    + "','" + f.Fjur
                    + "','" + f.Prop
                    + "','" + f.Fprop
                    + "','" + f.Test
                    + "','" + f.Ftest
                    + "','" + f.Semp
                    + "','" + f.Femp
                    + "','" + f.Cgtc
                    + "','" + f.Fgtc
                    + "'," + f.Ficha.Id
                    + ")";
        }
        public string cadena(Semoviente f)
        {
            return "Insert into semovientes "
                    + "(`se_especie`,`se_raza`,`se_edad`,`se_sangre`,`se_numero`,`se_vigente`,`fi_id`)"
                    + " Values ("
                    + "'" + f.Especie
                    + "','" + f.Raza
                    + "','" + f.Edad
                    + "','" + f.Sangre
                    + "','" + f.Num
                    + "','" + f.Vigencia
                    + "'," + f.Ficha.Id
                    + ")";
        }
        public string cadena(Serv_Predio f)
        {
            return "Insert into servicios_predio "
                    + "(`sp_agua`,`sp_med_prin_agua`,`sp_medid_agua`,`sp_elect`,`sp_med_prin_elec`,`sp_medid_elec`,`sp_num_telf_prin`,`sp_num_lineas_tel`,`sp_alcant`,`sp_riego`,`sp_met_riego`,`fi_id`)"
                    + " Values ("
                    + "'" + f.Agua
                    + "','" + f.Num_med_agua
                    + "'," + f.Num_agua
                    + ",'" + f.Elect
                    + "','" + f.Num_med_elect
                    + "'," + f.Num_elect
                    + ",'" + f.Num_tel
                    + "'," + f.Num_lin_tel
                    + ",'" + f.Alcant
                    + "','" + f.Riego
                    + "','" + f.Met_riego
                    + "'," + f.Ficha.Id
                    + ")";
        }
        public string cadena(Servicio_Via f)
        {
            return "Insert into servicios_via "
                    + "(`sv_tipo_via`,`sv_mat_via`,`sv_alumbrado`,`sv_est_via`,`sv_pobla_cerca`,`sv_transp_public`,`sv_acera`,`sv_basura`,`fi_id`)"
                    + " Values ("
                    + "'" + f.Tipo_via
                    + "','" + f.Mat_via
                    + "','" + f.Alumb
                    + "','" + f.Estado_via
                    + "','" + f.Pobla_cerca
                    + "','" + f.Transport
                    + "','" + f.Acera
                    + "','" + f.Basura
                    + "'," + f.Ficha.Id
                    + ")";
        }
        public string cadena(Uso_Suelo f)
        {
            return "Insert into uso_suelos "
                    + "(`us_uso`,`us_ext`,`us_porc`,`fi_id`)"
                    + " Values ("
                    + "'" + f.Uso
                    + "'," + f.Ext
                    + "," + f.Porc
                    + "," + f.Ficha.Id
                    + ")";
        }
    }
}
