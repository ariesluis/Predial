import sys
from PyQt4 import QtGui, uic
import MySQLdb
import os
from xml.dom import minidom

#datos conexion a la bd
global host, puerto, usuario, password, bd 
global clave_catrastral

class MyWindow(QtGui.QMainWindow):
    def __init__(self):
        super(MyWindow, self).__init__()
        uic.loadUi('C:\uiArcgis\gui\PredioView.ui', self)
        self.show()
        self.host="192.168.1.12"
        self.puerto=3306
        self.usuario="root"
        self.password="root"
        self.bd="db_arcgispredio"
        self.txtClaveCatastral.setText(clave_catrastral)
        self.comprobarDatos()
        self.btnGuardar.clicked.connect(self.guardarPersona)#evento click del boton llamando una funcion
        self.btnSiguiente.clicked.connect(lambda: self.tbPredio.setCurrentIndex(1))
        self.btnSiguiente_2.clicked.connect(lambda: self.tbPredio.setCurrentIndex(2))
        self.btnSiguiente_3.clicked.connect(lambda: self.tbPredio.setCurrentIndex(3))
        self.btnSiguiente_4.clicked.connect(lambda: self.tbPredio.setCurrentIndex(4))
        self.btnSiguiente2.clicked.connect(lambda: self.tbPredio.setCurrentIndex(5))
        self.btnSiguiente_5.clicked.connect(lambda: self.tbPredio.setCurrentIndex(6))
        self.btnSiguiente_6.clicked.connect(lambda: self.tbPredio.setCurrentIndex(7))
        self.pushButton.clicked.connect(lambda: self.tblUso.insertRow(0))
        self.pushButton_2.clicked.connect(lambda: self.tblUso.removeRow(0))
        self.pushButton_6.clicked.connect(lambda: self.tblSemoviviente.insertRow(0))
        self.pushButton_5.clicked.connect(lambda: self.tblSemoviviente.removeRow(0))
        self.pushButton_7.clicked.connect(lambda: self.tblMaquinaria.insertRow(0))
        self.pushButton_8.clicked.connect(lambda: self.tblMaquinaria.removeRow(0))
        self.pushButton_9.clicked.connect(lambda: self.tblCarac.insertRow(0))
        self.pushButton_10.clicked.connect(lambda: self.tblCarac.removeRow(0))
        self.pushButton_12.clicked.connect(lambda: self.tblObraInterna.insertRow(0))
        self.pushButton_11.clicked.connect(lambda: self.tblObraInterna.removeRow(0))
        self.pushButton_14.clicked.connect(lambda: self.tblOtraInversion.insertRow(0))
        self.pushButton_13.clicked.connect(lambda: self.tblOtraInversion.removeRow(0))

    def comprobarDatos(self):
        if(self.txtClaveCatastral.text()!=""):
            codigo_catastral=self.txtClaveCatastral.text()
            try:
                db=MySQLdb.connect(host=self.host, port=self.puerto, user=self.usuario, passwd=self.password, db=self.bd)
                sql = "SELECT * FROM predio_fichas WHERE fi_cod_catastral = '%s'" % (codigo_catastral)
                cursor= db.cursor()
                cursor.execute(sql)
                results = cursor.fetchall()
                if results!=():
                    self.lblNota.setText("Predio ya registrado")
                else:
                    self.lblNota.setText("")
            except:
                pass
        else:
            self.lblNota.setText("Predio no tiene clave")

    def guardarPersona(self):
        db=MySQLdb.connect(host=self.host, port=self.puerto, user=self.usuario, passwd=self.password, db=self.bd)
        codigoCatastro=self.txtCodProv.text()+ self.txtCodCant.text()+ self.txtCodParr.text()+ self.txtCodZona.text()+ self.txtCodSect.text()+self.txtCodPoli.text()+ self.txtCodPred.text()+ self.txtCodDivi.text()
        if self.txtApellido.text()!="" and self.txtCodProv.text()!="" and self.txtCodCant.text()!="" and self.txtCodParr.text()!="" and codigoCatastro==self.txtClaveCatastral.text() and self.lblNota.text()=="":
            try:
                cursor=db.cursor()
                propietario=[self.txtDni.text(), self.txtApellido.text(), self.txtNombre.text(), self.datFecNac.date().toPyDate(), self.txtPropAnt.text(), self.txtDireccion.text(), self.txtTelefono.text(), self.txtEmail.text(), self.cboResPro.currentText(), self.txtDirRep.text(), self.txtDniRep.text(), self.txtNomRep.text()]
                sql= "INSERT INTO predio_propietarios(pr_dni, pr_apellido, pr_nombre, pr_fec_nac, pr_prop_ant, pr_dir, pr_tel, pr_email, pr_residencia_pro, pr_rep_legal_dir, pr_rep_legal_dni, pr_rep_legal_nombre) VALUES ('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s')" % \
       		        (propietario[0], propietario[1], propietario[2], propietario[3], propietario[4], propietario[5], propietario[6], propietario[7], propietario[8], propietario[9], propietario[10], propietario[11])
                cursor.execute(sql)
                db.commit()
                cursor.close()
                #traer ultimo propietario registrado
                cursor=db.cursor()
                sql="SELECT MAX(pr_id) FROM predio_propietarios"
                cursor.execute(sql)
                pr=cursor.fetchall()
                id_pr=0#conserva el id del propietario
                for row in pr:
                    id_pr=row[0]
                cursor.close()
                #guardar datos en la tabla ficha
                cursor=db.cursor()
                ficha=[self.txtCodProv.text(), self.txtCodCant.text(), self.txtCodParr.text(), self.txtCodZona.text(), self.txtCodSect.text(), self.txtCodPoli.text(), self.txtCodPred.text(), self.txtCodDivi.text(), self.txtClaveCatastral.text(), self.txtCodAnte.text(), id_pr]
                sql= "INSERT INTO predio_fichas(fi_cod_prov, fi_cod_can, fi_cod_par, fi_cod_zon, fi_cod_sec, fi_cod_pol, fi_cod_pre, fi_cod_div, fi_cod_catastral, fi_cod_ant_pre, pr_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%d')" % \
       		        (ficha[0], ficha[1], ficha[2], ficha[3], ficha[4], ficha[5], ficha[6], ficha[7], ficha[8], ficha[9], ficha[10])
                cursor.execute(sql)
                db.commit()
                cursor.close()
       	        #traer ultima ficha registro
                cursor=db.cursor()
                id_fi=0
                sql="SELECT MAX(fi_id) FROM predio_fichas"
                cursor.execute(sql)
                fi=cursor.fetchall()
                for row in fi:
                    id_fi=row[0]
                cursor.close()
       	        #guargar datos en la tabla ubicacion
                cursor=db.cursor()
                ubicacion=[self.txtCodSiti.text(), self.txtNomSiti.text(), self.txtCodVia.text(), self.txtNomVia.text(), self.txtNomPred.text(), self.spnCoorX.value(), self.spnCoorY.value(), id_fi]
                sql= "INSERT INTO predio_ubicaciones(ub_cod_sector, ub_nombre_sector, ub_cod_via, ub_nombre_via, ub_nombre_predio, ub_coordenadas_x, ub_coordenadas_y, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%d')" % \
                    (ubicacion[0], ubicacion[1], ubicacion[2], ubicacion[3], ubicacion[4], ubicacion[5], ubicacion[6], ubicacion[7])
                cursor.execute(sql)
                db.commit()
                cursor.close()
		        #guardar datos en la tabla linderos
                for x in ["norte", "sur", "este", "oeste"]:
                    cursor=db.cursor()
                    if x=="norte" and self.txtNorte.text()!="":
                        sql= "INSERT INTO predio_linderos(li_punto_card, li_nom_propietario, fi_id) VALUES ('%s', '%s', '%d')" % \
                	        (x, self.txtNorte.text(), id_fi)
                    if x=="sur" and self.txtSur.text()!="":
                        sql= "INSERT INTO predio_linderos(li_punto_card, li_nom_propietario, fi_id) VALUES ('%s', '%s', '%d')" % \
                	        (x, self.txtSur.text(), id_fi)
                    if x=="este" and self.txtEste.text()!="":
                        sql= "INSERT INTO predio_linderos(li_punto_card, li_nom_propietario, fi_id) VALUES ('%s', '%s', '%d')" % \
                	        (x, self.txtEste.text(), id_fi)
                    if x=="oeste" and self.txtOeste.text()!="":
                        sql= "INSERT INTO predio_linderos(li_punto_card, li_nom_propietario, fi_id) VALUES ('%s', '%s', '%d')" % \
                	        (x, self.txtOeste.text(), id_fi)
                    cursor.execute(sql)
                    db.commit()
                    cursor.close()
		        #guardar datos en la tabla referencias cartograficas
                if self.txtTopografica.text()!="" or self.txtSatelital.text()!="" or self.txtArea.text()!="" or self.txtOtros.text()!="":
                    for i in ["topografica", "satelital", "area", "otro"]:
                        cursor=db.cursor()
                        if i=="topografica":
                            sql= "INSERT INTO predio_ref_cartog(rc_descripcion, rc_cod, fi_id) VALUES ('%s', '%s', '%d')" % \
                	            (i, self.txtTopografica.text(), id_fi)
                        if i=="satelital":
                            sql= "INSERT INTO predio_ref_cartog(rc_descripcion, rc_cod, fi_id) VALUES ('%s', '%s', '%d')" % \
                	            (i, self.txtSatelital.text(), id_fi)
                        if i=="area":
                            sql= "INSERT INTO predio_ref_cartog(rc_descripcion, rc_cod, fi_id) VALUES ('%s', '%s', '%d')" % \
                	            (i, self.txtArea.text(), id_fi)
                        if i=="otro":
                            sql= "INSERT INTO predio_ref_cartog(rc_descripcion, rc_cod, fi_id) VALUES ('%s', '%s', '%d')" % \
                	            (i, self.txtOtros.text(), id_fi)
                        cursor.execute(sql)
                        db.commit()
                        cursor.close()
                #guardar datos en la tabla superficies
                cursor=db.cursor()
                superficie=[self.spnBloqUno.value(), self.spnBloqDos.value(), self.spnBloqTres.value(), self.spnBloqCuatro.value(), self.spnBloqCinco.value(), self.spnBloqSeis.value(), self.spnAreaFrente.value(), self.spnTotalTerreno.value(), id_fi]
                sql= "INSERT INTO predio_superficies(su_bloque_uno, su_bloque_dos, su_bloque_tres, su_bloque_cuatro, su_bloque_cinco, su_bloque_seis, su_frente, su_area_total, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%d')" % \
                    (superficie[0], superficie[1], superficie[2], superficie[3], superficie[4], superficie[5], superficie[6], superficie[7], superficie[8])
                cursor.execute(sql)
                db.commit()
                cursor.close()
                #guardar datos en la tabla situacion legal
                cursor=db.cursor()
                situacion_legal=[self.cboDominio.currentText(), self.cboDescTenencia.currentText(), self.cboTransDominio.currentText(), self.cboTenencia.currentText(), id_fi]
                sql= "INSERT INTO predio_situ_legal(sl_dominio, sl_desc_tenencia, sl_trans_dominio, sl_tipo_tenencia, fi_id) VALUES ('%s', '%s', '%s', '%s','%d')" % \
                    (situacion_legal[0], situacion_legal[1], situacion_legal[2], situacion_legal[3], situacion_legal[4])
                cursor.execute(sql)
                db.commit()
                cursor.close()
                #guardar datos en la tabla escritura
                if self.txtNroNotaria.text()!="" and self.txtCanNotaria.text()!="":
                    cursor=db.cursor()
                    escritura=[self.txtNroNotaria.text(), self.txtCanNotaria.text(), self.txtNroRegPro.text(), self.datFecNotaria.date().toPyDate(), id_fi]
                    sql= "INSERT INTO predio_escrituras(es_nro_notaria, es_canton, es_nro_reg_prop, es_fecha, fi_id) VALUES ('%s', '%s', '%s', '%s','%d')" % \
       		            (escritura[0], escritura[1], escritura[2], escritura[3], escritura[4])
                    cursor.execute(sql)
                    db.commit()
                    cursor.close()
                #guardar datos en la identificacion de divisiones
                if self.txtResDiv.text()!="":
                    cursor=db.cursor()
                    division=[self.txtResDiv.text(), self.datFecAprob.date().toPyDate(), self.txtNomLote.text(), self.txtNroLote.text(), self.txtCodJace.text(), id_fi]
                    sql= "INSERT INTO predio_ident_divisiones(id_responsable_aprob, id_fecha_aprobacion, id_nombre_lotizacion, id_nro_lote, id_cod_jace, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s','%d')" % \
                        (division[0], division[1], division[2], division[3], division[4], division[5])
                    cursor.execute(sql)
                    db.commit()
                    cursor.close()
                #guardar datos en la uso y ocupacion predio
                cursor=db.cursor()
                uso_predio=[self.txtCodEco.text(), self.txtDescEco.text(), self.cboTipUsu.currentText(), self.spnNroTer.value(), self.spnNroCon.value(), id_fi]
                sql= "INSERT INTO predio_uso_ocup_predios(up_cod_economico, up_desc_economico, up_tipo_usuario, up_nro_bloq_terminado, up_nro_bloq_construccion, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s','%d')" % \
       		        (uso_predio[0], uso_predio[1], uso_predio[2], uso_predio[3], uso_predio[4], uso_predio[5])
                cursor.execute(sql)
                db.commit()
                cursor.close()
                #guardar datos en la tabla caracteristicas fisicas predio
                cursor=db.cursor()
                carac_predio=[self.cboForm.currentText(), self.cboTopo.currentText(), self.cboTipRiego.currentText(), self.cboErosion.currentText(), id_fi]
                sql= "INSERT INTO predio_carac_fisi_predios(cfi_form_predio, cfi_topografia, cfi_tipo_riesgo, cfi_erosion, fi_id) VALUES ('%s', '%s', '%s', '%s','%d')" % \
       		        (carac_predio[0], carac_predio[1], carac_predio[2], carac_predio[3], carac_predio[4])
                cursor.execute(sql)
                db.commit()
                cursor.close()
                #guardar datos en la tabla infraestructura y servicios en la via
                cursor=db.cursor()
                serv_via=[self.cboJerVial.currentText(), self.cboMatVia.currentText(), self.cboSerAgua.currentText(), self.cboSerEle.currentText(), self.cboSerAlu.currentText(), self.cboEstVia.currentText(), self.cboPobPred.currentText(), self.cboSerAlc.currentText(), self.cboSerTel.currentText(), self.cboSerTra.currentText(), id_fi]
                sql= "INSERT INTO predio_infra_serv_vias(iv_tipo_vial, iv_mat_calzada, iv_agua_consumo_hum, iv_energia_electrica, iv_alumbrado_public, iv_estado_via, iv_pobla_cerca_predio, iv_alcantarillado, iv_telefonia, iv_transporte_public, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s','%d')" % \
       		        (serv_via[0], serv_via[1], serv_via[2], serv_via[3], serv_via[4], serv_via[5], serv_via[6], serv_via[7], serv_via[8], serv_via[9], serv_via[10])
                cursor.execute(sql)
                db.commit()
                cursor.close()
                #guardar datos en la tabla servicios instalados en el predio
                cursor=db.cursor()
                serv_predio=[self.cboAgua.currentText(), self.cboAlcan.currentText(), self.cboEle.currentText(), self.cboRiego.currentText(), self.txtNroMedAgua.text(), self.txtNroMedElec.text(), self.spnNroAgua.value(), self.spnNroElec.value(), self.spnNroLin.value(), self.txtNumPrinTel.text(), id_fi]
                sql= "INSERT INTO predio_serv_instal_predios(sp_abast_agua, sp_evac_agua_servida, sp_energia_elect, sp_riego, sp_num_med_prin_agua, sp_num_med_prin_elec, sp_num_medidores_agua, sp_num_medidores_elec, sp_num_lineas_tel, sp_num_telf_prin, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s','%d')" % \
       		        (serv_predio[0], serv_predio[1], serv_predio[2], serv_predio[3], serv_predio[4], serv_predio[5], serv_predio[6], serv_predio[7], serv_predio[8], serv_predio[9], serv_predio[10])
                cursor.execute(sql)
                db.commit()
                cursor.close()
                #guardar datos en la tabla uso actual del predio
                numFilas=self.tblUso.rowCount()
                for x in range(0, numFilas):
                    cursor=db.cursor()
                    codigo=self.tblUso.item(x, 0).text()
                    uso=self.tblUso.item(x, 1).text()
                    detalle=self.tblUso.item(x, 2).text()
                    edad=self.tblUso.item(x, 3).text()
                    conservacion=self.tblUso.item(x, 4).text()
                    extencion=self.tblUso.item(x, 5).text()
                    porcentaje=self.tblUso.item(x, 6).text()
                    sql= "INSERT INTO predio_uso_actual_predios(uap_cod, uap_uso_general, uap_detalle_uso, uap_edad, uap_conservacion, uap_extencion, uap_porcentaje, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s', '%s','%d')" % \
       		            (codigo, uso, detalle, edad, conservacion, extencion, porcentaje, id_fi)
                    cursor.execute(sql)
                    db.commit()
                    cursor.close()
                #guardar datos en la tabla semovientes
                numFilas=self.tblSemoviviente.rowCount()
                for x in range(0, numFilas):
                    cursor=db.cursor()
                    codigo=self.tblSemoviviente.item(x, 0).text()
                    especie=self.tblSemoviviente.item(x, 1).text()
                    raza=self.tblSemoviviente.item(x, 2).text()
                    edad=self.tblSemoviviente.item(x, 3).text()
                    sangre=self.tblSemoviviente.item(x, 4).text()
                    numero=self.tblSemoviviente.item(x, 5).text()
                    sql= "INSERT INTO predio_semovientes(se_cod, se_especie, se_raza, se_edad, se_sangre, se_numero, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s','%d')" % \
       		            (codigo, especie, raza, edad, sangre, numero, id_fi)
                    cursor.execute(sql)
                    db.commit()
                    cursor.close()
                #guardar datos en la tabla maquinaria y equipos
                numFilas=self.tblMaquinaria.rowCount()
                for x in range(0, numFilas):
                    cursor=db.cursor()
                    codigo=self.tblMaquinaria.item(x, 0).text()
                    denominacion=self.tblMaquinaria.item(x, 1).text()
                    marca=self.tblMaquinaria.item(x, 2).text()
                    anio=self.tblMaquinaria.item(x, 3).text()
                    estado=self.tblMaquinaria.item(x, 4).text()
                    numero=self.tblMaquinaria.item(x, 5).text()
                    sql= "INSERT INTO predio_maq_equipos(mq_cod, mq_denomicacion, mq_marca, mq_anio, mq_estado, mq_numero, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s','%d')" % \
       		            (codigo, denominacion, marca, anio, estado, numero, id_fi)
                    cursor.execute(sql)
                    db.commit()
                    cursor.close()
                #guardar datos en la tabla caracteristicas principales de la edificacion
                numFilas=self.tblCarac.rowCount()
                for x in range(0, numFilas):
                    cursor=db.cursor()
                    nrobloque=self.tblCarac.item(x, 0).text()
                    nropiso=self.tblCarac.item(x, 1).text()
                    coduso=self.tblCarac.item(x, 2).text()
                    uso=self.tblCarac.item(x, 3).text()
                    areapiso=self.tblCarac.item(x, 4).text()
                    areabloque=self.tblCarac.item(x, 5).text()
                    meviga=self.tblCarac.item(x, 6).text()
                    mecolumna=self.tblCarac.item(x, 7).text()
                    mepared=self.tblCarac.item(x, 8).text()
                    meentrepiso=self.tblCarac.item(x, 9).text()
                    mecubierta=self.tblCarac.item(x, 10).text()
                    mapiso=self.tblCarac.item(x, 11).text()
                    mapuerta=self.tblCarac.item(x, 12).text()
                    maventana=self.tblCarac.item(x, 13).text()
                    maenlucido=self.tblCarac.item(x, 14).text()
                    macielorraso=self.tblCarac.item(x, 15).text()
                    ielectrica=self.tblCarac.item(x, 16).text()
                    isanitaria=self.tblCarac.item(x, 17).text()
                    ibanio=self.tblCarac.item(x, 18).text()
                    estado=self.tblCarac.item(x, 19).text()
                    aniocons=self.tblCarac.item(x, 20).text()
                    sql= "INSERT INTO predio_carac_princ_edific(cr_nro_bloque, cr_nro_piso, cr_cod_uso, cr_uso, cr_area_piso, cr_area_bloque, cr_mat_estruc_viga, cr_mat_estruc_columna, cr_mat_estruc_pared, cr_mat_estruc_entrepiso, cr_mat_estruc_cubierta, cr_mat_acab_piso, cr_mat_acab_puerta, cr_mat_acab_ventana, cr_mat_acab_enlucido, cr_mat_acab_cielorraso, cr_instal_electrica, cr_instal_sanitaria, cr_instal_banio, cr_estado, cr_anio_constr, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s','%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s','%s', '%s', '%s', '%s', '%s','%d')" % \
       		            (nrobloque, nropiso, coduso, uso, areapiso, areabloque, meviga, mecolumna, mepared, meentrepiso, mecubierta, mapiso, mapuerta, maventana, maenlucido, macielorraso, ielectrica, isanitaria, ibanio, estado, aniocons, id_fi)
                    cursor.execute(sql)
                    db.commit()
                    cursor.close()
                #guardar datos en la tabla obras internas
                numFilas=self.tblObraInterna.rowCount()
                for x in range(0, numFilas):
                    cursor=db.cursor()
                    codigo=self.tblObraInterna.item(x, 0).text()
                    descripcion=self.tblObraInterna.item(x, 1).text()
                    material=self.tblObraInterna.item(x, 2).text()
                    cantidad=self.tblObraInterna.item(x, 3).text()
                    unidad=self.tblObraInterna.item(x, 4).text()
                    estado=self.tblObraInterna.item(x, 5).text()
                    sql= "INSERT INTO predio_ir_internas(iri_cod, iri_desc, iri_tipo_mat, iri_cant, iri_unidad, iri_estado, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s','%d')" % \
       		            (codigo, descripcion, material, cantidad, unidad, estado, id_fi)
                    cursor.execute(sql)
                    db.commit()
                    cursor.close()
                #guardar datos en la tabla otras inversiones
                numFilas=self.tblOtraInversion.rowCount()
                for x in range(0, numFilas):
                    cursor=db.cursor()
                    codigo=self.tblOtraInversion.item(x, 0).text()
                    descripcion=self.tblOtraInversion.item(x, 1).text()
                    area=self.tblOtraInversion.item(x, 2).text()
                    unidad=self.tblOtraInversion.item(x, 3).text()
                    cantidad=self.tblOtraInversion.item(x, 4).text()
                    sql= "INSERT INTO predio_ir_otras(iro_cod, iro_desc, iro_superficie, iro_unid, iro_cant, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s','%d')" % \
                        (codigo, descripcion, area, unidad, cantidad, id_fi)
                    cursor.execute(sql)
                    db.commit()
                    cursor.close()
                #guardar datos en la tabla observaciones
                cursor=db.cursor()
                obs=[self.txaObservacion.toPlainText(), id_fi]
                sql= "INSERT INTO predio_observaciones(ob_desc, fi_id) VALUES ('%s','%d')" % \
       		        (obs[0], obs[1])
                cursor.execute(sql)
                db.commit()
                cursor.close()
                #guardar datos en la tabla responsables
                cursor=db.cursor()
                resp=[self.txtEmpadronado.text(), self.datEmpadronado.date().toPyDate(), self.txtRevisado.text(), self.datRevisado.date().toPyDate(), self.txtDigitado.text(), self.datDigitado.date().toPyDate(), self.txtJefe.text(), self.datJefe.date().toPyDate(), id_fi]
                sql= "INSERT INTO predio_responsables(re_empadronado, re_fecha_emp, re_revisado, re_fecha_rev, re_digitado, re_fecha_dig, re_jefe_avaluo_catas, re_fecha_jefe_aval_catas, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s','%d')" % \
       		        (resp[0], resp[1], resp[2], resp[3], resp[4], resp[5], resp[6], resp[7], resp[8])
                cursor.execute(sql)
                db.commit()
                cursor.close()
                db.close()
                QtGui.QMessageBox.about(self, "Datos Guardos", """Los datos se han guardado correctamente""")
                self.close()
            except:
                print ("Error no contemplado:", sys.exc_info()[0])
                db.rollback()
                QtGui.QMessageBox.about(self, "Error", """Error al momento de guardar los datos""")
                cursor.close()
                db.close()
        else:
            QtGui.QMessageBox.about(self, "Advertencia", """No se puede guardar datos en blanco ó clave catastral ingresada no coincide o vacia""")
            db.close()

if __name__ == '__main__':
    try:
        os.chdir("C:\uiArcgis\data")
        doc = minidom.parse("clave_catastral.xml")
        # doc.getElementsByTagName returns NodeList
        name = doc.getElementsByTagName("clave")[0]
        clave_catrastral = name.firstChild.data
    except  :
        clave_catrastral=""
    app = QtGui.QApplication(sys.argv)
    window = MyWindow()
    sys.exit(app.exec_())
