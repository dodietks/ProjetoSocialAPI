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
DROP DATABASE IF EXISTS `projeto_social_api`;
CREATE DATABASE IF NOT EXISTS `projeto_social_api` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `projeto_social_api`;

-- Dumping structure for table projeto_social_api.address
DROP TABLE IF EXISTS `address`;
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
  `created_at` datetime(6) NOT NULL,
  `Modificated_at` datetime(6) NOT NULL,
  `created_by` longtext CHARACTER SET utf8mb4 NOT NULL,
  `modificated_by` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table projeto_social_api.person
DROP TABLE IF EXISTS `person`;
CREATE TABLE IF NOT EXISTS `person` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `login` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
  `password` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
  `disabled` tinyint(1) NOT NULL,
  `StudentId` bigint(20) DEFAULT NULL,
  `AddressId` bigint(20) DEFAULT NULL,
  `deleted` tinyint(1) NOT NULL,
  `created_at` datetime(6) NOT NULL,
  `Modificated_at` datetime(6) NOT NULL,
  `created_by` longtext CHARACTER SET utf8mb4 NOT NULL,
  `modificated_by` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`id`),
  KEY `IX_person_AddressId` (`AddressId`),
  KEY `IX_person_StudentId` (`StudentId`),
  CONSTRAINT `FK_person_address_AddressId` FOREIGN KEY (`AddressId`) REFERENCES `address` (`id`),
  CONSTRAINT `FK_person_student_StudentId` FOREIGN KEY (`StudentId`) REFERENCES `student` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table projeto_social_api.student
DROP TABLE IF EXISTS `student`;
CREATE TABLE IF NOT EXISTS `student` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `name` varchar(250) CHARACTER SET utf8mb4 DEFAULT NULL,
  `gender` int(11) NOT NULL,
  `email` varchar(50) CHARACTER SET utf8mb4 DEFAULT NULL,
  `attendence` int(11) NOT NULL,
  `avatarUrl` varchar(50) CHARACTER SET utf8mb4 DEFAULT NULL,
  `belt` int(11) NOT NULL,
  `degee` int(11) NOT NULL,
  `birthdate` datetime(6) NOT NULL,
  `deleted` tinyint(1) NOT NULL,
  `created_at` datetime(6) NOT NULL,
  `Modificated_at` datetime(6) NOT NULL,
  `created_by` longtext CHARACTER SET utf8mb4 NOT NULL,
  `modificated_by` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table projeto_social_api.__EFMigrationsHistory
DROP TABLE IF EXISTS `__EFMigrationsHistory`;
CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
