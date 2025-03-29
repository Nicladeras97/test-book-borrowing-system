Imports MySql.Data.MySqlClient

Public Class Form13
    Public Property Accno As String

    Public Sub SetBookDetails(accNo As String, title As String, author As String, year As String, publisher As String, isbn As String, section As String, callNumber As String, rack As String)
        Label10.Text = accNo
        TextBox2.Text = title
        TextBox3.Text = author
        TextBox4.Text = year
        TextBox1.Text = publisher
        TextBox8.Text = isbn
        TextBox5.Text = section
        TextBox7.Text = callNumber
        TextBox6.Text = rack
    End Sub

    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBookData()
    End Sub

    Private Sub LoadBookData()
        Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")

        Try
            conn.Open()
            Dim query As String = "SELECT Accno, Title, Author, Year, Publisher, ISBN, Section, Rack, CallNumber FROM books WHERE Accno = @Accno"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Accno", Accno)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    Label10.Text = reader("Accno").ToString()
                    TextBox2.Text = reader("Title").ToString()
                    TextBox3.Text = reader("Author").ToString()
                    TextBox4.Text = reader("Year").ToString()
                    TextBox1.Text = reader("Publisher").ToString()
                    TextBox8.Text = reader("ISBN").ToString()
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
            Dim query As String = "UPDATE books SET Title = @Title, Author = @Author, Year = @Year, 
                                  Publisher = @Publisher, ISBN = @ISBN, 
                                  Section = @Section, Rack = @Rack, CallNumber = @CallNumber 
                                  WHERE Accno = @Accno"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Title", TextBox2.Text.Trim())
                cmd.Parameters.AddWithValue("@Author", TextBox3.Text.Trim())
                cmd.Parameters.AddWithValue("@Year", TextBox4.Text.Trim())
                cmd.Parameters.AddWithValue("@Publisher", TextBox1.Text.Trim())
                cmd.Parameters.AddWithValue("@ISBN", TextBox8.Text.Trim())
                cmd.Parameters.AddWithValue("@Section", TextBox5.Text.Trim())
                cmd.Parameters.AddWithValue("@Rack", TextBox6.Text.Trim())
                cmd.Parameters.AddWithValue("@CallNumber", TextBox7.Text.Trim())
                cmd.Parameters.AddWithValue("@Accno", Label10.Text)

                cmd.ExecuteNonQuery()
                MessageBox.Show("Book updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using

            DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error updating book: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class
