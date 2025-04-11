Imports System.Drawing.Printing
Imports ClosedXML.Excel
Imports DocumentFormat.OpenXml.Drawing
Imports MySql.Data.MySqlClient
Imports OfficeOpenXml.LoadFunctions.Params

Public Class Form6
    Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")
    Dim printDoc As New PrintDocument()
    Dim currentPage As Integer = 1
    Dim pageSize As Integer = 25
    Dim totalRecords As Integer = 0
    Dim totalPages As Integer = 0

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.AddRange(New String() {"Books Inventory", "Book Activity Summary", "Borrowed Books", "Overdue Books", "Lost Books", "Damaged Books", "Books with Multiple Copies", "Borrowers"})
        ComboBox1.SelectedIndex = 0

        ComboBox2.Items.AddRange(New String() {"1", "25", "50", "100", "500", "700", "1000"})
        ComboBox2.SelectedIndex = 1

        If ComboBox1.SelectedItem IsNot Nothing Then
            LoadReport()
        End If

        DataGridView1.ClearSelection()
        AddHandler printDoc.PrintPage, AddressOf Me.PrintDocument1_PrintPage
        TextBox1.Focus()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        LoadReport()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        pageSize = Integer.Parse(ComboBox2.SelectedItem.ToString())
        currentPage = 1
        LoadReport()
    End Sub

    Private Sub LoadReport()
        If ComboBox1.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a report category from the dropdown.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim query As String = ""
            Dim rowLimit As String = If(ComboBox2.SelectedItem IsNot Nothing, ComboBox2.SelectedItem.ToString(), "25")
            Dim offset As Integer = (currentPage - 1) * Integer.Parse(rowLimit)

            Select Case ComboBox1.SelectedItem.ToString()
                Case "Books Inventory"
                    query = "SELECT Accno AS 'Accession Number', Title, Author, CallNumber, AddedDate FROM books LIMIT " & offset & ", " & rowLimit
                Case "Book Activity Summary"
                    query = "SELECT b.Accno AS 'Accession Number', b.Title, b.Author, COUNT(bb.book_id) AS 'Borrow Count' " &
                        "FROM books b LEFT JOIN books_borrowed bb ON b.Accno = bb.book_id " &
                        "GROUP BY b.Accno HAVING COUNT(bb.book_id) > 0 " &
                        "ORDER BY COUNT(bb.book_id) DESC LIMIT " & offset & ", " & Integer.Parse(rowLimit)
                Case "Borrowed Books"
                    query = "SELECT b.Accno AS 'Accession Number', b.Title, u.StudNo AS 'Student Number', u.FullName AS 'Name', bb.due_date AS 'Due Date' " &
                        "FROM books_borrowed bb JOIN books b ON bb.book_id = b.Accno JOIN users u ON bb.borrower_id = u.UserID LIMIT " & offset & ", " & rowLimit
                Case "Overdue Books"
                    query = "SELECT b.Accno AS 'Accession Number', b.Title, u.StudNo AS 'Student Number', u.FullName AS 'Name', bb.due_date AS 'Due Date', " &
                        "DATEDIFF(NOW(), bb.due_date) AS 'Overdue Days' FROM books_borrowed bb " &
                        "JOIN books b ON bb.book_id = b.Accno JOIN users u ON bb.borrower_id = u.UserID " &
                        "WHERE bb.due_date < NOW() LIMIT " & offset & ", " & rowLimit
                Case "Lost Books"
                    query = "SELECT bd.Accno AS 'Accession Number', bd.Title, bd.DeletedDate AS 'Date Lost', u.StudNo AS 'Student Number' " &
                        "FROM books_deleted bd LEFT JOIN users u ON bd.borrower_id = u.UserID " &
                        "WHERE bd.DeletedDate IS NOT NULL LIMIT " & offset & ", " & rowLimit
                Case "Damaged Books"
                    query = "SELECT u.StudNo AS 'Student Number', rb.BookID AS 'Accession Number', rb.`Return Date`, rb.`Penalty Fee`, rb.`OverduePenalty` " &
                        "FROM returned_books rb JOIN users u ON rb.BorrowerID = u.UserID WHERE rb.ConditionID = 3 LIMIT " & offset & ", " & rowLimit
                Case "Books with Multiple Copies"
                    query = "SELECT b.ISBN, b.Title, GROUP_CONCAT(b.Accno SEPARATOR ', ') AS 'Accession Numbers', COUNT(*) AS 'Copies' " &
                        "FROM books b GROUP BY b.ISBN, b.Title HAVING COUNT(*) > 1 LIMIT " & offset & ", " & rowLimit
                Case "Borrowers"
                    query = "SELECT u.UserID AS 'User ID', u.FullName AS 'Name', u.StudNo AS 'Student Number' FROM users u LIMIT " & offset & ", " & rowLimit
                Case Else
                    MessageBox.Show("Unknown report category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
            End Select

            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table


            Dim countQuery As String = ""

            Select Case ComboBox1.SelectedItem.ToString()
                Case "Books Inventory"
                    countQuery = "SELECT COUNT(*) FROM books"
                Case "Book Activity Summary"
                    countQuery = "SELECT COUNT(*) FROM (SELECT b.Accno FROM books b LEFT JOIN books_borrowed bb ON b.Accno = bb.book_id GROUP BY b.Accno HAVING COUNT(bb.book_id) > 0) AS sub"
                Case "Borrowed Books"
                    countQuery = "SELECT COUNT(*) FROM books_borrowed"
                Case "Overdue Books"
                    countQuery = "SELECT COUNT(*) FROM books_borrowed WHERE due_date < NOW()"
                Case "Lost Books"
                    countQuery = "SELECT COUNT(*) FROM books_deleted WHERE DeletedDate IS NOT NULL"
                Case "Damaged Books"
                    countQuery = "SELECT COUNT(*) FROM returned_books WHERE ConditionID = 3"
                Case "Books with Multiple Copies"
                    countQuery = "SELECT COUNT(*) FROM (SELECT ISBN, Title FROM books GROUP BY ISBN, Title HAVING COUNT(*) > 1) AS sub"
                Case "Borrowers"
                    countQuery = "SELECT COUNT(*) FROM users"
            End Select

            Dim countCmd As New MySqlCommand(countQuery, conn)
            conn.Open()
            totalRecords = Convert.ToInt32(countCmd.ExecuteScalar())
            conn.Close()

            totalPages = Math.Ceiling(totalRecords / pageSize)
            Label2.Text = "Page " & currentPage.ToString() & " of " & totalPages.ToString()

        Catch ex As Exception
            MessageBox.Show("An error occurred while loading the report: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        FilterResults()
    End Sub

    Private Sub FilterResults()
        If ComboBox1.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a report category from the dropdown.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim searchText As String = TextBox1.Text.Trim()
            Dim query As String = ""
            Dim rowLimit As String = If(ComboBox2.SelectedItem IsNot Nothing, ComboBox2.SelectedItem.ToString(), "25")
            Dim offset As Integer = (currentPage - 1) * Integer.Parse(rowLimit)

            Select Case ComboBox1.SelectedItem.ToString()
                Case "Books Inventory"
                    query = "SELECT Accno AS 'Accession Number', Title, Author, CallNumber, AddedDate FROM books " &
                        "WHERE Title LIKE '%" & searchText & "%' OR Author LIKE '%" & searchText & "%' OR CallNumber LIKE '%" & searchText & "%' OR Accno LIKE '%" & searchText & "%' " &
                        "LIMIT " & offset & ", " & rowLimit

                Case "Book Activity Summary"
                    query = "SELECT b.Accno AS 'Accession Number', b.Title, b.Author, COUNT(bb.book_id) AS 'Borrow Count' " &
                        "FROM books b LEFT JOIN books_borrowed bb ON b.Accno = bb.book_id " &
                        "WHERE b.Title LIKE '%" & searchText & "%' OR b.Author LIKE '%" & searchText & "%' OR b.Accno LIKE '%" & searchText & "%' " &
                        "GROUP BY b.Accno HAVING COUNT(bb.book_id) > 0 " &
                        "ORDER BY COUNT(bb.book_id) DESC LIMIT " & offset & ", " & rowLimit

                Case "Borrowed Books"
                    query = "SELECT b.Accno AS 'Accession Number', b.Title, u.StudNo AS 'Student Number', u.FullName AS 'Name', bb.due_date AS 'Due Date' " &
                        "FROM books_borrowed bb JOIN books b ON bb.book_id = b.Accno JOIN users u ON bb.borrower_id = u.UserID " &
                        "WHERE u.Studno LIKE '%" & searchText & "%' OR b.Accno LIKE '%" & searchText & "%' OR b.Title LIKE '%" & searchText & "%' OR u.FullName LIKE '%" & searchText & "%' OR b.Author LIKE '%" & searchText & "%' " &
                        "LIMIT " & offset & ", " & rowLimit

                Case "Overdue Books"
                    query = "SELECT b.Accno AS 'Accession Number', b.Title, u.StudNo AS 'Student Number', u.FullName AS 'Name', bb.due_date AS 'Due Date', " &
                        "DATEDIFF(NOW(), bb.due_date) AS 'Overdue Days' FROM books_borrowed bb " &
                        "JOIN books b ON bb.book_id = b.Accno JOIN users u ON bb.borrower_id = u.UserID " &
                        "WHERE bb.due_date < NOW() AND (u.Studno LIKE '%" & searchText & "%' OR b.Accno LIKE '%" & searchText & "%' OR b.Title LIKE '%" & searchText & "%' OR u.FullName LIKE '%" & searchText & "%') " &
                        "LIMIT " & offset & ", " & rowLimit

                Case "Lost Books"
                    query = "SELECT bd.Accno AS 'Accession Number', bd.Title, bd.DeletedDate AS 'Date Lost', u.StudNo AS 'Student Number' " &
                        "FROM books_deleted bd LEFT JOIN users u ON bd.borrower_id = u.UserID " &
                        "WHERE bd.DeletedDate IS NOT NULL AND (bd.Accno LIKE '%" & searchText & "%' OR u.Studno LIKE '%" & searchText & "%' OR bd.Title LIKE '%" & searchText & "%' OR u.FullName LIKE '%" & searchText & "%') " &
                        "LIMIT " & offset & ", " & rowLimit

                Case "Damaged Books"
                    query = "SELECT u.StudNo AS 'Student Number', rb.BookID AS 'Accession Number', rb.`Return Date`, rb.`Penalty Fee`, rb.`OverduePenalty` " &
                        "FROM returned_books rb JOIN users u ON rb.BorrowerID = u.UserID " &
                        "WHERE rb.ConditionID = 3 AND (u.Studno LIKE '%" & searchText & "%' OR rb.BookID LIKE '%" & searchText & "%' OR u.FullName LIKE '%" & searchText & "%') " &
                        "LIMIT " & offset & ", " & rowLimit

                Case "Books with Multiple Copies"
                    query = "SELECT b.ISBN, b.Title, GROUP_CONCAT(b.Accno SEPARATOR ', ') AS 'Accession Numbers', COUNT(*) AS 'Copies' " &
                        "FROM books b WHERE b.Accno LIKE '%" & searchText & "%' OR b.Title LIKE '%" & searchText & "%' OR b.ISBN LIKE '%" & searchText & "%' " &
                        "GROUP BY b.ISBN, b.Title HAVING COUNT(*) > 1 LIMIT " & offset & ", " & rowLimit

                Case "Borrowers"
                    query = "SELECT u.UserID AS 'User ID', u.FullName AS 'Name', u.StudNo AS 'Student Number' " &
                        "FROM users u WHERE u.FullName LIKE '%" & searchText & "%' OR u.StudNo LIKE '%" & searchText & "%' " &
                        "LIMIT " & offset & ", " & rowLimit
            End Select

            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table

            Dim countQuery As String = ""

            Select Case ComboBox1.SelectedItem.ToString()
                Case "Books Inventory"
                    countQuery = "SELECT COUNT(*) FROM books WHERE Title LIKE '%" & searchText & "%' OR Author LIKE '%" & searchText & "%' OR CallNumber LIKE '%" & searchText & "%' OR Accno LIKE '%" & searchText & "%'"
                Case "Book Activity Summary"
                    countQuery = "SELECT COUNT(*) FROM (SELECT b.Accno FROM books b LEFT JOIN books_borrowed bb ON b.Accno = bb.book_id WHERE b.Title LIKE '%" & searchText & "%' OR b.Author LIKE '%" & searchText & "%' OR b.Accno LIKE '%" & searchText & "%' GROUP BY b.Accno HAVING COUNT(bb.book_id) > 0) AS sub"
                Case "Borrowed Books"
                    countQuery = "SELECT COUNT(*) FROM books_borrowed bb JOIN books b ON bb.book_id = b.Accno JOIN users u ON bb.borrower_id = u.UserID " &
                             "WHERE u.Studno LIKE '%" & searchText & "%' OR b.Accno LIKE '%" & searchText & "%' OR b.Title LIKE '%" & searchText & "%' OR u.FullName LIKE '%" & searchText & "%' OR b.Author LIKE '%" & searchText & "%'"
                Case "Overdue Books"
                    countQuery = "SELECT COUNT(*) FROM books_borrowed bb JOIN users u ON bb.borrower_id = u.UserID JOIN books b ON bb.book_id = b.Accno " &
                             "WHERE bb.due_date < NOW() AND (u.Studno LIKE '%" & searchText & "%' OR b.Accno LIKE '%" & searchText & "%' OR b.Title LIKE '%" & searchText & "%' OR u.FullName LIKE '%" & searchText & "%')"
                Case "Lost Books"
                    countQuery = "SELECT COUNT(*) FROM books_deleted bd LEFT JOIN users u ON bd.borrower_id = u.UserID " &
                             "WHERE bd.DeletedDate IS NOT NULL AND (bd.Accno LIKE '%" & searchText & "%' OR u.Studno LIKE '%" & searchText & "%' OR bd.Title LIKE '%" & searchText & "%' OR u.FullName LIKE '%" & searchText & "%')"
                Case "Damaged Books"
                    countQuery = "SELECT COUNT(*) FROM returned_books rb JOIN users u ON rb.BorrowerID = u.UserID " &
                             "WHERE rb.ConditionID = 3 AND (u.Studno LIKE '%" & searchText & "%' OR rb.BookID LIKE '%" & searchText & "%' OR u.FullName LIKE '%" & searchText & "%')"
                Case "Books with Multiple Copies"
                    countQuery = "SELECT COUNT(*) FROM (SELECT ISBN, Title FROM books WHERE Accno LIKE '%" & searchText & "%' OR Title LIKE '%" & searchText & "%' OR ISBN LIKE '%" & searchText & "%' GROUP BY ISBN, Title HAVING COUNT(*) > 1) AS sub"
                Case "Borrowers"
                    countQuery = "SELECT COUNT(*) FROM users u WHERE u.FullName LIKE '%" & searchText & "%' OR u.StudNo LIKE '%" & searchText & "%'"
            End Select

            Dim countCmd As New MySqlCommand(countQuery, conn)
            conn.Open()
            totalRecords = Convert.ToInt32(countCmd.ExecuteScalar())
            conn.Close()

            totalPages = Math.Ceiling(totalRecords / pageSize)
            Label2.Text = "Page " & currentPage.ToString() & " of " & totalPages.ToString()

        Catch ex As Exception
            MessageBox.Show("An error occurred while filtering results: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If DataGridView1.Rows.Count > 0 Then
                PrintPreviewDialog1.Document = printDoc
                PrintPreviewDialog1.ShowDialog()
            Else
                MessageBox.Show("No data to print.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error printing report: " & ex.Message, "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs)
        Dim yPos As Integer = 100
        Dim xPos As Integer = 60
        Dim lineHeight As Integer = 45
        Dim columnCount As Integer = DataGridView1.Columns.Count
        Dim font As New Font("Arial", 10)
        Dim brush As New SolidBrush(Color.Black)
        Dim pageHeight As Integer = e.PageBounds.Height
        Dim pageWidth As Integer = e.PageBounds.Width
        Dim yMax As Integer = pageHeight - 100

        Dim columnWidth As Integer = (pageWidth - 100) / columnCount

        For col As Integer = 0 To columnCount - 1
            e.Graphics.DrawString(DataGridView1.Columns(col).HeaderText, font, brush, xPos, yPos)
            xPos += columnWidth
        Next
        yPos += lineHeight
        xPos = 50

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.IsNewRow Then Continue For

            If yPos + lineHeight > yMax Then
                e.HasMorePages = True
                Return
            End If

            xPos = 50

            For col As Integer = 0 To columnCount - 1
                Dim cellValue As String = row.Cells(col).Value.ToString()

                Dim layoutRect As New RectangleF(xPos, yPos, columnWidth, lineHeight * 3)
                e.Graphics.DrawString(cellValue, font, brush, layoutRect)

                xPos += columnWidth
            Next
            yPos += lineHeight
        Next

        e.HasMorePages = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ExportToExcel()
    End Sub

    Private Sub ExportToExcel()
        Try
            If DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"
            saveFileDialog.Title = "Save Excel File"
            saveFileDialog.FileName = "Report_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".xlsx"

            If saveFileDialog.ShowDialog() <> DialogResult.OK Then Exit Sub

            Dim workbook As New XLWorkbook()
            Dim worksheet As IXLWorksheet = workbook.Worksheets.Add("Report")

            For col As Integer = 0 To DataGridView1.Columns.Count - 1
                worksheet.Cell(1, col + 1).Value = DataGridView1.Columns(col).HeaderText
                worksheet.Cell(1, col + 1).Style.Font.Bold = True
            Next

            For row As Integer = 0 To DataGridView1.Rows.Count - 1
                For col As Integer = 0 To DataGridView1.Columns.Count - 1
                    worksheet.Cell(row + 2, col + 1).Value = DataGridView1.Rows(row).Cells(col).Value
                Next
            Next

            workbook.SaveAs(saveFileDialog.FileName)
            MessageBox.Show("Data exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error exporting data: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If currentPage > 1 Then
            currentPage -= 1
            LoadReport()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If currentPage < totalPages Then
            currentPage += 1
            LoadReport()
        End If
    End Sub

End Class
