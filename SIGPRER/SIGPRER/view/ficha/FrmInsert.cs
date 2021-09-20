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
using SIGPRER.Util;
using System.Xml;

namespace SIGPRER.view.ficha
{
    public partial class FrmInsert : Form
    {
        public FrmInsert()
        {
            InitializeComponent();
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }

        private CodigoDB cdb = new CodigoDB();
        private FactorDB fdb = new FactorDB();
        private PredioDB pdb = new PredioDB();
        private UserDB udb = new UserDB();

        int id = 0;
        string catastro = "";
        double x = 0;
        double y = 0;
        double area = 0;

        private void inicio()
        {
            cargarProvincias();
            cargarFactor();
            cmbSupDesc.SelectedIndex = 0;
            cmbUnidad.SelectedIndex = 0;
            cmbDescTenen.SelectedIndex = 0;
        }

        private void cargarProvincias()
        {
            cdb.Cod.Lst = cdb.readDBlist("Select * from provincia", 0);
            if (cdb.Cod.Lst != null)
            {
                cboProv.DisplayMember = "nombre";
                cboProv.ValueMember = "cod";
                cboProv.DataSource = cdb.Cod.Lst;
            }
        }

        private void cargarDivision(string cod, int div_poli, ComboBox cbo)
        {
            try
            {
                if (div_poli == 1)
                    cdb.Cod.Lst = cdb.readDBlist("Select * from canton where cod_prov='" + cod + "'", div_poli);
                else
                    cdb.Cod.Lst = cdb.readDBlist("Select * from parroquia where cod_cant='" + cod + "'", div_poli);
                cbo.DisplayMember = "nombre";
                cbo.ValueMember = "cod";
                cbo.DataSource = cdb.Cod.Lst;
            }
            catch (Exception)
            { 
            }
        }
        private void cargarTexto(int divi_pol)
        {
            //divi_pol: 0 =prov, 1=cant, 2 =parr
            if (divi_pol == 0)
                cboProv.SelectedValue = txtCprov.Text;
            if (divi_pol == 1)
                cboCant.SelectedValue = txtCprov.Text + txtCcant.Text;
            if (divi_pol == 2)
                cboParr.SelectedValue = txtCprov.Text + txtCcant.Text + txtCparr.Text;
        }

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

