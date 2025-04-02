Imports MySql.Data.MySqlClient
Public Class Form3
    Dim connString As String = "server=localhost;user id=root;password=;database=book-borrowing"
    Private Sub LoadBooks()
        ComboBox1.Items.Clear()
        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()
                Dim query As String = "SELECT Accno FROM books"
                Using cmd As New MySqlCommand(query, conn)
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        ComboBox1.Items.Add(reader("Accno").ToString())
                    End While
                    reader.Close()
                End Using
            Catch ex As Exception
                MessageBox.Show("Error loading books: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Generator As New MessagingToolkit.Barcode.BarcodeEncoder
        Generator.BackColor = Color.White
        Generator.LabelFont = New Font("Arial", 7, FontStyle.Regular)
        Generator.IncludeLabel = True
        Generator.CustomLabel = ComboBox1.Text
        Try
            PictureBox1.Image = New Bitmap(Generator.Encode(MessagingToolkit.Barcode.BarcodeFormat.Code93, ComboBox1.Text))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim SD As New SaveFileDialog
        SD.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
        SD.FileName = ComboBox1.Text
        SD.SupportMultiDottedExtensions = True
        SD.AddExtension = True
        SD.Filter = "PNG File|*.png"
        If SD.ShowDialog() = DialogResult.OK Then
            Try
                PictureBox1.Image.Save(SD.FileName, Imaging.ImageFormat.Png)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PictureBox1.Image = Nothing
        ComboBox1.Focus()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBooks()
    End Sub
End Class