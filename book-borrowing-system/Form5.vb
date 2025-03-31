Imports System.IO
Imports OfficeOpenXml
Imports MySql.Data.MySqlClient

Public Class Form5
    Private pageSize As Integer = 20
    Private currentPage As Integer = 1
    Private totalRecords As Integer = 0

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()

        If Not DataGridView1.Columns.Contains("Delete") Then
            Dim deleteButton As New DataGridViewButtonColumn()
            deleteButton.HeaderText = "Action"
            deleteButton.Text = "Delete"
            deleteButton.Name = "Delete"
            deleteButton.UseColumnTextForButtonValue = True
            DataGridView1.Columns.Add(deleteButton)
        End If

        If Not DataGridView1.Columns.Contains("Edit") Then
            Dim editButton As New DataGridViewButtonColumn()
            editButton.HeaderText = "Action"
            editButton.Text = "Edit"
            editButton.Name = "Edit"
            editButton.UseColumnTextForButtonValue = True
            DataGridView1.Columns.Add(editButton)
        End If

        DataGridView1.Columns("Edit").DisplayIndex = DataGridView1.Columns.Count - 1
        DataGridView1.Columns("Delete").DisplayIndex = DataGridView1.Columns.Count - 1
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        currentPage = 1
        LoadData()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If currentPage > 1 Then
            currentPage -= 1
            LoadData()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim totalPages As Integer = Math.Ceiling(totalRecords / pageSize)
        If currentPage < totalPages Then
            currentPage += 1
            LoadData()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim addBook As New Form10()
        addBook.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"
            saveFileDialog.FileName = "Book_Import_Template.xlsx"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim filePath As String = saveFileDialog.FileName

                'ExcelPackage.LicenseContext = LicenseContext.NonCommercial
                Using package As New ExcelPackage()
                    Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.Add("Template")

                    Dim headers As String() = {"Title", "Author", "Year", "Publisher", "Section", "Copies", "CallNumber", "Rack", "ISBN"}
                    For col As Integer = 0 To headers.Length - 1
                        worksheet.Cells(1, col + 1).Value = headers(col)
                    Next

                    Dim headerRange = worksheet.Cells("A1:I1")
                    headerRange.Style.Font.Bold = True
                    headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                    headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray)

                    Dim sampleData As String(,) = {
                        {"The Great Gatsby", "F. Scott Fitzgerald", "1925", "Scribner", "Fiction", "3", "REF E 222 CE74 2001", "R2", "123456789"}
                    }

                    For col As Integer = 0 To sampleData.GetLength(1) - 1
                        worksheet.Cells(2, col + 1).Value = sampleData(0, col)
                    Next

                    worksheet.Cells.AutoFitColumns()

                    package.SaveAs(New FileInfo(filePath))

                    MessageBox.Show("Template downloaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Error downloading template: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim back As New Form4()
        back.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ImportExcelToDatabase(openFileDialog.FileName)
        End If
    End Sub

    Private Sub ImportExcelToDatabase(filePath As String)
        Dim connectionString As String = "server=localhost; user=root; password=; database=book-borrowing;"
        'ExcelPackage.LicenseContext = LicenseContext.NonCommercial

        Dim importedCount As Integer = 0
        Dim addedCopies As Integer = 0

        Using package As New ExcelPackage(New FileInfo(filePath))
            Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets(0)
            Dim rowCount As Integer = worksheet.Dimension.Rows

            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                For i As Integer = 2 To rowCount
                    Dim title As String = worksheet.Cells(i, 1).Text.Trim()
                    Dim author As String = worksheet.Cells(i, 2).Text.Trim()
                    Dim year As String = worksheet.Cells(i, 3).Text.Trim()
                    Dim publisher As String = worksheet.Cells(i, 4).Text.Trim()
                    Dim section As String = worksheet.Cells(i, 5).Text.Trim()
                    Dim copiesText As String = worksheet.Cells(i, 6).Text.Trim()
                    Dim callNumber As String = worksheet.Cells(i, 7).Text.Trim()
                    Dim rack As String = worksheet.Cells(i, 8).Text.Trim()
                    Dim isbn As String = worksheet.Cells(i, 9).Text.Trim()

                    Dim copies As Integer
                    If Not Integer.TryParse(copiesText, copies) OrElse copies <= 0 Then
                        copies = 1
                    End If

                    Dim lastAccno As String = GetLastAccnoByISBN(connection, isbn, section, year)
                    If String.IsNullOrEmpty(lastAccno) Then lastAccno = $"{section}{year}0000-00"


                    For copyIndex As Integer = 1 To copies
                        Dim newAccno As String = GenerateAccno(section, year, lastAccno, copyIndex)
                        If String.IsNullOrEmpty(newAccno) Then
                            MessageBox.Show("Error generating Accno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If


                        Dim query As String = "INSERT INTO books (Accno, Title, Author, Year, Publisher, Section, CallNumber, Rack, ISBN) " &
                                             "VALUES (@Accno, @Title, @Author, @Year, @Publisher, @Section, @CallNumber, @Rack, @ISBN)"
                        Using cmd As New MySqlCommand(query, connection)
                            cmd.Parameters.AddWithValue("@Accno", newAccno)
                            cmd.Parameters.AddWithValue("@Title", title)
                            cmd.Parameters.AddWithValue("@Author", author)
                            cmd.Parameters.AddWithValue("@Year", year)
                            cmd.Parameters.AddWithValue("@Publisher", publisher)
                            cmd.Parameters.AddWithValue("@Section", section)
                            cmd.Parameters.AddWithValue("@CallNumber", callNumber)
                            cmd.Parameters.AddWithValue("@Rack", rack)
                            cmd.Parameters.AddWithValue("@ISBN", isbn)

                            cmd.ExecuteNonQuery()
                            importedCount += 1
                        End Using
                    Next
                Next
            End Using
        End Using

        MessageBox.Show($"Imported: {importedCount} new books, {addedCopies} copies added to existing books.", "Import Summary", MessageBoxButtons.OK, MessageBoxIcon.Information)

        LoadData()
    End Sub

    Private Function GetLastAccno(connection As MySqlConnection, section As String, year As String) As String
        Dim prefix As String = section.Substring(0, 3).ToUpper() & year
        Dim query As String = "SELECT MAX(Accno) FROM books WHERE Accno LIKE @Prefix"
        Using cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@Prefix", prefix & "%")
            Dim result = cmd.ExecuteScalar()?.ToString()
            If String.IsNullOrEmpty(result) Then Return "0000"
            Return result.Substring(7, 4)
        End Using
    End Function

    Private Function GenerateAccno(section As String, year As String, lastAccno As String, copyIndex As Integer) As String
        Dim prefix As String = section.Substring(0, 3).ToUpper() & year
        Dim lastNumber As Integer = 0
        Dim lastCopy As Integer = 0

        If Not String.IsNullOrEmpty(lastAccno) AndAlso lastAccno.Length >= 13 Then
            Dim parts As String() = lastAccno.Split("-")

            If parts.Length = 2 AndAlso parts(0).Length >= 11 AndAlso IsNumeric(parts(0).Substring(7, 4)) AndAlso IsNumeric(parts(1)) Then
                lastNumber = Integer.Parse(parts(0).Substring(7, 4))
                lastCopy = Integer.Parse(parts(1))
            End If
        End If

        If copyIndex = 1 Then
            lastNumber += 1
            lastCopy = 1
        Else
            lastCopy += 1
        End If

        Dim formattedNumber As String = lastNumber.ToString("D4")
        Dim formattedCopy As String = lastCopy.ToString("D2")

        Return $"{prefix}{formattedNumber}-{formattedCopy}"
    End Function

    Private Function GetLastAccnoByISBN(connection As MySqlConnection, isbn As String, section As String, year As String) As String
        Dim prefix As String = section.Substring(0, 3).ToUpper() & year
        Dim query As String = "SELECT MAX(Accno) FROM books WHERE ISBN = @ISBN AND Accno LIKE @Prefix"

        Using cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@ISBN", isbn)
            cmd.Parameters.AddWithValue("@Prefix", prefix & "%")

            Dim result As Object = cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not String.IsNullOrEmpty(result.ToString()) Then
                Return result.ToString().Substring(7, 4)
            End If
        End Using

        Return "0000"
    End Function



    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Try
                Dim accNo As String = DataGridView1.Rows(e.RowIndex).Cells("Acc. No.").Value.ToString()

                If e.ColumnIndex = DataGridView1.Columns("Delete").Index Then
                    Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete book with Accession No: {accNo}?",
                                                             "Confirm Delete",
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Warning)
                    If result = DialogResult.Yes Then
                        DeleteBook(accNo)
                    End If
                End If

                If e.ColumnIndex = DataGridView1.Columns("Edit").Index Then
                    Dim title As String = DataGridView1.Rows(e.RowIndex).Cells("Title").Value.ToString()
                    Dim author As String = DataGridView1.Rows(e.RowIndex).Cells("Author").Value.ToString()
                    Dim year As String = DataGridView1.Rows(e.RowIndex).Cells("Year").Value.ToString()
                    Dim publisher As String = DataGridView1.Rows(e.RowIndex).Cells("Publisher").Value.ToString()
                    Dim isbn As String = DataGridView1.Rows(e.RowIndex).Cells("ISBN").Value.ToString()
                    Dim section As String = DataGridView1.Rows(e.RowIndex).Cells("Section").Value.ToString()
                    Dim callNumber As String = DataGridView1.Rows(e.RowIndex).Cells("CallNumber").Value.ToString()
                    Dim rack As String = DataGridView1.Rows(e.RowIndex).Cells("Rack").Value.ToString()

                    Dim editForm As New Form13()
                    editForm.SetBookDetails(accNo, title, author, year, publisher, isbn, section, callNumber, rack)
                    editForm.ShowDialog()

                    LoadData()
                End If

            Catch ex As Exception
                MessageBox.Show($"Error: {ex.Message}")
            End Try
        End If
    End Sub

    Private Sub DeleteBook(accNo As String)
        Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")

        Try
            conn.Open()

            Dim checkBorrowedQuery As String = "SELECT COUNT(*) FROM books_borrowed WHERE book_id = @Accno"
            Using cmd As New MySqlCommand(checkBorrowedQuery, conn)
                cmd.Parameters.AddWithValue("@Accno", accNo)
                Dim isBorrowed As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                If isBorrowed > 0 Then
                    MessageBox.Show("This book is still borrowed and cannot be deleted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End Using

            Dim checkReturnedQuery As String = "SELECT COUNT(*) FROM returned_books WHERE book_id = @Accno"
            Using cmd As New MySqlCommand(checkReturnedQuery, conn)
                cmd.Parameters.AddWithValue("@Accno", accNo)
                Dim isReturned As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                If isReturned = 0 Then
                    MessageBox.Show("This book has never been returned and cannot be deleted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End Using

            Dim deleteBookQuery As String = "DELETE FROM books WHERE Accno = @Accno"
            Using cmd As New MySqlCommand(deleteBookQuery, conn)
                cmd.Parameters.AddWithValue("@Accno", accNo)
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MessageBox.Show("Book deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadData()
                Else
                    MessageBox.Show("Failed to delete the book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}")
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadData()
        Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")

        Try
            conn.Open()

            Dim searchQuery As String = ""
            If Not String.IsNullOrWhiteSpace(TextBox1.Text) Then
                searchQuery = "WHERE (b.Title LIKE @Search OR b.Author LIKE @Search OR b.Accno LIKE @Search OR b.Section LIKE @Search)"
            End If

            Dim countQuery As String = $"SELECT COUNT(*) FROM books b {searchQuery}"

            Using cmd As New MySqlCommand(countQuery, conn)
                If searchQuery <> "" Then
                    cmd.Parameters.AddWithValue("@Search", $"%{TextBox1.Text.Trim()}%")
                End If
                totalRecords = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

            Dim offset As Integer = (currentPage - 1) * pageSize
            Dim query As String = $"
            SELECT 
                b.Accno AS `Acc. No.`,
                b.Title AS `Title`,
                b.Author AS `Author`,
                b.Year AS `Year`,
                b.Section AS `Section`,
                b.CallNumber AS `CallNumber`,
                b.Rack AS `Rack`,
                b.Publisher AS `Publisher`,
                b.ISBN AS `ISBN`
            FROM books b
            {searchQuery}
            LIMIT @Offset, @PageSize"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Offset", offset)
                cmd.Parameters.AddWithValue("@PageSize", pageSize)
                If searchQuery <> "" Then
                    cmd.Parameters.AddWithValue("@Search", $"%{TextBox1.Text.Trim()}%")
                End If

                Dim adapter As New MySqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                DataGridView1.DataSource = table
            End Using

            Dim totalPages As Integer = Math.Ceiling(totalRecords / pageSize)
            Label2.Text = $"{currentPage}/{totalPages}"
            Button7.Enabled = (currentPage > 1)
            Button6.Enabled = (currentPage < totalPages)

        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}")
        Finally
            conn.Close()
        End Try
    End Sub

End Class