        private int obtenerNroFila(DataGridView dgv)
        {
            return dgv.CurrentRow.Index;
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

        public void verificacion()
        {
            if 
            (
                txtCiNat.Text != "" || txtCiCo.Text!="" || txtRuJu.Text!="" || txtRuRl.Text!=""||
                txtANNat.Text != "" || txtNACo.Text != "" || txtNoJu.Text != "" || txtNoRl.Text != ""
            )
            {
                guardar();
            }
            else
            {
                MessageBox.Show("Datos necesarios acerca del propietario en blanco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void guardar()
        {
            try
            {
                string sql = "";
                int rta = 0;
                pdb.Pro = pdb.obtenerProp("select * from propietarios where "
                                            + "pr_ci_nat='" + txtCiNat.Text
                                            + "' or pr_nom_nat='" + txtANNat.Text
                                            + "' or pr_ruc_ju='" + txtRuJu.Text
                                            + "' or pr_dni_rl='" + txtRuRl.Text
                                            + "'");
                if (pdb.Pro.Ci_nat == null && pdb.Pro.Nom_nat==null)
                {
                    //datos propietario
                    pdb.Pro.Ci_nat = txtCiNat.Text;
                    pdb.Pro.Nom_nat = txtANNat.Text;
                    pdb.Pro.Fnat = dtpFnNat.Value.ToString("yyyy/MM/dd");
                    pdb.Pro.Ci_con = txtCiCo.Text;
                    pdb.Pro.Nom_con = txtNACo.Text;
                    pdb.Pro.Fcon = dtpFnCo.Value.ToString("yyyy/MM/dd");
                    pdb.Pro.Ruc_jur = txtRuJu.Text;
                    pdb.Pro.Nom_jur = txtNoJu.Text;
                    pdb.Pro.Am_jur = txtAMJu.Text;
                    pdb.Pro.Fjur = dtpFeJu.Value.ToString("yyyy/MM/dd");
                    pdb.Pro.Dni_rl = txtRuRl.Text;
                    pdb.Pro.Nom_rl = txtNoRl.Text;
                    pdb.Pro.Direccion = txtDir.Text;
                    pdb.Pro.Telefono = txtTel.Text;
                    pdb.Pro.Email = txtEmail.Text;
                    sql = pdb.cadena(pdb.Pro);
                    rta = pdb.guardarActualizar(sql);
                    //ultimo propietario registrado
                    int idp = pdb.ultimoProp();
                    pdb.Pro = pdb.obtenerProp("Select * from propietarios where pr_id=" + idp);
                }
                if (pdb.Pro!=null)
                {
                    //datos ficha
                    pdb.Fi.Prov=txtCprov.Text;
                    pdb.Fi.Cant=txtCcant.Text;
                    pdb.Fi.Parr=txtCparr.Text;
                    pdb.Fi.Zona=txtCzona.Text;
                    pdb.Fi.Sect=txtCsect.Text;
                    pdb.Fi.Poli=txtCpoli.Text;
                    pdb.Fi.Cod_catastro = cboParr.SelectedValue + txtCzona.Text + txtCsect.Text + txtCpoli.Text;
                    pdb.Fi.Propietario = pdb.Pro;
                    sql = pdb.cadena(pdb.Fi);
                    pdb.guardarActualizar(sql);
                    //ultima ficha registrada
                    int idf=pdb.ultimaFich();
                    pdb.Fi=pdb.obtenerFicha("Select * from fichas where fi_id=" + idf);
                    //caracteristicas fisicas
                    pdb.Cf.Forma = cmbForma.Text;
                    pdb.Cf.Riesgo = cmbRiesgo.Text;
                    pdb.Cf.Erosion = cmbErosion.Text;
                    pdb.Cf.Clas_suelo = cmbClasSuelo.Text;
                    pdb.Cf.Cob_natural = cmbCobNat.Text;
                    pdb.Cf.Ecosis_rele = cmbEcosRel.Text;
                    pdb.Cf.Valor_cult = cmbValCul.Text;
                    pdb.Cf.Area = (double)nudAreaTot.Value;
                    pdb.Cf.Costo_base = (double)nudPrecioBase.Value;
                    pdb.Cf.Ficha = pdb.Fi;
                    sql = pdb.cadena(pdb.Cf);
                    pdb.guardarActualizar(sql);
                    //clases agrologicas
                    pdb.Ca.Ficha = pdb.Fi;
                    DataGridViewRowCollection dgvr = dgvClasAgro.Rows;
                    foreach (DataGridViewRow item in dgvr)
                    {
                        if (item.Cells[0].Value != null && item.Cells[1].Value != null && item.Cells[1].Value != null)
                        {
                            DataGridViewComboBoxCell combo = item.Cells[0] as DataGridViewComboBoxCell;
                            pdb.Ca.Clase = ((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString();
                            pdb.Ca.Area = double.Parse(item.Cells[1].Value.ToString());
                            pdb.Ca.Porcion = double.Parse(item.Cells[2].Value.ToString());
                            sql = pdb.cadena(pdb.Ca);
                            pdb.guardarActualizar(sql);
                        }
                    }
                    //cobertura vegetal
                    //tabla individual
                    pdb.Cv.Ficha = pdb.Fi;
                    dgvr = dgvCobVegI.Rows;
                    foreach (DataGridViewRow item in dgvr)
                    {
                        if (item.Cells[0].Value != null && item.Cells[1].Value != null && item.Cells[2].Value != null && item.Cells[3].Value != null)
                        {
                            pdb.Cv.Desc = item.Cells[0].Value.ToString();
                            pdb.Cv.Porc = double.Parse(item.Cells[1].Value.ToString());
                            pdb.Cv.Edad = item.Cells[2].Value.ToString();
                            pdb.Cv.Est = item.Cells[3].Value.ToString();
                            sql = pdb.cadena(pdb.Cv);
                            pdb.guardarActualizar(sql);
                        }
                    }
                    //tabla asociacion
                    dgvr = dgvCobVegA.Rows;
                    pdb.Cv.Indicador = "a";
                    foreach (DataGridViewRow item in dgvr)
                    {
                        //1
                        if (item.Cells[0].Value != null && item.Cells[1].Value != null && item.Cells[3].Value != null && item.Cells[5].Value != null)
                        {
                            pdb.Cv.Desc = item.Cells[0].Value.ToString();
                            pdb.Cv.Porc = double.Parse(item.Cells[1].Value.ToString());
                            pdb.Cv.Edad = item.Cells[3].Value.ToString();
                            pdb.Cv.Est = item.Cells[5].Value.ToString();
                            sql = pdb.cadena(pdb.Cv);
                            pdb.guardarActualizar(sql);
                        }
                        //2
                        if (item.Cells[0].Value != null && item.Cells[2].Value != null && item.Cells[4].Value != null && item.Cells[6].Value != null)
                        {
                            pdb.Cv.Desc = item.Cells[0].Value.ToString();
                            pdb.Cv.Porc = double.Parse(item.Cells[2].Value.ToString());
                            pdb.Cv.Edad = item.Cells[4].Value.ToString();
                            pdb.Cv.Est = item.Cells[6].Value.ToString();
                            sql = pdb.cadena(pdb.Cv);
                            pdb.guardarActualizar(sql);
                        }
                    }

                    //materiales del edificio
                    dgvr = dgvMatEdif.Rows;
                    pdb.Me.Ficha = pdb.Fi;
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
                            pdb.Me.Lst.Add(p.Me);
                            sql = pdb.cadena(p.Me);
                            pdb.guardarActualizar(sql);
                        }
                    }

                    //descripcion de las contrucciones
                    dgvr = dgvDescCons.Rows;
                    pdb.Dc.Ficha = pdb.Fi;
                    foreach (DataGridViewRow item in dgvr)
                    {
                        if (item.Cells[0].Value != null && item.Cells[1].Value != null && item.Cells[2].Value != null && item.Cells[3].Value != null &&
                            item.Cells[4].Value != null && item.Cells[5].Value != null && item.Cells[7].Value != null && item.Cells[8].Value != null &&
                            item.Cells[9].Value != null
                            )
                        {
                            DataGridViewComboBoxCell combo = item.Cells[0] as DataGridViewComboBoxCell;
                            pdb.Dc.Nrob = int.Parse(((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString());
                            pdb.Dc.Nrops = int.Parse(item.Cells[1].Value.ToString());
                            combo = item.Cells[2] as DataGridViewComboBoxCell;
                            pdb.Dc.Cond_fis = ((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString();
                            combo = item.Cells[3] as DataGridViewComboBoxCell;
                            pdb.Dc.Val_cul = ((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString();
                            pdb.Dc.Anio = item.Cells[4].Value.ToString();
                            pdb.Dc.Area = double.Parse(item.Cells[5].Value.ToString());
                            combo = item.Cells[6] as DataGridViewComboBoxCell;
                            pdb.Dc.Elect = ((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString();
                            combo = item.Cells[7] as DataGridViewComboBoxCell;
                            pdb.Dc.Sanit = ((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString();
                            combo = item.Cells[8] as DataGridViewComboBoxCell;
                            pdb.Dc.Espec = ((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString();
                            combo = item.Cells[9] as DataGridViewComboBoxCell;
                            pdb.Dc.Nro_banio = ((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString();
                            pdb.Dc.PrecioBase = valorBaseBloque(pdb.Dc.Nrob);
                            sql = pdb.cadena(pdb.Dc);
                            pdb.guardarActualizar(sql);
                        }
                    }
                    //informacion legal
                    pdb.Inf.Form_tenen = cmbFormTen.Text;
                    pdb.Inf.Sup_desc = cmbSupDesc.Text;
                    pdb.Inf.Sup_area = (double)nudSupArea.Value;
                    pdb.Inf.Sup_unidad = cmbUnidad.Text;
                    pdb.Inf.Dprf = dtpPrF.Value.ToString("yyyy/MM/dd");
                    pdb.Inf.Dpfc = dtpPFc.Value.ToString("yyyy/MM/dd");
                    pdb.Inf.Dp_auto = txtAut.Text;
                    pdb.Inf.Dp_fi = dtpPFi.Value.ToString("yyyy/MM/dd");
                    pdb.Inf.Dp_lugar = txtLugIns.Text;
                    pdb.Inf.Dom = cmbDominio.Text;
                    pdb.Inf.Tip_tenen = cmbTipTenen.Text;
                    pdb.Inf.Desc_tenen = cmbDescTenen.Text;
                    pdb.Inf.Prop_ant = txtPropAnt.Text;
                    pdb.Inf.Ficha = pdb.Fi;
                    sql = pdb.cadena(pdb.Inf);
                    pdb.guardarActualizar(sql);
                    //linderos
                    lind_ref(new string[]{"n","s","e","o"}, 1);
                    // localizacion
                    pdb.Lo.Ficha = pdb.Fi;
                    pdb.Lo.NomPred = txtNomPred.Text;
                    pdb.Lo.CodSect = txtCodRec.Text;
                    pdb.Lo.NomSect = txtNomRec.Text;
                    pdb.Lo.CodVia = txtCodVia.Text;
                    pdb.Lo.NomVia = txtNomVia.Text;
                    pdb.Lo.Cx = double.Parse(txtCoorX.Text);
                    pdb.Lo.Cy = double.Parse(txtCoorY.Text);
                    pdb.Lo.Manzana = cmbLocMan.Text;
                    sql = pdb.cadena(pdb.Lo);
                    pdb.guardarActualizar(sql);
                    //maquinaria y equipos
                    dgvr = dgvMaq.Rows;
                    pdb.Maq.Ficha = pdb.Fi;
                    foreach (DataGridViewRow item in dgvr)
                    {
                        if (item.Cells[0].Value != null && item.Cells[1].Value != null && item.Cells[2].Value != null && item.Cells[3].Value != null &&
                            item.Cells[4].Value != null
                            )
                        {
                            pdb.Maq.Den = item.Cells[0].Value.ToString();
                            pdb.Maq.Marca = item.Cells[1].Value.ToString();
                            pdb.Maq.Anio = item.Cells[2].Value.ToString();
                            pdb.Maq.Estado = item.Cells[3].Value.ToString();
                            pdb.Maq.Num = item.Cells[4].Value.ToString();
                            sql = pdb.cadena(pdb.Maq);
                            pdb.guardarActualizar(sql);
                        }
                    }
                    //mejoras en el predio
                    pdb.Mp.Ficha = pdb.Fi;
                    iami(dgvInfAgrop, "a");
                    iami(dgvMejIns, "i");
                    //metodo linderacion
                    lind_ref(new string[]{"l","f","g"},2);
                    //referencias cartograficas
                    lind_ref(new string[] { "t", "s", "a", "o"}, 3);
                    //relieve
                    dgvr = dgvRelieve.Rows;
                    pdb.Re.Ficha = pdb.Fi;
                    foreach (DataGridViewRow item in dgvr)
                    {
                        if (item.Cells[0].Value != null && item.Cells[1].Value != null && item.Cells[2].Value != null)
                        {
                            DataGridViewComboBoxCell combo = item.Cells[0] as DataGridViewComboBoxCell;
                            pdb.Re.Desc = ((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString();
                            pdb.Re.Porcent = double.Parse(item.Cells[2].Value.ToString());
                            sql = pdb.cadena(pdb.Re);
                            pdb.guardarActualizar(sql);
                        }
                    }
                    //responsables
                    pdb.Res.Ficha = pdb.Fi;
                    pdb.Res.Obs=txtObs.Text;
                    pdb.Res.Tcat=txtTc.Text;
                    pdb.Res.Fcat=dtpTc.Value.ToString("yyyy/MM/dd");
                    pdb.Res.Tjur=txtTj.Text;
                    pdb.Res.Fjur= dtpTj.Value.ToString("yyyy/MM/dd");
                    pdb.Res.Prop=txtPro.Text;
                    pdb.Res.Fprop=dtpPro.Value.ToString("yyyy/MM/dd");
                    pdb.Res.Test=txtTes.Text;
                    pdb.Res.Ftest=dtpTes.Value.ToString("yyyy/MM/dd");
                    pdb.Res.Semp=txtEmp.Text;
                    pdb.Res.Femp=dtpEmp.Value.ToString("yyyy/MM/dd");
                    pdb.Res.Cgtc=txtGtc.Text;
                    pdb.Res.Fgtc = dtpGtc.Value.ToString("yyyy/MM/dd");
                    sql = pdb.cadena(pdb.Res);
                    pdb.guardarActualizar(sql);
                    //semovientes
                    dgvr = dgvSemo.Rows;
                    pdb.Se.Ficha = pdb.Fi;
                    foreach (DataGridViewRow item in dgvr)
                    {
                        if (item.Cells[0].Value != null && item.Cells[1].Value != null && item.Cells[2].Value != null && item.Cells[3].Value != null &&
                            item.Cells[4].Value != null)
                        {
                            pdb.Se.Especie = item.Cells[0].Value.ToString();
                            pdb.Se.Raza = item.Cells[1].Value.ToString();
                            pdb.Se.Edad = item.Cells[2].Value.ToString();
                            pdb.Se.Sangre = item.Cells[3].Value.ToString();
                            pdb.Se.Num = item.Cells[4].Value.ToString();
                            sql = pdb.cadena(pdb.Se);
                            pdb.guardarActualizar(sql);
                        }
                    }
                    //servicios predio
                    pdb.Sp.Ficha=pdb.Fi;
                    pdb.Sp.Agua = cmbAgua.Text;
                    pdb.Sp.Num_med_agua=txtMedA.Text;
                    pdb.Sp.Num_agua=(int)nudNroA.Value;
                    pdb.Sp.Elect = cmbElec.Text;
                    pdb.Sp.Num_med_elect=txtMedE.Text;
                    pdb.Sp.Num_elect=(int)nudNroE.Value;
                    pdb.Sp.Num_tel=txtTelPrin.Text;
                    pdb.Sp.Num_lin_tel=(int)nudNroT.Value;
                    pdb.Sp.Alcant = cmbAlcan.Text;
                    pdb.Sp.Riego = cmbRiesgo.Text;
                    pdb.Sp.Met_riego = cmbMetRiego.Text;
                    sql = pdb.cadena(pdb.Sp);
                    pdb.guardarActualizar(sql);
                    //servicios en la via
                    pdb.Sv.Ficha=pdb.Fi;
                    pdb.Sv.Tipo_via = cmbTipVia.Text;
                    pdb.Sv.Mat_via = cmbMatVia.Text;
                    pdb.Sv.Alumb = cmbAluPub.Text;
                    pdb.Sv.Estado_via = cmbEstVia.Text;
                    pdb.Sv.Pobla_cerca = cmbPobCer.Text;
                    pdb.Sv.Transport = cmbTraPub.Text;
                    pdb.Sv.Acera = cmbAcera.Text;
                    pdb.Sv.Basura = cmbRecBas.Text;
                    sql = pdb.cadena(pdb.Sv);
                    pdb.guardarActualizar(sql);
                    //uso del suelo
                    dgvr = dgvUsoSuelo.Rows;
                    pdb.Us.Ficha = pdb.Fi;
                    foreach (DataGridViewRow item in dgvr)
                    {
                        if (item.Cells[0].Value != null && item.Cells[1].Value != null && item.Cells[2].Value != null)
                        {
                            DataGridViewComboBoxCell combo = item.Cells[0] as DataGridViewComboBoxCell;
                            pdb.Us.Uso = ((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString();
                            pdb.Us.Ext = double.Parse(item.Cells[1].Value.ToString());
                            pdb.Us.Porc = double.Parse(item.Cells[2].Value.ToString());
                            sql = pdb.cadena(pdb.Us);
                            pdb.guardarActualizar(sql);
                        }
                    }
                    udb.User = Util.Util.leerUsuarioXml();
                    udb.guardarActualizar("INSERT INTO bitacora (`id_user`, `accion`) VALUES ('" + udb.User.Id + "','Registro de los datos del predio con codigo catastral: " + pdb.Fi.Cod_catastro + "')");
                }
                MessageBox.Show("Datos guardados", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        //linderos = 1, referencias cartograficas = 2, metodo linderacion = 3
        public void lind_ref(string[] elem, int param)
        {
            try
            {
                pdb.Lin.Ficha = pdb.Fi;
                if (param == 1)
                {
                    foreach (string item in elem)
                    {
                        if (item == "n" && txtNort.Text != "")
                        {
                            pdb.Lin.Desc = item;
                            pdb.Lin.Info = txtNort.Text;
                            pdb.guardarActualizar(pdb.cadena(pdb.Lin, param));
                        }
                        if (item == "s" && txtSur.Text != "")
                        {
                            pdb.Lin.Desc = item;
                            pdb.Lin.Info = txtSur.Text;
                            pdb.guardarActualizar(pdb.cadena(pdb.Lin, param));
                        }
                        if (item == "e" && txtEst.Text != "")
                        {
                            pdb.Lin.Desc = item;
                            pdb.Lin.Info = txtEst.Text;
                            pdb.guardarActualizar(pdb.cadena(pdb.Lin, param));
                        }
                        if (item == "o" && txtOest.Text != "")
                        {
                            pdb.Lin.Desc = item;
                            pdb.Lin.Info = txtOest.Text;
                            pdb.guardarActualizar(pdb.cadena(pdb.Lin, param));
                        }
                        //pdb.Lin.Lst.Add(pdb.Lin);
                    }
                }
                else
                {
                    if (param == 2)
                    {
                        foreach (string item in elem)
                        {
                            if (item == "l" && txtLp.Text != "")
                            {
                                pdb.Lin.Desc = item;
                                pdb.Lin.Info = txtLp.Text;
                                pdb.guardarActualizar(pdb.cadena(pdb.Lin, param));
                            }
                            if (item == "f" && txtFoto.Text != "")
                            {
                                pdb.Lin.Desc = item;
                                pdb.Lin.Info = txtFoto.Text;
                                pdb.guardarActualizar(pdb.cadena(pdb.Lin, param));
                            }
                            if (item == "g" && txtGps.Text != "")
                            {
                                pdb.Lin.Desc = item;
                                pdb.Lin.Info = txtGps.Text;
                                pdb.guardarActualizar(pdb.cadena(pdb.Lin, param));
                            }
                            //pdb.Lin.Lst.Add(pdb.Lin);
                        }
                    }
                    else
                    {
                        foreach (string item in elem)
                        {
                            if (item == "t" && txtTop.Text != "")
                            {
                                pdb.Lin.Desc = item;
                                pdb.Lin.Info = txtTop.Text;
                                pdb.guardarActualizar(pdb.cadena(pdb.Lin, param));
                            }
                            if (item == "s" && txtSat.Text != "")
                            {
                                pdb.Lin.Desc = item;
                                pdb.Lin.Info = txtSat.Text;
                                pdb.guardarActualizar(pdb.cadena(pdb.Lin, param));
                            }
                            if (item == "a" && txtAer.Text != "")
                            {
                                pdb.Lin.Desc = item;
                                pdb.Lin.Info = txtAer.Text;
                                pdb.guardarActualizar(pdb.cadena(pdb.Lin, param));
                            }
                            if (item == "o" && txtOtro.Text != "")
                            {
                                pdb.Lin.Desc = item;
                                pdb.Lin.Info = txtOtro.Text;
                                pdb.guardarActualizar(pdb.cadena(pdb.Lin, param));
                            }
                            //pdb.Lin.Lst.Add(pdb.Lin);
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
        public void iami(DataGridView dgv, string t)
        {
            DataGridViewRowCollection dgvr = dgv.Rows;
            foreach (DataGridViewRow item in dgvr)
            {
                if (item.Cells[0].Value != null && item.Cells[1].Value != null && item.Cells[2].Value != null && item.Cells[3].Value != null && item.Cells[4].Value != null)
                {
                    DataGridViewComboBoxCell combo = item.Cells[0] as DataGridViewComboBoxCell;
                    pdb.Mp.Desc = combo.Value.ToString();
                    combo = item.Cells[1] as DataGridViewComboBoxCell;
                    pdb.Mp.Tip_mat = combo.Value.ToString();
                    combo = item.Cells[2] as DataGridViewComboBoxCell;
                    pdb.Mp.U_med = combo.Value.ToString();
                    pdb.Mp.Area = double.Parse(item.Cells[3].Value.ToString());
                    combo = item.Cells[4] as DataGridViewComboBoxCell;
                    pdb.Mp.Estado = combo.Value.ToString();
                    pdb.Mp.Vigencia = t;
                    pdb.guardarActualizar(pdb.cadena(pdb.Mp));
                }
            }
        }

        private double valorBaseBloque(int nb)
        {
            string col = "", entrepiso = "", pared = "", cubierta = "";
            for (int i = 0; i < pdb.Me.Lst.Count; i++)
            {
                if (pdb.Me.Lst[i].Nro_bloque == nb && pdb.Me.Lst[i].Tipo == "Columnas")
                    col = pdb.Me.Lst[i].Material;
                if (pdb.Me.Lst[i].Nro_bloque == nb && pdb.Me.Lst[i].Tipo == "Entrepiso")
                    entrepiso = pdb.Me.Lst[i].Material;
                if (pdb.Me.Lst[i].Nro_bloque == nb && pdb.Me.Lst[i].Tipo == "Paredes")
                    pared = pdb.Me.Lst[i].Material;
                if (pdb.Me.Lst[i].Nro_bloque == nb && pdb.Me.Lst[i].Tipo == "Cubiertas")
                    cubierta = pdb.Me.Lst[i].Material;
            }
            string materiales = col + "-" + entrepiso + "-" + pared + "-" + cubierta;
            fdb.Vm = fdb.traerValorTipologia(materiales);
            return fdb.Vm.Precio;
        }

        public void leerDatosXml()
        {
            XmlTextReader reader = new XmlTextReader("C:\\sigprer\\datopoligono.xml");
            int con = 0;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Text: //Display the text in each element.
                        if (con == 0)
                            id = int.Parse(reader.Value.Trim());
                        if (con == 1)
                            catastro = reader.Value.Trim();
                        if (con == 2)
                            area = double.Parse(reader.Value.Trim());
                        if (con == 3)
                            x = double.Parse(reader.Value.Trim());
                        if (con == 4)
                            y = double.Parse(reader.Value.Trim());
                        con++;
                        break;
                }
            }
            reader.Close();
        }

        private void txtCprov_KeyUp(object sender, KeyEventArgs e)
        {
            cargarTexto(0);
        }

        private void txtCcant_KeyUp(object sender, KeyEventArgs e)
        {
            cargarTexto(1);
        }

        private void txtCparr_KeyUp(object sender, KeyEventArgs e)
        {
            cargarTexto(2);
        }

        private void cboProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProv.SelectedIndex != -1)
            {
                cargarDivision(cboProv.SelectedValue.ToString(), 1, cboCant);
                txtCprov.Text = cboProv.SelectedValue.ToString();
            }
        }

        private void cboCant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCant.SelectedIndex != -1)
            {
                cargarDivision(cboCant.SelectedValue.ToString(), 2, cboParr);
                txtCcant.Text = cboCant.SelectedValue.ToString().Substring(2, 2);
            }
        }

        private void cboParr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboParr.SelectedIndex != -1)
                txtCparr.Text = cboParr.SelectedValue.ToString().Substring(4, 2);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        //materiales u opciones segun seleccion del tipo en el edificio
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

        private void button1_Click(object sender, EventArgs e)
        {
            verificacion();
            Application.Exit();
        }

        private void dgvRelieve_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRelieve.Columns[e.ColumnIndex].Name == "colRelieve")
            {
                DataGridViewComboBoxCell combo = dgvRelieve.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
                string opc = ((System.Windows.Forms.DataGridViewCell)(combo)).EditedFormattedValue.ToString();//obtiene el texto presentado en el combo
                fdb.Facv = fdb.valorRelieve(opc);
                dgvRelieve.Rows[e.RowIndex].Cells[1].Value = fdb.Facv.Adicional;
            }
        }

        private void dgvUsoSuelo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex != 0)
                return;
            dgvUsoSuelo.BeginEdit(true);
        }
        private void FrmInsert_Load(object sender, EventArgs e)
        {
            inicio();
            leerDatosXml();
            if (!catastro.Contains(".") && catastro != "")
            {
                txtCprov.Text = catastro.Substring(0, 2);
                cargarTexto(0);
                txtCcant.Text = catastro.Substring(2, 2);
                cargarTexto(1);
                txtCparr.Text = catastro.Substring(4, 2);
                cargarTexto(2);
                txtCoorX.Text = x + "";
                txtCoorY.Text = y + "";
                nudAreaTot.Value = (decimal)area;
            }
            else
            {
                MessageBox.Show("El polinogo seleccionado no contiene clave catastral", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }
        }
    }
}
