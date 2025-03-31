Imports System.IO
Imports OfficeOpenXml
Imports MySql.Data.MySqlClient

Public Class Form5

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim addBook As New Form10
        addBook.Show()
        Hide()
    End Sub

    'Book Template
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
        Dim openFileDialog As New OpenFileDialog
        openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"

        If openFileDialog.ShowDialog = DialogResult.OK Then
            ImportExcelToDatabase(openFileDialog.FileName)
        End If
    End Sub

    'Import
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim edit As New Form13
        edit.Show()
        Me.Hide()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim deletebook As New Form2
        deletebook.Show()
        Me.Hide()
    End Sub
End Class
