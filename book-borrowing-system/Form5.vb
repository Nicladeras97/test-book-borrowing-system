Imports System.IO
Imports OfficeOpenXml
Imports MySql.Data.MySqlClient

Public Class Form5
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim addBook As New Form10
        addBook.Show()
        Hide()
    End Sub

    ' Download Book Import Template
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            ExcelPackage.License.SetNonCommercialPersonal("book-borrowing-system")

            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"
            saveFileDialog.FileName = "Book_Import_Template.xlsx"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim filePath As String = saveFileDialog.FileName

                Using package As New ExcelPackage()
                    Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.Add("Template")

                    ' Add headers with Copies column
                    Dim headers As String() = {"Title", "Author", "Year", "Publisher", "Section", "CallNumber", "Rack", "ISBN", "Copies"}
                    For col As Integer = 0 To headers.Length - 1
                        worksheet.Cells(1, col + 1).Value = headers(col)
                    Next

                    ' Sample Data
                    worksheet.Cells(2, 1).Value = "The Great Gatsby"
                    worksheet.Cells(2, 2).Value = "F. Scott Fitzgerald"
                    worksheet.Cells(2, 3).Value = "1925"
                    worksheet.Cells(2, 4).Value = "Scribner"
                    worksheet.Cells(2, 5).Value = "Fiction"
                    worksheet.Cells(2, 6).Value = "REF E 222 CE74 2001"
                    worksheet.Cells(2, 7).Value = "R2"
                    worksheet.Cells(2, 8).Value = "123456789"
                    worksheet.Cells(2, 9).Value = "3"  ' Number of copies

                    worksheet.Cells.AutoFitColumns()
                    package.SaveAs(New FileInfo(filePath))

                    MessageBox.Show("Template downloaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Error downloading template: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Generate the next Accno in YYYY000000-XX format
    Private Function GenerateNextAccno(conn As MySqlConnection, copyIndex As Integer) As String
        Dim year As String = DateTime.Now.Year.ToString()
        Dim query As String = $"SELECT MAX(Accno) FROM books WHERE Accno LIKE '{year}%'"

        Using cmd As New MySqlCommand(query, conn)
            Dim lastAccno As Object = cmd.ExecuteScalar()
            Dim nextNumber As Integer = 1

            If lastAccno IsNot DBNull.Value AndAlso lastAccno IsNot Nothing Then
                Dim lastNumber As String = lastAccno.ToString().Substring(4, 6)
                nextNumber = Integer.Parse(lastNumber) + 1
            End If

            Return $"{year}{nextNumber:000000}-{copyIndex:00}"
        End Using
    End Function

    ' Import Excel into Database with multiple copies support
    Private Sub ImportExcelToDatabase(filePath As String)
        Try
            ExcelPackage.License.SetNonCommercialPersonal("book-borrowing-system")

            Using package As New ExcelPackage(New FileInfo(filePath))
                Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets(0)

                Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")
                conn.Open()

                Using transaction As MySqlTransaction = conn.BeginTransaction()
                    Try
                        For row As Integer = 2 To worksheet.Dimension.End.Row
                            Dim title As String = worksheet.Cells(row, 1).Text
                            Dim author As String = worksheet.Cells(row, 2).Text
                            Dim year As String = worksheet.Cells(row, 3).Text
                            Dim publisher As String = worksheet.Cells(row, 4).Text
                            Dim section As String = worksheet.Cells(row, 5).Text
                            Dim callNumber As String = worksheet.Cells(row, 6).Text
                            Dim rack As String = worksheet.Cells(row, 7).Text
                            Dim isbn As String = worksheet.Cells(row, 8).Text
                            Dim copies As Integer = If(Integer.TryParse(worksheet.Cells(row, 9).Text, Nothing), Convert.ToInt32(worksheet.Cells(row, 9).Text), 1)

                            ' Validate Year
                            Dim yearInt As Integer
                            If Not Integer.TryParse(year, yearInt) OrElse yearInt < 1800 OrElse yearInt > DateTime.Now.Year Then
                                MessageBox.Show($"Invalid year at row {row}. Skipping...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Continue For
                            End If

                            ' Insert multiple copies
                            For copyIndex As Integer = 0 To copies - 1
                                Dim newAccno As String = GenerateNextAccno(conn, copyIndex)

                                Dim insertQuery As String = "
                                INSERT INTO books (Accno, Title, Author, Year, Publisher, Section, AddedDate, CallNumber, Rack, ISBN)
                                VALUES (@Accno, @Title, @Author, @Year, @Publisher, @Section, @AddedDate, @CallNumber, @Rack, @ISBN)"

                                Using cmd As New MySqlCommand(insertQuery, conn, transaction)
                                    cmd.Parameters.AddWithValue("@Accno", newAccno)
                                    cmd.Parameters.AddWithValue("@Title", title)
                                    cmd.Parameters.AddWithValue("@Author", author)
                                    cmd.Parameters.AddWithValue("@Year", yearInt)
                                    cmd.Parameters.AddWithValue("@Publisher", publisher)
                                    cmd.Parameters.AddWithValue("@Section", section)
                                    cmd.Parameters.AddWithValue("@AddedDate", DateTime.Now)
                                    cmd.Parameters.AddWithValue("@CallNumber", callNumber)
                                    cmd.Parameters.AddWithValue("@Rack", rack)
                                    cmd.Parameters.AddWithValue("@ISBN", isbn)
                                    cmd.ExecuteNonQuery()
                                End Using
                            Next
                        Next

                        transaction.Commit()
                        MessageBox.Show("Books imported successfully with multiple copies!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Catch ex As Exception
                        transaction.Rollback()
                        MessageBox.Show("Error importing data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
                conn.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
