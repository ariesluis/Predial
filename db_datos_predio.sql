/*
SQLyog Ultimate v11.11 (64 bit)
MySQL - 5.6.17 : Database - dbp_datos_predio
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`dbp_datos_predio` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `dbp_datos_predio`;

/*Table structure for table `avaluo` */

DROP TABLE IF EXISTS `avaluo`;

CREATE TABLE `avaluo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `av_terreno` double DEFAULT NULL,
  `av_cons` double DEFAULT NULL,
  `av_total_aval` double DEFAULT NULL,
  `av_imp_predio` double DEFAULT NULL,
  `av_imp_bomb` double DEFAULT NULL,
  `av_imp_admin` double DEFAULT NULL,
  `av_total_pagar` double DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fi_id` (`fi_id`),
  CONSTRAINT `avaluo_ibfk_1` FOREIGN KEY (`fi_id`) REFERENCES `fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `avaluo` */

/*Table structure for table `carac_fisicas` */

DROP TABLE IF EXISTS `carac_fisicas`;

CREATE TABLE `carac_fisicas` (
  `cf_id` int(11) NOT NULL AUTO_INCREMENT,
  `cf_forma` varchar(45) COLLATE latin1_spanish_ci NOT NULL,
  `cf_riesgo` varchar(45) COLLATE latin1_spanish_ci NOT NULL,
  `cf_erosion` varchar(45) COLLATE latin1_spanish_ci NOT NULL,
  `cf_clas_suelo` varchar(30) COLLATE latin1_spanish_ci NOT NULL,
  `cf_cob_nat` varchar(30) COLLATE latin1_spanish_ci NOT NULL,
  `cf_ecos_rele` varchar(30) COLLATE latin1_spanish_ci NOT NULL,
  `cf_valor_cult` varchar(30) COLLATE latin1_spanish_ci NOT NULL,
  `cf_area_tot` double NOT NULL,
  `cf_costo_base` double NOT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`cf_id`),
  KEY `carac_predios_8f164b0d` (`fi_id`),
  CONSTRAINT `arac_fisi_predios_fi_id_ac52f78a_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

/*Data for the table `carac_fisicas` */

/*Table structure for table `clases_agrol` */

DROP TABLE IF EXISTS `clases_agrol`;

CREATE TABLE `clases_agrol` (
  `ca_id` int(11) NOT NULL AUTO_INCREMENT,
  `ca_clase` varchar(30) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  `ca_area` double DEFAULT NULL,
  `ca_porc` double DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`ca_id`),
  KEY `fi_id` (`fi_id`),
  CONSTRAINT `clase_ago_ibfk_1` FOREIGN KEY (`fi_id`) REFERENCES `fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `clases_agrol` */

/*Table structure for table `cobert_vegetal` */

DROP TABLE IF EXISTS `cobert_vegetal`;

CREATE TABLE `cobert_vegetal` (
  `cv_id` int(11) NOT NULL AUTO_INCREMENT,
  `cv_desc` varchar(80) DEFAULT NULL,
  `cv_porc` double DEFAULT NULL,
  `cv_edad` varchar(20) DEFAULT NULL,
  `cv_est` varchar(20) DEFAULT NULL,
  `cv_ind` varchar(1) DEFAULT 'i',
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`cv_id`),
  KEY `cob_veg_88f164b0d` (`fi_id`),
  CONSTRAINT `predio_cob_veg_id_98854012_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `cobert_vegetal` */

/*Table structure for table `desc_construcciones` */

DROP TABLE IF EXISTS `desc_construcciones`;

