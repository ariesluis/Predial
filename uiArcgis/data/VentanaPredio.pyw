import sys
from PyQt4 import QtCore, QtGui, uic
import MySQLdb
import os
from xml.dom import minidom

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

#datos conexion a la bd
global host, puerto, usuario, password, bd 
global clave_catastral, fid

class MyWindow(QtGui.QMainWindow):
    def __init__(self):
        super(MyWindow, self).__init__()
        uic.loadUi('C:\uiArcgis\gui\PredioView.ui', self)
        self.show()
        self.host="192.168.1.9"
        self.puerto=3306
        self.usuario="root"
        self.password="root"
        self.bd="db_arcgispredio"
        self.txtClaveCatastral.setText(clave_catastral)
        self.comprobarDatos()
        self.btnGuardar.clicked.connect(self.guardarPersona)#evento click del boton llamando una funcion
        self.btnSiguiente.clicked.connect(lambda: self.tbPredio.setCurrentIndex(1))
        self.btnSiguiente_2.clicked.connect(lambda: self.tbPredio.setCurrentIndex(2))
        self.btnSiguiente_3.clicked.connect(lambda: self.tbPredio.setCurrentIndex(3))
        self.btnSiguiente_4.clicked.connect(lambda: self.tbPredio.setCurrentIndex(4))
        self.btnSiguiente2.clicked.connect(lambda: self.tbPredio.setCurrentIndex(5))
        self.btnSiguiente_5.clicked.connect(lambda: self.tbPredio.setCurrentIndex(6))
        self.btnSiguiente_6.clicked.connect(lambda: self.tbPredio.setCurrentIndex(7))
        self.pushButton.clicked.connect(self.filaUso)
        self.pushButton_2.clicked.connect(lambda: self.tblUso.removeRow(0))
        self.pushButton_6.clicked.connect(lambda: self.tblSemoviviente.insertRow(0))
        self.pushButton_5.clicked.connect(lambda: self.tblSemoviviente.removeRow(0))
        self.pushButton_7.clicked.connect(lambda: self.tblMaquinaria.insertRow(0))
        self.pushButton_8.clicked.connect(lambda: self.tblMaquinaria.removeRow(0))
        self.pushButton_9.clicked.connect(self.filaCarac)
        self.pushButton_10.clicked.connect(lambda: self.tblCarac.removeRow(0))
        self.pushButton_12.clicked.connect(self.filaInversion)
        self.pushButton_11.clicked.connect(lambda: self.tblInversion.removeRow(0))
        self.pushButton_3.clicked.connect(self.filaDesc)
        self.pushButton_4.clicked.connect(lambda: self.tblDescSuelo.removeRow(0))

    def filaUso(self):
        combo_options=["No tiene","Acuacultura",_fromUtf8("Agrícola"),"Agroindustrial",
                       "Bienestar Social","Casa Comunal","Comercial","Comercial y Residencial",
                       _fromUtf8("Conservación"),"Cultural",_fromUtf8("Diplomático"),_fromUtf8("Educación"),
                       _fromUtf8("Espacio Público"),"Financiero","Forestal","Hidrocarburos","Industrial",
                       "Institucional Privado",_fromUtf8("Institucional Público"),"Minero",
                       "Pecuario",_fromUtf8("Preservación Patrimonial"),_fromUtf8("Protección Ecológica"),
                       _fromUtf8("Recreación y Deporte"),"Religioso","Residencial","Salud","Seguridad","Servicios",
                       "Servicios Especiales","Transporte","Turismo"]
        self.tblUso.insertRow(0)
        combo=QtGui.QComboBox()
        for x in combo_options:
            combo.addItem(x)
        self.tblUso.setCellWidget(0,1,combo)
        
        combo_options=["No aplica","Bodega","Casa","Choza","Covacha","Cuarto en casa","Departamento","Local Comercial","Mediagua","Oficina","Otra Vivienda","Parqueadero","Rancho","Villa"]
        combo1=QtGui.QComboBox()
        for x in combo_options:
            combo1.addItem(x)
        self.tblUso.setCellWidget(0,2,combo1)

    def filaCarac(self):
        self.tblCarac.insertRow(0)

        uso=["No tiene", _fromUtf8("Balcón"), "Banco", _fromUtf8("Baños Sauna/Turco/Hidroma"), "Bodega", "Casa", "Casa Comunal", 
             _fromUtf8("Cuarto de Máquinas/Basura"), "Departamento", _fromUtf8("Garita/Guardianía"), 
             "Gimnasio",_fromUtf8("Guardería"),"Hospital","Hostal",_fromUtf8("Hostería"),"Hotel","Iglesia",_fromUtf8("Lavandería"),
             "Local Comercial",_fromUtf8("Malecón"),
             "Maternidad","Mercado","Mirador","Motel","Museo","Nave Industrial","Oficina",
             "Orfanato","Organismos Internacionales","Otros",
             "Parqueadero",_fromUtf8("Patio/Jardín"),_fromUtf8("Pensión"),_fromUtf8("Plantel Avícola"),"Plaza de Toros","Porqueriza",
             "Recinto Militar","Recinto Policial","Reclusorio",_fromUtf8("Representaciones Diplomáticas"),
             "Restaurante",_fromUtf8("Retén Policial"),"Sala Comunal","Sala de Cine",_fromUtf8("Sala de Exposición"),
             "Sala de Juegos",_fromUtf8("Sala de Ordeño"),"Sala de Culto/Templo",_fromUtf8("Salas de Hospitalización"),_fromUtf8("Salón de Eventos"),
             "Teatro","Terminal de Transferencia","Terminal Interprovincial","Terraza",_fromUtf8("Unidad de Policía Comunitaria")]
        combo=QtGui.QComboBox()
        for x in uso:
            combo.addItem(x)
        self.tblCarac.setCellWidget(0,3,combo)

        opciones=["No Tiene","Acero", _fromUtf8("Caña"), "Hierro",_fromUtf8("Hormigón Armado"),_fromUtf8("Madera Común"), "Madera Procesada Fina"]
        combo1=QtGui.QComboBox()
        for x in opciones:
            combo1.addItem(x)
        self.tblCarac.setCellWidget(0,6,combo1)

        opciones=["No Tiene","Acero", _fromUtf8("Caña"), "Hierro",_fromUtf8("Hormigón Armado"),_fromUtf8("Madera Común"), _fromUtf8("Mixto(Metal/Hormigón)"), _fromUtf8("Pilotaje de Hormigón Armado")]
        combo2=QtGui.QComboBox()
        for x in opciones:
            combo2.addItem(x)
        self.tblCarac.setCellWidget(0,7,combo2)

        opciones=["No Tiene","Bahareque", "Bloque", _fromUtf8("Caña"), "Ladrillo","Ferro Cemento", "Gypsum",
                  _fromUtf8("Prefabricado Hormigón Simple"), _fromUtf8("Madera Común"), "Madera Procesada Fina", "Malla", "Zinc", "Lona", "Piedra"]
        combo3=QtGui.QComboBox()
        for x in opciones:
            combo3.addItem(x)
        self.tblCarac.setCellWidget(0,8,combo3)

        opciones=["No Tiene",_fromUtf8("Acero Hormigón"), _fromUtf8("Hierro-Hormigón"), _fromUtf8("Losa Hormigón Armado"), _fromUtf8("Madera-Hormigón"), _fromUtf8("Madera Común"), "Madera Procesada Fina"]
        combo4=QtGui.QComboBox()
        for x in opciones:
            combo4.addItem(x)
        self.tblCarac.setCellWidget(0,9,combo4)

        opciones=["No Tiene",_fromUtf8("Hormigón Simple"), "Ladrillo visto", "Tierra", _fromUtf8("Caña")]
        combo05=QtGui.QComboBox()
        for x in opciones:
            combo05.addItem(x)
        self.tblCarac.setCellWidget(0,10,combo05)

        opciones=["No Tiene","Acero", _fromUtf8("Caña"), "Hierro", _fromUtf8("Losa Hormigón Armado"), _fromUtf8("Madera Común"), "Madera Procesada Fina"]
        combo5=QtGui.QComboBox()
        for x in opciones:
            combo5.addItem(x)
        self.tblCarac.setCellWidget(0,11,combo5)

        opciones=["No Tiene", _fromUtf8("Adoquín"), "Alfombra", _fromUtf8("Cerámica"), _fromUtf8("Césped Sintético"),"Duela Procesada", "En cementado",
                  "Flotante","Gres", _fromUtf8("Láminas de Tol Carrujado"), _fromUtf8("Madera Común"), _fromUtf8("Mármol"),"Marmolina","Parquet", _fromUtf8("Pintura de Alto Tráfico"),
                  "Porcelanato", _fromUtf8("Tabón"),"Vinil"]
        combo6=QtGui.QComboBox()
        for x in opciones:
            combo6.addItem(x)
        self.tblCarac.setCellWidget(0,12,combo6)

        opciones=["No Tiene","Aluminio-Vidrio", "Hierro", "Madera Panelada","Madera Tamboreada", _fromUtf8("Metálica Enrrollable"),
                  _fromUtf8("Plático Preformado"),"Tol","Vidrio Templado",_fromUtf8("Caña"),"Malla"]
        combo7=QtGui.QComboBox()
        for x in opciones:
            combo7.addItem(x)
        self.tblCarac.setCellWidget(0,13,combo7)

        opciones=["No Tiene","Aluminio",_fromUtf8("Caña"),"Hierro", _fromUtf8("Madera Común"),"Madera Procesada Fina", _fromUtf8("Plático Preformado")]
        combo8=QtGui.QComboBox()
        for x in opciones:
            combo8.addItem(x)
        self.tblCarac.setCellWidget(0,14,combo8)

        opciones=["No Tiene","Calciminas","Caucho","Esmalte", "Graniplast","Alucobond", _fromUtf8("Cerámica"),"Fachaleta","Laca"]
        combo9=QtGui.QComboBox()
        for x in opciones:
            combo9.addItem(x)
        self.tblCarac.setCellWidget(0,15,combo9)

        opciones=["No Tiene","Arena Cemento","Asbesto Cemento","Cady Paja", _fromUtf8("Cerámica"),"Chova","Ferro Cemento","Madera Ladrillo","Policarbonato","Teja Ordinaria", "Teja Vidriada","Tejuelo","Zinc"]
        combo10=QtGui.QComboBox()
        for x in opciones:
            combo10.addItem(x)
        self.tblCarac.setCellWidget(0,16,combo10)

        opciones=["No Tiene",_fromUtf8("Caña Enlucida"),"Fibra Mineral","Gypsum", "Madera Procesada Fina","Madera Triplex","Malla Enlucida"]
        combo11=QtGui.QComboBox()
        for x in opciones:
            combo11.addItem(x)
        self.tblCarac.setCellWidget(0,17,combo11)

        opciones=["Muy Bueno","Bueno","Regular","Malo","No Tiene"]
        combo12=QtGui.QComboBox()
        combo13=QtGui.QComboBox()
        for x in opciones:
            combo12.addItem(x)
            combo13.addItem(x)
        self.tblCarac.setCellWidget(0,18,combo12)
        self.tblCarac.setCellWidget(0,19,combo13)

        opciones=["No Tiene","Letrina",_fromUtf8("Medio Baño"), _fromUtf8("Baño Común"), _fromUtf8("Un Baño"),
                  _fromUtf8("Dos Baños"), _fromUtf8("Más de Dos Baños")]
        combo14=QtGui.QComboBox()
        for x in opciones:
            combo14.addItem(x)
        self.tblCarac.setCellWidget(0,20,combo14)

        opciones=["Muy Bueno","Bueno","Regular","Malo"]
        combo15=QtGui.QComboBox()
        for x in opciones:
            combo15.addItem(x)
        self.tblCarac.setCellWidget(0,21,combo15)

        opciones=["No Tiene","Abandonado","En Acabados","En Estructura","Reconstruida",_fromUtf8("Sin Modificación"),"Terminada"]
        combo16=QtGui.QComboBox()
        for x in opciones:
            combo16.addItem(x)
        self.tblCarac.setCellWidget(0,22,combo16)

        opciones=[_fromUtf8("Básico"), _fromUtf8("Económico"),"Bueno","Lujo"]
        combo17=QtGui.QComboBox()
        for x in opciones:
            combo17.addItem(x)
        self.tblCarac.setCellWidget(0,24,combo17)

    def filaInversion(self):
        self.tblInversion.insertRow(0)

        opciones=["No tiene","Aceras y Cercas","Canal de Riego Ocasional","Canal de Riego Permanente","Cerramiento",
                  _fromUtf8("Desecación de Pantanos"),
                  "Establo","Estanque/Reservorio","Funiculares", _fromUtf8("Galpón Avícola"),"Invernaderos",
                  _fromUtf8("Muro de Contención"),"Parques/Jardines","Piscina Camaronera",
                  _fromUtf8("Piscina Piscícola"), _fromUtf8("Piscina de Natación"),"Pista de Aterrizaje",
                  "Planta de Pos Cosecha","Pozo de Riego","Rellenos de Quebradas",_fromUtf8("Sala de Ordeño"),"Silo/Almacenamiento",
                  "Tendales",_fromUtf8("Vías Internas"),"Viveros","Otros"]
        combo=QtGui.QComboBox()
        for x in opciones:
            combo.addItem(x)
        self.tblInversion.setCellWidget(0,0,combo)

        opciones=[_fromUtf8("Hormigón"),"Ladrillo o Bloque","Piedra","Madera","Metal","Adobe o Tapia",_fromUtf8("Bahareque Caña Revestida"),
                  _fromUtf8("Caña"),"Aluminio y/o Vidrio",_fromUtf8("Plástico o Lona"),"Otro"]
        combo1=QtGui.QComboBox()
        for x in opciones:
            combo1.addItem(x)
        self.tblInversion.setCellWidget(0,1,combo1)

        opciones=["No Tiene","m","m2","m3","Kg","U"]
        combo2=QtGui.QComboBox()
        for x in opciones:
            combo2.addItem(x)
        self.tblInversion.setCellWidget(0,3,combo2)

        opciones=["Muy Bueno","Bueno","Regular","Malo"]
        combo3=QtGui.QComboBox()
        for x in opciones:
            combo3.addItem(x)
        self.tblInversion.setCellWidget(0,4,combo3)

    def filaDesc(self):

        self.tblDescSuelo.insertRow(0)

        opciones=["Clase I","Clase II","Clase III","Clase IV","Clase V","Clase VI","Clase VII","Clase VIII"]
        combo=QtGui.QComboBox()
        for x in opciones:
            combo.addItem(x)
        self.tblDescSuelo.setCellWidget(0,0,combo)

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
            self.lblNota.setText("")

    def guardarPersona(self):
        codigoCatastro=self.txtCodProv.text()+ self.txtCodCant.text()+ self.txtCodParr.text()+ self.txtCodZona.text()+ self.txtCodSect.text()+self.txtCodPoli.text()+ self.txtCodPred.text()+ self.txtCodDivi.text()
        self.txtClaveCatastral.setText(codigoCatastro)
        if self.txtApellido.text()!="" and self.txtCodProv.text()!="" and self.txtCodCant.text()!="" and self.txtCodParr.text()!="" and codigoCatastro==self.txtClaveCatastral.text() and self.lblNota.text()=="":
            try:
                db=MySQLdb.connect(host=self.host, port=self.puerto, user=self.usuario, passwd=self.password, db=self.bd)
                cursor=db.cursor()
                #verifica si ya fue registrado el propietario del terreno
                sql="SELECT pr_id FROM predio_propietarios WHERE pr_dni = '%s'" % (str(self.txtDni.text()))
                cursor= db.cursor()
                cursor.execute(sql)
                results = cursor.fetchall()
                id_pr=0
                for row in results:
                    id_pr=row[0]
                cursor.close()
                if id_pr<1:
                    cursor= db.cursor()
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
                ubicacion=[self.txtCodSiti.text(), self.txtNomSiti.text(), self.txtCodVia.text(), self.txtNomVia.text(), self.txtNomPred.text(), self.spnCoorX.value(), self.spnCoorY.value(), self.cboManzana.currentText(), id_fi]
                sql= "INSERT INTO predio_ubicaciones(ub_cod_sector, ub_nombre_sector, ub_cod_via, ub_nombre_via, ub_nombre_predio, ub_coordenadas_x, ub_coordenadas_y, ub_loc_manz, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%d')" % \
                    (ubicacion[0], ubicacion[1], ubicacion[2], ubicacion[3], ubicacion[4], ubicacion[5], ubicacion[6], ubicacion[7], ubicacion[8])
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
                superficie=[self.spnBloqUno.value(), self.spnBloqDos.value(), self.spnBloqTres.value(), self.spnBloqCuatro.value(), self.spnBloqCinco.value(), self.spnBloqSeis.value(), self.spnAreaFrente.value(), self.spnTotalTerreno.value(), self.spnPrecio.value(), id_fi]
                sql= "INSERT INTO predio_superficies(su_bloque_uno, su_bloque_dos, su_bloque_tres, su_bloque_cuatro, su_bloque_cinco, su_bloque_seis, su_frente, su_area_total, su_precio_base, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s',  '%s', '%d')" % \
                    (superficie[0], superficie[1], superficie[2], superficie[3], superficie[4], superficie[5], superficie[6], superficie[7], superficie[8], superficie[9])
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
                uso_predio=[self.txtCodEco.text(), self.txtDescEco.text(), self.cboTipUsu.currentText(), self.spnNroTer.value(), self.spnNroCon.value(), self.cboOcup.currentText(), id_fi]
                sql= "INSERT INTO predio_uso_ocup_predios(up_cod_economico, up_desc_economico, up_tipo_usuario, up_nro_bloq_terminado, up_nro_bloq_construccion, up_ocupacion, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s','%d')" % \
       		        (uso_predio[0], uso_predio[1], uso_predio[2], uso_predio[3], uso_predio[4], uso_predio[5], uso_predio[6])
                cursor.execute(sql)
                db.commit()
                cursor.close()
                #guardar datos en la tabla caracteristicas fisicas predio
                cursor=db.cursor()
                carac_predio=[self.cboForm.currentText(), self.cboTopo.currentText(), self.cboTipRiego.currentText(), self.cboErosion.currentText(), self.cboClasSuelo.currentText(), self.cboCobNat.currentText(), self.cboEcosRele.currentText(), self.cboValorCult.currentText(), id_fi]
                sql= "INSERT INTO predio_carac_fisi_predios(cfi_form_predio, cfi_topografia, cfi_tipo_riesgo, cfi_erosion, cfi_clas_suelo, cfi_cob_nat_pred, cfi_ecos_rele, cfi_valor_cult, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s','%d')" % \
       		        (carac_predio[0], carac_predio[1], carac_predio[2], carac_predio[3], carac_predio[4], carac_predio[5], carac_predio[6], carac_predio[7], carac_predio[8])
                cursor.execute(sql)
                db.commit()
                cursor.close()
                #guardar datos en la tabla infraestructura y servicios en la via
                cursor=db.cursor()
                serv_via=[self.cboJerVial.currentText(), self.cboMatVia.currentText(), self.cboSerAgua.currentText(), self.cboSerEle.currentText(), self.cboSerAlu.currentText(), self.cboEstVia.currentText(), self.cboPobPred.currentText(), self.cboSerAlc.currentText(), self.cboSerTel.currentText(), self.cboSerTra.currentText(), self.cboAcera.currentText(), self.cboBasura.currentText(), id_fi]
                sql= "INSERT INTO predio_infra_serv_vias(iv_tipo_vial, iv_mat_calzada, iv_agua_consumo_hum, iv_energia_electrica, iv_alumbrado_public, iv_estado_via, iv_pobla_cerca_predio, iv_alcantarillado, iv_telefonia, iv_transporte_public, iv_acera, iv_basura, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s','%s', '%s', '%d')" % \
       		        (serv_via[0], serv_via[1], serv_via[2], serv_via[3], serv_via[4], serv_via[5], serv_via[6], serv_via[7], serv_via[8], serv_via[9], serv_via[10], serv_via[11], serv_via[12])
                cursor.execute(sql)
                db.commit()
                cursor.close()
                #guardar datos en la tabla servicios instalados en el predio
                cursor=db.cursor()
                serv_predio=[self.cboAgua.currentText(), self.cboAlcan.currentText(), self.cboEle.currentText(), self.cboRiego.currentText(), self.txtNroMedAgua.text(), self.txtNroMedElec.text(), self.spnNroAgua.value(), self.spnNroElec.value(), self.spnNroLin.value(), self.txtNumPrinTel.text(), self.cboMetRiego.currentText(), self.cboInstEsp.currentText(), id_fi]
                sql= "INSERT INTO predio_serv_instal_predios(sp_abast_agua, sp_evac_agua_servida, sp_energia_elect, sp_riego, sp_num_med_prin_agua, sp_num_med_prin_elec, sp_num_medidores_agua, sp_num_medidores_elec, sp_num_lineas_tel, sp_num_telf_prin, sp_met_riego, sp_inst_esp, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%d')" % \
       		        (serv_predio[0], serv_predio[1], serv_predio[2], serv_predio[3], serv_predio[4], serv_predio[5], serv_predio[6], serv_predio[7], serv_predio[8], serv_predio[9], serv_predio[10], serv_predio[11], serv_predio[12])
                cursor.execute(sql)
                db.commit()
                cursor.close()
                #guardar datos en la tabla uso actual del predio
                numFilas=self.tblUso.rowCount()
                for x in range(0, numFilas):
                    cursor=db.cursor()
                    codigo=self.tblUso.item(x, 0).text()
                    uso=self.tblUso.cellWidget(x, 1).currentText()
                    detalle=self.tblUso.cellWidget(x, 2).currentText()
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
                    uso=self.tblCarac.cellWidget(x, 3).currentText()
                    areapiso=self.tblCarac.item(x, 4).text()
                    areabloque=self.tblCarac.item(x, 5).text()
                    meviga=self.tblCarac.cellWidget(x, 6).currentText()
                    mecolumna=self.tblCarac.cellWidget(x, 7).currentText()
                    mepared=self.tblCarac.cellWidget(x, 8).currentText()
                    meentrepiso=self.tblCarac.cellWidget(x, 9).currentText()
                    mecontrapiso=self.tblCarac.cellWidget(x, 10).currentText()
                    mecubierta=self.tblCarac.cellWidget(x, 11).currentText()
                    mapiso=self.tblCarac.cellWidget(x, 12).currentText()
                    mapuerta=self.tblCarac.cellWidget(x, 13).currentText()
                    maventana=self.tblCarac.cellWidget(x, 14).currentText()
                    maenlucidop=self.tblCarac.cellWidget(x, 15).currentText()
                    maenlucidoc=self.tblCarac.cellWidget(x, 16).currentText()
                    macielorraso=self.tblCarac.cellWidget(x, 17).currentText()
                    ielectrica=self.tblCarac.cellWidget(x, 18).currentText()
                    isanitaria=self.tblCarac.cellWidget(x, 19).currentText()
                    ibanio=self.tblCarac.cellWidget(x, 20).currentText()
                    estado=self.tblCarac.cellWidget(x, 21).currentText()
                    condicion=self.tblCarac.cellWidget(x, 22).currentText()
                    aniocons=self.tblCarac.item(x, 23).text()
                    acabado=self.tblCarac.cellWidget(x, 24).currentText()
                    sql= "INSERT INTO predio_carac_princ_edific(cr_nro_bloque, cr_nro_piso, cr_cod_uso, cr_uso, cr_area_piso, cr_area_bloque, cr_mat_estruc_viga, cr_mat_estruc_columna, cr_mat_estruc_pared, cr_mat_estruc_entrepiso, cr_mat_estruc_contrapiso, cr_mat_estruc_cubierta, cr_mat_acab_piso, cr_mat_acab_puerta, cr_mat_acab_ventana, cr_mat_acab_enlucidop, cr_mat_acab_enlucidoc, cr_mat_acab_cielorraso, cr_instal_electrica, cr_instal_sanitaria, cr_instal_banio, cr_estado, cr_cond_fisica ,cr_anio_constr, cr_acabado, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s', '%s','%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s','%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%d')" % \
       		            (nrobloque, nropiso, coduso, uso, areapiso, areabloque, meviga, mecolumna, mepared, meentrepiso, mecontrapiso, mecubierta, mapiso, mapuerta, maventana, maenlucidop, maenlucidoc, macielorraso, ielectrica, isanitaria, ibanio, estado, condicion, aniocons, acabado, id_fi)
                    cursor.execute(sql)
                    db.commit()
                    cursor.close()
                #guardar datos en la tabla inversiones
                numFilas=self.tblInversion.rowCount()
                for x in range(0, numFilas):
                    cursor=db.cursor()
                    descripcion=self.tblInversion.cellWidget(x, 0).currentText()
                    material=self.tblInversion.cellWidget(x, 1).currentText()
                    cantidad=self.tblInversion.item(x, 2).text()
                    unidad=self.tblInversion.cellWidget(x, 3).currentText()
                    estado=self.tblInversion.cellWidget(x, 4).currentText()
                    sql= "INSERT INTO predio_inversiones(in_desc, in_tipo_mat, in_area, in_unid_med, in_estado, fi_id) VALUES ('%s', '%s', '%s', '%s', '%s','%d')" % \
       		            (descripcion, material, cantidad, unidad, estado, id_fi)
                    cursor.execute(sql)
                    db.commit()
                    cursor.close()
                #guardar descripcion suelo 
                numFilas=self.tblDescSuelo.rowCount()
                for x in range(0, numFilas):
                    cursor=db.cursor()
                    descripcion=self.tblDescSuelo.cellWidget(x, 0).currentText()
                    area=self.tblDescSuelo.item(x, 1).text()
                    porcentaje=self.tblDescSuelo.item(x, 2).text()
                    sql= "INSERT INTO predio_desc_suelos (ds_clase, ds_area, ds_porc , fi_id) VALUES ('%s', '%s', '%s','%d')" % \
       		            (descripcion, area, porcentaje, id_fi)
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
                #asignar cod catastral a la geodatabase
                QtGui.QMessageBox.about(self, "Datos Guardos", """Los datos se han guardado correctamente""")
                self.close()
            except MySQLdb.Error, e:
                print ("Error no contemplado:", e)
                db.rollback()
                QtGui.QMessageBox.about(self, "Error", """Error al momento de guardar los datos""")
                cursor.close()
                db.close()
        else:
            QtGui.QMessageBox.about(self, "Advertencia", """No se puede guardar datos en blanco ó clave catastral ingresada no coincide o vacia""")
            
if __name__ == '__main__':
    try:
        os.chdir("C:\uiArcgis\data")
        fid=""
        clave_catastral=""
        doc = minidom.parse("clave_catastral.xml")
        # doc.getElementsByTagName returns NodeList
        name = doc.getElementsByTagName("fid")[0]
        fid= name.firstChild.data
        name = doc.getElementsByTagName("catastro")[0]
        clave_catastral= name.firstChild.data
    except  :
        pass
    app = QtGui.QApplication(sys.argv)
    window = MyWindow()
    sys.exit(app.exec_())
