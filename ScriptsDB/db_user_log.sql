/*
SQLyog Ultimate v11.11 (64 bit)
MySQL - 5.6.17 : Database - db_user_log
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`db_user_log` /*!40100 DEFAULT CHARACTER SET latin1 COLLATE latin1_spanish_ci */;

USE `db_user_log`;

/*Table structure for table `accounts` */

DROP TABLE IF EXISTS `accounts`;

CREATE TABLE `accounts` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(30) COLLATE latin1_spanish_ci DEFAULT NULL,
  `password` varchar(50) COLLATE latin1_spanish_ci DEFAULT NULL,
  `us_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `us_id` (`us_id`),
  CONSTRAINT `accounts_ibfk_1` FOREIGN KEY (`us_id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

/*Data for the table `accounts` */

insert  into `accounts`(`id`,`username`,`password`,`us_id`) values (2,'ariesluis','827ccb0eea8a706c4c34a16891f84e7b',1);

/*Table structure for table `activities` */

DROP TABLE IF EXISTS `activities`;

CREATE TABLE `activities` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `actividad` varchar(100) COLLATE latin1_spanish_ci NOT NULL,
  `fecha` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `us_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`,`actividad`,`fecha`),
  KEY `us_id` (`us_id`),
  CONSTRAINT `activities_ibfk_1` FOREIGN KEY (`us_id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

/*Data for the table `activities` */

/*Table structure for table `users` */

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ci` varchar(10) COLLATE latin1_spanish_ci DEFAULT NULL,
  `apellido` varchar(40) COLLATE latin1_spanish_ci DEFAULT NULL,
  `nombre` varchar(40) COLLATE latin1_spanish_ci DEFAULT NULL,
  `cargo` varchar(40) COLLATE latin1_spanish_ci DEFAULT NULL,
  `estado` varchar(1) COLLATE latin1_spanish_ci DEFAULT 'a',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

/*Data for the table `users` */

insert  into `users`(`id`,`ci`,`apellido`,`nombre`,`cargo`,`estado`) values (1,'1105329922','Viñamagua','Luis','Administrador Base de Datos','a');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
