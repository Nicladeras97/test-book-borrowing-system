-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 27, 2025 at 10:20 AM
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
  `BookID` varchar(15) NOT NULL,
  `ISBN` varchar(50) DEFAULT NULL,
  `Title` varchar(255) NOT NULL,
  `Author` varchar(255) NOT NULL,
  `Year` int(11) DEFAULT NULL,
  `Section` varchar(100) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  `Image` varchar(255) DEFAULT NULL,
  `Copies` int(11) DEFAULT NULL,
  `AddedDate` date DEFAULT NULL,
  `CallNumber` varchar(100) DEFAULT NULL,
  `Rack` varchar(50) NOT NULL DEFAULT '',
  `Publisher` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `book`
--

INSERT INTO `book` (`BookID`, `ISBN`, `Title`, `Author`, `Year`, `Section`, `Status`, `Image`, `Copies`, `AddedDate`, `CallNumber`, `Rack`, `Publisher`) VALUES
('CIR20000001', '978-0439827607', 'Harry Potter Collection (Harry Potter  #1-6)', 'J.K. Rowling', 2000, 'Circulation', 'Borrowed', NULL, 1, '2025-03-27', 'PZ7.R79835 Har 2000z', 'A', 'Scholastic'),
('FIC19990002', '978-0439655484', 'Harry Potter and the Prisoner of Azkaban (Harry Potter  #3)', 'J.K. Rowling/Mary GrandPré', 1999, 'Fiction', 'Borrowed', NULL, 1, '2025-03-27', 'PZ7.R79835 Har 1999', 'P', 'Scholastic Inc.'),
('FIC20000001', '978-0439682589', 'Harry Potter Boxed Set  Books 1-5 (Harry Potter  #1-5)', 'J.K. Rowling/Mary GrandPré', 2000, 'Fiction', 'Available', NULL, 1, '2025-03-27', 'PZ7.R79835 Har 2000z', 'P', 'Scholastic'),
('FIC20030001', '978-0439358071', 'Harry Potter and the Order of the Phoenix (Harry Potter  #5)', 'J.K. Rowling/Mary GrandPré', 2003, 'Fiction', 'Borrowed', NULL, 1, '2025-03-27', 'PZ7.R79835 Har 2003', 'P', 'Scholastic Inc.'),
('REF20030001', '978-0767908184', 'A Short History of Nearly Everything', 'Bill Bryson', 2003, 'Reference', 'Available', NULL, 2, '2025-03-27', 'Q162 .B88 2003', 'Q', 'Broadway Books'),
('REF20050001', '978-0976540601', 'Unauthorized Harry Potter Book Seven News: \"Half-Blood Prince\" Analysis and Speculation', 'W. Frederick Zimmerman', 2005, 'Reference', 'Available', NULL, 1, '2025-03-27', 'PN56.H55 Z56 2005', 'A', 'Nimble Books');

-- --------------------------------------------------------

--
-- Table structure for table `borrow`
--

