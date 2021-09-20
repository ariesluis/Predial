/*
SQLyog Ultimate v11.11 (64 bit)
MySQL - 5.6.17 : Database - db_arcgispredio
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`db_arcgispredio` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `db_arcgispredio`;

/*Table structure for table `predio_carac_fisi_predios` */

DROP TABLE IF EXISTS `predio_carac_fisi_predios`;

CREATE TABLE `predio_carac_fisi_predios` (
  `cfi_id` int(11) NOT NULL AUTO_INCREMENT,
  `cfi_form_predio` varchar(45) COLLATE latin1_spanish_ci DEFAULT NULL,
  `cfi_topografia` varchar(45) COLLATE latin1_spanish_ci DEFAULT NULL,
  `cfi_tipo_riesgo` varchar(45) COLLATE latin1_spanish_ci DEFAULT NULL,
  `cfi_erosion` varchar(45) COLLATE latin1_spanish_ci DEFAULT NULL,
  `cfi_clas_suelo` varchar(30) COLLATE latin1_spanish_ci DEFAULT NULL,
  `cfi_cob_nat_pred` varchar(30) COLLATE latin1_spanish_ci DEFAULT NULL,
  `cfi_ecos_rele` varchar(30) COLLATE latin1_spanish_ci DEFAULT NULL,
  `cfi_valor_cult` varchar(30) COLLATE latin1_spanish_ci DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`cfi_id`),
  KEY `predio_carac_fisi_predios_8f164b0d` (`fi_id`),
  CONSTRAINT `predio_carac_fisi_predios_fi_id_ac52f78a_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `predio_fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

/*Data for the table `predio_carac_fisi_predios` */

/*Table structure for table `predio_carac_princ_edific` */

DROP TABLE IF EXISTS `predio_carac_princ_edific`;

CREATE TABLE `predio_carac_princ_edific` (
  `cr_id` int(11) NOT NULL AUTO_INCREMENT,
  `cr_nro_bloque` varchar(45) DEFAULT NULL,
  `cr_nro_piso` varchar(45) DEFAULT NULL,
  `cr_cod_uso` varchar(45) DEFAULT NULL,
  `cr_uso` varchar(45) DEFAULT NULL,
  `cr_area_piso` double DEFAULT NULL,
  `cr_area_bloque` double DEFAULT NULL,
  `cr_mat_estruc_viga` varchar(45) DEFAULT NULL,
  `cr_mat_estruc_columna` varchar(45) DEFAULT NULL,
  `cr_mat_estruc_pared` varchar(45) DEFAULT NULL,
  `cr_mat_estruc_entrepiso` varchar(45) DEFAULT NULL,
  `cr_mat_estruc_contrapiso` varchar(45) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  `cr_mat_estruc_cubierta` varchar(45) DEFAULT NULL,
  `cr_mat_acab_piso` varchar(45) DEFAULT NULL,
  `cr_mat_acab_puerta` varchar(45) DEFAULT NULL,
  `cr_mat_acab_ventana` varchar(45) DEFAULT NULL,
  `cr_mat_acab_enlucidop` varchar(45) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  `cr_mat_acab_enlucidoc` varchar(45) DEFAULT NULL,
  `cr_mat_acab_cielorraso` varchar(45) DEFAULT NULL,
  `cr_instal_electrica` varchar(45) DEFAULT NULL,
  `cr_instal_sanitaria` varchar(45) DEFAULT NULL,
  `cr_instal_banio` varchar(45) DEFAULT NULL,
  `cr_estado` varchar(45) DEFAULT NULL,
  `cr_cond_fisica` varchar(30) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  `cr_anio_constr` varchar(45) DEFAULT NULL,
  `cr_acabado` varchar(40) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  `cr_vigente` varchar(1) NOT NULL DEFAULT 'a',
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`cr_id`),
  KEY `predio_carac_princ_edific_8f164b0d` (`fi_id`),
  CONSTRAINT `predio_carac_princ_edific_fi_id_053c4702_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `predio_fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

/*Data for the table `predio_carac_princ_edific` */

/*Table structure for table `predio_desc_suelos` */

DROP TABLE IF EXISTS `predio_desc_suelos`;

