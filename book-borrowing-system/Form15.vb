Imports MySql.Data.MySqlClient
Imports OfficeOpenXml
Imports System.IO

Public Class Form15
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Panel1.BackColor = Color.FromArgb(100, 0, 0, 0)

    End Sub

    Private Sub AddBooksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddBooksToolStripMenuItem.Click
        Dim add As New Form10
        add.Show()
    End Sub

    Private Sub EditBooksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditBooksToolStripMenuItem.Click
        Dim edit As New Form13
        edit.Show()
    End Sub

    Private Sub ImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem.Click
        Dim openFileDialog As New OpenFileDialog
        openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"

        If openFileDialog.ShowDialog = DialogResult.OK Then
            ImportExcelToDatabase(openFileDialog.FileName)
        End If
    End Sub

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

                            Dim yearInt As Integer
                            If Not Integer.TryParse(year, yearInt) OrElse yearInt < 1800 OrElse yearInt > DateTime.Now.Year Then
                                MessageBox.Show($"Invalid year at row {row}. Skipping...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Continue For
                            End If

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

    Private Sub DownloadTemplateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadTemplateToolStripMenuItem.Click
        Try
            ExcelPackage.License.SetNonCommercialPersonal("book-borrowing-system")

            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"
            saveFileDialog.FileName = "Book_Import_Template.xlsx"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim filePath As String = saveFileDialog.FileName

                Using package As New ExcelPackage()
                    Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.Add("Template")

                    Dim headers As String() = {"Title", "Author", "Year", "Publisher", "Section", "CallNumber", "Rack", "ISBN", "Copies"}
                    For col As Integer = 0 To headers.Length - 1
                        worksheet.Cells(1, col + 1).Value = headers(col)
                    Next

                    worksheet.Cells(2, 1).Value = "The Great Gatsby"
                    worksheet.Cells(2, 2).Value = "F. Scott Fitzgerald"
                    worksheet.Cells(2, 3).Value = "1925"
                    worksheet.Cells(2, 4).Value = "Scribner"
                    worksheet.Cells(2, 5).Value = "Fiction"
                    worksheet.Cells(2, 6).Value = "REF E 222 CE74 2001"
                    worksheet.Cells(2, 7).Value = "R2"
                    worksheet.Cells(2, 8).Value = "123456789"
                    worksheet.Cells(2, 9).Value = "3"
                    worksheet.Cells.AutoFitColumns()
                    package.SaveAs(New FileInfo(filePath))

                    MessageBox.Show("Template downloaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Error downloading template: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub REportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REportsToolStripMenuItem.Click
        Dim report As New Form6
        report.Show()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim logout As New Form1
        logout.Show()
        Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim logout As New Form1
        logout.Show()
        Hide()
    End Sub

    Private Sub DeleteBooksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteBooksToolStripMenuItem.Click
        Dim delete As New Form2
        delete.Show()
    End Sub

    Private Sub ReceivedBooksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceivedBooksToolStripMenuItem.Click
        Dim received As New Form9
        received.Show()
    End Sub

    Private Sub LendReceivedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LendReceivedToolStripMenuItem.Click
        Dim lend As New Form8
        lend.Show()
    End Sub

    Private Sub BarcodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BarcodeToolStripMenuItem.Click
        Dim barcode As New Form3
        barcode.Show()
    End Sub

    Private Sub MenuStrip1_Paint(sender As Object, e As PaintEventArgs) Handles MenuStrip1.Paint

        MenuStrip1.BackColor = Color.FromArgb(100, 0, 0, 0)
    End Sub

    Public Class CustomRenderer
        Inherits ToolStripProfessionalRenderer

        Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
            Dim isSubItem As Boolean = TypeOf e.Item.Owner Is ToolStripDropDownMenu

            If e.Item.Selected Then
                ' Hover effect for sub-items
                If isSubItem Then
                    e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(150, 50, 50, 50)), e.Item.ContentRectangle)
                Else
                    ' Hover effect for top-level menu items
                    e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(150, 30, 30, 30)), e.Item.ContentRectangle)
                End If
            Else
                ' Background when not hovered
                If isSubItem Then
                    e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(100, 20, 20, 20)), e.Item.ContentRectangle)
                Else
                    e.Graphics.FillRectangle(New SolidBrush(Color.Transparent), e.Item.ContentRectangle)
                End If
            End If
        End Sub

        Protected Overrides Sub OnRenderItemText(e As ToolStripItemTextRenderEventArgs)
            e.TextColor = Color.White
            MyBase.OnRenderItemText(e)
        End Sub

        Protected Overrides Sub OnRenderToolStripBorder(e As ToolStripRenderEventArgs)
            ' Optional: remove border
        End Sub
    End Class

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MenuStrip1.Renderer = New CustomRenderer()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim Logout As New Form1
        Logout.Show()
        Me.Hide()
    End Sub


End Class