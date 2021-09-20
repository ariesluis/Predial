import arcpy
import pythonaddins
import os
import sys
import xml.etree.cElementTree as ET
from xml.dom import minidom

class AsignarClave(object):
    """Implementation for sigprer_addin_addin.tool_2 (Tool)"""
    def __init__(self):
        self.enabled = True
        self.cursor=3
        self.shape = "NONE" # Can set to "Line", "Circle" or "Rectangle" for interactive shape drawing and to activate the onLine/Polygon/Circle event sinks.
    def onMouseDown(self, x, y, button, shift):
        pass
    def onMouseDownMap(self, x, y, button, shift):
        id=0
        clave=""
        os.chdir("C:\sigprer")
        #leer direccion de la geodatabase
        doc = minidom.parse("gdb.xml")
        dirgdb = doc.getElementsByTagName("dirgdb")[0]
        tablagdb=doc.getElementsByTagName("tablagdb")[0]
        #leer clave catatral
        doc = minidom.parse("claveCatastro.xml")
        codigo = doc.getElementsByTagName("catastro")[0]
        #acceso gdb y datos del poligono
        arcpy.env.workspace = dirgdb.firstChild.data
        Predio=tablagdb.firstChild.data
        mxd = arcpy.mapping.MapDocument("current")
        df = mxd.activeDataFrame
        #build point geometry
        pointGeom = arcpy.PointGeometry(arcpy.Point(x, y), mxd.activeDataFrame.spatialReference)
        #select for location
        lyr = arcpy.mapping.Layer(Predio)
        arcpy.SelectLayerByLocation_management(lyr, "INTERSECT", pointGeom)
        with arcpy.da.SearchCursor(lyr,["OBJECTID", "Cod_Catast", "Shape_Area"]) as cursor:
            for row in cursor:
                id = int(row[0])
                clave = row[1]
        #actualizacion del campo clave catastral
        with arcpy.da.UpdateCursor(Predio, ["OBJECTID","Cod_Catast"]) as cursor:
            for row in cursor:
                if row[0]==id:
                    result = pythonaddins.MessageBox('Desea asignar la clave catastral al predio:?', 'Asignar', 1)
                    if(result=="OK"):
                        row[1] = codigo.firstChild.data
                        cursor.updateRow(row)
                        pythonaddins.MessageBox('Clave cambiada', 'Listo', 0)

class Avaluo(object):
    """Implementation for sigprer_addin_addin.tool_3 (Tool)"""
    def __init__(self):
        self.enabled = True
        self.cursor=3
        self.shape = "NONE" # Can set to "Line", "Circle" or "Rectangle" for interactive shape drawing and to activate the onLine/Polygon/Circle event sinks.
    def onMouseDown(self, x, y, button, shift):
        pass
    def onMouseDownMap(self, x, y, button, shift):
        os.chdir("C:\sigprer")
        #leer direccion de la geodatabase
        doc = minidom.parse("gdb.xml")
        dirgdb = doc.getElementsByTagName("dirgdb")[0]
        tablagdb=doc.getElementsByTagName("tablagdb")[0]
        #escritura del archivo param.xml para llamado de ventanas
        root = ET.Element("r10101")
        ET.SubElement(root, "v0011").text = "o11"
        tree = ET.ElementTree(root)
        tree.write("param.xml")
        # manejo de la geodatabase
        arcpy.env.workspace = dirgdb.firstChild.data
        Predio=tablagdb.firstChild.data
        mxd = arcpy.mapping.MapDocument("current")
        df = mxd.activeDataFrame
        #build point geometry
        pointGeom = arcpy.PointGeometry(arcpy.Point(x, y), mxd.activeDataFrame.spatialReference)
        #select for location
        lyr = arcpy.mapping.Layer(Predio)
        arcpy.SelectLayerByLocation_management(lyr, "INTERSECT", pointGeom)
        #get value attribute and write in xml
        with arcpy.da.SearchCursor(lyr,["OBJECTID", "Cod_Catast"]) as cursor:
            for row in cursor:
                os.chdir("C:\sigprer")
                root = ET.Element("clave")
                ET.SubElement(root, "catastro").text = row[1]
                tree = ET.ElementTree(root)
                tree.write("catastrogdb.xml")
        #call interface consult predio
        pythonaddins.GPToolDialog(r'C:\sigprer\tbx\window.tbx', 'window')

