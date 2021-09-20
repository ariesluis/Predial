/*
SQLyog Ultimate v11.11 (64 bit)
MySQL - 5.6.17 : Database - db_factoraplicacion
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`db_factoraplicacion` /*!40100 DEFAULT CHARACTER SET utf8 COLLATE utf8_spanish_ci */;

USE `db_factoraplicacion`;

/*Table structure for table `construcciones` */

DROP TABLE IF EXISTS `construcciones`;

CREATE TABLE `construcciones` (
  `co_id` int(11) NOT NULL AUTO_INCREMENT,
  `co_desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  PRIMARY KEY (`co_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `construcciones` */

insert  into `construcciones`(`co_id`,`co_desc`) values (1,'Establo Ganado'),(2,'Galpón avícola'),(3,'Invernadero');

/*Table structure for table `factor_acabado` */

DROP TABLE IF EXISTS `factor_acabado`;

CREATE TABLE `factor_acabado` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(50) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_acabado` */

insert  into `factor_acabado`(`id`,`desc`,`coef`) values (1,'Básico',0.9),(2,'Económico',0.95),(3,'Bueno',1),(4,'Lujo',1.1);

/*Table structure for table `factor_acera` */

DROP TABLE IF EXISTS `factor_acera`;

CREATE TABLE `factor_acera` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_acera` */

insert  into `factor_acera`(`id`,`desc`,`coef`) values (1,'No tiene',0.7),(2,'Si tiene',1);

/*Table structure for table `factor_agua_proviene` */

DROP TABLE IF EXISTS `factor_agua_proviene`;

CREATE TABLE `factor_agua_proviene` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_agua_proviene` */

insert  into `factor_agua_proviene`(`id`,`desc`,`coef`) values (1,'No tiene',0.2),(2,'De red pública',1),(3,'De pozo',0.7),(4,'De río/vertiente/acequia',0.8),(5,'De carro repartidor',0.5),(6,'Otro',0.6);

/*Table structure for table `factor_agua_recibe` */

DROP TABLE IF EXISTS `factor_agua_recibe`;

CREATE TABLE `factor_agua_recibe` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(60) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_agua_recibe` */

insert  into `factor_agua_recibe`(`id`,`desc`,`coef`) values (1,'No tiene',0.7),(2,'Por tubería dentro de la vivienda',1),(3,'Por tubería fuera de la vivienda',0.8),(4,'Por tubería fuera del predio',0.5),(5,'Otros medios',0.5);

/*Table structure for table `factor_alcantarillado` */

DROP TABLE IF EXISTS `factor_alcantarillado`;

CREATE TABLE `factor_alcantarillado` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_alcantarillado` */

insert  into `factor_alcantarillado`(`id`,`desc`,`coef`) values (1,'No tiene',0.2),(2,'Red pública',1),(3,'Pozo séptico',0.3),(4,'Pozo ciego',0.6),(5,'Rio o quebrada',0.4),(6,'Letrina',0.3);

/*Table structure for table `factor_alumbrado` */

DROP TABLE IF EXISTS `factor_alumbrado`;

CREATE TABLE `factor_alumbrado` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  `coef` double DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_alumbrado` */

insert  into `factor_alumbrado`(`id`,`desc`,`coef`) values (1,'No tiene',0.8),(2,'Si tiene',1);

/*Table structure for table `factor_clas_agrologica` */

DROP TABLE IF EXISTS `factor_clas_agrologica`;

CREATE TABLE `factor_clas_agrologica` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(20) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  `coef` double DEFAULT NULL,
  `valor` double DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_clas_agrologica` */

insert  into `factor_clas_agrologica`(`id`,`desc`,`coef`,`valor`) values (1,'Clase I',1,0.41),(2,'Clase II',0.6,0.382),(3,'Clase III',0.51,0.318),(4,'Clase IV',0.42,0.26),(5,'Clase V',0.33,0.203),(6,'Clase VI',0.24,0.145),(7,'Clase VII',0.02,0.079),(8,'Clase VIII',0.005,0.021);

/*Table structure for table `factor_clas_suelo` */

DROP TABLE IF EXISTS `factor_clas_suelo`;

CREATE TABLE `factor_clas_suelo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_clas_suelo` */

insert  into `factor_clas_suelo`(`id`,`desc`,`coef`) values (2,'De producción',0.95),(3,'De extracción',0.6),(4,'De expansión urbana',1),(5,'De protección',0.6);

/*Table structure for table `factor_cob_nat_pred` */

DROP TABLE IF EXISTS `factor_cob_nat_pred`;

CREATE TABLE `factor_cob_nat_pred` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_cob_nat_pred` */

insert  into `factor_cob_nat_pred`(`id`,`desc`,`coef`) values (1,'No tiene',1),(2,'Arbórea',0.9),(3,'Arbustiva',0.8),(4,'Herbácea',0.9),(5,'Otro',0.5);

/*Table structure for table `factor_columna` */

DROP TABLE IF EXISTS `factor_columna`;

CREATE TABLE `factor_columna` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_columna` */

insert  into `factor_columna`(`id`,`desc`,`coef`) values (1,'No tiene',0.4),(2,'Acero',1),(3,'Caña',0.6),(4,'Hierro',1),(5,'Hormigón Armado',1),(6,'Madera común',0.6),(7,'Mixto(Metal/Hormigón)',1),(8,'Pilotaje de Hormigón Armado',1);

/*Table structure for table `factor_cond_fisica` */

DROP TABLE IF EXISTS `factor_cond_fisica`;

CREATE TABLE `factor_cond_fisica` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_cond_fisica` */

insert  into `factor_cond_fisica`(`id`,`desc`,`coef`) values (1,'En estructura',0.9),(2,'No tiene',0),(3,'Abandonado',4),(4,'En acabados',1),(5,'Reconstruida',1),(6,'Sin modificación',1),(7,'Terminada',1);

/*Table structure for table `factor_cond_ocup` */

DROP TABLE IF EXISTS `factor_cond_ocup`;

CREATE TABLE `factor_cond_ocup` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_cond_ocup` */

insert  into `factor_cond_ocup`(`id`,`desc`,`coef`) values (1,'Ocupada',1),(2,'Desocupada',0.7);

/*Table structure for table `factor_contrapiso` */

DROP TABLE IF EXISTS `factor_contrapiso`;

CREATE TABLE `factor_contrapiso` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_contrapiso` */

insert  into `factor_contrapiso`(`id`,`desc`,`coef`) values (1,'No tiene',0.2),(2,'Hormigón simple',1),(3,'Ladrillo visto',0.7),(4,'Tierra',0.4),(5,'Caña',0.5);

/*Table structure for table `factor_cubierta` */

DROP TABLE IF EXISTS `factor_cubierta`;

CREATE TABLE `factor_cubierta` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_cubierta` */

insert  into `factor_cubierta`(`id`,`desc`,`coef`) values (1,'No tiene',0.2),(2,'Acero',1),(3,'Caña',0.6),(4,'Hierro',1),(5,'Losa hormigón armado',1),(6,'Madera común',0.6),(7,'Madera procesada fina',0.95);

/*Table structure for table `factor_disp_riego` */

DROP TABLE IF EXISTS `factor_disp_riego`;

CREATE TABLE `factor_disp_riego` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_disp_riego` */

insert  into `factor_disp_riego`(`id`,`desc`,`coef`) values (1,'No tiene',0.7),(2,'Ocasional',1.3),(3,'Permanente',1.5);

/*Table structure for table `factor_dominio` */

DROP TABLE IF EXISTS `factor_dominio`;

CREATE TABLE `factor_dominio` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_dominio` */

insert  into `factor_dominio`(`id`,`desc`,`coef`) values (1,'Sin información',0.95),(2,'Natural',1),(3,'Jurídica Pública',1),(4,'Jurídica privada',1);

/*Table structure for table `factor_ecos_rele` */

DROP TABLE IF EXISTS `factor_ecos_rele`;

CREATE TABLE `factor_ecos_rele` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_ecos_rele` */

insert  into `factor_ecos_rele`(`id`,`desc`,`coef`) values (1,'No tiene',1),(2,'Páramo',0.8),(3,'Humedal',0.7),(4,'Manglar',0.4),(5,'Bosque Primario',0.9),(6,'Bosque Secundario',0.7);

/*Table structure for table `factor_electricidad` */

DROP TABLE IF EXISTS `factor_electricidad`;

CREATE TABLE `factor_electricidad` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_electricidad` */

insert  into `factor_electricidad`(`id`,`desc`,`coef`) values (1,'No tiene',0.2),(2,'Red empresa eléctrica',1),(3,'Panel solar',1),(4,'Planta eléctrica',0.8),(5,'Otro',0.6);

/*Table structure for table `factor_entrepiso` */

DROP TABLE IF EXISTS `factor_entrepiso`;

CREATE TABLE `factor_entrepiso` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_entrepiso` */

insert  into `factor_entrepiso`(`id`,`desc`,`coef`) values (1,'No tiene',0.2),(2,'Acero Hormigón',1),(3,'Hierro-Hormigón',1),(4,'Losa hormigón armado',1),(5,'Madera-hormigón',0.7),(6,'Madera común',0.6),(7,'Madera procesada fina',1);

/*Table structure for table `factor_erosion` */

DROP TABLE IF EXISTS `factor_erosion`;

CREATE TABLE `factor_erosion` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(40) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  `coef` double DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_erosion` */

insert  into `factor_erosion`(`id`,`desc`,`coef`) values (1,'No tiene',1.1),(2,'Leve',1),(3,'Moderado',0.95),(4,'Severo',0.9);

/*Table structure for table `factor_est_conservacion` */

DROP TABLE IF EXISTS `factor_est_conservacion`;

CREATE TABLE `factor_est_conservacion` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_est_conservacion` */

insert  into `factor_est_conservacion`(`id`,`desc`,`coef`) values (1,'Muy bueno',1.1),(2,'Bueno',1),(3,'Regular',0.75),(4,'Malo',0.6),(5,'No tiene',0.5);

/*Table structure for table `factor_est_via` */

DROP TABLE IF EXISTS `factor_est_via`;

CREATE TABLE `factor_est_via` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE latin1_spanish_ci DEFAULT NULL,
  `coef` double DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

/*Data for the table `factor_est_via` */

insert  into `factor_est_via`(`id`,`desc`,`coef`) values (1,'Bueno',1),(2,'Regular',0.9),(3,'Malo',0.8);

/*Table structure for table `factor_forma` */

DROP TABLE IF EXISTS `factor_forma`;

CREATE TABLE `factor_forma` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(40) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  `coef` double DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_forma` */

insert  into `factor_forma`(`id`,`desc`,`coef`) values (1,'Regular',1.1),(2,'Irregular',1),(3,'Muy irregular',0.9);

/*Table structure for table `factor_forma_adqui` */

DROP TABLE IF EXISTS `factor_forma_adqui`;

CREATE TABLE `factor_forma_adqui` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(40) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_forma_adqui` */

insert  into `factor_forma_adqui`(`id`,`desc`,`coef`) values (1,'Adjudicación',1),(2,'Compra-Venta',1),(3,'Donación',0.9),(4,'Herencia',0.9),(5,'Otro',0.8),(6,'Partición',0.6),(7,'Permuta',0.6),(8,'Posesión',0.5),(9,'Remate',1);

/*Table structure for table `factor_inst_esp` */

DROP TABLE IF EXISTS `factor_inst_esp`;

CREATE TABLE `factor_inst_esp` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(40) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_inst_esp` */

insert  into `factor_inst_esp`(`id`,`desc`,`coef`) values (1,'No tiene',1),(2,'Ascensor',1.1),(3,'Circuito cerrado de televisión',1.1),(4,'Montacargas',1.1),(5,'Sistema alternativo de energía',1.1),(6,'Sistema central de aire acondi',1.1),(7,'Sistema contra incendios',1.1),(8,'Sistema de gas centralizado',1.2),(9,'Sistema de ventilación mecánica',1.1),(10,'Sistema de voz y datos',1.2);

/*Table structure for table `factor_loc_manz` */

DROP TABLE IF EXISTS `factor_loc_manz`;

CREATE TABLE `factor_loc_manz` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_loc_manz` */

insert  into `factor_loc_manz`(`id`,`desc`,`coef`) values (1,'No tiene',0.4),(2,'Esquinero',1.1),(3,'En cabecera',1.15),(4,'Intermedio',1),(5,'En L',1.12),(6,'En T',1),(7,'En Cruz',1.2),(8,'Manzanero',1.2),(9,'Triángulo',0.9),(10,'En Callejón',0.65),(11,'Interior',0.4);

/*Table structure for table `factor_mampost_soport` */

DROP TABLE IF EXISTS `factor_mampost_soport`;

CREATE TABLE `factor_mampost_soport` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_mampost_soport` */

insert  into `factor_mampost_soport`(`id`,`desc`,`coef`) values (1,'No tiene',1),(2,'Adobe',0.7),(3,'Bloque',0.7),(4,'Ladrillo',0.8),(5,'Piedra',0.8),(6,'Tapial',0.7);

/*Table structure for table `factor_met_riego` */

DROP TABLE IF EXISTS `factor_met_riego`;

CREATE TABLE `factor_met_riego` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_met_riego` */

insert  into `factor_met_riego`(`id`,`desc`,`coef`) values (1,'No tiene',0.2),(2,'Gravedad',1),(3,'Aspersión',1),(4,'Goteo',1),(5,'Bombeo',1),(6,'Otro',1);

/*Table structure for table `factor_nivel` */

DROP TABLE IF EXISTS `factor_nivel`;

CREATE TABLE `factor_nivel` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_nivel` */

insert  into `factor_nivel`(`id`,`desc`,`coef`) values (1,'Nivel calzada',1),(2,'Subsuelo',0.9);

/*Table structure for table `factor_num_banio` */

DROP TABLE IF EXISTS `factor_num_banio`;

CREATE TABLE `factor_num_banio` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_num_banio` */

insert  into `factor_num_banio`(`id`,`desc`,`coef`) values (1,'No Tiene',0.75),(2,'Letrina',0.8),(3,'Medio Baño',0.85),(4,'Baño Común',0.9),(5,'Un Baño',0.95),(6,'Dos Baños',1),(7,'Más de Dos Baños',1.1);

/*Table structure for table `factor_obra_mejora` */

DROP TABLE IF EXISTS `factor_obra_mejora`;

CREATE TABLE `factor_obra_mejora` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_obra_mejora` */

insert  into `factor_obra_mejora`(`id`,`desc`,`coef`) values (1,'No tiene',0),(2,'Aceras y cercas',1),(3,'Canal de riego ocasional',1),(4,'Canal de riego permanente',1),(5,'Cerramiento',1),(6,'Desecación de pantanos',1.1),(7,'Establo',1.1),(8,'Estanque/Reservorio',1),(9,'Funiculares',1),(10,'Galpón Avícola',1),(11,'Invernaderos',1),(12,'Muro de contención',1),(13,'Parques/jardines',1.2),(14,'Piscina camaronera',1.1),(15,'Piscina Piscícola',1.1),(16,'Piscina de natación',1.1),(17,'Pista de aterrizaje',2),(18,'Planta de pos cosecha',1),(19,'Pozo de riego',1),(20,'Relleno de quebradas',0.8),(21,'Sala de ordeño',1),(22,'Silo/almacenamiento',1),(23,'Tendales',1),(24,'Vás internas',1.5),(25,'Viveros',1),(26,'Otros',0.9);

/*Table structure for table `factor_pared` */

DROP TABLE IF EXISTS `factor_pared`;

CREATE TABLE `factor_pared` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_pared` */

insert  into `factor_pared`(`id`,`desc`,`coef`) values (1,'No tiene',0.2),(2,'Bahareque',0.6),(3,'Bloque',0.7),(4,'Caña',0.6),(5,'Ladrillo',1),(6,'Ferro Cemento',1),(7,'Gypsum',1),(8,'Prefabricado Hormigón Simple',1),(9,'Madera común',1),(10,'Madera procesada fina',1),(11,'Malla',0.7),(12,'Zinc',0.7),(13,'Lona',0.5),(14,'Piedra',0.8);

/*Table structure for table `factor_pendiente` */

DROP TABLE IF EXISTS `factor_pendiente`;

CREATE TABLE `factor_pendiente` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `clas` int(11) NOT NULL,
  `porc` varchar(10) COLLATE utf8_spanish_ci NOT NULL,
  `desc` varchar(20) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_pendiente` */

insert  into `factor_pendiente`(`id`,`clas`,`porc`,`desc`,`coef`) values (1,1,'0-5','Plana',1),(2,2,'5-10','Suave',1),(3,3,'10-20','Media',0.9),(4,4,'20-35','Fuerte',0.8),(5,5,'35-45','Muy fuerte',0.7),(6,6,'45-70','Escarpada',0.5),(7,7,'>70','Abrupta',0.8);

/*Table structure for table `factor_piso` */

DROP TABLE IF EXISTS `factor_piso`;

CREATE TABLE `factor_piso` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_piso` */

insert  into `factor_piso`(`id`,`desc`,`coef`) values (1,'No tiene',0.2),(2,'Adoquín',0.6),(3,'Alfombra',1),(4,'Cerámica',1),(5,'Césped sintético',1),(6,'Duela procesada',1),(7,'En cementado',0.8),(8,'Flotante',1),(9,'Gres',1),(10,'Láminas de tol carrujado',1),(11,'Madera común',1),(12,'Mármol',1),(13,'Marmolina',1),(14,'Parquet',1),(15,'Pintura de alto tráfico',0.8),(16,'Porcelanato',1),(17,'Tabón',0.9),(18,'Vinil',0.9);

/*Table structure for table `factor_poblac_cercana` */

DROP TABLE IF EXISTS `factor_poblac_cercana`;

CREATE TABLE `factor_poblac_cercana` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(40) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  `coef` double DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_poblac_cercana` */

insert  into `factor_poblac_cercana`(`id`,`desc`,`coef`) values (1,'Capital Provincial',1.1),(2,'Cabecera Cantonal',1),(3,'Cabecera Parroquial',0.95),(4,'Asentamientos Urbanos',0.9);

/*Table structure for table `factor_puerta` */

DROP TABLE IF EXISTS `factor_puerta`;

CREATE TABLE `factor_puerta` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_puerta` */

insert  into `factor_puerta`(`id`,`desc`,`coef`) values (1,'No tiene',0.2),(2,'Aluminio-vidrio',1),(3,'Hierro',1),(4,'Madera panelada',1),(5,'Madera tamboreada',1),(6,'Metálica enrollable',1),(7,'Plástico preformado',1),(8,'Tol',0.9),(9,'Vidrio templado',1),(10,'Caña',0.8),(11,'Malla',0.8);

/*Table structure for table `factor_recolec_basura` */

DROP TABLE IF EXISTS `factor_recolec_basura`;

CREATE TABLE `factor_recolec_basura` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_recolec_basura` */

insert  into `factor_recolec_basura`(`id`,`desc`,`coef`) values (1,'No tiene',0.2),(2,'Por carro recolector',1),(3,'Terreno baldío o quebrada',0.5),(4,'La queman',0.5),(5,'La entierran',0.5),(6,'Rio/acequia/canal',0.3),(7,'Otra forma',0.6);

/*Table structure for table `factor_reg_prop` */

DROP TABLE IF EXISTS `factor_reg_prop`;

CREATE TABLE `factor_reg_prop` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_reg_prop` */

insert  into `factor_reg_prop`(`id`,`desc`,`coef`) values (1,'Unipropiedad',1),(2,'Propiedad horizontal',0.9);

/*Table structure for table `factor_revest_cubierta` */

DROP TABLE IF EXISTS `factor_revest_cubierta`;

CREATE TABLE `factor_revest_cubierta` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_revest_cubierta` */

insert  into `factor_revest_cubierta`(`id`,`desc`,`coef`) values (1,'No tiene',0.7),(2,'Arena cemento',0.85),(3,'Asbesto cemento',0.85),(4,'Cady paja',0.85),(5,'Cerámica',1),(6,'Chova',0.85),(7,'Ferro cemento',1),(8,'Madera ladrillo',1),(9,'Policarbonato',1),(10,'Teja ordinaria',1),(11,'Teja vidriada',1),(12,'Tejuelo',1),(13,'Zinc',0.8);

/*Table structure for table `factor_revest_pared` */

DROP TABLE IF EXISTS `factor_revest_pared`;

CREATE TABLE `factor_revest_pared` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_revest_pared` */

insert  into `factor_revest_pared`(`id`,`desc`,`coef`) values (1,'No tiene',0.2),(2,'Calciminas',0.8),(3,'Caucho',0.4),(4,'Esmalte',0.6),(5,'Graniplast',0.8),(6,'Alucobond',0.8),(7,'Cerámica',1),(8,'Fachaleta',1),(9,'Laca',1);

/*Table structure for table `factor_riesgo` */

DROP TABLE IF EXISTS `factor_riesgo`;

CREATE TABLE `factor_riesgo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(40) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  `coef` double DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_riesgo` */

insert  into `factor_riesgo`(`id`,`desc`,`coef`) values (1,'No tiene',1.1),(2,'Deslaves',0.95),(3,'Hundimientos',0.9),(4,'Inundación',0.85),(5,'Heladas',0.8),(6,'Contaminación',0.8),(7,'Geológico',0.75),(8,'Vientos',0.74),(9,'Volcánico',0.73),(10,'Otro',0.7);

/*Table structure for table `factor_rodadura` */

DROP TABLE IF EXISTS `factor_rodadura`;

CREATE TABLE `factor_rodadura` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_rodadura` */

insert  into `factor_rodadura`(`id`,`desc`,`coef`) values (1,'No tiene',0.2),(2,'Adoquín de cemento',0.95),(3,'Adoquín de piedra',1),(4,'Empedrado',0.95),(5,'Lastre',0.9),(6,'Hormigón',1.3),(7,'Asfalto',1.2),(8,'Tierra',0.8);

/*Table structure for table `factor_tenenc_vivienda` */

DROP TABLE IF EXISTS `factor_tenenc_vivienda`;

CREATE TABLE `factor_tenenc_vivienda` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_tenenc_vivienda` */

insert  into `factor_tenenc_vivienda`(`id`,`desc`,`coef`) values (1,'Anticresis',0.7),(2,'Arrendada',0.8),(3,'Por servicios',0.8),(4,'Prestada o cedida',0.8),(5,'Propia',1),(6,'Propia y la está pagando',0.9),(7,'Propia y totalmente pagada',1);

/*Table structure for table `factor_tipo_predio` */

DROP TABLE IF EXISTS `factor_tipo_predio`;

CREATE TABLE `factor_tipo_predio` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_tipo_predio` */

insert  into `factor_tipo_predio`(`id`,`desc`,`coef`) values (1,'Rural',0),(2,'Urbano',0);

/*Table structure for table `factor_tipo_via` */

DROP TABLE IF EXISTS `factor_tipo_via`;

CREATE TABLE `factor_tipo_via` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_tipo_via` */

insert  into `factor_tipo_via`(`id`,`desc`,`coef`) values (1,'No tiene',0.7),(2,'Autopista',1.2),(3,'Avenida',1.1),(4,'Calle',1),(5,'Callejón',0.7),(6,'Camino de herradura',0.5),(7,'Escalinata',0.8),(8,'Pasaje',0.9),(9,'Peatonal',0.8),(10,'Sendero',0.8),(11,'Aérea',0.5),(12,'Férrea',0.5),(13,'Fluvial',0.5),(14,'Marítima',0.5);

/*Table structure for table `factor_titularidad` */

DROP TABLE IF EXISTS `factor_titularidad`;

CREATE TABLE `factor_titularidad` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_titularidad` */

insert  into `factor_titularidad`(`id`,`desc`,`coef`) values (1,'Con título',1),(2,'Sin título',0.9);

/*Table structure for table `factor_transporte_publico` */

DROP TABLE IF EXISTS `factor_transporte_publico`;

CREATE TABLE `factor_transporte_publico` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  `coef` double DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_transporte_publico` */

insert  into `factor_transporte_publico`(`id`,`desc`,`coef`) values (1,'No tiene',1),(2,'Inter - Provincial',1),(3,'Inter - Cantonal',1),(4,'Inter - Parroquial',1);

/*Table structure for table `factor_tumbado` */

DROP TABLE IF EXISTS `factor_tumbado`;

CREATE TABLE `factor_tumbado` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_tumbado` */

insert  into `factor_tumbado`(`id`,`desc`,`coef`) values (1,'No tiene',1),(2,'Caña enlucida',0.8),(3,'Fibra mineral',0.8),(4,'Gypsum',0.9),(5,'Madera procesada fina',1),(6,'Madera triplex',1),(7,'Malla enlucida',1);

/*Table structure for table `factor_unidad_vivienda` */

DROP TABLE IF EXISTS `factor_unidad_vivienda`;

CREATE TABLE `factor_unidad_vivienda` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_unidad_vivienda` */

insert  into `factor_unidad_vivienda`(`id`,`desc`,`coef`) values (1,'No aplica',1),(2,'Bodega',0.8),(3,'Casa',1),(4,'Choza',0.8),(5,'Covacha',0.7),(6,'Cuarto en casa',0.8),(7,'Departamento',1.1),(8,'Local comercial',1.1),(9,'Mediagua',0.8),(10,'Oficina',0.8),(11,'Otra vivienda',0.8),(12,'Parqueadero',0.8),(13,'Rancho',0.8),(14,'Villa',1);

/*Table structure for table `factor_uso_constructivo` */

DROP TABLE IF EXISTS `factor_uso_constructivo`;

CREATE TABLE `factor_uso_constructivo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=56 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_uso_constructivo` */

insert  into `factor_uso_constructivo`(`id`,`desc`,`coef`) values (1,'No tiene',0.2),(2,'Balcón',1),(3,'Banco',1.5),(4,'Baños Sauna/turco/hdroma',1.3),(5,'Bodega',0.9),(6,'Casa',1),(7,'Casa Comunal',1),(8,'Cuarto Máquinas/Basura',1),(9,'Departamento',1.1),(10,'Garita/Guardianía',1),(11,'Gimnasio',1.1),(12,'Guardería',1.2),(13,'Hospital',3),(14,'Hostal',1.5),(15,'Hostería',1.3),(16,'Hotel',1.3),(17,'Iglesia',1.3),(18,'Lavandería',1.1),(19,'Local Comercial',1.1),(20,'Malecón',1.8),(21,'Maternidad',2),(22,'Mercado',1.5),(23,'Mirador',1),(24,'Motel',1),(25,'Museo',1.2),(26,'Nave industrial',1.5),(27,'Oficina',1),(28,'Orfanato',1),(29,'Organismos Internacionales',1.1),(30,'Otros',0.8),(31,'Parqueadero',0.8),(32,'Patio/Jardín',1),(33,'Pensión',1),(34,'Plantel avícola',1),(35,'Plaza de toros',1),(36,'Porqueriza',0.6),(37,'Recinto militar',1),(38,'Recinto policial',1),(39,'Reclusorio',1),(40,'Representaciones Diplomáticas',1),(41,'Restaurante',1),(42,'Retén Policial',1),(43,'Sala comunal',1),(44,'Sala de cine',1),(45,'Sala de exposición',1),(46,'Sala de juegos',1),(47,'Sala de ordeño',1),(48,'Sala de culto/templo',1),(49,'Salas de hospitalización',2),(50,'Salón de eventos',1),(51,'Teatro',1.8),(52,'Terminal de Transferencia',1.3),(53,'Terinal interprovincial',1.3),(54,'Terraza',1),(55,'Unidad de policía comunitaria',1);

/*Table structure for table `factor_uso_predio` */

DROP TABLE IF EXISTS `factor_uso_predio`;

CREATE TABLE `factor_uso_predio` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_uso_predio` */

insert  into `factor_uso_predio`(`id`,`desc`,`coef`) values (1,'No tiene',0.2),(2,'Acuacultura',0.8),(3,'Agrícola',0.95),(4,'Agroindustrial',1.15),(5,'Bienestar Social',1.03),(6,'Casa Comunal',1),(7,'Comercial',1.08),(8,'Comercial y Residencial',1.08),(9,'Conservación',1),(10,'Cultural',1),(11,'Diplomático',1.03),(12,'Educación',1.03),(13,'Espacio Público',1),(14,'Financiero',1.03),(15,'Forestal',1),(16,'Hidrocarburos',1.15),(17,'Industrial',1.15),(18,'Institucional Privado',1.03),(19,'Institucional Público',1.03),(20,'Minero',0.8),(21,'Pecuario',0.8),(22,'Preservación Patrimonial',1),(23,'Protección Ecológica',1),(24,'Recreacion y Deporte',1),(25,'Religioso',1),(26,'Residencial',1),(27,'Salud',1.03),(28,'Seguridad',1.03),(29,'Servicios',1.03),(30,'Servicios Especiales',1.03),(31,'Trasporte',1.03),(32,'Turismo',1.08);

/*Table structure for table `factor_valor_cult` */

DROP TABLE IF EXISTS `factor_valor_cult`;

CREATE TABLE `factor_valor_cult` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_valor_cult` */

insert  into `factor_valor_cult`(`id`,`desc`,`coef`) values (1,'No tiene',1),(2,'Ancestral',1.2),(3,'Arquitectónico',1.4),(4,'Histórico',1.1);

/*Table structure for table `factor_ventana` */

DROP TABLE IF EXISTS `factor_ventana`;

CREATE TABLE `factor_ventana` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_ventana` */

insert  into `factor_ventana`(`id`,`desc`,`coef`) values (1,'No tiene',0.2),(2,'Aluminio',1),(3,'Caña',0.5),(4,'Hierro',1),(5,'Madera común',0.7),(6,'Madera procesada fina',0.9),(7,'Plástico preformado',0.6);

/*Table structure for table `factor_vidrio` */

DROP TABLE IF EXISTS `factor_vidrio`;

CREATE TABLE `factor_vidrio` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_vidrio` */

insert  into `factor_vidrio`(`id`,`desc`,`coef`) values (1,'No tiene',0.2),(2,'Malla',0.5),(3,'Vidrio común',1),(4,'Vidrio templado',1.1),(5,'Vidrio catedral',1.2);

/*Table structure for table `factor_viga` */

DROP TABLE IF EXISTS `factor_viga`;

CREATE TABLE `factor_viga` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `coef` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `factor_viga` */

insert  into `factor_viga`(`id`,`desc`,`coef`) values (1,'No tiene',0.2),(2,'Acero',1),(3,'Caña',0.8),(4,'Hierro',1),(5,'Hormigón Armado',1),(6,'Madera Común',0.7),(7,'Madera procesada fina',1);

/*Table structure for table `material_estructura` */

DROP TABLE IF EXISTS `material_estructura`;

CREATE TABLE `material_estructura` (
  `ma_id` int(11) NOT NULL AUTO_INCREMENT,
  `ma_desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  PRIMARY KEY (`ma_id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `material_estructura` */

insert  into `material_estructura`(`ma_id`,`ma_desc`) values (1,'Hormigón'),(2,'Ladrillo o Bloque'),(3,'Piedra'),(4,'Madera'),(5,'Metal'),(6,'Adobe o tapia'),(7,'Bahareque caña revestida'),(8,'Caña'),(9,'Aluminio y/o vidrio'),(10,'Plástico o lona'),(11,'Otro');

/*Table structure for table `valor_maquinaria` */

DROP TABLE IF EXISTS `valor_maquinaria`;

CREATE TABLE `valor_maquinaria` (
  `vme_id` int(11) NOT NULL AUTO_INCREMENT,
  `vme_cod` int(11) NOT NULL,
  `vme_desc` varchar(40) COLLATE utf8_spanish_ci NOT NULL,
  `vme_cost_hor` double NOT NULL,
  PRIMARY KEY (`vme_id`),
  UNIQUE KEY `vme_cod` (`vme_cod`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `valor_maquinaria` */

insert  into `valor_maquinaria`(`vme_id`,`vme_cod`,`vme_desc`,`vme_cost_hor`) values (1,2000,'Herramienta menor',0.5),(2,2001,'Compactador mecánico',5);

/*Table structure for table `valor_mat_pred` */

DROP TABLE IF EXISTS `valor_mat_pred`;

CREATE TABLE `valor_mat_pred` (
  `mp_id` int(11) NOT NULL AUTO_INCREMENT,
  `ac_id` int(11) NOT NULL,
  `ma_id` int(11) NOT NULL,
  `mp_cons` varchar(40) COLLATE utf8_spanish_ci NOT NULL,
  `mp_valor` double NOT NULL,
  PRIMARY KEY (`mp_id`),
  KEY `factor_mat_pred_ibfk_234` (`ac_id`),
  KEY `factor_mat_pred_ibfk_2` (`ma_id`),
  CONSTRAINT `valor_mat_pred_ibfk_2` FOREIGN KEY (`ma_id`) REFERENCES `material_estructura` (`ma_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `valor_mat_pred_ibfk_234` FOREIGN KEY (`ac_id`) REFERENCES `factor_acabado` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `valor_mat_pred` */

insert  into `valor_mat_pred`(`mp_id`,`ac_id`,`ma_id`,`mp_cons`,`mp_valor`) values (1,1,1,'Pared',42.94),(2,1,2,'Pared',24.45);

/*Table structure for table `valor_material` */

DROP TABLE IF EXISTS `valor_material`;

CREATE TABLE `valor_material` (
  `vm_id` int(11) NOT NULL AUTO_INCREMENT,
  `vm_desc` varchar(50) COLLATE utf8_spanish_ci NOT NULL,
  `vm_unid` varchar(4) COLLATE utf8_spanish_ci NOT NULL,
  `vm_precio` double NOT NULL,
  PRIMARY KEY (`vm_id`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `valor_material` */

insert  into `valor_material`(`vm_id`,`vm_desc`,`vm_unid`,`vm_precio`) values (1,'Agua','m3',5),(3,'Cemento','Kg',0.17),(4,'Ripio Minado','m3',12.5),(9,'Polvo de piedra','m3',10),(10,'Acero de refuerzo','Kg',1.11),(11,'Piedra Molón','m3',25),(12,'Clavos','Kg',1),(13,'Pared prefabricada','m2',16),(14,'Columna madera rustica','m',4.5),(15,'Columna caña guadua','m',1.5),(16,'Pared madera rustica','m2',8),(17,'Mampara de aluminio y vidrio','m2',100),(18,'Zinc','m2',6.5),(19,'Galvalumen','m2',13.4),(20,'Steel panel','m2',13.4),(21,'Adobe común','u',0.1),(22,'Tapial','m2',9),(23,'Arena fina','m3',25),(24,'Bloque Liviano','u',0.45),(25,'Eternit','m2',9.26),(26,'Ardex','m2',12.35),(27,'Duratecho','m2',8.33),(28,'Palma/alambre','m2',6),(29,'Paja/alambre','m2',5),(30,'Plastico reforzado','m2',3.2),(31,'Policarbonato','m2',10),(32,'Bahareque','m2',4),(33,'Latilla de caña','m2',2.2),(34,'Correa','Kg',1),(35,'Alfajia','m',1.5),(36,'Teja','u',0.35),(37,'Tira eucalipto','u',1.1),(38,'Tirafondo','u',0.5),(39,'Ladrillo','u',0.28),(40,'Perfil aluminio','m',41.5);

/*Table structure for table `valor_mejora` */

DROP TABLE IF EXISTS `valor_mejora`;

CREATE TABLE `valor_mejora` (
  `co_id` int(11) NOT NULL,
  `ma_id` int(11) NOT NULL,
  `vm_valor` double NOT NULL,
  KEY `fk_construccion001_idx` (`co_id`),
  KEY `fk_material001_idx` (`ma_id`),
  CONSTRAINT `fk_construccion001` FOREIGN KEY (`co_id`) REFERENCES `construcciones` (`co_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_material001` FOREIGN KEY (`ma_id`) REFERENCES `material_estructura` (`ma_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `valor_mejora` */

insert  into `valor_mejora`(`co_id`,`ma_id`,`vm_valor`) values (2,1,129.44);

/*Table structure for table `valor_mo` */

DROP TABLE IF EXISTS `valor_mo`;

CREATE TABLE `valor_mo` (
  `vmo_id` int(11) NOT NULL AUTO_INCREMENT,
  `vmo_desc` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `vmo_jornal` double NOT NULL,
  PRIMARY KEY (`vmo_id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*Data for the table `valor_mo` */

insert  into `valor_mo`(`vmo_id`,`vmo_desc`,`vmo_jornal`) values (1,'Peón',3.08),(2,'Albañil',3.22),(3,'Fierrero',3.22),(4,'Carpintero',3.22),(5,'Maestro',3.57),(6,'Chofer D',4.64),(7,'Soldador',3.22),(8,'Operador excabadora',3.57),(12,'Aluminero',3.39);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