CREATE TABLE `predio_desc_suelos` (
  `ds_id` int(11) NOT NULL AUTO_INCREMENT,
  `ds_clase` varchar(30) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  `ds_area` double DEFAULT NULL,
  `ds_porc` double DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`ds_id`),
  KEY `fi_id` (`fi_id`),
  CONSTRAINT `predio_desc_suelos_ibfk_1` FOREIGN KEY (`fi_id`) REFERENCES `predio_fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `predio_desc_suelos` */

/*Table structure for table `predio_escrituras` */

DROP TABLE IF EXISTS `predio_escrituras`;

CREATE TABLE `predio_escrituras` (
  `es_id` int(11) NOT NULL AUTO_INCREMENT,
  `es_nro_notaria` varchar(45) DEFAULT NULL,
  `es_canton` varchar(45) DEFAULT NULL,
  `es_nro_reg_prop` varchar(45) DEFAULT NULL,
  `es_fecha` date DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`es_id`),
  KEY `predio_escrituras_81a691ac` (`fi_id`),
  CONSTRAINT `predio_escrituras_sl_id_d6da466f_fk_predio_situ_legal_sl_id` FOREIGN KEY (`fi_id`) REFERENCES `predio_fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;

/*Data for the table `predio_escrituras` */

/*Table structure for table `predio_fichas` */

DROP TABLE IF EXISTS `predio_fichas`;

