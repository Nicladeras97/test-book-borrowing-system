-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 24, 2025 at 06:42 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `book-borrowing`
--

-- --------------------------------------------------------

--
-- Table structure for table `book`
--

CREATE TABLE `book` (
  `BookID` varchar(50) NOT NULL,
  `Title` varchar(255) DEFAULT NULL,
  `Author` varchar(255) DEFAULT NULL,
  `Year` int(11) DEFAULT NULL,
  `ISBN` varchar(50) DEFAULT NULL,
  `Category` varchar(100) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  `Image` varchar(255) DEFAULT NULL,
  `Copies` int(11) DEFAULT NULL,
  `AddedDate` date DEFAULT NULL,
  `CallNumber` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `book`
--

INSERT INTO `book` (`BookID`, `Title`, `Author`, `Year`, `ISBN`, `Category`, `Status`, `Image`, `Copies`, `AddedDate`, `CallNumber`) VALUES
('B123456', 'Sample Book Title', 'John Doe', 2023, '1234567890', 'Fiction', 'Available', 'img/books/default.jpg', 1, '2025-03-24', 'N/A'),
('BK001', 'The Guns of the South', 'Harry Turtle dove', 1992, '0-345-38468-7', 'Non-Fiction', 'Pending', NULL, 0, NULL, NULL),
('BK003', 'River of Blue', 'Tad William', 1998, '978-0-886777-77-7', 'Non-Fiction', 'Lost', NULL, 0, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `borrow`
--

CREATE TABLE `borrow` (
  `BorrowID` varchar(50) NOT NULL,
  `StudNo` varchar(50) DEFAULT NULL,
  `BookID` varchar(50) DEFAULT NULL,
  `BorrowDate` date DEFAULT NULL,
  `DueDate` date DEFAULT NULL,
  `StatusName` varchar(50) DEFAULT NULL,
  `Title` varchar(255) DEFAULT NULL,
  `Author` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `borrow`
--

INSERT INTO `borrow` (`BorrowID`, `StudNo`, `BookID`, `BorrowDate`, `DueDate`, `StatusName`, `Title`, `Author`) VALUES
('0a497ec722', '211083', 'B123456', '2025-03-24', '2025-03-24', 'Returned', 'Sample Book Title', 'John Doe'),
('7ce071720d', '211083', 'BK003', '2025-03-24', NULL, 'Returned (Lost)', 'River of Blue', 'Tad William'),
('d38f8c15a3', '211083', 'BK001', '2025-03-24', '2025-03-24', 'Returned (Damaged)', 'The Guns of the South', 'Harry Turtle dove');

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `Category` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`Category`) VALUES
('Fiction'),
('History'),
('Journal'),
('Non-Fiction'),
('Textbook'),
('Theses');

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `LibraryID` int(11) NOT NULL,
  `Username` varchar(100) NOT NULL,
  `Password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`LibraryID`, `Username`, `Password`) VALUES
(1, 'user', 'user');

-- --------------------------------------------------------

--
-- Table structure for table `return_damaged`
--

CREATE TABLE `return_damaged` (
  `ReturnDamagedID` int(11) NOT NULL,
  `BorrowID` varchar(50) DEFAULT NULL,
  `BookID` varchar(50) DEFAULT NULL,
  `StudNo` varchar(50) DEFAULT NULL,
  `ReturnDate` date DEFAULT NULL,
  `DamageDescription` text DEFAULT NULL,
  `FineAmount` decimal(10,2) DEFAULT 0.00
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `return_damaged`
--

INSERT INTO `return_damaged` (`ReturnDamagedID`, `BorrowID`, `BookID`, `StudNo`, `ReturnDate`, `DamageDescription`, `FineAmount`) VALUES
(14, 'd38f8c15a3', 'BK001', '211083', '2025-03-24', 'Torn Pages', 900.00);

-- --------------------------------------------------------

--
-- Table structure for table `return_good`
--

CREATE TABLE `return_good` (
  `ReturnGoodID` int(11) NOT NULL,
  `BorrowID` varchar(20) NOT NULL,
  `StudNo` varchar(20) NOT NULL,
  `BookID` varchar(20) NOT NULL,
  `ReturnDate` date NOT NULL,
  `Remarks` varchar(255) DEFAULT NULL,
  `Status` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `return_good`
--

INSERT INTO `return_good` (`ReturnGoodID`, `BorrowID`, `StudNo`, `BookID`, `ReturnDate`, `Remarks`, `Status`) VALUES
(5, '0a497ec722', '211083', 'B123456', '2025-03-24', NULL, '');

-- --------------------------------------------------------

--
-- Table structure for table `return_lost`
--

CREATE TABLE `return_lost` (
  `ReturnLostID` int(11) NOT NULL,
  `BorrowID` varchar(50) DEFAULT NULL,
  `BookID` varchar(50) DEFAULT NULL,
  `StudNo` varchar(50) DEFAULT NULL,
  `ReportDate` date DEFAULT NULL,
  `GracePeriod` date DEFAULT NULL,
  `FineAmount` decimal(10,2) DEFAULT NULL,
  `ReturnDate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `return_lost`
--

INSERT INTO `return_lost` (`ReturnLostID`, `BorrowID`, `BookID`, `StudNo`, `ReportDate`, `GracePeriod`, `FineAmount`, `ReturnDate`) VALUES
(4, '7ce071720d', 'BK003', '211083', '2025-03-24', '2025-03-31', 2000.00, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `UserID` int(11) NOT NULL,
  `StudNo` varchar(50) NOT NULL,
  `FullName` varchar(255) NOT NULL,
  `ContactNumber` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserID`, `StudNo`, `FullName`, `ContactNumber`) VALUES
(1, '211083', 'Monica', '09368417320'),
(2, '211241', 'Cano', '09368417320'),
(3, '211394', 'Rhea', '09123456789'),
(4, '211154', 'April', '09124356786'),
(5, '201107', 'Kimberly', '09123456789'),
(6, '211321', 'Dale', '09123456789');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `book`
--
ALTER TABLE `book`
  ADD PRIMARY KEY (`BookID`);

--
-- Indexes for table `borrow`
--
ALTER TABLE `borrow`
  ADD PRIMARY KEY (`BorrowID`);

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`Category`);

--
-- Indexes for table `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`LibraryID`),
  ADD UNIQUE KEY `Username` (`Username`);

--
-- Indexes for table `return_damaged`
--
ALTER TABLE `return_damaged`
  ADD PRIMARY KEY (`ReturnDamagedID`),
  ADD KEY `BorrowID` (`BorrowID`),
  ADD KEY `BookID` (`BookID`),
  ADD KEY `StudNo` (`StudNo`);

--
-- Indexes for table `return_good`
--
ALTER TABLE `return_good`
  ADD PRIMARY KEY (`ReturnGoodID`),
  ADD KEY `fk_return_good_borrow` (`BorrowID`),
  ADD KEY `fk_return_good_book` (`BookID`);

--
-- Indexes for table `return_lost`
--
ALTER TABLE `return_lost`
  ADD PRIMARY KEY (`ReturnLostID`),
  ADD KEY `BorrowID` (`BorrowID`),
  ADD KEY `BookID` (`BookID`),
  ADD KEY `StudNo` (`StudNo`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserID`),
  ADD UNIQUE KEY `StudNo` (`StudNo`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `login`
--
ALTER TABLE `login`
  MODIFY `LibraryID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `return_damaged`
--
ALTER TABLE `return_damaged`
  MODIFY `ReturnDamagedID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `return_good`
--
ALTER TABLE `return_good`
  MODIFY `ReturnGoodID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `return_lost`
--
ALTER TABLE `return_lost`
  MODIFY `ReturnLostID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `return_damaged`
--
ALTER TABLE `return_damaged`
  ADD CONSTRAINT `return_damaged_ibfk_1` FOREIGN KEY (`BorrowID`) REFERENCES `borrow` (`BorrowID`) ON DELETE CASCADE,
  ADD CONSTRAINT `return_damaged_ibfk_2` FOREIGN KEY (`BookID`) REFERENCES `book` (`BookID`) ON DELETE CASCADE,
  ADD CONSTRAINT `return_damaged_ibfk_3` FOREIGN KEY (`StudNo`) REFERENCES `users` (`StudNo`) ON DELETE CASCADE;

--
-- Constraints for table `return_good`
--
ALTER TABLE `return_good`
  ADD CONSTRAINT `fk_return_good_book` FOREIGN KEY (`BookID`) REFERENCES `book` (`BookID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_return_good_borrow` FOREIGN KEY (`BorrowID`) REFERENCES `borrow` (`BorrowID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `return_lost`
--
ALTER TABLE `return_lost`
  ADD CONSTRAINT `return_lost_ibfk_1` FOREIGN KEY (`BorrowID`) REFERENCES `borrow` (`BorrowID`) ON DELETE CASCADE,
  ADD CONSTRAINT `return_lost_ibfk_2` FOREIGN KEY (`BookID`) REFERENCES `book` (`BookID`) ON DELETE CASCADE,
  ADD CONSTRAINT `return_lost_ibfk_3` FOREIGN KEY (`StudNo`) REFERENCES `users` (`StudNo`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
