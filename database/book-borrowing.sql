-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 24, 2025 at 02:13 PM
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
('The Guns of the South', 'Harry Turtledove', 1992, '0-345-38468-7', 'Non-Fiction', 'Damaged', 'img/books/default.jpg', 1, '2025-03-24', 'NF TUR 1992', 1),
('The Journal of Political Economy', 'Various Authors', 2021, '0022-3808', 'Journal', 'Available', 'img/books/default.jpg', 1, '2025-03-24', 'JNL JPE 2021', 20),
('Nature', 'Springer', 2020, '0028-0836', 'Journal', 'Available', 'img/books/default.jpg', 1, '2025-03-24', 'JNL NATURE 2020', 6),
('The Catcher in the Rye', 'J.D. Salinger', 1951, '978-0-316-76948-0', 'Fiction', 'Available', 'img/books/default.jpg', 1, '2025-03-24', 'FIC SAL 1951', 8),
('River of Blue', 'Tad Williams', 1998, '978-0-886777-77-7', 'Non-Fiction', 'Lost', 'img/books/default.jpg', 1, '2025-03-24', 'NF WIL 1998', 1),
('Sapiens: A Brief History of Humankind', 'Yuval Noah Harari', 2011, '978-0062316097', 'History', 'Available', 'img/books/default.jpg', 1, '2025-03-24', 'HIS HAR 2011', 11),
('The History of the Philippines', 'David L. Clawson', 2006, '978-0073526577', 'Non-Fiction', 'Available', 'img/books/default.jpg', 1, '2025-03-24', 'NF CLAW 2006', 4),
('The Communist Manifesto', 'Karl Marx & Friedrich Engels', 1848, '978-0140447576', 'History', 'Available', 'img/books/default.jpg', 1, '2025-03-24', 'HIS MAR 1848', 13),
('Advanced Engineering Mathematics', 'Erwin Kreyszig', 2011, '978-0470458365', 'Textbook', 'Available', 'img/books/default.jpg', 1, '2025-03-24', 'TXT KREY 2011', 15),
('Quantum Mechanics: Concepts and Applications', 'Nouredine Zettili', 2009, '978-0470748772', 'Textbook', 'Available', 'img/books/default.jpg', 1, '2025-03-24', 'TXT ZETT 2009', 19),
('The Diary of a Young Girl', 'Anne Frank', 1947, '978-0553296983', 'History', 'Damaged', 'img/books/default.jpg', 1, '2025-03-24', 'HIS FRA 1947', 14),
('A Brief History of Time', 'Stephen Hawking', 1988, '978-0553380163', 'Non-Fiction', 'Available', 'img/books/default.jpg', 1, '2025-03-24', 'NF HAWK 1988', 9),
('The God Delusion', 'Richard Dawkins', 2006, '978-0618680003', 'Non-Fiction', 'Available', 'img/books/default.jpg', 1, '2025-03-24', 'NF DAW 2006', 17),
('The Great Gatsby', 'F. Scott Fitzgerald', 1925, '978-0743273565', 'Fiction', 'Available', 'img/books/default.jpg', 1, '2025-03-24', 'FIC FITZ 1925', 12),
('The Power of Habit', 'Charles Duhigg', 2012, '978-0812981605', 'Non-Fiction', 'Available', 'img/books/default.jpg', 1, '2025-03-24', 'NF DUH 2012', 16),
('The Art of War', 'Sun Tzu', -500, '978-1-60527-297-6', 'History', 'Available', 'img/books/default.jpg', 1, '2025-03-24', 'HIS SUN 500BC', 7),
('Physics for Scientists and Engineers', 'Raymond A. Serway & John W. Jewett', 2013, '978-1133947271', 'Textbook', 'Available', 'img/books/default.jpg', 1, '2025-03-24', 'TXT SERW 2013', 10),
('Moby-Dick', 'Herman Melville', 1851, '978-1503280786', 'Fiction', 'Available', 'img/books/default.jpg', 1, '2025-03-24', 'FIC MEL 1851', 18),
('Trese: Murder on Balete Drive', 'Budjette Tan & Kajo Baldisimo', 2013, '978-971-94752-0-9', 'Fiction', 'Available', 'img/books/default.jpg', 1, '2025-03-24', 'FIC TAN 2013', 2),
('Bakit Baliktad Magbasa ng Libro ang mga Pilipino?', 'Bob Ong', 2001, '978-9715503195', 'Fiction', 'Available', 'img/books/default.jpg', 1, '2025-03-24', 'FIC ONG 2001', 1),
('Where the Crawdads Sing', 'Delia Owens', 2018, '9780735219090', 'Mystery', 'Available', 'img/books/default.jpg', 1, '2025-03-24', 'FIC OWE 2018', 2);

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
  `BorrowID` varchar(50) NOT NULL,
  `StudNo` varchar(50) DEFAULT NULL,
  `CopyID` int(11) NOT NULL,
  `BorrowDate` date DEFAULT NULL,
  `DueDate` date DEFAULT NULL,
  `StatusName` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `copies`
