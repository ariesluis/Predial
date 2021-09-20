import sys
from PyQt4 import QtGui, uic
import os
import arcpy
import pythonaddins
from xml.dom import minidom

global fid

class MyWindow(QtGui.QMainWindow):
    def __init__(self):
        super(MyWindow, self).__init__()
        uic.loadUi('C:\uiArcgis\gui\Asignar.ui', self)
        self.show()
        self.btnAsignar.clicked.connect(self.asignarCod)
        self.btnCancelar.clicked.connect(self.cerrar)

    def asignarCod(self):
        #asignar cod catastral a la geodatabase
        Predio=r'\\LUIS-PC\bin\Pinias.gdb\Predios'
        codigo=str(self.txtCodigo.text())
        v=False
        with arcpy.da.UpdateCursor(Predio, ["OBJECTID","Cod_Catast"]) as cursor:
            for row in cursor:
                if row[0]==fid and row[1]=="":
                    row[1] = codigo
                    cursor.updateRow(row)
                    v=True
        if v==False:
            QtGui.QMessageBox.about(self, "Advertencia", """Predio ya tiene un codigo asignado""")
        else:
            QtGui.QMessageBox.about(self, "Listo", """Codigo Catastral asignado""")
        self.close()

    def cerrar(self):
        self.close()

if __name__ == '__main__':
    try:
        os.chdir("C:\uiArcgis\data")
        fid=""
        doc = minidom.parse("clave_catastral.xml")
        # doc.getElementsByTagName returns NodeList
        name = doc.getElementsByTagName("fid")[0]
        fid= name.firstChild.data
        fid=int(fid)
    except  :
        pass
    app = QtGui.QApplication(sys.argv)
    window = MyWindow()
    sys.exit(app.exec_())