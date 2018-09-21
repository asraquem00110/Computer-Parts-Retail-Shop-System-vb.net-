-- phpMyAdmin SQL Dump
-- version 4.8.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 21, 2018 at 09:40 AM
-- Server version: 10.1.34-MariaDB
-- PHP Version: 7.0.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cprss`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `Delete_Systemuser` (IN `systemuserid` INT(11))  BEGIN


DELETE FROM `cprss`.`users`  
WHERE `user_id` = systemuserid;


END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllProducts` ()  BEGIN


SELECT `p`.`product_id`,`p`.`Description`,`p`.`brandname`,`p`.`cost_price`,
`c`.`category` 
FROM `cprss`.`products` `p` 
INNER JOIN `cprss`.`category` `c`;


END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `Insert_new_customer` (IN `lastname` VARCHAR(45), IN `firstname` VARCHAR(45), IN `address1` VARCHAR(45), IN `phonenum` VARCHAR(45))  BEGIN


INSERT INTO `cprss`.`customers` (`lname`,`fname`,`address`,`phonenumber`)
VALUES (lastname,firstname,address1,phonenum);

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `order_daily_report` ()  begin


set @sql_text2 = concat("SELECT o.Orderline_order_id,o.Products_product_id,
o.quantity_,o.cost_price,o.discount_price,((o.quantity_*o.cost_price)-o.discount_price) 

as Totalamount
,oi.orderdate into OUTFILE 'C:/cprss/eventreports/DailyReport/Cprssdaily_",DATE_FORMAT(now(),'%Y%m%d-%H%i%s'),'.csv', "' 

FIELDS TERMINATED BY ','
 OPTIONALLY ENCLOSED BY '\"'
 LINES TERMINATED BY '\n' FROM cprss.orderinfo o 
inner join cprss.orderline oi");
PREPARE s1 FROM @sql_text2;
EXECUTE s1;

DROP PREPARE s1;

end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `order_monthly_report` ()  begin


set @sql_text2 = concat("SELECT o.Orderline_order_id,o.Products_product_id,
o.quantity_,o.cost_price,o.discount_price,((o.quantity_*o.cost_price)-o.discount_price) 

as Totalamount
,oi.orderdate into OUTFILE 'C:/cprss/eventreports/MonthlyReport/Cprssmonthly_",DATE_FORMAT(now(),'%Y%m%d-%H%i%s'),'.csv', "' 

FIELDS TERMINATED BY ',' 
OPTIONALLY ENCLOSED BY '\"'
 LINES TERMINATED BY '\n' FROM cprss.orderinfo o 
inner join cprss.orderline oi");
PREPARE s1 FROM @sql_text2;
EXECUTE s1;

DROP PREPARE s1;

end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `Update_Supplier` (IN `Descriptions` VARCHAR(100), IN `Address1` VARCHAR(100), IN `phonenum` VARCHAR(45), IN `supplierid` INT(11))  BEGIN


UPDATE `cprss`.`suppliers` SET `Description`=Descriptions,`Address`=Address1,
`phoneno`=phonenum WHERE `supplier_id` = supplierid;


END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `category_id` int(11) NOT NULL,
  `category` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`category_id`, `category`) VALUES
(1, 'Processor'),
(2, 'Memory'),
(3, 'Hard disk'),
(4, 'Motherboard'),
(5, 'Graphics Card'),
(6, 'Cooling System'),
(7, 'NIC Card'),
(8, 'Optical Drive'),
(9, 'Power Supply'),
(10, 'Casing'),
(11, 'Mouse'),
(12, 'Keyboard'),
(13, 'Router'),
(14, 'Processor'),
(15, 'Memory'),
(16, 'Hard disk'),
(17, 'Motherboard'),
(18, 'Graphics Card'),
(19, 'Cooling System'),
(20, 'NIC Card'),
(21, 'Optical Drive'),
(22, 'Power Supply'),
(24, 'Mouse'),
(25, 'Keyboard'),
(26, 'Router');

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `customer_id` int(11) NOT NULL,
  `lname` varchar(100) DEFAULT NULL,
  `fname` varchar(100) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  `phonenumber` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`customer_id`, `lname`, `fname`, `address`, `phonenumber`) VALUES
(1, 'test', 'test', 'Philippines', '09123456789');

-- --------------------------------------------------------

--
-- Stand-in structure for view `customer_details`
-- (See below for the actual view)
--
CREATE TABLE `customer_details` (
`ID` int(11)
,`LastName` varchar(100)
,`FirstName` varchar(100)
,`address` varchar(100)
,`Phone Number` varchar(100)
);

-- --------------------------------------------------------

--
-- Table structure for table `orderinfo`
--