CREATE TABLE `borrow` (
  `BorrowID` int(11) NOT NULL,
  `StudNo` varchar(50) DEFAULT NULL,
  `BookID` varchar(10) DEFAULT NULL,
  `CopyID` int(11) NOT NULL,
  `BorrowDate` date DEFAULT NULL,
  `DueDate` date DEFAULT NULL,
  `StatusName` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `borrow`
--

INSERT INTO `borrow` (`BorrowID`, `StudNo`, `BookID`, `CopyID`, `BorrowDate`, `DueDate`, `StatusName`) VALUES
(1, '211083', 'CIR1996000', 0, '2025-03-27', '2025-03-27', 'Borrowed'),
(2, '211083', 'FIC1999000', 0, '2025-03-27', '2025-03-27', 'Borrowed'),
(3, '211083', 'CIR2000000', 0, '2025-03-27', '2025-03-27', 'Borrowed'),
(4, '211083', 'FIC1999000', 0, '2025-03-27', '2025-03-27', 'Borrowed'),
(5, '211083', 'FIC2003000', 0, '2025-03-27', '2025-03-27', 'Borrowed');

-- --------------------------------------------------------

--
-- Table structure for table `copies`
--

CREATE TABLE `copies` (
  `CopyID` varchar(15) NOT NULL,
  `ISBN` varchar(50) DEFAULT NULL,
  `Status` enum('Available','Borrowed','Damaged','Lost') DEFAULT 'Available',
  `BookID` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `copies`
--

INSERT INTO `copies` (`CopyID`, `ISBN`, `Status`, `BookID`) VALUES
('CIR20000001-01', '978-0439827607', 'Available', 'CIR20000001'),
('FIC19990002-01', '978-0439655484', 'Available', 'FIC19990002'),
('FIC20000001-01', '978-0439682589', 'Available', 'FIC20000001'),
('FIC20030001-01', '978-0439358071', 'Available', 'FIC20030001'),
('REF20030001-01', '978-0767908184', 'Available', 'REF20030001'),
('REF20030001-02', '978-0767908184', 'Available', 'REF20030001'),
('REF20050001-01', '978-0976540601', 'Available', 'REF20050001');

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
  `BorrowID` int(11) DEFAULT NULL,
  `StudNo` varchar(50) DEFAULT NULL,
  `ReturnDate` date DEFAULT NULL,
  `DamageDescription` text DEFAULT NULL,
  `FineAmount` decimal(10,2) DEFAULT 0.00
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `return_good`
--

CREATE TABLE `return_good` (
  `ReturnID` int(11) NOT NULL,
  `BorrowID` int(11) DEFAULT NULL,
  `CopyID` varchar(10) DEFAULT NULL,
  `StudNo` varchar(15) NOT NULL,
  `ReturnDate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `return_lost`
--

CREATE TABLE `return_lost` (
  `ReturnLostID` int(11) NOT NULL,
  `BorrowID` int(11) DEFAULT NULL,
  `ISBN` varchar(20) DEFAULT NULL,
  `StudNo` varchar(50) DEFAULT NULL,
  `ReportDate` date DEFAULT NULL,
  `GracePeriod` date DEFAULT NULL,
  `FineAmount` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `UserID` int(11) NOT NULL,
  `StudNo` varchar(50) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `ContactNum` varchar(15) DEFAULT NULL,
  `Email` varchar(100) NOT NULL,
  `YearSection` varchar(50) NOT NULL,
  `Course` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserID`, `StudNo`, `Name`, `ContactNum`, `Email`, `YearSection`, `Course`) VALUES
(1, '211083', 'Monica', '09368417320', 'nicladeras97@gmail.com', '4A', 'BSCS');

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
  ADD PRIMARY KEY (`BorrowID`),
  ADD KEY `StudNo` (`StudNo`),
  ADD KEY `BookID` (`BookID`),
  ADD KEY `CopyID` (`CopyID`);

--
-- Indexes for table `copies`
--
ALTER TABLE `copies`
  ADD PRIMARY KEY (`CopyID`),
  ADD KEY `ISBN` (`ISBN`),
  ADD KEY `BookID` (`BookID`);

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
  ADD KEY `StudNo` (`StudNo`);

--
-- Indexes for table `return_good`
--
ALTER TABLE `return_good`
  ADD PRIMARY KEY (`ReturnID`),
  ADD KEY `BorrowID` (`BorrowID`),
  ADD KEY `StudNo` (`StudNo`);

--
-- Indexes for table `return_lost`
--
ALTER TABLE `return_lost`
  ADD PRIMARY KEY (`ReturnLostID`),
  ADD KEY `BorrowID` (`BorrowID`),
  ADD KEY `StudNo` (`StudNo`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserID`),
  ADD KEY `StudNo` (`StudNo`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `borrow`
--
ALTER TABLE `borrow`
  MODIFY `BorrowID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `login`
--
ALTER TABLE `login`
  MODIFY `LibraryID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `return_damaged`
--
ALTER TABLE `return_damaged`
  MODIFY `ReturnDamagedID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `return_good`
--
ALTER TABLE `return_good`
  MODIFY `ReturnID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `return_lost`
--
ALTER TABLE `return_lost`
  MODIFY `ReturnLostID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
