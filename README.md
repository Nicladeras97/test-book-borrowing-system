# Book Borrowing System

## Description
The Book Borrowing System is a digital solution designed to streamline the borrowing and returning of books. It replaces the manual process used by librarians, allowing for easier tracking of book availability and transactions.

## Features
- Book search by title, author, or category
- Borrowing and returning process tracking
- Book Reports for lost, damaged and overdue books.

## Requirements
```sh
- Microsoft Visual Studio 2022
- VB.NET 2022
- XAMPP (MySQL Database)
- MySQL Connector 9.2
```

## Installation
### Step 1: Download and Install Dependencies
```sh
1. Install Microsoft Visual Studio 2022
2. Install XAMPP and enable MySQL
3. Download and install MySQL Connector 9.2
```

```sh
https://dev.mysql.com/downloads/connector/odbc/
```

4. Download the Windows (x86, 64-bit), MSI Installer based on the link I provided about MySQL Connector 9.2.

### Step 2: Clone the Repository
```sh
git clone https://github.com/Nicladeras97/book-borrowing-system-mysql.git
```

### Step 3: Set Up the Database
```sh
1. Open XAMPP and start the MySQL module
2. Open phpMyAdmin and create a new database (e.g., book-borrowing)
3. Import the provided SQL file 
```

### Step 4: Configure the Database Connection in VB.NET
#### Configuring in ODBC Data Source Administrator (`odbcad32.exe`)
```sh
1. Press Windows + R, type odbcad32.exe, and press Enter.
2. Go to the System DSN tab and click Add.
3. Select MySQL ODBC Driver and click Finish.
4. Enter the following details:
   - Data Source Name: My SQL Connections
   - Server: localhost
   - User: root
   - Password: 
   - Database: book-borrowing
5. Click Test to ensure the connection works, then click OK.
```

### Step 5:
#### Configuring database connection in vb 2022
```sh
1. Go to your project in Microsoft Visual Studio 2022.
2. Go to Tools tab and click the "Connect to Database".
3. Select Microsoft ODBC Data Source.
4. Click "Use user or system data source name" and click the dropdown.
5. Find you Data Source Name(My SQL Connections).
4. Enter the following details:
   - User: root
5. Click Test to ensure the connection works, then click OK.
```

### Step 6: Run the Application
```sh
1. Open the project in Visual Studio
2. Build the solution (Ctrl + Shift + B)
3. Run the project (F5)
```
