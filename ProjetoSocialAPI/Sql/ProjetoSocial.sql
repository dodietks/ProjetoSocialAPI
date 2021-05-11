-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.7.22 - MySQL Community Server (GPL)
-- Server OS:                    Linux
-- HeidiSQL Version:             11.2.0.6213
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for projeto_social_api
CREATE DATABASE IF NOT EXISTS `projeto_social_api` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `projeto_social_api`;

-- Dumping structure for table projeto_social_api.address
CREATE TABLE IF NOT EXISTS `address` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `postal_code` varchar(50) CHARACTER SET utf8mb4 DEFAULT NULL,
  `country` varchar(50) CHARACTER SET utf8mb4 DEFAULT NULL,
  `state` varchar(50) CHARACTER SET utf8mb4 DEFAULT NULL,
  `city` varchar(50) CHARACTER SET utf8mb4 DEFAULT NULL,
  `street` varchar(50) CHARACTER SET utf8mb4 DEFAULT NULL,
  `number` int(11) NOT NULL,
  `complement` varchar(50) CHARACTER SET utf8mb4 DEFAULT NULL,
  `deleted` tinyint(1) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `Modificated_at` datetime(6) NOT NULL,
  `created_by` longtext CHARACTER SET utf8mb4,
  `modificated_by` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Dumping data for table projeto_social_api.address: ~0 rows (approximately)
/*!40000 ALTER TABLE `address` DISABLE KEYS */;
INSERT INTO `address` (`id`, `postal_code`, `country`, `state`, `city`, `street`, `number`, `complement`, `deleted`, `CreatedAt`, `Modificated_at`, `created_by`, `modificated_by`) VALUES
	(1, 'anim cupidatat dolore in', 'non', 'incididunt esse', 'laborum voluptate occaeca', 'tempor in proident', -63023955, 'dolore fugiat dolore', 0, '0001-01-01 00:00:00.000000', '1991-11-23 19:50:43.446000', 'thomas', 'consectetur dolor quis deserunt');
/*!40000 ALTER TABLE `address` ENABLE KEYS */;

-- Dumping structure for table projeto_social_api.person
CREATE TABLE IF NOT EXISTS `person` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `login` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
  `password` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `disabled` tinyint(1) NOT NULL,
  `StudentId` bigint(20) DEFAULT NULL,
  `AddressId` bigint(20) DEFAULT NULL,
  `TokenId` bigint(20) DEFAULT NULL,
  `deleted` tinyint(1) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `Modificated_at` datetime(6) NOT NULL,
  `created_by` longtext CHARACTER SET utf8mb4,
  `modificated_by` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`id`),
  KEY `IX_person_AddressId` (`AddressId`),
  KEY `IX_person_StudentId` (`StudentId`),
  KEY `IX_person_TokenId` (`TokenId`),
  CONSTRAINT `FK_person_address_AddressId` FOREIGN KEY (`AddressId`) REFERENCES `address` (`id`),
  CONSTRAINT `FK_person_student_StudentId` FOREIGN KEY (`StudentId`) REFERENCES `student` (`id`),
  CONSTRAINT `FK_person_token_TokenId` FOREIGN KEY (`TokenId`) REFERENCES `token` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Dumping data for table projeto_social_api.person: ~1 rows (approximately)
