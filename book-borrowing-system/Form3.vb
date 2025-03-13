Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form3
    Dim connString As String = "server=localhost; user=root; password=; database=book-borrowing"
    Dim conn As New MySqlConnection(connString)

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadBooks()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        LoadBooks(TextBox1.Text)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        LoadBooks(TextBox1.Text)
    End Sub

    Private Sub LoadBooks(Optional searchQuery As String = "")
        FlowLayoutPanel1.Controls.Clear()

        Using conn As New MySqlConnection(connString)
            Dim query As String = "SELECT * FROM book WHERE Title LIKE @search OR Author LIKE @search"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@search", "%" & searchQuery & "%")

                Try
                    conn.Open()
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim bookID As String = reader("BookID").ToString()
                        Dim bookPanel As New Panel With {
                            .Size = New Size(182, 280),
                            .BackColor = Color.WhiteSmoke,
                            .BorderStyle = BorderStyle.None
                        }

                        Dim bookImage As New PictureBox With {
                            .Size = New Size(100, 137),
                            .Location = New Point(38, 13),
                            .SizeMode = PictureBoxSizeMode.StretchImage
                        }

                        Dim imagePath As String = reader("Image").ToString()
                        Try
                            If File.Exists(imagePath) Then
                                bookImage.Image = Image.FromFile(imagePath)
                            Else
                                bookImage.Image = My.Resources.image
                            End If
                        Catch ex As Exception
                            bookImage.Image = My.Resources.image
                        End Try

                        Dim bookTitle As New Label With {
                            .Text = reader("Title").ToString(),
                            .AutoSize = False,
                            .Location = New Point(10, 160),
                            .Size = New Size(160, 40),
                            .TextAlign = ContentAlignment.MiddleCenter,
                            .Font = New Font("Arial", 10, FontStyle.Bold)
                        }

                        Dim bookAuthor As New Label With {
                            .Text = reader("Author").ToString(),
                            .Location = New Point(10, 200),
                            .Size = New Size(160, 20),
                            .TextAlign = ContentAlignment.MiddleCenter
                        }

                        Dim bookCopies As New Label With {
                            .Text = "Copies: " & reader("Copies").ToString(),
                            .Location = New Point(10, 220),
                            .Size = New Size(160, 20),
                            .TextAlign = ContentAlignment.MiddleCenter
                        }

                        Dim btnBorrow As New Button With {
                            .Text = "Return",
                            .Size = New Size(80, 30),
                            .Location = New Point(51, 240),
                            .BackColor = Color.Green,
                            .ForeColor = Color.White
                        }
                        btnBorrow.Tag = bookID
                        AddHandler btnBorrow.Click, AddressOf ReturnBook

                        bookImage.Tag = bookID
                        bookPanel.Controls.Add(bookImage)
                        bookPanel.Controls.Add(bookTitle)
                        bookPanel.Controls.Add(bookAuthor)
                        bookPanel.Controls.Add(bookCopies)
                        bookPanel.Controls.Add(btnBorrow)

                        FlowLayoutPanel1.Controls.Add(bookPanel)
                    End While
                    reader.Close()

                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub ReturnBook(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim bookID As String = btn.Tag.ToString()

        Using conn As New MySqlConnection(connString)
            Dim query As String = "SELECT * FROM borrow WHERE BookID = @bookID AND Status = 'Borrowed'"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@bookID", bookID)

                Try
                    conn.Open()
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        reader.Close()

                        Dim updateQuery As String = "UPDATE borrow SET Status = 'Available', ReturnDate = NOW() WHERE BookID = @bookID AND Status = 'Borrowed'"
                        Using updateCmd As New MySqlCommand(updateQuery, conn)
                            updateCmd.Parameters.AddWithValue("@bookID", bookID)
                            updateCmd.ExecuteNonQuery()
                        End Using

                        Dim updateCopies As String = "UPDATE borrow SET Copies = Copies + 1 WHERE BookID = @bookID"
                        Using updateCopiesCmd As New MySqlCommand(updateCopies, conn)
                            updateCopiesCmd.Parameters.AddWithValue("@bookID", bookID)
                            updateCopiesCmd.ExecuteNonQuery()
                        End Using

                        MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadBooks()

                    Else
                        MessageBox.Show("No borrowed record found for this book!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim back As New Form11
        back.Show()
        Hide()
    End Sub
End Class
