/*
Navicat MySQL Data Transfer

Source Server         : databaseku
Source Server Version : 50505
Source Host           : localhost:3306
Source Database       : perpustakaan

Target Server Type    : MYSQL
Target Server Version : 50505
File Encoding         : 65001

Date: 2019-12-16 14:39:59
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `tb_anggota`
-- ----------------------------
DROP TABLE IF EXISTS `tb_anggota`;
CREATE TABLE `tb_anggota` (
  `kd_anggota` varchar(8) NOT NULL,
  `nama` varchar(32) DEFAULT NULL,
  `alamat` varchar(32) DEFAULT NULL,
  `no_telp` varchar(32) DEFAULT NULL,
  `role` char(1) DEFAULT NULL,
  PRIMARY KEY (`kd_anggota`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_anggota
-- ----------------------------

-- ----------------------------
-- Table structure for `tb_buku`
-- ----------------------------
DROP TABLE IF EXISTS `tb_buku`;
CREATE TABLE `tb_buku` (
  `kd_buku` varchar(16) DEFAULT NULL,
  `judul` varchar(32) DEFAULT NULL,
  `kd_pengarang` varchar(8) DEFAULT NULL,
  `kd_penerbit` varchar(8) DEFAULT NULL,
  `tahun_terbit` int(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_buku
-- ----------------------------

-- ----------------------------
-- Table structure for `tb_penerbit`
-- ----------------------------
DROP TABLE IF EXISTS `tb_penerbit`;
CREATE TABLE `tb_penerbit` (
  `kd_penerbit` varchar(8) DEFAULT NULL,
  `nama_penerbit` varchar(32) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_penerbit
-- ----------------------------

-- ----------------------------
-- Table structure for `tb_pengarang`
-- ----------------------------
DROP TABLE IF EXISTS `tb_pengarang`;
CREATE TABLE `tb_pengarang` (
  `kd_pengarang` varchar(8) NOT NULL,
  `nama_pengarang` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`kd_pengarang`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_pengarang
-- ----------------------------
