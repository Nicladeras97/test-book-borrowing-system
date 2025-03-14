Imports MySql.Data.MySqlClient

Public Class Form3
    Dim connString As String = "server=localhost; user=root; password=; database=book-borrowing"
    Dim conn As New MySqlConnection(connString)
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBorrowedBooks()
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        LoadBorrowedBooks(TextBox1.Text)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        LoadBorrowedBooks(TextBox1.Text)
    End Sub

    Private Sub LoadBorrowedBooks(Optional searchQuery As String = "")
        FlowLayoutPanel1.Controls.Clear()

        Using conn As New MySqlConnection(connString)
            Dim query As String = "SELECT borrow.BorrowID, borrow.BookID, book.Title, book.Author, borrow.StudNo, users.FullName, borrow.BorrowDate, borrow.DueDate " &
                                  "FROM borrow " &
                                  "INNER JOIN book ON borrow.BookID = book.BookID " &
                                  "INNER JOIN users ON borrow.StudNo = users.StudNo " &
                                  "WHERE borrow.StatusName = 'Borrowed' " &
                                  "AND (book.Title LIKE @search OR users.FullName LIKE @search)"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@search", "%" & searchQuery & "%")

                Try
                    conn.Open()
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim borrowID As String = reader("BorrowID").ToString()
                        Dim bookID As String = reader("BookID").ToString()
                        Dim studentName As String = reader("FullName").ToString()
                        Dim borrowDate As String = Convert.ToDateTime(reader("BorrowDate")).ToString("MMM dd, yyyy")
                        Dim dueDate As String = Convert.ToDateTime(reader("DueDate")).ToString("MMM dd, yyyy")

                        Dim bookPanel As New Panel With {
                            .Size = New Size(182, 280),
                            .BackColor = Color.WhiteSmoke,
                            .BorderStyle = BorderStyle.None
                        }

                        Dim lblTitle As New Label With {
                            .Text = reader("Title").ToString(),
                            .AutoSize = False,
                            .Location = New Point(10, 10),
                            .Size = New Size(160, 40),
                            .TextAlign = ContentAlignment.MiddleCenter,
                            .Font = New Font("Arial", 10, FontStyle.Bold)
                        }

                        Dim lblBorrower As New Label With {
                            .Text = "Borrowed by: " & studentName,
                            .AutoSize = False,
                            .Location = New Point(10, 35),
                            .Size = New Size(200, 20)
                        }

                        Dim borrowDates As New Label With {
                            .Text = "Borrowed: " & borrowDate,
                            .AutoSize = False,
                            .Location = New Point(10, 60),
                            .Size = New Size(200, 20)
                        }

                        Dim dueDates As New Label With {
                            .Text = "Due: " & dueDate,
                            .AutoSize = False,
                            .Location = New Point(10, 80),
                            .Size = New Size(200, 20)
                        }

                        Dim btnReturn As New Button With {
                            .Text = "Return",
                            .Size = New Size(80, 30),
                            .Location = New Point(70, 110),
                            .BackColor = Color.Red,
                            .ForeColor = Color.White
                        }
                        btnReturn.Tag = borrowID
                        AddHandler btnReturn.Click, AddressOf ReturnBook

                        bookPanel.Controls.Add(lblTitle)
                        bookPanel.Controls.Add(lblBorrower)
                        bookPanel.Controls.Add(borrowDates)
                        bookPanel.Controls.Add(dueDates)
                        bookPanel.Controls.Add(btnReturn)

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
        Dim borrowID As String = btn.Tag.ToString()

        Using conn As New MySqlConnection(connString)
            Dim query As String = "UPDATE borrow SET StatusName = 'Available', ReturnDate = NOW() WHERE BorrowID = @BorrowID AND StatusName = 'Borrowed'"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@BorrowID", borrowID)

                Try
                    conn.Open()
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadBorrowedBooks()
                    Else
                        MessageBox.Show("No active borrow record found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim back As New Form11()
        back.Show()
        Me.Hide()
    End Sub
End Class
