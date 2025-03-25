Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form10
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"
        openFileDialog.Title = "Select a Book Image"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            TextBox9.Text = Path.GetFileName(openFileDialog.FileName)
            PictureBox1.Tag = openFileDialog.FileName

            Try
                PictureBox1.Image = Image.FromFile(openFileDialog.FileName)
            Catch ex As Exception
                MessageBox.Show("Failed to load image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(TextBox5.Text) OrElse  ' ISBN
           String.IsNullOrWhiteSpace(TextBox3.Text) OrElse  ' Title
           String.IsNullOrWhiteSpace(TextBox4.Text) OrElse  ' Author
           String.IsNullOrWhiteSpace(TextBox8.Text) OrElse  ' Year
           String.IsNullOrWhiteSpace(TextBox7.Text) OrElse  ' Category
           String.IsNullOrWhiteSpace(TextBox6.Text) OrElse  ' Copies
           String.IsNullOrWhiteSpace(TextBox1.Text) OrElse  ' Call Number
           String.IsNullOrWhiteSpace(TextBox2.Text) Then    ' Rack Number

            MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim isbn As String = TextBox5.Text.Trim()
        Dim title As String = TextBox3.Text.Trim()
        Dim author As String = TextBox4.Text.Trim()
        Dim year As String = TextBox8.Text.Trim()
        Dim category As String = TextBox7.Text.Trim()
        Dim status As String = "Available"
        Dim copies As Integer

        If Not Integer.TryParse(TextBox6.Text.Trim(), copies) OrElse copies <= 0 Then
            MessageBox.Show("Invalid copies value. Must be a positive number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim callNumber As String = TextBox1.Text.Trim()
        Dim rackNumber As String = TextBox2.Text.Trim()

        Dim imagePath As String = ""
        If PictureBox1.Tag IsNot Nothing Then
            Dim sourcePath As String = PictureBox1.Tag.ToString()
            Dim fileName As String = Path.GetFileName(sourcePath)
            Dim destPath As String = Path.Combine(Application.StartupPath, "Resources", fileName)

            If PictureBox1.Image IsNot Nothing Then
                PictureBox1.Image.Dispose()
            End If

            File.Copy(sourcePath, destPath, True)
            imagePath = "Resources\" & fileName

            If File.Exists(destPath) Then
                PictureBox1.Image = Image.FromFile(destPath)
            Else
                PictureBox1.Image = Nothing
                MessageBox.Show("Image not found.")
            End If
        End If

        Dim connString As String = "server=localhost; user=root; password=; database=book-borrowing;"
        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()

                Dim query As String = "INSERT INTO book (ISBN, Title, Author, Year, Category, Status, Copies, Image, CallNumber, RackNumber) 
                                       VALUES (@ISBN, @Title, @Author, @Year, @Category, @Status, @Copies, @Image, @CallNumber, @RackNumber)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ISBN", isbn)
                    cmd.Parameters.AddWithValue("@Title", title)
                    cmd.Parameters.AddWithValue("@Author", author)
                    cmd.Parameters.AddWithValue("@Year", year)
                    cmd.Parameters.AddWithValue("@Category", category)
                    cmd.Parameters.AddWithValue("@Status", status)
                    cmd.Parameters.AddWithValue("@Copies", copies)
                    cmd.Parameters.AddWithValue("@Image", imagePath)
                    cmd.Parameters.AddWithValue("@CallNumber", callNumber)
                    cmd.Parameters.AddWithValue("@RackNumber", rackNumber)

                    cmd.ExecuteNonQuery()
                End Using

                Dim bookID As String = isbn

                For i As Integer = 1 To copies
                    Dim copyID As String = $"{bookID}-{i}"
                    Dim copyQuery As String = "INSERT INTO copies (CopyID, ISBN, Status) VALUES (@CopyID, @ISBN, 'Available')"
                    Using cmd As New MySqlCommand(copyQuery, conn)
                        cmd.Parameters.AddWithValue("@CopyID", copyID)
                        cmd.Parameters.AddWithValue("@ISBN", isbn)
                        cmd.ExecuteNonQuery()
                    End Using
                Next

                MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim close As New Form5
        close.Show()
        Me.Close()
    End Sub
End Class