CREATE TABLE `predio_fichas` (
  `fi_id` int(11) NOT NULL AUTO_INCREMENT,
  `fi_cod_prov` varchar(3) NOT NULL,
  `fi_cod_can` varchar(3) NOT NULL,
  `fi_cod_par` varchar(3) NOT NULL,
  `fi_cod_zon` varchar(3) NOT NULL,
  `fi_cod_sec` varchar(3) NOT NULL,
  `fi_cod_pol` varchar(3) NOT NULL,
  `fi_cod_pre` varchar(3) NOT NULL,
  `fi_cod_div` varchar(3) NOT NULL,
  `fi_cod_catastral` varchar(20) NOT NULL,
  `fi_cod_ant_pre` varchar(20) DEFAULT NULL,
  `pr_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`fi_id`),
  UNIQUE KEY `predio_fichas_fi_id_b6301d5d_uniq` (`fi_id`),
  KEY `predio_fichas_46aa1313` (`pr_id`),
  CONSTRAINT `predio_fichas_pr_id_4616d34e_fk_predio_propietarios_pr_id` FOREIGN KEY (`pr_id`) REFERENCES `predio_propietarios` (`pr_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=latin1;

/*Data for the table `predio_fichas` */

/*Table structure for table `predio_ident_divisiones` */

DROP TABLE IF EXISTS `predio_ident_divisiones`;

CREATE TABLE `predio_ident_divisiones` (
  `id_id` int(11) NOT NULL AUTO_INCREMENT,
  `id_responsable_aprob` varchar(45) DEFAULT NULL,
  `id_fecha_aprobacion` date DEFAULT NULL,
  `id_nombre_lotizacion` varchar(45) DEFAULT NULL,
  `id_nro_lote` varchar(45) DEFAULT NULL,
  `id_cod_jace` varchar(45) DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_id`),
  KEY `predio_ident_divisiones_8f164b0d` (`fi_id`),
  CONSTRAINT `predio_ident_divisiones_fi_id_c2894b79_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `predio_fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

/*Data for the table `predio_ident_divisiones` */

/*Table structure for table `predio_infra_serv_vias` */

DROP TABLE IF EXISTS `predio_infra_serv_vias`;

CREATE TABLE `predio_infra_serv_vias` (
  `iv_id` int(11) NOT NULL AUTO_INCREMENT,
  `iv_tipo_vial` varchar(45) DEFAULT NULL,
  `iv_mat_calzada` varchar(45) DEFAULT NULL,
  `iv_agua_consumo_hum` varchar(45) DEFAULT NULL,
  `iv_energia_electrica` varchar(45) DEFAULT NULL,
  `iv_alumbrado_public` varchar(45) DEFAULT NULL,
  `iv_estado_via` varchar(45) DEFAULT NULL,
  `iv_pobla_cerca_predio` varchar(45) DEFAULT NULL,
  `iv_alcantarillado` varchar(45) DEFAULT NULL,
  `iv_telefonia` varchar(45) DEFAULT NULL,
  `iv_transporte_public` varchar(45) DEFAULT NULL,
  `iv_acera` varchar(30) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  `iv_basura` varchar(30) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`iv_id`),
  KEY `predio_infra_serv_vias_8f164b0d` (`fi_id`),
  CONSTRAINT `predio_infra_serv_vias_fi_id_19dee8e8_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `predio_fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;

/*Data for the table `predio_infra_serv_vias` */

/*Table structure for table `predio_inversiones` */

DROP TABLE IF EXISTS `predio_inversiones`;

CREATE TABLE `predio_inversiones` (
  `in_id` int(11) NOT NULL AUTO_INCREMENT,
  `in_desc` varchar(45) DEFAULT NULL,
  `in_tipo_mat` varchar(45) DEFAULT NULL,
  `in_area` double DEFAULT NULL,
  `in_unid_med` varchar(10) DEFAULT NULL,
  `in_estado` varchar(45) DEFAULT NULL,
  `in_vigente` varchar(1) NOT NULL DEFAULT 'a',
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`in_id`),
  KEY `predio_ir_internas_8f164b0d` (`fi_id`),
  CONSTRAINT `predio_ir_internas_fi_id_9538f59a_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `predio_fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

/*Data for the table `predio_inversiones` */

/*Table structure for table `predio_linderos` */

DROP TABLE IF EXISTS `predio_linderos`;

CREATE TABLE `predio_linderos` (
  `li_id` int(11) NOT NULL AUTO_INCREMENT,
  `li_punto_card` varchar(45) DEFAULT NULL,
  `li_nom_propietario` varchar(60) DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`li_id`),
  KEY `predio_linderos_8f164b0d` (`fi_id`),
  CONSTRAINT `predio_linderos_fi_id_55df39aa_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `predio_fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=105 DEFAULT CHARSET=latin1;

/*Data for the table `predio_linderos` */

/*Table structure for table `predio_maq_equipos` */

DROP TABLE IF EXISTS `predio_maq_equipos`;

CREATE TABLE `predio_maq_equipos` (
  `mq_id` int(11) NOT NULL AUTO_INCREMENT,
  `mq_cod` varchar(45) DEFAULT NULL,
  `mq_denomicacion` varchar(45) DEFAULT NULL,
  `mq_marca` varchar(45) DEFAULT NULL,
  `mq_anio` varchar(45) DEFAULT NULL,
  `mq_estado` varchar(45) DEFAULT NULL,
  `mq_numero` varchar(45) DEFAULT NULL,
  `mq_vigente` varchar(1) NOT NULL DEFAULT 'a',
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`mq_id`),
  KEY `predio_maq_equipos_8f164b0d` (`fi_id`),
  CONSTRAINT `predio_maq_equipos_fi_id_c36cf856_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `predio_fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `predio_maq_equipos` */

/*Table structure for table `predio_observaciones` */

DROP TABLE IF EXISTS `predio_observaciones`;

CREATE TABLE `predio_observaciones` (
  `ob_id` int(11) NOT NULL AUTO_INCREMENT,
  `ob_desc` varchar(255) DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`ob_id`),
  KEY `predio_observaciones_8f164b0d` (`fi_id`),
  CONSTRAINT `predio_observaciones_fi_id_c856b740_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `predio_fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

/*Data for the table `predio_observaciones` */

/*Table structure for table `predio_propietarios` */

DROP TABLE IF EXISTS `predio_propietarios`;

CREATE TABLE `predio_propietarios` (
  `pr_id` int(11) NOT NULL AUTO_INCREMENT,
  `pr_dni` varchar(10) DEFAULT NULL,
  `pr_apellido` varchar(45) NOT NULL,
  `pr_nombre` varchar(45) DEFAULT NULL,
  `pr_fec_nac` date DEFAULT NULL,
  `pr_prop_ant` varchar(50) DEFAULT NULL,
  `pr_dir` varchar(50) DEFAULT NULL,
  `pr_tel` varchar(10) DEFAULT NULL,
  `pr_email` varchar(40) DEFAULT NULL,
  `pr_residencia_pro` varchar(20) DEFAULT NULL,
  `pr_rep_legal_dir` varchar(50) DEFAULT NULL,
  `pr_rep_legal_dni` varchar(10) DEFAULT NULL,
  `pr_rep_legal_nombre` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`pr_id`),
  UNIQUE KEY `predio_propietarios_pr_dni_2d74d10a_uniq` (`pr_dni`)
) ENGINE=InnoDB AUTO_INCREMENT=91 DEFAULT CHARSET=latin1;

/*Data for the table `predio_propietarios` */

/*Table structure for table `predio_ref_cartog` */

DROP TABLE IF EXISTS `predio_ref_cartog`;

CREATE TABLE `predio_ref_cartog` (
  `rc_id` int(11) NOT NULL AUTO_INCREMENT,
  `rc_descripcion` varchar(45) DEFAULT NULL,
  `rc_cod` varchar(45) DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`rc_id`),
  KEY `predio_ref_cartog_8f164b0d` (`fi_id`),
  CONSTRAINT `predio_ref_cartog_fi_id_23c857c6_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `predio_fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=141 DEFAULT CHARSET=latin1;

/*Data for the table `predio_ref_cartog` */

/*Table structure for table `predio_responsables` */

DROP TABLE IF EXISTS `predio_responsables`;

CREATE TABLE `predio_responsables` (
  `re_id` int(11) NOT NULL AUTO_INCREMENT,
  `re_empadronado` varchar(45) DEFAULT NULL,
  `re_fecha_emp` date DEFAULT NULL,
  `re_revisado` varchar(45) DEFAULT NULL,
  `re_fecha_rev` date DEFAULT NULL,
  `re_digitado` varchar(45) DEFAULT NULL,
  `re_fecha_dig` date DEFAULT NULL,
  `re_jefe_avaluo_catas` varchar(45) DEFAULT NULL,
  `re_fecha_jefe_aval_catas` date DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`re_id`),
  KEY `predio_responsables_8f164b0d` (`fi_id`),
  CONSTRAINT `predio_responsables_fi_id_27478ccf_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `predio_fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

/*Data for the table `predio_responsables` */

/*Table structure for table `predio_semovientes` */

DROP TABLE IF EXISTS `predio_semovientes`;

CREATE TABLE `predio_semovientes` (
  `se_id` int(11) NOT NULL AUTO_INCREMENT,
  `se_cod` varchar(45) DEFAULT NULL,
  `se_especie` varchar(45) DEFAULT NULL,
  `se_raza` varchar(45) DEFAULT NULL,
  `se_edad` int(11) DEFAULT NULL,
  `se_sangre` varchar(45) DEFAULT NULL,
  `se_numero` varchar(45) DEFAULT NULL,
  `se_vigente` varchar(1) NOT NULL DEFAULT 'a',
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`se_id`),
  KEY `predio_semovientes_8f164b0d` (`fi_id`),
  CONSTRAINT `predio_semovientes_fi_id_2203c199_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `predio_fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `predio_semovientes` */

/*Table structure for table `predio_serv_instal_predios` */

DROP TABLE IF EXISTS `predio_serv_instal_predios`;

CREATE TABLE `predio_serv_instal_predios` (
  `sp_id` int(11) NOT NULL AUTO_INCREMENT,
  `sp_abast_agua` varchar(45) DEFAULT NULL,
  `sp_evac_agua_servida` varchar(45) DEFAULT NULL,
  `sp_energia_elect` varchar(45) DEFAULT NULL,
  `sp_riego` varchar(45) DEFAULT NULL,
  `sp_num_med_prin_agua` varchar(45) DEFAULT NULL,
  `sp_num_med_prin_elec` varchar(45) DEFAULT NULL,
  `sp_num_medidores_agua` int(11) DEFAULT '0',
  `sp_num_medidores_elec` int(11) DEFAULT '0',
  `sp_num_lineas_tel` int(11) DEFAULT '0',
  `sp_num_telf_prin` varchar(15) DEFAULT NULL,
  `sp_met_riego` varchar(30) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  `sp_inst_esp` varchar(60) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`sp_id`),
  KEY `predio_serv_instal_predios_8f164b0d` (`fi_id`),
  CONSTRAINT `predio_serv_instal_predios_fi_id_36854012_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `predio_fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;

/*Data for the table `predio_serv_instal_predios` */

/*Table structure for table `predio_situ_legal` */

DROP TABLE IF EXISTS `predio_situ_legal`;

CREATE TABLE `predio_situ_legal` (
  `sl_id` int(11) NOT NULL AUTO_INCREMENT,
  `sl_dominio` varchar(45) DEFAULT NULL,
  `sl_desc_tenencia` varchar(45) DEFAULT NULL,
  `sl_trans_dominio` varchar(45) DEFAULT NULL,
  `sl_tipo_tenencia` varchar(45) DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`sl_id`),
  KEY `predio_situ_legal_8f164b0d` (`fi_id`),
  CONSTRAINT `predio_situ_legal_fi_id_a7a3e4be_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `predio_fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;

/*Data for the table `predio_situ_legal` */

/*Table structure for table `predio_superficies` */

DROP TABLE IF EXISTS `predio_superficies`;

CREATE TABLE `predio_superficies` (
  `su_id` int(11) NOT NULL AUTO_INCREMENT,
  `su_bloque_uno` double NOT NULL,
  `su_bloque_dos` double NOT NULL,
  `su_bloque_tres` double NOT NULL,
  `su_bloque_cuatro` double NOT NULL,
  `su_bloque_cinco` double NOT NULL,
  `su_bloque_seis` double NOT NULL,
  `su_frente` double NOT NULL,
  `su_area_total` double NOT NULL,
  `su_precio_base` double DEFAULT NULL,
  `fi_id` int(11) NOT NULL,
  PRIMARY KEY (`su_id`),
  KEY `fk_fi6798_idx` (`fi_id`),
  CONSTRAINT `fk_fi6798` FOREIGN KEY (`fi_id`) REFERENCES `predio_fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;

/*Data for the table `predio_superficies` */

/*Table structure for table `predio_ubicaciones` */

DROP TABLE IF EXISTS `predio_ubicaciones`;

CREATE TABLE `predio_ubicaciones` (
  `ub_id` int(11) NOT NULL AUTO_INCREMENT,
  `ub_cod_sector` varchar(45) DEFAULT NULL,
  `ub_nombre_sector` varchar(45) DEFAULT NULL,
  `ub_cod_via` varchar(45) DEFAULT NULL,
  `ub_nombre_via` varchar(45) DEFAULT NULL,
  `ub_nombre_predio` varchar(45) DEFAULT NULL,
  `ub_coordenadas_x` double DEFAULT NULL,
  `ub_coordenadas_y` double DEFAULT NULL,
  `ub_loc_manz` varchar(30) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`ub_id`),
  KEY `predio_ubicaciones_8f164b0d` (`fi_id`),
  CONSTRAINT `predio_ubicaciones_fi_id_91fe9ad4_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `predio_fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=57 DEFAULT CHARSET=latin1;

/*Data for the table `predio_ubicaciones` */

/*Table structure for table `predio_uso_actual_predios` */

DROP TABLE IF EXISTS `predio_uso_actual_predios`;

CREATE TABLE `predio_uso_actual_predios` (
  `uap_id` int(11) NOT NULL AUTO_INCREMENT,
  `uap_cod` varchar(45) DEFAULT NULL,
  `uap_uso_general` varchar(45) DEFAULT NULL,
  `uap_detalle_uso` varchar(45) DEFAULT NULL,
  `uap_edad` varchar(45) DEFAULT NULL,
  `uap_conservacion` varchar(45) DEFAULT NULL,
  `uap_extencion` double DEFAULT NULL,
  `uap_porcentaje` double DEFAULT NULL,
  `uap_vigente` varchar(1) NOT NULL DEFAULT 'a',
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`uap_id`),
  KEY `predio_uso_actual_predios_77fe886f` (`fi_id`),
  CONSTRAINT `predio_uso_actua_up_id_a0f78767_fk_predio_uso_ocup_predios_up_id` FOREIGN KEY (`fi_id`) REFERENCES `predio_fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

/*Data for the table `predio_uso_actual_predios` */

/*Table structure for table `predio_uso_ocup_predios` */

DROP TABLE IF EXISTS `predio_uso_ocup_predios`;

CREATE TABLE `predio_uso_ocup_predios` (
  `up_id` int(11) NOT NULL AUTO_INCREMENT,
  `up_cod_economico` varchar(45) DEFAULT NULL,
  `up_desc_economico` varchar(45) DEFAULT NULL,
  `up_tipo_usuario` varchar(45) DEFAULT NULL,
  `up_nro_bloq_terminado` int(11) DEFAULT NULL,
  `up_nro_bloq_construccion` int(11) DEFAULT NULL,
  `up_ocupacion` varchar(20) DEFAULT NULL,
  `fi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`up_id`),
  KEY `predio_uso_ocup_predios_8f164b0d` (`fi_id`),
  CONSTRAINT `predio_uso_ocup_predios_fi_id_7c31fe0f_fk_predio_fichas_fi_id` FOREIGN KEY (`fi_id`) REFERENCES `predio_fichas` (`fi_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=latin1;

/*Data for the table `predio_uso_ocup_predios` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
