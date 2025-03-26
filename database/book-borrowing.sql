-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 26, 2025 at 07:19 AM
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
  `Title` varchar(255) DEFAULT NULL,
  `Author` varchar(255) DEFAULT NULL,
  `Year` int(11) DEFAULT NULL,
  `ISBN` varchar(50) NOT NULL,
  `Category` varchar(100) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  `Image` varchar(255) DEFAULT NULL,
  `Copies` int(11) DEFAULT NULL,
  `AddedDate` date DEFAULT NULL,
  `CallNumber` varchar(100) DEFAULT NULL,
  `RackNumber` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `book`
--

INSERT INTO `book` (`Title`, `Author`, `Year`, `ISBN`, `Category`, `Status`, `Image`, `Copies`, `AddedDate`, `CallNumber`, `RackNumber`) VALUES
('Harry Potter and the Order of the Phoenix (Harry Potter  #5)', 'J.K. Rowling/Mary GrandPré', 2024, '9.780439358E+12', 'Fiction', 'Available', NULL, 3, '2025-03-26', 'FIC RG 2024', 2),
('Harry Potter and the Chamber of Secrets (Harry Potter  #2)', 'J.K. Rowling', 2025, '9.780439555E+12', 'Fiction', 'Available', NULL, 3, '2025-03-26', 'FIC ROW 2025', 3),
('Harry Potter and the Prisoner of Azkaban (Harry Potter  #3)', 'J.K. Rowling/Mary GrandPré', 2026, '9.780439655E+12', 'Fiction', 'Available', NULL, 4, '2025-03-26', 'FIC RG 2026', 4),
('Harry Potter Boxed Set  Books 1-5 (Harry Potter  #1-5)', 'J.K. Rowling/Mary GrandPré', 2027, '9.780439683E+12', 'Fiction', 'Available', NULL, 5, '2025-03-26', 'FIC RG 2027', 5),
('Harry Potter and the Half-Blood Prince (Harry Potter  #6)', 'J.K. Rowling/Mary GrandPré', 2023, '9.780439786E+12', 'Fiction', 'Available', NULL, 1, '2025-03-26', 'FIC RG 2023', 1),
('Harry Potter Collection (Harry Potter  #1-6)', 'J.K. Rowling', 2029, '9.780439828E+12', 'Fiction', 'Available', NULL, 7, '2025-03-26', 'FIC ROW 2029', 7),
('Unauthorized Harry Potter Book Seven News: \"Half-Blood Prince\" Analysis and Speculation', 'W. Frederick Zimmerman', 2028, '9.780976541E+12', 'Fiction', 'Available', NULL, 6, '2025-03-26', 'FIC ZIM 2028', 6);

--
-- Triggers `book`
--
DELIMITER $$
CREATE TRIGGER `generate_copies` AFTER INSERT ON `book` FOR EACH ROW BEGIN
    DECLARE i INT DEFAULT 1;

    -- Add logic to generate copies or any other operations
    WHILE i <= NEW.Copies DO
        -- Use NEW.BookID here to reference the auto-generated BookID
        -- Perform necessary operations, such as inserting into another table or something else
        SET i = i + 1;
    END WHILE;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `borrow`
--

