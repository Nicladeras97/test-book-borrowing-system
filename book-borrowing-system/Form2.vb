Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form2
    Dim connString As String = "server=localhost; user=root; password=; database=borrowing-system;"

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim back As New Form11()
        back.Show()
        Me.Hide()
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadBooks("")
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        LoadBooks(TextBox1.Text)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        LoadBooks(TextBox1.Text)
    End Sub

    Private Sub LoadBooks(Optional searchQuery As String = "")
        FlowLayoutPanel1.Controls.Clear()

        Using conn As New MySqlConnection(connString)
            Dim query As String = "SELECT * FROM book WHERE StatusID = 'Available' AND (Title LIKE @search OR Author LIKE @search)"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@search", "%" & searchQuery & "%")

                Try
                    conn.Open()
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim bookID As String = reader("BookID").ToString()

                        Dim bookPanel As New Panel With {
                            .Size = New Size(200, 350),
                            .BorderStyle = BorderStyle.None,
                            .BackColor = Color.LightBlue,
                            .Padding = New Padding(10)
                        }

                        Dim bookTitle As New Label With {
                            .Text = reader("Title").ToString(),
                            .Location = New Point(10, 220),
                            .Size = New Size(180, 20),
                            .Font = New Font("Arial", 10, FontStyle.Bold),
                            .ForeColor = Color.Black,
                            .BackColor = Color.Transparent,
                            .TextAlign = ContentAlignment.MiddleCenter,
                            .AutoSize = False
                        }

                        Dim bookAuthor As New Label With {
                            .Text = "By: " & reader("Author").ToString(),
                            .Location = New Point(10, 245),
                            .Size = New Size(180, 15),
                            .Font = New Font("Arial", 8, FontStyle.Regular),
                            .ForeColor = Color.Black,
                            .BackColor = Color.Transparent,
                            .TextAlign = ContentAlignment.MiddleCenter,
                            .AutoSize = False
                        }

                        Dim bookImage As New PictureBox With {
                            .Size = New Size(180, 200),
                            .Location = New Point(10, 10),
                            .SizeMode = PictureBoxSizeMode.Zoom,
                            .BackColor = Color.Transparent
                        }

                        Dim imagePath As String = reader("Image").ToString()
                        If File.Exists(imagePath) Then
                            bookImage.Image = Image.FromFile(imagePath)
                        Else
                            bookImage.Image = My.Resources.image
                        End If

                        Dim btnBorrow As New Button With {
                            .Text = "Borrow",
                            .Size = New Size(90, 30),
                            .Location = New Point(55, 270),
                            .BackColor = Color.Green,
                            .ForeColor = Color.White,
                            .Font = New Font("Arial", 9, FontStyle.Bold),
                            .FlatStyle = FlatStyle.Flat,
                            .Tag = bookID
                        }
                        btnBorrow.FlatAppearance.BorderSize = 0
                        btnBorrow.Cursor = Cursors.Hand
                        AddHandler btnBorrow.Click, AddressOf BorrowBook

                        bookPanel.Controls.Add(bookImage)
                        bookPanel.Controls.Add(bookTitle)
                        bookPanel.Controls.Add(bookAuthor)
                        bookPanel.Controls.Add(btnBorrow)

                        bookPanel.Tag = reader("BookID")
                        FlowLayoutPanel1.Controls.Add(bookPanel)
                    End While
                    reader.Close()

                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Database Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub BorrowBook(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim bookID As String = btn.Tag.ToString()

        Dim bookTitle As String = ""
        Dim bookImage As String = ""
        Dim bookStatusID As String = ""

        Using conn As New MySqlConnection(connString)
            Dim query As String = "SELECT Title, Image, StatusID FROM book WHERE BookID = @bookID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@bookID", bookID)

                Try
                    conn.Open()
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        bookTitle = reader("Title").ToString()
                        bookImage = reader("Image").ToString()
                        bookStatusID = reader("StatusID").ToString()
                    End If
                    reader.Close()
                Catch ex As Exception
                    MessageBox.Show("Error fetching book details: " & ex.Message)
                End Try
            End Using
        End Using

        Dim borrowForm As New Form8(bookID, bookTitle, bookImage, bookStatusID)
        borrowForm.Show()
        Me.Close()
    End Sub
End Class
