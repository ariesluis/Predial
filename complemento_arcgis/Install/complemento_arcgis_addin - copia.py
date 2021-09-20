import arcpy
import pythonaddins
import os
import sys
from arcpy import env 
import xml.etree.cElementTree as ET
from xml.dom import minidom

class AsignarCod(object):
    """Implementation for complemento_arcgis_addin.tool_2 (Tool)"""
    def __init__(self):
        self.enabled = True
        self.cursor=3
        self.shape = "NONE" # Can set to "Line", "Circle" or "Rectangle" for interactive shape drawing and to activate the onLine/Polygon/Circle event sinks.
    def onMouseDownMap(self, x, y, button, shift):
        #enviroment
        arcpy.env.workspace = r'\\LUIS-PC\bin\Pinias.gdb'
        Predio=r'\\LUIS-PC\bin\Pinias.gdb\Predios'
        mxd = arcpy.mapping.MapDocument("current")
        df = mxd.activeDataFrame
        #build point geometry
        pointGeom = arcpy.PointGeometry(arcpy.Point(x, y), mxd.activeDataFrame.spatialReference)
        #select for location
        lyr = arcpy.mapping.Layer(Predio)
        arcpy.SelectLayerByLocation_management(lyr, "INTERSECT", pointGeom)
        #get value attribute and write in xml
        with arcpy.da.SearchCursor(lyr,["OBJECTID"]) as cursor:
            for row in cursor:
                os.chdir("C:\uiArcgis\data")
                root = ET.Element("predio")
                ET.SubElement(root, "fid", name="valor1").text = str(row[0])
                tree = ET.ElementTree(root)
                tree.write("clave_catastral.xml")
        #call interface asignar codigo
        pythonaddins.GPToolDialog(r'C:\uiArcgis\tbx\AsignarCodigo.tbx', 'AsignarCodigo')

class BuscarPredio(object):
    """Implementation for complemento_arcgis_addin.btnBuscarPredio (Button)"""
    def __init__(self):
        self.enabled = True
        self.checked = False
    def onClick(self):
        try:
            os.chdir("C:\uiArcgis\data")
            codigo=""
            doc = minidom.parse("codigo.xml")
            # doc.getElementsByTagName returns NodeList
            name = doc.getElementsByTagName("codigo")[0]
            codigo= name.firstChild.data
            if(codigo!=""):
                mxd = arcpy.mapping.MapDocument('CURRENT')
                df = arcpy.mapping.ListDataFrames(mxd) [0]
                predio = arcpy.mapping.ListLayers(mxd, "Predios", df)[0]
                whereClause = "Cod_Catast ='%s'" % codigo
                arcpy.SelectLayerByAttribute_management(predio, "NEW_SELECTION", whereClause)
                df.extent = predio.getSelectedExtent(True)
                arcpy.mapping.ExportToJPEG(mxd, r"C:\uiArcgis\img\%s.jpg"%codigo, df, df_export_width=640, df_export_height=480, world_file=False)
                arcpy.RefreshActiveView()
        except  :
            pass

class ButtonClass16(object):
    """Implementation for complemento_arcgis_addin.button (Button)"""
    def __init__(self):
        self.enabled = False
        self.checked = False
    def onClick(self):
        pass

class ButtonClass26(object):
    """Implementation for complemento_arcgis_addin.button_1 (Button)"""
    def __init__(self):
        self.enabled = False
        self.checked = False
    def onClick(self):
        pass

class ButtonClass38(object):
    """Implementation for complemento_arcgis_addin.button_2 (Button)"""
    def __init__(self):
        self.enabled = False
        self.checked = False
    def onClick(self):
        pass

