-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 31, 2025 at 01:35 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

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
-- Table structure for table `books`
--

CREATE TABLE `books` (
  `Title` varchar(255) DEFAULT NULL,
  `Author` varchar(255) DEFAULT NULL,
  `Year` int(11) DEFAULT NULL,
  `Publisher` varchar(255) NOT NULL,
  `ISBN` varchar(50) NOT NULL,
  `Section` varchar(100) NOT NULL,
  `AddedDate` date DEFAULT NULL,
  `CallNumber` varchar(100) DEFAULT NULL,
  `Rack` varchar(11) DEFAULT NULL,
  `Accno` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `books`
--

INSERT INTO `books` (`Title`, `Author`, `Year`, `Publisher`, `ISBN`, `Section`, `AddedDate`, `CallNumber`, `Rack`, `Accno`) VALUES
('The Great Gatsby', 'F. Scott Fitzgerald', 1925, 'Scribner', '123456789', 'Fiction', NULL, 'PS3511.F45 G7', 'R2', 'FIC19250001-01'),
('The Great Gatsby', 'F. Scott Fitzgerald', 1925, 'Scribner', '', 'Fiction', NULL, 'PS3511.F45 G7', 'R2', 'FIC19250001-02'),
('The Great Gatsby', 'F. Scott Fitzgerald', 1925, 'Scribner', '', 'Fiction', NULL, 'PS3511.F45 G7', 'R2', 'FIC19250001-03'),
('The Great Gatsby', 'F. Scott Fitzgerald', 1925, 'Scribner', '', 'Fiction', NULL, 'PS3511.F45 G7', 'R2', 'FIC19250002-01'),
('The Great Gatsby', 'F. Scott Fitzgerald', 1925, 'Scribner', '', 'Fiction', NULL, 'PS3511.F45 G7', 'R2', 'FIC19250002-02'),
('The Great Gatsby', 'F. Scott Fitzgerald', 1925, 'Scribner', '', 'Fiction', NULL, 'PS3511.F45 G7', 'R2', 'FIC19250002-03'),
('The Great Gatsby', 'F. Scott Fitzgerald', 1925, 'Scribner', '', 'Fiction', NULL, 'PS3511.F45 G7', 'R2', 'FIC19250003-02'),
('The Great Gatsby', 'F. Scott Fitzgerald', 1925, 'Scribner', '', 'Fiction', NULL, 'PS3511.F45 G7', 'R2', 'FIC19250003-03'),
('The Untouchable', 'John Banville', 1998, 'Publisher', '', 'Fiction', NULL, 'PR6052.A57', 'P', 'FIC19980001-01'),
('The Untouchable', 'John Banville', 1998, 'Publisher', '', 'Fiction', NULL, 'PR6052.A57', 'P', 'FIC19980001-02'),
('The Untouchable', 'John Banville', 1998, 'Publisher', '', 'Fiction', NULL, 'PR6052.A57', 'P', 'FIC19980002-01'),
('The Untouchable', 'John Banville', 1998, 'Publisher', '', 'Fiction', NULL, 'PR6052.A57', 'P', 'FIC19980002-02'),
('The Untouchable', 'John Banville', 1998, 'Publisher', '', 'Fiction', NULL, 'PR6052.A57', 'P', 'FIC19980003-01'),
('The Untouchable', 'John Banville', 1998, 'Publisher', '', 'Fiction', NULL, 'PR6052.A57', 'P', 'FIC19980003-02'),
('Harry Potter and the Half-Blood Prince', 'J.K. Rowling', 2005, 'Bloomsbury', '9780439785969', 'Fiction', NULL, 'FIC HP 2005', 'A', 'Fic20241006'),
('Harry Potter and the Deathly Hallows', 'J.K. Rowling', 2007, 'Bloomsbury', '9780545139700', 'Fiction', NULL, 'FIC HP 2007', 'A', 'Fic20241007'),
('The Tales of Beedle the Bard', 'J.K. Rowling', 2008, 'Bloomsbury', '9780545162074', 'Fiction', NULL, 'FIC HP 2008', 'A', 'Fic20241008'),
('Atomic Habits', 'James Clear', 2004, '978-1-5635-708-3', 'Little, Brown and Company', 'Filipiniana', '2025-03-29', 'B550', 'FIL B 369 C', 'FIL2004-01'),
('A Short History  of Nearly Everything', 'Bill Bryson', 2003, 'Publisher', '978-0-76-790818-4', 'Reference', NULL, 'Q162 .B88 2003', 'Q', 'REF20030001-01'),
('A Short History  of Nearly Everything', 'Bill Bryson', 2003, 'Publisher', '', 'Reference', NULL, 'Q162 .B88 2003', 'Q', 'REF20030002-01'),
('A Short History  of Nearly Everything', 'Bill Bryson', 2003, 'Publisher', '', 'Reference', NULL, 'Q162 .B88 2003', 'Q', 'REF20030003-01');

-- --------------------------------------------------------

--
-- Table structure for table `books_borrowed`
--

CREATE TABLE `books_borrowed` (
  `borrow_id` int(11) NOT NULL,
  `borrower_id` int(11) NOT NULL,
  `book_id` varchar(50) NOT NULL,
  `condition_id` int(11) NOT NULL,
  `date_borrowed` date NOT NULL,
  `due_date` date NOT NULL,
  `time` time NOT NULL,
  `notify_id` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `books_borrowed`
--

INSERT INTO `books_borrowed` (`borrow_id`, `borrower_id`, `book_id`, `condition_id`, `date_borrowed`, `due_date`, `time`, `notify_id`) VALUES
(34, 1, 'FIC19250001-01', 1, '2025-03-31', '2025-04-04', '18:02:23', 2);

-- --------------------------------------------------------

--
-- Table structure for table `book_condition`
--

CREATE TABLE `book_condition` (
  `condition_id` int(11) NOT NULL,
  `condition_status` char(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `book_condition`
--

INSERT INTO `book_condition` (`condition_id`, `condition_status`) VALUES
(1, 'New'),
(2, 'Good'),
(3, 'Damaged'),
(4, 'Lost');

-- --------------------------------------------------------

--
-- Table structure for table `deadline_status`
--

CREATE TABLE `deadline_status` (
  `borrowerID` int(11) NOT NULL,
  `deadline_status` char(20) NOT NULL,
  `email_messageID` int(11) NOT NULL,
  `email_status` char(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `email_message`
--

CREATE TABLE `email_message` (
  `message_id` int(11) NOT NULL,
  `subject` char(255) NOT NULL,
  `deadline` char(20) NOT NULL,
  `message_content` char(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `email_message`
--

INSERT INTO `email_message` (`message_id`, `subject`, `deadline`, `message_content`) VALUES
(1, 'Reminder of almost due borrowed book', 'Almost Due', 'Dear Borrower,\r\n\r\nI hope this message finds you well. This is a friendly reminder that the book you borrowed is almost due.\r\n\r\nPlease ensure that you return the book by this date to avoid any late fees or penalties. \r\n\r\nThank you for your cooperation and'),
(2, 'Reminder of Overdue borrowed book', 'Overdue', 'Dear Borrower,\r\n\r\nI hope this message finds you well. I wanted to let you know that the book you borrowed is currently overdue.\r\n\r\nWe kindly ask that you return it to avoid any penalties. \r\n\r\nThank you for your prompt attention to this matter.\r\n'),
(3, 'Reminder of borrowed book due today', 'Due', 'Dear Borrower,\r\n\r\nI hope this message finds you well. This is a friendly reminder that the book you borrowed is due today.\r\n\r\nPlease ensure that you return the book before this day ends to avoid any late fees or penalties.\r\n\r\nThank you for your cooperatio'),
(4, 'None', 'Not yet Due', 'None');

-- --------------------------------------------------------

--
-- Table structure for table `librarians`
--

CREATE TABLE `librarians` (
  `LibraryID` int(11) NOT NULL,
  `FullName` varchar(255) NOT NULL,
  `Username` varchar(100) NOT NULL,
  `Password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `librarians`
--

INSERT INTO `librarians` (`LibraryID`, `FullName`, `Username`, `Password`) VALUES
(3, 'Dale Wood', 'dalehoods', 'ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f'),
(4, 'user', 'user', 'user');

-- --------------------------------------------------------

--
-- Table structure for table `returned_books`
--

CREATE TABLE `returned_books` (
  `return_id` int(11) NOT NULL,
  `BorrowerID` int(11) NOT NULL,
  `BookID` varchar(50) NOT NULL,
  `ConditionID` int(11) NOT NULL,
  `Return Date` date NOT NULL,
  `Penalty Fee` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `returned_books`
--

INSERT INTO `returned_books` (`return_id`, `BorrowerID`, `BookID`, `ConditionID`, `Return Date`, `Penalty Fee`) VALUES
(11, 1, 'Fic20241006', 1, '2025-03-29', 100),
(12, 1, 'Fic20241006', 3, '2025-03-29', 3),
(13, 1, 'FIC19250002-01', 1, '2025-03-31', 1);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `UserID` int(11) NOT NULL,
  `StudNo` varchar(50) NOT NULL,
  `FullName` varchar(255) NOT NULL,
  `Year_Section` varchar(50) NOT NULL,
  `Course_Strand` varchar(50) NOT NULL,
  `ContactNumber` varchar(15) DEFAULT NULL,
  `Email` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserID`, `StudNo`, `FullName`, `Year_Section`, `Course_Strand`, `ContactNumber`, `Email`) VALUES
(1, '211083', 'Monica', '4 A', 'BSCS', '09368417320', 'nicladeras97@gmail.com'),
(3, '211394', 'Rhea', '4 A', 'BSCS', '09123456789', 'rheamartin@gmail.com'),
(4, '211154', 'April', '4 A', 'BSCS', '09124356786', 'aprilreyes@gmail.com\r\n'),
(5, '201107', 'Kimberly', '4 A', 'BSCS', '09123456789', 'kimberlyjeresano@gmail.com'),
(6, '211321', 'Dale', '4 A', 'BSCS', '09123456789', 'dalesoriano@gmail.com'),
(7, '211008', 'Allysa', '4 A', 'BSCS', '09123455856', 'allysapacunio0023@gmail.com');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`Accno`) USING BTREE,
  ADD KEY `idx_book_title` (`Title`),
  ADD KEY `idx_book_author` (`Author`);

--
-- Indexes for table `books_borrowed`
--
ALTER TABLE `books_borrowed`
  ADD PRIMARY KEY (`borrow_id`),
  ADD KEY `Book_id` (`book_id`),
  ADD KEY `condition_id` (`condition_id`),
  ADD KEY `BORROWER` (`borrower_id`);

--
-- Indexes for table `book_condition`
--
ALTER TABLE `book_condition`
  ADD PRIMARY KEY (`condition_id`);

--
-- Indexes for table `email_message`
--
ALTER TABLE `email_message`
  ADD PRIMARY KEY (`message_id`);

--
-- Indexes for table `librarians`
--
ALTER TABLE `librarians`
  ADD PRIMARY KEY (`LibraryID`),
  ADD UNIQUE KEY `Username` (`Username`);

--
-- Indexes for table `returned_books`
--
ALTER TABLE `returned_books`
  ADD PRIMARY KEY (`return_id`),
  ADD KEY `bookConditionID` (`ConditionID`),
  ADD KEY `bookID` (`BookID`),
  ADD KEY `BORROWER_id` (`BorrowerID`);

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
-- AUTO_INCREMENT for table `books_borrowed`
--
ALTER TABLE `books_borrowed`
  MODIFY `borrow_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT for table `book_condition`
--
ALTER TABLE `book_condition`
  MODIFY `condition_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `email_message`
--
ALTER TABLE `email_message`
  MODIFY `message_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `librarians`
--
ALTER TABLE `librarians`
  MODIFY `LibraryID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `returned_books`
--
ALTER TABLE `returned_books`
  MODIFY `return_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `books_borrowed`
--
ALTER TABLE `books_borrowed`
  ADD CONSTRAINT `BORROWER` FOREIGN KEY (`borrower_id`) REFERENCES `users` (`UserID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `Book_id` FOREIGN KEY (`book_id`) REFERENCES `books` (`Accno`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `condition_id` FOREIGN KEY (`condition_id`) REFERENCES `book_condition` (`condition_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `returned_books`
--
ALTER TABLE `returned_books`
  ADD CONSTRAINT `BORROWER_id` FOREIGN KEY (`BorrowerID`) REFERENCES `users` (`UserID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `bookConditionID` FOREIGN KEY (`ConditionID`) REFERENCES `book_condition` (`condition_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `bookID` FOREIGN KEY (`BookID`) REFERENCES `books` (`Accno`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