class Buscar(object):
    """Implementation for sigprer_addin_addin.button_3 (Button)"""
    def __init__(self):
        self.enabled = True
        self.checked = False
    def onClick(self):
        try:
            os.chdir("C:\sigprer")
            doc = minidom.parse("search.xml")
            codigos = doc.getElementsByTagName("catastro")
            dimension = codigos.length
            #print dimension
            if dimension!=0:
                if dimension!=1:
                    for i in range(dimension):
                        codigo= doc.getElementsByTagName("catastro")[i-1]
                        print codigo.firstChild.data
                        if(codigo.firstChild.data!=""):
                                mxd = arcpy.mapping.MapDocument('CURRENT')
                                df = arcpy.mapping.ListDataFrames(mxd) [0]
                                predio = arcpy.mapping.ListLayers(mxd, "Predios", df)[0]
                                whereClause = "Cod_Catast ='%s'" % codigo.firstChild.data
                                arcpy.SelectLayerByAttribute_management(predio, "ADD_TO_SELECTION", whereClause)
                                df.extent = predio.getSelectedExtent(True)
                                arcpy.mapping.ExportToJPEG(mxd, r"C:\sigprer\img\%s.jpg"%codigo.firstChild.data, df, df_export_width=640, df_export_height=480, world_file=False)
                                arcpy.RefreshActiveView()
                else:
                    codigo= doc.getElementsByTagName("catastro")[0]
                    if(codigo.firstChild.data!=""):
                            mxd = arcpy.mapping.MapDocument('CURRENT')
                            df = arcpy.mapping.ListDataFrames(mxd) [0]
                            predio = arcpy.mapping.ListLayers(mxd, "Predios", df)[0]
                            whereClause = "Cod_Catast ='%s'" % codigo.firstChild.data
                            arcpy.SelectLayerByAttribute_management(predio, "NEW_SELECTION", whereClause)
                            df.extent = predio.getSelectedExtent(True)
                            arcpy.mapping.ExportToJPEG(mxd, r"C:\sigprer\img\%s.jpg"%codigo.firstChild.data, df, df_export_width=640, df_export_height=480, world_file=False)
                            arcpy.RefreshActiveView()
            else:
                pythonaddins.MessageBox('Predio no encontrado', 'Resultado', 0)
        except Exception:
            e = sys.exc_info()[1]
            # If using this code within a script tool, AddError can be used to return messages 
            #   back to a script tool.  If not, AddError will have no effect.
            print(e.args[0])

class ButtonClass11(object):
    """Implementation for sigprer_addin_addin.button_4 (Button)"""
    def __init__(self):
        self.enabled = False
        self.checked = False
    def onClick(self):
        pass

class ButtonClass17(object):
    """Implementation for sigprer_addin_addin.button_6 (Button)"""
    def __init__(self):
        self.enabled = False
        self.checked = False
    def onClick(self):
        pass

class ButtonClass3(object):
    """Implementation for sigprer_addin_addin.button (Button)"""
    def __init__(self):
        self.enabled = False
        self.checked = False
    def onClick(self):
        pass

class ButtonClass8(object):
    """Implementation for sigprer_addin_addin.button_1 (Button)"""
    def __init__(self):
        self.enabled = False
        self.checked = False
    def onClick(self):
        pass

class Cerrar(object):
    """Implementation for sigprer_addin_addin.btnCerrar (Button)"""
    def __init__(self):
        self.enabled = True
        self.checked = False
    def onClick(self):
        result = pythonaddins.MessageBox('Desea cerrar la sesion?', 'Cerrar Sesion', 1)
        if result=="OK":
            os.chdir("C:\sigprer")
            root = ET.Element("r10101")
            ET.SubElement(root, "v0011").text = "o00"
            tree = ET.ElementTree(root)
            tree.write("param.xml")
            #limpiar user.xml
            root1=ET.Element("Usuario")
            tree1=ET.ElementTree(root1)
            tree1.write("user.xml")


class ClaveCatastral(object):
    """Implementation for sigprer_addin_addin.button_5 (Button)"""
    def __init__(self):
        self.enabled = True
        self.checked = False
    def onClick(self):
        os.chdir("C:\sigprer")
        root = ET.Element("r10101")
        ET.SubElement(root, "v0011").text = "o1001"
        tree = ET.ElementTree(root)
        tree.write("param.xml")
        pythonaddins.GPToolDialog(r'C:\sigprer\tbx\window.tbx', 'window')

