Imports MySql.Data.MySqlClient

Public Class Form13
    Public Property Accno As String

    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBookData()
    End Sub

    Private Sub LoadBookData()
        Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")

        Try
            conn.Open()
            Dim query As String = "SELECT Accno, Title, Author, Year, Section, Rack, CallNumber FROM book WHERE Accno = @Accno"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Accno", Accno)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    TextBox1.Text = reader("Accno").ToString()
                    TextBox2.Text = reader("Title").ToString()
                    TextBox3.Text = reader("Author").ToString()
                    TextBox4.Text = reader("Year").ToString()
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
            Dim query As String = "UPDATE book SET Title = @Title, Author = @Author, Year = @Year, 
                                  Section = @Section, Rack = @Rack, 
                                  CallNumber = @CallNumber WHERE Accno = @Accno"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Title", TextBox2.Text.Trim())
                cmd.Parameters.AddWithValue("@Author", TextBox3.Text.Trim())
                cmd.Parameters.AddWithValue("@Year", TextBox4.Text.Trim())
                cmd.Parameters.AddWithValue("@Section", TextBox5.Text.Trim())
                cmd.Parameters.AddWithValue("@Rack", TextBox6.Text.Trim())
                cmd.Parameters.AddWithValue("@CallNumber", TextBox7.Text.Trim())
                cmd.Parameters.AddWithValue("@Accno", TextBox1.Text.Trim())

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