CREATE TABLE `borrow` (
  `BorrowID` int(11) NOT NULL,
  `StudNo` varchar(50) DEFAULT NULL,
  `ISBN` varchar(20) DEFAULT NULL,
  `Title` varchar(255) DEFAULT NULL,
  `CopyID` int(11) NOT NULL,
  `BorrowDate` date DEFAULT NULL,
  `DueDate` date DEFAULT NULL,
  `StatusName` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `borrow`
--

INSERT INTO `borrow` (`BorrowID`, `StudNo`, `ISBN`, `Title`, `CopyID`, `BorrowDate`, `DueDate`, `StatusName`) VALUES
(1, '211241', '9.780439358E+12', 'Harry Potter and the Order of the Phoenix (Harry Potter  #5)', 0, '2025-03-26', '2025-03-26', 'Returned');

-- --------------------------------------------------------

--
-- Table structure for table `copies`
--

CREATE TABLE `copies` (
  `CopyID` varchar(10) NOT NULL,
  `ISBN` varchar(50) NOT NULL,
  `Status` enum('Available','Borrowed','Damaged','Lost') DEFAULT 'Available'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

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
  `ISBN` varchar(20) DEFAULT NULL,
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
  `ISBN` varchar(20) DEFAULT NULL,
  `CopyID` varchar(10) DEFAULT NULL,
  `StudNo` varchar(15) NOT NULL,
  `ReturnDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `return_good`
--

INSERT INTO `return_good` (`ReturnID`, `BorrowID`, `ISBN`, `CopyID`, `StudNo`, `ReturnDate`) VALUES
(1, 1, '9.780439358E+12', NULL, '211241', '2025-03-26');

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
  `FullName` varchar(255) NOT NULL,
  `ContactNumber` varchar(15) DEFAULT NULL,
  `Email` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserID`, `StudNo`, `FullName`, `ContactNumber`, `Email`) VALUES
(1, '211083', 'Monica', '09368417320', 'nicladeras97@gmail.com'),
(2, '211241', 'Cano', '09368417320', 'monicano@gmail.com'),
(3, '211394', 'Rhea', '09123456789', 'rheamartin@gmail.com'),
(4, '211154', 'April', '09124356786', 'aprilreyes@gmail.com\r\n'),
(5, '201107', 'Kimberly', '09123456789', 'kimberlyjeresano@gmail.com'),
(6, '211321', 'Dale', '09123456789', 'dalesoriano@gmail.com');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `book`
--
ALTER TABLE `book`
  ADD PRIMARY KEY (`ISBN`),
  ADD KEY `idx_book_title` (`Title`),
  ADD KEY `idx_book_author` (`Author`);

--
-- Indexes for table `borrow`
--
ALTER TABLE `borrow`
  ADD PRIMARY KEY (`BorrowID`),
  ADD KEY `fk_borrow_user_new` (`StudNo`),
  ADD KEY `fk_borrow_copy` (`CopyID`);

--
-- Indexes for table `copies`
--
ALTER TABLE `copies`
  ADD PRIMARY KEY (`CopyID`),
  ADD KEY `fk_copies_book` (`ISBN`);

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
  ADD KEY `BookID` (`ISBN`),
  ADD KEY `StudNo` (`StudNo`),
  ADD KEY `return_damaged_ibfk_1` (`BorrowID`);

--
-- Indexes for table `return_good`
--
ALTER TABLE `return_good`
  ADD PRIMARY KEY (`ReturnID`),
  ADD KEY `fk_return_good_book` (`ISBN`),
  ADD KEY `fk_return_good_copy` (`CopyID`),
  ADD KEY `return_good_ibfk_1` (`BorrowID`);

--
-- Indexes for table `return_lost`
--
ALTER TABLE `return_lost`
  ADD PRIMARY KEY (`ReturnLostID`),
  ADD KEY `BookID` (`ISBN`),
  ADD KEY `StudNo` (`StudNo`),
  ADD KEY `return_lost_ibfk_1` (`BorrowID`);

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
-- AUTO_INCREMENT for table `borrow`
--
ALTER TABLE `borrow`
  MODIFY `BorrowID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

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
  MODIFY `ReturnID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `return_lost`
--
ALTER TABLE `return_lost`
  MODIFY `ReturnLostID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `borrow`
--
ALTER TABLE `borrow`
  ADD CONSTRAINT `fk_borrow_user_new` FOREIGN KEY (`StudNo`) REFERENCES `users` (`StudNo`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `copies`
--
ALTER TABLE `copies`
  ADD CONSTRAINT `fk_copies_book` FOREIGN KEY (`ISBN`) REFERENCES `book` (`ISBN`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `return_damaged`
--
ALTER TABLE `return_damaged`
  ADD CONSTRAINT `return_damaged_ibfk_1` FOREIGN KEY (`BorrowID`) REFERENCES `borrow` (`BorrowID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `return_damaged_ibfk_3` FOREIGN KEY (`StudNo`) REFERENCES `users` (`StudNo`) ON DELETE CASCADE;

--
-- Constraints for table `return_good`
--
ALTER TABLE `return_good`
  ADD CONSTRAINT `fk_return_good_copy` FOREIGN KEY (`CopyID`) REFERENCES `copies` (`CopyID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `return_good_ibfk_1` FOREIGN KEY (`BorrowID`) REFERENCES `borrow` (`BorrowID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `return_lost`
--
ALTER TABLE `return_lost`
  ADD CONSTRAINT `return_lost_ibfk_1` FOREIGN KEY (`BorrowID`) REFERENCES `borrow` (`BorrowID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `return_lost_ibfk_3` FOREIGN KEY (`StudNo`) REFERENCES `users` (`StudNo`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
