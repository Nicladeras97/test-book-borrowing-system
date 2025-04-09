Imports System.IO
Imports MySql.Data.MySqlClient
Imports OfficeOpenXml


Public Class Form15
    Public Property LoggedInUsername As String
    Private Sub LoadFormToMainPanel(form As Form)
        mainPanel.Controls.Clear()
        form.TopLevel = False
        form.FormBorderStyle = FormBorderStyle.None
        form.Dock = DockStyle.Fill
        mainPanel.Controls.Add(form)
        form.Show()
    End Sub

    Private Sub ReceivedBooksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceivedBooksToolStripMenuItem.Click
        LoadFormToMainPanel(New Form9)
    End Sub

    Private Sub AddBooksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddBooksToolStripMenuItem.Click
        LoadFormToMainPanel(New Form10)
    End Sub
    Private Sub EditBooksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditBooksToolStripMenuItem.Click
        LoadFormToMainPanel(New Form13)
    End Sub
    Private Sub DeleteBooksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteBooksToolStripMenuItem.Click
        LoadFormToMainPanel(New Form2)
    End Sub

    Private Sub ImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem.Click
        Dim openFileDialog As New OpenFileDialog
        openFileDialog.Filter = "Excel Files (.xlsx)|.xlsx"

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
        Throw New NotImplementedException()
    End Function

    Private Sub DownloadTemplateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadTemplateToolStripMenuItem.Click
        Try
            ExcelPackage.License.SetNonCommercialPersonal("book-borrowing-system")

            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Excel Files (.xlsx)|.xlsx"
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

    Private Sub ReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REportsToolStripMenuItem.Click
        LoadFormToMainPanel(New Form6)
    End Sub

    Private Sub RepairBooksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RepairBooksToolStripMenuItem.Click
        LoadFormToMainPanel(New Form5)
    End Sub

    Private Sub BarcodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BarcodeToolStripMenuItem.Click
        LoadFormToMainPanel(New Form3)
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        LoadFormToMainPanel(New Report)
    End Sub

    Private Sub Form15_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MenuStrip1.Dock = DockStyle.Left
        mainPanel.Dock = DockStyle.Fill
        MenuStrip1.Renderer = New CustomRenderer()
        MenuStrip1.BringToFront()
        mainPanel.BringToFront()

        Try
            Using conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")
                conn.Open()
                Dim query As String = "SELECT Fullname FROM librarians WHERE Username=@Username"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Username", LoggedInUsername)
                    Dim fullNameObj As Object = cmd.ExecuteScalar()
                    If fullNameObj IsNot Nothing Then
                        Dim fullName As String = fullNameObj.ToString()
                        Dim firstName As String = fullName.Split(" "c)(0)
                        Label3.Text = firstName
                    Else
                        Label3.Text = LoggedInUsername
                    End If
                End Using
            End Using
        Catch ex As Exception
            Label3.Text = LoggedInUsername
        End Try
    End Sub




    Private Function GetUserFirstName() As String
        If String.IsNullOrEmpty(LoggedInUsername) Then
            Return "Guest"
        End If

        Return LoggedInUsername
    End Function

    Public Class CustomRenderer
        Inherits ToolStripProfessionalRenderer

        Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
            Dim isSubItem As Boolean = TypeOf e.Item.Owner Is ToolStripDropDownMenu

            If e.Item.Selected Then
                If isSubItem Then
                    e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(150, 30, 30, 30)), e.Item.ContentRectangle)
                Else
                    e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(150, 30, 30, 30)), e.Item.ContentRectangle)
                End If
            Else
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

    End Class

    Private Sub LogoutToolStripMeuItem_Click(sender As Object, e As EventArgs)
        Dim logout As New Form1
        logout.Show()
        Hide()

    End Sub



    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim logout As New Form1
        logout.Show()
        Hide()
    End Sub


    Private Sub SetCurrentUserFirstName(username As String)

        Dim query As String = "SELECT FirstName FROM Users WHERE Username = @username"
        Using conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@username", username)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    LoggedInUsername = result.ToString()
                End If
            End Using
        End Using
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Panel1.BackColor = Color.FromArgb(100, 0, 0, 0)
    End Sub

    Private Sub MenuStrip1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        MenuStrip1.BackColor = Color.FromArgb(100, 0, 0, 0)
    End Sub

    Private Sub LendToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LendToolStripMenuItem.Click
        LoadFormToMainPanel(New Form8)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label2.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy - hh:mm:ss tt")
    End Sub


End Class