class Consult_data(object):
    """Implementation for complemento_arcgis_addin.tool_1 (Tool)"""
    def __init__(self):
        self.enabled = True
        self.cursor=3
        self.shape = "NONE" # Can set to "Line", "Circle" or "Rectangle" for interactive shape drawing and to activate the onLine/Polygon/Circle event sinks.
    def onMouseDownMap(self, x, y, button, shift):
        #enviroment
        arcpy.env.workspace = r'\\LUIS-PC\bin\Pinias.gdb'
        Predio=r'\\LUIS-PC\bin\Pinias.gdb\Predios'
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
                os.chdir("C:\uiArcgis\data")
                root = ET.Element("predio")
                ET.SubElement(root, "fid", name="valor1").text = str(row[0])
                ET.SubElement(root, "catastro", name="valor2").text = row[1]
                tree = ET.ElementTree(root)
                tree.write("clave_catastral.xml")
        #call interface consult predio
        pythonaddins.GPToolDialog(r'C:\uiArcgis\tbx\ConsultarDatos.tbx', 'ConsultarDatos')

class IngresarCodigo(object):
    """Implementation for complemento_arcgis_addin.btnIngresarCodigo (Button)"""
    def __init__(self):
        self.enabled = True
        self.checked = False
    def onClick(self):
        pythonaddins.GPToolDialog(r'C:\uiArcgis\tbx\BusquedaPredio.tbx', 'BusquedaPredio')

class Insert_data(object):
    """Implementation for complemento_arcgis_addin.tool (Tool)"""
    def __init__(self):
        self.enabled = True
        self.cursor=3
        self.shape = "NONE" # Can set to "Line", "Circle" or "Rectangle" for interactive shape drawing and to activate the onLine/Polygon/Circle event sinks.
    def onMouseDownMap(self, x, y, button, shift):
        #enviroment
        arcpy.env.workspace = r'\\LUIS-PC\bin\Pinias.gdb'
        Predio=r'\\LUIS-PC\bin\Pinias.gdb\Predios'
        mxd = arcpy.mapping.MapDocument("current")
        df = mxd.activeDataFrame
        #build point geometry
        pointGeom = arcpy.PointGeometry(arcpy.Point(x, y), mxd.activeDataFrame.spatialReference)
        #select for location
        lyr = arcpy.mapping.Layer(Predio)
        arcpy.SelectLayerByLocation_management(lyr, "INTERSECT", pointGeom)
        with arcpy.da.SearchCursor(lyr,["OBJECTID", "Cod_Catast"]) as cursor:
            for row in cursor:
                os.chdir("C:\uiArcgis\data")
                root = ET.Element("predio")
                ET.SubElement(root, "fid", name="valor1").text = str(row[0])
                ET.SubElement(root, "catastro", name="valor2").text = row[1]
                tree = ET.ElementTree(root)
                tree.write("clave_catastral.xml")
        #call interface save predio
        pythonaddins.GPToolDialog(r'C:\uiArcgis\tbx\InsertarDatos.tbx', 'InsertarDatos')

class ToolClass40(object):
    """Implementation for complemento_arcgis_addin.tool_3 (Tool)"""
    def __init__(self):
        self.enabled = True
        self.cursor=3
        self.shape = "NONE" # Can set to "Line", "Circle" or "Rectangle" for interactive shape drawing and to activate the onLine/Polygon/Circle event sinks.
    def onMouseDownMap(self, x, y, button, shift):
        #enviroment
        arcpy.env.workspace = r'\\LUIS-PC\bin\Pinias.gdb'
        Predio=r'\\LUIS-PC\bin\Pinias.gdb\Predios'
        mxd = arcpy.mapping.MapDocument("current")
        df = mxd.activeDataFrame
        #build point geometry
        pointGeom = arcpy.PointGeometry(arcpy.Point(x, y), mxd.activeDataFrame.spatialReference)
        #select for location
        lyr = arcpy.mapping.Layer(Predio)
        arcpy.SelectLayerByLocation_management(lyr, "INTERSECT", pointGeom)
        with arcpy.da.SearchCursor(lyr,["OBJECTID", "Cod_Catast"]) as cursor:
            for row in cursor:
                os.chdir("C:\uiArcgis\data")
                root = ET.Element("predio")
                ET.SubElement(root, "fid", name="valor1").text = str(row[0])
                ET.SubElement(root, "catastro", name="valor2").text = row[1]
                tree = ET.ElementTree(root)
                tree.write("clave_catastral.xml")
        #call interface save predio
        pythonaddins.GPToolDialog(r'C:\uiArcgis\tbx\GenerarValor.tbx', 'GenerarValor')