--

CREATE TABLE `copies` (
  `CopyID` varchar(10) NOT NULL,
  `ISBN` varchar(20) DEFAULT NULL,
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
  `BorrowID` varchar(50) DEFAULT NULL,
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
  `BorrowID` varchar(50) NOT NULL,
  `ISBN` varchar(20) DEFAULT NULL,
  `CopyID` varchar(10) DEFAULT NULL,
  `StudNo` varchar(15) NOT NULL,
  `ReturnDate` date NOT NULL,
  `Remarks` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `return_lost`
--

CREATE TABLE `return_lost` (
  `ReturnLostID` int(11) NOT NULL,
  `BorrowID` varchar(50) DEFAULT NULL,
  `ISBN` varchar(20) DEFAULT NULL,
  `StudNo` varchar(50) DEFAULT NULL,
  `ReportDate` date DEFAULT NULL,
  `GracePeriod` date DEFAULT NULL,
  `FineAmount` decimal(10,2) DEFAULT NULL,
  `ReturnDate` date DEFAULT NULL
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
  ADD KEY `fk_copies_book` (`ISBN`),
  ADD KEY `idx_status` (`Status`);

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
  ADD KEY `BookID` (`ISBN`),
  ADD KEY `StudNo` (`StudNo`);

--
-- Indexes for table `return_good`
--
ALTER TABLE `return_good`
  ADD PRIMARY KEY (`ReturnID`),
  ADD KEY `fk_return_good_borrow` (`BorrowID`),
  ADD KEY `fk_return_good_book` (`ISBN`),
  ADD KEY `fk_return_good_copy` (`CopyID`);

--
-- Indexes for table `return_lost`
--
ALTER TABLE `return_lost`
  ADD PRIMARY KEY (`ReturnLostID`),
  ADD KEY `BorrowID` (`BorrowID`),
  ADD KEY `BookID` (`ISBN`),
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
  MODIFY `ReturnID` int(11) NOT NULL AUTO_INCREMENT;

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
-- Constraints for table `borrow`
--
ALTER TABLE `borrow`
  ADD CONSTRAINT `fk_borrow_user_new` FOREIGN KEY (`StudNo`) REFERENCES `users` (`StudNo`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `return_damaged`
--
ALTER TABLE `return_damaged`
  ADD CONSTRAINT `return_damaged_ibfk_1` FOREIGN KEY (`BorrowID`) REFERENCES `borrow` (`BorrowID`) ON DELETE CASCADE,
  ADD CONSTRAINT `return_damaged_ibfk_3` FOREIGN KEY (`StudNo`) REFERENCES `users` (`StudNo`) ON DELETE CASCADE;

--
-- Constraints for table `return_good`
--
ALTER TABLE `return_good`
  ADD CONSTRAINT `fk_return_good_borrow` FOREIGN KEY (`BorrowID`) REFERENCES `borrow` (`BorrowID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_return_good_copy` FOREIGN KEY (`CopyID`) REFERENCES `copies` (`CopyID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `return_lost`
--
ALTER TABLE `return_lost`
  ADD CONSTRAINT `return_lost_ibfk_1` FOREIGN KEY (`BorrowID`) REFERENCES `borrow` (`BorrowID`) ON DELETE CASCADE,
  ADD CONSTRAINT `return_lost_ibfk_3` FOREIGN KEY (`StudNo`) REFERENCES `users` (`StudNo`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
