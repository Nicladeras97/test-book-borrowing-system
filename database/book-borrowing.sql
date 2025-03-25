-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 25, 2025 at 01:04 PM
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
('Philippine Journal of Science', 'Department of Science and Technology', 1906, '0031-7683', 'Journal', 'Borrowed', NULL, 1, '2025-03-25', 'JNL PJS 1906', 5),
('How to Write a Thesis', 'Umberto Eco', 1977, '262527138', 'Thesis', 'Available', NULL, 1, '2025-03-25', 'THE ECO 1977', 6),
('A Concise Guide to Writing a Thesis or Dissertation', 'Halyna M. Kornuta and Ron W. Germaine', 2019, '429615000', 'Thesis', 'Available', NULL, 1, '2025-03-25', 'THE KOR 2019', 6),
('Yellowface', 'R.F Kuang', 2023, '978-0-008532-77-2', 'Fiction', 'Available', NULL, 1, '2025-03-25', 'FIC KUA 2023', 1),
('The Poetry Of Robert Frost', 'Robert Frost', 1969, '978-0-030725-35-7', 'Non-Fiction', 'Borrowed', NULL, 1, '2025-03-25', 'NF FRO 1969', 2),
('Engineering Mechanics: Statics', 'Russell C. Hibbeler', 2019, '978-0-134686-60-1', 'TextBook', 'Available', NULL, 1, '2025-03-25', 'TB HIB 2019', 4),
('The Tao Of Pooh', 'Benjamin Hoff', 1983, '978-0-140067-47-7', 'Non-Fiction', 'Available', NULL, 1, '2025-03-25', 'NF HOF 1983', 2),
('How to Write a BA Thesis, Second Edition', 'Charles Lipson', 2018, '978-0-22643107-9', 'Thesis', 'Available', NULL, 1, '2025-03-25', 'THE LIP 2018', 6),
('Writing Your Journal Article in Twelve Weeks', 'Wendy Laura Belcher', 2019, '978-0-226499-91-8', 'Journal', 'Borrowed', NULL, 1, '2025-03-25', 'JNL BEL 2019', 5),
('Born To Run', 'Christopher McDougall', 2009, '978-0-307266-30-9', 'Non-Fiction', 'Available', NULL, 1, '2025-03-25', 'NF MCD 2009', 2),
('Quiet', 'Susan Cain', 2012, '978-0-307352-14-9', 'Non-Fiction', 'Available', NULL, 1, '2025-03-25', 'NF CAI 2012', 2),
('Bird\'s Basic Engineering Mathematics', 'John Bird', 2021, '978-0-367643-67-6', 'TextBook', 'Available', NULL, 1, '2025-03-25', 'TB BIR 2021', 4),
('The Diary Of A Young Girl', 'Anne Frank', 1995, '978-0-385473-78-1', 'Non-Fiction', 'Available', NULL, 1, '2025-03-25', 'NF FRA 1995', 2),
('Born A Crime', 'Trevor Noah', 2016, '978-0-399588-17-4', 'Non-Fiction', 'Available', NULL, 1, '2025-03-25', 'NF NOA 2016', 2),
('The Laws of Human Nature', 'Robert Greene', 2018, '978-0-525428-14-5', 'Non-Fiction', 'Available', NULL, 1, '2025-03-25', 'NF GRE 2018', 2),
('The Midnight Library', 'Matt Haig', 2020, '978-0-525559-47-4', 'Fiction', 'Available', NULL, 1, '2025-03-25', 'FIC HAI 2020', 1),
('Sword Catcher (The Chronicles of Castellane)', 'Cassandra Clare', 2023, '978-0-525620-01-3', 'Fiction', 'Available', NULL, 1, '2025-03-25', 'FIC CLA 2023', 1),
('Calculus', 'James Stewart', 2016, '978-0-538497-90-9', 'TextBook', 'Available', NULL, 1, '2025-03-25', 'TB STE 2016', 4),
('Black Woods Blue Sky', 'Eowyn Ivey', 2025, '978-0-593231-02-9', 'Fiction', 'Available', NULL, 1, '2025-03-25', 'FIC IVE 2025', 1),
('A Room Of One\'s Own', 'Virginia Woolf', 1989, '978-0-606208-90-1', 'Non-Fiction', 'Available', NULL, 1, '2025-03-25', 'NF WOO 1989', 2),
('Silent Spring', 'Rachel Carson', 1962, '978-0-618253-05-0', 'Non-Fiction', 'Available', NULL, 1, '2025-03-25', 'NF CAR 1962', 2),
('Through Time Into Healing', 'Brian L. Weiss', 1992, '978-0-671867-86-7', 'Non-Fiction', 'Available', NULL, 1, '2025-03-25', 'NF WEI 1992', 2),
('River of Blue', 'Tad William', 1998, '978-0-886777-77-7', 'Non-Fiction', 'Available', NULL, 1, '2025-03-25', 'NF WIL 1998', 2),
('Talk English', 'Ken Xiao', 2016, '978-0-998163-20-8', 'Non-Fiction', 'Available', NULL, 1, '2025-03-25', 'NF XIA 2016', 2),
('Science Fiction and Fantasy Literature', 'R.Reginald', 2010, '978-0941028-76-9', 'Fiction', 'Available', NULL, 1, '2025-03-25', 'FIC REG 2010', 1),
('An Exploration of Sustainable Energy Solutions', 'Emily Johnson', 2022, '978-1-234-567-89-0', 'Thesis', 'Available', NULL, 1, '2025-03-25', 'THE JOH 2022', 6),
('Principles of Economics', 'Nicholas Gregory Mankiw', 2017, '978-1-30558512-6', 'Fiction', 'Available', NULL, 1, '2025-03-25', 'FIC MAN 2017', 1),
('The Book of Records', 'Madeleine Thien', 2025, '978-1-324078-65-4', 'Fiction', 'Available', NULL, 1, '2025-03-25', 'FIC THI 2025', 1),
('The aventures of Tom Sawyer', 'Mark Twain', 2004, '978-1-402714-60-3', 'Fiction', 'Available', NULL, 1, '2025-03-25', 'FIC TWA 2004', 1),
('The Course o True Love', 'Cassandra Clare', 2014, '978-1-442495-63-0', 'Fiction', 'Available', NULL, 1, '2025-03-25', 'FIC CLA 2014', 1),
('Our Plastic Problem: A Call for Global Solutions', 'Megan Durnford', 2025, '978-1-459836-70-9', 'Non-Fiction', 'Available', NULL, 1, '2025-03-25', 'NF DUR 2025', 2),
('I have No Mouth & I Must Scream', 'Harlan Ellison', 2014, '978-1-497609-61-7', 'Non-Fiction', 'Available', NULL, 1, '2025-03-25', 'NF ELL 2014', 2),
('All your perfects', 'Colleen Hoover', 2018, '978-1-501171-59-8', 'Fiction', 'Available', NULL, 1, '2025-03-25', 'FIC HOO 2018', 1),
('I want to die but I want to eat Tteokbokki', 'Baek Sehee', 2018, '978-1-526650-86-3', 'Non-Fiction', 'Available', NULL, 1, '2025-03-25', 'NF SEE 2018', 2),
('Lessons in Chemistry', 'Bonnie Garmus', 2022, '978-1-529938-29-6', 'Fiction', 'Available', NULL, 1, '2025-03-25', 'FIC GAR 2022', 1),
('In Cold Blood', 'Truman Capote', 2001, '978-1-588361-65-3', 'Non-Fiction', 'Available', NULL, 1, '2025-03-25', 'NF CAP 2001', 2),
('Finish what you start', 'Peter Hollins', 2018, '978-1-647430-51-1', 'Non-Fiction', 'Available', NULL, 1, '2025-03-25', 'NF HOL 2018', 2),
('Blaze Orange: A Midcoast Maine Mystery', 'Allison Keeton', 2025, '978-1-685128-64-7', 'Fiction', 'Available', NULL, 1, '2025-03-25', 'FIC KEE 2025', 1),
('No-Fail Habits', 'Michael Hyatt', 2020, '978-1-735381-71-8', 'Non-Fiction', 'Available', NULL, 1, '2025-03-25', 'NF HYA 2020', 2),
('Self-Publish & Succeed', 'Julie Broad', 2021, '978-1-736031-50-6', 'Non-Fiction', 'Available', NULL, 1, '2025-03-25', 'NF BRO 2021', 2),
('Data-Driven Decisions', 'Amy Stubbing', 2022, '978-1-783304-79-0', 'TextBook', 'Available', NULL, 1, '2025-03-25', 'TB STU 2022', 4),
('Ancient Greek 1; A 21st Century Approach', 'Philip S. Peek', 2021, '978-1-800642-56-0', 'History', 'Available', NULL, 1, '2025-03-25', 'HIS PEE 2021', 3),
('Atomic Habits', 'James Clear', 2018, '978-1-80422020-7', 'Fiction', 'Available', NULL, 1, '2025-03-25', 'FIC CLE 2018', 1),
('101 Essays that will Change the way you think', 'Brianna West', 2016, '978-1-945796-06-7', 'Non-Fiction', 'Available', NULL, 1, '2025-03-25', 'NF WES 2016', 2),
('Atomic Physics for Everyone', 'Will Raven', 2025, '978-3-031695-07-0', 'TextBook', 'Borrowed', NULL, 1, '2025-03-25', 'TB RAV 2025', 4),
('Faulkner’s Treatment of Women', 'Dr. Vibha Manoj Sharma', 2017, '978-81-93390-41-2', 'Journal', 'Available', NULL, 1, '2025-03-25', 'JNL SHA 2017', 5),
('Propagation of Glory Lily (Gloriosa superba L.)', 'Dr. S. Anandhi', 2017, '978-81-93390-46-7', 'Journal', 'Available', NULL, 1, '2025-03-25', 'JNL ANA 2017', 5);

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
(1, '211083', '0031-7683', 'Philippine Journal of Science', 0, '2025-03-25', '2025-03-26', 'Borrowed'),
(2, '211241', '978-0-030725-35-7', 'The Poetry Of Robert Frost', 0, '2025-03-25', '2025-03-26', 'Borrowed'),
(3, '211241', '978-0-226499-91-8', 'Writing Your Journal Article in Twelve Weeks', 0, '2025-03-25', '2025-03-25', 'Borrowed'),
(4, '211083', '978-3-031695-07-0', 'Atomic Physics for Everyone', 0, '2025-03-25', '2025-03-25', 'Borrowed');

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
  `ReturnDate` date NOT NULL,
  `Remarks` text DEFAULT NULL
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
  MODIFY `BorrowID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

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
