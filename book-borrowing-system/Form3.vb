Imports MySql.Data.MySqlClient
Imports MessagingToolkit.Barcode
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

    Private Sub GenerateBarcode()
        Try
            Dim encoder As New BarcodeEncoder()
            encoder.BackColor = Color.White
            encoder.LabelFont = New Font("Arial", 7, FontStyle.Regular)
            encoder.IncludeLabel = True
            encoder.CustomLabel = ComboBox1.Text


            Dim barcodeImage As Bitmap = encoder.Encode(BarcodeFormat.Code128, ComboBox1.Text)


            PictureBox1.Image = barcodeImage
        Catch ex As Exception
            MessageBox.Show("Error generating barcode: " & ex.Message)
        End Try
    End Sub


    Private Sub SaveBarcode()
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
                MessageBox.Show("Error saving barcode: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub GenerateAndSaveAllBarcodes()
        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()
                Dim query As String = "SELECT Accno FROM books"
                Using cmd As New MySqlCommand(query, conn)
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()
                    Dim barcodeGenerator As New BarcodeEncoder With {
                        .BackColor = Color.White,
                        .LabelFont = New Font("Arial", 7, FontStyle.Regular),
                        .IncludeLabel = True
                    }

                    Dim saveFolder As String = Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, "Barcodes")
                    If Not Directory.Exists(saveFolder) Then
                        Directory.CreateDirectory(saveFolder)
                    End If

                    While reader.Read()
                        Dim accno As String = reader("Accno").ToString()
                        barcodeGenerator.CustomLabel = accno

                        Dim barcodeImage As Bitmap = barcodeGenerator.Encode(BarcodeFormat.Code93, accno)

                        Dim filePath As String = Path.Combine(saveFolder, accno & ".png")
                        barcodeImage.Save(filePath, Imaging.ImageFormat.Png)
                    End While

                    reader.Close()
                    MessageBox.Show("All barcodes are saved in: " & saveFolder, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            Catch ex As Exception
                MessageBox.Show("Error generating barcodes: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GenerateBarcode()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SaveBarcode()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PictureBox1.Image = Nothing
        ComboBox1.Focus()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        GenerateAndSaveAllBarcodes()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBooks()
    End Sub

End Class
