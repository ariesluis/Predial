using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIGPRER.controller;
using SIGPRER.controller.factores;
using SIGPRER.controller.predios;
using SIGPRER.controller.user;

namespace SIGPRER.view.ficha
{
    public partial class FrmConsultar : Form
    {
        public FrmConsultar()
        {
            InitializeComponent();
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }

        private FactorDB fdb = new FactorDB();
        private PredioDB pdb = new PredioDB();
        private UserDB udb = new UserDB();

        private void cargarFactor()
        {
            //forma tenencia 1
            cargarCmbFactor(cmbFormTen, "Forma Adquisición");
            //uso suelo 2
            cargarCmbFactor(dgvUsoSuelo.Columns[0] as DataGridViewComboBoxColumn, "Uso Suelo");
            //agua 3
            cargarCmbFactor(cmbAgua, "Agua Proviene");
            //electricidad 4
            cargarCmbFactor(cmbElec, "Energía Eléctrica Proviene");
            //alcantarillado 5
            cargarCmbFactor(cmbAlcan, "Alcantarillado");
            //tipo de via 6
            cargarCmbFactor(cmbTipVia, "Tipo Vía");
            //disponibilidad de riego 7
            cargarCmbFactor(cmbTipRiego, "Disponibilidad Riego");
            //metodo de riego 8
            cargarCmbFactor(cmbMetRiego, "Método Riego");
            //localizacion en la manzana 9
            cargarCmbFactor(cmbLocMan, "Localización Manzana");
            //domino 10
            cargarCmbFactor(cmbDominio, "Dominio");
            //tipo de tenencia 11
            cargarCmbFactor(cmbTipTenen, "Tipo Tenencia");
            // forma predio 12
            cargarCmbFactor(cmbForma, "Forma del Predio");
            // riesgo 13
            cargarCmbFactor(cmbRiesgo, "Riesgo");
            // erosion 14
            cargarCmbFactor(cmbErosion, "Erosión");
            // clasificacion del suelo 15
            cargarCmbFactor(cmbClasSuelo, "Clasificación Suelo");
            // cobertura natura 16
            cargarCmbFactor(cmbCobNat, "Cobertura Natural");
            //ecosistema relevante 17
            cargarCmbFactor(cmbEcosRel, "Ecosistema Relevante");
            //valor cultural 18
            cargarCmbFactor(cmbValCul, "Valor Cultural");
            //poblaciones cercanas 19
            cargarCmbFactor(cmbPobCer, "Poblaciones Cercanas");
            //estado via 20
            cargarCmbFactor(cmbEstVia, "Estado Vía");
            //material via 21
            cargarCmbFactor(cmbMatVia, "Rodadura");
            //acera 22
            cargarCmbFactor(cmbAcera, "Acera");
            //alumbrado publico 23
            cargarCmbFactor(cmbAluPub, "Alumbrado");
            //transporte publico 24
            cargarCmbFactor(cmbTraPub, "Transporte Público");
            //eliminacion basura 25
            cargarCmbFactor(cmbRecBas, "Recolección Basura");
            //clases agrologicas 26
            cargarCmbFactor((DataGridViewComboBoxColumn)dgvClasAgro.Columns[0], "Clasificación Agrológica");
            //edificacion 27
            // condicion fisica
            cargarCmbFactor((DataGridViewComboBoxColumn)dgvDescCons.Columns[2], "Condición Física");
            //valor cultural
            cargarCmbFactor((DataGridViewComboBoxColumn)dgvDescCons.Columns[3], "Valor Cultural");
            //estado conservacion
            cargarCmbFactor((DataGridViewComboBoxColumn)dgvDescCons.Columns[6], "Estado Conservación");
            //estado conservacion
            cargarCmbFactor((DataGridViewComboBoxColumn)dgvDescCons.Columns[7], "Estado Conservación");
            //instalaciones especiales
            cargarCmbFactor((DataGridViewComboBoxColumn)dgvDescCons.Columns[8], "Instalaciones Especiales");
            //numero de baños
            cargarCmbFactor((DataGridViewComboBoxColumn)dgvDescCons.Columns[9], "Numero Baños");
            //mejoras e instalaciones 28
            //infraestuctrura agropecuaria y mejoras e instalaciones
            cargarCmbFactor((DataGridViewComboBoxColumn)dgvInfAgrop.Columns[0], "Obra o Mejora");
            cargarCmbFactor((DataGridViewComboBoxColumn)dgvInfAgrop.Columns[1], "Material");
            cargarCmbFactor((DataGridViewComboBoxColumn)dgvInfAgrop.Columns[4], "Condición Física");
            cargarCmbFactor((DataGridViewComboBoxColumn)dgvMejIns.Columns[0], "Uso Constructivo");
            cargarCmbFactor((DataGridViewComboBoxColumn)dgvMejIns.Columns[1], "Material");
            cargarCmbFactor((DataGridViewComboBoxColumn)dgvMejIns.Columns[4], "Condición Física");
            //relieve
            cargarCmbFactor((DataGridViewComboBoxColumn)dgvRelieve.Columns[0], "Relieve");
        }
        private void cargarCmbFactor(ComboBox cmb, string facto)
        {
            FactorDB fdb1 = new FactorDB();
            fdb1.Fac = fdb1.traerFactor(facto);
            fdb1.Facv.Lst = fdb1.listSegunFactor(fdb1.Fac.Id);
            cmb.DisplayMember = "desc";
            cmb.ValueMember = "fa_id";
            cmb.DataSource = fdb1.Facv.Lst;
        }
        private void cargarCmbFactor(DataGridViewComboBoxColumn dgvcol, string facto)
        {
            dgvcol.Items.Clear();
            FactorDB fdb1 = new FactorDB();
            fdb1.Fac = fdb1.traerFactor(facto);
            if (facto != "Relieve")
                fdb1.Facv.Lst = fdb.listSegunFactor(fdb1.Fac.Id);
            else
                fdb1.Facv.Lst = fdb.listFactorRelieve(fdb1.Fac.Id);

            for (int i = 0; i < fdb1.Facv.Lst.Count; i++)
            {
                dgvcol.Items.Add(fdb1.Facv.Lst[i]);
            }
            dgvcol.DisplayMember = "desc";
        }