CREATE TABLE `desc_construcciones` (
  `dc_id` int(11) NOT NULL AUTO_INCREMENT,
  `dc_nro_b` int(11) DEFAULT NULL,
  `dc_nro_pisos` int(11) DEFAULT NULL,
  `dc_cond_f` varchar(60) DEFAULT NULL,
  `dc_val_c` varchar(60) DEFAULT NULL,
  `dc_anio` varchar(4) DEFAULT NULL,
  `dc_area` double NOT NULL,
  `dc_elec` varchar(80) DEFAULT NULL,
  `dc_sanit` varchar(80) DEFAULT NULL,
  `dc_especial` varchar(80) DEFAULT NULL,
  `dc_nro_banio` varchar(80) DEFAULT NULL,
  `dc_costo_base` double DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`dc_id`),
  KEY `construcc_8f164b0d` (`fi_id`),
  CONSTRAINT `fi_id_2w7478ccf_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `desc_construcciones` */

/*Table structure for table `fichas` */

DROP TABLE IF EXISTS `fichas`;

CREATE TABLE `fichas` (
  `fi_id` int(11) NOT NULL AUTO_INCREMENT,
  `fi_cod_prov` varchar(3) NOT NULL,
  `fi_cod_can` varchar(3) NOT NULL,
  `fi_cod_par` varchar(3) NOT NULL,
  `fi_cod_zon` varchar(3) NOT NULL,
  `fi_cod_sec` varchar(3) NOT NULL,
  `fi_cod_pol` varchar(3) NOT NULL,
  `fi_cod_catastral` varchar(20) NOT NULL,
  `pr_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`fi_id`),
  UNIQUE KEY `predio_fichas_fi_id_b6301d5d_uniq` (`fi_id`),
  UNIQUE KEY `fi_cod_catastral` (`fi_cod_catastral`),
  KEY `predio_fichas_46aa1313` (`pr_id`),
  CONSTRAINT `predio_fichas_pr_id_4616d34e_fk_predio_propietarios_pr_id` FOREIGN KEY (`pr_id`) REFERENCES `propietarios` (`pr_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `fichas` */

/*Table structure for table `info_legal` */

DROP TABLE IF EXISTS `info_legal`;

CREATE TABLE `info_legal` (
  `il_id` int(11) NOT NULL AUTO_INCREMENT,
  `il_form_tenen` varchar(45) DEFAULT NULL,
  `il_sup_desc` varchar(20) DEFAULT NULL,
  `il_sup_area` double NOT NULL,
  `il_sup_unid` varchar(4) DEFAULT NULL,
  `il_dp_fec` date DEFAULT NULL,
  `il_dp_fecc` date DEFAULT NULL,
  `il_dp_aut` varchar(60) DEFAULT NULL,
  `il_dp_feci` date DEFAULT NULL,
  `il_dp_lugar` varchar(50) DEFAULT NULL,
  `il_dominio` varchar(30) DEFAULT NULL,
  `il_tip_tenen` varchar(40) DEFAULT NULL,
  `il_desc_tenen` varchar(50) DEFAULT NULL,
  `il_prop_ant` varchar(100) DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`il_id`),
  KEY `predio_situ_legal_8f164b0d` (`fi_id`),
  CONSTRAINT `predio_situ_legal_fi_id_a7a3e4be_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `info_legal` */

/*Table structure for table `linderos` */

DROP TABLE IF EXISTS `linderos`;

CREATE TABLE `linderos` (
  `li_id` int(11) NOT NULL AUTO_INCREMENT,
  `li_punt_card` varchar(45) DEFAULT NULL,
  `li_nom_prop` varchar(60) DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`li_id`),
  KEY `predio_linderos_8f164b0d` (`fi_id`),
  CONSTRAINT `predio_linderos_fi_id_55df39aa_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;

/*Data for the table `linderos` */

/*Table structure for table `localizacion` */

DROP TABLE IF EXISTS `localizacion`;

CREATE TABLE `localizacion` (
  `lo_id` int(11) NOT NULL AUTO_INCREMENT,
  `lo_nombre_predio` varchar(60) DEFAULT NULL,
  `lo_cod_sect` varchar(45) DEFAULT NULL,
  `lo_nom_sect` varchar(45) DEFAULT NULL,
  `lo_cod_via` varchar(45) DEFAULT NULL,
  `lo_nom_via` varchar(45) DEFAULT NULL,
  `lo_coor_x` double DEFAULT NULL,
  `lo_coor_y` double DEFAULT NULL,
  `lo_loc_manz` varchar(30) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`lo_id`),
  KEY `predio_ubicaciones_8f164b0d` (`fi_id`),
  CONSTRAINT `predio_ubicaciones_fi_id_91fe9ad4_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `localizacion` */

/*Table structure for table `maq_equipos` */

DROP TABLE IF EXISTS `maq_equipos`;

CREATE TABLE `maq_equipos` (
  `mq_id` int(11) NOT NULL AUTO_INCREMENT,
  `mq_den` varchar(45) DEFAULT NULL,
  `mq_marca` varchar(45) DEFAULT NULL,
  `mq_anio` varchar(45) DEFAULT NULL,
  `mq_estado` varchar(45) DEFAULT NULL,
  `mq_numero` varchar(45) DEFAULT NULL,
  `mq_vigente` varchar(1) NOT NULL DEFAULT 'a',
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`mq_id`),
  KEY `maq_equipos_8f164b0d` (`fi_id`),
  CONSTRAINT `maq_equipos_fi_id_c36cf856_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

/*Data for the table `maq_equipos` */

/*Table structure for table `mat_edificio` */

DROP TABLE IF EXISTS `mat_edificio`;

CREATE TABLE `mat_edificio` (
  `me_id` int(11) NOT NULL AUTO_INCREMENT,
  `me_nro_b` int(11) DEFAULT NULL,
  `me_tipo` varchar(80) DEFAULT NULL,
  `me_mat` varchar(80) DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`me_id`),
  KEY `edif_8f164b0d` (`fi_id`),
  CONSTRAINT `mat_edifi_78ccf_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `mat_edificio` */

/*Table structure for table `mejoras_predio` */

DROP TABLE IF EXISTS `mejoras_predio`;

CREATE TABLE `mejoras_predio` (
  `mp_id` int(11) NOT NULL AUTO_INCREMENT,
  `mp_desc` varchar(60) COLLATE latin1_spanish_ci DEFAULT NULL,
  `mp_mat` varchar(40) COLLATE latin1_spanish_ci DEFAULT NULL,
  `mp_unid` varchar(5) COLLATE latin1_spanish_ci DEFAULT NULL,
  `mp_cant` double DEFAULT NULL,
  `mp_estado` varchar(20) COLLATE latin1_spanish_ci DEFAULT NULL,
  `mp_vigencia` varchar(1) COLLATE latin1_spanish_ci DEFAULT 'a',
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`mp_id`),
  KEY `fi_id` (`fi_id`),
  CONSTRAINT `mejoras_predio_ibfk_1` FOREIGN KEY (`fi_id`) REFERENCES `fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

/*Data for the table `mejoras_predio` */

/*Table structure for table `met_linderacion` */

DROP TABLE IF EXISTS `met_linderacion`;

CREATE TABLE `met_linderacion` (
  `li_id` int(11) NOT NULL AUTO_INCREMENT,
  `li_desc` varchar(1) DEFAULT NULL,
  `li_obs` varchar(60) DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`li_id`),
  KEY `linderacion_8f164b0d` (`fi_id`),
  CONSTRAINT `linderos_fi_id_55df339aa_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

/*Data for the table `met_linderacion` */

/*Table structure for table `propietarios` */

DROP TABLE IF EXISTS `propietarios`;

CREATE TABLE `propietarios` (
  `pr_id` int(11) NOT NULL AUTO_INCREMENT,
  `pr_ci_nat` varchar(10) DEFAULT NULL,
  `pr_nom_nat` varchar(100) NOT NULL,
  `pr_fnac_nat` date DEFAULT NULL,
  `pr_ci_con` varchar(10) DEFAULT '-',
  `pr_nom_con` varchar(100) DEFAULT '-',
  `pr_fnac_con` date DEFAULT NULL,
  `pr_ruc_ju` varchar(10) DEFAULT '-',
  `pr_nom_ju` varchar(100) DEFAULT '-',
  `pr_acminis_ju` varchar(5) DEFAULT NULL,
  `pr_fnac_ju` date DEFAULT NULL,
  `pr_dni_rl` varchar(10) DEFAULT '-',
  `pr_nom_rl` varchar(100) DEFAULT NULL,
  `pr_dir` varchar(50) DEFAULT NULL,
  `pr_tel` varchar(10) DEFAULT NULL,
  `pr_email` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`pr_id`),
  UNIQUE KEY `predio_propietarios_pr_dni_2d674d10a_uniq` (`pr_nom_nat`),
  UNIQUE KEY `predio_propietarios_pr_dni_2d454d10a_uniq` (`pr_ci_nat`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `propietarios` */

/*Table structure for table `ref_cartog` */

DROP TABLE IF EXISTS `ref_cartog`;

CREATE TABLE `ref_cartog` (
  `rc_id` int(11) NOT NULL AUTO_INCREMENT,
  `rc_descripcion` varchar(45) DEFAULT NULL,
  `rc_cod` varchar(45) DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`rc_id`),
  KEY `ref_cartog_8f164b0d` (`fi_id`),
  CONSTRAINT `ref_cartog_fi_id_23c857c6_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

/*Data for the table `ref_cartog` */

/*Table structure for table `relieve` */

DROP TABLE IF EXISTS `relieve`;

CREATE TABLE `relieve` (
  `re_id` int(11) NOT NULL AUTO_INCREMENT,
  `re_desc` varchar(40) COLLATE latin1_spanish_ci DEFAULT NULL,
  `re_porc` double DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`re_id`),
  KEY `fi_id` (`fi_id`),
  CONSTRAINT `relieve_ibfk_1` FOREIGN KEY (`fi_id`) REFERENCES `fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

/*Data for the table `relieve` */

/*Table structure for table `responsables` */

DROP TABLE IF EXISTS `responsables`;

CREATE TABLE `responsables` (
  `re_id` int(11) NOT NULL AUTO_INCREMENT,
  `re_obser` varchar(255) DEFAULT NULL,
  `re_tcat` varchar(45) DEFAULT NULL,
  `re_fec_cat` date DEFAULT NULL,
  `re_tjur` varchar(45) DEFAULT NULL,
  `re_fec_jur` date DEFAULT NULL,
  `re_prop` varchar(45) DEFAULT NULL,
  `re_fecha_prop` date DEFAULT NULL,
  `re_test` varchar(45) DEFAULT NULL,
  `re_fecha_test` date DEFAULT NULL,
  `re_semp` varchar(45) DEFAULT NULL,
  `re_fec_emp` date DEFAULT NULL,
  `re_cgtc` varchar(45) DEFAULT NULL,
  `re_fec_gtc` date DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`re_id`),
  KEY `responsables_8f164b0d` (`fi_id`),
  CONSTRAINT `responsables_fi_id_27478ccf_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `responsables` */

/*Table structure for table `semovientes` */

DROP TABLE IF EXISTS `semovientes`;

CREATE TABLE `semovientes` (
  `se_id` int(11) NOT NULL AUTO_INCREMENT,
  `se_especie` varchar(45) DEFAULT NULL,
  `se_raza` varchar(45) DEFAULT NULL,
  `se_edad` varchar(15) DEFAULT NULL,
  `se_sangre` varchar(45) DEFAULT NULL,
  `se_numero` varchar(45) DEFAULT NULL,
  `se_vigente` varchar(1) NOT NULL DEFAULT 'a',
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`se_id`),
  KEY `semovientes_8f164b0d` (`fi_id`),
  CONSTRAINT `semovientes_fi_id_2203c199_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `semovientes` */

/*Table structure for table `servicios_predio` */

DROP TABLE IF EXISTS `servicios_predio`;

CREATE TABLE `servicios_predio` (
  `sp_id` int(11) NOT NULL AUTO_INCREMENT,
  `sp_agua` varchar(80) DEFAULT NULL,
  `sp_med_prin_agua` varchar(20) DEFAULT NULL,
  `sp_medid_agua` int(11) DEFAULT '0',
  `sp_elect` varchar(60) DEFAULT NULL,
  `sp_med_prin_elec` varchar(20) DEFAULT NULL,
  `sp_medid_elec` int(11) DEFAULT '0',
  `sp_num_telf_prin` varchar(15) DEFAULT NULL,
  `sp_num_lineas_tel` int(11) DEFAULT '0',
  `sp_alcant` varchar(45) DEFAULT NULL,
  `sp_riego` varchar(45) DEFAULT NULL,
  `sp_met_riego` varchar(30) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`sp_id`),
  KEY `predio_serv_instal_predios_8f164b0d` (`fi_id`),
  CONSTRAINT `predio_serv_instal_predios_fi_id_36854012_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `servicios_predio` */

/*Table structure for table `servicios_via` */

DROP TABLE IF EXISTS `servicios_via`;

CREATE TABLE `servicios_via` (
  `sv_id` int(11) NOT NULL AUTO_INCREMENT,
  `sv_tipo_via` varchar(50) DEFAULT NULL,
  `sv_mat_via` varchar(50) DEFAULT NULL,
  `sv_alumbrado` varchar(50) DEFAULT NULL,
  `sv_est_via` varchar(50) DEFAULT NULL,
  `sv_pobla_cerca` varchar(50) DEFAULT NULL,
  `sv_transp_public` varchar(50) DEFAULT NULL,
  `sv_acera` varchar(30) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  `sv_basura` varchar(50) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`sv_id`),
  KEY `serv_vias_8f164b0d` (`fi_id`),
  CONSTRAINT `serv_vias_fi_id_19dee8e8_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `servicios_via` */

/*Table structure for table `uso_suelos` */

DROP TABLE IF EXISTS `uso_suelos`;

CREATE TABLE `uso_suelos` (
  `us_id` int(11) NOT NULL AUTO_INCREMENT,
  `us_uso` varchar(45) DEFAULT NULL,
  `us_ext` double DEFAULT NULL,
  `us_porc` double DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`us_id`),
  KEY `predio_uso_actual_predios_77fe886f` (`fi_id`),
  CONSTRAINT `predio_uso_actua_up_id_a0f78767_fk_predio_uso_ocup_predios_up_id` FOREIGN KEY (`fi_id`) REFERENCES `fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `uso_suelos` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
