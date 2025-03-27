Imports MySql.Data.MySqlClient

Public Class Form13
    Public Property BookID As String

    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBookData()
    End Sub

    Private Sub LoadBookData()
        Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")

        Try
            conn.Open()
            Dim query As String = "SELECT BookID, ISBN, Title, Author, Year, Publisher, Section, Rack, CallNumber FROM book WHERE BookID = @BookID"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@BookID", BookID)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    Label9.Text = reader("BookID").ToString()
                    TextBox8.Text = reader("ISBN").ToString()
                    TextBox2.Text = reader("Title").ToString()
                    TextBox3.Text = reader("Author").ToString()
                    TextBox4.Text = reader("Year").ToString()
                    TextBox1.Text = reader("Publisher").ToString()
                    TextBox5.Text = reader("Section").ToString()
                    TextBox6.Text = reader("Rack").ToString()
                    TextBox7.Text = reader("CallNumber").ToString()
                End If

                reader.Close()
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading book data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")

        Try
            conn.Open()
            Dim query As String = "UPDATE book SET ISBN = @ISBN, Title = @Title, Author = @Author, Year = @Year, 
                                  Section = @Section, Rack = @Rack, 
                                  CallNumber = @CallNumber WHERE BookID = @BookID"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ISBN", TextBox8.Text.Trim())
                cmd.Parameters.AddWithValue("@Title", TextBox2.Text.Trim())
                cmd.Parameters.AddWithValue("@Author", TextBox3.Text.Trim())
                cmd.Parameters.AddWithValue("@Year", TextBox4.Text.Trim())
                cmd.Parameters.AddWithValue("@Section", TextBox5.Text.Trim())
                cmd.Parameters.AddWithValue("@Rack", TextBox6.Text.Trim())
                cmd.Parameters.AddWithValue("@CallNumber", TextBox7.Text.Trim())
                cmd.Parameters.AddWithValue("@BookID", Label9.Text)

                cmd.ExecuteNonQuery()
                MessageBox.Show("Book updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using

            DialogResult = DialogResult.OK
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("Error updating book: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim back As New Form5
        back.Show()
        Me.Hide()
    End Sub
End Class
