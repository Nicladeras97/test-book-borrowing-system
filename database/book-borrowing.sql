-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 12, 2025 at 01:57 AM
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
('Noli Me Tangere', 'José Rizal', 1887, 'National Book Store', '978-9710813801', 'Filipiniana', '2025-04-11', 'FIL DS 675 R59 1887', 'DSR1', '2025000001-00'),
('Fundamentals of Accounting', 'Win Ballada', 2010, 'GIC Enterprises', '978-9719902193', 'Reserved', '2025-04-11', 'RES HF 5636 B35 2010', 'HFR2', '2025000003-00'),
('Encyclopedia of Philippine Art', 'CCP', 1994, 'CCP Publishing', '978-9718546077', 'Reference', '2025-04-11', 'REF NX 570 P6 C37', 'NR3', '2025000004-00'),
('Smaller and Smaller Circles', 'F.H. Batacan', 2002, 'University of the Philippines Press', '978-9715424507', 'Fiction', '2025-04-11', 'FIC PS 9993 B37 2002', 'PSR5', '2025000006-00'),
('The Invisible Life of Addie LaRue', 'Agatha Christie', 1998, 'Vintage', '978-1-5265-210-7', 'Section', '2025-04-11', 'SHS A 260 CA66 1998', 'CA66', '2025000007-00'),
('Atomic Habits', 'James Clear', 2004, 'Little, Brown and Company', '978-1-5635-708-4', 'SHS', '2025-04-11', 'FIL B 369 CB35 2004', 'CB35', '2025000008-00'),
('A Man Called Ove', 'Stephen King', 1994, 'Doubleday', '978-1-9880-351-5', 'Filipiniana', '2025-04-11', 'RES C 500 KC26 1994', 'KC26', '2025000009-00'),
('Daisy Jones & The Six', 'Fredrik Backman', 1986, 'Hachette Book Group', '978-1-3314-390-6', 'Reserved', '2025-04-11', 'SHS D 466 BD80 1986', 'BD80', '2025000010-00'),
('Daisy Jones & The Six', 'TJ Klune', 1992, 'Penguin Random House', '978-1-8297-256-7', 'SHS', '2025-04-11', 'FIL E 810 KE71 1992', 'KE71', '2025000011-00'),
('A Man Called Ove', 'Tracy Deonn', 2009, 'Penguin Random House', '978-1-2233-658-5', 'Filipiniana', '2025-04-11', 'RES F 733 DF53 2009', 'DF53', '2025000012-00'),
('Legendborn', 'Michelle Obama', 1999, 'Ballantine Books', '978-1-8858-681-8', 'Reserved', '2025-04-11', 'SHS G 171 OG33 1999', 'OG33', '2025000013-00'),
('The Night Circus', 'Markus Zusak', 1992, 'Crown Publishing', '978-1-8440-905-1', 'SHS', '2025-04-11', 'SHS H 873 ZH60 1992', 'ZH60', '2025000014-00'),
('Project Hail Mary', 'Michelle Obama', 2020, 'HarperCollins', '978-1-4032-861-8', 'SHS', '2025-04-11', 'FIL I 455 OI32 2020', 'OI32', '2025000015-00'),
('The Night Circus', 'Fredrik Backman', 1983, 'Harlequin', '978-1-4929-150-8', 'Filipiniana', '2025-04-11', 'REF J 902 BJ44 1983', 'BJ44', '2025000016-00'),
('Verity', 'Markus Zusak', 2001, 'Ballantine Books', '978-1-9747-375-9', 'Reference', '2025-04-11', 'FIL K 952 ZK51 2001', 'ZK51', '2025000017-00'),
('Becoming', 'Madeline Miller', 2002, 'Penguin Random House', '978-1-6197-667-5', 'Filipiniana', '2025-04-11', 'REF L 840 ML90 2002', 'ML90', '2025000018-00'),
('The House in the Cerulean Sea', 'Andy Weir', 1987, 'Simon & Schuster', '978-1-6129-759-2', 'Reference', '2025-04-11', 'FIL M 112 WM29 1987', 'WM29', '2025000019-00'),
('Educated', 'James Clear', 2008, 'Hachette Book Group', '978-1-9248-233-5', 'Filipiniana', '2025-04-11', 'RES N 316 CN70 2008', 'CN70', '2025000020-00'),
('It Ends With Us', 'Alex Michaelides', 1994, 'Farrar, Straus and Giroux', '978-1-2998-289-4', 'Reserved', '2025-04-11', 'SHS O 622 MO29 1994', 'MO29', '2025000021-00'),
('The House in the Cerulean Sea', 'Tara Westover', 2012, 'Simon & Schuster', '978-1-6190-789-8', 'SHS', '2025-04-11', 'RES P 158 WP49 2012', 'WP49', '2025000022-00'),
('Circe', 'Paulo Coelho', 1986, 'Crown Publishing', '978-1-2444-896-4', 'Reserved', '2025-04-11', 'RES Q 686 CQ30 1986', 'CQ30', '2025000023-00'),
('Daisy Jones & The Six', 'Delia Owens', 2012, 'Hachette Book Group', '978-1-4867-926-10', 'Reserved', '2025-04-11', 'FIL R 468 OR68 2012', 'OR68', '2025000024-00'),
('Daisy Jones & The Six', 'Taylor Jenkins Reid', 2001, 'Harlequin', '978-1-9585-247-8', 'Filipiniana', '2025-04-11', 'SHS S 442 RS20 2001', 'RS20', '2025000025-00'),
('A Man Called Ove', 'Agatha Christie', 2018, 'HarperCollins', '978-1-4568-254-1', 'SHS', '2025-04-11', 'RES T 487 CT75 2018', 'CT75', '2025000026-00'),
('The Night Circus', 'Alex Michaelides', 2020, 'Macmillan Publishers', '978-1-3173-747-1', 'Reserved', '2025-04-11', 'FIL U 526 MU84 2020', 'MU84', '2025000027-00'),
('The Invisible Life of Addie LaRue', 'Markus Zusak', 2021, 'St. Martin\'s Press', '978-1-5951-555-9', 'Filipiniana', '2025-04-11', 'RES V 515 ZV47 2021', 'ZV47', '2025000028-00'),
('The Invisible Life of Addie LaRue', 'J.K. Rowling', 2002, 'Doubleday', '978-1-1290-277-3', 'Reserved', '2025-04-11', 'SHS W 483 RW84 2002', 'RW84', '2025000029-00'),
('The Midnight Library', 'Michelle Obama', 1982, 'Grand Central Publishing', '978-1-2028-128-9', 'SHS', '2025-04-11', 'SHS X 586 OX19 1982', 'OX19', '2025000030-00'),
('The Invisible Life of Addie LaRue', 'Michelle Obama', 1993, 'Crown Publishing', '978-1-8274-300-10', 'SHS', '2025-04-11', 'REF Y 301 OY22 1993', 'OY22', '2025000031-00'),
('The Night Circus', 'Matt Haig', 2009, 'Harlequin', '978-1-7716-754-7', 'Reference', '2025-04-11', 'SHS Z 690 HZ58 2009', 'HZ58', '2025000032-00'),
('It Ends With Us', 'Paulo Coelho', 1985, 'Vintage', '978-1-8086-776-1', 'SHS', '2025-04-11', 'REF A 159 CA91 1985', 'CA91', '2025000033-00'),
('The House in the Cerulean Sea', 'James Clear', 1991, 'Penguin Random House', '978-1-6804-832-8', 'Reference', '2025-04-11', 'SHS B 696 CB49 1991', 'CB49', '2025000034-00'),
('Project Hail Mary', 'Andy Weir', 2000, 'Macmillan Publishers', '978-1-2893-512-10', 'SHS', '2025-04-11', 'RES C 898 WC16 2000', 'WC16', '2025000035-00'),
('Daisy Jones & The Six', 'TJ Klune', 2007, 'Grand Central Publishing', '978-1-3192-195-5', 'Reserved', '2025-04-11', 'RES D 803 KD62 2007', 'KD62', '2025000036-00'),
('Daisy Jones & The Six', 'Stephen King', 1980, 'Scholastic', '978-1-8152-501-2', 'Reserved', '2025-04-11', 'SHS E 448 KE35 1980', 'KE35', '2025000037-00'),
('The Seven Husbands of Evelyn Hugo', 'Paulo Coelho', 2018, 'Bloomsbury Publishing', '978-1-6543-366-10', 'SHS', '2025-04-11', 'RES F 913 CF27 2018', 'CF27', '2025000038-00'),
('A Man Called Ove', 'J.K. Rowling', 1992, 'Harlequin', '978-1-1762-403-4', 'Reserved', '2025-04-11', 'FIL G 880 RG48 1992', 'RG48', '2025000039-00'),
('Atomic Habits', 'Fredrik Backman', 2023, 'Macmillan Publishers', '978-1-5353-262-6', 'Filipiniana', '2025-04-11', 'RES H 771 BH75 2023', 'BH75', '2025000040-00'),
('The Silent Patient', 'Taylor Jenkins Reid', 1991, 'Little, Brown and Company', '978-1-5505-984-2', 'Reserved', '2025-04-11', 'SHS I 347 RI55 1991', 'RI55', '2025000041-00'),
('The Song of Achilles', 'Michelle Obama', 1990, 'Doubleday', '978-1-5087-983-2', 'SHS', '2025-04-11', 'REF J 453 OJ87 1990', 'OJ87', '2025000042-00'),
('Legendborn', 'Alex Michaelides', 2000, 'St. Martin\'s Press', '978-1-3304-915-4', 'Reference', '2025-04-11', 'FIL K 855 MK67 2000', 'MK67', '2025000043-00'),
('Project Hail Mary', 'V.E. Schwab', 2006, 'Little, Brown and Company', '978-1-2071-459-10', 'Filipiniana', '2025-04-11', 'SHS L 506 SL63 2006', 'SL63', '2025000044-00'),
('Project Hail Mary', 'V.E. Schwab', 2006, 'Little, Brown and Company', '978-1-2071-459-10', 'Filipiniana', '2025-04-11', 'SHS L 506 SL63 2006', 'SL63', '2025000045-01'),
('Project Hail Mary', 'V.E. Schwab', 2006, 'Little, Brown and Company', '978-1-2071-459-10', 'Filipiniana', '2025-04-11', 'SHS L 506 SL63 2006', 'SL63', '2025000046-02'),
('Educated', 'Paulo Coelho', 2020, 'Little, Brown and Company', '978-1-1243-547-10', 'SHS', '2025-04-11', 'REF M 777 CM93 2020', 'CM93', '2025000047-00'),
('The Seven Husbands of Evelyn Hugo', 'Fredrik Backman', 1998, 'Tor Books', '978-1-1069-535-3', 'Reference', '2025-04-11', 'SHS N 436 BN93 1998', 'BN93', '2025000048-00'),
('The Book Thief', 'Taylor Jenkins Reid', 2004, 'G.P. Putnam\'s Sons', '978-1-1626-371-1', 'SHS', '2025-04-11', 'RES O 426 RO95 2004', 'RO95', '2025000049-00'),
('Legendborn', 'James Clear', 2019, 'HarperCollins', '978-1-8836-329-2', 'Reserved', '2025-04-11', 'REF P 314 CP73 2019', 'CP73', '2025000050-00'),
('Project Hail Mary', 'Matt Haig', 1984, 'G.P. Putnam\'s Sons', '978-1-3451-726-10', 'Reference', '2025-04-11', 'SHS Q 164 HQ87 1984', 'HQ87', '2025000051-00'),
('Legendborn', 'TJ Klune', 1991, 'Doubleday', '978-1-4115-126-5', 'SHS', '2025-04-11', 'RES R 554 KR77 1991', 'KR77', '2025000052-00'),
('The Night Circus', 'Delia Owens', 2018, 'G.P. Putnam\'s Sons', '978-1-5498-571-4', 'Reserved', '2025-04-11', 'REF S 560 OS58 2018', 'OS58', '2025000053-00'),
('Project Hail Mary', 'V.E. Schwab', 2003, 'Vintage', '978-1-4997-786-8', 'Reference', '2025-04-11', 'RES T 554 ST15 2003', 'ST15', '2025000054-00'),
('Where the Crawdads Sing', 'Colleen Hoover', 2012, 'Crown Publishing', '978-1-4828-781-5', 'Reserved', '2025-04-11', 'REF U 624 HU93 2012', 'HU93', '2025000055-00'),
('The Book Thief', 'Erin Morgenstern', 2014, 'Grand Central Publishing', '978-1-3360-141-9', 'Reference', '2025-04-11', 'SHS V 148 MV71 2014', 'MV71', '2025000056-00'),
('Where the Crawdads Sing', 'Madeline Miller', 2023, 'Simon & Schuster', '978-1-8740-842-1', 'SHS', '2025-04-11', 'SHS W 589 MW84 2023', 'MW84', '2025000057-00'),
('Project Hail Mary', 'Markus Zusak', 2020, 'Grand Central Publishing', '978-1-7094-548-4', 'SHS', '2025-04-11', 'SHS X 399 ZX45 2020', 'ZX45', '2025000058-00'),
('The Seven Husbands of Evelyn Hugo', 'Tara Westover', 1992, 'Bantam Books', '978-1-3366-258-10', 'SHS', '2025-04-11', 'SHS Y 409 WY29 1992', 'WY29', '2025000059-00'),
('The Alchemist', 'Michelle Obama', 2024, 'St. Martin\'s Press', '978-1-7048-131-9', 'SHS', '2025-04-11', 'SHS Z 658 OZ16 2024', 'OZ16', '2025000060-00'),
('A Man Called Ove', 'Markus Zusak', 1994, 'Harlequin', '978-1-7721-406-1', 'SHS', '2025-04-11', 'RES A 500 ZA51 1994', 'ZA51', '2025000061-00'),
('The Song of Achilles', 'V.E. Schwab', 1982, 'Little, Brown and Company', '978-1-4989-671-3', 'Reserved', '2025-04-11', 'REF B 315 SB88 1982', 'SB88', '2025000062-00'),
('Becoming', 'Madeline Miller', 1994, 'Penguin Random House', '978-1-7605-828-1', 'Reference', '2025-04-11', 'SHS C 154 MC62 1994', 'MC62', '2025000063-00'),
('The Midnight Library', 'Tara Westover', 2004, 'HarperCollins', '978-1-3164-972-9', 'SHS', '2025-04-11', 'FIL D 599 WD95 2004', 'WD95', '2025000064-00'),
('The Invisible Life of Addie LaRue', 'Colleen Hoover', 2013, 'Farrar, Straus and Giroux', '978-1-5137-141-6', 'Filipiniana', '2025-04-11', 'SHS E 872 HE58 2013', 'HE58', '2025000065-00'),
('Verity', 'Agatha Christie', 1992, 'HarperCollins', '978-1-7660-717-2', 'SHS', '2025-04-11', 'SHS F 525 CF12 1992', 'CF12', '2025000066-00'),
('Verity', 'James Clear', 2014, 'Scholastic', '978-1-3692-361-6', 'SHS', '2025-04-11', 'REF G 879 CG11 2014', 'CG11', '2025000067-00'),
('It Ends With Us', 'Colleen Hoover', 1987, 'Vintage', '978-1-3249-335-9', 'Reference', '2025-04-11', 'SHS H 489 HH31 1987', 'HH31', '2025000068-00'),
('Where the Crawdads Sing', 'Tara Westover', 2017, 'Bloomsbury Publishing', '978-1-2357-501-3', 'SHS', '2025-04-11', 'REF I 830 WI86 2017', 'WI86', '2025000069-00'),
('The Seven Husbands of Evelyn Hugo', 'V.E. Schwab', 2011, 'Crown Publishing', '978-1-5962-850-9', 'Reference', '2025-04-11', 'SHS J 500 SJ19 2011', 'SJ19', '2025000070-00'),
('It Ends With Us', 'TJ Klune', 2008, 'Bloomsbury Publishing', '978-1-9243-737-7', 'SHS', '2025-04-11', 'FIL K 533 KK20 2008', 'KK20', '2025000071-00'),
('The Alchemist', 'Markus Zusak', 1981, 'Doubleday', '978-1-8566-122-2', 'Filipiniana', '2025-04-11', 'RES L 535 ZL29 1981', 'ZL29', '2025000072-00'),
('Where the Crawdads Sing', 'Michelle Obama', 1997, 'Bloomsbury Publishing', '978-1-6830-579-10', 'Reserved', '2025-04-11', 'RES M 169 OM41 1997', 'OM41', '2025000073-00'),
('The Invisible Life of Addie LaRue', 'Michelle Obama', 2022, 'Little, Brown and Company', '978-1-5425-659-7', 'Reserved', '2025-04-11', 'RES N 372 ON23 2022', 'ON23', '2025000074-00'),
('Becoming', 'Stephen King', 2018, 'Farrar, Straus and Giroux', '978-1-8560-478-2', 'Reserved', '2025-04-11', 'FIL O 918 KO88 2018', 'KO88', '2025000075-00'),
('The House in the Cerulean Sea', 'Alex Michaelides', 2013, 'Grand Central Publishing', '978-1-3383-791-2', 'Filipiniana', '2025-04-11', 'FIL P 972 MP43 2013', 'MP43', '2025000076-00'),
('It Ends With Us', 'Paulo Coelho', 2002, 'Tor Books', '978-1-2885-414-6', 'Filipiniana', '2025-04-11', 'SHS Q 689 CQ54 2002', 'CQ54', '2025000077-00'),
('Daisy Jones & The Six', 'Delia Owens', 2002, 'Harlequin', '978-1-2431-311-10', 'SHS', '2025-04-11', 'FIL R 527 OR69 2002', 'OR69', '2025000078-00'),
('The Silent Patient', 'James Clear', 1987, 'Simon & Schuster', '978-1-2470-181-10', 'Filipiniana', '2025-04-11', 'RES S 459 CS14 1987', 'CS14', '2025000079-00'),
('Atomic Habits', 'TJ Klune', 1985, 'Tor Books', '978-1-1481-838-7', 'Reserved', '2025-04-11', 'RES T 702 KT97 1985', 'KT97', '2025000080-00'),
('The Book Thief', 'TJ Klune', 2000, 'Scholastic', '978-1-7576-152-3', 'Reserved', '2025-04-11', 'REF U 178 KU16 2000', 'KU16', '2025000081-00'),
('Becoming', 'Tara Westover', 1996, 'Hachette Book Group', '978-1-9750-928-9', 'Reference', '2025-04-11', 'REF V 591 WV17 1996', 'WV17', '2025000082-00'),
('Educated', 'Paulo Coelho', 2018, 'Doubleday', '978-1-4084-583-3', 'Reference', '2025-04-11', 'SHS W 148 CW90 2018', 'CW90', '2025000083-00'),
('Circe', 'Matt Haig', 1983, 'Ballantine Books', '978-1-6777-406-4', 'SHS', '2025-04-11', 'SHS X 311 HX96 1983', 'HX96', '2025000084-00'),
('Project Hail Mary', 'Taylor Jenkins Reid', 2005, 'St. Martin\'s Press', '978-1-5304-114-6', 'SHS', '2025-04-11', 'FIL Y 488 RY26 2005', 'RY26', '2025000085-00'),
('The Midnight Library', 'J.K. Rowling', 1993, 'Penguin Random House', '978-1-3057-821-9', 'Filipiniana', '2025-04-11', 'FIL Z 624 RZ17 1993', 'RZ17', '2025000086-00'),
('Atomic Habits', 'J.K. Rowling', 1987, 'HarperCollins', '978-1-5969-936-7', 'Filipiniana', '2025-04-11', 'RES A 494 RA42 1987', 'RA42', '2025000087-00'),
('Educated', 'Markus Zusak', 2018, 'Farrar, Straus and Giroux', '978-1-7104-802-6', 'Reserved', '2025-04-11', 'SHS B 388 ZB63 2018', 'ZB63', '2025000088-00'),
('It Ends With Us', 'V.E. Schwab', 1990, 'Macmillan Publishers', '978-1-1423-300-10', 'SHS', '2025-04-11', 'SHS C 777 SC15 1990', 'SC15', '2025000089-00'),
('Legendborn', 'TJ Klune', 2008, 'Crown Publishing', '978-1-4047-327-6', 'SHS', '2025-04-11', 'RES D 205 KD48 2008', 'KD48', '2025000090-00'),
('The Silent Patient', 'Matt Haig', 1982, 'Harlequin', '978-1-6220-966-6', 'Reserved', '2025-04-11', 'SHS E 798 HE40 1982', 'HE40', '2025000091-00'),
('Legendborn', 'Tracy Deonn', 1990, 'Scholastic', '978-1-9641-906-2', 'SHS', '2025-04-11', 'FIL F 537 DF63 1990', 'DF63', '2025000092-00'),
('The Alchemist', 'V.E. Schwab', 1989, 'Knopf Publishing Group', '978-1-7740-406-2', 'Filipiniana', '2025-04-11', 'FIL G 577 SG39 1989', 'SG39', '2025000093-00'),
('Circe', 'J.K. Rowling', 1983, 'Macmillan Publishers', '978-1-6915-749-3', 'Filipiniana', '2025-04-11', 'RES H 175 RH37 1983', 'RH37', '2025000094-00'),
('Project Hail Mary', 'Delia Owens', 2020, 'Bantam Books', '978-1-9287-953-4', 'Reserved', '2025-04-11', 'SHS I 735 OI98 2020', 'OI98', '2025000095-00'),
('Becoming', 'Taylor Jenkins Reid', 2022, 'Tor Books', '978-1-3943-213-10', 'SHS', '2025-04-11', 'SHS J 758 RJ58 2022', 'RJ58', '2025000096-00'),
('Circe', 'Erin Morgenstern', 2023, 'Doubleday', '978-1-9153-119-5', 'SHS', '2025-04-11', 'FIL K 959 MK96 2023', 'MK96', '2025000097-00'),
('It Ends With Us', 'Markus Zusak', 1980, 'Harlequin', '978-1-2649-264-3', 'Filipiniana', '2025-04-11', 'FIL L 852 ZL65 1980', 'ZL65', '2025000098-00'),
('The Seven Husbands of Evelyn Hugo', 'Agatha Christie', 2023, 'Farrar, Straus and Giroux', '978-1-7175-289-3', 'Filipiniana', '2025-04-11', 'REF M 301 CM49 2023', 'CM49', '2025000099-00'),
('The Song of Achilles', 'Tracy Deonn', 2004, 'Doubleday', '978-1-4720-784-7', 'Reference', '2025-04-11', 'RES N 455 DN29 2004', 'DN29', '2025000100-00'),
('Verity', 'Andy Weir', 1984, 'Harlequin', '978-1-8780-648-9', 'Reserved', '2025-04-11', 'RES O 695 WO10 1984', 'WO10', '2025000101-00'),
('The Silent Patient', 'Matt Haig', 1985, 'Little, Brown and Company', '978-1-4428-502-2', 'Reserved', '2025-04-11', 'REF P 689 HP33 1985', 'HP33', '2025000102-00'),
('Legendborn', 'J.K. Rowling', 2003, 'Little, Brown and Company', '978-1-1731-462-10', 'Reference', '2025-04-11', 'RES Q 838 RQ81 2003', 'RQ81', '2025000103-00'),
('Atomic Habits', 'Madeline Miller', 2001, 'St. Martin\'s Press', '978-1-9934-399-7', 'Reserved', '2025-04-11', 'FIL R 140 MR49 2001', 'MR49', '2025000104-00'),
('The Seven Husbands of Evelyn Hugo', 'Delia Owens', 2001, 'Ballantine Books', '978-1-2496-160-10', 'Filipiniana', '2025-04-11', 'REF S 398 OS24 2001', 'OS24', '2025000105-00'),
('Becoming', 'Madeline Miller', 2006, 'Penguin Random House', '978-1-3021-748-1', 'Reference', '2025-04-11', 'FIL T 845 MT83 2006', 'MT83', '2025000106-00'),
('Atomic Habits', 'Agatha Christie', 2015, 'Bantam Books', '978-1-7543-564-4', 'Filipiniana', '2025-04-11', 'SHS U 572 CU52 2015', 'CU52', '2025000107-00'),
('The House in the Cerulean Sea', 'Tara Westover', 1984, 'Simon & Schuster', '978-1-3809-972-10', 'SHS', '2025-04-11', 'REF V 767 WV38 1984', 'WV38', '2025000108-00'),
('The Alchemist', 'Delia Owens', 2014, 'Scholastic', '978-1-3438-742-9', 'Reference', '2025-04-11', 'FIL W 557 OW44 2014', 'OW44', '2025000109-00'),
('Educated', 'Colleen Hoover', 2003, 'Doubleday', '978-1-7191-440-1', 'Filipiniana', '2025-04-11', 'SHS X 289 HX44 2003', 'HX44', '2025000110-00'),
('Daisy Jones & The Six', 'James Clear', 1980, 'Bloomsbury Publishing', '978-1-4530-451-4', 'SHS', '2025-04-11', 'FIL Y 687 CY15 1980', 'CY15', '2025000111-00'),
('The Song of Achilles', 'Markus Zusak', 2023, 'Doubleday', '978-1-7281-805-6', 'Filipiniana', '2025-04-11', 'SHS Z 588 ZZ95 2023', 'ZZ95', '2025000112-00'),
('Where the Crawdads Sing', 'Delia Owens', 2023, 'Simon & Schuster', '978-1-4131-929-3', 'SHS', '2025-04-11', 'SHS A 439 OA83 2023', 'OA83', '2025000113-00'),
('Educated', 'Tracy Deonn', 2007, 'Knopf Publishing Group', '978-1-1006-816-4', 'SHS', '2025-04-11', 'REF B 411 DB61 2007', 'DB61', '2025000114-00'),
('Atomic Habits', 'Paulo Coelho', 1987, 'Simon & Schuster', '978-1-5661-809-3', 'Reference', '2025-04-11', 'REF C 275 CC47 1987', 'CC47', '2025000115-00'),
('The Book Thief', 'Agatha Christie', 1996, 'St. Martin\'s Press', '978-1-3559-880-3', 'Reference', '2025-04-11', 'REF D 422 CD43 1996', 'CD43', '2025000116-00'),
('The Silent Patient', 'Delia Owens', 2016, 'G.P. Putnam\'s Sons', '978-1-4596-288-9', 'Reference', '2025-04-11', 'SHS E 713 OE96 2016', 'OE96', '2025000117-00'),
('The Invisible Life of Addie LaRue', 'Matt Haig', 2010, 'Knopf Publishing Group', '978-1-2966-810-7', 'SHS', '2025-04-11', 'SHS F 368 HF65 2010', 'HF65', '2025000118-00'),
('A Man Called Ove', 'Andy Weir', 2008, 'G.P. Putnam\'s Sons', '978-1-1804-970-4', 'SHS', '2025-04-11', 'FIL G 525 WG50 2008', 'WG50', '2025000119-00'),
('Circe', 'Tracy Deonn', 2017, 'Vintage', '978-1-6734-175-10', 'Filipiniana', '2025-04-11', 'FIL H 576 DH19 2017', 'DH19', '2025000120-00'),
('The Night Circus', 'Andy Weir', 1997, 'Simon & Schuster', '978-1-7192-699-7', 'Filipiniana', '2025-04-11', 'RES I 963 WI58 1997', 'WI58', '2025000121-00'),
('A Man Called Ove', 'Erin Morgenstern', 1989, 'Scholastic', '978-1-7659-384-5', 'Reserved', '2025-04-11', 'SHS J 275 MJ97 1989', 'MJ97', '2025000122-00'),
('Becoming', 'Markus Zusak', 2024, 'Vintage', '978-1-1911-568-8', 'SHS', '2025-04-11', 'RES K 476 ZK42 2024', 'ZK42', '2025000123-00'),
('The Night Circus', 'TJ Klune', 1996, 'Knopf Publishing Group', '978-1-3682-916-1', 'Reserved', '2025-04-11', 'RES L 609 KL34 1996', 'KL34', '2025000124-00'),
('Daisy Jones & The Six', 'Andy Weir', 2002, 'HarperCollins', '978-1-8549-792-10', 'Reserved', '2025-04-11', 'FIL M 210 WM91 2002', 'WM91', '2025000125-00'),
('The Night Circus', 'Alex Michaelides', 1981, 'Hachette Book Group', '978-1-9796-419-4', 'Filipiniana', '2025-04-11', 'REF N 754 MN65 1981', 'MN65', '2025000126-00'),
('A Man Called Ove', 'Fredrik Backman', 2001, 'Tor Books', '978-1-2589-514-2', 'Reference', '2025-04-11', 'SHS O 122 BO71 2001', 'BO71', '2025000127-00'),
('The Alchemist', 'Erin Morgenstern', 2011, 'Macmillan Publishers', '978-1-8883-322-2', 'SHS', '2025-04-11', 'SHS P 571 MP22 2011', 'MP22', '2025000128-00'),
('The Song of Achilles', 'Alex Michaelides', 2016, 'Harlequin', '978-1-1838-207-3', 'SHS', '2025-04-11', 'SHS Q 462 MQ97 2016', 'MQ97', '2025000129-00'),
('Project Hail Mary', 'V.E. Schwab', 2008, 'Macmillan Publishers', '978-1-9458-343-10', 'SHS', '2025-04-11', 'SHS R 237 SR90 2008', 'SR90', '2025000130-00'),
('Legendborn', 'Matt Haig', 1996, 'Penguin Random House', '978-1-9159-116-1', 'SHS', '2025-04-11', 'FIL S 848 HS39 1996', 'HS39', '2025000131-00'),
('Daisy Jones & The Six', 'Tracy Deonn', 2011, 'G.P. Putnam\'s Sons', '978-1-9965-658-6', 'Filipiniana', '2025-04-11', 'REF T 808 DT12 2011', 'DT12', '2025000132-00'),
('The Seven Husbands of Evelyn Hugo', 'Andy Weir', 1980, 'Doubleday', '978-1-4416-310-4', 'Reference', '2025-04-11', 'REF U 140 WU64 1980', 'WU64', '2025000133-00'),
('The Night Circus', 'Matt Haig', 2000, 'Tor Books', '978-1-6993-594-9', 'Reference', '2025-04-11', 'SHS V 439 HV63 2000', 'HV63', '2025000134-00'),
('The Invisible Life of Addie LaRue', 'Michelle Obama', 1984, 'Macmillan Publishers', '978-1-8371-469-8', 'SHS', '2025-04-11', 'RES W 216 OW57 1984', 'OW57', '2025000135-00'),
('Daisy Jones & The Six', 'Agatha Christie', 2000, 'Little, Brown and Company', '978-1-4454-327-8', 'Reserved', '2025-04-11', 'FIL X 679 CX13 2000', 'CX13', '2025000136-00'),
('The Midnight Library', 'Delia Owens', 1994, 'Simon & Schuster', '978-1-3752-814-6', 'Filipiniana', '2025-04-11', 'SHS Y 820 OY80 1994', 'OY80', '2025000137-00'),
('Becoming', 'V.E. Schwab', 1986, 'Doubleday', '978-1-3898-907-4', 'SHS', '2025-04-11', 'FIL Z 967 SZ82 1986', 'SZ82', '2025000138-00'),
('Becoming', 'Colleen Hoover', 1993, 'Harlequin', '978-1-7050-410-2', 'Filipiniana', '2025-04-11', 'REF A 991 HA97 1993', 'HA97', '2025000139-00'),
('The Midnight Library', 'Paulo Coelho', 1988, 'Scholastic', '978-1-5789-294-8', 'Reference', '2025-04-11', 'REF B 312 CB62 1988', 'CB62', '2025000140-00'),
('The House in the Cerulean Sea', 'Tracy Deonn', 1980, 'Bantam Books', '978-1-2281-738-8', 'Reference', '2025-04-11', 'FIL C 612 DC45 1980', 'DC45', '2025000141-00'),
('Becoming', 'Erin Morgenstern', 1981, 'Vintage', '978-1-1378-897-9', 'Filipiniana', '2025-04-11', 'FIL D 754 MD15 1981', 'MD15', '2025000142-00'),
('The Seven Husbands of Evelyn Hugo', 'James Clear', 1981, 'Penguin Random House', '978-1-1511-323-9', 'Filipiniana', '2025-04-11', 'FIL E 627 CE45 1981', 'CE45', '2025000143-00'),
('The Invisible Life of Addie LaRue', 'Stephen King', 1987, 'Farrar, Straus and Giroux', '978-1-8115-700-9', 'Filipiniana', '2025-04-11', 'RES F 127 KF68 1987', 'KF68', '2025000144-00'),
('The Night Circus', 'Tracy Deonn', 2001, 'Tor Books', '978-1-6519-361-1', 'Reserved', '2025-04-11', 'REF G 977 DG19 2001', 'DG19', '2025000145-00'),
('Daisy Jones & The Six', 'Colleen Hoover', 2024, 'Bantam Books', '978-1-5308-840-9', 'Reference', '2025-04-11', 'REF H 303 HH15 2024', 'HH15', '2025000146-00'),
('Verity', 'Delia Owens', 1980, 'Simon & Schuster', '978-1-7069-676-7', 'Reference', '2025-04-11', 'RES I 280 OI34 1980', 'OI34', '2025000147-00'),
('The Book Thief', 'Delia Owens', 1981, 'Grand Central Publishing', '978-1-3321-487-10', 'Reserved', '2025-04-11', 'SHS J 649 OJ30 1981', 'OJ30', '2025000148-00'),
('The Night Circus', 'Delia Owens', 2004, 'Harlequin', '978-1-5809-204-10', 'SHS', '2025-04-11', 'REF K 355 OK98 2004', 'OK98', '2025000149-00'),
('The Midnight Library', 'Matt Haig', 1994, 'G.P. Putnam\'s Sons', '978-1-1301-340-1', 'Reference', '2025-04-11', 'FIL L 385 HL83 1994', 'HL83', '2025000150-00'),
('The House in the Cerulean Sea', 'Stephen King', 2004, 'Vintage', '978-1-5671-223-1', 'Filipiniana', '2025-04-11', 'FIL M 419 KM45 2004', 'KM45', '2025000151-00'),
('Daisy Jones & The Six', 'J.K. Rowling', 1993, 'Penguin Random House', '978-1-9118-559-8', 'Filipiniana', '2025-04-11', 'REF N 416 RN51 1993', 'RN51', '2025000152-00'),
('The Night Circus', 'Andy Weir', 1999, 'Vintage', '978-1-7139-651-1', 'Reference', '2025-04-11', 'SHS O 623 WO35 1999', 'WO35', '2025000153-00'),
('The Silent Patient', 'James Clear', 2011, 'Penguin Random House', '978-1-1830-830-10', 'SHS', '2025-04-11', 'FIL P 347 CP38 2011', 'CP38', '2025000154-00'),
('Daisy Jones & The Six', 'Taylor Jenkins Reid', 1989, 'Bloomsbury Publishing', '978-1-4089-351-2', 'Filipiniana', '2025-04-11', 'FIL Q 741 RQ66 1989', 'RQ66', '2025000155-00'),
('The Song of Achilles', 'Colleen Hoover', 2015, 'Simon & Schuster', '978-1-1223-303-7', 'Filipiniana', '2025-04-11', 'RES R 976 HR21 2015', 'HR21', '2025000156-00'),
('The Book Thief', 'James Clear', 2000, 'Grand Central Publishing', '978-1-5737-508-6', 'Reserved', '2025-04-11', 'SHS S 869 CS86 2000', 'CS86', '2025000157-00'),
('Project Hail Mary', 'Madeline Miller', 2016, 'Harlequin', '978-1-7562-426-6', 'SHS', '2025-04-11', 'REF T 158 MT19 2016', 'MT19', '2025000158-00'),
('The Invisible Life of Addie LaRue', 'TJ Klune', 2000, 'HarperCollins', '978-1-6349-821-3', 'Reference', '2025-04-11', 'RES U 985 KU97 2000', 'KU97', '2025000159-00'),
('Daisy Jones & The Six', 'Andy Weir', 2021, 'Penguin Random House', '978-1-1353-331-5', 'Reserved', '2025-04-11', 'RES V 444 WV34 2021', 'WV34', '2025000160-00'),
('Daisy Jones & The Six', 'Markus Zusak', 1990, 'Little, Brown and Company', '978-1-4480-653-9', 'Reserved', '2025-04-11', 'SHS W 649 ZW26 1990', 'ZW26', '2025000161-00'),
('Atomic Habits', 'Madeline Miller', 2001, 'Little, Brown and Company', '978-1-5634-739-10', 'SHS', '2025-04-11', 'REF X 980 MX58 2001', 'MX58', '2025000162-00'),
('Atomic Habits', 'Fredrik Backman', 1980, 'Crown Publishing', '978-1-8450-563-8', 'Reference', '2025-04-11', 'RES Y 899 BY70 1980', 'BY70', '2025000163-00'),
('It Ends With Us', 'Tara Westover', 1991, 'Little, Brown and Company', '978-1-7086-314-2', 'Reserved', '2025-04-11', 'RES Z 589 WZ91 1991', 'WZ91', '2025000164-00'),
('The Night Circus', 'Tracy Deonn', 1993, 'Macmillan Publishers', '978-1-3615-565-8', 'Reserved', '2025-04-11', 'RES A 276 DA53 1993', 'DA53', '2025000165-00'),
('The Night Circus', 'Andy Weir', 2011, 'Bloomsbury Publishing', '978-1-1113-221-4', 'Reserved', '2025-04-11', 'RES B 337 WB32 2011', 'WB32', '2025000166-00'),
('A Man Called Ove', 'Delia Owens', 1998, 'Little, Brown and Company', '978-1-2211-451-4', 'Reserved', '2025-04-11', 'RES D 882 OD79 1998', 'OD79', '2025000168-00'),
('The Alchemist', 'Stephen King', 2020, 'Grand Central Publishing', '978-1-5260-803-7', 'Reserved', '2025-04-11', 'REF E 958 KE47 2020', 'KE47', '2025000169-00'),
('Daisy Jones & The Six', 'Erin Morgenstern', 1986, 'Farrar, Straus and Giroux', '978-1-6252-422-3', 'Reference', '2025-04-11', 'FIL F 727 MF11 1986', 'MF11', '2025000170-00'),
('Legendborn', 'Madeline Miller', 1993, 'HarperCollins', '978-1-5116-469-9', 'Filipiniana', '2025-04-11', 'FIL G 484 MG69 1993', 'MG69', '2025000171-00'),
('Educated', 'Markus Zusak', 1995, 'Crown Publishing', '978-1-8720-170-7', 'Filipiniana', '2025-04-11', 'REF H 791 ZH29 1995', 'ZH29', '2025000172-00'),
('The Alchemist', 'Michelle Obama', 2020, 'HarperCollins', '978-1-3866-246-7', 'Reference', '2025-04-11', 'SHS I 348 OI78 2020', 'OI78', '2025000173-00'),
('The Song of Achilles', 'Alex Michaelides', 2009, 'Knopf Publishing Group', '978-1-4538-148-6', 'SHS', '2025-04-11', 'FIL J 184 MJ25 2009', 'MJ25', '2025000174-00'),
('The Seven Husbands of Evelyn Hugo', 'Taylor Jenkins Reid', 2013, 'Knopf Publishing Group', '978-1-4369-664-6', 'Filipiniana', '2025-04-11', 'SHS K 665 RK93 2013', 'RK93', '2025000175-00'),
('The Seven Husbands of Evelyn Hugo', 'V.E. Schwab', 1991, 'Hachette Book Group', '978-1-5844-279-4', 'SHS', '2025-04-11', 'RES L 426 SL73 1991', 'SL73', '2025000176-00'),
('Project Hail Mary', 'Madeline Miller', 1981, 'Ballantine Books', '978-1-1940-362-1', 'Reserved', '2025-04-11', 'SHS M 880 MM38 1981', 'MM38', '2025000177-00'),
('The Song of Achilles', 'Delia Owens', 1980, 'Crown Publishing', '978-1-5631-324-8', 'SHS', '2025-04-11', 'REF N 510 ON79 1980', 'ON79', '2025000178-00'),
('Project Hail Mary', 'Andy Weir', 2001, 'Simon & Schuster', '978-1-3613-557-6', 'Reference', '2025-04-11', 'SHS O 998 WO94 2001', 'WO94', '2025000179-00'),
('Verity', 'V.E. Schwab', 2000, 'Doubleday', '978-1-8335-964-3', 'SHS', '2025-04-11', 'FIL P 307 SP42 2000', 'SP42', '2025000180-00'),
('Atomic Habits', 'Fredrik Backman', 2015, 'Bantam Books', '978-1-5023-478-7', 'Filipiniana', '2025-04-11', 'RES Q 501 BQ95 2015', 'BQ95', '2025000181-00'),
('The Book Thief', 'Colleen Hoover', 2012, 'Bloomsbury Publishing', '978-1-3851-807-9', 'Reserved', '2025-04-11', 'FIL R 741 HR75 2012', 'HR75', '2025000182-00'),
('A Man Called Ove', 'Paulo Coelho', 1980, 'Macmillan Publishers', '978-1-7222-362-3', 'Filipiniana', '2025-04-11', 'REF S 935 CS26 1980', 'CS26', '2025000183-00'),
('Verity', 'Tara Westover', 2021, 'Harlequin', '978-1-2843-678-2', 'Reference', '2025-04-11', 'REF T 131 WT39 2021', 'WT39', '2025000184-00'),
('The Book Thief', 'Delia Owens', 2021, 'Harlequin', '978-1-9247-926-9', 'Reference', '2025-04-11', 'RES U 546 OU68 2021', 'OU68', '2025000185-00'),
('The Alchemist', 'Paulo Coelho', 2003, 'Grand Central Publishing', '978-1-6075-478-5', 'Reserved', '2025-04-11', 'REF V 273 CV36 2003', 'CV36', '2025000186-00'),
('The Invisible Life of Addie LaRue', 'Andy Weir', 2006, 'Macmillan Publishers', '978-1-5466-207-10', 'Reference', '2025-04-11', 'RES W 779 WW51 2006', 'WW51', '2025000187-00'),
('The Alchemist', 'Paulo Coelho', 2008, 'Bloomsbury Publishing', '978-1-5550-203-1', 'Reserved', '2025-04-11', 'SHS X 683 CX40 2008', 'CX40', '2025000188-00'),
('The Night Circus', 'Stephen King', 1997, 'Penguin Random House', '978-1-5305-606-6', 'SHS', '2025-04-11', 'RES Y 506 KY58 1997', 'KY58', '2025000189-00'),
('The Song of Achilles', 'Alex Michaelides', 2008, 'Grand Central Publishing', '978-1-1382-143-2', 'Reserved', '2025-04-11', 'SHS Z 883 MZ13 2008', 'MZ13', '2025000190-00'),
('The Song of Achilles', 'Alex Michaelides', 2015, 'Scholastic', '978-1-9741-766-4', 'SHS', '2025-04-11', 'REF A 306 MA77 2015', 'MA77', '2025000191-00'),
('Legendborn', 'Madeline Miller', 2022, 'Vintage', '978-1-7224-377-9', 'Reference', '2025-04-11', 'REF B 606 MB46 2022', 'MB46', '2025000192-00'),
('The Midnight Library', 'Tracy Deonn', 1995, 'Harlequin', '978-1-6743-456-1', 'Reference', '2025-04-11', 'RES C 975 DC26 1995', 'DC26', '2025000193-00'),
('The Alchemist', 'Paulo Coelho', 2005, 'Farrar, Straus and Giroux', '978-1-6977-412-3', 'Reserved', '2025-04-11', 'REF D 405 CD19 2005', 'CD19', '2025000194-00'),
('The Silent Patient', 'Matt Haig', 2014, 'Scholastic', '978-1-1768-312-4', 'Reference', '2025-04-11', 'REF E 298 HE75 2014', 'HE75', '2025000195-00'),
('A Man Called Ove', 'Alex Michaelides', 1993, 'G.P. Putnam\'s Sons', '978-1-8375-450-2', 'Reference', '2025-04-11', 'FIL F 779 MF39 1993', 'MF39', '2025000196-00'),
('A Man Called Ove', 'Agatha Christie', 2011, 'Tor Books', '978-1-4231-970-5', 'Filipiniana', '2025-04-11', 'SHS G 196 CG97 2011', 'CG97', '2025000197-00'),
('Daisy Jones & The Six', 'James Clear', 2010, 'Grand Central Publishing', '978-1-2606-741-7', 'SHS', '2025-04-11', 'RES H 780 CH97 2010', 'CH97', '2025000198-00'),
('The Seven Husbands of Evelyn Hugo', 'Madeline Miller', 2014, 'Bloomsbury Publishing', '978-1-7148-440-3', 'Reserved', '2025-04-11', 'FIL I 463 MI61 2014', 'MI61', '2025000199-00'),
('A Man Called Ove', 'Fredrik Backman', 1997, 'Hachette Book Group', '978-1-3428-742-8', 'Filipiniana', '2025-04-11', 'REF J 291 BJ46 1997', 'BJ46', '2025000200-00'),
('Verity', 'Andy Weir', 1981, 'Doubleday', '978-1-8431-619-2', 'Reference', '2025-04-11', 'RES K 909 WK56 1981', 'WK56', '2025000201-00'),
('Educated', 'Andy Weir', 2013, 'Penguin Random House', '978-1-2148-918-7', 'Reserved', '2025-04-11', 'SHS L 463 WL19 2013', 'WL19', '2025000202-00'),
('The Silent Patient', 'Matt Haig', 2007, 'G.P. Putnam\'s Sons', '978-1-2006-898-9', 'SHS', '2025-04-11', 'REF M 812 HM94 2007', 'HM94', '2025000203-00'),
('It Ends With Us', 'Tracy Deonn', 2011, 'Little, Brown and Company', '978-1-6952-530-6', 'Reference', '2025-04-11', 'RES N 999 DN38 2011', 'DN38', '2025000204-00'),
('Educated', 'Delia Owens', 2001, 'Ballantine Books', '978-1-8669-594-1', 'Reserved', '2025-04-11', 'SHS O 425 OO53 2001', 'OO53', '2025000205-00'),
('Daisy Jones & The Six', 'TJ Klune', 1993, 'Hachette Book Group', '978-1-2050-572-6', 'SHS', '2025-04-11', 'FIL P 177 KP43 1993', 'KP43', '2025000206-00'),
('Circe', 'Markus Zusak', 2008, 'Ballantine Books', '978-1-9140-834-8', 'Filipiniana', '2025-04-11', 'RES Q 121 ZQ26 2008', 'ZQ26', '2025000207-00'),
('Daisy Jones & The Six', 'Matt Haig', 1998, 'HarperCollins', '978-1-5392-627-4', 'Reserved', '2025-04-11', 'REF R 926 HR41 1998', 'HR41', '2025000208-00'),
('Verity', 'Andy Weir', 1998, 'Vintage', '978-1-3901-420-1', 'Reference', '2025-04-11', 'RES S 348 WS23 1998', 'WS23', '2025000209-00'),
('Project Hail Mary', 'Michelle Obama', 1986, 'Ballantine Books', '978-1-2202-152-5', 'Reserved', '2025-04-11', 'SHS T 834 OT79 1986', 'OT79', '2025000210-00'),
('The Alchemist', 'Paulo Coelho', 1992, 'Ballantine Books', '978-1-8092-114-8', 'SHS', '2025-04-11', 'REF U 851 CU64 1992', 'CU64', '2025000211-00'),
('The Seven Husbands of Evelyn Hugo', 'Agatha Christie', 2009, 'Scholastic', '978-1-2532-167-4', 'Reference', '2025-04-11', 'FIL V 610 CV79 2009', 'CV79', '2025000212-00'),
('A Man Called Ove', 'Colleen Hoover', 2018, 'Harlequin', '978-1-3786-466-1', 'Filipiniana', '2025-04-11', 'RES W 894 HW79 2018', 'HW79', '2025000213-00'),
('The Book Thief', 'Andy Weir', 1987, 'Macmillan Publishers', '978-1-8900-986-3', 'Reserved', '2025-04-11', 'REF X 772 WX75 1987', 'WX75', '2025000214-00'),
('Becoming', 'Fredrik Backman', 1997, 'Little, Brown and Company', '978-1-6274-811-9', 'Reference', '2025-04-11', 'RES Y 574 BY35 1997', 'BY35', '2025000215-00'),
('Educated', 'Alex Michaelides', 1996, 'Hachette Book Group', '978-1-6672-829-1', 'Reserved', '2025-04-11', 'RES Z 155 MZ76 1996', 'MZ76', '2025000216-00'),
('Daisy Jones & The Six', 'Tara Westover', 2009, 'Bloomsbury Publishing', '978-1-5272-543-1', 'Reserved', '2025-04-11', 'RES A 286 WA82 2009', 'WA82', '2025000217-00'),
('Educated', 'Erin Morgenstern', 1990, 'Grand Central Publishing', '978-1-1736-165-3', 'Reserved', '2025-04-11', 'SHS B 439 MB61 1990', 'MB61', '2025000218-00'),
('Where the Crawdads Sing', 'Colleen Hoover', 1991, 'Scholastic', '978-1-8512-518-8', 'SHS', '2025-04-11', 'FIL C 353 HC29 1991', 'HC29', '2025000219-00'),
('Circe', 'Colleen Hoover', 2016, 'Knopf Publishing Group', '978-1-1315-166-6', 'Filipiniana', '2025-04-11', 'SHS D 758 HD65 2016', 'HD65', '2025000220-00'),
('Legendborn', 'Fredrik Backman', 2022, 'Tor Books', '978-1-5597-567-8', 'SHS', '2025-04-11', 'FIL E 408 BE82 2022', 'BE82', '2025000221-00'),
('It Ends With Us', 'Delia Owens', 2024, 'Penguin Random House', '978-1-3920-288-7', 'Filipiniana', '2025-04-11', 'SHS F 372 OF93 2024', 'OF93', '2025000222-00'),
('The Book Thief', 'Delia Owens', 2019, 'Vintage', '978-1-3802-943-1', 'SHS', '2025-04-11', 'FIL G 708 OG27 2019', 'OG27', '2025000223-00'),
('Becoming', 'Fredrik Backman', 2012, 'Ballantine Books', '978-1-1864-974-2', 'Filipiniana', '2025-04-11', 'RES H 469 BH77 2012', 'BH77', '2025000224-00'),
('Verity', 'Michelle Obama', 1991, 'Crown Publishing', '978-1-5053-221-4', 'Reserved', '2025-04-11', 'FIL I 582 OI56 1991', 'OI56', '2025000225-00'),
('Educated', 'Markus Zusak', 2005, 'Scholastic', '978-1-2030-569-6', 'Filipiniana', '2025-04-11', 'SHS J 560 ZJ73 2005', 'ZJ73', '2025000226-00'),
('The House in the Cerulean Sea', 'Paulo Coelho', 1990, 'Ballantine Books', '978-1-6348-146-4', 'SHS', '2025-04-11', 'RES K 233 CK52 1990', 'CK52', '2025000227-00'),
('The Seven Husbands of Evelyn Hugo', 'Madeline Miller', 1983, 'Knopf Publishing Group', '978-1-6240-269-10', 'Reserved', '2025-04-11', 'REF L 432 ML98 1983', 'ML98', '2025000228-00'),
('Daisy Jones & The Six', 'V.E. Schwab', 1982, 'Farrar, Straus and Giroux', '978-1-2932-266-3', 'Reference', '2025-04-11', 'SHS M 383 SM99 1982', 'SM99', '2025000229-00'),
('It Ends With Us', 'Stephen King', 2007, 'Farrar, Straus and Giroux', '978-1-6889-507-7', 'SHS', '2025-04-11', 'FIL N 582 KN40 2007', 'KN40', '2025000230-00'),
('The Song of Achilles', 'Tara Westover', 1981, 'Macmillan Publishers', '978-1-8865-684-5', 'Filipiniana', '2025-04-11', 'REF O 159 WO52 1981', 'WO52', '2025000231-00'),
('Becoming', 'Taylor Jenkins Reid', 2008, 'Farrar, Straus and Giroux', '978-1-9326-389-1', 'Reference', '2025-04-11', 'RES P 169 RP58 2008', 'RP58', '2025000232-00'),
('Circe', 'Colleen Hoover', 1993, 'St. Martin\'s Press', '978-1-5528-935-1', 'Reserved', '2025-04-11', 'SHS Q 678 HQ56 1993', 'HQ56', '2025000233-00'),
('Circe', 'Madeline Miller', 1996, 'Tor Books', '978-1-3971-452-5', 'SHS', '2025-04-11', 'REF R 711 MR10 1996', 'MR10', '2025000234-00'),
('Verity', 'Taylor Jenkins Reid', 1995, 'Vintage', '978-1-6714-482-10', 'Reference', '2025-04-11', 'REF S 285 RS50 1995', 'RS50', '2025000235-00'),
('Becoming', 'J.K. Rowling', 1990, 'Doubleday', '978-1-8651-641-2', 'Reference', '2025-04-11', 'RES T 636 RT71 1990', 'RT71', '2025000236-00'),
('Becoming', 'Tracy Deonn', 2003, 'Doubleday', '978-1-6510-468-3', 'Reserved', '2025-04-11', 'REF U 123 DU87 2003', 'DU87', '2025000237-00'),
('Verity', 'J.K. Rowling', 1994, 'Tor Books', '978-1-3212-409-1', 'Reference', '2025-04-11', 'FIL V 848 RV41 1994', 'RV41', '2025000238-00'),
('Verity', 'Erin Morgenstern', 2002, 'Bantam Books', '978-1-9260-283-9', 'Filipiniana', '2025-04-11', 'FIL W 917 MW95 2002', 'MW95', '2025000239-00'),
('The Night Circus', 'Tracy Deonn', 1980, 'Doubleday', '978-1-4530-998-3', 'Filipiniana', '2025-04-11', 'FIL X 914 DX53 1980', 'DX53', '2025000240-00'),
('Circe', 'Fredrik Backman', 2002, 'Ballantine Books', '978-1-9413-752-8', 'Filipiniana', '2025-04-11', 'SHS Y 930 BY32 2002', 'BY32', '2025000241-00'),
('Becoming', 'James Clear', 2019, 'Knopf Publishing Group', '978-1-8232-449-7', 'SHS', '2025-04-11', 'FIL Z 213 CZ93 2019', 'CZ93', '2025000242-00'),
('The Alchemist', 'Matt Haig', 1983, 'Bloomsbury Publishing', '978-1-6956-338-2', 'Filipiniana', '2025-04-11', 'FIL A 881 HA54 1983', 'HA54', '2025000243-00'),
('The Song of Achilles', 'Erin Morgenstern', 1988, 'Scholastic', '978-1-3305-250-2', 'Filipiniana', '2025-04-11', 'RES B 348 MB29 1988', 'MB29', '2025000244-00'),
('The Book Thief', 'Stephen King', 1996, 'Scholastic', '978-1-5458-835-1', 'Reserved', '2025-04-11', 'RES C 514 KC98 1996', 'KC98', '2025000245-00'),
('Becoming', 'J.K. Rowling', 1986, 'Scholastic', '978-1-8736-548-10', 'Reserved', '2025-04-11', 'SHS D 961 RD58 1986', 'RD58', '2025000246-00'),
('The Invisible Life of Addie LaRue', 'Fredrik Backman', 2023, 'Harlequin', '978-1-6908-156-4', 'SHS', '2025-04-11', 'FIL E 938 BE65 2023', 'BE65', '2025000247-00'),
('Project Hail Mary', 'Stephen King', 2008, 'Simon & Schuster', '978-1-2413-205-3', 'Filipiniana', '2025-04-11', 'REF F 529 KF41 2008', 'KF41', '2025000248-00'),
('A Man Called Ove', 'Fredrik Backman', 1982, 'Bantam Books', '978-1-1954-616-7', 'Reference', '2025-04-11', 'RES G 635 BG47 1982', 'BG47', '2025000249-00'),
('Verity', 'TJ Klune', 1980, 'Little, Brown and Company', '978-1-2739-594-3', 'Reserved', '2025-04-11', 'SHS H 136 KH49 1980', 'KH49', '2025000250-00'),
('The Seven Husbands of Evelyn Hugo', 'Tara Westover', 2004, 'Bantam Books', '978-1-3660-876-4', 'SHS', '2025-04-11', 'RES I 821 WI90 2004', 'WI90', '2025000251-00'),
('The Alchemist', 'J.K. Rowling', 2011, 'Knopf Publishing Group', '978-1-8147-446-7', 'Reserved', '2025-04-11', 'FIL J 686 RJ50 2011', 'RJ50', '2025000252-00'),
('Project Hail Mary', 'Markus Zusak', 2001, 'St. Martin\'s Press', '978-1-2785-197-10', 'Filipiniana', '2025-04-11', 'FIL K 710 ZK58 2001', 'ZK58', '2025000253-00'),
('Becoming', 'Tara Westover', 1980, 'Doubleday', '978-1-6019-589-8', 'Filipiniana', '2025-04-11', 'REF L 903 WL20 1980', 'WL20', '2025000254-00'),
('The Book Thief', 'Michelle Obama', 1987, 'Bantam Books', '978-1-7950-457-8', 'Reference', '2025-04-11', 'FIL M 172 OM79 1987', 'OM79', '2025000255-00'),
('The House in the Cerulean Sea', 'Stephen King', 2023, 'Scholastic', '978-1-4784-391-7', 'Filipiniana', '2025-04-11', 'FIL N 863 KN85 2023', 'KN85', '2025000256-00'),
('The Midnight Library', 'Erin Morgenstern', 2024, 'Crown Publishing', '978-1-3497-571-10', 'Filipiniana', '2025-04-11', 'RES O 387 MO52 2024', 'MO52', '2025000257-00'),
('The Invisible Life of Addie LaRue', 'Agatha Christie', 2005, 'St. Martin\'s Press', '978-1-4716-857-2', 'Reserved', '2025-04-11', 'SHS P 617 CP31 2005', 'CP31', '2025000258-00'),
('The Alchemist', 'J.K. Rowling', 2013, 'Doubleday', '978-1-8459-160-6', 'SHS', '2025-04-11', 'REF Q 444 RQ13 2013', 'RQ13', '2025000259-00'),
('It Ends With Us', 'Andy Weir', 2004, 'G.P. Putnam\'s Sons', '978-1-5850-287-6', 'Reference', '2025-04-11', 'REF R 558 WR29 2004', 'WR29', '2025000260-00'),
('The House in the Cerulean Sea', 'Andy Weir', 2019, 'G.P. Putnam\'s Sons', '978-1-7910-361-9', 'Reference', '2025-04-11', 'RES S 516 WS62 2019', 'WS62', '2025000261-00'),
('Educated', 'Taylor Jenkins Reid', 1994, 'Macmillan Publishers', '978-1-3485-874-1', 'Reserved', '2025-04-11', 'REF T 617 RT54 1994', 'RT54', '2025000262-00'),
('The Alchemist', 'Agatha Christie', 2023, 'Tor Books', '978-1-7079-390-3', 'Reference', '2025-04-11', 'RES U 865 CU62 2023', 'CU62', '2025000263-00'),
('The Book Thief', 'Delia Owens', 2016, 'Macmillan Publishers', '978-1-4626-141-9', 'Reserved', '2025-04-11', 'REF V 166 OV11 2016', 'OV11', '2025000264-00'),
('The Midnight Library', 'Andy Weir', 2013, 'Tor Books', '978-1-7661-759-7', 'Reference', '2025-04-11', 'FIL W 919 WW31 2013', 'WW31', '2025000265-00'),
('Becoming', 'Tara Westover', 2022, 'Penguin Random House', '978-1-7698-273-1', 'Filipiniana', '2025-04-11', 'SHS X 544 WX58 2022', 'WX58', '2025000266-00'),
('Becoming', 'Andy Weir', 1984, 'Bloomsbury Publishing', '978-1-1265-909-3', 'SHS', '2025-04-11', 'RES Y 312 WY21 1984', 'WY21', '2025000267-00'),
('The House in the Cerulean Sea', 'Delia Owens', 1983, 'Penguin Random House', '978-1-4245-432-4', 'Reserved', '2025-04-11', 'FIL Z 319 OZ92 1983', 'OZ92', '2025000268-00'),
('The Song of Achilles', 'Fredrik Backman', 1991, 'Ballantine Books', '978-1-9290-605-1', 'Filipiniana', '2025-04-11', 'FIL A 258 BA51 1991', 'BA51', '2025000269-00'),
('The House in the Cerulean Sea', 'V.E. Schwab', 2019, 'Macmillan Publishers', '978-1-8481-452-2', 'Filipiniana', '2025-04-11', 'RES B 628 SB94 2019', 'SB94', '2025000270-00'),
('The Seven Husbands of Evelyn Hugo', 'Madeline Miller', 2021, 'Vintage', '978-1-3643-363-10', 'Reserved', '2025-04-11', 'SHS C 867 MC24 2021', 'MC24', '2025000271-00'),
('Legendborn', 'TJ Klune', 2001, 'Bloomsbury Publishing', '978-1-5582-164-9', 'SHS', '2025-04-11', 'FIL D 765 KD76 2001', 'KD76', '2025000272-00'),
('Legendborn', 'Tracy Deonn', 2010, 'HarperCollins', '978-1-7054-560-6', 'Filipiniana', '2025-04-11', 'SHS E 285 DE50 2010', 'DE50', '2025000273-00'),
('The Night Circus', 'V.E. Schwab', 2018, 'G.P. Putnam\'s Sons', '978-1-9995-711-3', 'SHS', '2025-04-11', 'RES F 306 SF66 2018', 'SF66', '2025000274-00'),
('The Night Circus', 'Stephen King', 2001, 'Hachette Book Group', '978-1-3988-697-5', 'Reserved', '2025-04-11', 'FIL G 914 KG41 2001', 'KG41', '2025000275-00'),
('Becoming', 'Madeline Miller', 1984, 'Simon & Schuster', '978-1-4669-550-1', 'Filipiniana', '2025-04-11', 'SHS H 732 MH86 1984', 'MH86', '2025000276-00'),
('The Silent Patient', 'Tara Westover', 1992, 'HarperCollins', '978-1-9488-127-1', 'SHS', '2025-04-11', 'REF I 837 WI84 1992', 'WI84', '2025000277-00'),
('The Invisible Life of Addie LaRue', 'Madeline Miller', 1983, 'Grand Central Publishing', '978-1-9160-882-2', 'Reference', '2025-04-11', 'SHS J 656 MJ22 1983', 'MJ22', '2025000278-00'),
('The Midnight Library', 'Matt Haig', 2021, 'Doubleday', '978-1-4026-763-5', 'SHS', '2025-04-11', 'SHS K 863 HK42 2021', 'HK42', '2025000279-00'),
('Where the Crawdads Sing', 'Matt Haig', 2019, 'Doubleday', '978-1-4643-482-5', 'SHS', '2025-04-11', 'SHS L 136 HL56 2019', 'HL56', '2025000280-00'),
('A Man Called Ove', 'Tracy Deonn', 2019, 'Farrar, Straus and Giroux', '978-1-5721-833-4', 'SHS', '2025-04-11', 'FIL M 636 DM81 2019', 'DM81', '2025000281-00'),
('The Seven Husbands of Evelyn Hugo', 'Paulo Coelho', 2017, 'Farrar, Straus and Giroux', '978-1-8402-197-5', 'Filipiniana', '2025-04-11', 'FIL N 697 CN23 2017', 'CN23', '2025000282-00'),
('Atomic Habits', 'J.K. Rowling', 2019, 'Bloomsbury Publishing', '978-1-8748-331-5', 'Filipiniana', '2025-04-11', 'FIL O 332 RO86 2019', 'RO86', '2025000283-00'),
('Circe', 'Markus Zusak', 1999, 'Little, Brown and Company', '978-1-6823-153-2', 'Filipiniana', '2025-04-11', 'FIL P 366 ZP63 1999', 'ZP63', '2025000284-00'),
('The Invisible Life of Addie LaRue', 'Tracy Deonn', 1984, 'St. Martin\'s Press', '978-1-7257-479-7', 'Filipiniana', '2025-04-11', 'FIL Q 227 DQ85 1984', 'DQ85', '2025000285-00'),
('It Ends With Us', 'Andy Weir', 1988, 'HarperCollins', '978-1-6198-753-4', 'Filipiniana', '2025-04-11', 'RES R 101 WR62 1988', 'WR62', '2025000286-00'),
('Atomic Habits', 'Tracy Deonn', 2000, 'Knopf Publishing Group', '978-1-4148-464-8', 'Reserved', '2025-04-11', 'SHS S 544 DS37 2000', 'DS37', '2025000287-00'),
('Educated', 'Tara Westover', 1999, 'Scholastic', '978-1-8906-198-3', 'SHS', '2025-04-11', 'SHS T 208 WT49 1999', 'WT49', '2025000288-00'),
('Atomic Habits', 'Matt Haig', 2018, 'HarperCollins', '978-1-9636-586-6', 'SHS', '2025-04-11', 'SHS U 397 HU93 2018', 'HU93', '2025000289-00'),
('The Book Thief', 'Tracy Deonn', 2014, 'Crown Publishing', '978-1-9806-859-1', 'SHS', '2025-04-11', 'FIL V 635 DV80 2014', 'DV80', '2025000290-00'),
('It Ends With Us', 'Agatha Christie', 2010, 'Scholastic', '978-1-2314-996-4', 'Filipiniana', '2025-04-11', 'RES W 483 CW33 2010', 'CW33', '2025000291-00'),
('Project Hail Mary', 'Markus Zusak', 1982, 'Scholastic', '978-1-1895-789-4', 'Reserved', '2025-04-11', 'SHS X 970 ZX55 1982', 'ZX55', '2025000292-00'),
('Circe', 'Tara Westover', 2011, 'Little, Brown and Company', '978-1-1003-211-6', 'SHS', '2025-04-11', 'REF Y 996 WY66 2011', 'WY66', '2025000293-00'),
('The Song of Achilles', 'Tracy Deonn', 1993, 'G.P. Putnam\'s Sons', '978-1-7090-841-10', 'Reference', '2025-04-11', 'SHS Z 752 DZ54 1993', 'DZ54', '2025000294-00'),
('The Night Circus', 'Stephen King', 2017, 'G.P. Putnam\'s Sons', '978-1-8491-367-7', 'SHS', '2025-04-11', 'RES A 145 KA79 2017', 'KA79', '2025000295-00'),
('Verity', 'Paulo Coelho', 2004, 'Macmillan Publishers', '978-1-3423-386-5', 'Reserved', '2025-04-11', 'FIL B 767 CB81 2004', 'CB81', '2025000296-00'),
('Daisy Jones & The Six', 'Colleen Hoover', 2010, 'Bantam Books', '978-1-7742-578-9', 'Filipiniana', '2025-04-11', 'REF C 464 HC49 2010', 'HC49', '2025000297-00'),
('The House in the Cerulean Sea', 'V.E. Schwab', 1995, 'HarperCollins', '978-1-9434-773-1', 'Reference', '2025-04-11', 'FIL D 585 SD50 1995', 'SD50', '2025000298-00'),
('Circe', 'Agatha Christie', 2001, 'Grand Central Publishing', '978-1-4982-541-4', 'Filipiniana', '2025-04-11', 'REF E 222 CE74 2001', 'CE74', '2025000299-00'),
('The Seven Husbands of Evelyn Hugo', 'Madeline Miller', 1996, 'Doubleday', '978-1-7077-713-2', 'Reference', '2025-04-11', 'SHS F 692 MF28 1996', 'MF28', '2025000300-00'),
('Atomic Habits', 'James Clear', 1982, 'G.P. Putnam\'s Sons', '978-1-5543-328-4', 'SHS', '2025-04-11', 'REF G 280 CG94 1982', 'CG94', '2025000301-00'),
('The Invisible Life of Addie LaRue', 'James Clear', 2004, 'Grand Central Publishing', '978-1-9252-751-10', 'Reference', '2025-04-11', 'SHS H 652 CH26 2004', 'CH26', '2025000302-00'),
('Legendborn', 'Tracy Deonn', 1997, 'Tor Books', '978-1-5485-867-4', 'SHS', '2025-04-11', 'FIL I 446 DI77 1997', 'DI77', '2025000303-00'),
('The Midnight Library', 'TJ Klune', 1991, 'Bloomsbury Publishing', '978-1-2970-234-8', 'Filipiniana', '2025-04-11', 'REF J 527 KJ16 1991', 'KJ16', '2025000304-00'),
('The Silent Patient', 'Tracy Deonn', 1982, 'Bloomsbury Publishing', '978-1-1067-615-3', 'Reference', '2025-04-11', 'RES K 738 DK22 1982', 'DK22', '2025000305-00'),
('Where the Crawdads Sing', 'Tara Westover', 1980, 'Little, Brown and Company', '978-1-5959-127-4', 'Reserved', '2025-04-11', 'REF L 901 WL49 1980', 'WL49', '2025000306-00'),
('Verity', 'Paulo Coelho', 1995, 'HarperCollins', '978-1-3807-907-9', 'Reference', '2025-04-11', 'FIL M 523 CM43 1995', 'CM43', '2025000307-00'),
('Atomic Habits', 'Andy Weir', 1983, 'Vintage', '978-1-2915-482-1', 'Filipiniana', '2025-04-11', 'REF N 682 WN82 1983', 'WN82', '2025000308-00'),
('The Invisible Life of Addie LaRue', 'Alex Michaelides', 2013, 'Little, Brown and Company', '978-1-2308-868-5', 'Reference', '2025-04-11', 'FIL O 235 MO62 2013', 'MO62', '2025000309-00'),
('Project Hail Mary', 'TJ Klune', 2015, 'Simon & Schuster', '978-1-6688-584-2', 'Filipiniana', '2025-04-11', 'SHS P 513 KP93 2015', 'KP93', '2025000310-00'),
('Circe', 'J.K. Rowling', 1982, 'Little, Brown and Company', '978-1-3716-936-4', 'SHS', '2025-04-11', 'REF Q 883 RQ34 1982', 'RQ34', '2025000311-00'),
('The Seven Husbands of Evelyn Hugo', 'Agatha Christie', 1988, 'St. Martin\'s Press', '978-1-8660-940-8', 'Reference', '2025-04-11', 'RES R 599 CR71 1988', 'CR71', '2025000312-00'),
('A Man Called Ove', 'TJ Klune', 2001, 'Harlequin', '978-1-9165-535-10', 'Reserved', '2025-04-11', 'SHS S 896 KS23 2001', 'KS23', '2025000313-00'),
('It Ends With Us', 'Agatha Christie', 2005, 'Ballantine Books', '978-1-5438-945-4', 'SHS', '2025-04-11', 'RES T 357 CT21 2005', 'CT21', '2025000314-00'),
('The House in the Cerulean Sea', 'Paulo Coelho', 2011, 'Scholastic', '978-1-8211-258-6', 'Reserved', '2025-04-11', 'REF U 631 CU42 2011', 'CU42', '2025000315-00'),
('The Song of Achilles', 'J.K. Rowling', 1984, 'G.P. Putnam\'s Sons', '978-1-8064-809-7', 'Reference', '2025-04-11', 'RES V 970 RV94 1984', 'RV94', '2025000316-00'),
('The Seven Husbands of Evelyn Hugo', 'Paulo Coelho', 2013, 'Little, Brown and Company', '978-1-1966-222-1', 'Reserved', '2025-04-11', 'FIL W 270 CW48 2013', 'CW48', '2025000317-00'),
('The Midnight Library', 'Tara Westover', 2019, 'Macmillan Publishers', '978-1-3282-821-10', 'Filipiniana', '2025-04-11', 'RES X 537 WX90 2019', 'WX90', '2025000318-00'),
('Legendborn', 'Madeline Miller', 2024, 'Penguin Random House', '978-1-8294-801-4', 'Reserved', '2025-04-11', 'SHS Y 649 MY67 2024', 'MY67', '2025000319-00');
INSERT INTO `books` (`Title`, `Author`, `Year`, `Publisher`, `ISBN`, `Section`, `AddedDate`, `CallNumber`, `Rack`, `Accno`) VALUES
('A Man Called Ove', 'J.K. Rowling', 1985, 'Harlequin', '978-1-2990-651-2', 'SHS', '2025-04-11', 'FIL Z 557 RZ55 1985', 'RZ55', '2025000320-00'),
('Project Hail Mary', 'Andy Weir', 1992, 'Scholastic', '978-1-9308-177-1', 'Filipiniana', '2025-04-11', 'RES A 912 WA89 1992', 'WA89', '2025000321-00'),
('Project Hail Mary', 'Erin Morgenstern', 2011, 'Ballantine Books', '978-1-7845-947-2', 'Reserved', '2025-04-11', 'RES B 874 MB22 2011', 'MB22', '2025000322-00'),
('The Book Thief', 'Delia Owens', 2004, 'Simon & Schuster', '978-1-8426-613-8', 'Reserved', '2025-04-11', 'FIL C 365 OC36 2004', 'OC36', '2025000323-00'),
('The Silent Patient', 'Fredrik Backman', 2008, 'Scholastic', '978-1-2750-876-2', 'Filipiniana', '2025-04-11', 'REF D 160 BD31 2008', 'BD31', '2025000324-00'),
('Becoming', 'Stephen King', 1989, 'HarperCollins', '978-1-5529-977-3', 'Reference', '2025-04-11', 'SHS E 411 KE71 1989', 'KE71', '2025000325-00'),
('The Alchemist', 'Colleen Hoover', 1998, 'Harlequin', '978-1-5181-303-7', 'SHS', '2025-04-11', 'RES F 455 HF51 1998', 'HF51', '2025000326-00'),
('The Silent Patient', 'Erin Morgenstern', 2022, 'Macmillan Publishers', '978-1-9559-483-1', 'Reserved', '2025-04-11', 'RES G 717 MG62 2022', 'MG62', '2025000327-00'),
('The Silent Patient', 'Agatha Christie', 2002, 'Vintage', '978-1-1642-825-1', 'Reserved', '2025-04-11', 'RES H 326 CH89 2002', 'CH89', '2025000328-00'),
('Where the Crawdads Sing', 'Stephen King', 1982, 'Knopf Publishing Group', '978-1-8362-442-2', 'Reserved', '2025-04-11', 'RES I 519 KI44 1982', 'KI44', '2025000329-00'),
('The Silent Patient', 'Madeline Miller', 2023, 'Tor Books', '978-1-4397-812-2', 'Reserved', '2025-04-11', 'SHS J 258 MJ20 2023', 'MJ20', '2025000330-00'),
('Educated', 'Fredrik Backman', 2015, 'Simon & Schuster', '978-1-7657-343-4', 'SHS', '2025-04-11', 'FIL K 335 BK76 2015', 'BK76', '2025000331-00'),
('The Alchemist', 'Stephen King', 2019, 'Farrar, Straus and Giroux', '978-1-5747-214-6', 'Filipiniana', '2025-04-11', 'REF L 968 KL51 2019', 'KL51', '2025000332-00'),
('Verity', 'V.E. Schwab', 2006, 'Grand Central Publishing', '978-1-2359-720-9', 'Reference', '2025-04-11', 'REF M 893 SM52 2006', 'SM52', '2025000333-00'),
('The Seven Husbands of Evelyn Hugo', 'James Clear', 1990, 'Vintage', '978-1-5900-434-4', 'Reference', '2025-04-11', 'SHS N 900 CN44 1990', 'CN44', '2025000334-00'),
('A Man Called Ove', 'Michelle Obama', 2010, 'Harlequin', '978-1-4395-833-4', 'SHS', '2025-04-11', 'RES O 387 OO11 2010', 'OO11', '2025000335-00'),
('The Alchemist', 'Stephen King', 2019, 'Scholastic', '978-1-7285-482-8', 'Reserved', '2025-04-11', 'FIL P 825 KP98 2019', 'KP98', '2025000336-00'),
('Becoming', 'Matt Haig', 2016, 'St. Martin\'s Press', '978-1-2715-778-4', 'Filipiniana', '2025-04-11', 'FIL Q 962 HQ84 2016', 'HQ84', '2025000337-00'),
('The Seven Husbands of Evelyn Hugo', 'Tara Westover', 1983, 'Knopf Publishing Group', '978-1-6359-156-6', 'Filipiniana', '2025-04-11', 'SHS R 984 WR44 1983', 'WR44', '2025000338-00'),
('The Midnight Library', 'Paulo Coelho', 2018, 'Simon & Schuster', '978-1-8897-822-5', 'SHS', '2025-04-11', 'FIL S 208 CS48 2018', 'CS48', '2025000339-00'),
('The Alchemist', 'Madeline Miller', 2010, 'Bloomsbury Publishing', '978-1-6357-386-6', 'Filipiniana', '2025-04-11', 'REF T 681 MT30 2010', 'MT30', '2025000340-00'),
('Circe', 'Markus Zusak', 2023, 'HarperCollins', '978-1-3212-646-4', 'Reference', '2025-04-11', 'REF U 775 ZU55 2023', 'ZU55', '2025000341-00'),
('The Midnight Library', 'Madeline Miller', 2010, 'Knopf Publishing Group', '978-1-7390-517-9', 'Reference', '2025-04-11', 'RES V 700 MV90 2010', 'MV90', '2025000342-00'),
('The Alchemist', 'V.E. Schwab', 1999, 'Harlequin', '978-1-7164-921-5', 'Reserved', '2025-04-11', 'RES W 837 SW70 1999', 'SW70', '2025000343-00'),
('Where the Crawdads Sing', 'Taylor Jenkins Reid', 2009, 'Tor Books', '978-1-6330-595-6', 'Reserved', '2025-04-11', 'REF X 896 RX29 2009', 'RX29', '2025000344-00'),
('Where the Crawdads Sing', 'Erin Morgenstern', 2023, 'Grand Central Publishing', '978-1-6570-495-6', 'Reference', '2025-04-11', 'SHS Y 136 MY66 2023', 'MY66', '2025000345-00'),
('A Man Called Ove', 'V.E. Schwab', 2004, 'Ballantine Books', '978-1-7209-956-4', 'SHS', '2025-04-11', 'REF Z 654 SZ56 2004', 'SZ56', '2025000346-00'),
('Becoming', 'Alex Michaelides', 2016, 'Farrar, Straus and Giroux', '978-1-3525-573-1', 'Reference', '2025-04-11', 'SHS A 516 MA65 2016', 'MA65', '2025000347-00'),
('Legendborn', 'Andy Weir', 2023, 'Harlequin', '978-1-6374-187-6', 'SHS', '2025-04-11', 'RES B 568 WB46 2023', 'WB46', '2025000348-00'),
('The Seven Husbands of Evelyn Hugo', 'J.K. Rowling', 1982, 'Scholastic', '978-1-3284-137-3', 'Reserved', '2025-04-11', 'FIL C 555 RC35 1982', 'RC35', '2025000349-00'),
('The Alchemist', 'Colleen Hoover', 1980, 'Farrar, Straus and Giroux', '978-1-2970-369-7', 'Filipiniana', '2025-04-11', 'RES D 418 HD94 1980', 'HD94', '2025000350-00'),
('Becoming', 'Colleen Hoover', 1992, 'Hachette Book Group', '978-1-7786-361-5', 'Reserved', '2025-04-11', 'REF E 648 HE26 1992', 'HE26', '2025000351-00'),
('Legendborn', 'Tara Westover', 2013, 'Penguin Random House', '978-1-5730-222-2', 'Reference', '2025-04-11', 'REF F 874 WF84 2013', 'WF84', '2025000352-00'),
('Project Hail Mary', 'Alex Michaelides', 1990, 'Tor Books', '978-1-6173-677-3', 'Reference', '2025-04-11', 'FIL G 113 MG14 1990', 'MG14', '2025000353-00'),
('Project Hail Mary', 'Alex Michaelides', 1994, 'Simon & Schuster', '978-1-8657-523-8', 'Filipiniana', '2025-04-11', 'REF H 619 MH30 1994', 'MH30', '2025000354-00'),
('Daisy Jones & The Six', 'Colleen Hoover', 1987, 'Scholastic', '978-1-8271-213-3', 'Reference', '2025-04-11', 'REF I 854 HI84 1987', 'HI84', '2025000355-00'),
('Legendborn', 'James Clear', 2006, 'Bloomsbury Publishing', '978-1-1539-493-7', 'Reference', '2025-04-11', 'RES J 373 CJ91 2006', 'CJ91', '2025000356-00'),
('Circe', 'Erin Morgenstern', 2012, 'Grand Central Publishing', '978-1-8308-281-7', 'Reserved', '2025-04-11', 'REF K 740 MK24 2012', 'MK24', '2025000357-00'),
('Atomic Habits', 'Madeline Miller', 1998, 'G.P. Putnam\'s Sons', '978-1-9906-451-10', 'Reference', '2025-04-11', 'REF L 473 ML86 1998', 'ML86', '2025000358-00'),
('The Book Thief', 'Tara Westover', 2013, 'Bantam Books', '978-1-7688-186-6', 'Reference', '2025-04-11', 'REF M 756 WM80 2013', 'WM80', '2025000359-00'),
('Where the Crawdads Sing', 'Stephen King', 2012, 'HarperCollins', '978-1-8077-772-7', 'Reference', '2025-04-11', 'SHS N 580 KN74 2012', 'KN74', '2025000360-00'),
('Educated', 'Agatha Christie', 2007, 'Scholastic', '978-1-3675-475-2', 'SHS', '2025-04-11', 'SHS O 206 CO97 2007', 'CO97', '2025000361-00'),
('A Man Called Ove', 'Erin Morgenstern', 2020, 'Crown Publishing', '978-1-1114-723-2', 'SHS', '2025-04-11', 'SHS P 771 MP58 2020', 'MP58', '2025000362-00'),
('The Song of Achilles', 'Alex Michaelides', 2002, 'HarperCollins', '978-1-9209-252-3', 'SHS', '2025-04-11', 'REF Q 576 MQ28 2002', 'MQ28', '2025000363-00'),
('Where the Crawdads Sing', 'Delia Owens', 1995, 'Simon & Schuster', '978-1-6316-309-7', 'Reference', '2025-04-11', 'RES R 667 OR44 1995', 'OR44', '2025000364-00'),
('The Night Circus', 'Tracy Deonn', 1991, 'Doubleday', '978-1-4652-763-4', 'Reserved', '2025-04-11', 'SHS S 931 DS34 1991', 'DS34', '2025000365-00'),
('Circe', 'Fredrik Backman', 1996, 'Knopf Publishing Group', '978-1-5310-889-8', 'SHS', '2025-04-11', 'SHS T 826 BT87 1996', 'BT87', '2025000366-00'),
('Becoming', 'Madeline Miller', 1998, 'Hachette Book Group', '978-1-8847-739-9', 'SHS', '2025-04-11', 'FIL U 496 MU11 1998', 'MU11', '2025000367-00'),
('Atomic Habits', 'Markus Zusak', 1998, 'Harlequin', '978-1-3309-482-3', 'Filipiniana', '2025-04-11', 'RES V 526 ZV67 1998', 'ZV67', '2025000368-00'),
('The Song of Achilles', 'Agatha Christie', 1986, 'Simon & Schuster', '978-1-9229-442-8', 'Reserved', '2025-04-11', 'RES W 641 CW19 1986', 'CW19', '2025000369-00'),
('Verity', 'J.K. Rowling', 2015, 'St. Martin\'s Press', '978-1-2606-923-7', 'Reserved', '2025-04-11', 'RES X 165 RX20 2015', 'RX20', '2025000370-00'),
('Circe', 'Alex Michaelides', 2002, 'St. Martin\'s Press', '978-1-4383-483-5', 'Reserved', '2025-04-11', 'REF Y 234 MY10 2002', 'MY10', '2025000371-00'),
('Where the Crawdads Sing', 'Alex Michaelides', 2021, 'Farrar, Straus and Giroux', '978-1-9378-610-3', 'Reference', '2025-04-11', 'RES Z 869 MZ54 2021', 'MZ54', '2025000372-00'),
('Where the Crawdads Sing', 'Madeline Miller', 2018, 'Hachette Book Group', '978-1-3030-491-8', 'Reserved', '2025-04-11', 'FIL A 532 MA80 2018', 'MA80', '2025000373-00'),
('Becoming', 'Matt Haig', 2021, 'Tor Books', '978-1-6039-952-1', 'Filipiniana', '2025-04-11', 'REF B 149 HB12 2021', 'HB12', '2025000374-00'),
('The Midnight Library', 'J.K. Rowling', 1987, 'Doubleday', '978-1-3109-617-2', 'Reference', '2025-04-11', 'FIL C 751 RC50 1987', 'RC50', '2025000375-00'),
('The Night Circus', 'TJ Klune', 1990, 'Macmillan Publishers', '978-1-6960-549-7', 'Filipiniana', '2025-04-11', 'REF D 128 KD61 1990', 'KD61', '2025000376-00'),
('It Ends With Us', 'Matt Haig', 2003, 'HarperCollins', '978-1-9609-688-5', 'Reference', '2025-04-11', 'REF E 890 HE98 2003', 'HE98', '2025000377-00'),
('Where the Crawdads Sing', 'Matt Haig', 1992, 'Bantam Books', '978-1-3280-449-1', 'Reference', '2025-04-11', 'REF F 284 HF87 1992', 'HF87', '2025000378-00'),
('It Ends With Us', 'Fredrik Backman', 2001, 'Penguin Random House', '978-1-4896-723-3', 'Reference', '2025-04-11', 'FIL G 812 BG49 2001', 'BG49', '2025000379-00'),
('The Book Thief', 'Fredrik Backman', 1980, 'Macmillan Publishers', '978-1-1511-191-4', 'Filipiniana', '2025-04-11', 'FIL H 373 BH74 1980', 'BH74', '2025000380-00'),
('The Alchemist', 'Madeline Miller', 2000, 'Grand Central Publishing', '978-1-7530-632-4', 'Filipiniana', '2025-04-11', 'RES I 505 MI22 2000', 'MI22', '2025000381-00'),
('Verity', 'Agatha Christie', 1998, 'HarperCollins', '978-1-5697-970-1', 'Reserved', '2025-04-11', 'REF J 657 CJ70 1998', 'CJ70', '2025000382-00'),
('The Alchemist', 'Andy Weir', 1994, 'Crown Publishing', '978-1-2501-811-6', 'Reference', '2025-04-11', 'REF K 319 WK41 1994', 'WK41', '2025000383-00'),
('Circe', 'TJ Klune', 2011, 'Knopf Publishing Group', '978-1-8508-422-8', 'Reference', '2025-04-11', 'REF L 469 KL70 2011', 'KL70', '2025000384-00'),
('Legendborn', 'Andy Weir', 1986, 'Hachette Book Group', '978-1-1631-997-4', 'Reference', '2025-04-11', 'FIL M 890 WM68 1986', 'WM68', '2025000385-00'),
('Circe', 'Erin Morgenstern', 1993, 'Grand Central Publishing', '978-1-3003-137-5', 'Filipiniana', '2025-04-11', 'FIL N 814 MN63 1993', 'MN63', '2025000386-00'),
('Becoming', 'Fredrik Backman', 1987, 'Tor Books', '978-1-7428-298-8', 'Filipiniana', '2025-04-11', 'SHS O 651 BO84 1987', 'BO84', '2025000387-00'),
('The Night Circus', 'Tracy Deonn', 1982, 'Hachette Book Group', '978-1-2195-920-6', 'SHS', '2025-04-11', 'REF P 748 DP74 1982', 'DP74', '2025000388-00'),
('The Book Thief', 'TJ Klune', 1992, 'Hachette Book Group', '978-1-6430-766-5', 'Reference', '2025-04-11', 'REF Q 287 KQ92 1992', 'KQ92', '2025000389-00'),
('The Midnight Library', 'Fredrik Backman', 1996, 'Grand Central Publishing', '978-1-8437-739-4', 'Reference', '2025-04-11', 'REF R 958 BR73 1996', 'BR73', '2025000390-00'),
('Project Hail Mary', 'Delia Owens', 2004, 'Harlequin', '978-1-6568-655-7', 'Reference', '2025-04-11', 'SHS S 700 OS42 2004', 'OS42', '2025000391-00'),
('Circe', 'Paulo Coelho', 1992, 'Vintage', '978-1-6264-948-1', 'SHS', '2025-04-11', 'REF T 212 CT42 1992', 'CT42', '2025000392-00'),
('The Book Thief', 'J.K. Rowling', 2017, 'G.P. Putnam\'s Sons', '978-1-5034-305-8', 'Reference', '2025-04-11', 'RES U 401 RU19 2017', 'RU19', '2025000393-00'),
('Where the Crawdads Sing', 'Tara Westover', 1999, 'Bloomsbury Publishing', '978-1-2485-153-7', 'Reserved', '2025-04-11', 'SHS V 221 WV86 1999', 'WV86', '2025000394-00'),
('Educated', 'Tara Westover', 2004, 'Harlequin', '978-1-3650-407-2', 'SHS', '2025-04-11', 'RES W 915 WW77 2004', 'WW77', '2025000395-00'),
('The Night Circus', 'V.E. Schwab', 1995, 'Doubleday', '978-1-9692-798-8', 'Reserved', '2025-04-11', 'FIL X 611 SX83 1995', 'SX83', '2025000396-00'),
('Becoming', 'Alex Michaelides', 1987, 'Farrar, Straus and Giroux', '978-1-3603-897-8', 'Filipiniana', '2025-04-11', 'RES Y 100 MY77 1987', 'MY77', '2025000397-00'),
('The Silent Patient', 'Alex Michaelides', 2016, 'Crown Publishing', '978-1-9514-591-3', 'Reserved', '2025-04-11', 'SHS Z 474 MZ87 2016', 'MZ87', '2025000398-00'),
('The Silent Patient', 'Erin Morgenstern', 1992, 'Knopf Publishing Group', '978-1-3785-285-7', 'SHS', '2025-04-11', 'REF A 912 MA61 1992', 'MA61', '2025000399-00'),
('The Book Thief', 'Tara Westover', 2024, 'Scholastic', '978-1-7317-621-2', 'Reference', '2025-04-11', 'SHS B 396 WB26 2024', 'WB26', '2025000400-00'),
('The Silent Patient', 'J.K. Rowling', 1995, 'Farrar, Straus and Giroux', '978-1-3559-346-8', 'SHS', '2025-04-11', 'FIL C 250 RC47 1995', 'RC47', '2025000401-00'),
('The Silent Patient', 'Taylor Jenkins Reid', 1985, 'Bantam Books', '978-1-1667-794-8', 'Filipiniana', '2025-04-11', 'REF D 662 RD19 1985', 'RD19', '2025000402-00'),
('The Midnight Library', 'Paulo Coelho', 2010, 'Hachette Book Group', '978-1-6177-600-9', 'Reference', '2025-04-11', 'SHS E 300 CE59 2010', 'CE59', '2025000403-00'),
('Becoming', 'James Clear', 1983, 'Harlequin', '978-1-5495-160-10', 'SHS', '2025-04-11', 'SHS F 966 CF55 1983', 'CF55', '2025000404-00'),
('Atomic Habits', 'Delia Owens', 1999, 'Penguin Random House', '978-1-1763-723-9', 'SHS', '2025-04-11', 'REF G 259 OG72 1999', 'OG72', '2025000405-00'),
('Daisy Jones & The Six', 'Michelle Obama', 2003, 'Penguin Random House', '978-1-4662-799-10', 'Reference', '2025-04-11', 'SHS H 552 OH38 2003', 'OH38', '2025000406-00'),
('The Book Thief', 'V.E. Schwab', 1984, 'Ballantine Books', '978-1-2894-420-4', 'SHS', '2025-04-11', 'RES I 308 SI99 1984', 'SI99', '2025000407-00'),
('The Song of Achilles', 'Fredrik Backman', 2015, 'Simon & Schuster', '978-1-7338-387-7', 'Reserved', '2025-04-11', 'FIL J 281 BJ46 2015', 'BJ46', '2025000408-00'),
('Verity', 'Delia Owens', 2010, 'Macmillan Publishers', '978-1-2570-878-5', 'Filipiniana', '2025-04-11', 'SHS K 921 OK66 2010', 'OK66', '2025000409-00'),
('Circe', 'Agatha Christie', 1990, 'Scholastic', '978-1-7521-615-8', 'SHS', '2025-04-11', 'REF L 911 CL77 1990', 'CL77', '2025000410-00'),
('The Silent Patient', 'Taylor Jenkins Reid', 1983, 'Ballantine Books', '978-1-1011-393-10', 'Reference', '2025-04-11', 'RES M 472 RM32 1983', 'RM32', '2025000411-00'),
('The Midnight Library', 'Markus Zusak', 2018, 'Penguin Random House', '978-1-9326-763-2', 'Reserved', '2025-04-11', 'REF N 843 ZN11 2018', 'ZN11', '2025000412-00'),
('The Song of Achilles', 'Michelle Obama', 2011, 'Penguin Random House', '978-1-7509-810-6', 'Reference', '2025-04-11', 'SHS O 174 OO21 2011', 'OO21', '2025000413-00'),
('It Ends With Us', 'Markus Zusak', 2004, 'Farrar, Straus and Giroux', '978-1-2854-188-5', 'SHS', '2025-04-11', 'FIL P 965 ZP72 2004', 'ZP72', '2025000414-00'),
('Project Hail Mary', 'Madeline Miller', 1989, 'Scholastic', '978-1-5943-745-9', 'Filipiniana', '2025-04-11', 'REF Q 163 MQ59 1989', 'MQ59', '2025000415-00'),
('The Book Thief', 'Erin Morgenstern', 1998, 'Bloomsbury Publishing', '978-1-9696-564-7', 'Reference', '2025-04-11', 'RES R 569 MR27 1998', 'MR27', '2025000416-00'),
('A Man Called Ove', 'Taylor Jenkins Reid', 2010, 'G.P. Putnam\'s Sons', '978-1-7524-255-1', 'Reserved', '2025-04-11', 'SHS S 777 RS36 2010', 'RS36', '2025000417-00'),
('The Song of Achilles', 'Stephen King', 2011, 'Harlequin', '978-1-8492-198-10', 'SHS', '2025-04-11', 'RES T 145 KT45 2011', 'KT45', '2025000418-00'),
('The Night Circus', 'James Clear', 2001, 'Little, Brown and Company', '978-1-3743-243-2', 'Reserved', '2025-04-11', 'FIL U 138 CU78 2001', 'CU78', '2025000419-00'),
('The Book Thief', 'V.E. Schwab', 2024, 'St. Martin\'s Press', '978-1-6402-646-1', 'Filipiniana', '2025-04-11', 'FIL V 682 SV97 2024', 'SV97', '2025000420-00'),
('Becoming', 'TJ Klune', 2017, 'Macmillan Publishers', '978-1-1712-453-6', 'Filipiniana', '2025-04-11', 'RES W 830 KW89 2017', 'KW89', '2025000421-00'),
('Educated', 'Agatha Christie', 2004, 'Vintage', '978-1-1816-537-7', 'Reserved', '2025-04-11', 'RES X 135 CX57 2004', 'CX57', '2025000422-00'),
('Becoming', 'TJ Klune', 2014, 'Grand Central Publishing', '978-1-9184-845-5', 'Reserved', '2025-04-11', 'FIL Y 721 KY44 2014', 'KY44', '2025000423-00'),
('Verity', 'J.K. Rowling', 2024, 'Bloomsbury Publishing', '978-1-1362-795-9', 'Filipiniana', '2025-04-11', 'SHS Z 437 RZ54 2024', 'RZ54', '2025000424-00'),
('Becoming', 'Delia Owens', 2002, 'Little, Brown and Company', '978-1-7442-230-7', 'SHS', '2025-04-11', 'FIL A 933 OA68 2002', 'OA68', '2025000425-00'),
('Project Hail Mary', 'Taylor Jenkins Reid', 1989, 'Farrar, Straus and Giroux', '978-1-8376-490-2', 'Filipiniana', '2025-04-11', 'RES B 409 RB45 1989', 'RB45', '2025000426-00'),
('The Book Thief', 'Tara Westover', 1991, 'Knopf Publishing Group', '978-1-5488-389-7', 'Reserved', '2025-04-11', 'FIL C 967 WC64 1991', 'WC64', '2025000427-00'),
('The Song of Achilles', 'Tara Westover', 2000, 'Vintage', '978-1-4761-673-2', 'Filipiniana', '2025-04-11', 'REF D 178 WD18 2000', 'WD18', '2025000428-00'),
('Educated', 'V.E. Schwab', 1998, 'Scholastic', '978-1-9942-598-4', 'Reference', '2025-04-11', 'SHS E 162 SE75 1998', 'SE75', '2025000429-00'),
('The Silent Patient', 'Michelle Obama', 1997, 'Macmillan Publishers', '978-1-5321-510-10', 'SHS', '2025-04-11', 'FIL F 328 OF76 1997', 'OF76', '2025000430-00'),
('Legendborn', 'Fredrik Backman', 1981, 'Hachette Book Group', '978-1-3568-756-10', 'Filipiniana', '2025-04-11', 'REF G 759 BG90 1981', 'BG90', '2025000431-00'),
('Becoming', 'Markus Zusak', 2007, 'Harlequin', '978-1-9522-138-7', 'Reference', '2025-04-11', 'REF H 665 ZH82 2007', 'ZH82', '2025000432-00'),
('The Midnight Library', 'Stephen King', 2020, 'Harlequin', '978-1-7449-130-7', 'Reference', '2025-04-11', 'FIL I 962 KI91 2020', 'KI91', '2025000433-00'),
('The Song of Achilles', 'Paulo Coelho', 1999, 'Bloomsbury Publishing', '978-1-3849-910-2', 'Filipiniana', '2025-04-11', 'RES J 470 CJ33 1999', 'CJ33', '2025000434-00'),
('Daisy Jones & The Six', 'TJ Klune', 2015, 'Hachette Book Group', '978-1-8784-295-6', 'Reserved', '2025-04-11', 'REF K 849 KK31 2015', 'KK31', '2025000435-00'),
('The Song of Achilles', 'Alex Michaelides', 1995, 'Doubleday', '978-1-4110-217-2', 'Reference', '2025-04-11', 'SHS L 631 ML74 1995', 'ML74', '2025000436-00'),
('Atomic Habits', 'Delia Owens', 2007, 'Bloomsbury Publishing', '978-1-7281-237-10', 'SHS', '2025-04-11', 'FIL M 743 OM55 2007', 'OM55', '2025000437-00'),
('Legendborn', 'Delia Owens', 1993, 'Little, Brown and Company', '978-1-4484-227-3', 'Filipiniana', '2025-04-11', 'REF N 681 ON12 1993', 'ON12', '2025000438-00'),
('The Midnight Library', 'Andy Weir', 1992, 'Bloomsbury Publishing', '978-1-9069-421-8', 'Reference', '2025-04-11', 'REF O 525 WO67 1992', 'WO67', '2025000439-00'),
('The Seven Husbands of Evelyn Hugo', 'Tara Westover', 2011, 'Hachette Book Group', '978-1-4862-922-4', 'Reference', '2025-04-11', 'REF P 934 WP47 2011', 'WP47', '2025000440-00'),
('Daisy Jones & The Six', 'Delia Owens', 2008, 'Harlequin', '978-1-5786-580-9', 'Reference', '2025-04-11', 'FIL Q 961 OQ10 2008', 'OQ10', '2025000441-00'),
('The Silent Patient', 'J.K. Rowling', 2001, 'Little, Brown and Company', '978-1-9724-704-7', 'Filipiniana', '2025-04-11', 'RES R 917 RR67 2001', 'RR67', '2025000442-00'),
('A Man Called Ove', 'Alex Michaelides', 1980, 'Vintage', '978-1-4908-185-6', 'Reserved', '2025-04-11', 'REF S 355 MS63 1980', 'MS63', '2025000443-00'),
('Educated', 'V.E. Schwab', 1992, 'Knopf Publishing Group', '978-1-6149-714-1', 'Reference', '2025-04-11', 'FIL T 619 ST49 1992', 'ST49', '2025000444-00'),
('The House in the Cerulean Sea', 'Tracy Deonn', 2004, 'Doubleday', '978-1-6461-216-9', 'Filipiniana', '2025-04-11', 'RES U 852 DU64 2004', 'DU64', '2025000445-00'),
('Becoming', 'Erin Morgenstern', 2003, 'Simon & Schuster', '978-1-7044-488-7', 'Reserved', '2025-04-11', 'FIL V 559 MV37 2003', 'MV37', '2025000446-00'),
('The Book Thief', 'Delia Owens', 1999, 'Crown Publishing', '978-1-8202-710-6', 'Filipiniana', '2025-04-11', 'REF W 762 OW36 1999', 'OW36', '2025000447-00'),
('The Night Circus', 'Madeline Miller', 2013, 'Macmillan Publishers', '978-1-9767-726-6', 'Reference', '2025-04-11', 'SHS X 502 MX75 2013', 'MX75', '2025000448-00'),
('It Ends With Us', 'TJ Klune', 2006, 'Bloomsbury Publishing', '978-1-7723-600-6', 'SHS', '2025-04-11', 'SHS Y 818 KY83 2006', 'KY83', '2025000449-00'),
('The Midnight Library', 'TJ Klune', 1998, 'Ballantine Books', '978-1-5655-988-8', 'SHS', '2025-04-11', 'SHS Z 215 KZ37 1998', 'KZ37', '2025000450-00'),
('It Ends With Us', 'Michelle Obama', 2015, 'St. Martin\'s Press', '978-1-3957-315-5', 'SHS', '2025-04-11', 'REF A 521 OA82 2015', 'OA82', '2025000451-00'),
('The Night Circus', 'Fredrik Backman', 2023, 'Ballantine Books', '978-1-6485-216-8', 'Reference', '2025-04-11', 'FIL B 592 BB49 2023', 'BB49', '2025000452-00'),
('Daisy Jones & The Six', 'Tara Westover', 1993, 'Harlequin', '978-1-6548-243-7', 'Filipiniana', '2025-04-11', 'SHS C 855 WC44 1993', 'WC44', '2025000453-00'),
('Project Hail Mary', 'Alex Michaelides', 1980, 'Macmillan Publishers', '978-1-2098-561-8', 'SHS', '2025-04-11', 'FIL D 511 MD22 1980', 'MD22', '2025000454-00'),
('A Man Called Ove', 'Delia Owens', 1993, 'Macmillan Publishers', '978-1-6825-467-7', 'Filipiniana', '2025-04-11', 'RES E 577 OE80 1993', 'OE80', '2025000455-00'),
('Where the Crawdads Sing', 'James Clear', 2014, 'Grand Central Publishing', '978-1-6086-280-4', 'Reserved', '2025-04-11', 'REF F 806 CF68 2014', 'CF68', '2025000456-00'),
('The Midnight Library', 'James Clear', 1990, 'Hachette Book Group', '978-1-2894-415-5', 'Reference', '2025-04-11', 'SHS G 452 CG94 1990', 'CG94', '2025000457-00'),
('Daisy Jones & The Six', 'Alex Michaelides', 1993, 'Grand Central Publishing', '978-1-8706-423-10', 'SHS', '2025-04-11', 'RES H 117 MH81 1993', 'MH81', '2025000458-00'),
('The Invisible Life of Addie LaRue', 'Erin Morgenstern', 2000, 'Crown Publishing', '978-1-1325-501-4', 'Reserved', '2025-04-11', 'FIL I 708 MI98 2000', 'MI98', '2025000459-00'),
('Becoming', 'Andy Weir', 2002, 'Knopf Publishing Group', '978-1-5119-920-3', 'Filipiniana', '2025-04-11', 'SHS J 639 WJ60 2002', 'WJ60', '2025000460-00'),
('Becoming', 'Alex Michaelides', 2002, 'Macmillan Publishers', '978-1-7562-903-6', 'SHS', '2025-04-11', 'REF K 188 MK38 2002', 'MK38', '2025000461-00'),
('Atomic Habits', 'Michelle Obama', 2016, 'Tor Books', '978-1-7995-186-9', 'Reference', '2025-04-11', 'FIL L 199 OL79 2016', 'OL79', '2025000462-00'),
('Daisy Jones & The Six', 'TJ Klune', 2016, 'Scholastic', '978-1-2649-179-10', 'Filipiniana', '2025-04-11', 'RES M 712 KM41 2016', 'KM41', '2025000463-00'),
('Legendborn', 'Delia Owens', 2024, 'Ballantine Books', '978-1-7708-934-10', 'Reserved', '2025-04-11', 'SHS N 756 ON17 2024', 'ON17', '2025000464-00'),
('Becoming', 'Tara Westover', 2005, 'Bantam Books', '978-1-1839-318-5', 'SHS', '2025-04-11', 'SHS O 131 WO24 2005', 'WO24', '2025000465-00'),
('Becoming', 'Fredrik Backman', 1992, 'Macmillan Publishers', '978-1-2260-664-9', 'SHS', '2025-04-11', 'SHS P 785 BP84 1992', 'BP84', '2025000466-00'),
('The Invisible Life of Addie LaRue', 'James Clear', 2008, 'Knopf Publishing Group', '978-1-7299-560-7', 'SHS', '2025-04-11', 'SHS Q 739 CQ24 2008', 'CQ24', '2025000467-00'),
('The Midnight Library', 'Erin Morgenstern', 2001, 'Simon & Schuster', '978-1-8550-664-4', 'SHS', '2025-04-11', 'RES R 270 MR61 2001', 'MR61', '2025000468-00'),
('Daisy Jones & The Six', 'Matt Haig', 1996, 'Farrar, Straus and Giroux', '978-1-4911-905-2', 'Reserved', '2025-04-11', 'FIL S 689 HS49 1996', 'HS49', '2025000469-00'),
('The House in the Cerulean Sea', 'Andy Weir', 2004, 'Harlequin', '978-1-6968-761-2', 'Filipiniana', '2025-04-11', 'RES T 567 WT94 2004', 'WT94', '2025000470-00'),
('The Night Circus', 'Markus Zusak', 1991, 'Knopf Publishing Group', '978-1-4137-363-4', 'Reserved', '2025-04-11', 'RES U 306 ZU66 1991', 'ZU66', '2025000471-00'),
('It Ends With Us', 'Agatha Christie', 2019, 'Ballantine Books', '978-1-7826-932-9', 'Reserved', '2025-04-11', 'RES V 355 CV74 2019', 'CV74', '2025000472-00'),
('The House in the Cerulean Sea', 'J.K. Rowling', 2012, 'Scholastic', '978-1-4711-587-8', 'Reserved', '2025-04-11', 'FIL W 888 RW56 2012', 'RW56', '2025000473-00'),
('The Night Circus', 'Matt Haig', 2007, 'Macmillan Publishers', '978-1-9864-608-4', 'Filipiniana', '2025-04-11', 'SHS X 579 HX64 2007', 'HX64', '2025000474-00'),
('It Ends With Us', 'Tracy Deonn', 2007, 'Crown Publishing', '978-1-6831-762-10', 'SHS', '2025-04-11', 'FIL Y 958 DY59 2007', 'DY59', '2025000475-00'),
('The Seven Husbands of Evelyn Hugo', 'Taylor Jenkins Reid', 2010, 'Knopf Publishing Group', '978-1-6720-977-9', 'Filipiniana', '2025-04-11', 'FIL Z 264 RZ47 2010', 'RZ47', '2025000476-00'),
('The Silent Patient', 'Stephen King', 2003, 'Macmillan Publishers', '978-1-7361-306-3', 'Filipiniana', '2025-04-11', 'REF A 936 KA55 2003', 'KA55', '2025000477-00'),
('Circe', 'V.E. Schwab', 1996, 'Crown Publishing', '978-1-3311-623-2', 'Reference', '2025-04-11', 'SHS B 500 SB18 1996', 'SB18', '2025000478-00'),
('Daisy Jones & The Six', 'Tara Westover', 2003, 'HarperCollins', '978-1-1755-132-4', 'SHS', '2025-04-11', 'FIL C 603 WC49 2003', 'WC49', '2025000479-00'),
('The Silent Patient', 'Michelle Obama', 1995, 'Farrar, Straus and Giroux', '978-1-1752-450-2', 'Filipiniana', '2025-04-11', 'RES D 384 OD53 1995', 'OD53', '2025000480-00'),
('Verity', 'Tara Westover', 2023, 'HarperCollins', '978-1-9186-340-9', 'Reserved', '2025-04-11', 'SHS E 629 WE14 2023', 'WE14', '2025000481-00'),
('Legendborn', 'Delia Owens', 2006, 'Hachette Book Group', '978-1-2064-121-3', 'SHS', '2025-04-11', 'RES F 444 OF55 2006', 'OF55', '2025000482-00'),
('Educated', 'Tracy Deonn', 2003, 'Simon & Schuster', '978-1-9828-590-2', 'Reserved', '2025-04-11', 'FIL G 392 DG69 2003', 'DG69', '2025000483-00'),
('A Man Called Ove', 'Tara Westover', 2015, 'Bantam Books', '978-1-4913-368-6', 'Filipiniana', '2025-04-11', 'SHS H 257 WH67 2015', 'WH67', '2025000484-00'),
('The Night Circus', 'Fredrik Backman', 1998, 'Macmillan Publishers', '978-1-4703-946-7', 'SHS', '2025-04-11', 'FIL I 555 BI40 1998', 'BI40', '2025000485-00'),
('Atomic Habits', 'Fredrik Backman', 2014, 'Crown Publishing', '978-1-3709-611-3', 'Filipiniana', '2025-04-11', 'FIL J 217 BJ12 2014', 'BJ12', '2025000486-00'),
('Daisy Jones & The Six', 'Delia Owens', 1993, 'Bloomsbury Publishing', '978-1-1044-147-7', 'Filipiniana', '2025-04-11', 'RES K 884 OK55 1993', 'OK55', '2025000487-00'),
('The Song of Achilles', 'Madeline Miller', 2004, 'St. Martin\'s Press', '978-1-5731-891-10', 'Reserved', '2025-04-11', 'SHS L 585 ML64 2004', 'ML64', '2025000488-00'),
('Becoming', 'Matt Haig', 1998, 'Harlequin', '978-1-7100-587-7', 'SHS', '2025-04-11', 'FIL M 127 HM67 1998', 'HM67', '2025000489-00'),
('Circe', 'J.K. Rowling', 1995, 'Doubleday', '978-1-8423-967-5', 'Filipiniana', '2025-04-11', 'FIL N 621 RN80 1995', 'RN80', '2025000490-00'),
('The Invisible Life of Addie LaRue', 'Matt Haig', 1997, 'Tor Books', '978-1-5571-761-2', 'Filipiniana', '2025-04-11', 'REF O 755 HO97 1997', 'HO97', '2025000491-00'),
('The Alchemist', 'Tracy Deonn', 2002, 'G.P. Putnam\'s Sons', '978-1-6668-121-7', 'Reference', '2025-04-11', 'SHS P 893 DP10 2002', 'DP10', '2025000492-00'),
('Daisy Jones & The Six', 'Stephen King', 2016, 'Crown Publishing', '978-1-7164-805-9', 'SHS', '2025-04-11', 'SHS Q 667 KQ99 2016', 'KQ99', '2025000493-00'),
('Daisy Jones & The Six', 'Erin Morgenstern', 2009, 'Scholastic', '978-1-5166-703-6', 'SHS', '2025-04-11', 'REF R 626 MR10 2009', 'MR10', '2025000494-00'),
('Verity', 'Markus Zusak', 2007, 'Vintage', '978-1-7184-504-8', 'Reference', '2025-04-11', 'REF S 665 ZS82 2007', 'ZS82', '2025000495-00'),
('The Silent Patient', 'V.E. Schwab', 1998, 'Vintage', '978-1-5641-920-8', 'Reference', '2025-04-11', 'RES T 465 ST75 1998', 'ST75', '2025000496-00'),
('Daisy Jones & The Six', 'Delia Owens', 2011, 'Farrar, Straus and Giroux', '978-1-1661-530-4', 'Reserved', '2025-04-11', 'RES U 771 OU93 2011', 'OU93', '2025000497-00'),
('The Midnight Library', 'Fredrik Backman', 2019, 'Grand Central Publishing', '978-1-2079-809-10', 'Reserved', '2025-04-11', 'SHS V 810 BV78 2019', 'BV78', '2025000498-00'),
('A Man Called Ove', 'Stephen King', 2004, 'Grand Central Publishing', '978-1-9853-936-10', 'SHS', '2025-04-11', 'RES W 474 KW56 2004', 'KW56', '2025000499-00'),
('The Invisible Life of Addie LaRue', 'TJ Klune', 2012, 'Little, Brown and Company', '978-1-7921-102-10', 'Reserved', '2025-04-11', 'SHS X 321 KX20 2012', 'KX20', '2025000500-00'),
('Verity', 'J.K. Rowling', 2013, 'Doubleday', '978-1-6778-927-3', 'SHS', '2025-04-11', 'REF Y 283 RY11 2013', 'RY11', '2025000501-00'),
('Becoming', 'Stephen King', 1984, 'Macmillan Publishers', '978-1-2410-363-5', 'Reference', '2025-04-11', 'REF Z 925 KZ82 1984', 'KZ82', '2025000502-00'),
('The Book Thief', 'Agatha Christie', 1998, 'Simon & Schuster', '978-1-7793-756-5', 'Reference', '2025-04-11', 'SHS A 614 CA80 1998', 'CA80', '2025000503-00'),
('Daisy Jones & The Six', 'Fredrik Backman', 2022, 'Vintage', '978-1-7332-568-3', 'SHS', '2025-04-11', 'RES B 967 BB55 2022', 'BB55', '2025000504-00'),
('Educated', 'Fredrik Backman', 2001, 'Scholastic', '978-1-5714-242-4', 'Reserved', '2025-04-11', 'RES C 848 BC45 2001', 'BC45', '2025000505-00'),
('Daisy Jones & The Six', 'V.E. Schwab', 2020, 'Doubleday', '978-1-2501-607-10', 'Reserved', '2025-04-11', 'SHS D 561 SD65 2020', 'SD65', '2025000506-00'),
('The Alchemist', 'Andy Weir', 2018, 'Harlequin', '978-1-1593-737-7', 'SHS', '2025-04-11', 'FIL E 886 WE84 2018', 'WE84', '2025000507-00'),
('Educated', 'Matt Haig', 1987, 'Scholastic', '978-1-5481-800-8', 'Filipiniana', '2025-04-11', 'RES F 573 HF53 1987', 'HF53', '2025000508-00'),
('The Seven Husbands of Evelyn Hugo', 'Michelle Obama', 1986, 'Hachette Book Group', '978-1-6565-192-3', 'Reserved', '2025-04-11', 'FIL G 763 OG95 1986', 'OG95', '2025000509-00'),
('Educated', 'Colleen Hoover', 1988, 'Tor Books', '978-1-8630-401-8', 'Filipiniana', '2025-04-11', 'SHS H 546 HH52 1988', 'HH52', '2025000510-00'),
('The Book Thief', 'Delia Owens', 2017, 'Tor Books', '978-1-2869-667-9', 'SHS', '2025-04-11', 'SHS I 569 OI68 2017', 'OI68', '2025000511-00'),
('The Invisible Life of Addie LaRue', 'Tracy Deonn', 2011, 'Crown Publishing', '978-1-8860-939-5', 'SHS', '2025-04-11', 'SHS J 297 DJ59 2011', 'DJ59', '2025000512-00'),
('The Song of Achilles', 'J.K. Rowling', 2022, 'Penguin Random House', '978-1-9581-574-7', 'SHS', '2025-04-11', 'RES K 781 RK53 2022', 'RK53', '2025000513-00'),
('It Ends With Us', 'Fredrik Backman', 2009, 'Bloomsbury Publishing', '978-1-8196-858-7', 'Reserved', '2025-04-11', 'RES L 569 BL67 2009', 'BL67', '2025000514-00'),
('The House in the Cerulean Sea', 'J.K. Rowling', 2003, 'Hachette Book Group', '978-1-5224-411-10', 'Reserved', '2025-04-11', 'SHS M 921 RM31 2003', 'RM31', '2025000515-00'),
('Daisy Jones & The Six', 'Alex Michaelides', 1998, 'St. Martin\'s Press', '978-1-8500-774-1', 'SHS', '2025-04-11', 'RES N 291 MN91 1998', 'MN91', '2025000516-00'),
('The Seven Husbands of Evelyn Hugo', 'Delia Owens', 2004, 'St. Martin\'s Press', '978-1-1260-345-3', 'Reserved', '2025-04-11', 'REF O 323 OO67 2004', 'OO67', '2025000517-00'),
('Where the Crawdads Sing', 'Markus Zusak', 2009, 'Grand Central Publishing', '978-1-2762-849-3', 'Reference', '2025-04-11', 'SHS P 534 ZP22 2009', 'ZP22', '2025000518-00'),
('The Seven Husbands of Evelyn Hugo', 'Erin Morgenstern', 1982, 'Knopf Publishing Group', '978-1-6647-461-5', 'SHS', '2025-04-11', 'RES Q 700 MQ89 1982', 'MQ89', '2025000519-00'),
('Atomic Habits', 'Alex Michaelides', 2020, 'Scholastic', '978-1-4266-897-5', 'Reserved', '2025-04-11', 'RES R 259 MR48 2020', 'MR48', '2025000520-00'),
('The Alchemist', 'Markus Zusak', 1993, 'Hachette Book Group', '978-1-6029-275-5', 'Reserved', '2025-04-11', 'SHS S 722 ZS67 1993', 'ZS67', '2025000521-00'),
('The Seven Husbands of Evelyn Hugo', 'Taylor Jenkins Reid', 1990, 'St. Martin\'s Press', '978-1-9304-637-1', 'SHS', '2025-04-11', 'SHS T 612 RT13 1990', 'RT13', '2025000522-00'),
('The Song of Achilles', 'Stephen King', 2020, 'Hachette Book Group', '978-1-5889-572-5', 'SHS', '2025-04-11', 'SHS U 981 KU34 2020', 'KU34', '2025000523-00'),
('The Night Circus', 'Alex Michaelides', 1980, 'Harlequin', '978-1-1419-586-6', 'SHS', '2025-04-11', 'REF V 758 MV24 1980', 'MV24', '2025000524-00'),
('The Night Circus', 'TJ Klune', 1981, 'Crown Publishing', '978-1-9601-666-7', 'Reference', '2025-04-11', 'FIL W 705 KW33 1981', 'KW33', '2025000525-00'),
('Becoming', 'Colleen Hoover', 2010, 'Macmillan Publishers', '978-1-2923-679-2', 'Filipiniana', '2025-04-11', 'REF X 562 HX87 2010', 'HX87', '2025000526-00'),
('Daisy Jones & The Six', 'Markus Zusak', 2024, 'Farrar, Straus and Giroux', '978-1-4685-208-9', 'Reference', '2025-04-11', 'SHS Y 313 ZY69 2024', 'ZY69', '2025000527-00'),
('Where the Crawdads Sing', 'V.E. Schwab', 1986, 'St. Martin\'s Press', '978-1-6307-370-8', 'SHS', '2025-04-11', 'SHS Z 129 SZ39 1986', 'SZ39', '2025000528-00'),
('The House in the Cerulean Sea', 'Madeline Miller', 1984, 'Scholastic', '978-1-9653-585-2', 'SHS', '2025-04-11', 'RES A 980 MA28 1984', 'MA28', '2025000529-00'),
('The Invisible Life of Addie LaRue', 'Stephen King', 1989, 'HarperCollins', '978-1-5000-896-5', 'Reserved', '2025-04-11', 'SHS B 953 KB10 1989', 'KB10', '2025000530-00'),
('Project Hail Mary', 'Matt Haig', 2020, 'G.P. Putnam\'s Sons', '978-1-3335-407-8', 'SHS', '2025-04-11', 'REF C 679 HC14 2020', 'HC14', '2025000531-00'),
('Verity', 'V.E. Schwab', 2003, 'G.P. Putnam\'s Sons', '978-1-2417-376-3', 'Reference', '2025-04-11', 'SHS D 332 SD27 2003', 'SD27', '2025000532-00'),
('The Seven Husbands of Evelyn Hugo', 'Matt Haig', 2021, 'Bloomsbury Publishing', '978-1-4536-805-5', 'SHS', '2025-04-11', 'FIL E 125 HE47 2021', 'HE47', '2025000533-00'),
('The Night Circus', 'Erin Morgenstern', 1982, 'Simon & Schuster', '978-1-1673-437-3', 'Filipiniana', '2025-04-11', 'REF F 100 MF42 1982', 'MF42', '2025000534-00'),
('The Silent Patient', 'Erin Morgenstern', 1997, 'Penguin Random House', '978-1-6101-742-9', 'Reference', '2025-04-11', 'REF G 274 MG75 1997', 'MG75', '2025000535-00'),
('The Song of Achilles', 'Delia Owens', 2013, 'G.P. Putnam\'s Sons', '978-1-8930-954-2', 'Reference', '2025-04-11', 'RES H 810 OH57 2013', 'OH57', '2025000536-00'),
('Atomic Habits', 'Stephen King', 2018, 'St. Martin\'s Press', '978-1-7459-737-6', 'Reserved', '2025-04-11', 'FIL I 434 KI92 2018', 'KI92', '2025000537-00'),
('Legendborn', 'Fredrik Backman', 2019, 'HarperCollins', '978-1-4459-137-10', 'Filipiniana', '2025-04-11', 'SHS J 898 BJ90 2019', 'BJ90', '2025000538-00'),
('The Seven Husbands of Evelyn Hugo', 'Tara Westover', 2021, 'Doubleday', '978-1-5609-967-6', 'SHS', '2025-04-11', 'RES K 386 WK93 2021', 'WK93', '2025000539-00'),
('The Night Circus', 'Alex Michaelides', 1985, 'Penguin Random House', '978-1-4940-554-6', 'Reserved', '2025-04-11', 'REF L 370 ML34 1985', 'ML34', '2025000540-00'),
('The Book Thief', 'Agatha Christie', 1987, 'Penguin Random House', '978-1-1715-315-4', 'Reference', '2025-04-11', 'SHS M 467 CM41 1987', 'CM41', '2025000541-00'),
('The Invisible Life of Addie LaRue', 'Michelle Obama', 2011, 'St. Martin\'s Press', '978-1-1862-779-5', 'SHS', '2025-04-11', 'REF N 865 ON52 2011', 'ON52', '2025000542-00'),
('Where the Crawdads Sing', 'J.K. Rowling', 1990, 'Crown Publishing', '978-1-4105-116-4', 'Reference', '2025-04-11', 'REF O 875 RO26 1990', 'RO26', '2025000543-00'),
('The Alchemist', 'Michelle Obama', 2002, 'Doubleday', '978-1-2857-640-1', 'Reference', '2025-04-11', 'SHS P 705 OP19 2002', 'OP19', '2025000544-00'),
('Legendborn', 'Stephen King', 1999, 'Harlequin', '978-1-6704-535-3', 'SHS', '2025-04-11', 'FIL Q 806 KQ12 1999', 'KQ12', '2025000545-00'),
('The Alchemist', 'Delia Owens', 1984, 'G.P. Putnam\'s Sons', '978-1-6247-240-7', 'Filipiniana', '2025-04-11', 'FIL R 122 OR78 1984', 'OR78', '2025000546-00'),
('It Ends With Us', 'Paulo Coelho', 1993, 'Bantam Books', '978-1-5177-531-7', 'Filipiniana', '2025-04-11', 'REF S 937 CS45 1993', 'CS45', '2025000547-00'),
('The Midnight Library', 'Paulo Coelho', 2003, 'HarperCollins', '978-1-6592-847-8', 'Reference', '2025-04-11', 'FIL T 389 CT27 2003', 'CT27', '2025000548-00'),
('Where the Crawdads Sing', 'Taylor Jenkins Reid', 2003, 'Knopf Publishing Group', '978-1-3250-414-1', 'Filipiniana', '2025-04-11', 'SHS U 674 RU84 2003', 'RU84', '2025000549-00'),
('Atomic Habits', 'V.E. Schwab', 1995, 'Penguin Random House', '978-1-9668-306-6', 'SHS', '2025-04-11', 'RES V 631 SV66 1995', 'SV66', '2025000550-00'),
('The Midnight Library', 'Paulo Coelho', 2001, 'Ballantine Books', '978-1-2968-648-6', 'Reserved', '2025-04-11', 'SHS W 463 CW52 2001', 'CW52', '2025000551-00'),
('Becoming', 'Tara Westover', 1998, 'Grand Central Publishing', '978-1-7878-517-2', 'SHS', '2025-04-11', 'SHS X 743 WX13 1998', 'WX13', '2025000552-00'),
('The Alchemist', 'James Clear', 1981, 'Harlequin', '978-1-9429-958-2', 'SHS', '2025-04-11', 'REF Y 636 CY30 1981', 'CY30', '2025000553-00'),
('The Silent Patient', 'Stephen King', 1982, 'HarperCollins', '978-1-6572-147-5', 'Reference', '2025-04-11', 'FIL Z 659 KZ67 1982', 'KZ67', '2025000554-00'),
('Project Hail Mary', 'Paulo Coelho', 1993, 'Tor Books', '978-1-8827-330-5', 'Filipiniana', '2025-04-11', 'SHS A 527 CA62 1993', 'CA62', '2025000555-00'),
('Educated', 'Taylor Jenkins Reid', 1991, 'Doubleday', '978-1-2108-207-8', 'SHS', '2025-04-11', 'SHS B 404 RB42 1991', 'RB42', '2025000556-00'),
('It Ends With Us', 'Markus Zusak', 1998, 'Simon & Schuster', '978-1-8126-758-9', 'SHS', '2025-04-11', 'RES C 693 ZC23 1998', 'ZC23', '2025000557-00'),
('The Silent Patient', 'Andy Weir', 1999, 'Little, Brown and Company', '978-1-7231-500-7', 'Reserved', '2025-04-11', 'RES D 997 WD76 1999', 'WD76', '2025000558-00'),
('Ibong Adarna', 'Jose Dela Cruz', 1944, 'Phoenix Publishing House', '978-9-7150-856-6', 'Reserved', '2025-04-11', 'FIL P 914 CP44 1944', 'CP44', '2025000559-00'),
('Florante at Laura', 'Francisco Balagtas', 1838, 'Phoenix Publishing House', '979-8-8889-762-90', 'Filipiniana', '2025-04-11', 'FIL P 439 BP28 1838', 'BP28', '2025000560-00'),
('A Sample For You', 'Sample', 2024, '978-012345678', 'Sampler', 'SHS', '2025-04-12', 'R2', 'SHS A123 20', '2025000561-01'),
('The Invisible Life of Addie LaRue', 'Agatha Christie', 1998, 'Vintage', '978-1-5265-210-7', 'Section', '2025-04-12', 'SHS A 260 CA66 1998', 'CA66', '2025000562-00'),
('Atomic Habits', 'James Clear', 2004, 'Little, Brown and Company', '978-1-5635-708-4', 'SHS', '2025-04-12', 'FIL B 369 CB35 2004', 'CB35', '2025000563-00'),
('A Man Called Ove', 'Stephen King', 1994, 'Doubleday', '978-1-9880-351-5', 'Filipiniana', '2025-04-12', 'RES C 500 KC26 1994', 'KC26', '2025000564-00'),
('Daisy Jones & The Six', 'Fredrik Backman', 1986, 'Hachette Book Group', '978-1-3314-390-6', 'Reserved', '2025-04-12', 'SHS D 466 BD80 1986', 'BD80', '2025000565-00'),
('Daisy Jones & The Six', 'TJ Klune', 1992, 'Penguin Random House', '978-1-8297-256-7', 'SHS', '2025-04-12', 'FIL E 810 KE71 1992', 'KE71', '2025000566-00');

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
(10, 2, '2025000012-00', 1, '2025-04-12', '2025-04-16', '07:28:17', 4);

