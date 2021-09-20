import sys
from PyQt4 import QtGui, uic
import MySQLdb
import os
import datetime
import time
from datetime import datetime
from xml.dom import minidom

#datos conexion a la bd
global host, puerto, usuario, password, bd 

#variables globales que contienen el id de la ficha, cod catastral y el id del propietario
global clave_catrastral
global fi_id
global pr_id

#variables globales que contiene el id de la fila seleccionada y el numero de la fila
global id_fila, fila, tabla

class MyWindow(QtGui.QMainWindow):
    def __init__(self):
        super(MyWindow, self).__init__()
        uic.loadUi('C:\uiArcgis\gui\PredioViewR.ui', self)
        self.show()
        self.host="192.168.1.12"
        self.puerto=3306
        self.usuario="root"
        self.password="root"
        self.bd="db_arcgispredio"
        self.txtCodCatastro.setText(clave_catrastral)
        self.btnBuscar.clicked.connect(self.consultarPredio)#operaciones a la db al clickear
        self.btnGuardar.clicked.connect(self.actualizarPredio)
        self.btnSiguiente.clicked.connect(lambda: self.tbPredio.setCurrentIndex(1))
        self.btnSiguiente_2.clicked.connect(lambda: self.tbPredio.setCurrentIndex(2))
        self.btnSiguiente_3.clicked.connect(lambda: self.tbPredio.setCurrentIndex(3))
        self.btnSiguiente_4.clicked.connect(lambda: self.tbPredio.setCurrentIndex(4))
        self.btnSiguiente2.clicked.connect(lambda: self.tbPredio.setCurrentIndex(5))
        self.btnSiguiente_5.clicked.connect(lambda: self.tbPredio.setCurrentIndex(6))
        self.btnSiguiente_6.clicked.connect(lambda: self.tbPredio.setCurrentIndex(7))
        self.tblUso.cellClicked.connect(self.obtenerIdFilaUso)
        self.tblSemoviviente.cellClicked.connect(self.obtenerIdFilaSemoviente)
        self.tblMaquinaria.cellClicked.connect(self.obtenerIdFilaMaquinaria)
        self.tblCarac.cellClicked.connect(self.obtenerIdFilaCarac)
        self.tblObraInterna.cellClicked.connect(self.obtenerIdFilaInterna)
        self.tblOtraInversion.cellClicked.connect(self.obtenerIdFilaOtra)
        self.pushButton.clicked.connect(lambda: self.tblUso.insertRow(0))
        self.pushButton_2.clicked.connect(lambda: self.modificarVigencia(self.tblUso, "UPDATE predio_uso_actual_predios set uap_vigente='%s' WHERE fi_id='%d' and uap_id='%s'" % ("b", self.fi_id, self.id_fila)))
        self.pushButton_6.clicked.connect(lambda: self.tblSemoviviente.insertRow(0))
        self.pushButton_5.clicked.connect(lambda: self.modificarVigencia(self.tblSemoviviente, "UPDATE predio_semovientes set se_vigente='%s' WHERE fi_id='%d' and se_id='%s'" % ("b", self.fi_id, self.id_fila)))
        self.pushButton_7.clicked.connect(lambda: self.tblMaquinaria.insertRow(0))
        self.pushButton_8.clicked.connect(lambda: self.modificarVigencia(self.tblMaquinaria, "UPDATE predio_maq_equipos set mq_vigente='%s' WHERE fi_id='%d' and mq_id='%s'" % ("b", self.fi_id, self.id_fila)))
        self.pushButton_9.clicked.connect(lambda: self.tblCarac.insertRow(0))
        self.pushButton_10.clicked.connect(lambda: self.modificarVigencia(self.tblCarac, "UPDATE predio_carac_princ_edific set cr_vigente='%s' WHERE fi_id='%d' and cr_id='%s'" % ("b", self.fi_id, self.id_fila)))
        self.pushButton_12.clicked.connect(lambda: self.tblObraInterna.insertRow(0))
        self.pushButton_11.clicked.connect(lambda: self.modificarVigencia(self.tblObraInterna, "UPDATE predio_ir_internas set iri_vigente='%s' WHERE fi_id='%d' and iri_id='%s'" % ("b", self.fi_id, self.id_fila)))
        self.pushButton_14.clicked.connect(lambda: self.tblOtraInversion.insertRow(0))
        self.pushButton_13.clicked.connect(lambda: self.modificarVigencia(self.tblOtraInversion, "UPDATE predio_ir_otras set iro_vigente='%s' WHERE fi_id='%d' and iro_id='%s'" % ("b", self.fi_id, self.id_fila)))

    def obtenerIdFilaUso(self, row, column):
        #obtiene el id de la fila seleccionada
        try:
            num_col=self.tblUso.columnCount()
            item = self.tblUso.item(row, num_col-1)
            self.id_fila = item.text()
            self.fila=row
        except  :
            pass
    def obtenerIdFilaSemoviente(self, row, column):
        #obtiene el id de la fila seleccionada
        try:
            num_col=self.tblSemoviviente.columnCount()
            item = self.tblSemoviviente.item(row, num_col-1)
            self.id_fila = item.text()
            self.fila=row
        except  :
            pass
    def obtenerIdFilaMaquinaria(self, row, column):
        #obtiene el id de la fila seleccionada
        try:
            num_col=self.tblMaquinaria.columnCount()
            item = self.tblMaquinaria.item(row, num_col-1)
            self.id_fila = item.text()
            self.fila=row
        except  :
            pass
    def obtenerIdFilaCarac(self, row, column):
        #obtiene el id de la fila seleccionada
        try:
            num_col=self.tblCarac.columnCount()
            item = self.tblCarac.item(row, num_col-1)
            self.id_fila = item.text()
            self.fila=row
        except  :
            pass
    def obtenerIdFilaInterna(self, row, column):
        #obtiene el id de la fila seleccionada
        try:
            num_col=self.tblObraInterna.columnCount()
            item = self.tblObraInterna.item(row, num_col-1)
            self.id_fila = item.text()
            self.fila=row
        except  :
            pass
    def obtenerIdFilaOtra(self, row, column):
        #obtiene el id de la fila seleccionada
        try:
            num_col=self.tblOtraInversion.columnCount()
            item = self.tblOtraInversion.item(row, num_col-1)
            self.id_fila = item.text()
            self.fila=row
        except  :
            pass

    def modificarVigencia(self, tabla, sql):
        #cambia la vigencia de la caracteristica y remueve la fila de la tabla
        try:
            db=MySQLdb.connect(host=self.host, port=self.puerto, user=self.usuario, passwd=self.password, db=self.bd)
            cursor=db.cursor()
            cursor=db.cursor()
            cursor.execute(sql)
            db.commit()
            cursor.close()
            tabla.removeRow(self.fila)
        except MySQLdb.Error, e:
            print ("Error no contemplado:", e)

    def consultarPredio(self):
        db=MySQLdb.connect(host=self.host, port=self.puerto, user=self.usuario, passwd=self.password, db=self.bd)
        cursor=db.cursor()
        if(self.txtCodCatastro.text()!=""):
            codigo_catastral=self.txtCodCatastro.text()
            sql = "SELECT * FROM predio_fichas WHERE fi_cod_catastral = '%s'" % (codigo_catastral)
            try:
                cursor.execute(sql)
                results = cursor.fetchall()
                self.fi_id=0
                self.pr_id=0
                for row in results:
                    self.fi_id=row[0]
                    self.txtCodProv.setText(row[1])
                    self.txtCodCant.setText(row[2])
                    self.txtCodParr.setText(row[3])
                    self.txtCodZona.setText(row[4])
                    self.txtCodSect.setText(row[5])
                    self.txtCodPoli.setText(row[6])
                    self.txtCodPred.setText(row[7])
                    self.txtCodDivi.setText(row[8])
                    self.txtCodAnte.setText(row[10])
                    self.pr_id=row[11]
                cursor.close()
                fi_id=self.fi_id
                pr_id=self.pr_id
                if pr_id!=0:
                    sql="SELECT * FROM predio_propietarios WHERE pr_id = '%d'" % (pr_id)
                    cursor= db.cursor()
                    cursor.execute(sql)
                    results = cursor.fetchall()
                    for row in results:
                        self.txtDni.setText(row[1])
                        self.txtApellido.setText(row[2])
                        self.txtNombre.setText(row[3])
                        self.datFecNac.setDate(row[4])
                        self.txtPropAnt.setText(row[5])
                        self.txtDireccion.setText(row[6])
                        self.txtTelefono.setText(row[7])
                        self.txtEmail.setText(row[8])
                        pos=self.cboResPro.findText(row[9])
                        self.cboResPro.setCurrentIndex(pos)
                        self.txtDirRep.setText(row[10])
                        self.txtDniRep.setText(row[11])
                        self.txtNomRep.setText(row[12])
                    #caracteristicas fisicas del predio
                    sql="SELECT * FROM predio_carac_fisi_predios WHERE fi_id = '%d'" % (fi_id)
                    cursor= db.cursor()
                    cursor.execute(sql)
                    results = cursor.fetchall()
                    for row in results:
                        pos=self.cboForm.findText(row[1])
                        self.cboForm.setCurrentIndex(pos)
                        pos=self.cboTopo.findText(row[2])
                        self.cboTopo.setCurrentIndex(pos)
                        pos=self.cboTipRiego.findText(row[3])
                        self.cboTipRiego.setCurrentIndex(pos)
                        pos=self.cboErosion.findText(row[4])
                        self.cboErosion.setCurrentIndex(pos)
                    cursor.close()
                    #escritura
                    sql="SELECT * FROM predio_escrituras WHERE fi_id = '%d'" % (fi_id)
                    cursor= db.cursor()
                    cursor.execute(sql)
                    results = cursor.fetchall()
                    for row in results:
                        self.txtNroNotaria.setText(row[1])
                        self.txtCanNotaria.setText(row[2])
                        self.txtNroRegPro.setText(row[3])
                        self.datFecNotaria.setDate(row[4])
                    cursor.close()
                    #identificacion divisiones
                    sql="SELECT * FROM predio_ident_divisiones WHERE fi_id = '%d'" % (fi_id)
                    cursor= db.cursor()
                    cursor.execute(sql)
                    results = cursor.fetchall()
                    for row in results:
                        self.txtResDiv.setText(row[1])
                        self.datFecAprob.setDate(row[2])
                        self.txtNomLote.setText(row[3])
                        self.txtNroLote.setText(row[4])
                        self.txtCodJace.setText(row[5])
                    cursor.close()
                    #servicios instalados en la via
                    sql="SELECT * FROM predio_infra_serv_vias WHERE fi_id = '%d'" % (fi_id)
                    cursor= db.cursor()
                    cursor.execute(sql)
                    results = cursor.fetchall()
                    for row in results:
                        pos=self.cboJerVial.findText(row[1])
                        self.cboJerVial.setCurrentIndex(pos)
                        pos=self.cboMatVia.findText(row[2])
                        self.cboMatVia.setCurrentIndex(pos)
                        pos=self.cboSerAgua.findText(row[3])
                        self.cboSerAgua.setCurrentIndex(pos)
                        pos=self.cboSerEle.findText(row[4])
                        self.cboSerEle.setCurrentIndex(pos)
                        pos=self.cboSerAlu.findText(row[5])
                        self.cboSerAlu.setCurrentIndex(pos)
                        pos=self.cboEstVia.findText(row[6])
                        self.cboEstVia.setCurrentIndex(pos)
                        pos=self.cboPobPred.findText(row[7])
                        self.cboPobPred.setCurrentIndex(pos)
                        pos=self.cboSerAlc.findText(row[8])
                        self.cboSerAlc.setCurrentIndex(pos)
                        pos=self.cboSerTel.findText(row[9])
                        self.cboSerTel.setCurrentIndex(pos)
                        pos=self.cboErosion.findText(row[10])
                        self.cboSerTra.setCurrentIndex(pos)
                    cursor.close()
                    #observaciones
                    sql="SELECT * FROM predio_observaciones WHERE fi_id = '%d'" % (fi_id)
                    cursor= db.cursor()
                    cursor.execute(sql)
                    results = cursor.fetchall()
                    for row in results:
                        self.txaObservacion.setPlainText(row[1])
                    cursor.close()
                    #responsables
                    sql="SELECT * FROM predio_responsables WHERE fi_id = '%d'" % (fi_id)
                    cursor= db.cursor()
                    cursor.execute(sql)
                    results = cursor.fetchall()
                    for row in results:
                        self.txtEmpadronado.setText(row[1])
                        self.datEmpadronado.setDate(row[2])
                        self.txtRevisado.setText(row[3])
                        self.datRevisado.setDate(row[4])
                        self.txtDigitado.setText(row[5])
                        self.datDigitado.setDate(row[6])
                        self.txtJefe.setText(row[7])
                        self.datJefe.setDate(row[8])
                    cursor.close()
                    #servicios instalados en el predio
                    sql="SELECT * FROM predio_serv_instal_predios WHERE fi_id = '%d'" % (fi_id)
                    cursor= db.cursor()
                    cursor.execute(sql)
                    results = cursor.fetchall()
                    for row in results:
                        pos=self.cboAgua.findText(row[1])
                        self.cboAgua.setCurrentIndex(pos)
                        pos=self.cboAlcan.findText(row[2])
                        self.cboAlcan.setCurrentIndex(pos)
                        pos=self.cboEle.findText(row[3])
                        self.cboEle.setCurrentIndex(pos)
                        pos=self.cboRiego.findText(row[4])
                        self.cboRiego.setCurrentIndex(pos)
                        self.txtNroMedAgua.setText(row[5])
                        self.txtNroMedElec.setText(row[6])
                        self.spnNroAgua.setValue(row[7])
                        self.spnNroElec.setValue(row[8])
                        self.spnNroLin.setValue(row[9])
                        self.txtNumPrinTel.setText(row[10])
                    cursor.close()
                    #situacion legal
                    sql="SELECT * FROM predio_situ_legal WHERE fi_id = '%d'" % (fi_id)
                    cursor= db.cursor()
                    cursor.execute(sql)
                    results = cursor.fetchall()
                    for row in results:
                        pos=self.cboDominio.findText(row[1])
                        self.cboDominio.setCurrentIndex(pos)
                        pos=self.cboDescTenencia.findText(row[2])
                        self.cboDescTenencia.setCurrentIndex(pos)
                        pos=self.cboTransDominio.findText(row[3])
                        self.cboTransDominio.setCurrentIndex(pos)
                        pos=self.cboTenencia.findText(row[4])
                        self.cboTenencia.setCurrentIndex(pos)
                    cursor.close()
                    #superficie
                    sql="SELECT * FROM predio_superficies WHERE fi_id = '%d'" % (fi_id)
                    cursor= db.cursor()
                    cursor.execute(sql)
                    results = cursor.fetchall()
                    for row in results:
                        self.spnBloqUno.setValue(row[1])
                        self.spnBloqDos.setValue(row[2])
                        self.spnBloqTres.setValue(row[3])
                        self.spnBloqCuatro.setValue(row[4])
                        self.spnBloqCinco.setValue(row[5])
                        self.spnBloqSeis.setValue(row[6])
                        self.spnAreaFrente.setValue(row[7])
                        self.spnTotalTerreno.setValue(row[8])
                    cursor.close()
                    #ubicaciones
                    sql="SELECT * FROM predio_ubicaciones WHERE fi_id = '%d'" % (fi_id)
                    cursor= db.cursor()
                    cursor.execute(sql)
                    results = cursor.fetchall()
                    for row in results:
                        self.txtCodSiti.setText(row[1])
                        self.txtNomSiti.setText(row[2])
                        self.txtCodVia.setText(row[3])
                        self.txtNomVia.setText(row[4])
                        self.txtNomPred.setText(row[5])
                        self.spnCoorX.setValue(row[6])
                        self.spnCoorY.setValue(row[7])
                    cursor.close()
                    #uso ocupacion del predio
                    sql="SELECT * FROM predio_uso_ocup_predios WHERE fi_id = '%d'" % (fi_id)
                    cursor= db.cursor()
                    cursor.execute(sql)
                    results = cursor.fetchall()
                    for row in results:
                        self.txtCodEco.setText(row[1])
                        self.txtDescEco.setText(row[2])
                        pos=self.cboTipUsu.findText(row[3])
                        self.cboTipUsu.setCurrentIndex(pos)
                        self.spnNroTer.setValue(row[4])
                        self.spnNroCon.setValue(row[5])
                    cursor.close()
                    #caracteristicas principales edificio
                    sql="SELECT * FROM predio_carac_princ_edific WHERE fi_id = '%d' and cr_vigente='%s'" % (fi_id, "a")
                    cursor= db.cursor()
                    cursor.execute(sql)
                    results = cursor.fetchall()
                    num_fila=0
                    for row in results:
                        self.tblCarac.insertRow(0)
                        self.tblCarac.setItem(num_fila, 0, QtGui.QTableWidgetItem(row[1]))
                        self.tblCarac.setItem(num_fila, 1, QtGui.QTableWidgetItem(row[2]))
                        self.tblCarac.setItem(num_fila, 2, QtGui.QTableWidgetItem(row[3]))
                        self.tblCarac.setItem(num_fila, 3, QtGui.QTableWidgetItem(row[4]))
                        self.tblCarac.setItem(num_fila, 4, QtGui.QTableWidgetItem(str(row[5])))
                        self.tblCarac.setItem(num_fila, 5, QtGui.QTableWidgetItem(str(row[6])))
                        self.tblCarac.setItem(num_fila, 6, QtGui.QTableWidgetItem(row[7]))
                        self.tblCarac.setItem(num_fila, 7, QtGui.QTableWidgetItem(row[8]))
                        self.tblCarac.setItem(num_fila, 8, QtGui.QTableWidgetItem(row[9]))
                        self.tblCarac.setItem(num_fila, 9, QtGui.QTableWidgetItem(row[10]))
                        self.tblCarac.setItem(num_fila, 10, QtGui.QTableWidgetItem(row[11]))
                        self.tblCarac.setItem(num_fila, 11, QtGui.QTableWidgetItem(row[12]))
                        self.tblCarac.setItem(num_fila, 12, QtGui.QTableWidgetItem(row[13]))
                        self.tblCarac.setItem(num_fila, 13, QtGui.QTableWidgetItem(row[14]))
                        self.tblCarac.setItem(num_fila, 14, QtGui.QTableWidgetItem(row[15]))
                        self.tblCarac.setItem(num_fila, 15, QtGui.QTableWidgetItem(row[16]))
                        self.tblCarac.setItem(num_fila, 16, QtGui.QTableWidgetItem(row[17]))
                        self.tblCarac.setItem(num_fila, 17, QtGui.QTableWidgetItem(row[18]))
                        self.tblCarac.setItem(num_fila, 18, QtGui.QTableWidgetItem(row[19]))
                        self.tblCarac.setItem(num_fila, 19, QtGui.QTableWidgetItem(row[20]))
                        self.tblCarac.setItem(num_fila, 20, QtGui.QTableWidgetItem(row[21]))
                        self.tblCarac.setItem(num_fila, 21, QtGui.QTableWidgetItem(str(row[0])))
                        num_fila=num_fila+1
                    cursor.close()
                    #inversiones internas
                    sql="SELECT * FROM predio_ir_internas WHERE fi_id = '%d' and iri_vigente='%s'" % (fi_id, "a")
                    cursor= db.cursor()
                    cursor.execute(sql)
                    results = cursor.fetchall()
                    num_fila=0
                    for row in results:
                        self.tblObraInterna.insertRow(0)
                        self.tblObraInterna.setItem(num_fila, 0, QtGui.QTableWidgetItem(row[1]))
                        self.tblObraInterna.setItem(num_fila, 1, QtGui.QTableWidgetItem(row[2]))
                        self.tblObraInterna.setItem(num_fila, 2, QtGui.QTableWidgetItem(row[3]))
                        self.tblObraInterna.setItem(num_fila, 3, QtGui.QTableWidgetItem(str(row[4])))
                        self.tblObraInterna.setItem(num_fila, 4, QtGui.QTableWidgetItem(str(row[5])))
                        self.tblObraInterna.setItem(num_fila, 5, QtGui.QTableWidgetItem(row[6]))
                        self.tblObraInterna.setItem(num_fila, 6, QtGui.QTableWidgetItem(str(row[0])))
                        num_fila=num_fila+1
                    cursor.close()
                    #otras inversiones
                    sql="SELECT * FROM predio_ir_otras WHERE fi_id = '%d' and iro_vigente='%s'" % (fi_id, "a")
                    cursor= db.cursor()
                    cursor.execute(sql)
                    results = cursor.fetchall()
                    num_fila=0
                    for row in results:
                        self.tblOtraInversion.insertRow(0)
                        self.tblOtraInversion.setItem(num_fila, 0, QtGui.QTableWidgetItem(row[1]))
                        self.tblOtraInversion.setItem(num_fila, 1, QtGui.QTableWidgetItem(row[2]))
                        self.tblOtraInversion.setItem(num_fila, 2, QtGui.QTableWidgetItem(str(row[3])))
                        self.tblOtraInversion.setItem(num_fila, 3, QtGui.QTableWidgetItem(str(row[4])))
                        self.tblOtraInversion.setItem(num_fila, 4, QtGui.QTableWidgetItem(str(row[5])))
                        self.tblOtraInversion.setItem(num_fila, 5, QtGui.QTableWidgetItem(str(row[0])))
                        num_fila=num_fila+1
                    cursor.close()
                    #linderos
                    sql="SELECT * FROM predio_linderos WHERE fi_id = '%d'" % (fi_id)
                    cursor= db.cursor()
                    cursor.execute(sql)
                    results = cursor.fetchall()
                    for row in results:
                        if row[1]=="norte":
                            self.txtNorte.setText(row[2])
                        if row[1]=="sur":
                            self.txtSur.setText(row[2])
                        if row[1]=="este":
                            self.txtEste.setText(row[2])
                        if row[1]=="oeste":
                            self.txtOeste.setText(row[2])
                    cursor.close()
                    #maquinarias y equipos
                    sql="SELECT * FROM predio_maq_equipos WHERE fi_id = '%d' and mq_vigente='%s'" % (fi_id, "a")
                    cursor= db.cursor()
                    cursor.execute(sql)
                    results = cursor.fetchall()
                    num_fila=0
                    for row in results:
                        self.tblMaquinaria.insertRow(0)
                        self.tblMaquinaria.setItem(num_fila, 0, QtGui.QTableWidgetItem(row[1]))
                        self.tblMaquinaria.setItem(num_fila, 1, QtGui.QTableWidgetItem(row[2]))
                        self.tblMaquinaria.setItem(num_fila, 2, QtGui.QTableWidgetItem(row[3]))
                        self.tblMaquinaria.setItem(num_fila, 3, QtGui.QTableWidgetItem(row[4]))
                        self.tblMaquinaria.setItem(num_fila, 4, QtGui.QTableWidgetItem(row[5]))
                        self.tblMaquinaria.setItem(num_fila, 5, QtGui.QTableWidgetItem(row[6]))
                        self.tblMaquinaria.setItem(num_fila, 6, QtGui.QTableWidgetItem(str(row[0])))
                        num_fila=num_fila+1
                    cursor.close()
                    #referencias cartograficas
                    sql="SELECT * FROM predio_ref_cartog WHERE fi_id = '%d'" % (fi_id)
                    cursor= db.cursor()
                    cursor.execute(sql)
                    results = cursor.fetchall()
                    for row in results:
                        if row[1]=="topografica":
                            self.txtTopografica.setText(row[2])
                        if row[1]=="satelital":
                            self.txtSatelital.setText(row[2])
                        if row[1]=="area":
                            self.txtArea.setText(row[2])
                        if row[1]=="otro":
                            self.txtOtros.setText(row[2])
                    cursor.close()
                    #semovientes
                    sql="SELECT * FROM predio_semovientes WHERE fi_id = '%d' and se_vigente='%s'" % (fi_id, "a")
                    cursor= db.cursor()
                    cursor.execute(sql)
                    results = cursor.fetchall()
                    num_fila=0
                    for row in results:
                        self.tblSemoviviente.insertRow(0)
                        self.tblSemoviviente.setItem(num_fila, 0, QtGui.QTableWidgetItem(row[1]))
                        self.tblSemoviviente.setItem(num_fila, 1, QtGui.QTableWidgetItem(row[2]))
                        self.tblSemoviviente.setItem(num_fila, 2, QtGui.QTableWidgetItem(row[3]))
                        self.tblSemoviviente.setItem(num_fila, 3, QtGui.QTableWidgetItem(str(row[4])))
                        self.tblSemoviviente.setItem(num_fila, 4, QtGui.QTableWidgetItem(row[5]))
                        self.tblSemoviviente.setItem(num_fila, 5, QtGui.QTableWidgetItem(row[6]))
                        self.tblSemoviviente.setItem(num_fila, 6, QtGui.QTableWidgetItem(str(row[0])))
                        num_fila=num_fila+1
                    cursor.close()
                    #uso actual del predio
                    sql="SELECT * FROM predio_uso_actual_predios WHERE fi_id = '%d' and uap_vigente='%s'" % (fi_id, "a")
                    cursor= db.cursor()
                    cursor.execute(sql)
                    results = cursor.fetchall()
                    num_fila=0
                    for row in results:
                        self.tblUso.insertRow(num_fila)
                        self.tblUso.setItem(num_fila, 0, QtGui.QTableWidgetItem(row[1]))
                        self.tblUso.setItem(num_fila, 1, QtGui.QTableWidgetItem(row[2]))
                        self.tblUso.setItem(num_fila, 2, QtGui.QTableWidgetItem(row[3]))
                        self.tblUso.setItem(num_fila, 3, QtGui.QTableWidgetItem(row[4]))
                        self.tblUso.setItem(num_fila, 4, QtGui.QTableWidgetItem(row[5]))
                        self.tblUso.setItem(num_fila, 5, QtGui.QTableWidgetItem(str(row[6])))
                        self.tblUso.setItem(num_fila, 6, QtGui.QTableWidgetItem(str(row[7])))
                        self.tblUso.setItem(num_fila, 7, QtGui.QTableWidgetItem(str(row[0])))
                        num_fila=num_fila+1
                    cursor.close()
                else:
                    QtGui.QMessageBox.about(self, "Advertencia", """Predio no registrado""")
                db.close()
            except MySQLdb.Error, e:
                print ("Error no contemplado:", e)
                cursor.close()
                db.close()
        else:
            QtGui.QMessageBox.about(self, "Advertencia", """Es obligatorio tener la clave catastral""")

    def actualizarPredio(self):
        try:
            db=MySQLdb.connect(host=self.host, port=self.puerto, user=self.usuario, passwd=self.password, db=self.bd)
            #datos propietario
            propietario=[self.txtDni.text(), self.txtApellido.text(), self.txtNombre.text(), self.datFecNac.date().toPyDate(), self.txtPropAnt.text(), self.txtDireccion.text(), self.txtTelefono.text(), self.txtEmail.text(), self.cboResPro.currentText(), self.txtDirRep.text(), self.txtDniRep.text(), self.txtNomRep.text()]
            sql= "UPDATE predio_propietarios set pr_dni ='%s', pr_apellido='%s', pr_nombre='%s', pr_fec_nac='%s', pr_prop_ant='%s', pr_dir='%s', pr_tel='%s', pr_email='%s', pr_residencia_pro='%s', pr_rep_legal_dir='%s', pr_rep_legal_dni='%s', pr_rep_legal_nombre='%s' WHERE pr_id='%d'" % \
       		        (propietario[0], propietario[1], propietario[2], propietario[3], propietario[4], propietario[5], propietario[6], propietario[7], propietario[8], propietario[9], propietario[10], propietario[11], self.pr_id)
            cursor=db.cursor()
            cursor.execute(sql)
            db.commit()
            cursor.close()
            #ubicaciones
            cursor=db.cursor()
            ubicacion=[self.txtCodSiti.text(), self.txtNomSiti.text(), self.txtCodVia.text(), self.txtNomVia.text(), self.txtNomPred.text(), self.spnCoorX.value(), self.spnCoorY.value(), self.fi_id]
            sql= "UPDATE predio_ubicaciones set ub_cod_sector='%s', ub_nombre_sector='%s', ub_cod_via='%s', ub_nombre_via='%s', ub_nombre_predio='%s', ub_coordenadas_x='%s', ub_coordenadas_y='%s'WHERE fi_id='%d'" % \
                (ubicacion[0], ubicacion[1], ubicacion[2], ubicacion[3], ubicacion[4], ubicacion[5], ubicacion[6], ubicacion[7])
            cursor.execute(sql)
            db.commit()
            cursor.close()
            #linderos
            for x in ["norte", "sur", "este", "oeste"]:
                cursor=db.cursor()
                if x=="norte" and self.txtNorte.text()!="":
                    sql= "UPDATE predio_linderos set li_nom_propietario='%s' WHERE fi_id='%d' and li_punto_card='%s'" % \
                        (self.txtNorte.text(), self.fi_id, x)
                if x=="sur" and self.txtSur.text()!="":
                    sql= "UPDATE predio_linderos set li_nom_propietario='%s' WHERE fi_id='%d' and li_punto_card='%s'" % \
                	    (self.txtSur.text(), self.fi_id, x)
                if x=="este" and self.txtEste.text()!="":
                    sql= "UPDATE predio_linderos set li_nom_propietario='%s' WHERE fi_id='%d' and li_punto_card='%s'" % \
                        (self.txtEste.text(), self.fi_id, x)
                if x=="oeste" and self.txtOeste.text()!="":
                    sql= "UPDATE predio_linderos set li_nom_propietario='%s' WHERE fi_id='%d' and li_punto_card='%s'" % \
                	    (self.txtOeste.text(), self.fi_id, x)
                cursor.execute(sql)
                db.commit()
                cursor.close()
            #referencias cartograficas
            if self.txtTopografica.text()!="" or self.txtSatelital.text()!="" or self.txtArea.text()!="" or self.txtOtros.text()!="":
                for i in ["topografica", "satelital", "area", "otro"]:
                    cursor=db.cursor()
                    if i=="topografica":
                        sql= "UPDATE predio_ref_cartog set rc_cod='%s' WHERE fi_id='%d' and rc_descripcion='%s'" % \
                	        (self.txtTopografica.text(), self.fi_id, i)
                    if i=="satelital":
                        sql= "UPDATE predio_ref_cartog set rc_cod='%s' WHERE fi_id='%d' and rc_descripcion='%s'" % \
                	        (self.txtSatelital.text(), self.fi_id, i)
                    if i=="area":
                        sql= "UPDATE predio_ref_cartog set rc_cod='%s' WHERE fi_id='%d' and rc_descripcion='%s'" % \
                	        (self.txtArea.text(), self.fi_id, i)
                    if i=="otro":
                        sql= "UPDATE predio_ref_cartog set rc_cod='%s' WHERE fi_id='%d' and rc_descripcion='%s'" % \
                	        (self.txtOtros.text(), self.fi_id, i)
                    cursor.execute(sql)
                    db.commit()
                    cursor.close()
            #superficies
            cursor=db.cursor()
            superficie=[self.spnBloqUno.value(), self.spnBloqDos.value(), self.spnBloqTres.value(), self.spnBloqCuatro.value(), self.spnBloqCinco.value(), self.spnBloqSeis.value(), self.spnAreaFrente.value(), self.spnTotalTerreno.value(), self.fi_id]
            sql= "UPDATE predio_superficies set su_bloque_uno='%d', su_bloque_dos='%d', su_bloque_tres='%d', su_bloque_cuatro='%d', su_bloque_cinco='%d', su_bloque_seis='%d', su_frente='%d', su_area_total='%d' WHERE fi_id='%d'" % \
                (superficie[0], superficie[1], superficie[2], superficie[3], superficie[4], superficie[5], superficie[6], superficie[7], superficie[8])
            cursor.execute(sql)
            db.commit()
            cursor.close()
            #situacion legal
            cursor=db.cursor()
            situacion_legal=[self.cboDominio.currentText(), self.cboDescTenencia.currentText(), self.cboTransDominio.currentText(), self.cboTenencia.currentText(), self.fi_id]
            sql= "UPDATE predio_situ_legal set sl_dominio='%s', sl_desc_tenencia='%s', sl_trans_dominio='%s', sl_tipo_tenencia='%s' WHERE fi_id='%d'" % \
                (situacion_legal[0], situacion_legal[1], situacion_legal[2], situacion_legal[3], situacion_legal[4])
            cursor.execute(sql)
            db.commit()
            cursor.close()
            #escrituras
            sql="SELECT * FROM predio_escrituras WHERE fi_id = '%d'" % (self.fi_id)
            cursor= db.cursor()
            cursor.execute(sql)
            results = cursor.fetchall()
            cursor.close()
            if results!=():
                cursor=db.cursor()
                escritura=[self.txtNroNotaria.text(), self.txtCanNotaria.text(), self.txtNroRegPro.text(), self.datFecNotaria.date().toPyDate(), self.fi_id]
                sql= "UPDATE predio_escrituras set es_nro_notaria='%s', es_canton='%s', es_nro_reg_prop='%s', es_fecha='%s' WHERE fi_id='%d'" % \
       		        (escritura[0], escritura[1], escritura[2], escritura[3], escritura[4])
                cursor.execute(sql)
                db.commit()
                cursor.close()
            else:
                cursor=db.cursor()
                escritura=[self.txtNroNotaria.text(), self.txtCanNotaria.text(), self.txtNroRegPro.text(), self.datFecNotaria.date().toPyDate(), self.fi_id]
                sql= "INSERT INTO predio_escrituras(es_nro_notaria, es_canton, es_nro_reg_prop, es_fecha, fi_id) VALUES ('%s', '%s', '%s', '%s','%d')" % \
       		        (escritura[0], escritura[1], escritura[2], escritura[3], escritura[4])
                cursor.execute(sql)
                db.commit()
                cursor.close()
            #identificacion de division
            cursor=db.cursor()
            sql="SELECT * FROM predio_ident_divisiones WHERE fi_id = '%d'" % (self.fi_id)
            cursor= db.cursor()
            cursor.execute(sql)
            results = cursor.fetchall()
            cursor.close()
            if results!=():
                cursor=db.cursor()
                division=[self.txtResDiv.text(), self.datFecAprob.date().toPyDate(), self.txtNomLote.text(), self.txtNroLote.text(), self.txtCodJace.text(), self.fi_id]
                sql= "UPDATE predio_ident_divisiones set id_responsable_aprob='%s', id_fecha_aprobacion='%s', id_nombre_lotizacion='%s', id_nro_lote='%s', id_cod_jace='%s' WHERE fi_id='%d'" % \
                    (division[0], division[1], division[2], division[3], division[4], division[5])
                cursor.execute(sql)
                db.commit()
                cursor.close()
            else:
                cursor=db.cursor()
                division=[self.txtResDiv.text(), self.datFecAprob.date().toPyDate(), self.txtNomLote.text(), self.txtNroLote.text(), self.txtCodJace.text(), self.fi_id]
                sql= "INSERT INTO predio_ident_divisiones(id_responsable_aprob, id_fecha_aprobacion, id_nombre_lotizacion, id_nro_lote, id_cod_jace, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s','%d')" % \
                    (division[0], division[1], division[2], division[3], division[4], division[5])
                cursor.execute(sql)
                db.commit()
                cursor.close()
            #uso y ocupacion del predio
            cursor=db.cursor()
            uso_predio=[self.txtCodEco.text(), self.txtDescEco.text(), self.cboTipUsu.currentText(), self.spnNroTer.value(), self.spnNroCon.value(), self.fi_id]
            sql= "UPDATE predio_uso_ocup_predios set up_cod_economico='%s', up_desc_economico='%s', up_tipo_usuario='%s', up_nro_bloq_terminado='%s', up_nro_bloq_construccion='%s' WHERE fi_id='%d'" % \
       		    (uso_predio[0], uso_predio[1], uso_predio[2], uso_predio[3], uso_predio[4], uso_predio[5])
            cursor.execute(sql)
            db.commit()
            cursor.close()
            #caracteristicas fisicas predio
            cursor=db.cursor()
            carac_predio=[self.cboForm.currentText(), self.cboTopo.currentText(), self.cboTipRiego.currentText(), self.cboErosion.currentText(), self.fi_id]
            sql= "UPDATE predio_carac_fisi_predios set cfi_form_predio='%s', cfi_topografia='%s', cfi_tipo_riesgo='%s', cfi_erosion='%s' WHERE fi_id='%d'" % \
       		    (carac_predio[0], carac_predio[1], carac_predio[2], carac_predio[3], carac_predio[4])
            cursor.execute(sql)
            db.commit()
            cursor.close()
            #infraestructura y servicios en la via
            cursor=db.cursor()
            serv_via=[self.cboJerVial.currentText(), self.cboMatVia.currentText(), self.cboSerAgua.currentText(), self.cboSerEle.currentText(), self.cboSerAlu.currentText(), self.cboEstVia.currentText(), self.cboPobPred.currentText(), self.cboSerAlc.currentText(), self.cboSerTel.currentText(), self.cboSerTra.currentText(), self.fi_id]
            sql= "UPDATE predio_infra_serv_vias set iv_tipo_vial='%s', iv_mat_calzada='%s', iv_agua_consumo_hum='%s', iv_energia_electrica='%s', iv_alumbrado_public='%s', iv_estado_via='%s', iv_pobla_cerca_predio='%s', iv_alcantarillado='%s', iv_telefonia='%s', iv_transporte_public='%s' WHERE fi_id='%d'" % \
       		    (serv_via[0], serv_via[1], serv_via[2], serv_via[3], serv_via[4], serv_via[5], serv_via[6], serv_via[7], serv_via[8], serv_via[9], serv_via[10])
            cursor.execute(sql)
            db.commit()
            cursor.close()
            #servicios instalados en el predio
            cursor=db.cursor()
            serv_predio=[self.cboAgua.currentText(), self.cboAlcan.currentText(), self.cboEle.currentText(), self.cboRiego.currentText(), self.txtNroMedAgua.text(), self.txtNroMedElec.text(), self.spnNroAgua.value(), self.spnNroElec.value(), self.spnNroLin.value(), self.txtNumPrinTel.text(), self.fi_id]
            sql= "UPDATE predio_serv_instal_predios set sp_abast_agua='%s', sp_evac_agua_servida='%s', sp_energia_elect='%s', sp_riego='%s', sp_num_med_prin_agua='%s', sp_num_med_prin_elec='%s', sp_num_medidores_agua='%s', sp_num_medidores_elec='%s', sp_num_lineas_tel='%s', sp_num_telf_prin='%s' WHERE fi_id='%d'" % \
       		    (serv_predio[0], serv_predio[1], serv_predio[2], serv_predio[3], serv_predio[4], serv_predio[5], serv_predio[6], serv_predio[7], serv_predio[8], serv_predio[9], serv_predio[10])
            cursor.execute(sql)
            db.commit()
            cursor.close()
            #observaciones
            cursor=db.cursor()
            obs=[self.txaObservacion.toPlainText(), self.fi_id]
            sql= "UPDATE predio_observaciones set ob_desc='%s' WHERE fi_id='%d'" % \
       		    (obs[0], obs[1])
            cursor.execute(sql)
            db.commit()
            cursor.close()
            #responsables
            cursor=db.cursor()
            resp=[self.txtEmpadronado.text(), self.datEmpadronado.date().toPyDate(), self.txtRevisado.text(), self.datRevisado.date().toPyDate(), self.txtDigitado.text(), self.datDigitado.date().toPyDate(), self.txtJefe.text(), self.datJefe.date().toPyDate(), self.fi_id]
            sql= "UPDATE predio_responsables set re_empadronado='%s', re_fecha_emp='%s', re_revisado='%s', re_fecha_rev='%s', re_digitado='%s', re_fecha_dig='%s', re_jefe_avaluo_catas='%s', re_fecha_jefe_aval_catas='%s' WHERE fi_id='%d'" % \
       		    (resp[0], resp[1], resp[2], resp[3], resp[4], resp[5], resp[6], resp[7], resp[8])
            cursor.execute(sql)
            db.commit()
            cursor.close()
            #uso actual del predio
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
                id=self.tblUso.item(x,7)
                if(id==None):
                    id=""
                else:
                    id=self.tblUso.item(x,7).text()
                if id=="":
                    sql= "INSERT INTO predio_uso_actual_predios(uap_cod, uap_uso_general, uap_detalle_uso, uap_edad, uap_conservacion, uap_extencion, uap_porcentaje, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s', '%s','%d')" % \
       		            (codigo, uso, detalle, edad, conservacion, extencion, porcentaje, self.fi_id)
                else:
                    sql= "UPDATE predio_uso_actual_predios set uap_cod='%s', uap_uso_general='%s', uap_detalle_uso='%s', uap_edad='%s', uap_conservacion='%s', uap_extencion='%s', uap_porcentaje='%s' WHERE fi_id='%d' and uap_id='%s'" % \
       		            (codigo, uso, detalle, edad, conservacion, extencion, porcentaje, self.fi_id, id)
                cursor.execute(sql)
                db.commit()
                cursor.close()
            #semovientes
            numFilas=self.tblSemoviviente.rowCount()
            for x in range(0, numFilas):
                cursor=db.cursor()
                codigo=self.tblSemoviviente.item(x, 0).text()
                especie=self.tblSemoviviente.item(x, 1).text()
                raza=self.tblSemoviviente.item(x, 2).text()
                edad=self.tblSemoviviente.item(x, 3).text()
                sangre=self.tblSemoviviente.item(x, 4).text()
                numero=self.tblSemoviviente.item(x, 5).text()
                id=self.tblSemoviviente.item(x, 6)
                if(id==None):
                    id=""
                else:
                    id=self.tblSemoviviente.item(x, 6).text()
                if id=="":
                    sql= "INSERT INTO predio_semovientes(se_cod, se_especie, se_raza, se_edad, se_sangre, se_numero, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s','%d')" % \
       		            (codigo, especie, raza, edad, sangre, numero, self.fi_id)
                else:
                    id=self.tblSemoviviente.item(x, 6).text()
                    sql= "UPDATE predio_semovientes set se_cod='%s', se_especie='%s', se_raza='%s', se_edad='%s', se_sangre='%s', se_numero='%s' WHERE fi_id='%d' and se_id='%s'" % \
       		            (codigo, especie, raza, edad, sangre, numero, self.fi_id, id)
                cursor.execute(sql)
                db.commit()
                cursor.close()
            #maquinaria y equipos
            numFilas=self.tblMaquinaria.rowCount()
            for x in range(0, numFilas):
                cursor=db.cursor()
                codigo=self.tblMaquinaria.item(x, 0).text()
                denominacion=self.tblMaquinaria.item(x, 1).text()
                marca=self.tblMaquinaria.item(x, 2).text()
                anio=self.tblMaquinaria.item(x, 3).text()
                estado=self.tblMaquinaria.item(x, 4).text()
                numero=self.tblMaquinaria.item(x, 5).text()
                id=self.tblMaquinaria.item(x, 6)
                if(id==None):
                    id=""
                else:
                    id=self.tblMaquinaria.item(x, 6).text()
                if id=="":
                    sql= "INSERT INTO predio_maq_equipos(mq_cod, mq_denomicacion, mq_marca, mq_anio, mq_estado, mq_numero, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s','%d')" % \
       		            (codigo, denominacion, marca, anio, estado, numero, self.fi_id)
                else:
                    id=self.tblMaquinaria.item(x, 6).text()
                    sql= "UPDATE predio_maq_equipos set mq_cod='%s', mq_denomicacion='%s', mq_marca='%s', mq_anio='%s', mq_estado='%s', mq_numero='%s' WHERE fi_id='%d' and mq_id='%s'" % \
       		            (codigo, denominacion, marca, anio, estado, numero, self.fi_id, id)
                cursor.execute(sql)
                db.commit()
                cursor.close()
            #caracteristicas principales de la edificacion
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
                id=self.tblCarac.item(x, 21)
                if(id==None):
                    id=""
                else:
                    id=self.tblCarac.item(x, 21).text()
                if id=="":
                    sql= "INSERT INTO predio_carac_princ_edific(cr_nro_bloque, cr_nro_piso, cr_cod_uso, cr_uso, cr_area_piso, cr_area_bloque, cr_mat_estruc_viga, cr_mat_estruc_columna, cr_mat_estruc_pared, cr_mat_estruc_entrepiso, cr_mat_estruc_cubierta, cr_mat_acab_piso, cr_mat_acab_puerta, cr_mat_acab_ventana, cr_mat_acab_enlucido, cr_mat_acab_cielorraso, cr_instal_electrica, cr_instal_sanitaria, cr_instal_banio, cr_estado, cr_anio_constr, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s','%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s','%s', '%s', '%s', '%s', '%s','%d')" % \
       		            (nrobloque, nropiso, coduso, uso, areapiso, areabloque, meviga, mecolumna, mepared, meentrepiso, mecubierta, mapiso, mapuerta, maventana, maenlucido, macielorraso, ielectrica, isanitaria, ibanio, estado, aniocons, self.fi_id)
                else:
                    id=self.tblCarac.item(x, 6).text()
                    sql= "UPDATE predio_carac_princ_edific set cr_nro_bloque='%s', cr_nro_piso='%s', cr_cod_uso='%s', cr_uso='%s', cr_area_piso='%s', cr_area_bloque='%s', cr_mat_estruc_viga='%s', cr_mat_estruc_columna='%s', cr_mat_estruc_pared='%s', cr_mat_estruc_entrepiso='%s', cr_mat_estruc_cubierta='%s', cr_mat_acab_piso='%s', cr_mat_acab_puerta='%s', cr_mat_acab_ventana='%s', cr_mat_acab_enlucido='%s', cr_mat_acab_cielorraso='%s', cr_instal_electrica='%s', cr_instal_sanitaria='%s', cr_instal_banio='%s', cr_estado='%s', cr_anio_constr='%s' WHERE fi_id='%d' and cr_id='%s'" % \
       		            (nrobloque, nropiso, coduso, uso, areapiso, areabloque, meviga, mecolumna, mepared, meentrepiso, mecubierta, mapiso, mapuerta, maventana, maenlucido, macielorraso, ielectrica, isanitaria, ibanio, estado, aniocons, self.fi_id, id)
                cursor.execute(sql)
                db.commit()
                cursor.close()
            #inversiones internas
            numFilas=self.tblObraInterna.rowCount()
            for x in range(0, numFilas):
                cursor=db.cursor()
                codigo=self.tblObraInterna.item(x, 0).text()
                descripcion=self.tblObraInterna.item(x, 1).text()
                material=self.tblObraInterna.item(x, 2).text()
                cantidad=self.tblObraInterna.item(x, 3).text()
                unidad=self.tblObraInterna.item(x, 4).text()
                estado=self.tblObraInterna.item(x, 5).text()
                id=self.tblObraInterna.item(x, 6)
                if(id==None):
                    id=""
                else:
                    id=self.tblObraInterna.item(x, 6).text()
                if id=="":
                    sql= "INSERT INTO predio_ir_internas(iri_cod, iri_desc, iri_tipo_mat, iri_cant, iri_unidad, iri_estado, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s','%d')" % \
       		            (codigo, descripcion, material, cantidad, unidad, estado, self.fi_id)
                else:
                    id=self.tblObraInterna.item(x, 6).text()
                    sql= "UPDATE predio_ir_internas set iri_cod='%s', iri_desc='%s', iri_tipo_mat='%s', iri_cant='%s', iri_unidad='%s', iri_estado='%s' WHERE fi_id='%d' and iri_id='%s'" % \
       		            (codigo, descripcion, material, cantidad, unidad, estado, self.fi_id, id)
                cursor.execute(sql)
                db.commit()
                cursor.close()
            #otras inversiones
            numFilas=self.tblOtraInversion.rowCount()
            for x in range(0, numFilas):
                cursor=db.cursor()
                codigo=self.tblOtraInversion.item(x, 0).text()
                descripcion=self.tblOtraInversion.item(x, 1).text()
                area=self.tblOtraInversion.item(x, 2).text()
                unidad=self.tblOtraInversion.item(x, 3).text()
                cantidad=self.tblOtraInversion.item(x, 4).text()
                id=self.tblOtraInversion.item(x, 5)
                if(id==None):
                    id=""
                else:
                    id=self.tblOtraInversion.item(x, 5).text()
                if id=="":
                    sql= "INSERT INTO predio_ir_otras(iro_cod, iro_desc, iro_superficie, iro_unid, iro_cant, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s','%d')" % \
                        (codigo, descripcion, area, unidad, cantidad, self.fi_id)
                else:
                    id=self.tblOtraInversion.item(x, 5).text()
                    sql= "UPDATE predio_ir_otras set iro_cod='%s', iro_desc='%s', iro_superficie='%s', iro_unid='%s', iro_cant='%s' WHERE fi_id='%d' and iro_id='%s'" % \
                        (codigo, descripcion, area, unidad, cantidad, self.fi_id, id)
                cursor.execute(sql)
                db.commit()
                cursor.close()
            db.close()
            QtGui.QMessageBox.about(self, "Datos Actualizados", """Los datos se han actualizado correctamente""")
            self.close()
        except MySQLdb.Error, e:
            print ("Error no contemplado:", e)


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