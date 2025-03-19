-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 19, 2025 at 10:08 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.0.30

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
  `BookID` int(11) NOT NULL,
  `Title` varchar(255) NOT NULL,
  `Author` varchar(255) NOT NULL,
  `Year` varchar(4) DEFAULT NULL,
  `ISBN` varchar(20) DEFAULT NULL,
  `Category` varchar(100) NOT NULL,
  `Status` varchar(50) NOT NULL DEFAULT 'Available',
  `Image` varchar(255) DEFAULT NULL,
  `Copies` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `book`
--

INSERT INTO `book` (`BookID`, `Title`, `Author`, `Year`, `ISBN`, `Category`, `Status`, `Image`, `Copies`) VALUES
(1, 'The Hunger Games', 'Suzanne Collins', '2018', '978-0-439-02352-8', 'Fiction', 'Available', 'C:\\Users\\PC\\source\\repos\\Nicladeras97\\book-borrowing-system-mysql\\book-borrowing-system\\img\\books\\book1.jpg', 4),
(2, 'You Didn\'t Hear This From Me: (Mostly) True Notes on Gossip', 'Kelsey McKinney', '2024', '9780241741191', 'Non-Fiction', 'Available', 'C:\\Users\\PC\\source\\repos\\Nicladeras97\\book-borrowing-system-mysql\\book-borrowing-system\\img\\books\\book2.jpg', 3),
(3, 'Introduction to Earth Science - Second Edition', 'Introduction to Earth Science - Second Edition', '2025', '1962841227', 'Textbook', 'Available', 'C:\\Users\\PC\\source\\repos\\Nicladeras97\\book-borrowing-system-mysql\\book-borrowing-system\\img\\books\\book4.png', 3),
(4, 'RBM: A Journal of Rare Books, Manuscripts, and Cultural Heritage', 'Diane Dias De Fazio', '2024', '1529-6407', 'Journal', 'Available', 'C:\\Users\\PC\\source\\repos\\Nicladeras97\\book-borrowing-system-mysql\\book-borrowing-system\\img\\books\\book3.jpg', 1),
(5, 'The Wright Brothers', 'David McCullough', '2015', '978-1476728759', 'History', 'Available', 'C:\\Users\\PC\\source\\repos\\Nicladeras97\\book-borrowing-system-mysql\\book-borrowing-system\\img\\books\\book5.jpg', 1),
(6, 'The Midnight Library', 'Matt Haig', '2020', '978-0525559474', 'Fiction', 'Available', 'C:\\Users\\PC\\source\\repos\\Nicladeras97\\book-borrowing-system-mysql\\book-borrowing-system\\img\\books\\book6.jpg', 1),
(7, 'The Anthropocene Reviewed', 'John Green', '2021', '978-0525555216', 'Non-Fiction', 'Available', 'C:\\Users\\PC\\source\\repos\\Nicladeras97\\book-borrowing-system-mysql\\book-borrowing-system\\img\\books\\book7.jpg', 0),
(8, 'Caste: The Origins of Our Discontents', 'Isabel Wilkerson', '2020', '978-0593230251', 'History', 'Available', 'C:\\Users\\PC\\source\\repos\\Nicladeras97\\book-borrowing-system-mysql\\book-borrowing-system\\img\\books\\book8.jpg', 1),
(9, 'Campbell Biology (12th Edition)', 'Lisa A. Urry et al.', '2020', '978-0135188743', 'Textbook', 'Available', 'C:\\Users\\PC\\source\\repos\\Nicladeras97\\book-borrowing-system-mysql\\book-borrowing-system\\img\\books\\book6.jpg', 1),
(10, 'Journal of Artificial Intelligence Research', 'Multiple Authors', '2020', 'N/A', 'Journal', 'Available', 'C:\\Users\\PC\\source\\repos\\Nicladeras97\\book-borrowing-system-mysql\\book-borrowing-system\\img\\books\\book6.jpg', 1);

-- --------------------------------------------------------

--
-- Table structure for table `borrow`
--

CREATE TABLE `borrow` (
  `BorrowID` int(11) NOT NULL,
  `StudNo` varchar(50) DEFAULT NULL,
  `BookID` int(11) DEFAULT NULL,
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
(1, '211083', 1, '2025-03-18', '2025-03-19', 'Available', 'The Hunger Games', 'Suzanne Collins'),
(2, '211098', 1, '2025-03-18', '2025-03-20', 'Available', 'The Hunger Games', 'Suzanne Collins'),
(3, '211083', 1, '2025-03-18', '2025-03-19', 'Available', 'The Hunger Games', 'Suzanne Collins'),
(4, '201107', 1, '2025-03-18', '2025-03-20', 'Available', 'The Hunger Games', 'Suzanne Collins'),
(5, '213423', 6, '2025-03-19', '2025-03-21', 'Available', 'The Midnight Library', 'Matt Haig'),
(6, '211241', 7, '2025-03-19', '2025-03-20', 'Borrowed', 'The Anthropocene Reviewed', 'John Green'),
(7, '211083', 3, '2025-03-19', '2025-03-22', 'Borrowed', 'Introduction to Earth Science - Second Edition', 'Introduction to Earth Science - Second Edition'),
(8, '211083', 2, '2025-03-19', '2025-03-19', 'Available', 'You Didn\'t Hear This From Me: (Mostly) True Notes on Gossip', 'Kelsey McKinney'),
(9, '211241', 3, '2025-03-19', '2025-03-20', 'Borrowed', 'Introduction to Earth Science - Second Edition', 'Introduction to Earth Science - Second Edition');

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
('Textbook');

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
-- Table structure for table `returned`
--

CREATE TABLE `returned` (
  `ReturnID` int(11) NOT NULL,
  `BorrowID` int(11) NOT NULL,
  `BookID` int(11) NOT NULL,
  `StudentName` varchar(100) NOT NULL,
  `StudNo` varchar(50) NOT NULL,
  `ReturnDate` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `returned`
--

INSERT INTO `returned` (`ReturnID`, `BorrowID`, `BookID`, `StudentName`, `StudNo`, `ReturnDate`) VALUES
(1, 1, 1, 'Monica Cano', '211083', '2025-03-18 13:35:38'),
(2, 2, 1, 'Sky', '211098', '2025-03-18 13:49:01'),
(3, 3, 2, 'Monica Cano', '211083', '2025-03-18 13:51:06'),
(4, 3, 1, 'Monica Cano', '211083', '2025-03-19 14:19:34'),
(5, 8, 2, 'Monica Cano', '211083', '2025-03-19 14:45:47'),
(6, 5, 6, 'John Dave', '213423', '2025-03-19 14:50:12'),
(7, 4, 1, 'Kimberly Jeresano', '201107', '2025-03-19 16:44:56');

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
(1, '211083', 'Monica Cano', '09123456789'),
(2, '211241', 'Monic', '09123456789'),
(3, '211098', 'Sky', '09123456789'),
(4, '201107', 'Kimberly Jeresano', '09123456789'),
(5, '213423', 'John Dave', '09123456789');

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
  ADD KEY `StatusName` (`StatusName`);

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
-- Indexes for table `returned`
--
ALTER TABLE `returned`
  ADD PRIMARY KEY (`ReturnID`);

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
-- AUTO_INCREMENT for table `book`
--
ALTER TABLE `book`
  MODIFY `BookID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `borrow`
--
ALTER TABLE `borrow`
  MODIFY `BorrowID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `login`
--
ALTER TABLE `login`
  MODIFY `LibraryID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `returned`
--
ALTER TABLE `returned`
  MODIFY `ReturnID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
