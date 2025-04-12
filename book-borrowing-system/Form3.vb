Imports MySql.Data.MySqlClient
Imports System.IO

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
            Dim rawBarcode As Image = Generator.Encode(MessagingToolkit.Barcode.BarcodeFormat.Code128, ComboBox1.Text)

            Dim scaleFactor As Integer = 3
            Dim newWidth As Integer = rawBarcode.Width * scaleFactor
            Dim newHeight As Integer = rawBarcode.Height * scaleFactor
            Dim highResImage As New Bitmap(newWidth, newHeight)

            Using g As Graphics = Graphics.FromImage(highResImage)
                g.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
                g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                g.SmoothingMode = Drawing2D.SmoothingMode.None
                g.Clear(Color.White)
                g.DrawImage(rawBarcode, New Rectangle(0, 0, newWidth, newHeight))
            End Using

            PictureBox1.Image = highResImage
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
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Generator As New MessagingToolkit.Barcode.BarcodeEncoder
        Generator.BackColor = Color.White
        Generator.LabelFont = New Font("Arial", 7, FontStyle.Regular)
        Generator.IncludeLabel = True

        Dim folderPath As String = Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, "GeneratedBarcodes")
        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If

        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()
                Dim query As String = "SELECT Accno FROM books"
                Using cmd As New MySqlCommand(query, conn)
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim accno As String = reader("Accno").ToString()

                        Generator.CustomLabel = accno
                        Dim rawBarcode As Image = New Bitmap(Generator.Encode(MessagingToolkit.Barcode.BarcodeFormat.Code128, accno))

                        'Dim scaleFactor As Integer = 3
                        Dim newWidth As Integer = rawBarcode.Width
                        Dim newHeight As Integer = rawBarcode.Height
                        Dim highResImage As New Bitmap(newWidth, newHeight)

                        Using g As Graphics = Graphics.FromImage(highResImage)
                            g.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
                            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                            g.SmoothingMode = Drawing2D.SmoothingMode.None
                            g.Clear(Color.White)
                            g.DrawImage(rawBarcode, New Rectangle(0, 0, newWidth, newHeight))
                        End Using

                        PictureBox1.Image = highResImage
                        Dim fileName As String = Path.Combine(folderPath, accno & ".png")
                        highResImage.Save(fileName, Imaging.ImageFormat.Png)


                        Application.DoEvents()
                        System.Threading.Thread.Sleep(500)
                    End While
                    reader.Close()
                End Using
            Catch ex As Exception
                MessageBox.Show("Error generating barcodes: " & ex.Message)
            End Try
        End Using

        MessageBox.Show("Barcodes generated and saved in folder 'GeneratedBarcodes'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
