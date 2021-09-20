using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGPRER.model.dato_predial;

namespace SIGPRER.model
{
    class Ficha
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string prov, cant, parr, zona, sect, poli, cod_catastro, lote;

        public string Lote
        {
            get { return lote; }
            set { lote = value; }
        }

        public string Prov
        {
            get { return prov; }
            set { prov = value; }
        }

        public string Cant
        {
            get { return cant; }
            set { cant = value; }
        }

        public string Parr
        {
            get { return parr; }
            set { parr = value; }
        }

        public string Zona
        {
            get { return zona; }
            set { zona = value; }
        }

        public string Sect
        {
            get { return sect; }
            set { sect = value; }
        }

        public string Poli
        {
            get { return poli; }
            set { poli = value; }
        }

        public string Cod_catastro
        {
            get { return cod_catastro; }
            set { cod_catastro = value; }
        }

        private Propietario propietario;

        public Propietario Propietario
        {
            get { return propietario; }
            set { propietario = value; }
        }

        private Carac_Fisica cf;

        internal Carac_Fisica Cf
        {
            get { return cf; }
            set { cf = value; }
        }

        private List<Clase_Agrol> lstCa;

        internal List<Clase_Agrol> LstCa
        {
            get { return lstCa; }
            set { lstCa = value; }
        }

        private List<Cob_Vegetal> lstCv;

        internal List<Cob_Vegetal> LstCv
        {
            get { return lstCv; }
            set { lstCv = value; }
        }

        private List<Desc_Construc> lstDc;

        internal List<Desc_Construc> LstDc
        {
            get { return lstDc; }
            set { lstDc = value; }
        }

        private Info_Legal il;

        internal Info_Legal Il
        {
            get { return il; }
            set { il = value; }
        }

        private List<Lin_Ref> lin;

        internal List<Lin_Ref> Lin
        {
            get { return lin; }
            set { lin = value; }
        }
        private Localizacion local;

        internal Localizacion Local
        {
            get { return local; }
            set { local = value; }
        }

        private List<Maquinaria> lstMaq;

        internal List<Maquinaria> LstMaq
        {
            get { return lstMaq; }
            set { lstMaq = value; }
        }

        private List<Mat_Edificio> lstMe;

        internal List<Mat_Edificio> LstMe
        {
            get { return lstMe; }
            set { lstMe = value; }
        }

        private List<Mejoras_Predio> lstMp;

        internal List<Mejoras_Predio> LstMp
        {
            get { return lstMp; }
            set { lstMp = value; }
        }

        private List<Lin_Ref> metLin;

        internal List<Lin_Ref> MetLin
        {
            get { return metLin; }
            set { metLin = value; }
        }

        private List<Lin_Ref> refCar;

        internal List<Lin_Ref> RefCar
        {
            get { return refCar; }
            set { refCar = value; }
        }

        private List<Relieve> lstRel;

        internal List<Relieve> LstRel
        {
            get { return lstRel; }
            set { lstRel = value; }
        }

        private Responsable resp;

        internal Responsable Resp
        {
            get { return resp; }
            set { resp = value; }
        }

        private List<Semoviente> lstSem;

        internal List<Semoviente> LstSem
        {
            get { return lstSem; }
            set { lstSem = value; }
        }

        private Serv_Predio sp;

        internal Serv_Predio Sp
        {
            get { return sp; }
            set { sp = value; }
        }

        private Servicio_Via sv;

        internal Servicio_Via Sv
        {
            get { return sv; }
            set { sv = value; }
        }
        private List<Uso_Suelo> lstUs;

        internal List<Uso_Suelo> LstUs
        {
            get { return lstUs; }
            set { lstUs = value; }
        }

        private List<Ficha> lst;

        internal List<Ficha> Lst
        {
            get { return lst; }
            set { lst = value; }
        }

        private Avaluo avaluo;

        internal Avaluo Avaluo
        {
            get { return avaluo; }
            set { avaluo = value; }
        }
    }
}
