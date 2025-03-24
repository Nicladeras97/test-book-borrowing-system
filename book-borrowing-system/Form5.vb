Imports MySql.Data.MySqlClient
Imports OfficeOpenXml
Imports System.IO
Public Class Form5

    Private currentPage As Integer = 1
    Private totalPages As Integer = 1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim add As New Form10
        add.Show()
        Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim back As New Form4
        back.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Using saveFileDialog As New SaveFileDialog
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"
            saveFileDialog.Title = "Save Template File"
            saveFileDialog.FileName = "Book_Import_Template.xlsx"

            If saveFileDialog.ShowDialog = DialogResult.OK Then
                GenerateExcelTemplate(saveFileDialog.FileName)
                MessageBox.Show("Template downloaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    Private Sub GenerateExcelTemplate(filePath As String)
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial

        Using package As New ExcelPackage()
            Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.Add("Books Template")

            worksheet.Cells(1, 1).Value = "ISBN"
            worksheet.Cells(1, 2).Value = "Title"
            worksheet.Cells(1, 3).Value = "Author"
            worksheet.Cells(1, 4).Value = "Year"
            worksheet.Cells(1, 5).Value = "Category"
            worksheet.Cells(1, 6).Value = "Status"
            worksheet.Cells(1, 7).Value = "Copies"
            worksheet.Cells(1, 8).Value = "AddedDate"
            worksheet.Cells(1, 9).Value = "CallNumber"

            worksheet.Cells(2, 1).Value = "978-0-06-279715-5"
            worksheet.Cells(2, 2).Value = "Sample Book Title"
            worksheet.Cells(2, 3).Value = "John Doe"
            worksheet.Cells(2, 4).Value = "2023"
            worksheet.Cells(2, 5).Value = "Fiction"
            worksheet.Cells(2, 6).Value = "Available"
            worksheet.Cells(2, 7).Value = "1"
            worksheet.Cells(2, 8).Value = DateTime.Now.ToString("yyyy-MM-dd")
            worksheet.Cells(2, 9).Value = "FIC DOE 2023"

            Using headerRange = worksheet.Cells("A1:I1")
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
                    Dim isbn As String = worksheet.Cells(i, 1).Text.Trim()
                    Dim title As String = worksheet.Cells(i, 2).Text.Trim()
                    Dim author As String = worksheet.Cells(i, 3).Text.Trim()
                    Dim year As String = worksheet.Cells(i, 4).Text.Trim()
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

        MessageBox.Show($"✅ Imported: {importedCount}{vbCrLf}🚫 Skipped (Duplicate): {skippedCount}", "Import Summary", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

                    Dim isbnInput As String = InputBox("Enter the ISBN to associate this image:", "ISBN", "")
                    If Not String.IsNullOrEmpty(isbnInput) Then
                        Dim isbn As String = isbnInput

                        Dim connectionString As String = "server=localhost; user=root; password=; database=book-borrowing;"
                        Using conn As New MySqlConnection(connectionString)
                            conn.Open()
                            Dim query As String = "UPDATE book SET Image = @ImagePath WHERE ISBN = @ISBN"
                            Using cmd As New MySqlCommand(query, conn)
                                cmd.Parameters.AddWithValue("@ImagePath", imagePath)
                                cmd.Parameters.AddWithValue("@ISBN", isbn)
                                cmd.ExecuteNonQuery()
                            End Using
                        End Using

                        MessageBox.Show("Image uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadBookData()
                    Else
                        MessageBox.Show("Invalid ISBN. Image upload canceled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End Using
        End If
    End Sub

    Private Sub LoadBookData(Optional searchQuery As String = "")
        Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")

        Try
            conn.Open()

            Dim filter As String = ""
            If Not String.IsNullOrEmpty(searchQuery) Then
                filter = "WHERE Title LIKE @Search OR Author LIKE @Search OR Category LIKE @Search OR ISBN LIKE @Search OR CallNumber LIKE @Search"
            End If

            Dim countQuery As String = $"SELECT COUNT(*) FROM book {filter}"
            Dim totalRecords As Integer
            Using cmd As New MySqlCommand(countQuery, conn)
                If Not String.IsNullOrEmpty(searchQuery) Then
                    cmd.Parameters.AddWithValue("@Search", "%" & searchQuery & "%")
                End If
                totalRecords = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

            Dim pageSize As Integer = 20

            totalPages = Math.Ceiling(totalRecords / pageSize)

            If currentPage < 1 Then
                currentPage = 1
            ElseIf currentPage > totalPages Then
                currentPage = totalPages
            End If

            Dim offset As Integer = (currentPage - 1) * pageSize

            Dim query As String = $"SELECT ISBN, Title, Author, Year, Category, Status, Image, Copies, AddedDate, CallNumber FROM book {filter} LIMIT {offset}, {pageSize}"

            Dim dt As New DataTable()

            Using cmd As New MySqlCommand(query, conn)
                If Not String.IsNullOrEmpty(searchQuery) Then
                    cmd.Parameters.AddWithValue("@Search", "%" & searchQuery & "%")
                End If

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using

            If dt.Rows.Count = 0 Then
                MessageBox.Show("No books found in the database.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            DataGridView1.DataSource = dt
            DataGridView1.Refresh()

            Button3.Enabled = (currentPage > 1)
            Button2.Enabled = (currentPage < totalPages)

            If Not DataGridView1.Columns.Contains("Delete") Then
                Dim deleteColumn As New DataGridViewCheckBoxColumn()
                deleteColumn.Name = "Delete"
                deleteColumn.HeaderText = "Delete"
                DataGridView1.Columns.Add(deleteColumn)
            End If

            DataGridView1.Columns("Delete").DisplayIndex = DataGridView1.Columns.Count - 1
            DataGridView1.AutoResizeColumns()

            Label2.Text = $"{currentPage}/{totalPages}"

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If currentPage > 1 Then
            currentPage -= 1
            LoadBookData()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If currentPage < totalPages Then
            currentPage += 1
            LoadBookData()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = DataGridView1.Columns("Delete").Index AndAlso e.RowIndex >= 0 Then
            Dim confirmDelete As DialogResult = MessageBox.Show("Are you sure you want to delete this book?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If confirmDelete = DialogResult.Yes Then
                Dim ISBN As String = DataGridView1.Rows(e.RowIndex).Cells("ISBN").Value.ToString()

                DeleteBook(ISBN)
            End If
        End If
    End Sub

    Private Sub DeleteBook(ISBN As String)
        Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")
        Try
            conn.Open()

            Using transaction As MySqlTransaction = conn.BeginTransaction()
                Try
                    Dim deleteCopiesQuery As String = "DELETE FROM copies WHERE ISBN = @ISBN"
                    Using cmd As New MySqlCommand(deleteCopiesQuery, conn)
                        cmd.Parameters.AddWithValue("@ISBN", ISBN)
                        cmd.Transaction = transaction
                        cmd.ExecuteNonQuery()
                    End Using

                    Dim deleteBookQuery As String = "DELETE FROM book WHERE ISBN = @ISBN"
                    Using cmd As New MySqlCommand(deleteBookQuery, conn)
                        cmd.Parameters.AddWithValue("@ISBN", ISBN)
                        cmd.Transaction = transaction
                        cmd.ExecuteNonQuery()
                    End Using

                    transaction.Commit()

                    LoadBookData()

                    MessageBox.Show("Book and its copies deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    transaction.Rollback()
                    MessageBox.Show("Error deleting book and copies: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBookData()
    End Sub
End Class