class Consultar(object):
    """Implementation for sigprer_addin_addin.tool_1 (Tool)"""
    def __init__(self):
        self.enabled = True
        self.cursor=3
        self.shape = "NONE" # Can set to "Line", "Circle" or "Rectangle" for interactive shape drawing and to activate the onLine/Polygon/Circle event sinks.
    def onMouseDown(self, x, y, button, shift):
        pass
    def onMouseDownMap(self, x, y, button, shift):
        os.chdir("C:\sigprer")
        #leer direccion de la geodatabase
        doc = minidom.parse("gdb.xml")
        dirgdb = doc.getElementsByTagName("dirgdb")[0]
        tablagdb=doc.getElementsByTagName("tablagdb")[0]
        #escritura del archivo param.xml para llamado de ventanas
        root = ET.Element("r10101")
        ET.SubElement(root, "v0011").text = "o10"
        tree = ET.ElementTree(root)
        tree.write("param.xml")
        # manejo de la geodatabase
        arcpy.env.workspace = dirgdb.firstChild.data
        Predio=tablagdb.firstChild.data
        mxd = arcpy.mapping.MapDocument("current")
        df = mxd.activeDataFrame
        #build point geometry
        pointGeom = arcpy.PointGeometry(arcpy.Point(x, y), mxd.activeDataFrame.spatialReference)
        #select for location
        lyr = arcpy.mapping.Layer(Predio)
        arcpy.SelectLayerByLocation_management(lyr, "INTERSECT", pointGeom)
        #get value attribute and write in xml
        with arcpy.da.SearchCursor(lyr,["OBJECTID", "Cod_Catast"]) as cursor:
            for row in cursor:
                os.chdir("C:\sigprer")
                root = ET.Element("clave")
                ET.SubElement(root, "catastro").text = row[1]
                tree = ET.ElementTree(root)
                tree.write("catastrogdb.xml")
        #call interface consult predio
        pythonaddins.GPToolDialog(r'C:\sigprer\tbx\window.tbx', 'window')

class Factor(object):
    """Implementation for sigprer_addin_addin.button_7 (Button)"""
    def __init__(self):
        self.enabled = True
        self.checked = False
    def onClick(self):
        try:
            os.chdir("C:\sigprer")
            root = ET.Element("r10101")
            ET.SubElement(root, "v0011").text = "o100"
            tree = ET.ElementTree(root)
            tree.write("param.xml")
            pythonaddins.GPToolDialog(r'C:\sigprer\tbx\window.tbx', 'window')
        except Exception:
            e = sys.exc_info()[1]
            # If using this code within a script tool, AddError can be used to return messages 
            #   back to a script tool.  If not, AddError will have no effect.
            print(e.args[0])

class Ingresar(object):
    """Implementation for sigprer_addin_addin.tool (Tool)"""
    def __init__(self):
        self.enabled = True
        self.cursor=3
        self.shape = "NONE" # Can set to "Line", "Circle" or "Rectangle" for interactive shape drawing and to activate the onLine/Polygon/Circle event sinks.
    def onMouseDownMap(self, x, y, button, shift):
        os.chdir("C:\sigprer")
        #leer direccion de la geodatabase
        doc = minidom.parse("gdb.xml")
        dirgdb = doc.getElementsByTagName("dirgdb")[0]
        tablagdb=doc.getElementsByTagName("tablagdb")[0]
        #escritura del archivo param.xml para llamado de ventanas
        root = ET.Element("r10101")
        ET.SubElement(root, "v0011").text = "o01"
        tree = ET.ElementTree(root)
        tree.write("param.xml")
        #acceso gdb y datos del poligono
        arcpy.env.workspace = dirgdb.firstChild.data
        Predio=tablagdb.firstChild.data
        mxd = arcpy.mapping.MapDocument("current")
        df = mxd.activeDataFrame
        #build point geometry
        pointGeom = arcpy.PointGeometry(arcpy.Point(x, y), mxd.activeDataFrame.spatialReference)
        #select for location
        lyr = arcpy.mapping.Layer(Predio)
        arcpy.SelectLayerByLocation_management(lyr, "INTERSECT", pointGeom)
        with arcpy.da.SearchCursor(lyr,["OBJECTID", "Cod_Catast", "Shape_Area"]) as cursor:
            for row in cursor:
                os.chdir("C:\sigprer")
                root = ET.Element("poligono")
                ET.SubElement(root, "id").text = str(row[0])
                ET.SubElement(root, "catastro").text = str(row[1])
                ET.SubElement(root, "area").text = str(row[2])
                ET.SubElement(root, "x").text = str(x)
                ET.SubElement(root, "y").text = str(y)
                tree = ET.ElementTree(root)
                tree.write("datopoligono.xml")
        #call interface save predio
        pythonaddins.GPToolDialog(r'C:\sigprer\tbx\window.tbx', 'window')

class Iniciar(object):
    """Implementation for sigprer_addin_addin.btnInicio (Button)"""
    def __init__(self):
        self.enabled = True
        self.checked = False
    def onClick(self):
        os.chdir("C:\sigprer")
        root = ET.Element("r10101")
        ET.SubElement(root, "v0011").text = "o00"
        tree = ET.ElementTree(root)
        tree.write("param.xml")
        pythonaddins.GPToolDialog(r'C:\sigprer\tbx\window.tbx', 'window')

class Parametro(object):
    """Implementation for sigprer_addin_addin.button_2 (Button)"""
    def __init__(self):
        self.enabled = True
        self.checked = False
    def onClick(self):
        os.chdir("C:\sigprer")
        root = ET.Element("r10101")
        ET.SubElement(root, "v0011").text = "o1000"
        tree = ET.ElementTree(root)
        tree.write("param.xml")
        pythonaddins.GPToolDialog(r'C:\sigprer\tbx\window.tbx', 'window')