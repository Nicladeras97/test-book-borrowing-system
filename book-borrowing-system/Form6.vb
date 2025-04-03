Imports System.Drawing.Printing
Imports ClosedXML.Excel
Imports MySql.Data.MySqlClient

Public Class Form6
    Dim currentPage As Integer = 1
    Dim pageSize As Integer = 20
    Dim totalRecords As Integer = 0
    Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")
    Dim printDoc As New PrintDocument()

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.AddRange(New String() {"Books Inventory", "Book Activity Summary", "Borrowed Books", "Overdue Books", "Lost Books", "Damaged Books", "Books with Multiple Copies", "Borrowers"})
        ComboBox1.SelectedIndex = 0
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy"
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "MMMM dd, yyyy"
        LoadReport()
        DataGridView1.ClearSelection()
        AddHandler printDoc.PrintPage, AddressOf Me.PrintDocument_PrintPage
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        LoadReport()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim query As String = ""
        Dim startDate As String = DateTimePicker1.Value.ToString("MMMM dd, yyyy")
        Dim endDate As String = DateTimePicker2.Value.ToString("MMMM dd, yyyy")

        Select Case ComboBox1.SelectedItem.ToString()
            Case "Books Inventory"
                query = "SELECT Accno AS 'Accession Number', Title, Author, CallNumber FROM books"

            Case "Book Activity Summary"
                query = "SELECT b.Accno AS 'Accession Number', b.Title, b.Author, COUNT(bb.book_id) AS 'Borrow Count' " &
                        "FROM books b " &
                        "LEFT JOIN books_borrowed bb ON b.Accno = bb.book_id " &
                        "GROUP BY b.Accno ORDER BY 'Borrow Count' DESC"

            Case "Borrowed Books"
                query = "SELECT b.Accno AS 'Accession Number', b.Title, u.StudNo AS 'Student Number', u.FullName AS 'Name', bb.due_date AS 'Due Date' " &
                        "FROM books_borrowed bb " &
                        "JOIN books b ON bb.book_id = b.Accno " &
                        "JOIN users u ON bb.borrower_id = u.UserID " &
                        "WHERE bb.due_date BETWEEN '" & startDate & "' AND '" & endDate & "'"

            Case "Overdue Books"
                query = "SELECT b.Accno AS 'Accession Number', b.Title, u.StudNo AS 'Student Number', u.FullName AS 'Name', bb.due_date AS 'Due Date', " &
                        "DATEDIFF(NOW(), bb.due_date) AS 'Overdue Days' " &
                        "FROM books_borrowed bb " &
                        "JOIN books b ON bb.book_id = b.Accno " &
                        "JOIN users u ON bb.borrower_id = u.UserID " &
                        "WHERE bb.due_date < NOW()"

            Case "Lost Books"
                query = "SELECT bd.Accno AS 'Accession Number', bd.Title, bd.CallNumber, bd.Rack, bd.DeletedDate AS 'Date Lost', u.StudNo AS 'Student Number' " &
                        "FROM books_deleted bd " &
                        "LEFT JOIN users u ON bd.borrower_id = u.UserID " &
                        "WHERE bd.DeletedDate IS NOT NULL"

            Case "Damaged Books"
                query = "SELECT rb.BorrowerID AS 'Borrower ID', u.StudNo AS 'Student Number', rb.BookID AS 'Accession Number', rb.`Return Date`, rb.`Penalty Fee` " &
                        "FROM returned_books rb " &
                        "JOIN users u ON rb.BorrowerID = u.UserID " &
                        "WHERE rb.ConditionID = 3"

            Case "Books with Multiple Copies"
                query = "SELECT b.ISBN, b.Title, GROUP_CONCAT(b.Accno SEPARATOR ', ') AS 'Accession Numbers', COUNT(*) AS 'Copies' " &
                        "FROM books b " &
                        "GROUP BY b.ISBN, b.Title HAVING COUNT(*) > 0"

            Case "Borrowers"
                query = "SELECT u.UserID AS 'User ID', u.FullName AS 'Name', u.StudNo AS 'Student Number' " &
                        "FROM users u"

        End Select

        Dim adapter As New MySqlDataAdapter(query, conn)
        Dim table As New DataTable()
        adapter.Fill(table)
        DataGridView1.DataSource = table
        totalRecords = table.Rows.Count
        UpdatePagination()
    End Sub

    Private Sub LoadReport()
        Dim query As String = ""
        Dim offset As Integer = (currentPage - 1) * pageSize
        Dim limit As Integer = pageSize

        Select Case ComboBox1.SelectedItem.ToString()
            Case "Books Inventory"
                query = "SELECT Accno AS 'Accession Number', Title, Author, CallNumber FROM books LIMIT " & limit & " OFFSET " & offset

            Case "Book Activity Summary"
                query = "SELECT b.Accno AS 'Accession Number', b.Title, b.Author, COUNT(bb.book_id) AS 'Borrow Count' " &
                        "FROM books b " &
                        "LEFT JOIN books_borrowed bb ON b.Accno = bb.book_id " &
                        "GROUP BY b.Accno ORDER BY 'Borrow Count' DESC LIMIT " & limit & " OFFSET " & offset

            Case "Borrowed Books"
                query = "SELECT b.Accno AS 'Accession Number', b.Title, u.StudNo AS 'Student Number', u.FullName AS 'Name', bb.due_date AS 'Due Date' " &
                        "FROM books_borrowed bb " &
                        "JOIN books b ON bb.book_id = b.Accno " &
                        "JOIN users u ON bb.borrower_id = u.UserID LIMIT " & limit & " OFFSET " & offset

            Case "Overdue Books"
                query = "SELECT b.Accno AS 'Accession Number', b.Title, u.StudNo AS 'Student Number', u.FullName AS 'Name', bb.due_date AS 'Due Date', " &
                        "DATEDIFF(NOW(), bb.due_date) AS 'Overdue Days' " &
                        "FROM books_borrowed bb " &
                        "JOIN books b ON bb.book_id = b.Accno " &
                        "JOIN users u ON bb.borrower_id = u.UserID " &
                        "WHERE bb.due_date < NOW() LIMIT " & limit & " OFFSET " & offset

            Case "Lost Books"
                query = "SELECT bd.Accno AS 'Accession Number', bd.Title, bd.CallNumber, bd.Rack, bd.DeletedDate AS 'Date Lost', u.StudNo AS 'Student Number' " &
                        "FROM books_deleted bd " &
                        "LEFT JOIN users u ON bd.borrower_id = u.UserID " &
                        "WHERE bd.DeletedDate IS NOT NULL LIMIT " & limit & " OFFSET " & offset

            Case "Damaged Books"
                query = "SELECT rb.BorrowerID AS 'Borrower ID', u.StudNo AS 'Student Number', rb.BookID AS 'Accession Number', rb.`Return Date`, rb.`Penalty Fee` " &
                        "FROM returned_books rb " &
                        "JOIN users u ON rb.BorrowerID = u.UserID " &
                        "WHERE rb.ConditionID = 3 LIMIT " & limit & " OFFSET " & offset

            Case "Books with Multiple Copies"
                query = "SELECT b.ISBN, b.Title, GROUP_CONCAT(b.Accno SEPARATOR ', ') AS 'Accession Numbers', COUNT(*) AS 'Copies' " &
                        "FROM books b " &
                        "GROUP BY b.ISBN, b.Title HAVING COUNT(*) > 0 LIMIT " & limit & " OFFSET " & offset

            Case "Borrowers"
                query = "SELECT u.UserID AS 'User ID', u.FullName AS 'Name', u.StudNo AS 'Student Number' " &
                        "FROM users u LIMIT " & limit & " OFFSET " & offset
        End Select

        Dim adapter As New MySqlDataAdapter(query, conn)
        Dim table As New DataTable()
        adapter.Fill(table)
        DataGridView1.DataSource = table
        totalRecords = GetTotalRecords()
        UpdatePagination()
    End Sub

    Private Function GetTotalRecords() As Integer
        Dim countQuery As String = ""

        Select Case ComboBox1.SelectedItem.ToString()
            Case "Books Inventory"
                countQuery = "SELECT COUNT(*) FROM books"

            Case "Book Activity Summary"
                countQuery = "SELECT COUNT(DISTINCT Accno) FROM books"

            Case "Borrowed Books"
                countQuery = "SELECT COUNT(*) FROM books_borrowed"

            Case "Overdue Books"
                countQuery = "SELECT COUNT(*) FROM books_borrowed WHERE due_date < NOW()"

            Case "Lost Books"
                countQuery = "SELECT COUNT(*) FROM books_deleted WHERE DeletedDate IS NOT NULL"

            Case "Damaged Books"
                countQuery = "SELECT COUNT(*) FROM returned_books WHERE ConditionID = 3"

            Case "Books with Multiple Copies"
                countQuery = "SELECT COUNT(DISTINCT ISBN) FROM books"

            Case "Borrowers"
                countQuery = "SELECT COUNT(*) FROM users"
        End Select

        Dim cmd As New MySqlCommand(countQuery, conn)
        conn.Open()
        Dim total As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        conn.Close()

        Return total
    End Function

    Private Sub UpdatePagination()
        Dim totalPages As Integer = Math.Ceiling(totalRecords / pageSize)
        Label5.Text = currentPage.ToString() & "/" & totalPages.ToString() & " out of " & totalRecords.ToString()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If currentPage > 1 Then
            currentPage -= 1
            LoadReport()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim totalPages As Integer = Math.Ceiling(totalRecords / pageSize)
        If currentPage < totalPages Then
            currentPage += 1
            LoadReport()
        End If
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
                worksheet.Cell(1, col + 1).Style.Fill.BackgroundColor = XLColor.LightGray
            Next

            For row As Integer = 0 To DataGridView1.Rows.Count - 1
                If Not DataGridView1.Rows(row).IsNewRow Then
                    For col As Integer = 0 To DataGridView1.Columns.Count - 1
                        worksheet.Cell(row + 2, col + 1).Value = DataGridView1.Rows(row).Cells(col).Value?.ToString()
                    Next
                End If
            Next

            worksheet.Columns().AdjustToContents()

            workbook.SaveAs(saveFileDialog.FileName)

            MessageBox.Show("Exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error exporting to Excel: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If DataGridView1.Rows.Count > 0 Then
                printDoc.Print()
            Else
                MessageBox.Show("No data to print.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error printing report: " & ex.Message, "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PrintDocument_PrintPage(sender As Object, e As PrintPageEventArgs)
        Dim yPos As Integer = 100
        Dim xPos As Integer = 50
        Dim lineHeight As Integer = 20
        Dim columnCount As Integer = DataGridView1.Columns.Count
        Dim font As New Font("Arial", 10)
        Dim brush As New SolidBrush(Color.Black)

        For col As Integer = 0 To columnCount - 1
            e.Graphics.DrawString(DataGridView1.Columns(col).HeaderText, font, brush, xPos, yPos)
            xPos += 150
        Next
        yPos += lineHeight

        For Each row As DataGridViewRow In DataGridView1.Rows
            xPos = 50
            If row.IsNewRow Then Continue For

            For col As Integer = 0 To columnCount - 1
                e.Graphics.DrawString(row.Cells(col).Value.ToString(), font, brush, xPos, yPos)
                xPos += 150
            Next
            yPos += lineHeight

            If yPos > e.MarginBounds.Bottom Then
                e.HasMorePages = True
                Return
            End If
        Next

        e.HasMorePages = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ExportToExcel()
    End Sub

End Class