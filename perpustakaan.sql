/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50505
Source Host           : localhost:3306
Source Database       : perpustakaan

Target Server Type    : MYSQL
Target Server Version : 50505
File Encoding         : 65001

Date: 2020-01-03 12:32:52
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
INSERT INTO `tb_anggota` VALUES ('AGT00001', 'ALDO', 'hertasning', '1293819', 'M');
INSERT INTO `tb_anggota` VALUES ('AGT00002', 'AKBAR', 'alaudin', '812398123', 'D');

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
INSERT INTO `tb_buku` VALUES ('BKU1912000001', 'BOBO', 'PNG00001', 'PBT00001', '2019');
INSERT INTO `tb_buku` VALUES ('BKU1912000002', 'ROMEO N JULIET', 'PNG00002', 'PBT00002', '2012');

-- ----------------------------
-- Table structure for `tb_keranjang`
-- ----------------------------
DROP TABLE IF EXISTS `tb_keranjang`;
CREATE TABLE `tb_keranjang` (
  `no` int(2) NOT NULL AUTO_INCREMENT,
  `kd_buku` varchar(13) DEFAULT NULL,
  `judul` varchar(32) DEFAULT NULL,
  `tgl_kembali` date DEFAULT NULL,
  PRIMARY KEY (`no`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_keranjang
-- ----------------------------

-- ----------------------------
-- Table structure for `tb_keranjang_pengembalian`
-- ----------------------------
DROP TABLE IF EXISTS `tb_keranjang_pengembalian`;
CREATE TABLE `tb_keranjang_pengembalian` (
  `no` int(2) NOT NULL AUTO_INCREMENT,
  `kd_buku` varchar(13) DEFAULT NULL,
  `judul` varchar(32) DEFAULT NULL,
  `jmlhari` varchar(16) DEFAULT NULL,
  PRIMARY KEY (`no`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_keranjang_pengembalian
-- ----------------------------

-- ----------------------------
-- Table structure for `tb_peminjaman`
-- ----------------------------
DROP TABLE IF EXISTS `tb_peminjaman`;
CREATE TABLE `tb_peminjaman` (
  `kd_peminjaman` varchar(13) NOT NULL,
  `tanggal` date DEFAULT NULL,
  `kd_anggota` varchar(8) DEFAULT NULL,
  PRIMARY KEY (`kd_peminjaman`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_peminjaman
-- ----------------------------
INSERT INTO `tb_peminjaman` VALUES ('PJM2001000001', '2020-01-03', 'AGT00002');
INSERT INTO `tb_peminjaman` VALUES ('PJM2001000002', '2020-01-03', 'AGT00001');
INSERT INTO `tb_peminjaman` VALUES ('PJM2001000003', '2020-01-03', 'AGT00002');

-- ----------------------------
-- Table structure for `tb_peminjaman_detail`
-- ----------------------------
DROP TABLE IF EXISTS `tb_peminjaman_detail`;
CREATE TABLE `tb_peminjaman_detail` (
  `kd_peminjaman` varchar(13) DEFAULT NULL,
  `kd_buku` varchar(13) DEFAULT NULL,
  `tgl_kembali` date DEFAULT NULL,
  `status` char(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_peminjaman_detail
-- ----------------------------
INSERT INTO `tb_peminjaman_detail` VALUES ('PJM2001000001', 'BKU1912000001', '2020-01-07', '1');
INSERT INTO `tb_peminjaman_detail` VALUES ('PJM2001000001', 'BKU1912000002', '2020-01-10', '1');
INSERT INTO `tb_peminjaman_detail` VALUES ('PJM2001000002', 'BKU1912000001', '2020-01-10', '1');
INSERT INTO `tb_peminjaman_detail` VALUES ('PJM2001000003', 'BKU1912000002', '2020-01-10', '1');

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
INSERT INTO `tb_penerbit` VALUES ('PBT00001', 'GRAMEDIA');
INSERT INTO `tb_penerbit` VALUES ('PBT00002', 'ERLANGA');

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
INSERT INTO `tb_pengarang` VALUES ('PNG00001', 'ADI');
INSERT INTO `tb_pengarang` VALUES ('PNG00002', 'HARY POTER');

-- ----------------------------
-- Table structure for `tb_pengembalian`
-- ----------------------------
DROP TABLE IF EXISTS `tb_pengembalian`;
CREATE TABLE `tb_pengembalian` (
  `kd_pengembalian` varchar(13) NOT NULL,
  `tanggal` date DEFAULT NULL,
  `kd_peminjaman` varchar(13) DEFAULT NULL,
  PRIMARY KEY (`kd_pengembalian`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_pengembalian
-- ----------------------------
INSERT INTO `tb_pengembalian` VALUES ('', null, null);
INSERT INTO `tb_pengembalian` VALUES ('KBL2001000001', '2020-01-03', 'PJM2001000001');
INSERT INTO `tb_pengembalian` VALUES ('KBL2001000002', '2020-01-03', 'PJM2001000001');
INSERT INTO `tb_pengembalian` VALUES ('KBL2001000003', '2020-01-16', 'PJM2001000002');
INSERT INTO `tb_pengembalian` VALUES ('KBL2001000004', '2020-01-03', 'PJM2001000003');

-- ----------------------------
-- Table structure for `tb_pengembalian_detail`
-- ----------------------------
DROP TABLE IF EXISTS `tb_pengembalian_detail`;
CREATE TABLE `tb_pengembalian_detail` (
  `kd_pengembalian` varchar(13) DEFAULT NULL,
  `kd_buku` varchar(16) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_pengembalian_detail
-- ----------------------------
INSERT INTO `tb_pengembalian_detail` VALUES ('KBL2001000001', 'BKU1912000001');
INSERT INTO `tb_pengembalian_detail` VALUES ('KBL2001000002', 'BKU1912000002');
INSERT INTO `tb_pengembalian_detail` VALUES ('KBL2001000003', 'BKU1912000001');
INSERT INTO `tb_pengembalian_detail` VALUES ('KBL2001000004', 'BKU1912000002');