        private void cargarDatos()
        {
            pdb.Fi = pdb.obtenerFicha("Select * from fichas where fi_cod_catastral='" + Util.Util.leerParamXml("catastrogdb.xml") + "'");
            if (pdb.Fi.Propietario != null)
            {
                //datos propietario
                txtCiNat.Text = pdb.Fi.Propietario.Ci_nat;
                txtANNat.Text = pdb.Fi.Propietario.Nom_nat;
                dtpFnNat.Value = DateTime.Parse(pdb.Fi.Propietario.Fnat);
                txtCiCo.Text = pdb.Fi.Propietario.Ci_con;
                txtNACo.Text = pdb.Fi.Propietario.Nom_con;
                dtpFnCo.Value = DateTime.Parse(pdb.Fi.Propietario.Fcon);
                txtRuJu.Text = pdb.Fi.Propietario.Ruc_jur;
                txtNoJu.Text = pdb.Fi.Propietario.Nom_jur;
                txtAMJu.Text = pdb.Fi.Propietario.Am_jur;
                dtpFeJu.Value = DateTime.Parse(pdb.Fi.Propietario.Fjur);
                txtRuRl.Text = pdb.Fi.Propietario.Dni_rl;
                txtNoRl.Text = pdb.Fi.Propietario.Nom_rl;
                txtDir.Text = pdb.Fi.Propietario.Direccion;
                txtTel.Text = pdb.Fi.Propietario.Telefono;
                txtEmail.Text = pdb.Fi.Propietario.Email;
                //datos ficha
                txtCprov.Text = pdb.Fi.Prov;
                txtCcant.Text = pdb.Fi.Cant;
                txtCparr.Text = pdb.Fi.Parr;
                txtCzona.Text = pdb.Fi.Zona;
                txtCsect.Text = pdb.Fi.Sect;
                txtCpoli.Text = pdb.Fi.Poli;
                //caracteristicas fisicas
                cmbForma.Text = pdb.Fi.Cf.Forma;
                cmbRiesgo.Text = pdb.Fi.Cf.Riesgo;
                cmbErosion.Text = pdb.Fi.Cf.Erosion;
                cmbClasSuelo.Text = pdb.Fi.Cf.Clas_suelo;
                cmbCobNat.Text = pdb.Fi.Cf.Cob_natural;
                cmbEcosRel.Text = pdb.Fi.Cf.Ecosis_rele;
                cmbValCul.Text = pdb.Fi.Cf.Valor_cult;
                nudAreaTot.Value = (decimal)pdb.Fi.Cf.Area;
                nudPrecioBase.Value = (decimal)pdb.Fi.Cf.Costo_base;
                //clases agrologicas
                for (int i = 0; i < pdb.Fi.LstCa.Count; i++)
                {
                    dgvClasAgro.Rows.Add(1);
                    dgvClasAgro.Rows[i].Cells[0].Value = pdb.Fi.LstCa[i].Clase;
                    dgvClasAgro.Rows[i].Cells[1].Value = pdb.Fi.LstCa[i].Area;
                    dgvClasAgro.Rows[i].Cells[2].Value = pdb.Fi.LstCa[i].Porcion;
                }
                //cobertura vegetal
                int conti = 0; int conta = 0;
                for (int i = 0; i < pdb.Fi.LstCv.Count; i++)
                {
                    if (pdb.Fi.LstCv[i].Indicador == "i")
                    {
                        dgvCobVegI.Rows.Add();
                        dgvCobVegI.Rows[conti].Cells[0].Value = pdb.Fi.LstCv[i].Desc;
                        dgvCobVegI.Rows[conti].Cells[1].Value = pdb.Fi.LstCv[i].Porc;
                        dgvCobVegI.Rows[conti].Cells[2].Value = pdb.Fi.LstCv[i].Edad;
                        dgvCobVegI.Rows[conti].Cells[4].Value = pdb.Fi.LstCv[i].Est;
                        conti++;
                    }
                    if (pdb.Fi.LstCv[i].Indicador == "a")
                    {
                        dgvCobVegI.Rows.Add();
                        dgvCobVegI.Rows[conta].Cells[0].Value = pdb.Fi.LstCv[i].Desc;
                        dgvCobVegI.Rows[conta].Cells[1].Value = pdb.Fi.LstCv[i].Porc;
                        dgvCobVegI.Rows[conta].Cells[2].Value = pdb.Fi.LstCv[i].Edad;
                        dgvCobVegI.Rows[conta].Cells[4].Value = pdb.Fi.LstCv[i].Est;
                        conta++;
                    }
                }
                //descripcion de contrucciones
                for (int i = 0; i < pdb.Fi.LstDc.Count; i++)
                {
                    dgvDescCons.Rows.Add(1);
                    dgvDescCons.Rows[i].Cells[0].Value = pdb.Fi.LstDc[i].Nrob;
                    dgvDescCons.Rows[i].Cells[1].Value = pdb.Fi.LstDc[i].Nrops;
                    dgvDescCons.Rows[i].Cells[2].Value = pdb.Fi.LstDc[i].Cond_fis;
                    dgvDescCons.Rows[i].Cells[3].Value = pdb.Fi.LstDc[i].Val_cul;
                    dgvDescCons.Rows[i].Cells[4].Value = pdb.Fi.LstDc[i].Anio;
                    dgvDescCons.Rows[i].Cells[5].Value = pdb.Fi.LstDc[i].Area;
                    dgvDescCons.Rows[i].Cells[6].Value = pdb.Fi.LstDc[i].Elect;
                    dgvDescCons.Rows[i].Cells[7].Value = pdb.Fi.LstDc[i].Sanit;
                    dgvDescCons.Rows[i].Cells[8].Value = pdb.Fi.LstDc[i].Espec;
                    dgvDescCons.Rows[i].Cells[9].Value = pdb.Fi.LstDc[i].Nro_banio;
                    dgvDescCons.Rows[i].Cells[10].Value = pdb.Fi.LstDc[i].PrecioBase;
                }
                //informacion legal
                cmbFormTen.Text = pdb.Fi.Il.Form_tenen;
                cmbSupDesc.Text = pdb.Fi.Il.Sup_desc;
                nudSupArea.Value = (decimal)pdb.Fi.Il.Sup_area;
                cmbUnidad.Text = pdb.Fi.Il.Sup_unidad;
                dtpPrF.Value = DateTime.Parse(pdb.Fi.Il.Dprf);
                dtpPFc.Value = DateTime.Parse(pdb.Fi.Il.Dpfc);
                txtAut.Text = pdb.Fi.Il.Dp_auto;
                dtpPFi.Value = DateTime.Parse(pdb.Fi.Il.Dp_fi);
                txtLugIns.Text = pdb.Fi.Il.Dp_lugar;
                cmbDominio.Text = pdb.Fi.Il.Dom;
                cmbTipTenen.Text = pdb.Fi.Il.Tip_tenen;
                cmbDescTenen.Text = pdb.Fi.Il.Desc_tenen;
                txtPropAnt.Text = pdb.Fi.Il.Prop_ant;
                //linderos
                for (int i = 0; i < pdb.Fi.Lin.Count; i++)
                {
                    if (pdb.Fi.Lin[i].Desc == "n")
                        txtNort.Text = pdb.Fi.Lin[i].Info;
                    if (pdb.Fi.Lin[i].Desc == "s")
                        txtSur.Text = pdb.Fi.Lin[i].Info;
                    if (pdb.Fi.Lin[i].Desc == "e")
                        txtEst.Text = pdb.Fi.Lin[i].Info;
                    if (pdb.Fi.Lin[i].Desc == "o")
                        txtOest.Text = pdb.Fi.Lin[i].Info;
                }
                //localizacion
                txtNomPred.Text = pdb.Fi.Local.NomPred;
                txtCodRec.Text = pdb.Fi.Local.CodSect;
                txtNomRec.Text = pdb.Fi.Local.NomSect;
                txtCodVia.Text = pdb.Fi.Local.CodVia;
                txtNomVia.Text = pdb.Fi.Local.NomVia;
                txtCoorX.Text = pdb.Fi.Local.Cx + "";
                txtCoorY.Text = pdb.Fi.Local.Cy + "";
                cmbLocMan.Text = pdb.Fi.Local.Manzana;
                //maquinaria y equipos
                for (int i = 0; i < pdb.Fi.LstMaq.Count; i++)
                {
                    dgvMaq.Rows.Add(1);
                    dgvMaq.Rows[i].Cells[0].Value = pdb.Fi.LstMaq[i].Den;
                    dgvMaq.Rows[i].Cells[1].Value = pdb.Fi.LstMaq[i].Marca;
                    dgvMaq.Rows[i].Cells[2].Value = pdb.Fi.LstMaq[i].Anio;
                    dgvMaq.Rows[i].Cells[3].Value = pdb.Fi.LstMaq[i].Estado;
                    dgvMaq.Rows[i].Cells[4].Value = pdb.Fi.LstMaq[i].Num;
                }
                //materiales de edificio
                for (int i = 0; i < pdb.Fi.LstMe.Count; i++)
                {
                    dgvMatEdif.Rows.Add(1);
                    dgvMatEdif.Rows[i].Cells[0].Value = pdb.Fi.LstMe[i].Nro_bloque;
                    dgvMatEdif.Rows[i].Cells[1].Value = pdb.Fi.LstMe[i].Tipo;
                    dgvMatEdif.Rows[i].Cells[2].Value = pdb.Fi.LstMe[i].Material;
                }
                //mejoras en el predio
                conta = 0; conti = 0;
                for (int i = 0; i < pdb.Fi.LstMp.Count; i++)
                {
                    if (pdb.Fi.LstMp[i].Vigencia == "a")
                    {
                        dgvInfAgrop.Rows.Add(1);
                        dgvInfAgrop.Rows[conta].Cells[0].Value = pdb.Fi.LstMp[i].Desc;
                        dgvInfAgrop.Rows[conta].Cells[1].Value = pdb.Fi.LstMp[i].Tip_mat;
                        dgvInfAgrop.Rows[conta].Cells[2].Value = pdb.Fi.LstMp[i].U_med;
                        dgvInfAgrop.Rows[conta].Cells[3].Value = pdb.Fi.LstMp[i].Area;
                        dgvInfAgrop.Rows[conta].Cells[4].Value = pdb.Fi.LstMp[i].Estado;
                        conta++;
                    }
                    if (pdb.Fi.LstMp[i].Vigencia == "i")
                    {
                        dgvMejIns.Rows.Add(1);
                        dgvMejIns.Rows[conti].Cells[0].Value = pdb.Fi.LstMp[i].Desc;
                        dgvMejIns.Rows[conti].Cells[1].Value = pdb.Fi.LstMp[i].Tip_mat;
                        dgvMejIns.Rows[conti].Cells[2].Value = pdb.Fi.LstMp[i].U_med;
                        dgvMejIns.Rows[conti].Cells[3].Value = pdb.Fi.LstMp[i].Area;
                        dgvMejIns.Rows[conti].Cells[4].Value = pdb.Fi.LstMp[i].Estado;
                        conti++;
                    }
                }
                //metodos de linderacion
                for (int i = 0; i < pdb.Fi.MetLin.Count; i++)
                {
                    if (pdb.Fi.MetLin[i].Desc == "l")
                        txtLp.Text = pdb.Fi.MetLin[i].Info;
                    if (pdb.Fi.MetLin[i].Desc == "f")
                        txtFoto.Text = pdb.Fi.MetLin[i].Info;
                    if (pdb.Fi.MetLin[i].Desc == "g")
                        txtGps.Text = pdb.Fi.MetLin[i].Info;
                }
                //referencias cartograficas
                for (int i = 0; i < pdb.Fi.RefCar.Count; i++)
                {
                    if (pdb.Fi.RefCar[i].Desc == "t")
                        txtTop.Text = pdb.Fi.RefCar[i].Info;
                    if (pdb.Fi.RefCar[i].Desc == "s")
                        txtSat.Text = pdb.Fi.RefCar[i].Info;
                    if (pdb.Fi.RefCar[i].Desc == "a")
                        txtAer.Text = pdb.Fi.RefCar[i].Info;
                    if (pdb.Fi.RefCar[i].Desc == "o")
                        txtOtro.Text = pdb.Fi.RefCar[i].Info;
                }
                //relieve
                for (int i = 0; i < pdb.Fi.LstRel.Count; i++)
                {
                    dgvRelieve.Rows.Add(1);
                    dgvRelieve.Rows[i].Cells[0].Value = pdb.Fi.LstRel[i].Desc;
                    dgvRelieve.Rows[i].Cells[1].Value = pdb.Fi.LstRel[i].Porcent;
                }
                //responsable
                txtObs.Text = pdb.Fi.Resp.Obs;
                txtTc.Text = pdb.Fi.Resp.Tcat;
                dtpTc.Value = DateTime.Parse(pdb.Fi.Resp.Fcat);
                txtTj.Text = pdb.Fi.Resp.Tjur;
                dtpTj.Value = DateTime.Parse(pdb.Fi.Resp.Fjur);
                txtPro.Text = pdb.Fi.Resp.Prop;
                dtpPro.Value = DateTime.Parse(pdb.Fi.Resp.Fprop);
                txtTes.Text = pdb.Fi.Resp.Test;
                dtpTes.Value = DateTime.Parse(pdb.Fi.Resp.Ftest);
                txtEmp.Text = pdb.Fi.Resp.Semp;
                dtpEmp.Value = DateTime.Parse(pdb.Fi.Resp.Femp);
                txtGtc.Text = pdb.Fi.Resp.Cgtc;
                dtpGtc.Value = DateTime.Parse(pdb.Fi.Resp.Fgtc);
                //semovientes
                for (int i = 0; i < pdb.Fi.LstSem.Count; i++)
                {
                    dgvSemo.Rows.Add(1);
                    dgvSemo.Rows[i].Cells[0].Value = pdb.Fi.LstSem[i].Especie;
                    dgvSemo.Rows[i].Cells[1].Value = pdb.Fi.LstSem[i].Raza;
                    dgvSemo.Rows[i].Cells[2].Value = pdb.Fi.LstSem[i].Edad;
                    dgvSemo.Rows[i].Cells[3].Value = pdb.Fi.LstSem[i].Sangre;
                    dgvSemo.Rows[i].Cells[4].Value = pdb.Fi.LstSem[i].Num;
                }
                //servicios en el predio
                cmbAgua.Text = pdb.Fi.Sp.Agua;
                txtMedA.Text = pdb.Fi.Sp.Num_med_agua;
                nudNroA.Value = pdb.Fi.Sp.Num_agua;
                cmbElec.Text = pdb.Fi.Sp.Elect;
                txtMedE.Text = pdb.Fi.Sp.Num_med_elect;
                nudNroE.Value = pdb.Fi.Sp.Num_elect;
                txtTelPrin.Text = pdb.Fi.Sp.Num_tel;
                nudNroT.Value = pdb.Fi.Sp.Num_lin_tel;
                cmbAlcan.Text = pdb.Fi.Sp.Alcant;
                cmbRiesgo.Text = pdb.Fi.Sp.Riego;
                cmbMetRiego.Text = pdb.Fi.Sp.Met_riego;
                //servicios en la via
                cmbTipVia.Text = pdb.Fi.Sv.Tipo_via;
                cmbMatVia.Text = pdb.Fi.Sv.Mat_via;
                cmbAluPub.Text = pdb.Fi.Sv.Alumb;
                cmbEstVia.Text = pdb.Fi.Sv.Estado_via;
                cmbPobCer.Text = pdb.Fi.Sv.Pobla_cerca;
                cmbTraPub.Text = pdb.Fi.Sv.Transport;
                cmbAcera.Text = pdb.Fi.Sv.Acera;
                cmbRecBas.Text = pdb.Fi.Sv.Basura;
                //uso del suelo
                for (int i = 0; i < pdb.Fi.LstUs.Count; i++)
                {
                    dgvUsoSuelo.Rows.Add(1);
                    dgvUsoSuelo.Rows[i].Cells[0].Value = pdb.Fi.LstUs[i].Uso;
                    dgvUsoSuelo.Rows[i].Cells[1].Value = pdb.Fi.LstUs[i].Ext;
                    dgvUsoSuelo.Rows[i].Cells[2].Value = pdb.Fi.LstUs[i].Porc;
                }
            }
            else
            {
                MessageBox.Show("Predio no registrado", "Advertencia");
                Application.Exit();
            }
        }
        //actualizar
        private void actualizar()
        {
            try
            {
                string sql = "";
                PredioDB predio = new PredioDB();

                //propietario
                predio.Pro.Ci_nat = txtCiNat.Text;
                predio.Pro.Nom_nat = txtANNat.Text;
                predio.Pro.Fnat = dtpFnNat.Value.ToString("yyyy/MM/dd");
                predio.Pro.Ci_con = txtCiCo.Text;
                predio.Pro.Nom_con = txtNACo.Text;
                predio.Pro.Fcon = dtpFnCo.Value.ToString("yyyy/MM/dd");
                predio.Pro.Ruc_jur = txtRuJu.Text;
                predio.Pro.Nom_jur = txtNoJu.Text;
                predio.Pro.Am_jur = txtAMJu.Text;
                predio.Pro.Fjur = dtpFeJu.Value.ToString("yyyy/MM/dd");
                predio.Pro.Dni_rl = txtRuRl.Text;
                predio.Pro.Nom_rl = txtNoRl.Text;
                predio.Pro.Direccion = txtDir.Text;
                predio.Pro.Telefono = txtTel.Text;
                predio.Pro.Email = txtEmail.Text;
                sql = "Update propietarios"
                    + " set pr_ci_nat='" + predio.Pro.Ci_nat
                    + "' ,pr_nom_nat='" + predio.Pro.Nom_nat
                    + "' ,pr_fnac_nat='" + predio.Pro.Fnat
                    + "' ,pr_ci_con='" + predio.Pro.Ci_con
                    + "' ,pr_nom_con='" + predio.Pro.Nom_con
                    + "' ,pr_fnac_con='" + predio.Pro.Fcon
                    + "' ,pr_ruc_ju='" + predio.Pro.Ruc_jur
                    + "' ,pr_nom_ju='" + predio.Pro.Nom_jur
                    + "' ,pr_acminis_ju='" + predio.Pro.Am_jur
                    + "' ,pr_fnac_ju ='" + predio.Pro.Fjur
                    + "' ,pr_dni_rl ='" + predio.Pro.Dni_rl
                    + "' ,pr_nom_rl='" + predio.Pro.Nom_rl
                    + "' ,pr_dir ='" + predio.Pro.Direccion
                    + "' ,pr_tel='" + predio.Pro.Telefono
                    + "' ,pr_email='" + predio.Pro.Email
                    + "' Where pr_id=" + pdb.Fi.Propietario.Id;
                predio.guardarActualizar(sql);

                //caracteristicas fisicas
                predio.Cf.Forma = cmbForma.Text;
                predio.Cf.Riesgo = cmbRiesgo.Text;
                predio.Cf.Erosion = cmbErosion.Text;
                predio.Cf.Clas_suelo = cmbClasSuelo.Text;
                predio.Cf.Cob_natural = cmbCobNat.Text;
                predio.Cf.Ecosis_rele = cmbEcosRel.Text;
                predio.Cf.Valor_cult = cmbValCul.Text;
                predio.Cf.Area = (double)nudAreaTot.Value;
                predio.Cf.Costo_base = (double)nudPrecioBase.Value;
                sql = "Update carac_fisicas"
                    + " set cf_forma='" + predio.Cf.Forma
                    + "' ,cf_riesgo='" + predio.Cf.Riesgo
                    + "' ,cf_erosion='" + predio.Cf.Erosion
                    + "' ,cf_clas_suelo='" + predio.Cf.Clas_suelo
                    + "' ,cf_cob_nat='" + predio.Cf.Cob_natural
                    + "' ,cf_ecos_rele='" + predio.Cf.Ecosis_rele
                    + "' ,cf_valor_cult='" + predio.Cf.Valor_cult
                    + "' ,cf_area_tot=" + predio.Cf.Area
                    + " ,cf_costo_base=" + predio.Cf.Costo_base
                    + " Where fi_id=" + pdb.Fi.Id;
                predio.guardarActualizar(sql);

                //clases agrologicas
                //eliminacion datos anteriores
                sql = "Delete from clases_agrol where fi_id=" + pdb.Fi.Id;
                predio.guardarActualizar(sql);
                //ingreso nuevos datos
                predio.Ca.Ficha = pdb.Fi;
                DataGridViewRowCollection dgvr = dgvClasAgro.Rows;
                foreach (DataGridViewRow item in dgvr)
                {
                    if (item.Cells[0].Value != null && item.Cells[1].Value != null && item.Cells[1].Value != null)
                    {
                        DataGridViewComboBoxCell combo = item.Cells[0] as DataGridViewComboBoxCell;
                        predio.Ca.Clase = ((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString();
                        predio.Ca.Area = double.Parse(item.Cells[1].Value.ToString());
                        predio.Ca.Porcion = double.Parse(item.Cells[2].Value.ToString());
                        sql = predio.cadena(predio.Ca);
                        predio.guardarActualizar(sql);
                    }
                }

                //cobertura vegetal
                //eliminacion datos anteriores
                sql = "Delete from cobert_vegetal where fi_id=" + pdb.Fi.Id;
                predio.guardarActualizar(sql);
                //ingreso de datos
                //tabla individual
                predio.Cv.Ficha = pdb.Fi;
                dgvr = dgvCobVegI.Rows;
                foreach (DataGridViewRow item in dgvr)
                {
                    if (item.Cells[0].Value != null && item.Cells[1].Value != null && item.Cells[2].Value != null && item.Cells[3].Value != null)
                    {
                        predio.Cv.Desc = item.Cells[0].Value.ToString();
                        predio.Cv.Porc = double.Parse(item.Cells[1].Value.ToString());
                        predio.Cv.Edad = item.Cells[2].Value.ToString();
                        predio.Cv.Est = item.Cells[3].Value.ToString();
                        sql = predio.cadena(predio.Cv);
                        predio.guardarActualizar(sql);
                    }
                }
                //tabla asociacion
                dgvr = dgvCobVegA.Rows;
                predio.Cv.Indicador = "a";
                foreach (DataGridViewRow item in dgvr)
                {
                    if (item.Cells[0].Value != null && item.Cells[1].Value != null && item.Cells[2].Value != null && item.Cells[3].Value != null)
                    {
                        predio.Cv.Desc = item.Cells[0].Value.ToString();
                        predio.Cv.Porc = double.Parse(item.Cells[1].Value.ToString());
                        predio.Cv.Edad = item.Cells[2].Value.ToString();
                        predio.Cv.Est = item.Cells[3].Value.ToString();
                        sql = predio.cadena(predio.Cv);
                        predio.guardarActualizar(sql);
                    }
                }

                //materiales del edificio
                dgvr = dgvMatEdif.Rows;
                //eliminacion datos anteriores
                sql = "Delete from mat_edificio where fi_id=" + pdb.Fi.Id;
                predio.guardarActualizar(sql);
                //ingreso de datos
                foreach (DataGridViewRow item in dgvr)
                {
                    PredioDB p = new PredioDB();
                    p.Me.Ficha = pdb.Fi;
                    if (item.Cells[0].Value != null && item.Cells[1].Value != null && item.Cells[2].Value != null)
                    {
                        DataGridViewComboBoxCell combo = item.Cells[0] as DataGridViewComboBoxCell;
                        p.Me.Nro_bloque = int.Parse(((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString());
                        combo = item.Cells[1] as DataGridViewComboBoxCell;
                        p.Me.Tipo = ((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString();
                        combo = item.Cells[2] as DataGridViewComboBoxCell;
                        p.Me.Material = ((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString();
                        predio.Me.Lst.Add(p.Me);
                        sql = predio.cadena(p.Me);
                        predio.guardarActualizar(sql);
                    }
                }

                //descripcion de las contrucciones
                //eliminacion datos anteriores
                sql = "Delete from desc_construcciones where fi_id=" + pdb.Fi.Id;
                pdb.guardarActualizar(sql);
                //ingreso de datos
                dgvr = dgvDescCons.Rows;
                predio.Dc.Ficha = pdb.Fi;
                foreach (DataGridViewRow item in dgvr)
                {
                    if (item.Cells[0].Value != null && item.Cells[1].Value != null && item.Cells[2].Value != null && item.Cells[3].Value != null &&
                        item.Cells[4].Value != null && item.Cells[5].Value != null && item.Cells[7].Value != null && item.Cells[8].Value != null &&
                        item.Cells[9].Value != null
                        )
                    {
                        DataGridViewComboBoxCell combo = item.Cells[0] as DataGridViewComboBoxCell;
                        predio.Dc.Nrob = int.Parse(((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString());
                        predio.Dc.Nrops = int.Parse(item.Cells[1].Value.ToString());
                        combo = item.Cells[2] as DataGridViewComboBoxCell;
                        predio.Dc.Cond_fis = ((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString();
                        combo = item.Cells[3] as DataGridViewComboBoxCell;
                        predio.Dc.Val_cul = ((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString();
                        predio.Dc.Anio = item.Cells[4].Value.ToString();
                        predio.Dc.Area = double.Parse(item.Cells[5].Value.ToString());
                        combo = item.Cells[6] as DataGridViewComboBoxCell;
                        predio.Dc.Elect = ((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString();
                        combo = item.Cells[7] as DataGridViewComboBoxCell;
                        predio.Dc.Sanit = ((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString();
                        combo = item.Cells[8] as DataGridViewComboBoxCell;
                        predio.Dc.Espec = ((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString();
                        combo = item.Cells[9] as DataGridViewComboBoxCell;
                        predio.Dc.Nro_banio = ((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString();
                        predio.Dc.PrecioBase = valorBaseBloque(predio.Dc.Nrob, predio);
                        sql = predio.cadena(predio.Dc);
                        predio.guardarActualizar(sql);
                    }
                }

                //informacion legal
                predio.Inf.Form_tenen = cmbFormTen.Text;
                predio.Inf.Sup_desc = cmbSupDesc.Text;
                predio.Inf.Sup_area = (double)nudSupArea.Value;
                predio.Inf.Sup_unidad = cmbUnidad.Text;
                predio.Inf.Dprf = dtpPrF.Value.ToString("yyyy/MM/dd");
                predio.Inf.Dpfc = dtpPFc.Value.ToString("yyyy/MM/dd");
                predio.Inf.Dp_auto = txtAut.Text;
                predio.Inf.Dp_fi = dtpPFi.Value.ToString("yyyy/MM/dd");
                predio.Inf.Dp_lugar = txtLugIns.Text;
                predio.Inf.Dom = cmbDominio.Text;
                predio.Inf.Tip_tenen = cmbTipTenen.Text;
                predio.Inf.Desc_tenen = cmbDescTenen.Text;
                predio.Inf.Prop_ant = txtPropAnt.Text;
                sql = "Update info_legal"
                    + " set il_form_tenen='" + predio.Inf.Form_tenen
                    + "' ,il_sup_desc ='" + predio.Inf.Sup_desc
                    + "' ,il_sup_area ='" + predio.Inf.Sup_area
                    + "' ,il_sup_unid ='" + predio.Inf.Sup_unidad
                    + "' ,il_dp_fec ='" + predio.Inf.Dprf
                    + "' ,il_dp_fecc='" + predio.Inf.Dpfc
                    + "' ,il_dp_aut='" + predio.Inf.Dp_auto
                    + "' ,il_dp_feci ='" + predio.Inf.Dp_fi
                    + "' ,il_dp_lugar ='" + predio.Inf.Dp_lugar
                    + "' ,il_dominio  ='" + predio.Inf.Dom
                    + "' ,il_tip_tenen ='" + predio.Inf.Tip_tenen
                    + "' ,il_desc_tenen ='" + predio.Inf.Desc_tenen
                    + "' ,il_prop_ant ='" + predio.Inf.Prop_ant
                    + "' Where fi_id=" + pdb.Fi.Id;
                predio.guardarActualizar(sql);

                //linderos
                lind_ref(new string[] { "n", "s", "e", "o" }, 1, predio);

                // localizacion
                predio.Lo.NomPred = txtNomPred.Text;
                predio.Lo.CodSect = txtCodRec.Text;
                predio.Lo.NomSect = txtNomRec.Text;
                predio.Lo.CodVia = txtCodVia.Text;
                predio.Lo.NomVia = txtNomVia.Text;
                predio.Lo.Cx = double.Parse(txtCoorX.Text);
                predio.Lo.Cy = double.Parse(txtCoorY.Text);
                predio.Lo.Manzana = cmbLocMan.Text;
                sql = "Update localizacion"
                    + " set lo_nombre_predio='" + predio.Lo.NomPred
                    + "' ,lo_cod_sect ='" + predio.Lo.CodSect
                    + "' ,lo_nom_sect ='" + predio.Lo.NomSect
                    + "' ,lo_cod_via ='" + predio.Lo.CodVia
                    + "' ,lo_nom_via ='" + predio.Lo.NomVia
                    + "' ,lo_coor_x ='" + predio.Lo.Cx
                    + "' ,lo_coor_y ='" + predio.Lo.Cy
                    + "' ,lo_loc_manz ='" + predio.Lo.Manzana
                    + "' Where fi_id=" + pdb.Fi.Id;
                predio.guardarActualizar(sql);

                //maquinaria y equipos
                dgvr = dgvMaq.Rows;
                predio.Maq.Ficha = pdb.Fi;
                //eliminacion datos anteriores
                sql = "Delete from maq_equipos where fi_id=" + pdb.Fi.Id;
                predio.guardarActualizar(sql);
                //ingreso de datos
                foreach (DataGridViewRow item in dgvr)
                {
                    if (item.Cells[0].Value != null && item.Cells[1].Value != null && item.Cells[2].Value != null && item.Cells[3].Value != null &&
                        item.Cells[4].Value != null
                        )
                    {
                        predio.Maq.Den = item.Cells[0].Value.ToString();
                        predio.Maq.Marca = item.Cells[1].Value.ToString();
                        predio.Maq.Anio = item.Cells[2].Value.ToString();
                        predio.Maq.Estado = item.Cells[3].Value.ToString();
                        predio.Maq.Num = item.Cells[4].Value.ToString();
                        sql = predio.cadena(predio.Maq);
                        predio.guardarActualizar(sql);
                    }
                }

                //mejoras en el predio
                predio.Mp.Ficha = pdb.Fi;
                //eliminacion datos anteriores
                sql = "Delete from mejoras_predio where fi_id=" + pdb.Fi.Id;
                predio.guardarActualizar(sql);
                //ingreso de datos
                infraestuctura(dgvInfAgrop, "a", predio);
                infraestuctura(dgvMejIns, "i", predio);

                //metodo linderacion
                lind_ref(new string[] { "l", "f", "g" }, 2, predio);

                //referencias cartograficas
                lind_ref(new string[] { "t", "s", "a", "o" }, 3, predio);

                //relieve
                dgvr = dgvRelieve.Rows;
                predio.Re.Ficha = pdb.Fi;
                //eliminacion datos anteriores
                sql = "Delete from relieve where fi_id=" + pdb.Fi.Id;
                predio.guardarActualizar(sql);
                //ingreso de datos
                foreach (DataGridViewRow item in dgvr)
                {
                    if (item.Cells[0].Value != null && item.Cells[1].Value != null)
                    {
                        DataGridViewComboBoxCell combo = item.Cells[0] as DataGridViewComboBoxCell;
                        predio.Re.Desc = ((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString();
                        predio.Re.Porcent = double.Parse(item.Cells[1].Value.ToString());
                        sql = predio.cadena(predio.Re);
                        predio.guardarActualizar(sql);
                    }
                }

                //responsables
                predio.Res.Obs = txtObs.Text;
                predio.Res.Tcat = txtTc.Text;
                predio.Res.Fcat = dtpTc.Value.ToString("yyyy/MM/dd");
                predio.Res.Tjur = txtTj.Text;
                predio.Res.Fjur = dtpTj.Value.ToString("yyyy/MM/dd");
                predio.Res.Prop = txtPro.Text;
                predio.Res.Fprop = dtpPro.Value.ToString("yyyy/MM/dd");
                predio.Res.Test = txtTes.Text;
                predio.Res.Ftest = dtpTes.Value.ToString("yyyy/MM/dd");
                predio.Res.Semp = txtEmp.Text;
                predio.Res.Femp = dtpEmp.Value.ToString("yyyy/MM/dd");
                predio.Res.Cgtc = txtGtc.Text;
                predio.Res.Fgtc = dtpGtc.Value.ToString("yyyy/MM/dd");
                sql = "Update responsables"
                    + " set re_obser='" + predio.Res.Obs
                    + "' ,re_tcat ='" + predio.Res.Tcat
                    + "' ,re_fec_cat ='" + predio.Res.Fcat
                    + "' ,re_tjur ='" + predio.Res.Tjur
                    + "' ,re_fec_jur ='" + predio.Res.Fjur
                    + "' ,re_prop ='" + predio.Res.Prop
                    + "' ,re_fecha_prop ='" + predio.Res.Fprop
                    + "' ,re_test ='" + predio.Res.Test
                    + "' ,re_fecha_test ='" + predio.Res.Ftest
                    + "' ,re_semp ='" + predio.Res.Semp
                    + "' ,re_fec_emp ='" + predio.Res.Femp
                    + "' ,re_cgtc ='" + predio.Res.Cgtc
                    + "' ,re_fec_gtc ='" + predio.Res.Fgtc
                    + "' Where fi_id=" + pdb.Fi.Id;
                predio.guardarActualizar(sql);

                //semovientes
                dgvr = dgvSemo.Rows;
                predio.Se.Ficha = pdb.Fi;
                //eliminacion datos anteriores
                sql = "Delete from semovientes where fi_id=" + pdb.Fi.Id;
                predio.guardarActualizar(sql);
                //ingreso de datos
                foreach (DataGridViewRow item in dgvr)
                {
                    if (item.Cells[0].Value != null && item.Cells[1].Value != null && item.Cells[2].Value != null && item.Cells[3].Value != null &&
                        item.Cells[4].Value != null)
                    {
                        predio.Se.Especie = item.Cells[0].Value.ToString();
                        predio.Se.Raza = item.Cells[1].Value.ToString();
                        predio.Se.Edad = item.Cells[2].Value.ToString();
                        predio.Se.Sangre = item.Cells[3].Value.ToString();
                        predio.Se.Num = item.Cells[4].Value.ToString();
                        sql = predio.cadena(predio.Se);
                        predio.guardarActualizar(sql);
                    }
                }

                //servicios predio
                predio.Sp.Agua = cmbAgua.Text;
                predio.Sp.Num_med_agua = txtMedA.Text;
                predio.Sp.Num_agua = (int)nudNroA.Value;
                predio.Sp.Elect = cmbElec.Text;
                predio.Sp.Num_med_elect = txtMedE.Text;
                predio.Sp.Num_elect = (int)nudNroE.Value;
                predio.Sp.Num_tel = txtTelPrin.Text;
                predio.Sp.Num_lin_tel = (int)nudNroT.Value;
                predio.Sp.Alcant = cmbAlcan.Text;
                predio.Sp.Riego = cmbRiesgo.Text;
                predio.Sp.Met_riego = cmbMetRiego.Text;
                sql = "Update servicios_predio"
                    + " set sp_agua ='" + predio.Sp.Agua
                    + "' ,sp_med_prin_agua ='" + predio.Sp.Num_med_agua
                    + "' ,sp_medid_agua ='" + predio.Sp.Num_agua
                    + "' ,sp_elect ='" + predio.Sp.Elect
                    + "' ,sp_med_prin_elec ='" + predio.Sp.Num_med_elect
                    + "' ,sp_medid_elec ='" + predio.Sp.Num_elect
                    + "' ,sp_num_telf_prin ='" + predio.Sp.Num_tel
                    + "' ,sp_num_lineas_tel ='" + predio.Sp.Num_lin_tel
                    + "' ,sp_alcant ='" + predio.Sp.Alcant
                    + "' ,sp_riego ='" + predio.Sp.Riego
                    + "' ,sp_met_riego ='" + predio.Sp.Met_riego
                    + "' Where fi_id=" + pdb.Fi.Id;
                predio.guardarActualizar(sql);

                //servicios en la via
                predio.Sv.Tipo_via = cmbTipVia.Text;
                predio.Sv.Mat_via = cmbMatVia.Text;
                predio.Sv.Alumb = cmbAluPub.Text;
                predio.Sv.Estado_via = cmbEstVia.Text;
                predio.Sv.Pobla_cerca = cmbPobCer.Text;
                predio.Sv.Transport = cmbTraPub.Text;
                predio.Sv.Acera = cmbAcera.Text;
                predio.Sv.Basura = cmbRecBas.Text;
                sql = "Update servicios_via"
                    + " set sv_tipo_via ='" + predio.Sv.Tipo_via
                    + "' ,sv_mat_via ='" + predio.Sv.Mat_via
                    + "' ,sv_alumbrado ='" + predio.Sv.Alumb
                    + "' ,sv_est_via ='" + predio.Sv.Estado_via
                    + "' ,sv_pobla_cerca ='" + predio.Sv.Pobla_cerca
                    + "' ,sv_transp_public ='" + predio.Sv.Transport
                    + "' ,sv_acera ='" + predio.Sv.Acera
                    + "' ,sv_basura ='" + predio.Sv.Basura
                    + "' Where fi_id=" + pdb.Fi.Id;
                predio.guardarActualizar(sql);

                //uso del suelo
                dgvr = dgvUsoSuelo.Rows;
                predio.Us.Ficha = pdb.Fi;
                //eliminacion datos anteriores
                sql = "Delete from uso_suelos where fi_id=" + pdb.Fi.Id;
                predio.guardarActualizar(sql);
                //ingreso de datos
                foreach (DataGridViewRow item in dgvr)
                {
                    if (item.Cells[0].Value != null && item.Cells[1].Value != null && item.Cells[2].Value != null)
                    {
                        DataGridViewComboBoxCell combo = item.Cells[0] as DataGridViewComboBoxCell;
                        predio.Us.Uso = ((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString();
                        predio.Us.Ext = double.Parse(item.Cells[1].Value.ToString());
                        predio.Us.Porc = double.Parse(item.Cells[2].Value.ToString());
                        sql = predio.cadena(predio.Us);
                        predio.guardarActualizar(sql);
                    }
                }
                udb.User = Util.Util.leerUsuarioXml();
                udb.guardarActualizar("INSERT INTO bitacora (`id_user`, `accion`) VALUES ('" + udb.User.Id + "','Modifico los datos del predio con codigo catastral: " + pdb.Fi.Cod_catastro + "')");
                MessageBox.Show("Datos actualizados", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        private void lind_ref(string[] elem, int param, PredioDB predio)
        {
            try
            {
                predio.Lin.Ficha = pdb.Fi;
                if (param == 1)
                {
                    //eliminacion datos anteriores
                    string sql = "Delete from linderos where fi_id=" + pdb.Fi.Id;
                    predio.guardarActualizar(sql);
                    //ingreso de datos
                    foreach (string item in elem)
                    {
                        if (item == "n" && txtNort.Text != "")
                        {
                            predio.Lin.Desc = item;
                            predio.Lin.Info = txtNort.Text;
                            predio.guardarActualizar(predio.cadena(predio.Lin, param));
                        }
                        if (item == "s" && txtSur.Text != "")
                        {
                            predio.Lin.Desc = item;
                            predio.Lin.Info = txtSur.Text;
                            predio.guardarActualizar(predio.cadena(predio.Lin, param));
                        }
                        if (item == "e" && txtEst.Text != "")
                        {
                            predio.Lin.Desc = item;
                            predio.Lin.Info = txtEst.Text;
                            predio.guardarActualizar(predio.cadena(predio.Lin, param));
                        }
                        if (item == "o" && txtOest.Text != "")
                        {
                            predio.Lin.Desc = item;
                            predio.Lin.Info = txtOest.Text;
                            predio.guardarActualizar(predio.cadena(predio.Lin, param));
                        }
                        //pdb.Lin.Lst.Add(pdb.Lin);
                    }
                }
                else
                {
                    if (param == 2)
                    {
                        //eliminacion datos anteriores
                        string sql = "Delete from met_linderacion where fi_id=" + pdb.Fi.Id;
                        predio.guardarActualizar(sql);
                        //ingreso de datos
                        foreach (string item in elem)
                        {
                            if (item == "l" && txtLp.Text != "")
                            {
                                predio.Lin.Desc = item;
                                predio.Lin.Info = txtLp.Text;
                                predio.guardarActualizar(predio.cadena(predio.Lin, param));
                            }
                            if (item == "f" && txtFoto.Text != "")
                            {
                                predio.Lin.Desc = item;
                                predio.Lin.Info = txtFoto.Text;
                                predio.guardarActualizar(predio.cadena(predio.Lin, param));
                            }
                            if (item == "g" && txtGps.Text != "")
                            {
                                predio.Lin.Desc = item;
                                predio.Lin.Info = txtGps.Text;
                                predio.guardarActualizar(predio.cadena(predio.Lin, param));
                            }
                        }
                    }
                    else
                    {
                        //eliminacion datos anteriores
                        string sql = "Delete from ref_cartog where fi_id=" + pdb.Fi.Id;
                        predio.guardarActualizar(sql);
                        //ingreso de datos
                        foreach (string item in elem)
                        {
                            if (item == "t" && txtTop.Text != "")
                            {
                                predio.Lin.Desc = item;
                                predio.Lin.Info = txtTop.Text;
                                predio.guardarActualizar(predio.cadena(predio.Lin, param));
                            }
                            if (item == "s" && txtSat.Text != "")
                            {
                                predio.Lin.Desc = item;
                                predio.Lin.Info = txtSat.Text;
                                predio.guardarActualizar(predio.cadena(predio.Lin, param));
                            }
                            if (item == "a" && txtAer.Text != "")
                            {
                                predio.Lin.Desc = item;
                                predio.Lin.Info = txtAer.Text;
                                predio.guardarActualizar(predio.cadena(predio.Lin, param));
                            }
                            if (item == "o" && txtOtro.Text != "")
                            {
                                predio.Lin.Desc = item;
                                predio.Lin.Info = txtOtro.Text;
                                predio.guardarActualizar(predio.cadena(predio.Lin, param));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //infraestructura agropecuaria y mejoras e instalaciones
        private void infraestuctura(DataGridView dgv, string t, PredioDB predio)
        {
            DataGridViewRowCollection dgvr = dgv.Rows;
            foreach (DataGridViewRow item in dgvr)
            {
                if (item.Cells[0].Value != null && item.Cells[1].Value != null && item.Cells[2].Value != null && item.Cells[3].Value != null && item.Cells[4].Value != null)
                {
                    DataGridViewComboBoxCell combo = item.Cells[0] as DataGridViewComboBoxCell;
                    predio.Mp.Desc = combo.Value.ToString();
                    combo = item.Cells[1] as DataGridViewComboBoxCell;
                    predio.Mp.Tip_mat = combo.Value.ToString();
                    combo = item.Cells[2] as DataGridViewComboBoxCell;
                    predio.Mp.U_med = combo.Value.ToString();
                    predio.Mp.Area = double.Parse(item.Cells[3].Value.ToString());
                    combo = item.Cells[4] as DataGridViewComboBoxCell;
                    predio.Mp.Estado = combo.Value.ToString();
                    predio.Mp.Vigencia = t;
                    predio.guardarActualizar(predio.cadena(predio.Mp));
                }
            }
        }

        private double valorBaseBloque(int nb, PredioDB p)
        {
            string col = "", entrepiso = "", pared = "", cubierta = "";
            for (int i = 0; i < p.Me.Lst.Count; i++)
            {
                if (p.Me.Lst[i].Nro_bloque == nb && p.Me.Lst[i].Tipo == "Columnas")
                    col = p.Me.Lst[i].Material;
                if (p.Me.Lst[i].Nro_bloque == nb && p.Me.Lst[i].Tipo == "Entrepiso")
                    entrepiso = p.Me.Lst[i].Material;
                if (p.Me.Lst[i].Nro_bloque == nb && p.Me.Lst[i].Tipo == "Paredes")
                    pared = p.Me.Lst[i].Material;
                if (p.Me.Lst[i].Nro_bloque == nb && p.Me.Lst[i].Tipo == "Cubiertas")
                    cubierta = p.Me.Lst[i].Material;
            }
            string materiales = col + "-" + entrepiso + "-" + pared + "-" + cubierta;
            fdb.Vm = fdb.traerValorTipologia(materiales);
            return fdb.Vm.Precio;
        }

        private void dgvDescCons_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvMatEdif_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvMatEdif_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMatEdif.Columns[e.ColumnIndex].Name == "tipo")
            {
                DataGridViewComboBoxCell combo = dgvMatEdif.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
                string opc = combo.Value.ToString();
                if (opc == "Cocina" || opc == "Cerrajería")
                    cargarCmbFactor((DataGridViewComboBoxColumn)dgvMatEdif.Columns[2], "Tipo Acabado");
                else
                {
                    if (opc == "Elementos Decorativos")
                        cargarCmbFactor((DataGridViewComboBoxColumn)dgvMatEdif.Columns[2], "Elementos Decorativos");
                    else
                        cargarCmbFactor((DataGridViewComboBoxColumn)dgvMatEdif.Columns[2], "Material");
                }
            }
        }

        private void FrmConsultar_Load(object sender, EventArgs e)
        {
            cargarFactor();
            cargarDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            actualizar();
            Application.Exit();
        }
    }
}
