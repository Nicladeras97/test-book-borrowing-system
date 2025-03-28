-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 28, 2025 at 11:16 PM
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
-- Table structure for table `books`
--

CREATE TABLE `books` (
  `Title` varchar(255) DEFAULT NULL,
  `Author` varchar(255) DEFAULT NULL,
  `Year` int(11) DEFAULT NULL,
  `ISBN` varchar(50) NOT NULL,
  `Category` varchar(100) DEFAULT NULL,
  `Copies` int(11) DEFAULT NULL,
  `AddedDate` date DEFAULT NULL,
  `CallNumber` varchar(100) DEFAULT NULL,
  `Rack` varchar(11) DEFAULT NULL,
  `Accno` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `books`
--

INSERT INTO `books` (`Title`, `Author`, `Year`, `ISBN`, `Category`, `Copies`, `AddedDate`, `CallNumber`, `Rack`, `Accno`) VALUES
('Harry Potter and the Order of the Phoenix (Harry Potter  #5)', 'J.K. Rowling/Mary GrandPré', 2024, '9.780439358E+12', 'Fiction', 1, '2025-03-26', 'FIC RG 2024', 'A', 'Fic20241001'),
('Harry Potter and the Chamber of Secrets (Harry Potter  #2)', 'J.K. Rowling', 2025, '9.780439555E+12', 'Fiction', 1, '2025-03-26', 'FIC ROW 2025', 'A', 'Fic20251002'),
('Harry Potter and the Prisoner of Azkaban (Harry Potter  #3)', 'J.K. Rowling/Mary GrandPré', 2026, '9.780439655E+12', 'Fiction', 1, '2025-03-26', 'FIC RG 2026', 'A', 'Fic20261003'),
('Harry Potter and the Half-Blood Prince (Harry Potter  #6)', 'J.K. Rowling/Mary GrandPré', 2023, '9.780439786E+12', 'Fiction', 1, '2025-03-26', 'FIC RG 2023', 'A', 'Fic20231004'),
('Unauthorized Harry Potter Book Seven News: \"Half-Blood Prince\" Analysis and Speculation', 'W. Frederick Zimmerman', 2028, '9.780976541E+12', 'Fiction', 6, '2025-03-26', 'FIC ZIM 2028', 'A', 'Fic20281005');

-- --------------------------------------------------------

--
-- Table structure for table `books_borrowed`
--

CREATE TABLE `books_borrowed` (
  `borrow_id` int(11) NOT NULL,
  `borrower_id` varchar(50) NOT NULL,
  `book_id` varchar(50) NOT NULL,
  `condition_id` int(11) NOT NULL,
  `date_borrowed` date NOT NULL,
  `due_date` date NOT NULL,
  `time` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `books_borrowed`
--

INSERT INTO `books_borrowed` (`borrow_id`, `borrower_id`, `book_id`, `condition_id`, `date_borrowed`, `due_date`, `time`) VALUES
(1, '201107', 'Fic20251002', 1, '2025-03-28', '2025-03-29', '15:50:00');

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
(2, 'used but in good condition'),
(3, 'Damaged');

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
(3, 'Reminder of borrowed book due today', 'Due', 'Dear Borrower,\r\n\r\nI hope this message finds you well. This is a friendly reminder that the book you borrowed is due today.\r\n\r\nPlease ensure that you return the book before this day ends to avoid any late fees or penalties.\r\n\r\nThank you for your cooperatio');

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
-- Indexes for table `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`ISBN`),
  ADD UNIQUE KEY `Accno` (`Accno`),
  ADD KEY `idx_book_title` (`Title`),
  ADD KEY `idx_book_author` (`Author`);

--
-- Indexes for table `books_borrowed`
--
ALTER TABLE `books_borrowed`
  ADD PRIMARY KEY (`borrow_id`),
  ADD KEY `borrower_id` (`borrower_id`),
  ADD KEY `Book_id` (`book_id`),
  ADD KEY `condition_id` (`condition_id`);

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
  MODIFY `borrow_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `book_condition`
--
ALTER TABLE `book_condition`
  MODIFY `condition_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `email_message`
--
ALTER TABLE `email_message`
  MODIFY `message_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `librarians`
--
ALTER TABLE `librarians`
  MODIFY `LibraryID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `books_borrowed`
--
ALTER TABLE `books_borrowed`
  ADD CONSTRAINT `Book_id` FOREIGN KEY (`book_id`) REFERENCES `books` (`Accno`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `borrower_id` FOREIGN KEY (`borrower_id`) REFERENCES `users` (`StudNo`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `condition_id` FOREIGN KEY (`condition_id`) REFERENCES `book_condition` (`condition_id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