/*!40000 ALTER TABLE `person` DISABLE KEYS */;
INSERT INTO `person` (`id`, `login`, `password`, `disabled`, `StudentId`, `AddressId`, `TokenId`, `deleted`, `CreatedAt`, `Modificated_at`, `created_by`, `modificated_by`) VALUES
	(1, 'thomas', 'D3-86-81-07-44-67-C0-BC-14-7B-17-A9-A1-2B-9E-FA-8C-C1-0B-CF-54-5F-5B-0B-CC-CC-F5-A9-3C-4A-2B-79', 0, 1, 1, 10, 0, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000', NULL, NULL);
/*!40000 ALTER TABLE `person` ENABLE KEYS */;

-- Dumping structure for table projeto_social_api.student
CREATE TABLE IF NOT EXISTS `student` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `name` varchar(250) CHARACTER SET utf8mb4 DEFAULT NULL,
  `gender` int(11) NOT NULL,
  `email` varchar(50) CHARACTER SET utf8mb4 DEFAULT NULL,
  `attendance` int(11) NOT NULL,
  `avatarUrl` varchar(255) CHARACTER SET utf8mb4 DEFAULT NULL,
  `belt` int(11) NOT NULL,
  `degee` int(11) NOT NULL,
  `birthdate` datetime(6) NOT NULL,
  `deleted` tinyint(1) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `Modificated_at` datetime(6) NOT NULL,
  `created_by` longtext CHARACTER SET utf8mb4,
  `modificated_by` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Dumping data for table projeto_social_api.student: ~0 rows (approximately)
/*!40000 ALTER TABLE `student` DISABLE KEYS */;
INSERT INTO `student` (`id`, `name`, `gender`, `email`, `attendance`, `avatarUrl`, `belt`, `degee`, `birthdate`, `deleted`, `CreatedAt`, `Modificated_at`, `created_by`, `modificated_by`) VALUES
	(1, 'sit dolore', 20, 'pariatu', 0, 'oc', 20, 1, '1977-03-05 14:05:40.294000', 0, '0001-01-01 00:00:00.000000', '1944-05-23 01:57:50.952000', 'thomas', 'culpa deserunt');
/*!40000 ALTER TABLE `student` ENABLE KEYS */;

-- Dumping structure for table projeto_social_api.token
CREATE TABLE IF NOT EXISTS `token` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `token` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `token_refresh_time` datetime(6) NOT NULL,
  `deleted` tinyint(1) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `Modificated_at` datetime(6) NOT NULL,
  `created_by` longtext CHARACTER SET utf8mb4,
  `modificated_by` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

-- Dumping data for table projeto_social_api.token: ~8 rows (approximately)
/*!40000 ALTER TABLE `token` DISABLE KEYS */;
INSERT INTO `token` (`id`, `token`, `token_refresh_time`, `deleted`, `CreatedAt`, `Modificated_at`, `created_by`, `modificated_by`) VALUES
	(1, 'xbcS6tKjV/qO0CnfH5b14MhTiGciFOX4BetbC6wUEbc=', '2021-05-17 10:51:48.558466', 0, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000', NULL, NULL),
	(2, 'oixkp9hDniOOmDIxgF0QprXNSt1auhkiRqeEjXKVNds=', '2021-05-17 10:53:19.278293', 0, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000', NULL, NULL),
	(3, 'eZVvV2Tq3NVOflICbZY93KRVuKs46YmrbI+eBRCEfFU=', '2021-05-17 11:13:27.965556', 0, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000', NULL, NULL),
	(4, 'RYXo+yvuzLPCJIPF11zJXBEJuyIihbULkaOE74KbzZM=', '2021-05-17 11:15:47.718297', 0, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000', NULL, NULL),
	(5, 'ADLBXKRfizl++fXEKOML0V+ImWxcrxOedJ59ZnVGKo8=', '2021-05-17 11:16:14.809997', 0, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000', NULL, NULL),
	(6, 'oHnmLZ0yVbwixTSJDcEP09mO1C8yZquojNikC311Tf0=', '2021-05-17 11:16:24.986427', 0, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000', NULL, NULL),
	(7, 'siOfei3EQZoEUSeiou3r7qaNVa3X9hhIV7uSDJB10Sk=', '2021-05-17 11:16:33.883868', 0, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000', NULL, NULL),
	(8, '/pSSZi+gChDOc+j5lI+Oz883BKfWzgxVcYAIMdHPQnM=', '2021-05-17 11:16:40.030853', 0, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000', NULL, NULL),
	(9, '0zTHRGV/5esN1P1iTZk4Gu8tGvVnSnByPBLa1ZHizh8=', '2021-05-17 11:16:49.313699', 0, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000', NULL, NULL),
	(10, '2dDsdUnKKR6O77M7901IwS/SligLQVc7PyBc/sQPSVg=', '2021-05-17 11:27:34.540690', 0, '0001-01-01 00:00:00.000000', '0001-01-01 00:00:00.000000', NULL, NULL);
/*!40000 ALTER TABLE `token` ENABLE KEYS */;

-- Dumping structure for table projeto_social_api.__EFMigrationsHistory
CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table projeto_social_api.__EFMigrationsHistory: ~0 rows (approximately)
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