-- --------------------------------------------------------

--
-- Table structure for table `books_deleted`
--

CREATE TABLE `books_deleted` (
  `Accno` varchar(50) NOT NULL,
  `Title` varchar(255) DEFAULT NULL,
  `Author` varchar(255) DEFAULT NULL,
  `Year` int(11) DEFAULT NULL,
  `Publisher` varchar(255) DEFAULT NULL,
  `ISBN` varchar(50) DEFAULT NULL,
  `Section` varchar(50) DEFAULT NULL,
  `CallNumber` varchar(50) DEFAULT NULL,
  `Rack` varchar(50) DEFAULT NULL,
  `ConditionID` int(11) DEFAULT NULL,
  `DeletedDate` timestamp NOT NULL DEFAULT current_timestamp(),
  `borrower_id` int(11) DEFAULT NULL,
  `Penalty Fee` decimal(10,0) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `books_deleted`
--

INSERT INTO `books_deleted` (`Accno`, `Title`, `Author`, `Year`, `Publisher`, `ISBN`, `Section`, `CallNumber`, `Rack`, `ConditionID`, `DeletedDate`, `borrower_id`, `Penalty Fee`) VALUES
('2025000002-01', 'Noli Me Tangere', 'José Rizal', 1887, 'National Book Store', '978-9710813801', 'Filipiniana', 'FIL DS 675 R59 1887', 'DSR1', 5, '2025-04-10 16:00:00', 4, 123),
('2025000005-00', 'Ang Mga Kaibigan ni Mama Susan', 'Bob Ong', 2010, 'Visprint Inc.', '978-9719257477', 'Circulation', 'CIR PS 9993 O54 2010', 'PSR4', 4, '2025-04-11 07:39:12', 1, 0),
('2025000167-00', 'A Man Called Ove', 'James Clear', 2016, 'Vintage', '978-1-9807-589-5', 'Reserved', 'RES C 687 CC28 2016', 'CC28', 4, '2025-04-11 23:25:48', 1, 0);

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
(4, 'Lost'),
(5, 'Repair');

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
(1, 'Librarian 1', 'admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918');

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
  `Penalty Fee` decimal(10,2) NOT NULL DEFAULT 0.00,
  `OverduePenalty` decimal(10,2) DEFAULT 0.00
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `returned_books`
--

INSERT INTO `returned_books` (`return_id`, `BorrowerID`, `BookID`, `ConditionID`, `Return Date`, `Penalty Fee`, `OverduePenalty`) VALUES
(1, 2, '2025000001-00', 1, '2025-04-11', 0.00, 0.00),
(2, 3, '2025000003-00', 1, '2025-04-11', 0.00, 0.00),
(3, 5, '2025000004-00', 3, '2025-04-11', 10.00, 0.00),
(6, 2, '2025000012-00', 1, '2025-04-12', 1.00, 1.00),
(8, 2, '2025000013-00', 3, '2025-04-12', 2009.00, 1.00);

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
(1, '211083', 'Monica Cano', '4A', 'BSCS', '09368417321', 'nicladeras97@gmail.com'),
(2, '211241', 'Monica Cano', '4A', 'BSCS', '09368417320', 'nicladeras97@gmail.com'),
(3, '211008', 'Allysa Pacunio', '4A', 'BSCS', '09123456789', 'allysapacunio0023@gmail.com'),
(4, '210731', 'Rhea Martin', '4A', 'BSCS ', '09123456789', 'rheamartin56@gmail.com'),
(5, '211031', 'April Joy Reyes', '4A', 'BSCS', '09356877565', 'roslengjay@gmail.com');

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
-- Indexes for table `books_deleted`
--
ALTER TABLE `books_deleted`
  ADD PRIMARY KEY (`Accno`),
  ADD KEY `ConditionID` (`ConditionID`);

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
  MODIFY `borrow_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

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
  MODIFY `LibraryID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `returned_books`
--
ALTER TABLE `returned_books`
  MODIFY `return_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `books_borrowed`
--
ALTER TABLE `books_borrowed`
  ADD CONSTRAINT `BORROWER` FOREIGN KEY (`borrower_id`) REFERENCES `users` (`UserID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `Book_id` FOREIGN KEY (`book_id`) REFERENCES `books` (`Accno`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `condition_id` FOREIGN KEY (`condition_id`) REFERENCES `book_condition` (`condition_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_book_id` FOREIGN KEY (`book_id`) REFERENCES `books` (`Accno`) ON DELETE CASCADE;

--
-- Constraints for table `books_deleted`
--
ALTER TABLE `books_deleted`
  ADD CONSTRAINT `books_deleted_ibfk_1` FOREIGN KEY (`ConditionID`) REFERENCES `book_condition` (`condition_id`) ON DELETE SET NULL;

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
