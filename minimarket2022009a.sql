-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 22, 2021 at 09:54 AM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `minimarket2022009a`
--

-- --------------------------------------------------------

--
-- Table structure for table `barang`
--

CREATE TABLE `barang` (
  `kode_barang` varchar(100) NOT NULL,
  `merk` varchar(100) DEFAULT NULL,
  `motif` varchar(100) DEFAULT NULL,
  `harga` double DEFAULT NULL,
  `jmlbrg` int(11) DEFAULT NULL,
  `satuan` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `barang`
--

INSERT INTO `barang` (`kode_barang`, `merk`, `motif`, `harga`, `jmlbrg`, `satuan`) VALUES
('BA2021120001', 'Luxurious', 'Rustic', 12000, 90, 'Roll'),
('BA2021120002', 'Glory', 'Galaxy', 12500, 100, 'Roll'),
('BA2021120003', 'XoXo', '3D', 12000, 120, 'Roll'),
('BA2021120004', 'Tokuniku', 'Modern Stripe', 13000, 100, 'Roll'),
('BA2021120005', 'Tridee', 'Polkadot', 12000, 120, 'Roll');

-- --------------------------------------------------------

--
-- Table structure for table `pemasok`
--

CREATE TABLE `pemasok` (
  `kode_pemasok` varchar(100) NOT NULL,
  `nama` varchar(100) DEFAULT NULL,
  `alamat` varchar(100) DEFAULT NULL,
  `notelp` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `pemasok`
--

INSERT INTO `pemasok` (`kode_pemasok`, `nama`, `alamat`, `notelp`) VALUES
('PE2021120001', 'Ahmad', 'Baloi', 812512),
('PE2021120002', 'Paula', 'Tiban', 854235),
('PE2021120003', 'Hendri', 'Baloi', 8574434);

-- --------------------------------------------------------

--
-- Table structure for table `pembayaran`
--

CREATE TABLE `pembayaran` (
  `nofaktur` varchar(100) DEFAULT NULL,
  `atas_nama` varchar(100) DEFAULT NULL,
  `tglbayar` date DEFAULT NULL,
  `totalbelanja` double DEFAULT NULL,
  `diskon` double DEFAULT NULL,
  `totbersih` double DEFAULT NULL,
  `dibayar` double DEFAULT NULL,
  `sisabayar` double DEFAULT NULL,
  `status` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `pembayaran`
--

INSERT INTO `pembayaran` (`nofaktur`, `atas_nama`, `tglbayar`, `totalbelanja`, `diskon`, `totbersih`, `dibayar`, `sisabayar`, `status`) VALUES
('JU2021120001', 'Arvy', '2021-12-22', 240000, 0, 240000, 250000, 10000, 'Lunas'),
('JU2021120002', 'Arvyy', '2021-12-22', 360000, 5, 342000, 350000, 8000, 'Lunas');

-- --------------------------------------------------------

--
-- Table structure for table `pengguna`
--

CREATE TABLE `pengguna` (
  `username` varchar(100) NOT NULL,
  `userfullname` varchar(100) DEFAULT NULL,
  `userpass` varchar(100) DEFAULT NULL,
  `useraktif` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `pengguna`
--

INSERT INTO `pengguna` (`username`, `userfullname`, `userpass`, `useraktif`) VALUES
('Amanda', 'Kasir', '827ccb0eea8a706c4c34a16891f84e7b', 1),
('Arvy', 'Admin', '827ccb0eea8a706c4c34a16891f84e7b', 1);

-- --------------------------------------------------------

--
-- Table structure for table `trans_pembelian`
--

CREATE TABLE `trans_pembelian` (
  `no_beli` varchar(100) NOT NULL,
  `tgl_beli` date DEFAULT NULL,
  `kode_pemasok` varchar(100) DEFAULT NULL,
  `nama` varchar(100) DEFAULT NULL,
  `kode_barang` varchar(100) DEFAULT NULL,
  `merk` varchar(100) DEFAULT NULL,
  `jml_masuk` int(11) DEFAULT NULL,
  `harga_beli` double DEFAULT NULL,
  `harga_satuan` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `trans_pembelian`
--

INSERT INTO `trans_pembelian` (`no_beli`, `tgl_beli`, `kode_pemasok`, `nama`, `kode_barang`, `merk`, `jml_masuk`, `harga_beli`, `harga_satuan`) VALUES
('BE2021120001', '2021-12-22', 'PE2021120001', 'Ahmad', 'BA2021120001', 'Luxurious', 100, 950000, 9500),
('BE2021120002', '2021-12-22', 'PE2021120002', 'Paula', 'BA2021120002', 'Glory', 100, 970000, 9700),
('BE2021120003', '2021-12-22', 'PE2021120001', 'Ahmad', 'BA2021120003', 'XoXo', 120, 1200000, 10000),
('BE2021120004', '2021-12-22', 'PE2021120003', 'Hendri', 'BA2021120004', 'Tokuniku', 100, 1000000, 10000),
('BE2021120005', '2021-12-22', 'PE2021120003', 'Hendri', 'BA2021120005', 'Tridee', 120, 1200000, 10000),
('BE2021120006', '2021-12-22', 'PE2021120001', 'Ahmad', 'BA2021120001', 'Luxurious', 20, 200000, 10000);

-- --------------------------------------------------------

--
-- Table structure for table `trans_penjualan`
--

CREATE TABLE `trans_penjualan` (
  `nofaktur` varchar(100) NOT NULL,
  `tgltransaksi` date DEFAULT NULL,
  `atas_nama` varchar(100) DEFAULT NULL,
  `notelp` int(11) DEFAULT NULL,
  `kode_barang` varchar(100) DEFAULT NULL,
  `jml_beli` double DEFAULT NULL,
  `jml_harga` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `trans_penjualan`
--

INSERT INTO `trans_penjualan` (`nofaktur`, `tgltransaksi`, `atas_nama`, `notelp`, `kode_barang`, `jml_beli`, `jml_harga`) VALUES
('JU2021120001', '2021-12-22', 'Arvy', 4643, 'BA2021120001', 20, 240000),
('JU2021120002', '2021-12-22', 'Arvyy', 81242, 'BA2021120001', 30, 360000);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `barang`
--
ALTER TABLE `barang`
  ADD PRIMARY KEY (`kode_barang`);

--
-- Indexes for table `pemasok`
--
ALTER TABLE `pemasok`
  ADD PRIMARY KEY (`kode_pemasok`);

--
-- Indexes for table `pembayaran`
--
ALTER TABLE `pembayaran`
  ADD KEY `pembayaran_ibfk_1` (`nofaktur`);

--
-- Indexes for table `pengguna`
--
ALTER TABLE `pengguna`
  ADD PRIMARY KEY (`username`);

--
-- Indexes for table `trans_pembelian`
--
ALTER TABLE `trans_pembelian`
  ADD PRIMARY KEY (`no_beli`),
  ADD KEY `trans_pembelian_ibfk_1` (`kode_pemasok`),
  ADD KEY `trans_pembelian_ibfk_2` (`kode_barang`);

--
-- Indexes for table `trans_penjualan`
--
ALTER TABLE `trans_penjualan`
  ADD PRIMARY KEY (`nofaktur`),
  ADD KEY `trans_penjualan_ibfk_1` (`kode_barang`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `pembayaran`
--
ALTER TABLE `pembayaran`
  ADD CONSTRAINT `pembayaran_ibfk_1` FOREIGN KEY (`nofaktur`) REFERENCES `trans_penjualan` (`nofaktur`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `trans_pembelian`
--
ALTER TABLE `trans_pembelian`
  ADD CONSTRAINT `trans_pembelian_ibfk_1` FOREIGN KEY (`kode_pemasok`) REFERENCES `pemasok` (`kode_pemasok`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `trans_pembelian_ibfk_2` FOREIGN KEY (`kode_barang`) REFERENCES `barang` (`kode_barang`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `trans_penjualan`
--
ALTER TABLE `trans_penjualan`
  ADD CONSTRAINT `trans_penjualan_ibfk_1` FOREIGN KEY (`kode_barang`) REFERENCES `barang` (`kode_barang`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
