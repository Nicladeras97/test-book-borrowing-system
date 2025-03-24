Imports MySql.Data.MySqlClient
Imports OfficeOpenXml
Imports System.IO
Public Class Form5

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim addForm As New Form10
        addForm.Show()
        Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim back As New Form4
        back.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Using saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"
            saveFileDialog.Title = "Save Template File"
            saveFileDialog.FileName = "Book_Import_Template.xlsx"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                GenerateExcelTemplate(saveFileDialog.FileName)
                MessageBox.Show("Template downloaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    Private Sub GenerateExcelTemplate(filePath As String)
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial

        Using package As New ExcelPackage()
            Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.Add("Books Template")

            worksheet.Cells(1, 1).Value = "Title"
            worksheet.Cells(1, 2).Value = "Author"
            worksheet.Cells(1, 3).Value = "Year"
            worksheet.Cells(1, 4).Value = "ISBN"
            worksheet.Cells(1, 5).Value = "Category"
            worksheet.Cells(1, 6).Value = "Copies"

            worksheet.Cells(2, 1).Value = "Sample Book Title"
            worksheet.Cells(2, 2).Value = "John Doe"
            worksheet.Cells(2, 3).Value = "2023"
            worksheet.Cells(2, 4).Value = "1234567890"
            worksheet.Cells(2, 5).Value = "Fiction"
            worksheet.Cells(2, 6).Value = "5"

            Using headerRange = worksheet.Cells("A1:F1")
                headerRange.Style.Font.Bold = True
                headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray)
            End Using

            worksheet.Cells.AutoFitColumns()

            Dim fileInfo As New FileInfo(filePath)
            package.SaveAs(fileInfo)
        End Using
    End Sub

    Public Sub ImportExcelToDatabase(filePath As String)
        Dim connectionString As String = "server=localhost; user=root; password=; database=book-borrowing;"

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial

        Dim importedCount As Integer = 0
        Dim skippedCount As Integer = 0

        Using package As New ExcelPackage(New FileInfo(filePath))
            Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets(0)
            Dim rowCount As Integer = worksheet.Dimension.Rows

            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                For i As Integer = 2 To rowCount
                    Dim title As String = worksheet.Cells(i, 1).Text.Trim()
                    Dim author As String = worksheet.Cells(i, 2).Text.Trim()
                    Dim year As String = worksheet.Cells(i, 3).Text.Trim()
                    Dim isbn As String = worksheet.Cells(i, 4).Text.Trim()
                    Dim category As String = worksheet.Cells(i, 5).Text.Trim()
                    Dim copiesText As String = worksheet.Cells(i, 6).Text.Trim()

                    Dim copies As Integer
                    If Not Integer.TryParse(copiesText, copies) OrElse copies <= 0 Then
                        copies = 1
                    End If

                    Dim checkQuery As String = "SELECT COUNT(*) FROM book WHERE ISBN = @isbn"
                    Using checkCmd As New MySqlCommand(checkQuery, connection)
                        checkCmd.Parameters.AddWithValue("@isbn", isbn)
                        Dim existingCount As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                        If existingCount > 0 Then
                            skippedCount += 1
                            Continue For
                        End If
                    End Using

                    Dim query As String = "INSERT INTO book (Title, Author, Year, ISBN, Category, Status, Copies) 
                                           VALUES (@title, @author, 
                                           @year, @isbn, @category, 'Available', @copies)"

                    Using cmd As New MySqlCommand(query, connection)
                        cmd.Parameters.AddWithValue("@title", title)
                        cmd.Parameters.AddWithValue("@author", author)
                        cmd.Parameters.AddWithValue("@year", year)
                        cmd.Parameters.AddWithValue("@isbn", isbn)
                        cmd.Parameters.AddWithValue("@category", category)
                        cmd.Parameters.AddWithValue("@copies", copies)
                        cmd.ExecuteNonQuery()

                        importedCount += 1
                    End Using
                Next
            End Using
        End Using

        MessageBox.Show($"✅ Imported: {importedCount}{vbNewLine}🚫 Skipped (Duplicate): {skippedCount}", "Import Summary", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim result As DialogResult = MessageBox.Show("Choose an option:" & vbCrLf &
                                                 "Yes = Import File" & vbCrLf &
                                                 "No = Import Image",
                                                 "Import Options",
                                                 MessageBoxButtons.YesNoCancel,
                                                 MessageBoxIcon.Question)

        If result = DialogResult.Yes Then

            Using openFileDialog As New OpenFileDialog
                openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"
                openFileDialog.Title = "Select an Excel File"

                If openFileDialog.ShowDialog = DialogResult.OK Then
                    ImportExcelToDatabase(openFileDialog.FileName)
                    LoadBookData()
                End If
            End Using

        ElseIf result = DialogResult.No Then

            Using openFileDialog As New OpenFileDialog()
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"
                openFileDialog.Title = "Select a Book Image"

                If openFileDialog.ShowDialog() = DialogResult.OK Then
                    Dim sourcePath As String = openFileDialog.FileName
                    Dim fileName As String = Path.GetFileName(sourcePath)
                    Dim destPath As String = Path.Combine(Application.StartupPath, "img\books", fileName)

                    File.Copy(sourcePath, destPath, True)

                    Dim imagePath As String = "img/books/" & fileName

                    Dim bookIDInput As String = InputBox("Enter the BookID to associate this image:", "Book ID", "")
                    If Not String.IsNullOrEmpty(bookIDInput) AndAlso IsNumeric(bookIDInput) Then
                        Dim bookID As Integer = Convert.ToInt32(bookIDInput)

                        Dim connectionString As String = "server=localhost; user=root; password=; database=book-borrowing;"
                        Using conn As New MySqlConnection(connectionString)
                            conn.Open()
                            Dim query As String = "UPDATE book SET Image = @ImagePath WHERE BookID = @BookID"
                            Using cmd As New MySqlCommand(query, conn)
                                cmd.Parameters.AddWithValue("@ImagePath", imagePath)
                                cmd.Parameters.AddWithValue("@BookID", bookID)
                                cmd.ExecuteNonQuery()
                            End Using
                        End Using

                        MessageBox.Show("Image uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadBookData()
                    Else
                        MessageBox.Show("Invalid BookID. Image upload canceled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End Using
        End If
    End Sub


    Private Sub LoadBookData(Optional searchQuery As String = "")
        Dim connectionString As String = "server=localhost; user=root; password=; database=book-borrowing;"
        Dim query As String = "SELECT BookID, Title, Author, Year, ISBN, Category, Copies FROM book"

        If Not String.IsNullOrEmpty(searchQuery) Then
            query &= " WHERE Title LIKE @searchQuery OR Author LIKE @searchQuery OR Category LIKE @searchQuery"
        End If

        Dim dt As New DataTable()

        Using connection As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, connection)
                If Not String.IsNullOrEmpty(searchQuery) Then
                    cmd.Parameters.AddWithValue("@searchQuery", "%" & searchQuery & "%")
                End If
                connection.Open()
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    dt.Load(reader)
                End Using
            End Using
        End Using

        DataGridView1.DataSource = dt

        If Not DataGridView1.Columns.Contains("Delete") Then
            Dim deleteColumn As New DataGridViewCheckBoxColumn()
            deleteColumn.Name = "Delete"
            deleteColumn.HeaderText = "Delete"
            DataGridView1.Columns.Add(deleteColumn)
        End If

        DataGridView1.Columns("Delete").DisplayIndex = DataGridView1.Columns.Count - 1
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = DataGridView1.Columns("Delete").Index AndAlso e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim isChecked As Boolean = Convert.ToBoolean(row.Cells("Delete").Value)

            If isChecked Then
                Dim confirmDelete As DialogResult = MessageBox.Show("Are you sure you want to delete this book?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                If confirmDelete = DialogResult.Yes Then
                    Dim bookID As Integer = Convert.ToInt32(row.Cells("BookID").Value)
                    Dim connectionString As String = "server=localhost; user=root; password=; database=book-borrowing;"

                    Using connection As New MySqlConnection(connectionString)
                        connection.Open()
                        Dim deleteQuery As String = "DELETE FROM book WHERE BookID = @bookID"
                        Using deleteCmd As New MySqlCommand(deleteQuery, connection)
                            deleteCmd.Parameters.AddWithValue("@bookID", bookID)
                            deleteCmd.ExecuteNonQuery()
                        End Using
                    End Using

                    DataGridView1.Rows.RemoveAt(e.RowIndex)
                    MessageBox.Show("Book deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    row.Cells("Delete").Value = False
                End If
            End If
        End If
    End Sub


    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            If DataGridView1.Columns(e.ColumnIndex).Name = "Delete" Then
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim isChecked As Boolean = Convert.ToBoolean(row.Cells("Delete").Value)

                If isChecked Then
                    Dim confirmDelete As DialogResult = MessageBox.Show("Are you sure you want to delete this book?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                    If confirmDelete = DialogResult.Yes Then
                        Dim bookID As Integer = Convert.ToInt32(row.Cells("BookID").Value)
                        Dim connectionString As String = "server=localhost; user=root; password=; database=book-borrowing;"

                        Using connection As New MySqlConnection(connectionString)
                            connection.Open()
                            Dim deleteQuery As String = "DELETE FROM book WHERE BookID = @bookID"
                            Using deleteCmd As New MySqlCommand(deleteQuery, connection)
                                deleteCmd.Parameters.AddWithValue("@bookID", bookID)
                                deleteCmd.ExecuteNonQuery()
                            End Using
                        End Using

                        DataGridView1.Rows.RemoveAt(e.RowIndex)
                        MessageBox.Show("Book deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        row.Cells("Delete").Value = False
                    End If
                End If
            End If
        End If
    End Sub


    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBookData()
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim searchQuery As String = TextBox1.Text.Trim()
        LoadBookData(searchQuery)
    End Sub

End Class
