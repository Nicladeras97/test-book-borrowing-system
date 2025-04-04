Imports MySql.Data.MySqlClient

Public Class Form13
    Private connString As String = "server=localhost; user=root; password=; database=book-borrowing;"

    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBookAccnos()
    End Sub

    Private Sub LoadBookAccnos()
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
                End Using
            Catch ex As Exception
                MessageBox.Show("Error loading Accno: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ComboBox1.SelectedItem Is Nothing Then
            MessageBox.Show("Please select an Accno.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedAccNo As String = ComboBox1.SelectedItem.ToString()
        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()
                Dim query As String = "SELECT * FROM books WHERE Accno = @Accno"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Accno", selectedAccNo)
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        TextBox2.Text = reader("Title").ToString()
                        TextBox3.Text = reader("Author").ToString()
                        TextBox4.Text = reader("Year").ToString()
                        TextBox1.Text = reader("Publisher").ToString()
                        TextBox8.Text = reader("ISBN").ToString()
                        TextBox5.Text = reader("Section").ToString()
                        TextBox7.Text = reader("CallNumber").ToString()
                        TextBox6.Text = reader("Rack").ToString()
                    Else
                        MessageBox.Show("Book not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving book details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using conn As New MySqlConnection(connString)
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
                    cmd.Parameters.AddWithValue("@Accno", ComboBox1.SelectedItem.ToString())

                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Book updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using

                Dim back As New Form15
                back.Show()
                Me.Hide()

            Catch ex As Exception
                MessageBox.Show("Error updating book: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim cancel As New Form15
        cancel.Show()
        Me.Hide()
    End Sub
End Class
