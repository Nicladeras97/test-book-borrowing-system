# Book Borrowing System

## Description
The Book Borrowing System is a digital solution designed to streamline the borrowing and returning of books. It replaces the manual process used by librarians, allowing for easier tracking of book availability and transactions.

## Features
- Book search by title, author, or category
- Borrowing and returning process tracking

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
#### Method 1: Manually Adding MySQL Connector (Windows + R)
```sh
1. Press Windows + R, type sysdm.cpl, and press Enter.
2. Go to the Advanced tab and click Environment Variables.
3. Under System Variables, look for Path, select it, and click Edit.
4. Click New and add the path to MySQL Connector (e.g., C:\Program Files (x86)\MySQL\Connector NET 9.2\).
5. Click OK to save changes.
```

#### Method 2: Configuring in ODBC Data Source Administrator (`odbcad32.exe`)
```sh
1. Press Windows + R, type odbcad32.exe, and press Enter.
2. Go to the System DSN tab and click Add.
3. Select MySQL ODBC Driver and click Finish.
4. Enter the following details:
   - Data Source Name: BookBorrowingDB
   - Server: localhost
   - User: root
   - Password: (your MySQL password)
   - Database: book_borrowing_db
5. Click Test to ensure the connection works, then click OK.
```

#### Method 3: Configuring in `App.config`
```xml
<connectionStrings>
  <add name="MySqlConnection" 
       connectionString="server=localhost; database=book_borrowing_db; user id=root; password=yourpassword;" 
       providerName="MySql.Data.MySqlClient" />
</connectionStrings>
```

### Step 5: Run the Application
```sh
1. Open the project in Visual Studio
2. Build the solution (Ctrl + Shift + B)
3. Run the project (F5)
```
