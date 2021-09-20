import sys
from PyQt4 import QtGui, uic
import os
from xml.dom import minidom
import xml.etree.cElementTree as ET
import MySQLdb

#datos conexion a la bd
global host, puerto, usuario, password, bd 

class MyWindow(QtGui.QMainWindow):
    def __init__(self):
        super(MyWindow, self).__init__()
        uic.loadUi('C:\uiArcgis\gui\BusquedaCatastro.ui', self)
        self.show()
        self.host="192.168.1.9"
        self.puerto=3306
        self.usuario="root"
        self.password="root"
        self.bd="db_arcgispredio"
        self.btnAsignar.clicked.connect(self.asignarCod)
        self.btnCancelar.clicked.connect(self.cerrar)

    def asignarCod(self):
        codigo=str(self.txtCodigo.text())
        try:
            os.chdir("C:\uiArcgis\data")
            if self.cboParam.currentIndex()==0:
                root = ET.Element("predio")
                ET.SubElement(root, "codigo", name=codigo).text = codigo
                tree = ET.ElementTree(root)
                tree.write("codigo.xml")
            else:
                root = ET.Element("predio")
                cont=1
                result=self.traerCod()
                for row in result:
                    ET.SubElement(root, "codigo", name=row[0]).text = row[0]
                    cont=cont+1
                tree = ET.ElementTree(root)
                tree.write("codigo.xml")
            self.close()
        except Exception:
            e = sys.exc_info()[1]
            # If using this code within a script tool, AddError can be used to return messages 
            #   back to a script tool.  If not, AddError will have no effect.
            print(e.args[0])

    def traerCod(self):
        try:
            db=MySQLdb.connect(host=self.host, port=self.puerto, user=self.usuario, passwd=self.password, db=self.bd)
            sql="SELECT pr_id FROM predio_propietarios WHERE pr_apellido = '%s'" % (str(self.txtCodigo.text()))
            cursor= db.cursor()
            cursor.execute(sql)
            results = cursor.fetchall()
            pr_id=0
            for row in results:
                pr_id=row[0]
            cursor.close()

            sql="SELECT fi_cod_catastral FROM predio_fichas WHERE pr_id = '%d'" % (pr_id)
            cursor= db.cursor()
            cursor.execute(sql)
            results = cursor.fetchall()
            cursor.close()
            return results
        except MySQLdb.Error, e:
            print ("Error no contemplado:", e)
            cursor.close()
            return ()
        db.close()

    def cerrar(self):
        self.close()

if __name__ == '__main__':
    app = QtGui.QApplication(sys.argv)
    window = MyWindow()
    sys.exit(app.exec_())