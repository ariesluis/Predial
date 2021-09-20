using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIGPRER.controller.factores;
using SIGPRER.controller.predios;
using System.IO;

namespace SIGPRER.view.ficha
{
    public partial class FrmAvaluo : Form
    {
        public FrmAvaluo()
        {
            InitializeComponent();
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            
        }

        PredioDB pdb = new PredioDB();
        FactorDB fdb = new FactorDB();

        double facti = 1;
        double areaTerreno = 0;
        double costoBase = 0;
        string descTenencia = "";

        double valorTerreno = 0;
        double valorConstruc = 0;

        double valorTotal = 0;

        private void calculoFactor()
        {
            try
            {
                txtClave.Text = Util.Util.leerParamXml("catastrogdb.xml");
                //traer datos de la ficha
                pdb.Fi = pdb.obtenerFicha("Select * from fichas where fi_cod_catastral='" + txtClave.Text + "'");
                //traer valores base
                fdb.Vi = fdb.valoresBase(fdb.traerFactor("Impuestos").Id);
                listBox1.Items.Add(fdb.Vi.Band_imp+" impuesto municipal");
                listBox1.Items.Add(fdb.Vi.Bomberos + " bomberos");
                listBox1.Items.Add("Area total: " + pdb.Fi.Cf.Area);
                listBox1.Items.Add("Valor base: " + pdb.Fi.Cf.Costo_base);
                //terreno
                if (pdb.Fi.Cf.Area > 1 && pdb.Fi.Cf.Area < 5001)
                {
                    facti *= factor("Tamaño", "Rango 1");

                    listBox1.Items.Add("Tamaño factor: Rango 1, factor: " + factor("Tamaño", "Rango 1") + ", multiplicacion:" + facti);
                }
                if (pdb.Fi.Cf.Area > 5000 && pdb.Fi.Cf.Area < 10001)
                {
                    facti *= factor("Tamaño", "Rango 2");

                    listBox1.Items.Add("Tamaño factor: Rango 2, factor: " + factor("Tamaño", "Rango 2") + ", multiplicacion:" + facti);
                }
                if (pdb.Fi.Cf.Area > 10000 && pdb.Fi.Cf.Area < 500001)
                {
                    facti *= factor("Tamaño", "Rango 3");

                    listBox1.Items.Add("Tamaño factor: Rango 3, factor: " + factor("Tamaño", "Rango 3") + ", multiplicacion:" + facti);
                }
                if (pdb.Fi.Cf.Area > 500000)
                {
                    facti *= factor("Tamaño", "Rango 4");

                    listBox1.Items.Add("Tamaño factor: Rango 4, factor: " + factor("Tamaño", "Rango 4") + ", multiplicacion:" + facti);
                }
                facti *= factor("Forma del Predio", pdb.Fi.Cf.Forma);
                listBox1.Items.Add("Forma del Predio: " + pdb.Fi.Cf.Forma + ", factor: " + factor("Forma del Predio", pdb.Fi.Cf.Forma) + ", multipicacion:" + facti);

                facti *= factor("Riesgo", pdb.Fi.Cf.Riesgo);
                listBox1.Items.Add("Riesgo: "+pdb.Fi.Cf.Riesgo + ", factor: " + factor("Riesgo", pdb.Fi.Cf.Riesgo) + ", multipicacion:" + facti);

                facti *= factor("Erosión", pdb.Fi.Cf.Erosion);
                listBox1.Items.Add("Erosión: "+pdb.Fi.Cf.Erosion + ", factor: " + factor("Erosión", pdb.Fi.Cf.Erosion) + ", multipicacion:" + facti);

                facti *= factor("Clasificación Suelo", pdb.Fi.Cf.Clas_suelo);
                listBox1.Items.Add("Clasificación Suelo: "+pdb.Fi.Cf.Clas_suelo + ", factor: " + factor("Clasificación Suelo", pdb.Fi.Cf.Clas_suelo) + ", multipicacion:" + facti);

                facti *= factor("Cobertura Natural", pdb.Fi.Cf.Cob_natural);
                listBox1.Items.Add("Cobertura Natural: "+pdb.Fi.Cf.Cob_natural + ", factor: " + factor("Cobertura Natural", pdb.Fi.Cf.Cob_natural) + ", multipicacion:" + facti);

                facti *= factor("Ecosistema Relevante", pdb.Fi.Cf.Ecosis_rele);
                listBox1.Items.Add("Ecosistema Relevante: "+pdb.Fi.Cf.Ecosis_rele + ", factor: " + factor("Ecosistema Relevante", pdb.Fi.Cf.Ecosis_rele) + ", multipicacion:" + facti);

                facti *= factor("Valor Cultural", pdb.Fi.Cf.Valor_cult);
                listBox1.Items.Add("Valor Cultural: "+pdb.Fi.Cf.Valor_cult + ", factor: " + factor("Valor Cultural", pdb.Fi.Cf.Valor_cult) + ", multipicacion:" + facti);

                facti *= factorMultiple("Clasificación Agrológica");
                listBox1.Items.Add("Clasificación Agrológica factor: " + factorMultiple("Clasificación Agrológica") + ", multipicacion:" + facti);

                facti *= factor("Forma Adquisición", pdb.Fi.Il.Form_tenen);
                listBox1.Items.Add("Forma Adquisición: " + pdb.Fi.Il.Form_tenen + ", factor: " + factor("Forma Adquisición", pdb.Fi.Il.Form_tenen) + ", multipicacion:" + facti);

                facti *= factor("Dominio", pdb.Fi.Il.Dom);
                listBox1.Items.Add("Dominio: " + pdb.Fi.Il.Dom + ", factor: " + factor("Dominio", pdb.Fi.Il.Dom) + ", multipicacion:" + facti);

                facti *= factor("Tipo Tenencia", pdb.Fi.Il.Tip_tenen);
                listBox1.Items.Add("Tipo Tenencia: " + pdb.Fi.Il.Tip_tenen + ", factor: " + factor("Tipo Tenencia", pdb.Fi.Il.Tip_tenen) + ", multipicacion:" + facti);

                facti *= factor("Localización Manzana", pdb.Fi.Local.Manzana);
                listBox1.Items.Add("Localización Manzana: " + pdb.Fi.Local.Manzana + " factor: " + factor("Localización Manzana", pdb.Fi.Local.Manzana) + " multipicacion:" + facti);

                facti *= factorMultiple("Relieve");
                listBox1.Items.Add("Relieve factor: " + factorMultiple("Relieve") + " multipicacion:" + facti);

                facti *= factor("Agua Proviene", pdb.Fi.Sp.Agua);
                listBox1.Items.Add("Agua Proviene: " + pdb.Fi.Sp.Agua + " factor: " + factor("Agua Proviene", pdb.Fi.Sp.Agua) + " multipicacion:" + facti);

                facti *= factor("Energía Eléctrica Proviene", pdb.Fi.Sp.Elect);
                listBox1.Items.Add("Energía Eléctrica Proviene: " + pdb.Fi.Sp.Elect + " factor: " + factor("Energía Eléctrica Proviene", pdb.Fi.Sp.Elect) + " multipicacion:" + facti);

                facti *= factor("Alcantarillado", pdb.Fi.Sp.Alcant);
                listBox1.Items.Add("Alcantarillado: " + pdb.Fi.Sp.Alcant + " factor: " + factor("Alcantarillado", pdb.Fi.Sp.Alcant) + " multipicacion:" + facti);

                facti *= factor("Disponibilidad Riego", pdb.Fi.Sp.Riego);
                listBox1.Items.Add("Disponibilidad Riego: " + pdb.Fi.Sp.Riego + " factor: " + factor("Disponibilidad Riego", pdb.Fi.Sp.Riego) + " multipicacion:" + facti);

                facti *= factor("Método Riego", pdb.Fi.Sp.Met_riego);
                listBox1.Items.Add("Método Riego: " + pdb.Fi.Sp.Met_riego + " factor: " + factor("Método Riego", pdb.Fi.Sp.Met_riego) + " multipicacion:" + facti);

                facti *= factor("Tipo Vía", pdb.Fi.Sv.Tipo_via);
                listBox1.Items.Add("Tipo Vía: " + pdb.Fi.Sv.Tipo_via + " factor: " + factor("Tipo Vía", pdb.Fi.Sv.Tipo_via) + " multipicacion:" + facti);

                facti *= factor("Rodadura", pdb.Fi.Sv.Mat_via);
                listBox1.Items.Add("Rodadura: " + pdb.Fi.Sv.Mat_via + " factor: " + factor("Rodadura", pdb.Fi.Sv.Mat_via) + " multipicacion:" + facti);

                facti *= factor("Alumbrado", pdb.Fi.Sv.Alumb);
                listBox1.Items.Add("Alumbrado: " + pdb.Fi.Sv.Alumb + " factor: " + factor("Alumbrado", pdb.Fi.Sv.Alumb) + " multipicacion:" + facti);

                facti *= factor("Estado Vía", pdb.Fi.Sv.Estado_via);
                listBox1.Items.Add("Estado Vía: " + pdb.Fi.Sv.Estado_via + " factor: " + factor("Estado Vía", pdb.Fi.Sv.Estado_via) + " multipicacion:" + facti);

                facti *= factor("Poblaciones Cercanas", pdb.Fi.Sv.Pobla_cerca);
                listBox1.Items.Add("Poblaciones Cercanas: " + pdb.Fi.Sv.Pobla_cerca + " factor: " + factor("Poblaciones Cercanas", pdb.Fi.Sv.Pobla_cerca) + " multipicacion:" + facti);

                facti *= factor("Transporte Público", pdb.Fi.Sv.Transport);
                listBox1.Items.Add("Transporte Público: " + pdb.Fi.Sv.Transport + " factor: " + factor("Transporte Público", pdb.Fi.Sv.Transport) + " multipicacion:" + facti);

                facti *= factor("Acera", pdb.Fi.Sv.Acera);
                listBox1.Items.Add("Acera: " + pdb.Fi.Sv.Acera + " factor: " + factor("Acera", pdb.Fi.Sv.Acera) + " multipicacion:" + facti);

                facti *= factor("Recolección Basura", pdb.Fi.Sv.Basura);
                listBox1.Items.Add("Recolección Basura:" + pdb.Fi.Sv.Basura + " factor: " + factor("Recolección Basura", pdb.Fi.Sv.Basura) + " multipicacion:" + facti);

                facti *= factorMultiple("Uso Suelo");
                listBox1.Items.Add("Uso Suelo factor: " + factorMultiple("Uso Suelo") + " multipicacion:" + facti);
                
                //edificios
                factorEdificios();
                //valores base
                areaTerreno = pdb.Fi.Cf.Area;
                costoBase = pdb.Fi.Cf.Costo_base;
                descTenencia = pdb.Fi.Il.Desc_tenen;

            }
            catch (Exception)
            {
                MessageBox.Show("El predio no contiene datos completos o tipo de mejora resgistrado con su respectivo material o Tipologia de la edificacion estos se gestionan en Factores", "Advertencia");
                Application.Exit();
            }
        }
        private double factorRelieve(string desc)
        {
            try
            {
                fdb.Facv = fdb.valorRelieve(desc);
                return fdb.Facv.Valor;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        private double factor(string nomFact, string descFactor)
        {
            try
            {
                fdb.Fac = fdb.traerFactor(nomFact);
                fdb.Facv = fdb.valorFactor(fdb.Fac.Id, descFactor);
                return fdb.Facv.Valor;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        private double factorMultiple(string param)
        {
            if (param == "Clasificación Agrológica")
            {
                double fm = 0;
                for (int i = 0; i < pdb.Fi.LstCa.Count; i++)
                {
                    double fact = factor(param, pdb.Fi.LstCa[i].Clase);
                    double porcent = (pdb.Fi.LstCa[i].Porcion) / 100;
                    fm += (fact * porcent);
                }
                return fm;
            }
            else
                if (param == "Relieve")
                {
                    double fm = 0;
                    for (int i = 0; i < pdb.Fi.LstRel.Count; i++)
                    {
                        double fact = factorRelieve(pdb.Fi.LstRel[i].Desc);
                        double porcent = (pdb.Fi.LstRel[i].Porcent) / 100;
                        fm += (fact * porcent);
                    }
                    return fm;
                }
                else
                    if (param=="Uso Suelo")
                    {
                        double fm = 0;
                        for (int i = 0; i < pdb.Fi.LstUs.Count; i++)
                        {
                            double fact = factor(param, pdb.Fi.LstUs[i].Uso);
                            double porcent = (pdb.Fi.LstUs[i].Porc) / 100;
                            fm += (fact * porcent);
                        }
                        return fm;
                    }
                    else
                        return 1;
        }
        private void inicalizacionCampos()
        {
            if (pdb.Fi.Propietario.Nom_nat != "")
            {
                txtContrib.Text = pdb.Fi.Propietario.Nom_nat;
                txtCi.Text = pdb.Fi.Propietario.Ci_nat;
            }
            else
            {
                txtContrib.Text = pdb.Fi.Propietario.Nom_jur;
                txtCi.Text = pdb.Fi.Propietario.Ruc_jur;
            }

        }
        private void factorEdificios()
        {
            listBox1.Items.Add("----------contrucciones----------");

            double factEdif = 1;
            for (int i = 0; i < pdb.Fi.LstDc.Count; i++)
            {

                listBox1.Items.Add("Nro Bloque: " + pdb.Fi.LstDc[i].Nrob);
                listBox1.Items.Add("Costo base: " + pdb.Fi.LstDc[i].PrecioBase);

                factEdif = 1;
                factEdif *= factor("Condición Física", pdb.Fi.LstDc[i].Cond_fis);
                listBox1.Items.Add("Condicion fisica: " + pdb.Fi.LstDc[i].Cond_fis + ", factor: " + factor("Condición Física", pdb.Fi.LstDc[i].Cond_fis) + ", multiplicacion: " + factEdif);

                factEdif *= factor("Valor Cultural", pdb.Fi.LstDc[i].Val_cul);
                listBox1.Items.Add("Valor cultural: " + pdb.Fi.LstDc[i].Val_cul + ", factor: " + factor("Valor Cultural", pdb.Fi.LstDc[i].Val_cul) + ", multiplicacion: " + factEdif);

                factEdif *= factor("Estado Conservación", pdb.Fi.LstDc[i].Elect);
                listBox1.Items.Add("Estado i. electricas: " + pdb.Fi.LstDc[i].Elect + ", factor: " + factor("Estado Conservación", pdb.Fi.LstDc[i].Elect) + ", multiplicacion: " + factEdif);

                factEdif *= factor("Estado Conservación", pdb.Fi.LstDc[i].Sanit);
                listBox1.Items.Add("Estado i. sanitarias: " + pdb.Fi.LstDc[i].Sanit + ", factor: " + factor("Estado Conservación", pdb.Fi.LstDc[i].Sanit) + ", multiplicacion: " + factEdif);

                factEdif *= factor("Instalaciones Especiales", pdb.Fi.LstDc[i].Espec);
                listBox1.Items.Add("Instalaciones especiales: " + pdb.Fi.LstDc[i].Espec + ", factor: " + factor("Instalaciones Especiales", pdb.Fi.LstDc[i].Espec) + ", multiplicacion: " + factEdif);

                factEdif *= factor("Numero Baños", pdb.Fi.LstDc[i].Nro_banio);
                listBox1.Items.Add("Numero baños: " + pdb.Fi.LstDc[i].Nro_banio + ", factor: " + factor("Numero Baños", pdb.Fi.LstDc[i].Nro_banio) + ", multiplicacion: " + factEdif);
                
                for (int j = 0; j < pdb.Fi.LstMe.Count; j++)
                {
                    if (pdb.Fi.LstDc[i].Nrob == pdb.Fi.LstMe[j].Nro_bloque)
                    {
                        factEdif *= factor("Material", pdb.Fi.LstMe[j].Material);

                        listBox1.Items.Add("Estructura: " + pdb.Fi.LstMe[j].Tipo + ", material: " + pdb.Fi.LstMe[j].Material + ", factor: " + factor("Material", pdb.Fi.LstMe[j].Material) + ", multiplicacion: " + factEdif);

                    }
                }
                listBox1.Items.Add("Area: " + pdb.Fi.LstDc[i].Area + ", costo: " + (pdb.Fi.LstDc[i].PrecioBase * factEdif * pdb.Fi.LstDc[i].Area));
                listBox1.Items.Add("");

                valorConstruc += (pdb.Fi.LstDc[i].PrecioBase * factEdif * pdb.Fi.LstDc[i].Area);
            }
            for (int i = 0; i < pdb.Fi.LstMp.Count; i++)
            {
                factEdif = 1;
                factEdif *= factor("Condición Física", pdb.Fi.LstMp[i].Estado);

                listBox1.Items.Add("Obra: " + pdb.Fi.LstMp[i].Desc);
                listBox1.Items.Add("Material: " + pdb.Fi.LstMp[i].Tip_mat);
                listBox1.Items.Add("Valor base + m2: " + (fdb.traerValorMejora(pdb.Fi.LstMp[i].Desc, pdb.Fi.LstMp[i].Tip_mat).Precio));
                listBox1.Items.Add("Area/Long: " + pdb.Fi.LstMp[i].Area + " " + pdb.Fi.LstMp[i].U_med);
                listBox1.Items.Add("Condicion fisica: " + pdb.Fi.LstMp[i].Estado + ", factor: " + factor("Condición Física", pdb.Fi.LstMp[i].Estado));
                listBox1.Items.Add("Costo: " + (fdb.traerValorMejora(pdb.Fi.LstMp[i].Desc, pdb.Fi.LstMp[i].Tip_mat).Precio * factEdif * pdb.Fi.LstMp[i].Area));
                listBox1.Items.Add("");

                valorConstruc += (fdb.traerValorMejora(pdb.Fi.LstMp[i].Desc, pdb.Fi.LstMp[i].Tip_mat).Precio * factEdif * pdb.Fi.LstMp[i].Area);
            }
        }
        private void calculoImpuesto()
        {
            valorTerreno = Math.Round((facti * areaTerreno * costoBase), 2);
            txtTotalAva.Text = (valorTerreno + valorConstruc) + "";
            txtTerreno.Text = valorTerreno + "";
            if (descTenencia == "Estado" || descTenencia == "Municipal" || descTenencia == "C. Provincial" || descTenencia == "Comuna" || descTenencia == "Asist. Social" || descTenencia == "Gob. Extranj")
            {
                txtimp.Text = "0";
                txtbomb.Text = "0";
                txtadmin.Text = "0";
                txttotal.Text = "0";
            }
            else
            {
                if ((valorTerreno+valorConstruc) <= (fdb.Vi.Sbu * 15))
                {
                    txtimp.Text = "0";
                    txtbomb.Text = "0";
                    txtadmin.Text = "0";
                    txttotal.Text = "0";
                }
                else
                {
                    txtimp.Text = Math.Round((fdb.Vi.Band_imp / 1000 * (valorTerreno+valorConstruc)), 2) + "";
                    txtbomb.Text = Math.Round((fdb.Vi.Bomberos / 1000 * (valorTerreno+valorConstruc)), 2) + "";
                    txtadmin.Text = fdb.Vi.Serv_admi + "";
                    txtConstruc.Text = valorConstruc + "";
                    valorTotal = double.Parse(txtimp.Text) + double.Parse(txtbomb.Text) + double.Parse(txtadmin.Text);
                    txttotal.Text = valorTotal + "";
                }
            }

            listBox1.Items.Add("-------------------Valores finales-------------");
            listBox1.Items.Add("Terreno: " + txtTerreno.Text);
            listBox1.Items.Add("Construccion: " + txtConstruc.Text);
            listBox1.Items.Add("Avaluo Predio: " + txtTotalAva.Text);
            listBox1.Items.Add("Impuesto predial: " + txtimp.Text);
            listBox1.Items.Add("Bomberos: " + txtbomb.Text);
            listBox1.Items.Add("Servicios administrativos: " + txtadmin.Text);
            listBox1.Items.Add("Total pagar: " + txttotal.Text);


        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rdbSi_CheckedChanged(object sender, EventArgs e)
        {
            txttotal.Text = (valorTotal*0.5) + "";
        }

        private void rdbNo_CheckedChanged(object sender, EventArgs e)
        {
            txttotal.Text = valorTotal + "";
        }

        private void FrmAvaluo_Load(object sender, EventArgs e)
        {
            calculoFactor();
            inicalizacionCampos();
            calculoImpuesto();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (!pdb.obtenerAvaluo(pdb.Fi.Id))
            {
                string sql = "Insert into avaluo (av_terreno, av_cons, av_total_aval, av_imp_predio, av_imp_bomb, av_imp_admin, av_total_pagar, fi_id) values"
                    + "(" + double.Parse(txtTerreno.Text)
                    + "," + double.Parse(txtConstruc.Text)
                    + "," + double.Parse(txtTotalAva.Text)
                    + "," + double.Parse(txtimp.Text)
                    + "," + double.Parse(txtbomb.Text)
                    + "," + double.Parse(txtadmin.Text)
                    + "," + double.Parse(txttotal.Text)
                    + "," + pdb.Fi.Id
                    + ")";
                pdb.guardarActualizar(sql);
                MessageBox.Show("Valores guardados", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string sql = "Update avaluo set "
                    + "av_terreno='" + txtTerreno.Text
                    + "', av_cons='" + txtConstruc.Text
                    + "', ava_total_aval='" + txtTotalAva.Text
                    + "', av_imp_predio='" + txtimp.Text
                    + "', av_imp_bomb='" + txtbomb.Text
                    + "', av_imp_admin='" + txtadmin.Text
                    + "', av_total_pagar='" + txttotal.Text
                    + "' where fi_id=" + pdb.Fi.Id
                    + ")";
                pdb.guardarActualizar(sql);
                MessageBox.Show("Valores actualizados", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"C:\sigprer\test.txt");
            foreach (object lista in listBox1.Items)
            {
                sw.WriteLine(lista.ToString());
            }
            sw.Close();
        }
    }
}
