Imports MySql.Data.MySqlClient
Imports OfficeOpenXml
Imports System.IO
Public Class Form5

    Private currentPage As Integer = 1
    Private totalPages As Integer = 1

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBookData()
    End Sub

    Private Sub LoadBookData(Optional searchQuery As String = "")
        Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")

        Try
            conn.Open()

            Dim filter As String = ""
            If Not String.IsNullOrEmpty(searchQuery) Then
                filter = "WHERE Title LIKE @Search OR Author LIKE @Search OR Section LIKE @Search OR Publisher LIKE @Search OR CallNumber LIKE @Search OR Rack LIKE @Search"
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

            If currentPage < 1 Then currentPage = 1
            If currentPage > totalPages Then currentPage = totalPages

            Dim offset As Integer = (currentPage - 1) * pageSize
            offset = Math.Max(0, offset)

            Dim query As String = $"SELECT BookID, ISBN, Title, Author, Year, Publisher, Section, Status, Image, Copies, AddedDate, CallNumber, Rack FROM book {filter} LIMIT {offset}, {pageSize}"
            Dim dt As New DataTable()

            Using cmd As New MySqlCommand(query, conn)
                If Not String.IsNullOrEmpty(searchQuery) Then
                    cmd.Parameters.AddWithValue("@Search", "%" & searchQuery & "%")
                End If

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using

            DataGridView1.DataSource = dt
            DataGridView1.Refresh()

            Button7.Enabled = (currentPage > 1)
            Button6.Enabled = (currentPage < totalPages)

            If Not DataGridView1.Columns.Contains("Delete") Then
                Dim deleteColumn As New DataGridViewCheckBoxColumn()
                deleteColumn.Name = "Delete"
                deleteColumn.HeaderText = "Delete"
                DataGridView1.Columns.Add(deleteColumn)
            End If

            If Not DataGridView1.Columns.Contains("Edit") Then
                Dim editButton As New DataGridViewButtonColumn()
                editButton.Name = "Edit"
                editButton.HeaderText = "Action"
                editButton.Text = "Edit"
                editButton.UseColumnTextForButtonValue = True
                DataGridView1.Columns.Add(editButton)
            End If

            DataGridView1.Columns("Edit").DisplayIndex = DataGridView1.Columns.Count - 2
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
        If e.RowIndex < 0 Then Exit Sub

        If e.ColumnIndex = DataGridView1.Columns("Delete").Index Then
            Dim confirmDelete As DialogResult = MessageBox.Show("Are you sure you want to delete this book?", "Delete Confirmation",
                                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If confirmDelete = DialogResult.Yes Then
                Dim BookID As String = DataGridView1.Rows(e.RowIndex).Cells("BookID").Value.ToString()
                DeleteBook(BookID)
            End If
        End If

        If e.ColumnIndex = DataGridView1.Columns("Edit").Index Then
            Dim selectedBookID As String = DataGridView1.Rows(e.RowIndex).Cells("BookID").Value.ToString()

            Dim editForm As New Form13
            editForm.BookID = selectedBookID

            If editForm.ShowDialog() = DialogResult.OK Then
                LoadBookData()
            End If
        End If
    End Sub


    Private Sub DeleteBook(BookID As String)
        Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")

        Try
            conn.Open()

            Using transaction As MySqlTransaction = conn.BeginTransaction()
                Try
                    Dim deleteCopiesQuery As String = "DELETE FROM copies WHERE BookID = @BookID"
                    Using cmd As New MySqlCommand(deleteCopiesQuery, conn)
                        cmd.Parameters.AddWithValue("@BookID", BookID)
                        cmd.Transaction = transaction
                        cmd.ExecuteNonQuery()
                    End Using

                    Dim deleteBookQuery As String = "DELETE FROM book WHERE BookID = @BookID"
                    Using cmd As New MySqlCommand(deleteBookQuery, conn)
                        cmd.Parameters.AddWithValue("@BookID", BookID)
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"
            saveFileDialog.FileName = "Book_Import_Template.xlsx"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim filePath As String = saveFileDialog.FileName

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial
                Using package As New ExcelPackage()
                    Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.Add("Template")

                    worksheet.Cells(1, 1).Value = "ISBN"
                    worksheet.Cells(1, 2).Value = "Title"
                    worksheet.Cells(1, 3).Value = "Author"
                    worksheet.Cells(1, 4).Value = "Year"
                    worksheet.Cells(1, 5).Value = "Publisher"
                    worksheet.Cells(1, 6).Value = "Section"
                    worksheet.Cells(1, 7).Value = "Copies"
                    worksheet.Cells(1, 8).Value = "CallNumber"
                    worksheet.Cells(1, 9).Value = "Rack"

                    Using headerRange = worksheet.Cells("A1:H1")
                        headerRange.Style.Font.Bold = True
                        headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                        headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray)
                    End Using

                    worksheet.Cells(2, 1).Value = "978-0000000000"
                    worksheet.Cells(2, 2).Value = "The Great Gatsby"
                    worksheet.Cells(2, 3).Value = "F. Scott Fitzgerald"
                    worksheet.Cells(2, 4).Value = "1925"
                    worksheet.Cells(2, 5).Value = "Scribner"
                    worksheet.Cells(2, 6).Value = "Fiction"
                    worksheet.Cells(2, 7).Value = "3"
                    worksheet.Cells(2, 8).Value = "PS3511.F45 G7"
                    worksheet.Cells(2, 9).Value = "R2"

                    Dim file = New FileInfo(filePath)
                    package.SaveAs(file)
                End Using

                MessageBox.Show("Template downloaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error downloading template: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim addBookForm As New Form10()
        addBookForm.BookID = ""
        If addBookForm.ShowDialog() = DialogResult.OK Then
            LoadBookData()
        End If
    End Sub

    Private Function GenerateNextBookID(conn As MySqlConnection, section As String, year As String) As String
        Dim prefix As String = section.Substring(0, Math.Min(3, section.Length)).ToUpper() & year

        Dim query As String = $"SELECT MAX(BookID) FROM book WHERE BookID LIKE '{prefix}%'"
        Using cmd As New MySqlCommand(query, conn)
            Dim lastID As Object = cmd.ExecuteScalar()

            Dim nextNumber As Integer = 1
            If lastID IsNot DBNull.Value AndAlso lastID IsNot Nothing Then
                Dim lastNumber As String = lastID.ToString().Substring(7, 4)
                nextNumber = Integer.Parse(lastNumber) + 1
            End If

            Return $"{prefix}{nextNumber:0000}"
        End Using
    End Function
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"
        openFileDialog.Title = "Select Excel File to Import"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = openFileDialog.FileName

            Try
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial

                Using package As New ExcelPackage(New FileInfo(filePath))
                    Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets(0)

                    Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")
                    conn.Open()

                    Using transaction As MySqlTransaction = conn.BeginTransaction()
                        Try
                            For row As Integer = 2 To worksheet.Dimension.End.Row

                                Dim isbn As String = worksheet.Cells(row, 1).Text
                                Dim title As String = worksheet.Cells(row, 2).Text
                                Dim author As String = worksheet.Cells(row, 3).Text
                                Dim year As String = worksheet.Cells(row, 4).Text
                                Dim publisher As String = worksheet.Cells(row, 5).Text
                                Dim section As String = worksheet.Cells(row, 6).Text
                                Dim copiesText As String = worksheet.Cells(row, 7).Text
                                Dim callNumber As String = worksheet.Cells(row, 8).Text
                                Dim rack As String = worksheet.Cells(row, 9).Text

                                title = title.Substring(0, Math.Min(title.Length, 255))
                                author = author.Substring(0, Math.Min(author.Length, 255))
                                publisher = publisher.Substring(0, Math.Min(publisher.Length, 100))
                                section = section.Substring(0, Math.Min(section.Length, 100))
                                callNumber = callNumber.Substring(0, Math.Min(callNumber.Length, 50))
                                rack = rack.Substring(0, Math.Min(rack.Length, 10))
                                isbn = isbn.Substring(0, Math.Min(isbn.Length, 50))

                                Dim yearInt As Integer
                                If Not Integer.TryParse(year, yearInt) OrElse yearInt < 1800 OrElse yearInt > DateTime.Now.Year Then
                                    MessageBox.Show($"Invalid year at row {row}. Skipping...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Continue For
                                End If

                                Dim copies As Integer
                                If Not Integer.TryParse(copiesText, copies) OrElse copies < 1 Then
                                    MessageBox.Show($"Invalid copies value at row {row}. Skipping...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Continue For
                                End If

                                Dim baseBookID As String = GenerateNextBookID(conn, section, year)

                                For i As Integer = 1 To copies
                                    Dim bookID As String = baseBookID

                                    Dim copyID As String = $"{bookID}-{i:00}"

                                    If i = 1 Then
                                        Dim query As String = "
                                        INSERT INTO book (BookID, ISBN, Title, Author, Year, Publisher, Section, Status, Copies, AddedDate, CallNumber, Rack)
                                        VALUES (@BookID, @ISBN, @Title, @Author, @Year, @Publisher, @Section, 'Available', @Copies, @AddedDate, @CallNumber, @Rack)"

                                        Using cmd As New MySqlCommand(query, conn, transaction)
                                            cmd.Parameters.AddWithValue("@BookID", bookID)
                                            cmd.Parameters.AddWithValue("@ISBN", isbn)
                                            cmd.Parameters.AddWithValue("@Title", title)
                                            cmd.Parameters.AddWithValue("@Author", author)
                                            cmd.Parameters.AddWithValue("@Year", yearInt)
                                            cmd.Parameters.AddWithValue("@Publisher", publisher)
                                            cmd.Parameters.AddWithValue("@Section", section)
                                            cmd.Parameters.AddWithValue("@Copies", copies)
                                            cmd.Parameters.AddWithValue("@AddedDate", DateTime.Now)
                                            cmd.Parameters.AddWithValue("@CallNumber", callNumber)
                                            cmd.Parameters.AddWithValue("@Rack", rack)
                                            cmd.ExecuteNonQuery()
                                        End Using
                                    End If

                                    Dim copyQuery As String = "
                                    INSERT INTO copies (CopyID, ISBN, Status, BookID)
                                    VALUES (@CopyID, @ISBN, 'Available', @BookID)"

                                    Using copyCmd As New MySqlCommand(copyQuery, conn, transaction)
                                        copyCmd.Parameters.AddWithValue("@CopyID", copyID)
                                        copyCmd.Parameters.AddWithValue("@ISBN", isbn)
                                        copyCmd.Parameters.AddWithValue("@BookID", bookID)
                                        copyCmd.ExecuteNonQuery()
                                    End Using
                                Next
                            Next

                            transaction.Commit()
                            MessageBox.Show("Books imported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            LoadBookData()

                        Catch ex As Exception
                            transaction.Rollback()
                            MessageBox.Show("Error importing data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Using
                    conn.Close()
                End Using

            Catch ex As Exception
                MessageBox.Show("Error reading Excel file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim back As New Form4
        back.Show()
        Me.Hide()
    End Sub
End Class
