/*
SQLyog Ultimate v11.11 (64 bit)
MySQL - 5.6.17 : Database - dbp_factorapp
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`dbp_factorapp` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `dbp_factorapp`;

/*Table structure for table `factor` */

DROP TABLE IF EXISTS `factor`;

CREATE TABLE `factor` (
  `fa_id` int(11) NOT NULL AUTO_INCREMENT,
  `fa_desc` varchar(80) COLLATE latin1_spanish_ci NOT NULL,
  PRIMARY KEY (`fa_id`)
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

/*Data for the table `factor` */

insert  into `factor`(`fa_id`,`fa_desc`) values (1,'Tipo Acabado'),(2,'Acera'),(3,'Agua Proviene'),(4,'Agua Recibe'),(5,'Alcantarillado'),(6,'Alumbrado'),(7,'Clasificación Agrológica'),(8,'Clasificación Suelo'),(9,'Cobertura Vegetal'),(10,'Cobertura Natural'),(11,'Material'),(12,'Condición Física'),(13,'Condición Ocupación'),(14,'Disponibilidad Riego'),(15,'Dominio'),(16,'Ecosistema Relevante'),(17,'Energía Eléctrica Proviene'),(18,'Erosión'),(19,'Estado Conservación'),(20,'Estado Vía'),(21,'Forma del Predio'),(22,'Forma Adquisición'),(23,'Instalaciones Especiales'),(24,'Localización Manzana'),(25,'Método Riego'),(26,'Numero Baños'),(27,'Obra o Mejora'),(28,'Poblaciones Cercanas'),(29,'Recolección Basura'),(30,'Riesgo'),(31,'Rodadura'),(32,'Tipo Tenencia'),(33,'Tipo Vía'),(34,'Titularidad'),(35,'Transporte Público'),(36,'Unidad o Vivienda'),(37,'Uso Constructivo'),(38,'Uso Suelo'),(39,'Valor Cultural'),(41,'Elementos Decorativos'),(42,'Relieve'),(43,'Impuestos'),(44,'Valor Mejoras'),(45,'Tamaño');

/*Table structure for table `factor_valor` */

DROP TABLE IF EXISTS `factor_valor`;

CREATE TABLE `factor_valor` (
  `fa_id` int(11) NOT NULL,
  `fv_desc` varchar(80) COLLATE latin1_spanish_ci NOT NULL,
  `fv_valor` double NOT NULL DEFAULT '1',
  KEY `fa_id` (`fa_id`),
  CONSTRAINT `factor_valor_ibfk_1` FOREIGN KEY (`fa_id`) REFERENCES `factor` (`fa_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

/*Data for the table `factor_valor` */

insert  into `factor_valor`(`fa_id`,`fv_desc`,`fv_valor`) values (1,'Básico',0.91),(1,'Económico',0.97),(1,'Bueno',1),(1,'Lujo',1.1),(2,'Si tiene',1),(2,'No tiene',0.98),(3,'No tiene',0.75),(3,'De red pública',1),(3,'De pozo',0.9),(3,'De río/vertiente',0.9),(3,'De carro repartidor',0.85),(3,'Otro',0.8),(4,'No tiene',0.7),(4,'Por tubería dentro de la vivienda',1),(4,'Por tubería fuera de la vivienda',0.95),(4,'Por tubería fuera del predio',0.9),(4,'Otros medios',0.85),(5,'No tiene',0.7),(5,'Red pública',1),(5,'Pozo séptico',0.85),(5,'Pozo ciego',0.85),(5,'Rio o quebrada',0.8),(5,'Letrina',0.85),(6,'No tiene',0.9),(6,'Si tiene',1),(7,'Clase I',1),(7,'Clase II',0.6),(7,'Clase III',0.51),(7,'Clase IV',0.42),(7,'Clase V',0.33),(7,'Clase VI',0.24),(7,'Clase VII',0.02),(7,'Clase VIII',0.005),(8,'De producción',1),(8,'De extracción',1),(8,'De expanción urbana',1),(8,'De protección',1),(9,'Algarrobo',1),(9,'Bosque húmedo',1),(9,'Cacao',1),(9,'Cacao - café',1),(9,'Café',1),(9,'Caña de azúcar',1),(9,'Embalse',1),(9,'Matorral Húmedo',1),(9,'Misceláneo de ciclo corto',1),(9,'Misceláneo de frutales',1),(9,'Misceláneo indiferenciado',1),(9,'Pasto cultivado',1),(9,'Pasto cultivado con presencia de arboles',1),(9,'Pasto cultivado con presencia de maíz',1),(9,'Urbano',1),(9,'Vegetación herbácea',1),(10,'No tiene',1),(10,'Arbórea',0.95),(10,'Arbustiva',0.95),(10,'Herbácea',1),(10,'Otro',0.9),(12,'No tiene',1),(12,'En estructura',0.95),(12,'Abandonado',1),(12,'En acabados',0.98),(12,'Reconstruida',1),(12,'Terminada',1),(12,'Sin modificación',1),(13,'Ocupado',1),(13,'Desocupado',0.9),(14,'No tiene',0.75),(14,'Ocasional',0.9),(14,'Permanente',1.05),(15,'Sin información',0.98),(15,'Natural',1),(15,'Jurídica Pública',1),(15,'Jurídica Privada',1),(16,'No tiene',1),(16,'Páramo',0.9),(16,'Humedal',0.7),(16,'Manglar',0.4),(16,'Bosque primario',1),(16,'Bosque Secundario',1),(17,'No tiene',0.7),(17,'Empresa Eléctrica',1),(17,'Panel Solar',1.1),(17,'Planta Eléctrica',1.1),(17,'Otro',1),(18,'No tiene',1.1),(18,'Leve',1),(18,'Moderado',0.95),(18,'Severo',0.9),(19,'Muy bueno',1.1),(19,'Bueno',1),(19,'Regular',0.95),(19,'Malo',0.9),(19,'No tiene',1),(20,'Bueno',1),(20,'Regular',0.9),(20,'Malo',0.8),(21,'Regular',1.1),(21,'Irregular',1),(21,'Muy Irregular',0.95),(22,'Compra - Venta',1),(22,'Donación',1),(22,'Herencia',1),(22,'Otro',0.95),(22,'Partición',1),(22,'Permuta',1),(22,'Posesión',0.9),(22,'Remate',1),(23,'No tiene',1),(23,'Ascensor',1.1),(23,'Circuito cerrado de televisión',1.1),(23,'Montacargas',1.1),(23,'Sistema alternativo de energía',1.1),(23,'Sistema de aire acondicionado',1.1),(23,'Sistema contra incendios',1.1),(23,'Sistema de gas centralizado',1.1),(23,'Sistema de ventilación mecánica',1.1),(23,'Sistema de voz y datos',1.1),(24,'No tiene',0.8),(24,'Esquinero',1.1),(24,'En cabecera',1.15),(24,'Intermedio',1),(24,'En L',1.1),(24,'En T',1),(24,'En cruz',1.1),(24,'Manzanero',1.2),(24,'Triángulo',0.95),(24,'En callejón',0.9),(24,'Interior',0.8),(25,'No tiene',0.8),(25,'Gravedad',1),(25,'Aspersión',1),(25,'Goteo',1),(25,'Bombeo',1),(25,'Otro',1),(27,'No tiene',1),(27,'Aceras y cercas',1),(27,'Canal de riego ocasional',1),(27,'Canal de riego permanente',1),(27,'Cerramiento',1),(27,'Desecación de pantanos',1.1),(27,'Establo',1.1),(27,'Estanque/Reservorio',1),(27,'Funiculares',1),(27,'Galpón Avícola',1),(27,'Invernaderos',1),(27,'Muro de contención',1),(27,'Parques/jardines',1.2),(27,'Piscina camaronera',1.1),(27,'Piscina Piscícola',1.1),(27,'Piscina de natación',1.1),(27,'Pista de aterrizaje',2),(27,'Planta de pos cosecha',1),(27,'Pozo de riego',1),(27,'Relleno de quebradas',0.8),(27,'Sala de ordeño',1),(27,'Silo/almacenamiento',1),(27,'Tendales',1),(27,'Vias internas',1.2),(27,'Viveros',1),(27,'Otros',1),(28,'Capital provincial',1),(28,'Cabecera cantonal',1),(28,'Cabecera parroquial',1),(28,'Asentamientos urbanos',1),(29,'No tiene',0.7),(29,'Por carro recolector',1),(29,'Terreno baldío o quebrada',0.7),(29,'La queman',0.8),(29,'La entierran',0.9),(29,'Rio/Acequia/Canal',0.1),(29,'Otra forma',0.11),(30,'No tiene',1.1),(30,'Deslaves',0.95),(30,'Hundimientos',0.9),(30,'Inundación',0.85),(30,'Heladas',0.8),(30,'Contaminación',0.8),(30,'Geológico',0.75),(30,'Vientos',0.7),(30,'Volcánico',0.7),(30,'Otro',0.7),(31,'No tiene',0.7),(31,'Adoquín de cemento',0.95),(31,'Adoquín de piedra',1),(31,'Empedrado',0.95),(31,'Lastre',0.9),(31,'Hormigón',1.1),(31,'Asfalto',1.1),(31,'Tierra',0.8),(32,'Anticresis',1),(32,'Arrendada',0.8),(32,'Por servicios',1),(32,'Prestada o cedida',1),(32,'Propia',1),(32,'Propia y la esta pagando',0.98),(33,'No tiene',0.7),(33,'Autopista',1.1),(33,'Avenida',1.1),(33,'Calle',1),(33,'Callejón',1),(33,'Camino de herradura',0.9),(33,'Escalinata',0.9),(33,'Pasaje',0.1),(33,'Peatonal',0.11),(33,'Sendero',0.12),(33,'Aérea',0.6),(33,'Férrea',0.7),(33,'Fluvial',0.7),(33,'Marítima',0.7),(35,'No tiene',0.8),(35,'Inter - provincial',1),(35,'Inter - cantonal',1),(35,'Inter - parroquial',1),(36,'No aplica',1),(36,'Bodega',1),(36,'Casa',1),(36,'Choza',1),(36,'Covacha',1),(36,'Cuarto en casa',1),(36,'Departamento',1),(36,'Local comercial',1.1),(36,'Mediagua',1),(36,'Oficina',1),(36,'Otra vivienda',1),(36,'Parqueadero',1),(36,'Rancho',1.1),(36,'Villa',1.1),(37,'No tiene',1),(37,'Balcón',1.1),(37,'Banco',1.2),(37,'Baños Sauna/turco/hdroma',1.2),(37,'Bodega',1),(37,'Casa',1),(37,'Casa Comunal',1),(37,'Cuarto Máquinas/Basura',1.1),(37,'Departamento',1),(37,'Garita/Guardianía',1),(37,'Gimnasio',1),(37,'Guardería',1),(37,'Hospital',1.5),(37,'Hostal',1.2),(37,'Hostería',1.3),(37,'Hotel',1.5),(37,'Iglesia',1),(37,'Lavandería',1),(37,'Local Comercial',1),(37,'Malecón',1.2),(37,'Maternidad',1.5),(37,'Mercado',1),(37,'Mirador',1.1),(37,'Motel',1.1),(37,'Museo',1.5),(37,'Nave industrial',1),(37,'Oficina',1),(37,'Orfanato',1),(37,'Organismos Internacionales',1),(37,'Otros',1),(37,'Parqueadero',1),(37,'Patio/Jardín',1),(37,'Pensión',1),(37,'Plantel avícola',1.1),(37,'Plaza de toros',1.1),(37,'Porqueriza',1),(37,'Recinto militar',1.2),(37,'Recinto policial',1.2),(37,'Reclusorio',1),(37,'Representaciones Diplomáticas',1),(37,'Restaurante',1),(37,'Retén Policial',1),(37,'Sala comunal',1),(37,'Sala de cine',1.2),(37,'Sala de exposición',1.2),(37,'Sala de juegos',1.2),(37,'Sala de ordeño',1.2),(37,'Sala de culto/templo',1),(37,'Salas de hospitalización',1.5),(37,'Salón de eventos',1),(37,'Teatro',1.5),(37,'Terminal de Transferencia',1.5),(37,'Terminal interprovincial',1.5),(37,'Terraza',1),(37,'Unidad de policía comunitaria',1.5),(38,'No tiene',1),(38,'Acuacultura',1.1),(38,'Agrícola',1),(38,'Agroindustrial',1.1),(38,'Bienestar Social',1),(38,'Casa Comunal',1),(38,'Comercial',1),(38,'Comercial y Residencial',1),(38,'Conservación',1),(38,'Cultural',1),(38,'Diplomático',1),(38,'Educación',1),(38,'Espacio Público',1),(38,'Financiero',1),(38,'Forestal',1),(38,'Hidrocarburos',1.1),(38,'Industrial',1.3),(38,'Institucional Privado',1),(38,'Institucional Público',1),(38,'Minero',1.3),(38,'Pecuario',1.1),(38,'Preservación Patrimonial',1),(38,'Protección Ecológica',1),(38,'Recreacion y Deporte',1),(38,'Religioso',1),(38,'Residencial',1),(38,'Salud',1.3),(38,'Seguridad',1.3),(38,'Servicios',1.1),(38,'Servicios Especiales',1.1),(38,'Transporte',1.2),(38,'Turismo',1),(39,'No tiene',1),(39,'Ancestral',1.2),(39,'Arquitectónico',1.2),(39,'Histórico',1.2),(11,'No tiene',0.5),(11,'Acero',1),(11,'Acero Hormigón',1),(11,'Adobe',0.8),(11,'Adoquín',1),(11,'Alfombra',1),(11,'Alucobond',1),(11,'Aluminio',1),(11,'Aluminio-vidrio',1),(11,'Arena cemento',1),(11,'Asbesto cemento',0.9),(11,'Bahareque',0.85),(11,'Bloque',0.85),(11,'Cady paja',0.85),(11,'Calciminas',1),(11,'Caña',0.7),(11,'Caña enlucida',0.85),(11,'Caucho',1),(11,'Cerámica',1),(11,'Césped sintético',1),(11,'Chova',1),(11,'Duela procesada',1),(11,'En cementado',1),(11,'Esmalte',1),(11,'Fachaleta',1),(11,'Ferro Cemento',1),(11,'Fibra mineral',1),(11,'Flotante',1),(11,'Graniplast',1),(11,'Gres',1),(11,'Gypsum',1),(11,'Hierro',1),(11,'Hierro-Hormigón',1),(11,'Hormigón Armado',1),(11,'Hormigón simple',1),(11,'Laca',1),(11,'Ladrillo',1),(11,'Ladrillo visto',0.85),(11,'Láminas de tol carrujado',1),(11,'Lona',0.75),(11,'Losa hormigón armado',1),(11,'Madera común',0.9),(11,'Madera ladrillo',1),(11,'Madera panelada',1),(11,'Madera procesada fina',1),(11,'Madera tamboreada',1),(11,'Madera triplex',1),(11,'Madera-hormigón',1),(11,'Malla',0.8),(11,'Malla enlucida',1),(11,'Mármol',1),(11,'Marmolina',1),(11,'Metálica enrollable',1),(11,'Parquet',1),(11,'Piedra',1),(11,'Pilotaje de Hormigón Armado',1),(11,'Pintura de alto tráfico',1),(11,'Plástico preformado',1),(11,'Policarbonato',1),(11,'Porcelanato',1),(11,'Tabón',1),(11,'Tapial',0.8),(11,'Teja ordinaria',1),(11,'Teja vidriada',1),(11,'Tejuelo',1),(11,'Tierra',0.5),(11,'Tol',1),(11,'Vidrio catedral',1),(11,'Vidrio común',1),(11,'Vidrio templado',1),(11,'Vinil',1),(11,'Zinc',0.9),(26,'No tiene',0.75),(26,'Letrina',0.8),(26,'Medio Baño',0.85),(26,'Baño Comun',0.95),(26,'Un Baño',1),(26,'Dos Baños',1),(26,'Mas de dos baños',1.1),(22,'Adjudicación',1),(41,'No tiene',1),(41,'Chimenea',1.1),(41,'Pared Decorada',1.1),(41,'Pared - Madera',1.1),(45,'Rango 1',1.2),(45,'Rango 2',1),(45,'Rango 3',0.8),(45,'Rango 4',0.6);

/*Table structure for table `factor_valor_relieve` */

DROP TABLE IF EXISTS `factor_valor_relieve`;

CREATE TABLE `factor_valor_relieve` (
  `fa_id` int(11) DEFAULT NULL,
  `fv_desc` varchar(40) COLLATE latin1_spanish_ci NOT NULL,
  `fv_valor` double NOT NULL,
  `fv_grado` varchar(20) COLLATE latin1_spanish_ci NOT NULL,
  KEY `fa_id` (`fa_id`),
  CONSTRAINT `factor_valor_relieve_ibfk_1` FOREIGN KEY (`fa_id`) REFERENCES `factor` (`fa_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

/*Data for the table `factor_valor_relieve` */

insert  into `factor_valor_relieve`(`fa_id`,`fv_desc`,`fv_valor`,`fv_grado`) values (42,'Plano',1,'0 - 5'),(42,'Suave',1,'5 - 10'),(42,'Media',1,'10 - 20'),(42,'Fuerte',0.9,'20 - 35'),(42,'Muy Fuerte',0.85,'35 - 45'),(42,'Escarpada',0.7,'45 - 70'),(42,'Abrupta',0.65,'>70');

/*Table structure for table `valor_impuestos` */

DROP TABLE IF EXISTS `valor_impuestos`;

CREATE TABLE `valor_impuestos` (
  `fa_id` int(11) DEFAULT NULL,
  `ban_imp` double DEFAULT NULL,
  `sbu` double DEFAULT NULL,
  `serv_admi` double DEFAULT NULL,
  `bombero` double DEFAULT NULL,
  KEY `fa_id` (`fa_id`),
  CONSTRAINT `valor_impuestos_ibfk_1` FOREIGN KEY (`fa_id`) REFERENCES `factor` (`fa_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `valor_impuestos` */

insert  into `valor_impuestos`(`fa_id`,`ban_imp`,`sbu`,`serv_admi`,`bombero`) values (43,0.36,375,2,0.26);

/*Table structure for table `valor_mejoras` */

DROP TABLE IF EXISTS `valor_mejoras`;

CREATE TABLE `valor_mejoras` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `mejora` varchar(100) DEFAULT NULL,
  `material` varchar(100) DEFAULT NULL,
  `precio` double DEFAULT NULL,
  `fa_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `valor_mejoras_ibfk_1` (`fa_id`),
  CONSTRAINT `valor_mejoras_ibfk_1` FOREIGN KEY (`fa_id`) REFERENCES `factor` (`fa_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

/*Data for the table `valor_mejoras` */

insert  into `valor_mejoras`(`id`,`mejora`,`material`,`precio`,`fa_id`) values (1,'Aceras y cercas','Hormigón simple',101.24,44),(3,'Canal de riego permanente','Hormigón simple',121.61,44),(5,'Casa','Ladrillo',23.56,44),(6,'Establo','Hormigón simple',12.44,44);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
