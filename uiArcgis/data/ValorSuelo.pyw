import sys
from PyQt4 import QtCore, QtGui, uic
import MySQLdb
import os
import datetime
import time
from datetime import datetime
from xml.dom import minidom

global fid, fi_id, pr_id, valor_predial

global host, db, db1, port, user, password

try:
    _fromUtf8 = QtCore.QString.fromUtf8
except AttributeError:
    def _fromUtf8(s):
        return s

try:
    _encoding = QtGui.QApplication.UnicodeUTF8
    def _translate(context, text, disambig):
        return QtGui.QApplication.translate(context, text, disambig, _encoding)
except AttributeError:
    def _translate(context, text, disambig):
        return QtGui.QApplication.translate(context, text, disambig)

class MyWindow(QtGui.QMainWindow):
    def __init__(self):
        super(MyWindow, self).__init__()
        uic.loadUi('C:\uiArcgis\gui\ValorSuelo.ui', self)
        self.show()
        self.host="192.168.1.9"
        self.port=3306
        self.user="root"
        self.password="root"
        self.db="db_arcgispredio"
        self.db1="db_factoraplicacion"
        self.valor_predial=0;
        self.txtCodigo.setText(fid)
        self.txtFecha.setText(time.strftime("%d/%m/%Y"))
        self.calcularValor()
        self.btnCancelar.clicked.connect(self.cerrar)
        self.rdbSi.toggled.connect(lambda:self.calculo_impuesto(0.5))
        self.rdbNo.toggled.connect(lambda:self.calculo_impuesto(1))

    def calcularValor(self):
        list_factores=[]
        if(fid!=""):
            db=MySQLdb.connect(host=self.host, port=self.port, user=self.user, passwd=self.password, db=self.db, charset='utf8')
            sql = "SELECT fi_id, pr_id FROM predio_fichas WHERE fi_cod_catastral = '%s'" % (fid)
            try:
                cursor=db.cursor()
                cursor.execute(sql)
                results = cursor.fetchall()
                self.fi_id=0
                self.pr_id=0
                for row in results:
                    self.fi_id=row[0]
                    self.pr_id=row[1]
                cursor.close()
                if self.pr_id!=0:
                    sql="SELECT pr_apellido, pr_nombre FROM predio_propietarios WHERE pr_id = '%d'" % (self.pr_id)
                    cursor= db.cursor()
                    cursor.execute(sql)
                    results = cursor.fetchall()
                    for row in results:
                        self.txtPropietario.setText(row[0]+" "+row[1])
                    cursor.close()
                    db.close()
                    #1
                    sql="SELECT ub_loc_manz FROM predio_ubicaciones WHERE fi_id = '%d'" % (self.fi_id)
                    manzana=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_loc_manz where `desc` = '%s'"%(manzana)
                    manzana=self.desc_coef(sql, self.db1)
                    list_factores.append(manzana)
                    #2
                    sql="SELECT sp_abast_agua FROM predio_serv_instal_predios WHERE fi_id = '%d'" % (self.fi_id)
                    agua_recibe=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_agua_recibe WHERE `desc` = '%s'"%(agua_recibe)
                    agua_recibe=self.desc_coef(sql, self.db1)
                    list_factores.append(agua_recibe)
                    #3
                    sql="SELECT sp_riego FROM predio_serv_instal_predios WHERE fi_id = '%d'" % (self.fi_id)
                    riego_disp=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_disp_riego WHERE `desc` = '%s'"%(riego_disp)
                    riego_disp=self.desc_coef(sql, self.db1)
                    list_factores.append(riego_disp)
                    #4
                    sql="SELECT sp_met_riego FROM predio_serv_instal_predios WHERE fi_id = '%d'" % (self.fi_id)
                    riego_met=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_met_riego WHERE `desc` = '%s'"%(riego_met)
                    riego_met=self.desc_coef(sql, self.db1)
                    list_factores.append(riego_met)
                    #5
                    sql="SELECT sp_evac_agua_servida FROM predio_serv_instal_predios WHERE fi_id = '%d'" % (self.fi_id)
                    alcant=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_alcantarillado WHERE `desc` = '%s'"%(alcant)
                    alcant=self.desc_coef(sql, self.db1)
                    list_factores.append(alcant)
                    #6
                    sql="SELECT sp_inst_esp FROM predio_serv_instal_predios WHERE fi_id = '%d'" % (self.fi_id)
                    instal_esp=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_inst_esp WHERE `desc` = '%s'"%(instal_esp)
                    instal_esp=self.desc_coef(sql, self.db1)
                    list_factores.append(instal_esp)
                    #7
                    sql="SELECT sl_dominio FROM predio_situ_legal WHERE fi_id = '%d'" % (self.fi_id)
                    dominio=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_dominio WHERE `desc` = '%s'"%(dominio)
                    dominio=self.desc_coef(sql, self.db1)
                    list_factores.append(dominio)
                    #8
                    sql="SELECT sl_tipo_tenencia FROM predio_situ_legal WHERE fi_id = '%d'" % (self.fi_id)
                    tip_tenen=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_tenenc_vivienda WHERE `desc` = '%s'"%(tip_tenen)
                    tip_tenen=self.desc_coef(sql, self.db1)
                    list_factores.append(tip_tenen)
                    #9
                    sql="SELECT sl_trans_dominio FROM predio_situ_legal WHERE fi_id = '%d'" % (self.fi_id)
                    trans_dom=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_forma_adqui WHERE `desc` = '%s'"%(trans_dom)
                    trans_dom=self.desc_coef(sql, self.db1)
                    list_factores.append(trans_dom)
                    #10
                    sql="SELECT cfi_form_predio FROM predio_carac_fisi_predios WHERE fi_id = '%d'" % (self.fi_id)
                    forma=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_forma WHERE `desc` = '%s'"%(forma)
                    forma=self.desc_coef(sql, self.db1)
                    list_factores.append(forma)
                    #11
                    sql="SELECT cfi_topografia FROM predio_carac_fisi_predios WHERE fi_id = '%d'" % (self.fi_id)
                    pendiente=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_pendiente WHERE `desc` = '%s'"%(pendiente)
                    pendiente=self.desc_coef(sql, self.db1)
                    list_factores.append(pendiente)
                    #12
                    sql="SELECT cfi_tipo_riesgo FROM predio_carac_fisi_predios WHERE fi_id = '%d'" % (self.fi_id)
                    riesgo=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_riesgo WHERE `desc` = '%s'"%(riesgo)
                    riesgo=self.desc_coef(sql, self.db1)
                    list_factores.append(riesgo)
                    #13
                    sql="SELECT cfi_erosion FROM predio_carac_fisi_predios WHERE fi_id = '%d'" % (self.fi_id)
                    erosion=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_erosion WHERE `desc` = '%s'"%(erosion)
                    erosion=self.desc_coef(sql, self.db1)
                    list_factores.append(erosion)
                    #14
                    sql="SELECT cfi_clas_suelo FROM predio_carac_fisi_predios WHERE fi_id = '%d'" % (self.fi_id)
                    clas_suelo=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_clas_suelo WHERE `desc` = '%s'"%(clas_suelo)
                    clas_suelo=self.desc_coef(sql, self.db1)
                    list_factores.append(clas_suelo)
                    #15
                    sql="SELECT cfi_cob_nat_pred FROM predio_carac_fisi_predios WHERE fi_id = '%d'" % (self.fi_id)
                    cobertura=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_cob_nat_pred WHERE `desc` = '%s'"%(cobertura)
                    cobertura=self.desc_coef(sql, self.db1)
                    list_factores.append(cobertura)
                    #16
                    sql="SELECT cfi_ecos_rele FROM predio_carac_fisi_predios WHERE fi_id = '%d'" % (self.fi_id)
                    ecosistema=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_ecos_rele WHERE `desc` = '%s'"%(ecosistema)
                    ecosistema=self.desc_coef(sql, self.db1)
                    list_factores.append(ecosistema)
                    #17
                    sql="SELECT cfi_valor_cult FROM predio_carac_fisi_predios WHERE fi_id = '%d'" % (self.fi_id)
                    cultural=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_valor_cult WHERE `desc` = '%s'"%(cultural)
                    cultural=self.desc_coef(sql, self.db1)
                    list_factores.append(cultural)
                    #18
                    sql="SELECT iv_tipo_vial FROM predio_infra_serv_vias WHERE fi_id = '%d'" % (self.fi_id)
                    tip_via=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_tipo_via WHERE `desc` = '%s'"%(tip_via)
                    tip_via=self.desc_coef(sql, self.db1)
                    list_factores.append(tip_via)
                    #19
                    sql="SELECT iv_mat_calzada FROM predio_infra_serv_vias WHERE fi_id = '%d'" % (self.fi_id)
                    mat_via=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_rodadura WHERE `desc` = '%s'"%(mat_via)
                    mat_via=self.desc_coef(sql, self.db1)
                    list_factores.append(mat_via)
                    #20
                    sql="SELECT iv_estado_via FROM predio_infra_serv_vias WHERE fi_id = '%d'" % (self.fi_id)
                    est_via=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_est_via WHERE `desc` = '%s'"%(est_via)
                    est_via=self.desc_coef(sql, self.db1)
                    list_factores.append(est_via)
                    #21
                    sql="SELECT iv_pobla_cerca_predio FROM predio_infra_serv_vias WHERE fi_id = '%d'" % (self.fi_id)
                    pob_cercana=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_poblac_cercana WHERE `desc` = '%s'"%(pob_cercana)
                    pob_cercana=self.desc_coef(sql, self.db1)
                    list_factores.append(pob_cercana)
                    #22
                    sql="SELECT iv_alumbrado_public FROM predio_infra_serv_vias WHERE fi_id = '%d'" % (self.fi_id)
                    alumbrado=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_alumbrado WHERE `desc` = '%s'"%(alumbrado)
                    alumbrado=self.desc_coef(sql, self.db1)
                    list_factores.append(alumbrado)
                    #23
                    sql="SELECT iv_transporte_public FROM predio_infra_serv_vias WHERE fi_id = '%d'" % (self.fi_id)
                    transporte=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_transporte_publico WHERE `desc` = '%s'"%(transporte)
                    transporte=self.desc_coef(sql, self.db1)
                    list_factores.append(transporte)
                    #24
                    sql="SELECT iv_agua_consumo_hum FROM predio_infra_serv_vias WHERE fi_id = '%d'" % (self.fi_id)
                    agua_proviene=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_agua_proviene WHERE `desc` = '%s'"%(agua_proviene)
                    agua_proviene=self.desc_coef(sql, self.db1)
                    list_factores.append(agua_proviene)
                    #25
                    sql="SELECT iv_energia_electrica FROM predio_infra_serv_vias WHERE fi_id = '%d'" % (self.fi_id)
                    energia_proviene=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_electricidad WHERE `desc` = '%s'"%(energia_proviene)
                    energia_proviene=self.desc_coef(sql, self.db1)
                    list_factores.append(energia_proviene)
                    #26
                    sql="SELECT iv_acera FROM predio_infra_serv_vias WHERE fi_id = '%d'" % (self.fi_id)
                    acera=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_acera WHERE `desc` = '%s'"%(acera)
                    acera=self.desc_coef(sql, self.db1)
                    list_factores.append(acera)
                    #27
                    sql="SELECT iv_basura FROM predio_infra_serv_vias WHERE fi_id = '%d'" % (self.fi_id)
                    basura=self.desc_coef(sql, self.db)
                    sql="SELECT coef FROM factor_recolec_basura WHERE `desc` = '%s'"%(basura)
                    basura=self.desc_coef(sql, self.db1)
                    list_factores.append(basura)
                    #28, 29
                    sql="SELECT uap_uso_general, uap_detalle_uso FROM predio_uso_actual_predios WHERE fi_id = '%d' and uap_vigente='%s'" % (self.fi_id, "a")
                    uso_predio=self.desc_coef_multiple(sql, self.db)
                    list_uso_predio=[]
                    list_det_uso=[]
                    for row in uso_predio:
                        sql="SELECT coef FROM factor_uso_predio WHERE `desc` = '%s'"%(row[0])
                        list_uso_predio.append(self.desc_coef(sql, self.db1))
                        sql="SELECT coef FROM factor_unidad_vivienda WHERE `desc` = '%s'"%(row[1])
                        list_det_uso.append(self.desc_coef(sql, self.db1))
                    #list_factores.append(self.resultList(list_uso_predio))
                    #list_factores.append(self.resultList(list_det_uso))
                    #30, 49
                    sql="SELECT * FROM predio_carac_princ_edific WHERE fi_id = '%d' and cr_vigente='%s'" % (self.fi_id, "a")
                    carac_edi=self.desc_coef_multiple(sql, self.db)
                    luso=[]; lviga=[]; lcolum=[]; lpared=[]; lentrep=[]; lcontrap=[]
                    lcubierta=[]; lpiso=[]; lpuerta=[]; lventana=[]; lenlup=[]; lenluc=[]
                    lcielor=[]; lelec=[]; lsani=[]; lbanio=[]; lest=[]; lcond=[]; lacab=[]
                    for row in carac_edi:
                        sql="SELECT coef FROM factor_uso_constructivo WHERE `desc` = '%s'"%(row[4])
                        luso.append(self.desc_coef(sql, self.db1))
                        sql="SELECT coef FROM factor_viga WHERE `desc` = '%s'"%(row[7])
                        lviga.append(self.desc_coef(sql, self.db1))
                        sql="SELECT coef FROM factor_columna WHERE `desc` = '%s'"%(row[8])
                        lcolum.append(self.desc_coef(sql, self.db1))
                        sql="SELECT coef FROM factor_pared WHERE `desc` = '%s'"%(row[9])
                        lpared.append(self.desc_coef(sql, self.db1))
                        sql="SELECT coef FROM factor_entrepiso WHERE `desc` = '%s'"%(row[10])
                        lentrep.append(self.desc_coef(sql, self.db1))
                        sql="SELECT coef FROM factor_contrapiso WHERE `desc` = '%s'"%(row[11])
                        lcontrap.append(self.desc_coef(sql, self.db1))
                        sql="SELECT coef FROM factor_cubierta WHERE `desc` = '%s'"%(row[12])
                        lcubierta.append(self.desc_coef(sql, self.db1))
                        sql="SELECT coef FROM factor_piso WHERE `desc` = '%s'"%(row[13])
                        lpiso.append(self.desc_coef(sql, self.db1))
                        sql="SELECT coef FROM factor_puerta WHERE `desc` = '%s'"%(row[14])
                        lpuerta.append(self.desc_coef(sql, self.db1))
                        sql="SELECT coef FROM factor_ventana WHERE `desc` = '%s'"%(row[15])
                        lventana.append(self.desc_coef(sql, self.db1))
                        sql="SELECT coef FROM factor_revest_pared WHERE `desc` = '%s'"%(row[16])
                        lenlup.append(self.desc_coef(sql, self.db1))
                        sql="SELECT coef FROM factor_revest_cubierta WHERE `desc` = '%s'"%(row[17])
                        lenluc.append(self.desc_coef(sql, self.db1))
                        sql="SELECT coef FROM factor_tumbado WHERE `desc` = '%s'"%(row[18])
                        lcielor.append(self.desc_coef(sql, self.db1))
                        sql="SELECT coef FROM factor_est_conservacion WHERE `desc` = '%s'"%(row[19])
                        lelec.append(self.desc_coef(sql, self.db1))
                        sql="SELECT coef FROM factor_est_conservacion WHERE `desc` = '%s'"%(row[20])
                        lsani.append(self.desc_coef(sql, self.db1))
                        sql="SELECT coef FROM factor_num_banio WHERE `desc` = '%s'"%(row[21])
                        lbanio.append(self.desc_coef(sql, self.db1))
                        sql="SELECT coef FROM factor_est_conservacion WHERE `desc` = '%s'"%(row[22])
                        lest.append(self.desc_coef(sql, self.db1))
                        sql="SELECT coef FROM factor_cond_fisica WHERE `desc` = '%s'"%(row[23])
                        lcond.append(self.desc_coef(sql, self.db1))
                        sql="SELECT coef FROM factor_acabado WHERE `desc` = '%s'"%(row[25])
                        lacab.append(self.desc_coef(sql, self.db1))
                    
                    #list_factores.append(self.resultList(luso))
                    #list_factores.append(self.resultList(lviga))
                    #list_factores.append(self.resultList(lcolum))
                    #list_factores.append(self.resultList(lpared))
                    #list_factores.append(self.resultList(lentrep))
                    #list_factores.append(self.resultList(lcontrap))
                    #list_factores.append(self.resultList(lcubierta))
                    #list_factores.append(self.resultList(lpiso))
                    #list_factores.append(self.resultList(lpuerta))
                    #list_factores.append(self.resultList(lventana))
                    #list_factores.append(self.resultList(lenlup))
                    #list_factores.append(self.resultList(lenluc))
                    #list_factores.append(self.resultList(lcielor))
                    #list_factores.append(self.resultList(lelec))
                    #list_factores.append(self.resultList(lsani))
                    #list_factores.append(self.resultList(lbanio))
                    #list_factores.append(self.resultList(lest))
                    #list_factores.append(self.resultList(lcond))
                    #list_factores.append(self.resultList(lacab))
                    
                    #50
                    sql="SELECT ds_clase FROM predio_desc_suelos WHERE fi_id = '%d'" % (self.fi_id)
                    desc_suelo=self.desc_coef_multiple(sql, self.db)
                    list_desc_suelo=[]
                    for row in desc_suelo:
                        sql="SELECT coef FROM factor_clas_agrologica WHERE `desc` = '%s'"%(row[0])
                        list_desc_suelo.append(self.desc_coef(sql, self.db1))
                    list_factores.append(self.resultList(list_desc_suelo))

                    area_total=1
                    valor_base=1

                    sql="SELECT su_area_total, su_precio_base FROM predio_superficies WHERE fi_id = '%d'" % (self.fi_id)
                    valor_area=self.desc_coef_multiple(sql, self.db)
                    for row in valor_area:
                        area_total=row[0]
                        valor_base=row[1]

                    #calculo valor total
                    self.valor_predial=self.resultList(list_factores)*area_total*valor_base
                    valor_base =self.resultList(list_factores)*area_total*valor_base
                    self.txtValor.setText(str("%.2f" % valor_base))
            except MySQLdb.Error, e:
                print ("Error no contemplado:", e)

    def calculo_impuesto(self, mayor):
        #calcular impuesto predial
        try:
            tenencia=""; sbu=0; base_impo=0; servicio=0; bombero=0; ecos_r="";

            sql="SELECT cfi_ecos_rele FROM predio_carac_fisi_predios WHERE fi_id = '%d'" % (self.fi_id)
            ecos_r=self.desc_coef(sql, self.db)
            sql="SELECT sl_desc_tenencia FROM predio_situ_legal WHERE fi_id = '%d'" % (self.fi_id)
            tenencia=self.desc_coef(sql, self.db)

            if ecos_r=="Bosque Primario" or (tenencia=="Estado" or tenencia=="Municipal" or tenencia=="C. Provincial" or tenencia=="Comuna" or tenencia=="Asist. Social" or tenencia=="Gob. Extranj"):
                self.txtPredial.setText(str("%.2f" % 0))
                print 0
            else:
                sql="SELECT * FROM factor_calculo_impuesto"
                valores=self.desc_coef_multiple(sql, self.db1)
                for row in valores:
                    base_impo=row[1]; sbu=row[2]; servicio=row[3]; bombero=row[4]
                if (self.valor_predial<=(sbu*15)):
                    self.txtPredial.setText(str("%.2f" % 0))
                    print 1
                else:
                    imp_base=base_impo*1000/self.valor_predial
                    imp_bomberos=bombero/1000*self.valor_predial
                    impuesto=(imp_base+imp_bomberos+servicio)*mayor
                    self.txtPredial.setText(str("%.2f" % (impuesto)))
                    print 2
        except MySQLdb.Error, e:
                print ("Error no contemplado:", e)
        
    def desc_coef(self, sql, db):
        try:
            conexion=MySQLdb.connect(host=self.host, port=self.port, user=self.user, passwd=self.password, db=db, charset='utf8')
            cursor=conexion.cursor()
            cursor.execute(sql)
            results = cursor.fetchall()
            opcion=""
            #revisar
            for row in results:
                opcion=row[0]
            cursor.close()
            conexion.close()
            return opcion
        except MySQLdb.Error, e:
            print ("Error no contemplado:", e)
            cursor.close()
            conexion.close()

    def desc_coef_multiple(self, sql, db):
        try:
            conexion=MySQLdb.connect(host=self.host, port=self.port, user=self.user, passwd=self.password, db=db, charset='utf8')
            cursor=conexion.cursor()
            cursor.execute(sql)
            results = cursor.fetchall()
            cursor.close()
            conexion.close()
            return results
        except MySQLdb.Error, e:
            print ("Error no contemplado:", e)
            cursor.close()
            conexion.close()

    def resultList(self, x):
        mult=1
        for i in range(0, len(x)):
            if x[i]=='':
                mult=mult*1
            else:
                mult=mult*x[i]
        return mult

    def cerrar(self):
        self.close()

if __name__ == '__main__':
    try:
        os.chdir("C:\uiArcgis\data")
        fid=""
        doc = minidom.parse("clave_catastral.xml")
        # doc.getElementsByTagName returns NodeList
        name = doc.getElementsByTagName("catastro")[0]
        fid= name.firstChild.data
    except  :
        pass
    app = QtGui.QApplication(sys.argv)
    window = MyWindow()
    sys.exit(app.exec_())