CREATE TABLE `orderinfo` (
  `quantity_` int(11) NOT NULL,
  `cost_price` decimal(20,2) DEFAULT NULL,
  `Orderline_order_id` int(11) NOT NULL,
  `Products_product_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `orderinfo`
--

INSERT INTO `orderinfo` (`quantity_`, `cost_price`, `Orderline_order_id`, `Products_product_id`) VALUES
(2, '8170.00', 1, 4),
(2, '2517.50', 1, 84);

-- --------------------------------------------------------

--
-- Table structure for table `orderline`
--

CREATE TABLE `orderline` (
  `order_id` int(11) NOT NULL,
  `orderdate` date DEFAULT NULL,
  `Customers_customer_id` int(11) NOT NULL,
  `Users_user_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `orderline`
--

INSERT INTO `orderline` (`order_id`, `orderdate`, `Customers_customer_id`, `Users_user_id`) VALUES
(1, '2018-09-21', 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `permissions`
--

CREATE TABLE `permissions` (
  `permission_id` int(11) NOT NULL,
  `Description` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `permissions`
--

INSERT INTO `permissions` (`permission_id`, `Description`) VALUES
(1, 'Make Transaction'),
(2, 'View System Users'),
(3, 'Add System Users'),
(4, 'Delete System Users'),
(5, 'Update System Users'),
(6, 'View Customer'),
(7, 'Add Customer'),
(8, 'Delete Customer'),
(9, 'Update Customer'),
(10, 'View Inventory'),
(11, 'Add Product'),
(12, 'Delete Product'),
(13, 'Update Inventory'),
(14, 'View Supplier'),
(15, 'Add Supplier'),
(16, 'Delete Supplier'),
(17, 'Update Supplier'),
(18, 'View Records'),
(19, 'View Roles');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `product_id` int(11) NOT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `brandname` varchar(100) DEFAULT NULL,
  `cost_price` decimal(20,2) DEFAULT NULL,
  `stocksonhand` int(11) NOT NULL DEFAULT '0',
  `category_category_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`product_id`, `Description`, `brandname`, `cost_price`, `stocksonhand`, `category_category_id`) VALUES
(1, 'AMD FM2 A4-6300 (3.7GHZ)OEM W FAN)', 'AMD', '1550.00', 20, 1),
(2, 'AMD FM2+ A6-7400K (3.5GHZ)OEM W FAN PROCESSOR', 'AMD', '2150.00', 20, 1),
(3, 'AMD FM2+ A8-7600 (3.1GHZ) PROCESSOR', 'AMD', '3550.00', 20, 1),
(4, 'AMD FX-8350 (4.0GHZ) BLK EDITION PROCESSOR', 'AMD', '8600.00', 20, 1),
(5, 'INTEL CELERON G1620 DUAL CORE (2.70GHZ) PROCESSOR', 'INTEL', '1800.00', 20, 1),
(6, 'INTEL CELERON G1820 DUAL CORE (2.70GHZ) PROCESSOR', 'INTEL', '1600.00', 20, 1),
(7, 'INTEL CELERON G1840 DUAL CORE (2.80GHZ) PROCESSOR', 'INTEL', '1700.00', 20, 1),
(8, 'INTEL CELERON G1840 DUAL CORE (2.80GHZ) PROCESSOR', 'INTEL', '5450.00', 20, 1),
(9, 'INTEL CORE I3-4170 (3.7GHZ) PROCESSOR', 'INTEL', '5450.00', 20, 1),
(10, 'INTEL CORE I3-6100 (3.7GHZ) PROCESSOR', 'INTEL', '5700.00', 20, 1),
(11, 'INTEL CORE I5-4460 (3.2GHZ) PROCESSOR', 'INTEL', '8600.00', 20, 1),
(12, 'INTEL CORE I5-4590 (3.30GHZ) PROCESSOR', 'INTEL', '9600.00', 20, 1),
(13, 'INTEL CORE I5-4690K (3.5GHZ) PROCESSOR', 'INTEL', '11550.00', 20, 1),
(14, 'INTEL CORE I5-6400 (2.7GHZ) PROCESSOR', 'INTEL', '8600.00', 20, 1),
(15, 'INTEL CORE I5-6500 (3.2GHZ) PROCESSOR', 'INTEL', '9800.00', 20, 1),
(16, 'INTEL CORE I5-6600 (3.3GHZ) PROCESSOR', 'INTEL', '10850.00', 20, 1),
(17, 'INTEL CORE I5-6600K (3.5GHZ) PROCESSOR', 'INTEL', '11800.00', 20, 1),
(18, 'INTEL CORE I7-4790 (3.6GHZ) PROCESSOR', 'INTEL', '14800.00', 20, 1),
(19, 'GSKILLS RIPJAWS X-RED 8GB (1X8GB) DDR3 MEMORY', 'GSKILLS', '1750.00', 20, 2),
(20, 'GSKILLS RIPJAWS X-RED 8GB (2X4GB) DDR3 1600MHZ MEMORY', 'GSKILLS', '1900.00', 20, 2),
(21, 'GSKILLS RIPJAWSV 16GB (2X8GB) DDR4-2400MHZ MEMORY', 'GSKILLS', '3400.00', 20, 2),
(22, 'GSKILLS RIPJAWSV 8GB (2X4GB) DDR4-2400MHZ MEMORY', 'GSKILLS', '1900.00', 20, 2),
(23, 'KINGSTON 16GB (2X8GB) 2133MHZ DDR4 FURY BLACK MEMORY', 'KINGSTON', '3500.00', 20, 2),
(24, 'KINGSTON 2GB DDR3 PC1333 (KVR13N9S6/2) MEMORY', 'KINGSTON', '600.00', 20, 2),
(25, 'KINGSTON 2GB DDR3 PC1600 SODIMM LOVO (KVR16LS11S6/2) MEMORY', 'KINGSTON', '600.00', 20, 2),
(26, 'KINGSTON 4GB 1600MHZ HYPERX FURY BLUE (KHX316C10F/4) MEMORY', 'KINGSTON', '1100.00', 20, 2),
(27, 'KINGSTON 4GB 2133MHZ FURY BLK (KHX421C14FB/4) MEMORY', 'KINGSTON', '1100.00', 20, 2),
(28, 'KINGSTON 4GB DDR3 PC1333 (KVR13N9S8/4) MEMORY', 'KINGSTON', '980.00', 20, 2),
(29, 'KINGSTON 4GB DDR3 PC1333 NON-ECC SODIMM MEMORY', 'KINGSTON', '1000.00', 20, 2),
(30, 'KINGSTON 4GB DDR3 PC1600 MEMORY', 'KINGSTON', '980.00', 20, 2),
(31, 'KINGSTON 4GB DDR3 PC1600 SODIMM LOVO (KVR16LS11/4) MEMORY', 'KINGSTON', '1000.00', 20, 2),
(32, 'KINGSTON 4GB DDR4 PC2133 SODIMM MEMORY', 'KINGSTON', '980.00', 20, 2),
(33, 'KINGSTON 8GB 1600MHZ HYPERX FURY BLUE (KHX316C10F/8) MEMORY', 'KINGSTON', '1900.00', 20, 2),
(34, 'KINGSTON 8GB 2133MHZ FURY BLK HX421C14FB/8 MEMORY', 'KINGSTON', '1900.00', 20, 2),
(35, 'KINGSTON 8GB DDR3 PC1600 SODIMM LOVO (KVR16LS11/8) MEMORY', 'KINGSTON', '1900.00', 20, 2),
(36, 'KINGSTON 8GB DDR3L PC1600 KVR16LN11/8 MEMORY', 'KINGSTON', '1800.00', 20, 2),
(37, 'KINGSTON 8GB DDR4 PC2133 SODIMM MEMORY', 'KINGSTON', '1850.00', 20, 2),
(38, 'INTEL 120GB 535 SERIES SOLID STATE DRIVE', 'INTEL', '2650.00', 20, 3),
(39, 'INTEL 120GB SOLID STATE DRIVE 540 SERIES', 'INTEL', '2700.00', 20, 3),
(40, 'INTEL 240GB 535 SERIES SOLID STATE DRIVE', 'INTEL', '4300.00', 20, 3),
(41, 'INTEL 240GB SOLID STATE DRIVE 540 SERIES', 'INTEL', '4600.00', 20, 3),
(42, 'KINGSTON 120GB HYPERX FURY SOLID STATE DRIVE', 'KINGSTON', '2450.00', 20, 3),
(43, 'KINGSTON 120GB SOLID STATE DRIVE NOW UV400 SERIES', 'KINGSTON', '1995.00', 20, 3),
(44, 'KINGSTON 120GB SSDNOW V300 SOLID STATE DRIVE', 'KINGSTON', '2350.00', 20, 3),
(45, 'KINGSTON 240GB HYPERX FURY SOLID STATE DRIVE', 'KINGSTON', '3950.00', 20, 3),
(46, 'KINGSTON 240GB SOLID STATE DRIVE NOW UV400 SERIES', 'KINGSTON', '3250.00', 20, 3),
(47, 'KINGSTON 240GB SSDNOW V300 SOLID STATE DRIVE', 'KINGSTON', '3800.00', 20, 3),
(48, 'KINGSTON 480GB SOLID STATE DRIVE NOW UV400 SERIES', 'KINGSTON', '6100.00', 20, 3),
(49, 'KINGSTON 480GB SSDNOW V300 SOLID STATE DRIVE', 'KINGSTON', '6450.00', 20, 3),
(50, 'SAMSUNG 120GB 850 EVO SOLID STATE DRIVE', 'SAMSUNG', '3150.00', 20, 3),
(51, 'SAMSUNG 250GB 850 EVO SOLID STATE DRIVE', 'SAMSUNG', '4600.00', 20, 3),
(52, 'SAMSUNG 500GB 850 EVO SOLID STATE DRIVE', 'SAMSUNG', '8450.00', 20, 3),
(53, 'SEAGATE 1TB SATA (ST1000VX001) SURVEILLANCE HARD DRIVE', 'SEAGATE', '2650.00', 20, 3),
(54, 'SEAGATE 1TB SATA 7200RPM SSHD', 'SEAGATE', '3900.00', 20, 3),
(55, 'SEAGATE 1TERABYTE SATA (ST1000DM003) HARD DRIVE', 'SEAGATE', '2500.00', 20, 3),
(56, 'SEAGATE 2TB SATA (ST2000VX003) SURVEILLANCE HARD DRIVE', 'SEAGATE', '3995.00', 20, 3),
(57, 'SEAGATE 2TB SATA 7200RPM HARD DRIVE', 'SEAGATE', '3750.00', 20, 3),
(58, 'SEAGATE 2TB SATA 7200RPM SSHD', 'SEAGATE', '5550.00', 20, 3),
(59, 'SEAGATE 2TB SATA SV35 (ST2000VX000) SURVEILLANCE HARD DRIVE', 'SEAGATE', '4350.00', 20, 3),
(60, 'SEAGATE 3TB 7200RPM SATA HARD DRIVE', 'SEAGATE', '4800.00', 20, 3),
(61, 'SEAGATE 4TB 5900RPM SATA HARD DRIVE', 'SEAGATE', '6750.00', 20, 3),
(62, 'COOLER MASTER SEIDON 120V PLUS LIQUID COOLING SYSTEM', 'COOLER MASTER', '2900.00', 20, 6),
(63, 'THERMALTAKE FRIO EXTREME CPU FAN', 'THERMALTAKE', '3800.00', 20, 6),
(64, 'THERMALTAKE FRIO OCK CPU FAN', 'THERMALTAKE', '3750.00', 20, 6),
(65, 'THERMALTAKE WATER 3.0 EXTREME-S CPU FAN', 'THERMALTAKE', '5050.00', 20, 6),
(66, 'THERMALTAKE WATER 3.0 PERFORMER-C CPU FAN', 'THERMALTAKE', '2450.00', 20, 6),
(67, 'XIGMATEK JANUS LD1266 120/80MM CPU FAN', 'XIGMATEK', '1900.00', 20, 6),
(68, 'XIGMATEK PRAETON LD963 CPU FAN', 'XIGMATEK', '1050.00', 20, 6),
(69, 'ZALMAN CNPS14X CPU FAN', 'ZALMAN', '2250.00', 20, 6),
(70, 'ZALMAN CNPS99000 MAX CPU FAN', 'ZALMAN', '3800.00', 20, 6),
(71, 'ASROCK FATALITY Z170 GAMING K4 MOTHERBOARD', 'ASROCK', '8150.00', 20, 4),
(72, 'ASROCK H110M-HDV MOTHERBOARD', 'ASROCK', '2995.00', 20, 4),
(73, 'ASUS A68HM-K FM2+ MOTHERBOARD', 'ASUS', '2500.00', 20, 4),
(74, 'ASUS B150M-A MOTHERBOARD', 'ASUS', '5150.00', 20, 4),
(75, 'ASUS B85-PRO GAMER LGA1150 MOTHERBOARD', 'ASUS', '5200.00', 20, 4),
(76, 'ASUS B85M-G LGA1150 MOTHERBOARD', 'ASUS', '3700.00', 20, 4),
(77, 'ASUS H81M-D S1150 MOTHERBOARD', 'ASUS', '2750.00', 20, 4),
(78, 'ASUS H97M-E LGA1150 MOTHERBOARD', 'ASUS', '4750.00', 20, 4),
(79, 'ECS A68M-C4DL V2 FM2+ MOTHERBOARD', 'ECS', '2100.00', 20, 4),
(80, 'ECS H110M-C3D S1151 MOTHERBOARD', 'ECS', '2500.00', 20, 4),
(81, 'ECS H110M4-C3D MOTHERBOARD', 'ECS', '2700.00', 20, 4),
(82, 'ECS H81H3-M4 GLV1.0A S1150 MOTHERBOARD', 'ECS', '1995.00', 20, 4),
(83, 'MSI A68HM-E33 V2 FM2+ MOTHERBOARD', 'MSI', '2400.00', 20, 4),
(84, 'MSI A78M-E35 V2/FM2+/AMD A78 MOTHERBOARD', 'MSI', '2650.00', 20, 4),
(85, 'MSI Z170A GAMING M7 LGA1151 MOTHERBOARD', 'MSI', '13700.00', 20, 4),
(86, 'MSI H81M-P33 S1150 MOTHERBOARD', 'MSI', '2450.00', 20, 4),
(87, 'MSI Z170A PCMATE LGA1151 MOTHERBOARD', 'MSI', '6800.00', 20, 4),
(88, 'ASUS GT630 1GB DDR3 64BIT KEPLER VIDEOCARD', 'ASUS', '2300.00', 20, 5),
(89, 'ASUS GT730 2GB DDR3 128BIT FERMI VIDEOCARD', 'ASUS', '2850.00', 20, 5),
(90, 'ASUS GTX750PHOC 1GB DDR5 128BIT VIDEOCARD', 'ASUS', '6200.00', 20, 5),
(91, 'ASUS GTX950 DC2OC STRIX 2GB DDR5 128BIT VIDEOCARD', 'ASUS', '9050.00', 20, 5),
(92, 'ASUS GTX960 DC2OC 2GB DDR5 128BIT BLACK EDITION VIDEOCARD', 'ASUS', '12600.00', 20, 5),
(93, 'ASUS GTX960 DC2OC STRIX 2GB DDR5 128BIT OC VIDEOCARD', 'ASUS', '11200.00', 20, 5),
(94, 'ASUS GTX960 STRIX OC 4GB DDR5 128BIT VIDEOCARD', 'ASUS', '11650.00', 20, 5),
(95, 'ASUS GTX960 TURBO 2GB DDR5 128BIT OC WHT VIDEOCARD', 'ASUS', '9995.00', 20, 5),
(96, 'ASUS GTX960 TURBO 4GB DDR5 128BIT OC WHT VIDEOCARD', 'ASUS', '10800.00', 20, 5),
(97, 'ASUS GTX970 STRIX OC 4GB DDR5 256BIT VIDEOCARD', 'ASUS', '20100.00', 20, 5),
(98, 'ASUS GTX970 TURBO 4GB DDR5 256BIT OC WHT VIDEOCARD', 'ASUS', '18000.00', 20, 5),
(99, 'ASUS GTX980TI STRIX OC 6GB DDR5 384BIT VIDEOCARD', 'ASUS', '39200.00', 20, 5),
(100, 'ASUS R9 280 DC2T 3GB DDR5 384BIT VIDEOCARD', 'ASUS', '16350.00', 20, 5),
(101, 'ASUS RX480 8GB DDR5 256BIT GRAPHICS CARD', 'ASUS', '16700.00', 20, 5),
(102, 'EVGA GTX750 FTW 1GB DDR5 128BIT VIDEOCARD', 'EVGA', '6750.00', 20, 5),
(103, 'EVGA GTX750TI FTW 2GB DDR5 128BIT VIDEOCARD', 'EVGA', '8000.00', 20, 5),
(104, 'EVGA GTX960 SSC 2GB DDR5 128BIT VIDEOCARD', 'EVGA', '12750.00', 20, 5),
(105, 'EVGA GTX970 SSC 4GB DDR5 256BIT VIDEOCARD', 'EVGA', '19300.00', 20, 5),
(106, 'INNO3D GT630 1GB DDR3 64B KEPLER VIDEOCARD', 'INNO3D', '2200.00', 20, 5),
(107, 'INNO3D GT630 2GB DDR3 64B KEPLER VIDEOCARD', 'INNO3D', '2500.00', 20, 5),
(108, 'INNO3D GT730 2GB DDR5 64BIT KEPLER VIDEOCARD', 'INNO3D', '3050.00', 20, 5),
(109, 'INNO3D GT730 2GB DDR3 128BIT FERMI VIDEOCARD', 'INNO3D', '2700.00', 20, 5),
(110, 'INNO3D GT730 2GB DDR3 64BIT KEPLER VIDEOCARD', 'INNO3D', '2600.00', 20, 5),
(111, 'INNO3D GTX650 1GB GDDR5 128BIT GREEN VIDEOCARD', 'INNO3D', '4050.00', 20, 5),
(112, 'DLINK DFE-528TX/DFE-520TX 10/100MBPS LAN CARD', 'DLINK', '330.00', 20, 7),
(113, 'DLINK DWA-525 PCI WIRELESS LAN CARD', 'DLINK', '650.00', 20, 7),
(114, 'LINK TL-WN851N 300MBPS WIRELESS N PCI ADAPTER', 'LINK', '880.00', 20, 7),
(115, 'LINK TL-WN881ND 300MBPS WIRELESS N PCI EXPRESS ADAPTER', 'LINK', '880.00', 20, 7),
(116, 'TP-LINK TF-3239DL 10/100 LAN CARD', 'TP-LINK', '210.00', 20, 7),
(117, 'TP-LINK TG-3269 GIGABIT LAN CARD', 'TP-LINK', '450.00', 20, 7),
(118, 'TP-LINK TG-3468 LAN CARD', 'TP-LINK', '570.00', 20, 7),
(119, 'LITE-ON IHAS-124 24X SATA BLK W/ BOX', 'LITE-ON', '800.00', 20, 8),
(120, 'SAMSUNG ODE1SH-224DB(224FB)/BSBS 22X SATA DVDRW (OEM)', 'SAMSUNG', '800.00', 20, 8),
(121, 'LITE-ON IHAS-124 OPTICAL DISK DRIVE DVD-RW SATA BLACK OEM', 'LITE-ON', '700.00', 20, 8),
(122, 'LITE-ON EBAU108 EXTERNAL OPTICAL DISK DRIVE DVD-RW USB BLACK', 'LITE-ON', '1150.00', 20, 8),
(123, 'AEROCOOL STRIKE-X 500W 80+ BRONZE MODULAR POWER SUPPLY', 'AEROCOOL', '2750.00', 20, 9),
(124, 'AEROCOOL STRIKE-X 500W 80+ BRONZE POWER SUPPLY', 'AEROCOOL', '2200.00', 20, 9),
(125, 'AEROCOOL STRIKE-X 600W 80+ BRONZE POWER SUPPLY', 'AEROCOOL', '2650.00', 20, 9),
(126, 'COOLER MASTER B600 V2 600W 80+ POWER SUPPLY', 'COOLER MASTER', '3150.00', 20, 9),
(127, 'COOLER MASTER GX-2 550W 80+ SLI 550W POWER SUPPLY', 'COOLER MASTER', '3550.00', 20, 9),
(128, 'COOLER MASTER THUNDER 450W POWER SUPPLY', 'COOLER MASTER', '1950.00', 20, 9),
(129, 'COOLER MASTER THUNDER 500W 80+ POWER SUPPLY', 'COOLER MASTER', '2450.00', 20, 9),
(130, 'CORSAIR VS550 550W POWER SUPPLY', 'CORSAIR', '2300.00', 20, 9),
(131, 'CORSAIR VS650 650W POWER SUPPLY', 'CORSAIR', '2800.00', 20, 9),
(132, 'COUGAR SL500 500W POWER SUPPLY', 'COUGAR', '1995.00', 20, 9),
(133, 'FSP AURUM 500 80PLUS GOLD SLI 500WATTS POWER SUPPLY', 'FSP', '3650.00', 20, 9),
(134, 'FSP AURUM 600 80PLUS GOLD SLI 600WATTS POWER SUPPLY', 'FSP', '4300.00', 20, 9),
(135, 'FSP HEXA HE-600 600WATTS POWER SUPPLY', 'FSP', '2900.00', 20, 9),
(136, 'FSP HEXA HE+450 450WATTS POWER SUPPLY', 'FSP', '1600.00', 20, 9),
(137, 'FSP HYPER 500W 85% EFFICIENCY POWER SUPPLY', 'FSP', '2350.00', 20, 9),
(138, 'FSP HYPER 600W 85% EFFICIENCY POWER SUPPLY', 'FSP', '2800.00', 20, 9),
(139, 'FSP HYPER 700W 85% EFFICIENCY POWER SUPPLY', 'FSP', '3250.00', 20, 9),
(140, 'FSP RAIDER 550W 80+ SILVER POWER SUPPLY', 'FSP', '2950.00', 20, 9),
(141, 'FSP RAIDER 650W 80+ SILVER POWER SUPPLY', 'FSP', '3200.00', 20, 9),
(142, 'FSP RAIDER 750W 80+ SILVER POWER SUPPLY', 'FSP', '3450.00', 20, 9),
(143, 'AEROCOOL AERO-1000 BLACK GAMING CASE', 'AEROCOOL', '3300.00', 20, 10),
(144, 'AEROCOOL AERO-800 GREY GAMING CASE', 'AEROCOOL', '2900.00', 20, 10),
(145, 'AEROCOOL CRUISE STAR ADVANCE BLACK GAMING CASE', 'AEROCOOL', '2050.00', 20, 10),
(146, 'AEROCOOL GT-A BLK GAMING CASE', 'AEROCOOL', '2800.00', 20, 10),
(147, 'AEROCOOL GT-R BLACK CASING', 'AEROCOOL', '3550.00', 20, 10),
(148, 'AEROCOOL VS-92 BLK GAMING CASING', 'AEROCOOL', '2200.00', 20, 10),
(149, 'COOLER MASTER ELITE 110 MINI ITX USB 3.0 GAMING CHASSIS', 'COOLER MASTER', '2200.00', 20, 10),
(150, 'COOLER MASTER ELITE K350 W/ WINDOW CASING', 'COOLER MASTER', '2200.00', 20, 10),
(151, 'COOLER MASTER ELITE RC102 W/ 500W PSU CASING', 'COOLER MASTER', '2050.00', 20, 10),
(152, 'COOLER MASTER K280 W/O POWERSUPPLY CASING', 'COOLER MASTER', '1950.00', 20, 10),
(153, 'COOLER MASTER LAN 241 BLACK CASING', 'COOLER MASTER', '1300.00', 20, 10),
(154, 'COOLER MASTER MASTER CASE 5 PRO FULL MODULAR BLACK CASING', 'COOLER MASTER', '8200.00', 20, 10),
(155, 'COOLER MASTER N200 CASING', 'COOLER MASTER', '2200.00', 20, 10),
(156, 'COOLER MASTER N300 USB 3.0 W/ WINDOW CASING', 'COOLER MASTER', '2350.00', 20, 10),
(157, 'COOLER MASTER NSE-400-KWN2 CASING', 'COOLER MASTER', '2700.00', 20, 10),
(158, 'COOLER MASTER STORM TROOPER USB3.0 CASING', 'COOLER MASTER', '7700.00', 20, 10),
(159, 'GENIUS TRAVELER 6000Z WIRELESS BLUE MOUSE', 'GENIUS', '400.00', 20, 11),
(160, 'GENIUS TRAVELER 6000Z WIRELESS MOUSE', 'GENIUS', '400.00', 20, 11),
(161, 'GENIUS TRAVELER 6000Z WIRELESS RED MOUSE', 'GENIUS', '400.00', 20, 11),
(162, 'LOGITECH B100 USB BLK MOUSE', 'LOGITECH', '240.00', 20, 11),
(163, 'LOGITECH G500S 8200DPI 10-PROGRAMMABLE BUTTONS LASER GAMING MOUSE', 'LOGITECH', '2450.00', 20, 11),
(164, 'LOGITECH M185 GRAY WIRELESS MOUSE', 'LOGITECH', '650.00', 20, 11),
(165, 'LOGITECH M238 PLAY BLUE FACETS WIRELESS MOUSE', 'LOGITECH', '800.00', 20, 11),
(166, 'LOGITECH M545 WIRELESS BLK MOUSE', 'LOGITECH', '1150.00', 20, 11),
(167, 'A4TECH OP-720 MOUSE PS2', 'A4TECH', '130.00', 20, 11),
(168, 'A4TECH OP-720 MOUSE USB', 'A4TECH', '160.00', 20, 11),
(169, 'A4TECH OP-620D 2X CLICK MOUSE PS2', 'A4TECH', '165.00', 20, 11),
(170, 'A4TECH OP-620D 2X CLICK MOUSE USB', 'A4TECH', '180.00', 20, 11),
(171, 'A4TECH OP-620D 2X CLICK MOUSE USB', 'A4TECH', '180.00', 20, 11),
(172, 'A4TECH KD-800L BACKLIGHT USB KEYBOARD', 'A4TECH', '930.00', 20, 12),
(173, 'A4TECH KLS-7MU X-SLIM W/ MIC AND USB PS/2 KEYBOARD', 'A4TECH', '700.00', 20, 12),
(174, 'A4TECH KRS-83 USB BLACK KEYBOARD', 'A4TECH', '360.00', 20, 12),
(175, 'LOGITECH K270 WIRELESS KEYBOARD', 'LOGITECH', '900.00', 20, 12),
(176, 'LOGITECH K400 PLUS WIRELESS/TOUCH KEYBOARD', 'LOGITECH', '2100.00', 20, 12),
(177, 'RAPOO E9070 WIRELESS ULTRA-SLIM KEYBOARD', 'RAPOO', '1050.00', 20, 12),
(178, 'RAPOO E9080 WIRELESS TOUCHPAD KEYBOARD', 'RAPOO', '1650.00', 20, 12),
(179, 'RAPOO E9080 WIRELESS TOUCHPAD KEYBOARD', 'RAPOO', '1650.00', 20, 12);

--
-- Triggers `products`
--
DELIMITER $$
CREATE TRIGGER `after_update_on_products` AFTER UPDATE ON `products` FOR EACH ROW begin


INSERT INTO product_audit (Product_id,audit_user,action_description,olddescription,oldbrandname,
oldcategory_id,oldstocksonhand,oldcost,Datetriggered)

values (old.product_id,current_user(),"UPDATE",old.Description,old.brandname,
old.category_category_id,old.stocksonhand,old.cost_price,curdate());

end
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `product_audit`
--

CREATE TABLE `product_audit` (
  `pid` int(11) NOT NULL,
  `Product_id` int(11) NOT NULL,
  `audit_user` varchar(100) DEFAULT NULL,
  `action_description` varchar(100) DEFAULT NULL,
  `olddescription` varchar(100) DEFAULT NULL,
  `oldbrandname` varchar(100) DEFAULT NULL,
  `oldcategory_id` int(11) DEFAULT NULL,
  `oldstocksonhand` int(11) DEFAULT NULL,
  `oldcost` decimal(20,2) DEFAULT NULL,
  `Datetriggered` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Stand-in structure for view `product_audit_details`
-- (See below for the actual view)
--
CREATE TABLE `product_audit_details` (
`ID` int(11)
,`Product ID` int(11)
,`Audit User` varchar(100)
,`Action Done` varchar(100)
,`Old ProductName` varchar(100)
,`Old Brand` varchar(100)
,`Old CategoryID` int(11)
,`Old Stocks` int(11)
,`Old Price` decimal(20,2)
,`Datetriggered` date
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `product_details`
-- (See below for the actual view)
--
CREATE TABLE `product_details` (
`ID` int(11)
,`Product Name` varchar(100)
,`Brand` varchar(100)
,`Price` decimal(20,2)
,`Category` varchar(100)
);

-- --------------------------------------------------------

--
-- Table structure for table `rolepermissions`
--

CREATE TABLE `rolepermissions` (
  `Roles_role_id` int(11) NOT NULL,
  `Permissions_permission_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `rolepermissions`
--

INSERT INTO `rolepermissions` (`Roles_role_id`, `Permissions_permission_id`) VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(1, 5),
(1, 6),
(1, 7),
(1, 8),
(1, 9),
(1, 10),
(1, 11),
(1, 12),
(1, 13),
(1, 14),
(1, 15),
(1, 16),
(1, 17),
(1, 18),
(1, 19),
(2, 1),
(2, 6),
(2, 7),
(2, 9);

-- --------------------------------------------------------

--
-- Table structure for table `roles`
--

CREATE TABLE `roles` (
  `role_id` int(11) NOT NULL,
  `Description` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `roles`
--

INSERT INTO `roles` (`role_id`, `Description`) VALUES
(1, 'Administrator'),
(2, 'Cashier');

-- --------------------------------------------------------

--
-- Table structure for table `stocksin`
--

CREATE TABLE `stocksin` (
  `stocksin_id` int(11) NOT NULL,
  `quantity` int(11) DEFAULT NULL,
  `Priceperpiece` decimal(20,2) DEFAULT NULL,
  `DateIn` date DEFAULT NULL,
  `Products_product_id` int(11) NOT NULL,
  `suppliers_supplier_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `stocksin`
--

INSERT INTO `stocksin` (`stocksin_id`, `quantity`, `Priceperpiece`, `DateIn`, `Products_product_id`, `suppliers_supplier_id`) VALUES
(1, 20, '1350.00', '2018-09-21', 1, 1),
(2, 20, '1950.00', '2018-09-21', 2, 1),
(3, 20, '3350.00', '2018-09-21', 3, 1),
(4, 20, '8400.00', '2018-09-21', 4, 1),
(5, 20, '1600.00', '2018-09-21', 5, 1),
(6, 20, '1400.00', '2018-09-21', 6, 1),
(7, 20, '1500.00', '2018-09-21', 7, 1),
(8, 20, '5250.00', '2018-09-21', 8, 1),
(9, 20, '5250.00', '2018-09-21', 9, 1),
(10, 20, '5550.00', '2018-09-21', 10, 1),
(11, 20, '8400.00', '2018-09-21', 11, 1),
(12, 20, '9400.00', '2018-09-21', 12, 1),
(13, 20, '11350.00', '2018-09-21', 13, 1),
(14, 20, '8400.00', '2018-09-21', 14, 1),
(15, 20, '9600.00', '2018-09-21', 15, 1),
(16, 20, '10650.00', '2018-09-21', 16, 1),
(17, 20, '11600.00', '2018-09-21', 17, 1),
(18, 20, '14600.00', '2018-09-21', 18, 1),
(19, 20, '1550.00', '2018-09-21', 19, 1),
(20, 20, '1700.00', '2018-09-21', 20, 1),
(21, 20, '3200.00', '2018-09-21', 21, 1),
(22, 20, '1700.00', '2018-09-21', 22, 1),
(23, 20, '3300.00', '2018-09-21', 23, 1),
(24, 20, '400.00', '2018-09-21', 24, 1),
(25, 20, '400.00', '2018-09-21', 25, 1),
(26, 20, '900.00', '2018-09-21', 26, 1),
(27, 20, '900.00', '2018-09-21', 27, 1),
(28, 20, '780.00', '2018-09-21', 28, 1),
(29, 20, '800.00', '2018-09-21', 29, 1),
(30, 20, '780.00', '2018-09-21', 30, 1),
(31, 20, '800.00', '2018-09-21', 31, 1),
(32, 20, '780.00', '2018-09-21', 32, 1),
(33, 20, '1700.00', '2018-09-21', 33, 1),
(34, 20, '1700.00', '2018-09-21', 34, 1),
(35, 20, '1700.00', '2018-09-21', 35, 1),
(36, 20, '1600.00', '2018-09-21', 36, 1),
(37, 20, '1650.00', '2018-09-21', 37, 1),
(38, 20, '2450.00', '2018-09-21', 38, 1),
(39, 20, '2500.00', '2018-09-21', 39, 1),
(40, 20, '4100.00', '2018-09-21', 40, 1),
(41, 20, '4400.00', '2018-09-21', 41, 1),
(42, 20, '2250.00', '2018-09-21', 42, 1),
(43, 20, '1795.00', '2018-09-21', 43, 1),
(44, 20, '2150.00', '2018-09-21', 44, 1),
(45, 20, '3750.00', '2018-09-21', 45, 1),
(46, 20, '3050.00', '2018-09-21', 46, 1),
(47, 20, '3600.00', '2018-09-21', 47, 1),
(48, 20, '5900.00', '2018-09-21', 48, 1),
(49, 20, '6250.00', '2018-09-21', 49, 1),
(50, 20, '2950.00', '2018-09-21', 50, 1),
(51, 20, '4400.00', '2018-09-21', 51, 1),
(52, 20, '8250.00', '2018-09-21', 52, 1),
(53, 20, '2450.00', '2018-09-21', 53, 1),
(54, 20, '3700.00', '2018-09-21', 54, 1),
(55, 20, '2300.00', '2018-09-21', 55, 1),
(56, 20, '3795.00', '2018-09-21', 56, 1),
(57, 20, '3550.00', '2018-09-21', 57, 1),
(58, 20, '5350.00', '2018-09-21', 58, 1),
(59, 20, '4150.00', '2018-09-21', 59, 1),
(60, 20, '4600.00', '2018-09-21', 60, 1),
(61, 20, '6550.00', '2018-09-21', 61, 1),
(62, 20, '2700.00', '2018-09-21', 62, 2),
(63, 20, '3600.00', '2018-09-21', 63, 2),
(64, 20, '3550.00', '2018-09-21', 64, 2),
(65, 20, '4850.00', '2018-09-21', 65, 2),
(66, 20, '2250.00', '2018-09-21', 66, 2),
(67, 20, '1700.00', '2018-09-21', 67, 2),
(68, 20, '850.00', '2018-09-21', 68, 2),
(69, 20, '2050.00', '2018-09-21', 69, 2),
(70, 20, '3600.00', '2018-09-21', 70, 2),
(71, 20, '7950.00', '2018-09-21', 71, 2),
(72, 20, '2795.00', '2018-09-21', 72, 2),
(73, 50, '2300.00', '2018-09-21', 73, 2),
(74, 20, '4950.00', '2018-09-21', 74, 2),
(75, 20, '5000.00', '2018-09-21', 75, 2),
(76, 20, '3500.00', '2018-09-21', 76, 2),
(77, 20, '2550.00', '2018-09-21', 77, 2),
(78, 20, '4550.00', '2018-09-21', 78, 2),
(79, 20, '1900.00', '2018-09-21', 79, 2),
(80, 20, '2300.00', '2018-09-21', 80, 2),
(81, 20, '2500.00', '2018-09-21', 81, 2),
(82, 20, '1795.00', '2018-09-21', 82, 2),
(83, 20, '2200.00', '2018-09-21', 83, 2),
(84, 20, '2450.00', '2018-09-21', 84, 2),
(85, 20, '13200.00', '2018-09-21', 85, 2),
(86, 20, '2250.00', '2018-09-21', 86, 2),
(87, 20, '6400.00', '2018-09-21', 87, 2),
(88, 20, '2100.00', '2018-09-21', 88, 2),
(89, 20, '2650.00', '2018-09-21', 89, 2),
(90, 20, '6000.00', '2018-09-21', 90, 2),
(91, 20, '8850.00', '2018-09-21', 91, 2),
(92, 20, '12400.00', '2018-09-21', 92, 2),
(93, 20, '11000.00', '2018-09-21', 93, 2),
(94, 20, '11450.00', '2018-09-21', 94, 2),
(95, 20, '9795.00', '2018-09-21', 95, 2),
(96, 20, '10600.00', '2018-09-21', 96, 2),
(97, 20, '19900.00', '2018-09-21', 97, 2),
(98, 20, '17800.00', '2018-09-21', 98, 2),
(99, 20, '39000.00', '2018-09-21', 99, 2),
(100, 20, '16150.00', '2018-09-21', 100, 2),
(101, 20, '16500.00', '2018-09-21', 101, 2),
(102, 20, '6550.00', '2018-09-21', 102, 2),
(103, 20, '7800.00', '2018-09-21', 103, 2),
(104, 20, '12550.00', '2018-09-21', 104, 2),
(105, 20, '19100.00', '2018-09-21', 105, 2),
(106, 20, '2000.00', '2018-09-21', 106, 2),
(107, 20, '2300.00', '2018-09-21', 107, 2),
(108, 20, '2850.00', '2018-09-21', 108, 2),
(109, 20, '2500.00', '2018-09-21', 109, 2),
(110, 20, '2400.00', '2018-09-21', 110, 2),
(111, 20, '3850.00', '2018-09-21', 111, 2),
(112, 20, '310.00', '2018-09-21', 112, 2),
(113, 20, '630.00', '2018-09-21', 113, 2),
(114, 20, '860.00', '2018-09-21', 114, 2),
(115, 20, '860.00', '2018-09-21', 115, 2),
(116, 20, '190.00', '2018-09-21', 116, 2),
(117, 20, '430.00', '2018-09-21', 117, 2),
(118, 20, '550.00', '2018-09-21', 118, 2),
(119, 20, '750.00', '2018-09-21', 119, 2),
(120, 20, '750.00', '2018-09-21', 120, 2),
(121, 20, '650.00', '2018-09-21', 121, 2),
(122, 20, '1050.00', '2018-09-21', 122, 2),
(123, 20, '2500.00', '2018-09-21', 123, 2),
(124, 20, '2000.00', '2018-09-21', 124, 2),
(125, 20, '2450.00', '2018-09-21', 125, 2),
(126, 20, '2950.00', '2018-09-21', 126, 2),
(127, 20, '3350.00', '2018-09-21', 127, 2),
(128, 20, '1750.00', '2018-09-21', 128, 2),
(129, 50, '2250.00', '2018-09-21', 129, 2),
(130, 50, '2100.00', '2018-09-21', 130, 2),
(131, 20, '2600.00', '2018-09-21', 131, 2),
(132, 20, '1795.00', '2018-09-21', 132, 2),
(133, 20, '3450.00', '2018-09-21', 133, 2),
(134, 20, '4100.00', '2018-09-21', 134, 2),
(135, 20, '2700.00', '2018-09-21', 135, 2),
(136, 20, '1400.00', '2018-09-21', 136, 2),
(137, 20, '2250.00', '2018-09-21', 137, 2),
(138, 20, '2700.00', '2018-09-21', 138, 2),
(139, 20, '3050.00', '2018-09-21', 139, 2),
(140, 20, '2750.00', '2018-09-21', 140, 2),
(141, 20, '3000.00', '2018-09-21', 141, 2),
(142, 20, '3250.00', '2018-09-21', 142, 2),
(143, 20, '3000.00', '2018-09-21', 143, 1),
(144, 20, '2600.00', '2018-09-21', 144, 1),
(145, 20, '1850.00', '2018-09-21', 145, 1),
(146, 20, '2500.00', '2018-09-21', 146, 1),
(147, 20, '3250.00', '2018-09-21', 147, 1),
(148, 20, '1900.00', '2018-09-21', 148, 1),
(149, 20, '1900.00', '2018-09-21', 149, 1),
(150, 20, '1900.00', '2018-09-21', 150, 1),
(151, 20, '1850.00', '2018-09-21', 151, 1),
(152, 20, '1850.00', '2018-09-21', 152, 1),
(153, 20, '1150.00', '2018-09-21', 153, 1),
(154, 20, '7600.00', '2018-09-21', 154, 1),
(155, 20, '1800.00', '2018-09-21', 155, 1),
(156, 20, '2150.00', '2018-09-21', 156, 1),
(157, 20, '2550.00', '2018-09-21', 157, 1),
(158, 20, '7100.00', '2018-09-21', 158, 1),
(159, 20, '360.00', '2018-09-21', 159, 1),
(160, 20, '360.00', '2018-09-21', 160, 1),
(161, 20, '360.00', '2018-09-21', 161, 1),
(162, 20, '210.00', '2018-09-21', 162, 1),
(163, 20, '2250.00', '2018-09-21', 163, 1),
(164, 20, '550.00', '2018-09-21', 164, 1),
(165, 20, '750.00', '2018-09-21', 165, 1),
(166, 20, '1050.00', '2018-09-21', 166, 1),
(167, 20, '115.00', '2018-09-21', 167, 1),
(168, 20, '145.00', '2018-09-21', 168, 1),
(169, 20, '135.00', '2018-09-21', 169, 1),
(170, 20, '170.00', '2018-09-21', 170, 1),
(171, 20, '170.00', '2018-09-21', 171, 1),
(172, 20, '830.00', '2018-09-21', 172, 1),
(173, 20, '650.00', '2018-09-21', 173, 1),
(174, 20, '320.00', '2018-09-21', 174, 1),
(175, 20, '870.00', '2018-09-21', 175, 1),
(176, 20, '2000.00', '2018-09-21', 176, 1),
(177, 20, '850.00', '2018-09-21', 177, 1),
(178, 20, '1450.00', '2018-09-21', 178, 1),
(179, 20, '1450.00', '2018-09-21', 179, 1);

--
-- Triggers `stocksin`
--
DELIMITER $$
CREATE TRIGGER `updatestocksafterinsertstocksin` AFTER INSERT ON `stocksin` FOR EACH ROW begin

declare oldquantity,newquantity,pid int default 0;

set @pid=new.Products_product_id ;
set @newquantity=new.quantity ;
set @oldquantity=(Select stocksonhand from products where product_id=@pid) ;

Update products set stocksonhand =(@newquantity+@oldquantity) where product_id=@pid;


end
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Stand-in structure for view `stocksinview`
-- (See below for the actual view)
--
CREATE TABLE `stocksinview` (
`product_id` int(11)
,`ProductName` varchar(100)
,`brandname` varchar(100)
,`category` varchar(100)
,`supplier_id` int(11)
,`SupplierName` varchar(100)
,`stocksin_id` int(11)
,`quantity` int(11)
,`Priceperpiece` decimal(20,2)
,`DateIn` date
);

-- --------------------------------------------------------

--
-- Table structure for table `suppliers`
--

CREATE TABLE `suppliers` (
  `supplier_id` int(11) NOT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `Address` varchar(100) DEFAULT NULL,
  `Phoneno` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `suppliers`
--

INSERT INTO `suppliers` (`supplier_id`, `Description`, `Address`, `Phoneno`) VALUES
(1, 'PC Hardware Parts', 'Philippines', '09487287995'),
(2, 'PC Software Parts', 'Makati City,Philippines', '09123456789');

-- --------------------------------------------------------

--
-- Stand-in structure for view `supplier_details`
-- (See below for the actual view)
--
CREATE TABLE `supplier_details` (
`ID` int(11)
,`Supplier Name` varchar(100)
,`Address` varchar(100)
,`Phone Number` varchar(100)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `systemuser_details`
-- (See below for the actual view)
--
CREATE TABLE `systemuser_details` (
`ID` int(11)
,`User Last Name` varchar(100)
,`User First Name` varchar(100)
,`UserName` varchar(100)
,`Password` varchar(100)
,`Role` varchar(100)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `transactions`
-- (See below for the actual view)
--
CREATE TABLE `transactions` (
`CustomerLname` varchar(100)
,`CustomerFname` varchar(100)
,`address` varchar(100)
,`phonenumber` varchar(100)
,`CashierLname` varchar(100)
,`CashierFname` varchar(100)
,`order_id` int(11)
,`product_id` int(11)
,`Description` varchar(100)
,`quantity_` int(11)
,`cost_price` decimal(20,2)
,`orderdate` date
);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `lname` varchar(100) DEFAULT NULL,
  `fname` varchar(100) DEFAULT NULL,
  `username` varchar(100) DEFAULT NULL,
  `password` varchar(100) DEFAULT NULL,
  `Roles_role_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `lname`, `fname`, `username`, `password`, `Roles_role_id`) VALUES
(1, 'Raquem', 'Alvin', 'alvin', 'alvin', 1),
(2, 'test', 'test', 'test', 'test', 2);

-- --------------------------------------------------------

--
-- Structure for view `customer_details`
--
DROP TABLE IF EXISTS `customer_details`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `customer_details`  AS  select `c`.`customer_id` AS `ID`,`c`.`lname` AS `LastName`,`c`.`fname` AS `FirstName`,`c`.`address` AS `address`,`c`.`phonenumber` AS `Phone Number` from `customers` `c` ;

-- --------------------------------------------------------

--
-- Structure for view `product_audit_details`
--
DROP TABLE IF EXISTS `product_audit_details`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `product_audit_details`  AS  select `pa`.`pid` AS `ID`,`pa`.`Product_id` AS `Product ID`,`pa`.`audit_user` AS `Audit User`,`pa`.`action_description` AS `Action Done`,`pa`.`olddescription` AS `Old ProductName`,`pa`.`oldbrandname` AS `Old Brand`,`pa`.`oldcategory_id` AS `Old CategoryID`,`pa`.`oldstocksonhand` AS `Old Stocks`,`pa`.`oldcost` AS `Old Price`,`pa`.`Datetriggered` AS `Datetriggered` from `product_audit` `pa` ;

-- --------------------------------------------------------

--
-- Structure for view `product_details`
--
DROP TABLE IF EXISTS `product_details`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `product_details`  AS  select `p`.`product_id` AS `ID`,`p`.`Description` AS `Product Name`,`p`.`brandname` AS `Brand`,`p`.`cost_price` AS `Price`,`c`.`category` AS `Category` from (`products` `p` left join `category` `c` on((`p`.`category_category_id` = `c`.`category_id`))) ;

-- --------------------------------------------------------

--
-- Structure for view `stocksinview`
--
DROP TABLE IF EXISTS `stocksinview`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `stocksinview`  AS  select `p`.`product_id` AS `product_id`,`p`.`Description` AS `ProductName`,`p`.`brandname` AS `brandname`,`c`.`category` AS `category`,`s`.`supplier_id` AS `supplier_id`,`s`.`Description` AS `SupplierName`,`st`.`stocksin_id` AS `stocksin_id`,`st`.`quantity` AS `quantity`,`st`.`Priceperpiece` AS `Priceperpiece`,`st`.`DateIn` AS `DateIn` from (((`products` `p` join `category` `c` on((`p`.`category_category_id` = `c`.`category_id`))) join `stocksin` `st` on((`st`.`Products_product_id` = `p`.`product_id`))) join `suppliers` `s` on((`s`.`supplier_id` = `st`.`suppliers_supplier_id`))) ;

-- --------------------------------------------------------

--
-- Structure for view `supplier_details`
--
DROP TABLE IF EXISTS `supplier_details`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `supplier_details`  AS  select `s`.`supplier_id` AS `ID`,`s`.`Description` AS `Supplier Name`,`s`.`Address` AS `Address`,`s`.`Phoneno` AS `Phone Number` from `suppliers` `s` ;

-- --------------------------------------------------------

--
-- Structure for view `systemuser_details`
--
DROP TABLE IF EXISTS `systemuser_details`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `systemuser_details`  AS  select `u`.`user_id` AS `ID`,`u`.`lname` AS `User Last Name`,`u`.`fname` AS `User First Name`,`u`.`username` AS `UserName`,`u`.`password` AS `Password`,`r`.`Description` AS `Role` from (`users` `u` join `roles` `r` on((`u`.`Roles_role_id` = `r`.`role_id`))) ;

-- --------------------------------------------------------

--
-- Structure for view `transactions`
--
DROP TABLE IF EXISTS `transactions`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `transactions`  AS  select `c`.`lname` AS `CustomerLname`,`c`.`fname` AS `CustomerFname`,`c`.`address` AS `address`,`c`.`phonenumber` AS `phonenumber`,`u`.`lname` AS `CashierLname`,`u`.`fname` AS `CashierFname`,`o`.`order_id` AS `order_id`,`p`.`product_id` AS `product_id`,`p`.`Description` AS `Description`,`oi`.`quantity_` AS `quantity_`,`oi`.`cost_price` AS `cost_price`,`o`.`orderdate` AS `orderdate` from ((((`customers` `c` join `orderline` `o` on((`c`.`customer_id` = `o`.`Customers_customer_id`))) join `users` `u` on((`u`.`user_id` = `o`.`Users_user_id`))) join `orderinfo` `oi` on((`oi`.`Orderline_order_id` = `o`.`order_id`))) join `products` `p` on((`p`.`product_id` = `oi`.`Products_product_id`))) ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`category_id`);

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`customer_id`);

--
-- Indexes for table `orderinfo`
--
ALTER TABLE `orderinfo`
  ADD KEY `fk_Orderinfo_Orderline1_idx` (`Orderline_order_id`),
  ADD KEY `fk_Orderinfo_Products1_idx` (`Products_product_id`);

--
-- Indexes for table `orderline`
--
ALTER TABLE `orderline`
  ADD PRIMARY KEY (`order_id`),
  ADD KEY `fk_Orderline_Customers1_idx` (`Customers_customer_id`),
  ADD KEY `fk_Orderline_Users1_idx` (`Users_user_id`);

--
-- Indexes for table `permissions`
--
ALTER TABLE `permissions`
  ADD PRIMARY KEY (`permission_id`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`product_id`),
  ADD KEY `fk_Products_category1_idx` (`category_category_id`);

--
-- Indexes for table `product_audit`
--
ALTER TABLE `product_audit`
  ADD PRIMARY KEY (`pid`);

--
-- Indexes for table `rolepermissions`
--
ALTER TABLE `rolepermissions`
  ADD PRIMARY KEY (`Roles_role_id`,`Permissions_permission_id`),
  ADD KEY `fk_RolePermissions_Permissions1_idx` (`Permissions_permission_id`);

--
-- Indexes for table `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`role_id`);

--
-- Indexes for table `stocksin`
--
ALTER TABLE `stocksin`
  ADD PRIMARY KEY (`stocksin_id`),
  ADD KEY `fk_stocksin_Products1_idx` (`Products_product_id`),
  ADD KEY `fk_stocksin_suppliers1_idx` (`suppliers_supplier_id`);

--
-- Indexes for table `suppliers`
--
ALTER TABLE `suppliers`
  ADD PRIMARY KEY (`supplier_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD KEY `fk_Users_Roles1_idx` (`Roles_role_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `category_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT for table `customers`
--
ALTER TABLE `customers`
  MODIFY `customer_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `orderline`
--
ALTER TABLE `orderline`
  MODIFY `order_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `permissions`
--
ALTER TABLE `permissions`
  MODIFY `permission_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `product_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=180;

--
-- AUTO_INCREMENT for table `product_audit`
--
ALTER TABLE `product_audit`
  MODIFY `pid` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `roles`
--
ALTER TABLE `roles`
  MODIFY `role_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `stocksin`
--
ALTER TABLE `stocksin`
  MODIFY `stocksin_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=180;

--
-- AUTO_INCREMENT for table `suppliers`
--
ALTER TABLE `suppliers`
  MODIFY `supplier_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `orderinfo`
--
ALTER TABLE `orderinfo`
  ADD CONSTRAINT `fk_Orderinfo_Orderline1` FOREIGN KEY (`Orderline_order_id`) REFERENCES `orderline` (`order_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_Orderinfo_Products1` FOREIGN KEY (`Products_product_id`) REFERENCES `products` (`product_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `orderline`
--
ALTER TABLE `orderline`
  ADD CONSTRAINT `fk_Orderline_Customers1` FOREIGN KEY (`Customers_customer_id`) REFERENCES `customers` (`customer_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_Orderline_Users1` FOREIGN KEY (`Users_user_id`) REFERENCES `users` (`user_id`) ON DELETE SET NULL ON UPDATE SET NULL;

--
-- Constraints for table `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `fk_Products_category1` FOREIGN KEY (`category_category_id`) REFERENCES `category` (`category_id`) ON DELETE SET NULL ON UPDATE SET NULL;

--
-- Constraints for table `rolepermissions`
--
ALTER TABLE `rolepermissions`
  ADD CONSTRAINT `fk_RolePermissions_Permissions1` FOREIGN KEY (`Permissions_permission_id`) REFERENCES `permissions` (`permission_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_RolePermissions_Roles` FOREIGN KEY (`Roles_role_id`) REFERENCES `roles` (`role_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `stocksin`
--
ALTER TABLE `stocksin`
  ADD CONSTRAINT `fk_stocksin_Products1` FOREIGN KEY (`Products_product_id`) REFERENCES `products` (`product_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_stocksin_suppliers1` FOREIGN KEY (`suppliers_supplier_id`) REFERENCES `suppliers` (`supplier_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `fk_Users_Roles1` FOREIGN KEY (`Roles_role_id`) REFERENCES `roles` (`role_id`) ON DELETE CASCADE ON UPDATE CASCADE;

DELIMITER $$
--
-- Events
--
CREATE DEFINER=`root`@`localhost` EVENT `daily_reports` ON SCHEDULE EVERY '1 1' DAY_HOUR STARTS '2016-08-17 00:00:00' ON COMPLETION NOT PRESERVE ENABLE DO BEGIN
call order_daily_report();


END$$

CREATE DEFINER=`root`@`localhost` EVENT `Monthly_reports` ON SCHEDULE EVERY 1 MONTH STARTS '2016-09-01 00:00:00' ON COMPLETION NOT PRESERVE ENABLE DO BEGIN


call order_report();


END$$

DELIMITER ;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
