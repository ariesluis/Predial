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
using SIGPRER.controller.user;
using SIGPRER.Util;

namespace SIGPRER.view.factor
{
    public partial class FrmModifFact : Form
    {
        public FrmModifFact()
        {
            InitializeComponent();
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            
        }
        public FrmModifFact(UserDB us)
        {
            InitializeComponent();
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            this.us = us;

        }

        FactorDB fdb = new FactorDB();
        public UserDB us = null;
        UserDB udb = new UserDB();

        //tipo de factor seleccionad
        string opcion = "";
        int filaId = 0;
        //descripcion del factor seleccionado o elemento del factor
        string desc = "";
        int numFila = 0;

        private void cargarFactor()
        {
            fdb.Fac.Lst = fdb.listFactor();
            cboOpcion.DisplayMember = "desc";
            cboOpcion.ValueMember = "id";
            cboOpcion.DataSource = fdb.Fac.Lst;
        }

        private void cargarValorMejoras(int id)
        {
            dgvDatos.Rows.Clear();
            fdb.Vm.Lst = fdb.listValorMejora(id);
            for (int i = 0; i < fdb.Vm.Lst.Count; i++)
            {
                dgvDatos.Rows.Add(1);
                dgvDatos.Rows[i].Cells[0].Value = fdb.Vm.Lst[i].Mejora;
                dgvDatos.Rows[i].Cells[1].Value = fdb.Vm.Lst[i].Material;
                dgvDatos.Rows[i].Cells[2].Value = fdb.Vm.Lst[i].Precio;
            }
        }
        private void cargarListFactores(int id)
        {
            dgvDatos.Rows.Clear();
            fdb.Facv.Lst = fdb.listSegunFactor(id);
            for (int i = 0; i < fdb.Facv.Lst.Count; i++)
            {
                dgvDatos.Rows.Add(1);
                dgvDatos.Rows[i].Cells[0].Value = fdb.Facv.Lst[i].Fa_id;
                dgvDatos.Rows[i].Cells[1].Value = fdb.Facv.Lst[i].Desc;
                dgvDatos.Rows[i].Cells[2].Value = fdb.Facv.Lst[i].Valor;
            }
        }
        private void cargarRelieve(int id)
        {
            dgvDatos.Rows.Clear();
            fdb.Facv.Lst = fdb.listFactorRelieve(id);
            for (int i = 0; i < fdb.Facv.Lst.Count; i++)
            {
                dgvDatos.Rows.Add(1);
                dgvDatos.Rows[i].Cells[0].Value = fdb.Facv.Lst[i].Fa_id;
                dgvDatos.Rows[i].Cells[1].Value = fdb.Facv.Lst[i].Desc;
                dgvDatos.Rows[i].Cells[2].Value = fdb.Facv.Lst[i].Valor;
            }
        }
        private void formatTable(string opc)
        {
            dgvDatos.Columns.Clear();
            if (opc != "Impuestos" && opcion != "Valor Mejoras" && opcion != "Tipología Edificaciones")
            {
                dgvDatos.Columns.Add("Column0", "ID");
                dgvDatos.Columns.Add("Column1", "Desc");
                dgvDatos.Columns.Add("Column2", "Valor");
            }
            else
            {
                if (opcion == "Valor Mejoras")
                {
                    dgvDatos.Columns.Add("Column0", "Obra o Mejora");
                    dgvDatos.Columns.Add("Column1", "Material");
                    dgvDatos.Columns.Add("Column2", "Valor");
                }
                else
                {
                    dgvDatos.Columns.Add("Column0", "Tipo");
                    dgvDatos.Columns.Add("Column1", "Elementos");
                    dgvDatos.Columns.Add("Column2", "Valor");
                }
            }
        }

        private void cboOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            opcion = cboOpcion.Text;
            gpbDatoObra.Enabled = false;
            gpbTipo.Enabled = false;
            gpbDatos.Show();
            int id = int.Parse(cboOpcion.SelectedValue.ToString());
            if (opcion != "Impuestos" && opcion != "Relieve" && opcion != "Valor Mejoras" && opcion != "Tipología Edificaciones")
            {
                gpbList.Enabled = true;
                formatTable(opcion);
                cargarListFactores(id);
                gpbImp.Enabled = false;
            }
            else
            {
                if (opcion == "Relieve")
                {
                    formatTable(opcion);
                    cargarRelieve(id);
                    gpbImp.Enabled = false;
                }
                else
                {
                    if (opcion == "Valor Mejoras")
                    {
                        gpbDatoObra.Enabled = true;
                        formatTable(opcion);
                        cargarValorMejoras(int.Parse(cboOpcion.SelectedValue.ToString()));
                        cargarMateriales();
                    }
                    else
                        if (opcion == "Tipología Edificaciones")
                        {
                            gpbTipo.Enabled = true;
                            formatTable(opcion);
                            cargarValorMejoras(int.Parse(cboOpcion.SelectedValue.ToString()));
                            cargarMateriales();
                        }
                        else
                        {
                            gpbList.Enabled = false;
                            fdb.Vi = fdb.valoresBase(id);
                            txtId.Text = fdb.Vi.Id + "";
                            nudBI.Value = (decimal)fdb.Vi.Band_imp;
                            nudB.Value = (decimal)fdb.Vi.Bomberos;
                            nudSbu.Value = (decimal)fdb.Vi.Sbu;
                            nudAdmi.Value = (decimal)fdb.Vi.Serv_admi;
                            gpbImp.Enabled = true;
                            gpbDatos.Enabled = true;
                        }
                }
            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnSelect.Enabled = true;
                if (opcion == "Valor Mejoras" || opcion == "Tipología Edificaciones")
                {
                    numFila = dgvDatos.CurrentRow.Index;
                    rbn1.Enabled = false;
                    rbn2.Enabled = false;
                }
                else
                {
                    filaId = int.Parse(dgvDatos.CurrentRow.Cells[0].Value.ToString());
                    desc = dgvDatos.CurrentRow.Cells[1].Value.ToString();
                }
            }
            catch
            { btnSelect.Enabled = false; }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (opcion != "Valor Mejoras" && opcion != "Tipología Edificaciones")
            {
                gpbDatos.Enabled = true;
                gpbFactor.Enabled = true;
                if (opcion != "Relieve")
                    fdb.Facv = fdb.valorFactor(filaId, desc);
                else
                    fdb.Facv = fdb.valorRelieve(desc);
                txtId.Text = fdb.Facv.Fa_id.ToString();
                txtDesc.Text = fdb.Facv.Desc;
                nudCoef.Value = (decimal)fdb.Facv.Valor;
            }
            else
            {
                if (opcion == "Tipología Edificaciones")
                {
                    btnGuardarT.Enabled = false;
                    btnModT.Enabled = true;
                    txtNomTipo.Enabled = false;
                    cmbMat1.Enabled = false;
                    cmbMat2.Enabled = false;
                    cmbMat3.Enabled = false;
                    cmbMat4.Enabled = false;
                    txtNomTipo.Text = dgvDatos.Rows[numFila].Cells[0].Value.ToString();
                    List<string> lst = procesarCadena(dgvDatos.Rows[numFila].Cells[1].Value.ToString());
                    nudValorT.Value = decimal.Parse(dgvDatos.Rows[numFila].Cells[2].Value.ToString());
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (i == 0)
                            cmbMat1.Text = lst[i];
                        if (i == 1)
                            cmbMat2.Text = lst[i];
                        if (i == 2)
                            cmbMat3.Text = lst[i];
                        if (i == 3)
                            cmbMat4.Text = lst[i];
                    }
                }
                else
                {
                    btnGuardar.Enabled = false;
                    btnModObra.Enabled = true;
                    cmbObra.Text = dgvDatos.Rows[numFila].Cells[0].Value.ToString();
                    cmbMaterial.Text = dgvDatos.Rows[numFila].Cells[1].Value.ToString();
                    nudValor.Value = decimal.Parse(dgvDatos.Rows[numFila].Cells[2].Value.ToString());
                    cmbObra.Enabled = false;
                    cmbMaterial.Enabled = false;
                }
            }
        }

        private List<string> procesarCadena(string cadena)
        {
            cadena += "-";
            List<string> lista = new List<string>();
            int posini = 0;
            for (int i = 0; i < cadena.Length; i++)
            {
                if (cadena[i] == '-')
                {
                    lista.Add(cadena.Substring(posini, i - posini));
                    posini = i + 1;
                }
            }
            return lista;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int v = 0;
            if (opcion != "Impuestos" && opcion != "Relieve")
            {
                string sql = "Update factor_valor set fv_valor=" + (double)nudCoef.Value + " WHERE fa_id=" + int.Parse(txtId.Text) + " and fv_desc='" + txtDesc.Text + "'";
                v=fdb.guardarActualizar(sql);
                udb.User = Util.Util.leerUsuarioXml();
                if(us==null)
                    udb.guardarActualizar("INSERT INTO bitacora (`id_user`, `accion`) VALUES ('" + udb.User.Id + "', 'Modificacion del valor: " + desc + " del factor " + opcion + " por el valor: " + (double)nudCoef.Value + "')");
                else
                    udb.guardarActualizar("INSERT INTO bitacora (`id_user`, `accion`) VALUES ('" + us.User.Id + "', 'Modificacion del valor: " + desc + " del factor " + opcion + " por el valor: " + (double)nudCoef.Value + "')");
            }
            else
            {
                if (opcion == "Relieve")
                {
                    string sql = "Update factor_valor_relieve set fv_valor=" + (double)nudCoef.Value + " WHERE fa_id=" + int.Parse(txtId.Text) + " and fv_desc='" + txtDesc.Text + "'";
                    v=fdb.guardarActualizar(sql);
                    udb.User = Util.Util.leerUsuarioXml();
                    if(us==null)
                        udb.guardarActualizar("INSERT INTO bitacora (`id_user`, `accion`) VALUES ('" + udb.User.Id + "','Modificacion del valor: " + desc + " del factor " + opcion + " por el valor: " + (double)nudCoef.Value + "')");
                    else
                        udb.guardarActualizar("INSERT INTO bitacora (`id_user`, `accion`) VALUES ('" + us.User.Id + "','Modificacion del valor: " + desc + " del factor " + opcion + " por el valor: " + (double)nudCoef.Value + "')");
                }
                else
                {
                    string sql = "Update valor_impuestos set ban_imp=" + (double)nudBI.Value + ", sbu=" + (double)nudSbu.Value + ", serv_admi=" + (double)nudAdmi.Value + ", bombero=" + (double)nudB.Value + " WHERE fa_id=" + int.Parse(txtId.Text);
                    v=fdb.guardarActualizar(sql);
                    udb.User = Util.Util.leerUsuarioXml();
                    if(us==null)
                        udb.guardarActualizar("INSERT INTO bitacora (`id_user`, `accion`) VALUES ('" + udb.User.Id + "','Modificacion del valor: " + desc + " del factor " + opcion + "')");
                    else
                        udb.guardarActualizar("INSERT INTO bitacora (`id_user`, `accion`) VALUES ('" + us.User.Id + "','Modificacion del valor: " + desc + " del factor " + opcion + "')");
                }
            }
            if(v>0)
            {
                MessageBox.Show("Valor actualizado", "Listo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                inicio();
                
            }
            else
                MessageBox.Show("Error al actualizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rbn1_CheckedChanged(object sender, EventArgs e)
        {
            FactorDB f = new FactorDB();
            f.Fac = f.traerFactor("Obra o Mejora");
            f.Facv.Lst = fdb.listSegunFactor(f.Fac.Id);
            cmbObra.DisplayMember = "desc";
            cmbObra.ValueMember = "id";
            cmbObra.DataSource = f.Facv.Lst;
        }

        private void rbn2_CheckedChanged(object sender, EventArgs e)
        {
            FactorDB f = new FactorDB();
            f.Fac = f.traerFactor("Uso Constructivo");
            f.Facv.Lst = fdb.listSegunFactor(f.Fac.Id);
            cmbObra.DisplayMember = "desc";
            cmbObra.ValueMember = "id";
            cmbObra.DataSource = f.Facv.Lst;
        }

        private void cargarMateriales()
        {
            FactorDB f = new FactorDB();
            f.Fac = f.traerFactor("Material");
            f.Facv.Lst = fdb.listSegunFactor(f.Fac.Id);
            cmbMaterial.DisplayMember = "desc";
            cmbMaterial.ValueMember = "id";
            cmbMaterial.DataSource = f.Facv.Lst;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string sql = "Insert into valor_mejoras (`mejora`, `material`, `precio`, `fa_id`) VALUES ('" + cmbObra.Text + "','" + cmbMaterial.Text + "'," + (double)nudValor.Value + ", " + int.Parse(cboOpcion.SelectedValue.ToString()) + ")";
            fdb.guardarActualizar(sql);
            udb.User = Util.Util.leerUsuarioXml();
            if(us==null)
                udb.guardarActualizar("INSERT INTO bitacora (`id_user`, `accion`) VALUES ('" + udb.User.Id + "','Se agrego un nuevo valor de mejora: " + cmbObra.Text + " con el material " + cmbMaterial.Text + " precio: " + (double)nudValor.Value + "')");
            else
                udb.guardarActualizar("INSERT INTO bitacora (`id_user`, `accion`) VALUES ('" + us.User.Id + "','Se agrego un nuevo valor de mejora: " + cmbObra.Text + " con el material " + cmbMaterial.Text + " precio: " + (double)nudValor.Value + "')");
            MessageBox.Show("Se agrego un nuevo valor", "Listo");
            inicio();
        }

        private void btnModObra_Click(object sender, EventArgs e)
        {
            double val = (double)nudValor.Value;
            string sql = "Update valor_mejoras set precio=" + (double)nudValor.Value + " where mejora='" + cmbObra.Text + "' and material='" + cmbMaterial.Text + "'";
            fdb.guardarActualizar(sql);
            udb.User = Util.Util.leerUsuarioXml();
            if(us==null)
                udb.guardarActualizar("INSERT INTO bitacora (`id_user`, `accion`) VALUES ('" + udb.User.Id + "','Se modifico el valor de mejora: " + cmbObra.Text + " con el material " + cmbMaterial.Text + " precio: " + (double)nudValor.Value + "')");
            else
                udb.guardarActualizar("INSERT INTO bitacora (`id_user`, `accion`) VALUES ('" + us.User.Id + "','Se modifico el valor de mejora: " + cmbObra.Text + " con el material " + cmbMaterial.Text + " precio: " + (double)nudValor.Value + "')");
            MessageBox.Show("Se modifico el valor", "Listo");
            inicio();

        }

        private void btnGuardarT_Click(object sender, EventArgs e)
        {
            string materiales = cmbMat1.Text + "-" + cmbMat2.Text + "-" + cmbMat3.Text + "-" + cmbMat4.Text;
            string sql = "Insert into valor_mejoras (`mejora`, `material`, `precio`, `fa_id`) VALUES ('" + txtNomTipo.Text + "','" + materiales + "'," + (double)nudValorT.Value + ", " + int.Parse(cboOpcion.SelectedValue.ToString()) + ")";
            if (txtNomTipo.Text != "")
            {
                fdb.guardarActualizar(sql);
                udb.User = Util.Util.leerUsuarioXml();
                if(us==null)
                    udb.guardarActualizar("INSERT INTO bitacora (`id_user`, `accion`) VALUES ('" + udb.User.Id + "','Se agrego una nueva tipologia de edificacion: " + txtNomTipo.Text + ", materiales: " + materiales + " precio: " + (double)nudValorT.Value + "')");
                else
                    udb.guardarActualizar("INSERT INTO bitacora (`id_user`, `accion`) VALUES ('" + us.User.Id + "','Se agrego una nueva tipologia de edificacion: " + txtNomTipo.Text + ", materiales: " + materiales + " precio: " + (double)nudValorT.Value + "')");
                MessageBox.Show("Se agrego un nuevo valor", "Listo");
                inicio();
            }
        }

        private void btnModT_Click(object sender, EventArgs e)
        {
            double val = (double)nudValorT.Value;
            string materiales = cmbMat1.Text + "-" + cmbMat2.Text + "-" + cmbMat3.Text + "-" + cmbMat4.Text;
            string sql = "Update valor_mejoras set precio=" + val + " where mejora='" + txtNomTipo.Text + "' and material='" + materiales + "'";
            fdb.guardarActualizar(sql);
            udb.User = Util.Util.leerUsuarioXml();
            if(us==null)
                udb.guardarActualizar("INSERT INTO bitacora (`id_user`, `accion`) VALUES ('" + udb.User.Id + "','Se modifico la tipologiia de edificaciones: " + txtNomTipo.Text + " con el precio: " + val + "')");
            else
                udb.guardarActualizar("INSERT INTO bitacora (`id_user`, `accion`) VALUES ('" + us.User.Id + "','Se modifico la tipologiia de edificaciones: " + txtNomTipo.Text + " con el precio: " + val + "')");
            MessageBox.Show("Se modifico el valor", "Listo");
            inicio();
        }

        private void FrmModifFact_Load(object sender, EventArgs e)
        {
            inicio();
        }
        private void inicio()
        {
            cargarFactor();
            gpbDatos.Enabled = false;
            gpbDatoObra.Enabled = false;
            gpbTipo.Enabled = false;
            btnModObra.Enabled = false;
            btnModT.Enabled = false;
            gpbFactor.Enabled = false;
        }

        private void FrmModifFact_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
